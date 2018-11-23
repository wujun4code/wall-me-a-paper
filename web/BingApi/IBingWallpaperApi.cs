using System;
using System.Threading.Tasks;
using web.Models;

namespace web.BingApi
{
    public interface IBingWallpaperApi
    {
        Task<Wallpaper> GetTodayAsync();
    }
}
