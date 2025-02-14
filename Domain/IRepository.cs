using Domain.DTO;

namespace Domain
{
    public interface IRepository
    {
        void Create(UserDTO user);
        bool Check(string login);
        List<UserDTO> GetAll();
        UserDTO GetById(int id);

    }
}
