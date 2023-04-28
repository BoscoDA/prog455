using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DAL _dataService = new DAL();

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<UserModel> Get()
        {
            return _dataService.APIGetAll();
        }
    }
}
