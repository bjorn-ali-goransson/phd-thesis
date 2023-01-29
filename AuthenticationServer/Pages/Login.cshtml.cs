using AuthenticationServer.CertificateSupport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AuthenticationServer.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost(IFormFile certificate, string callback, [FromServices] ICertificateProvider certificateProvider, [FromServices] ILogger<LoginModel> logger)
        {
            if (certificate == null)
            {
                logger.LogError("No certificate found");
                return Content("No certificate found");
            }

            try
            {
                using var stream = certificate.OpenReadStream();
                
                var key = JsonDocument.Parse(certificateProvider.Decrypt(new StreamReader(stream).ReadToEnd()));

                if (key.RootElement.GetProperty("type").ToString() != "userkey")
                {
                    logger.LogError("Invalid key");
                    return Content("Invalid key");
                }

                return Redirect(callback);
            }
            catch(Exception exception)
            {
                logger.LogError(exception, "Invalid key");
                return Content("Invalid key");
            }
        }
    }
}
