using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class PagingModel
    {
        public int TotalRecords { get; set; }

        public int Pagesize { get; set; } = 10;

        public int PageIndex { get; set; } = 1;
    }
}
