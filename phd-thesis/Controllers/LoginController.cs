using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class LoginController : Controller
    {
        [Route("/login-callback")]
        public async Task<IActionResult> Callback(IHttpClientFactory httpClientFactory, string action, string key)
        {
            if(action != "login")
            {
                return Content("Unknown action");
            }

            var httpClient = httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync($"https://localhost:7274/verify?key={key}");

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return Content("Could not verify");
            }

            // login

            return Redirect("/");
        }
    }
}
