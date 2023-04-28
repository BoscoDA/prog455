using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Model;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private DAL _dateService = new DAL();

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<RecordModel> Get()
        {

            return _dateService.APIGetAll();
        }


        [HttpGet]
        [Route("get-by-Id/{id}")]
        public RecordModel Get(int id)
        {
            return _dateService.APIGetById(id);
        }

        [HttpGet]
        [Route("get-by-name/{name}")]
        public IEnumerable<RecordModel> Get(string name)
        {
            return _dateService.APIGetbyName(name);
        }


        [HttpPost]
        [Route("insert-record")]
        public int Post([FromBody] RecordModel model)
        {
            return _dateService.APIInsertRecord(model);
        }



        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(int id)
        {
            return _dateService.APIDeleteById(id);
        }
    }
}
