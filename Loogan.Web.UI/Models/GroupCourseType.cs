using Loogan.API.Models.Models;

namespace Loogan.Web.UI.Models
{
    public class GroupCourseType
    {
        public string? CourseType { get; set; }

        public List<StudentCourseModel>? StudentCourseModels { get; set; }
    }
}
