using Microsoft.AspNetCore.Mvc;
using WebApi.Aplication.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]

    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "danta" && password == "123")
            {
                var token = TokenService.GenerateToken(new Model.Employee();
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
       
    }
}
