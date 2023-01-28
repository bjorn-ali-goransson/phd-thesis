using AuthenticationServer.CertificateSupport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationServer.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost(IFormFile certificate, string @return, [FromServices] ICertificateProvider certificateProvider, [FromServices] ILogger<LoginModel> logger)
        {
            if (certificate == null)
            {
                return Content("No certificate found");
            }

            try
            {
                using var stream = certificate.OpenReadStream();
                
                using var rsa = certificateProvider.Get(new StreamReader(stream).ReadToEnd());

                if(rsa == null)
                {
                    return Content("Certificate not found");
                }

                return Redirect(@return);
            }
            catch(Exception exception)
            {
                logger.LogError(exception, "Invalid certificate");
                return Content("Invalid certificate");
            }
        }
    }
}
