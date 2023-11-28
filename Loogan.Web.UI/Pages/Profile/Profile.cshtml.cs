using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Profile
{
    public class ProfileModel : PageModel
    {

        [BindProperty]
        public List<SectionModel>? LeftSectionValues { get; set; }

        [BindProperty]
        public List<SectionModel>? RightSectionValues { get; set; }

        public void OnGet()
        {
            LeftSectionValues = new List<SectionModel> {
                new SectionModel()
                {
                    SectionName = "Basic Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Full Name","Suresh Kalaga" },
                        {"Email Address", "Suresh.Kalaga@outlook.com" }

                    }
                },
                new SectionModel()
                {
                    SectionName = "Additional Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Gender","Male" },
                        {"Additional Name", "Test" },
                        {"Education Level", "Post Graduate School" },
                        {"Website", "<a href='#'>Add Website</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = "Contact Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Mailing Address","<a href='#'>Add mailing address</a>" },
                        {"Phone Number", "<a href='#'>Add phone number</a>" },
                        {"Business Fax Number", "<a href='#'>Add business fax number</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = "Job Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Company","<a href='#'>Add company</a>" },
                        {"Job Title", "<a href='#'>Add job title</a>" },
                        {"Department", "<a href='#'>Add department</a>" },
                    }
                }

            };

            RightSectionValues = new List<SectionModel> {
                new SectionModel()
                {
                    SectionName = "System Settings",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Langauage","Engilsh (United states)" },
                        {"Privacy Settigs", "<a href='#'>Only instructors can <br/> view my profile<br/> information</a>" },
                        {"Global Notification Settings", "<a href='#'>Stream notifications</a> <br/><a href='#'>Email notifications</a><br/><a href='#'>Push notifications</a>" },
                    }
                },
            };


        }
    }

    public class SectionModel
    {
        public string? SectionName { get; set; }

        public Dictionary<string, string>? SectionValueData { get; set; }
    }
}
