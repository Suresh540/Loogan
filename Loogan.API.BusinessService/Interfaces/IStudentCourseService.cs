﻿using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Interfaces
{
    public interface IStudentCourseService
    {
        public Task<List<StudentCourseModel>> GetStudentCourseDetails(int studentId);
    }
}