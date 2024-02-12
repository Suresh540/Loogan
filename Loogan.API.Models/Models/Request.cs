using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class Request
    {
        public int LanguageId { get; set; }
    }

    public class RoleMenuRequest
    {
        public int RoleId { get; set; }
        public int LanguageId { get; set; }
    }

    public class SaveRoleMenuRequest
    {
        public int? MenuRoleMappingId { get; set; }
        public int RoleId { get; set; }

        public int PrimaryMenuId { get; set; }
    }

    public class InstitutionUserRequest
    {
        public int InstitutionId { get; set; }
        public int UserTypeId { get; set; }
    }

    public class SaveInstitutionUserRequest
    {
        public int? InstitutionUserMappingId { get; set; }
        public int InstitutionId { get; set; }
        public int UserTypeId { get; set; }
        public int UserId { get; set; }
    }
}
