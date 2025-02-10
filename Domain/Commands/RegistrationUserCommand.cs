using Domain.DTO;

namespace Domain.Commands;

public class RegistrationUserCommand : Service.ICommand<UserDTO>
{
    private readonly IRepository _repository;
    public RegistrationUserCommand(IRepository repository)
    {
        ArgumentNullException.ThrowIfNull(nameof(repository));
        _repository = repository;
    }

    public void Execute(UserDTO obj)
    {
        if (obj.Login.Length < 3 || obj.Password.Length < 3) return;

        if (!_repository.Check(obj.Login))
        {
            _repository.Create(obj);
        }
    }
}

