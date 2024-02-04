using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class EmailTemplatesModel
    {
        public int EmailTemplateId { get; set; }

        public int MasterEmailTemplateId { get; set; }

        public string? EmailTemplateName { get; set; }   

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public bool IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int TotalRecords { get; set; }
    }
}
