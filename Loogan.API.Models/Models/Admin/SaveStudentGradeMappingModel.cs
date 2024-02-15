using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class SaveStudentGradeMappingModel
    {
        public int GradeStudentMappingId { get; set; }

        public int StudentCourseMappingId { get; set; }//

        public int MasterGradeId { get; set; }//

        public string? Remarks { get; set; }//

        public bool IsDeleted { get; set; }

        public int? CreatedBy { get; set; }//

        public DateTime? CreatedDate { get; set; }//

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
