using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthenticationServer.Controllers
{
    public class CertificateController
    {
        [Route("/certificate/generate")]
        public object Generate()
        {
            //This code creates a 2048-bit key
            using (var rsa = RSA.Create(2048))
            {
                return new
                {
                    certificate = Convert.ToBase64String(rsa.ExportRSAPublicKey()),
                };
            }
        }
    }
}
