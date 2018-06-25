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
    public class ImaageCenterCroper
    {
        public byte[] ReziseImage(byte[] bytes, int height, int width)
        {
            var str = new MemoryStream(bytes);
            using (var output = new MemoryStream())
            using (var image = Image.Load(str))
            {
                image.Mutate(ctx => ctx.Resize(image.Width / 2, image.Height / 2));
                image.SaveAsJpeg(output);
                return output.ReadToEnd();

            }
        }
    }
}
