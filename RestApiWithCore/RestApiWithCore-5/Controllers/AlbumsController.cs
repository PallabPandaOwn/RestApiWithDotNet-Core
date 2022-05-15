using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithCore_5.Data;
using RestApiWithCore_5.HelperClass;
using RestApiWithCore_5.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestApiWithCore_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private ApiDbContext _dbcontext;

        public AlbumsController(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> PostAlbums([FromForm] Album album)
        {
            string albumCoverConatinerName = string.Empty;
            var imageurl = await FileUpload.UploadImage(album.Image, albumCoverConatinerName);
            album.ImageUrl = imageurl;
            await _dbcontext.Album.AddAsync(album);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var getalbum = await (from album in _dbcontext.Album
                                    select new
                                    {
                                        Id = album.Id,
                                        Name = album.Name,
                                        ImageUrl = album.ImageUrl,
                                    }).ToListAsync();
            return Ok(getalbum);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlbumDetails(int albumid)
        {
            var getalbumdeatils = await _dbcontext.Album.Where(a => a.Id == albumid).Include(a => a.Songs).ToListAsync();
            return Ok(getalbumdeatils);
        }
    }
}
