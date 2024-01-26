﻿using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Interfaces
{
    public interface ILooganCalendar
    {
        public Task<List<CourseCalendarModel>> GetCourseCalendarDetails();
    }
}
