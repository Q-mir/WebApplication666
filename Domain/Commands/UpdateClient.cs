using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class UpdateClient
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsValidation
        {
            get => Id <= 0 && Country.Length < 3 && Password.Length < 3;
        }
    }
}
