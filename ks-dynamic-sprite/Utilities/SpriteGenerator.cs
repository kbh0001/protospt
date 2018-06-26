using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

using SixLabors.ImageSharp.Processing.Drawing;

using SixLabors.Primitives;
using System.Collections.Generic;
using SixLabors.ImageSharp.PixelFormats;

namespace Yearg
{
    public class SpriteGenerator
    {
        public Image<SixLabors.ImageSharp.PixelFormats.Rgba32> CreateSprite(List<Image<SixLabors.ImageSharp.PixelFormats.Rgba32>> images, int height, int width)
        {
            var newImage = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(width * images.Count, height); 
            var cntr = 0;
            images.ForEach(image => {
                newImage.Mutate(ctx => {
                    var h = image.Height;
                    ctx.DrawImage(image, PixelBlenderMode.Normal, 1f, new Point(width * cntr, 0));
                });
                cntr++;
            });
            return newImage;
        }
    }
}
