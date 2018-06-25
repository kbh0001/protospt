using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using SixLabors.ImageSharp;
using System.Net;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.Net.Http;
using System.IO;
using SixLabors.ImageSharp.Processing.Transforms;

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
        public async Task<ActionResult<IEnumerable<string>>> Post([FromBody] SpriteDetails details)
        {
            // var imgurl = new Comp
          {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(details.imagePaths.First());
            Stream inputStream = await response.Content.ReadAsStreamAsync();

            using (var image = Image.Load(inputStream))
            {
                image.Mutate(z => z.Resize(100, 100));
            }



            return new Task(string[] { "value1", "value2" };

            });
        }








        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
