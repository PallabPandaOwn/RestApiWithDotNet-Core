using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiWithCore_5.Data;
using RestApiWithCore_5.HelperClass;
using RestApiWithCore_5.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithCore_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbcontext;

        public ArtistsController(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> PostArtist([FromForm] Artist artist)
        {
            string artistImageContainerName = "artistimages";
            var imageurl = await FileUpload.UploadImage(artist.Image, artistImageContainerName);
            artist.ImageUrl = imageurl;
            await _dbcontext.Artist.AddAsync(artist);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        public ApiDbContext Get_dbcontext()
        {
            return _dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var getartists = await (from artist in _dbcontext.Artist
                                    select new 
                                    {
                                        Id = artist.Id,
                                        Name = artist.Name,
                                        ImageUrl = artist.ImageUrl,
                                    }).ToListAsync();
            return Ok(getartists);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetArtistsDetails(int artistid)
        {
            var getartistsdeatils = await _dbcontext.Artist.Where(a => a.Id == artistid).Include(a => a.Songs).ToListAsync();
            return Ok(getartistsdeatils);
        }
    }
}
