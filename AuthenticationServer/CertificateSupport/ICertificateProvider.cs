using System.Security.Cryptography;

namespace AuthenticationServer.CertificateSupport
{
    public interface ICertificateProvider
    {
        string GetPublicKey();
        string Encrypt(string value);
        string Decrypt(string value);
    }
}