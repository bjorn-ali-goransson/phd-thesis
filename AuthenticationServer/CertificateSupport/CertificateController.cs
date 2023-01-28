using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthenticationServer.CertificateSupport
{
    public class CertificateController
    {
        [Route("/certificate/generate")]
        public object Generate([FromServices] ICertificateProvider certificateProvider)
        {
            var certificate = certificateProvider.GenerateNew();

            return new { certificate = certificate.PublicKey };
        }
    }
}
