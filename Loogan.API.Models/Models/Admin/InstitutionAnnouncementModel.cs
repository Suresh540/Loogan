﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class InstitutionAnnouncementModel
    {
        public int InstitutionAnnouncementId { get; set; }

        public string? InstitutionName { get; set; }
        public int InstitutionId { get; set; }

        public string? Title { get; set; }

        public string? Announcement { get; set; }

        public string? Description { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public bool IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int TotalRecords { get; set; }
    }
}
