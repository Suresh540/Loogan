using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class InstitutionUserModel
    {
        public int InstitutionUserMappingId { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public int? UserTypeId { get; set; }
       
    }
}
