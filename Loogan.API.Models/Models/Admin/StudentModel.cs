using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string? StudentNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? AdminssionReprestative { get; set; }
        public string? Title { get; set; }

        public string? Suffix { get; set; }

        public string? MaidenName { get; set; }

        public string? NickName { get; set; }

        public string? MiddleInitial { get; set; }

        public int? CitizenShipStatusId { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }

        public int? StateId { get; set; }

        public string? StateName { get; set; }

        public int? AdminssionRepresentativeId { get; set; }

        public int? CampusId { get; set; }

        public int? ProgramId { get; set; }

        public int? SchoolId { get; set; }

        public string? PostalCode { get; set; }

        public int? EducationalLevelId { get; set; }

        public int? EthnicGroupId { get; set; }

        public int? GenderId { get; set; }

        public string? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public int? NationalityId { get; set; }

        public int? ProgramGroupId { get; set; }

        public int? ProspectId { get; set; }

        public int? ProspectCategoryId { get; set; }

        public int? ProspectTypeId { get; set; }

        public DateTime? OriginalExceptedStartDate { get; set; }

        public DateTime? OriginalStartDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public int? HispanicInd { get; set; }

        public int? VeteranInd { get; set; }

        public int TotalRecords { get; set; }

    }
}
