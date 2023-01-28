using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthenticationServer.Controllers
{
    public class VerifyController
    {
        [Route("/verify")]
        public object Verify(string payload)
        {
            return "";
        }
    }
}
