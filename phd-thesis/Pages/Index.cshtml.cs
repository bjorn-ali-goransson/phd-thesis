using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Website
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost(IFormFile certificate)
        {
            if(certificate == null)
            {
                return Content("No certificate found");
            }

            try
            {
                byte[] certificateBytes;
                using (var stream = certificate.OpenReadStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    certificateBytes = Convert.FromBase64String(reader.ReadToEnd());
                }
                using (var rsa = RSA.Create(2048))
                {
                    rsa.ImportRSAPublicKey(certificateBytes, out var read);

                    var message = "LOGIN";

                    var payload = rsa.Encrypt(Encoding.UTF8.GetBytes(message), RSAEncryptionPadding.Pkcs1);

                    return Redirect($"https://localhost:7274/verify?payload={Convert.ToBase64String(payload)}&return=https://localhost:7039/callback");
                }
            }
            catch
            {
                return Content("Invalid certificate");
            }
        }
    }
}
