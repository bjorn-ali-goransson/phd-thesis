using System.Security.Cryptography;

namespace AuthenticationServer.CertificateSupport
{
    public interface ICertificateProvider
    {
        Certificate GenerateNew();
        RSA? Get(string publicKey);
    }
}