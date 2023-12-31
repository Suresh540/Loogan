﻿using System;
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
}
