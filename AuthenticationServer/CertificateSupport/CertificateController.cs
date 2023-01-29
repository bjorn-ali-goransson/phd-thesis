using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.Json;

namespace AuthenticationServer.CertificateSupport
{
    public class CertificateController
    {
        [Route("/certificate/generate")]
        public object Generate([FromServices] ICertificateProvider certificateProvider)
        {
            var certificate = certificateProvider.Encrypt(JsonSerializer.Serialize(new { type = "userkey", date = DateTime.Now }));

            return new { certificate };
        }
    }
}
