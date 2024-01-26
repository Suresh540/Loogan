using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Services;
using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ILooganCalendar _looganCalendar;
        private readonly IMapper _mapper;

        public CalendarService(ILooganCalendar looganCalendar, IMapper mapper)
        {
            _looganCalendar = looganCalendar;
            _mapper = mapper;
        }

        public async Task<List<CourseCalendarModel>> GetCourseCalendarDetails()
        {
            var studentCourseMappingModelList = await _looganCalendar.GetCourseCalendarDetails();
            return studentCourseMappingModelList;
        }
    }
}
