
using Domain;
using Domain.Commands;
using Domain.DTO;
using Moq;
using Service;

namespace TestDomain;

public class UnitTest1
{
    [Fact]
    public void Adduser()
    {
        //ARRAGE
        IMock mock = new IMock<IRepository>(MockBehavior.Strict);
        ICommand<UserDTO> obj = new RegistrationUserCommand();
        UserDTO userDTO = new UserDTO()
        {
            Id = 1,
            Country = "testName",
            Password = "testPassword",
            Login = "testLogin"
        };
        //ACT

        //ASSERT
    }
}