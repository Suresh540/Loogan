using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class StaffModel
    {
        public int StaffId { get; set; }

        public int? UserId { get; set; }
        public string? Code { get; set; }

        public string? StaffName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int TotalRecords { get; set; }
    }
}
