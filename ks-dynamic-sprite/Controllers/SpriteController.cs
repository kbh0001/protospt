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
    using Yearg;

    [Route("api/[controller]")]
    [ApiController]
    public class SpriteController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] SpriteDetails details)
        {
            //sanity
            if (!details.ImagePaths.Any() || (details.Height < 1 || details.Width < 1))
            {
                return this.BadRequest();
            }

            var tasks = details.ImagePaths.Select(url =>
            {
                var fetchTask = new ImageFetcher().FetchImage(url);
                return fetchTask.ContinueWith(image => new Yearg.ImageCenterCroper().CropImage(image.Result, details.Height, details.Width));
            }).ToArray();

            Task.WaitAll(tasks);
            var newImage = new ImageConcatenator().CreateSprite(tasks.Select(z => z.Result).ToList(),  details.Height, details.Width);

            var fs = new MemoryStream();
            newImage.SaveAsJpeg(fs);
            return  File(fs, "image/jpeg");

        }

    }
}
