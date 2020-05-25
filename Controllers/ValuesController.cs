using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoSqlSaveJson.Application.Queries.DemoQueries;
using demoSqlSaveJson.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace demoSqlSaveJson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDemoQueries _demoQueries;

        public ValuesController(IDemoQueries demoQueries)
        {
            _demoQueries = demoQueries;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var result = await _demoQueries.SaveJson("");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<DemoViewModel> request)
        {
            var json = JsonConvert.SerializeObject(request);
            var result = await _demoQueries.SaveJson(json);
            var dd = "";
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
