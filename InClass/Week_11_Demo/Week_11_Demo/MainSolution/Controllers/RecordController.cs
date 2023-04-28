using LeoAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private DAL _dateService = new DAL();

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<RecordDAL> Get()
        {
            return _dateService.APIGetAll();
        }


        [HttpGet("{id}")]
        [Route("get-record-by-id")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        [Route("Insert-record")]
        public void Post([FromBody] GameApiModel model)
        {
        }

       
 
        [HttpDelete("{id}")]
        [Route("delete-record-by-id")]
        public void Delete(GameApiModel model)
        {
        }
    }
}
