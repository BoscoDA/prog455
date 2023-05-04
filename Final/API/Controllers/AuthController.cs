using APIService;
using APIService.Models;
using APIService.Models.RequestModels;
using APIService.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthService service;

        public AuthController()
        {
            service = new AuthService();
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody] AuthRequestModel auth)
        {
            UserModel model = new UserModel();
            model.Username = auth.Username;
            model.SignupTime = DateTime.Now;

            string username = model.Username;

            if (service.UsernameExist(username))
            {
                return BadRequest(new AuthResponseModel()
                {
                    Message = "Username already exists.",
                    Success = false
                });
            }

            model.Password = auth.Password;

            model.Id = service.AddUser(model);

            return Ok(new AuthResponseModel()
            {
                Message = "Signup Successful.",
                Success = true,
                Id = model.Id.ToString()
            });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthRequestModel auth)
        {
            string validLogin = service.ValidUsername(auth.Username, auth.Password);

            if(validLogin != string.Empty) 
            {
                return Ok(new AuthResponseModel()
                {
                    Message = "Login Successful.",
                    Success = true,
                    Id = validLogin
                });
            }
            else
            {
                return Unauthorized(new AuthResponseModel()
                {
                    Message = "Invalid Credentials.",
                    Success = false,
                    Id = string.Empty
                });
            }
        }
    }
}
