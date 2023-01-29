using System.Security.Cryptography;
using System.Text;

namespace AuthenticationServer.CertificateSupport
{
    public class CertificateProvider : ICertificateProvider, IDisposable
    {
        //This code creates a 2048-bit key
        RSA RSA { get; } = RSA.Create(2048);

        public string GenerateNew(string key)
        {
            return Convert.ToBase64String(RSA.Encrypt(Encoding.UTF8.GetBytes(key), RSAEncryptionPadding.OaepSHA512));
        }

        public void Dispose()
        {
            RSA.Dispose();
        }
    }
}
