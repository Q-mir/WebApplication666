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
}
