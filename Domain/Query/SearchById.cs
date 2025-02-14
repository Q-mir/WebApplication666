using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    public class SearchById : IQuery
    {
        public int Id { get; set; }
    }
}
