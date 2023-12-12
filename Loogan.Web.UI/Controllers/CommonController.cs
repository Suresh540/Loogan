using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Loogan.Web.UI.Controllers
{
    [Route("Common")]
    public class CommonController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;
        public CommonController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [Route("GetMasterLookupValues")]
        public async Task<JsonResult> GetMasterLookupValues(string lookUpType)
        {
            var apiRequest = new ApiRequest() { RequestValue = lookUpType };
            var masterLookUpValues = new List<DropDownListModel>();

            //var masterLookUpValues = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetMasterLookupValues");

            //Temp starts
            var genderList = new List<DropDownListModel>();
            genderList.Add(new DropDownListModel() { Id = 4, Name = "Male" });
            genderList.Add(new DropDownListModel() { Id = 5, Name = "Female" });
            genderList.Add(new DropDownListModel() { Id = 6, Name = "Transgender" });

            var educationlevel = new List<DropDownListModel>();
            educationlevel.Add(new DropDownListModel() { Id = 7, Name = "Not disclosed" });
            educationlevel.Add(new DropDownListModel() { Id = 8, Name = "K-8" });
            educationlevel.Add(new DropDownListModel() { Id = 9, Name = "High School" });
            educationlevel.Add(new DropDownListModel() { Id = 10, Name = "Freshman" });
            educationlevel.Add(new DropDownListModel() { Id = 14, Name = "Graduate School" });
            educationlevel.Add(new DropDownListModel() { Id = 15, Name = "Post-Graduate School" });

            var languageList = new List<DropDownListModel>();
            languageList.Add(new DropDownListModel() { Id = 1, Name = "English" });
            languageList.Add(new DropDownListModel() { Id = 2, Name = "Telugu" });
            languageList.Add(new DropDownListModel() { Id = 3, Name = "Hindi" });

            if (lookUpType == "gender")
                masterLookUpValues = genderList;
            else if(lookUpType == "educationlevel")
                masterLookUpValues = educationlevel;
            else if(lookUpType == "language")
                masterLookUpValues = languageList;

            //Temp ends


            return Json(masterLookUpValues);
        }
    }
}
