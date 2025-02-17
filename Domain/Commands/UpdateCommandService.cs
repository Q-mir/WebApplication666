using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class UpdateCommandService : ICommand<UpdateClient>
    {
        private readonly IRepository _repository;

        public UpdateCommandService(IRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(UpdateClient obj)
        {
            if (!obj.IsValidation)
            {
                throw new MissingFieldException();
            }
            if (!_repository.Update(obj))
            {
                throw new InvalidDataException();
            }
        }
    }
}
