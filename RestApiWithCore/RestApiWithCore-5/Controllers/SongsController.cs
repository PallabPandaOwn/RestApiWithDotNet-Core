using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiWithCore_5.Data;
using RestApiWithCore_5.HelperClass;
using RestApiWithCore_5.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithCore_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbcontext;

        public SongsController(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> PostSongs([FromForm] Song song)
        {
            string songsCovercontaineName = "songscover";
            var imageurl = await FileUpload.UploadImage(song.Image, songsCovercontaineName);
            song.ImageUrl = imageurl;
            string songsAudioFilecontaineName = "audiofiles";
            var audioUrl = await FileUpload.UploadFile(song.AudioFile, songsAudioFilecontaineName);
            song.AudioUrl = audioUrl;
            song.UploadedDate = DateTime.Now;
            await _dbcontext.Songs.AddAsync(song);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
                var getallsongs = await (from song in _dbcontext.Songs
                                     select new { Id = song.Id, Title = song.Title, Duration = song.Duration, ImageUrl = song.ImageUrl, AudioUrl = song.AudioUrl }).ToListAsync(); ;
            return Ok(getallsongs.Skip((currentPageNumber-1)*currentPageSize).Take(currentPageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeturedSongs()
        {
            var feturedSongs = await (from song in _dbcontext.Songs
                                      where song.IsFeatured == true
                                      select new { Id = song.Id, Title = song.Title, Duration = song.Duration, ImageUrl = song.ImageUrl, AudioUrl = song.AudioUrl }).ToListAsync(); ;
            return Ok(feturedSongs);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var newSongs = await (from song in _dbcontext.Songs
                                  orderby song.UploadedDate descending
                                  select new { Id = song.Id, Title = song.Title, Duration = song.Duration, ImageUrl = song.ImageUrl, AudioUrl = song.AudioUrl }).Take(15).ToListAsync(); ;
            return Ok(newSongs);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getSongById(int songid)
        {
            var getSongById = await (from song in _dbcontext.Songs
                                     where song.Id == songid
                                     select new { Id = song.Id, Title = song.Title, Duration = song.Duration, ImageUrl = song.ImageUrl, AudioUrl = song.AudioUrl }).ToListAsync(); ;
            return Ok(getSongById);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var searchSongs = await (from song in _dbcontext.Songs
                                     where song.Title.StartsWith(query)
                                     select new { Id = song.Id, Title = song.Title, Duration = song.Duration, ImageUrl = song.ImageUrl, AudioUrl = song.AudioUrl }).ToListAsync(); ;
            return Ok(searchSongs);
        }
    }
}
