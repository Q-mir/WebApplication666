using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Client
    {
        [Key,Required]
        public int Id { get; set; }
        
        [MaxLength(10), Required]
        public string Login { get; set; } = null!;
        
        [MaxLength(10),Required]
        public string Password { get; set; } = null!;
        
        [MaxLength(100),Required]
        public string Country { get; set; } = null!;
    }
}
