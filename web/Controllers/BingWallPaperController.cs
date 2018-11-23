using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.BingApi;
using web.Models;

namespace web.Controllers
{
    [Route("bing/")]
    [ApiController]
    public class BingWallPaperController : ControllerBase
    {
        private readonly IBingWallpaperApi _bingWallpaperApi;

        public BingWallPaperController(IBingWallpaperApi bingWallpaperApi)
        {
            this._bingWallpaperApi = bingWallpaperApi;
        }

        // GET bing/today
        [HttpGet("today")]
        public async Task<ActionResult<Wallpaper>> Today()
        {
            return await _bingWallpaperApi.GetTodayAsync();
        }
    }
}
