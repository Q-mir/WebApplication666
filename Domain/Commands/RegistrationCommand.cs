using Domain.DTO;
using Service;

namespace Domain.Commands
{
    public class RegistrationCommand : ICommand<UserDTO>
    {
        public void Execute(UserDTO obj)
        {
            using (var stream = new StreamWriter(@"c:\1\reg.txt", true))
            {
                stream.WriteLine($"{obj.Login}{obj.Password}{obj.Country}");
            }
        }
    }
}
