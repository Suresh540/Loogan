using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class MenuModel
    {
        public int PrimaryMenuId { get; set; }

        public string? MenuName { get; set; }

        public string? MenuCode { get; set; }

        public string? MenuUrl { get; set;}

        public string? MenuIcon { get; set;}

        public int SequenceOrder { get; set;}
    }
}
