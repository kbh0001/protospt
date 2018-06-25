namespace KsDynamicSprite.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using KsDynamicSprite.Utilities;
    using Microsoft.AspNetCore.Mvc;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Processing;
// using SixLabors.ImageSharp.Processing.Transforms;

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

            details.ImagePaths.ForEach(async img =>
            {

                var fetchTask = Task.Run( () => new ImageFetcher().FetchImage(img));
                var taskResult = await fetchTask;

                System.Diagnostics.Trace.WriteLine("image fetched");
            });

            return new string[] { "value1", "value2" };

            /*
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync(details.ImagePaths.First());
                    Stream inputStream = await response.Content.ReadAsStreamAsync();

                    using (var image = Image.Load(inputStream))
                    {
                        image.Mutate(z => z.Resize(100, 100));
                    }

                     
              */
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
