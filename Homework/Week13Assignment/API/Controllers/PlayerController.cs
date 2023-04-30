using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private DAL _dataService = new DAL();

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<RecordModel> Get()
        {
            return _dataService.APIGetAll();
        }

        [HttpGet]
        [Route("get-by-name{name}")]
        public IEnumerable<RecordModel> Get(string name)
        {
            return _dataService.APIGetAllByName(name);
        }

        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(string id)
        {
            return _dataService.APIDeleteById(id);
        }

        [HttpPost]
        [Route("insert-record")]
        public string Post([FromBody] RecordModel model) 
        {
            return _dataService.APIInsertRecord(model);
        }

        [HttpPost]
        [Route("update-record")]
        public string Update([FromBody] RecordModel model)
        {
            return _dataService.APIInsertRecord(model);
        }
    }
}
