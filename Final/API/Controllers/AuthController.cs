using API.Models.RequestModels;
using API.Models.ResponseModels;
using APIService;
using APIService.Models;
using Logger;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        DBLogger _logger = DBLogger.Instance();
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

            //Check if username exists, if it does return bad request
            string username = model.Username;
            bool usernameExist = service.UsernameExist(username);
            if (!usernameExist)
            {
                return BadRequest(new AuthResponseModel()
                {
                    Message = "Username already exists.",
                    Success = false
                });
            }

            //Create salt and hash password with salt
            model.Salt = APIService.Utilities.HashUtil.GenerateSalt();
            model.Password = APIService.Utilities.HashUtil.HashPasswordWithSalt(auth.Password, model.Salt);
            
            UserRecordModel record = new UserRecordModel() 
            {
                Username = model.Username,
                Password = model.Password,
                Salt = model.Salt,
                SignupTime = model.SignupTime
            };
            
            //add new user to the db and return the unquieidentifier generated with it
            model.Id = service.AddUser(record);

            _logger.Log("INFO",$"New user sign up successful. {model.Id} registered at {DateTime.Now}.");

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
            string validLogin = service.ValidLogin(auth.Username, auth.Password);

            if(validLogin != string.Empty) 
            {
                _logger.Log("INFO", $"Sucessful login by {auth.Username} at {DateTime.Now}");
                return Ok(new AuthResponseModel()
                {
                    Message = "Login Successful.",
                    Success = true,
                    Id = validLogin
                });
            }
            else
            {
                _logger.Log("WARNING",$"Failed login attempt to account {auth.Username} at {DateTime.Now}");
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
