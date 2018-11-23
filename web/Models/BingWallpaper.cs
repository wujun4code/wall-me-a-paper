using System;
namespace web.Models
{
    public class BingWallpaper : Wallpaper
    {
        const string wallpaperHostUrl = "http://s.cn.bing.net";
        public BingWallpaper()
        {
            this.Provider = "Bing";
        }

        public void Transform(ResolutionValue target)
        {
            this.Resolution = target;
            var url = $"{wallpaperHostUrl}{UrlBase}_{Resolution.Width}x{Resolution.Height}.jpg";
            this.Url = url;
        }

        public string UrlBase { get; set; }
    }
}
