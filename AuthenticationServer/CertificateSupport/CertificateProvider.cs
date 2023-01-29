using System.Security.Cryptography;
using System.Text;

namespace AuthenticationServer.CertificateSupport
{
    public class CertificateProvider : ICertificateProvider, IDisposable
    {
        //This code creates a 2048-bit key
        RSA Certificate { get; } = RSA.Create(2048);

        public string GetPublicKey()
        {
            return Convert.ToBase64String(Certificate.ExportRSAPublicKey());
        }

        public string Encrypt(string value)
        {
            return Convert.ToBase64String(Certificate.Encrypt(Encoding.UTF8.GetBytes(value), RSAEncryptionPadding.OaepSHA512));
        }

        public string Decrypt(string value)
        {
            return Encoding.UTF8.GetString(Certificate.Decrypt(Convert.FromBase64String(value), RSAEncryptionPadding.OaepSHA512));
        }

        public void Dispose()
        {
            Certificate.Dispose();
        }
    }
}
