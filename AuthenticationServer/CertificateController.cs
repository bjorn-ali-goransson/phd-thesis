using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace phd_thesis.Controllers
{
    public class CertificateController
    {
        [Route("/certificate/download")]
        public string Generate(string username)
        {
            //This code creates a 2048-bit key
            using (var rsa = RSA.Create(2048))
            {
                return Convert.ToBase64String(rsa.ExportRSAPublicKey());
            }
        }
    }
}
