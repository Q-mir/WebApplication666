using Domain.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    public class AllUsersService : IQueryService<All, List<UserDTO>>
    {
        private readonly IRepository _repository;

        public AllUsersService(IRepository repository)
        {
            ArgumentNullException.ThrowIfNull(nameof(repository));
            _repository = repository;
        }

        public List<UserDTO> Execute(All obj)
        {
            return null;
        }
    }
}
