using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ks_dynamic_sprite.Controllers
{
    public class SpriteDetails
    {

        public List<String> imagePaths { get; set; }
        public Int32 height { get; set; }
        public Int32 width { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class SpriteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
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
        public ActionResult<IEnumerable<string>> Post([FromBody] SpriteDetails details)
        { 
        
            return new string[] { "value1", "value2" };
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
