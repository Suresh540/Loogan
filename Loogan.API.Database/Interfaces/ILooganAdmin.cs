using Loogan.API.Database.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Interfaces
{
    public interface ILooganAdmin
    {
        public Task<List<CourseModel>?> GetAllCourses();

        public Task<int?> CreateCourse(Course courseModelObj);
        public Task<int?> UpdateCourse(Course courseModelObj);

        public Task<List<StaffModel>?> GetAllStaff();

        public Task<int?> CreateStaff(Staff staffModelObj);
        public Task<int?> UpdateStaff(Staff staffModelObj);

        public Task<List<StudentModel>?> GetAllStudents();

        public Task<int?> CreateStudent(Student studentModelObj);
        public Task<int?> UpdateStudent(Student studentModelObj);
    }
}
