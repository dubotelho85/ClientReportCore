using ClientReport.DAL.Entites;
using ClientReport.Service.Interface.Dto;
using ClientReport.Service.Interface.Processors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthController : ControllerBase
    {
        private readonly IMonthProcessor monthProcessor;

        public MonthController(IMonthProcessor monthProcessor)
        {
            this.monthProcessor = monthProcessor;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthEntity>>> Get()
        {
            return Ok(await monthProcessor.GetLastMonthsAsync(3));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]ClientDto value)
        {
            await monthProcessor.AddDataAsync(value);
        }
    }
}
