using KsDynamicSprite.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Yearg
{
    public class ImageResizer
    {
        public byte[] ResizeImage(byte[] bytes, int height, int width)
        {
            var str = new MemoryStream(bytes);
            using (var output = new MemoryStream())

            using (var image = Image.Load(str))
            {


                var newimage = image.Clone(ctx => ctx.Resize(width, height));
                newimage.SaveAsJpeg(output);
                return output.ToArray();

            }
        }
    }
}
