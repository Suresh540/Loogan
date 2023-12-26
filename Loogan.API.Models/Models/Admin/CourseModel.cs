using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        public int? CourseGroupId { get; set; }

        public string? CourseGroupName { get; set; }

        public string CourseCode { get; set; } = null!;

        public string? CourseName { get; set; }

        public string? CourseDesc { get; set; }

        public double? CreditHours { get; set; }
        public double? Credits { get; set; }

        public int TotalRecords { get; set; }

    }
}
