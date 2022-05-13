using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithCore_5.Data;
using RestApiWithCore_5.HelperClass;
using RestApiWithCore_5.Models;
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

            var imageurl = await FileUpload.Fileupload(artist.Image);
            artist.ImageUrl = imageurl;
            await _dbcontext.Artist.AddAsync(artist);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
