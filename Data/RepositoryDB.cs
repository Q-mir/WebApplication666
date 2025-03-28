﻿using Domain.Commands;
using Domain.DTO;
namespace Data;

public class RepositoryDB : Domain.IRepository
{
    private readonly Connection _connection;

    public RepositoryDB(Connection connection)
    {
        ArgumentNullException.ThrowIfNull(nameof(connection));
        _connection = connection;
    }

    public bool Check(string login)
                => _connection.Clients.Any(client => client.Login.ToLower() == login.ToLower());

    public void Create(UserDTO user)
    {
        Client client = new Client()
        {
            Login = user.Login,
            Password = user.Password,
            Country = user.Country
        };
        _connection.Clients.Add(client);
        _connection.SaveChanges();
    }

    public List<UserDTO> GetAll()
        => _connection.Clients.Select(client => Convert(client)).ToList();

    public UserDTO GetById(int id)
    {
        var client = _connection.Clients.FirstOrDefault(client => client.Id == id);
        return client == null ? null : Convert(client);
    }

    private static UserDTO? Convert(Client item)
        => item == null ? null : new UserDTO()
        {
            Id = item.Id,
            Login = item.Login,
            Country = item.Country,
            Password = item.Password,
        };

    public bool Update(UpdateClient client)
    {
        var item = _connection.Clients.FirstOrDefault(row => row.Id == client.Id);
        if (item == null) return false;

        item.Password = client.Password;
        item.Country = client.Country;
        _connection.Update(item);
        return _connection.SaveChanges() > 0;
    }
}
