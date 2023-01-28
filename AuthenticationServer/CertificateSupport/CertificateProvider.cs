using System.Security.Cryptography;
using System.Text;

namespace AuthenticationServer.CertificateSupport
{
    public class CertificateProvider : ICertificateProvider
    {
        IDictionary<string, Certificate> Certificates { get; } = new Dictionary<string, Certificate>();

        public Certificate GenerateNew()
        {
            //This code creates a 2048-bit key
            using var rsa = RSA.Create(2048);
            
            var certificate = new Certificate(Convert.ToBase64String(rsa.ExportRSAPublicKey()), Convert.ToBase64String(rsa.ExportRSAPrivateKey()));

            Certificates[certificate.PublicKey] = certificate;

            return certificate;
        }

        public RSA? Get(string publicKey)
        {
            if (!Certificates.ContainsKey(publicKey))
            {
                return null;
            }

            var rsa = RSA.Create(2048);
            var certificate = Certificates[publicKey];

            rsa.ImportRSAPublicKey(Convert.FromBase64String(certificate.PublicKey), out var _);
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(certificate.PrivateKey), out var _);

            return rsa;
        }
    }
}
