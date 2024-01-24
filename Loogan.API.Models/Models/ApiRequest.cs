using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class ApiRequest
    {
        public string? RequestValue { get; set; }

    }

    public class ApiLookUpRequest
    {
        public string LookupType { get; set; }

        public int LanguageId { get; set; }
    }

    public class UserNameEmailRequest
    {
        public string Text { get; set; }

        public int UserId { get; set; }
    }
}
