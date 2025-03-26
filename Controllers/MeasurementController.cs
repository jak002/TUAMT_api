using Microsoft.AspNetCore.Mvc;
using TUAMT_api.Backend;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TUAMT_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private IMeasureRepo _repo;

        public MeasurementController(IMeasureRepo measureRepo)
        {
            _repo = measureRepo;
        }

        // GET: api/<MeasurementController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<MeasurementController>/5
        [HttpGet("name/{name}")]
        //[Route("name")]
        public IActionResult GetByName(string name)
        {
            return Ok(_repo.GetByName(name));
        }

        // GET api/<MeasurementController>/5
        [HttpGet("type/{type}")]
        //[Route("type")]
        public IActionResult GetByType(string type)
        {
            return Ok(_repo.GetByType(type));
        }

        // GET api/<MeasurementController>/5
        [HttpGet("convert/{input}/{output}/{amount}")]
        //[Route("name")]
        public IActionResult Convert(string input, string output, double amount)
        {
            return Ok(_repo.GetConversion(input,output,amount));
        }
    }
}
