using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class UserLoginModel
    {
        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public string? UserTypeName { get; set; }

        public string? UserName { get; set; }

        public string? FullName { get; set;}

    }
}
