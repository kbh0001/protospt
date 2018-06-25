namespace KsDynamicSprite.Utilities
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ImageFetcher
    {

        public async Task<byte[]> FetchImage(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ImageNotFoundException();
            }

            Stream inputStream = await response.Content.ReadAsStreamAsync();

            return inputStream.ReadToEnd();

        }

    }
}
