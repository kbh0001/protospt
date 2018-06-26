namespace KsDynamicSprite.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using KsDynamicSprite.Utilities;
    using Microsoft.AspNetCore.Mvc;
    using SixLabors.ImageSharp;

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
        public ActionResult<IEnumerable<string>> Post([FromBody] SpriteDetails details)
        {

            var tasks = details.ImagePaths.Select(url =>
            {
                var fetchTask = new ImageFetcher().FetchImage(url);
                return fetchTask.ContinueWith(image =>
                {
                    {
                        using (var resizeTask = new Yearg.ImageCenterCroper().CropImage(image.Result, 50, 50))
                        {
                            return resizeTask;
                        }

                    }
                });
            }).ToArray();

            Task.WaitAll(tasks);
            var results = tasks.Select(z => z.Result).ToArray();


            return new string[] { "value1", "value2" };
        }

            // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
