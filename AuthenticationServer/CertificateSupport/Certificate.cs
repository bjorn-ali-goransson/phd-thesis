namespace AuthenticationServer.CertificateSupport
{
    public record Certificate(
        string PublicKey,
        string PrivateKey
    );
}
