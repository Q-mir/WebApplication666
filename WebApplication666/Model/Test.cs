using Domain.DTO;
using Domain.Query;
using Service;

namespace WebApplication666.Model
{
    public class Test : IQueryService<All, List<UserDTO>>
    {
        public List<UserDTO> Execute(All obj)
        {

        }
    }
}
