using Domain.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    public class GetUserByIdQuery : IQueryService<SearchById, UserDTO>
    {
        private readonly IRepository _repository;

        public GetUserByIdQuery(Domain.IRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public UserDTO Execute(SearchById obj)
        {
            if (obj.Id <= 0) return null;
            return _repository.GetById(obj.Id);
        }
    }
}
