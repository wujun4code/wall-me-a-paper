using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using web.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace web.BingApi
{
    public class BingWallpaperApi : IBingWallpaperApi
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string[] BingMarkets = new string[] { "zh-cn" };
        const string apiBaseUrl = "http://www.bing.com";
        const string apiRelativeUrlPattern = "/HPImageArchive.aspx?format=js&idx={0}&n={1}&mkt={2}";


        public BingWallpaperApi()
        {

        }

        public async Task<Wallpaper> GetTodayAsync()
        {
            var bingBaseApiUrl = string.Format($"{apiBaseUrl}{apiRelativeUrlPattern}", 0, 1, BingMarkets[0]);

            HttpResponseMessage apiResponse = await client.GetAsync(bingBaseApiUrl);

            apiResponse.EnsureSuccessStatusCode();

            string apiResponseBody = await apiResponse.Content.ReadAsStringAsync();

            JObject todayJObject = JObject.Parse(apiResponseBody);

            if (todayJObject.ContainsKey("images"))
            {
                JArray todayImages = (JArray)todayJObject["images"];
                if (todayImages.Count > 0)
                {
                    var todayImageJToken = todayImages[0];
                    return DecodeWallpaper(todayImageJToken);
                }
            }

            return new BingWallpaper();
        }

        public Wallpaper DecodeWallpaper(JToken imageJToken)
        {
            var todayWallpaper = new BingWallpaper()
            {
                UrlBase = (string)imageJToken["urlbase"]
            };
            todayWallpaper.Transform(new Wallpaper.ResolutionValue()
            {
                Width = 1920,
                Height = 1080
            });
            return todayWallpaper;
        }
    }
}
