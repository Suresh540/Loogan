using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class InstitutionModel
    {
        public int InstitutionId { get; set; }

        public string InstitutionName { get; set; } = null!;

        public string? Description { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }

        public string? Website { get; set; }

        public string? InstitutionImageUrl { get; set; }

        public string? Mission { get; set; }

        public string? Vision { get; set; }

        public string? AdditionalComments { get; set; }

        public bool IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int TotalRecords { get; set; }
    }
}
