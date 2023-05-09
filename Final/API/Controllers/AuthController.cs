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

        /// <summary>
        /// api endpoint to handle logic for registering a new user to the database
        /// </summary>
        /// <param name="auth">Request modle that contains the username and password for the user</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody] AuthRequestModel auth)
        {
            try
            {
                UserModel model = new UserModel();
                model.Username = auth.Username;
                model.SignupTime = DateTime.Now;

                //Check if username exists, if it does return bad request
                string username = model.Username!;
                bool usernameExist = service.UsernameExist(username!);
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
                model.Password = APIService.Utilities.HashUtil.HashPasswordWithSalt(auth.Password!, model.Salt);

                UserRecordModel record = new UserRecordModel()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Salt = model.Salt,
                    SignupTime = model.SignupTime
                };

                //add new user to the db and return the unquieidentifier generated with it
                model.Id = service.AddUser(record);

                _logger.Log("INFO", $"New user sign up successful. {model.Id} registered at {DateTime.Now}.");

                return Ok(new AuthResponseModel()
                {
                    Message = "Signup Successful.",
                    Success = true,
                    Id = model.Id.ToString()
                });
            }
            catch (Exception ex)
            {
                _logger.Log("ERROR", "Exception thrown by Guess()", ex);
                return BadRequest(new AuthResponseModel()
                {
                    Message = "Exception was thrown.",
                    Success = false,
                    Id = ""
                });
            }
            
        }


        /// <summary>
        /// Handles HTTP POST requests to authenticate a user's login credentials
        /// </summary>
        /// <param name="auth">An AuthRequestModel object containing the user's login information</param>
        /// <returns>
        /// If authentication is successful, returns an HTTP 200 OK response with an AuthResponseModel object
        /// containing the user's id, a message, and success status.
        /// If authentication fails, returns an HTTP 401 Unauthorized response with an AuthResponseModel object
        /// containing an error message, a false success status, and an empty authentication token.
        /// </returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthRequestModel auth)
        {
            try
            {
                string validLogin = service.ValidLogin(auth.Username!, auth.Password!);

                if (validLogin != string.Empty)
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
                    _logger.Log("WARNING", $"Failed login attempt to account {auth.Username} at {DateTime.Now}");
                    return Unauthorized(new AuthResponseModel()
                    {
                        Message = "Invalid Credentials.",
                        Success = false,
                        Id = string.Empty
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.Log("ERROR", "Exception thrown by Guess()", ex);
                return BadRequest(new AuthResponseModel()
                {
                    Message = "Exception was thrown.",
                    Success = false,
                    Id = ""
                });
            }
            
        }
    }
}
