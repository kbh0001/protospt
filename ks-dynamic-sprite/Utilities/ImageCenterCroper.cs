using KsDynamicSprite.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Yearg
{
    public class ImageCenterCroper
    {
        public Image<SixLabors.ImageSharp.PixelFormats.Rgba32> CropImage(Image<SixLabors.ImageSharp.PixelFormats.Rgba32> image, int height, int width)
        {
                var size = new Size(width, height);
                var newImage = image.Clone(ctx => ctx.Resize(new ResizeOptions
                {
                    Size = size,
                    Mode = ResizeMode.Crop,
                }));
                return newImage;
        }
    }
}
