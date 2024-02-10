using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Shared
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public string Message { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "institutionimages", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    Message = "Image uploaded successfully";
                }
                catch (Exception ex)
                {
                    Message = "Error: " + ex.Message.ToString();
                }
            }
            else
            {
                Message = "You have not specified a file.";
            }

            return Page();
        }
    }
}
