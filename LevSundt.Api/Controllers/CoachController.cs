using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevSundt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly IBmiGetAllQuery _bmiGetAllQuery;

        public CoachController(IBmiGetAllQuery bmiGetAllQuery)
        {
            _bmiGetAllQuery = bmiGetAllQuery;
        }

        //// GET: api/<CoachController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CoachController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CoachController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CoachController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CoachController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet("User/{userId}")]
        public IEnumerable<BmiQueryResultDto> Get(string userId)
        {
            return _bmiGetAllQuery.GetAll(userId);
        }
    }
}
