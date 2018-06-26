namespace KsDynamicSprite.Utilities
{
    using SixLabors.ImageSharp;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ImageFetcher
    {

        public async Task<Image<SixLabors.ImageSharp.PixelFormats.Rgba32>> FetchImage(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ImageNotFoundException();
            }
            Stream inputStream = await response.Content.ReadAsStreamAsync();
            return Image.Load(inputStream);


        }

    }
}
