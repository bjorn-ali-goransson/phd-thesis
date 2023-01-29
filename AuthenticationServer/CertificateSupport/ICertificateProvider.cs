using System.Security.Cryptography;

namespace AuthenticationServer.CertificateSupport
{
    public interface ICertificateProvider
    {
        string GenerateNew(string key);
        bool Verify(string key);
    }
}