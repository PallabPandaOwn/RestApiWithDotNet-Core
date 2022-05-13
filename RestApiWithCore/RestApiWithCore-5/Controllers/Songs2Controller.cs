using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiWithCore_5.Data;
using RestApiWithCore_5.HelperClass;
using RestApiWithCore_5.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiWithCore_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Songs2Controller : ControllerBase
    {

        private ApiDbContext _dbcontext;
        public Songs2Controller(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // GET: api/<Songs2Controller>
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            return Ok(await _dbcontext.Songs.ToListAsync());
        }

        // GET api/<Songs2Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongsById(int id)
        {
            var song = await _dbcontext.Songs.FindAsync(id);
            return Ok(song);
        }


        // GET api/<Songs2Controller>/[action]/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> test(int id)
        {
            var song = await _dbcontext.Songs.FindAsync(id);
            return Ok(song);
        }

        // POST api/<Songs2Controller>
        [HttpPost("{value}")]
        public async Task PostByValue([FromBody] string value)
        {
            await _dbcontext.Songs.FindAsync(value);

        }

        // POST api/<Songs2Controller>
        /*[HttpPost]
        public async Task<IActionResult> PostNewSongObject([FromBody] Song song)
        {

            await _dbcontext.Songs.AddAsync(song);
            return Ok("No of record inserted : "+ await _dbcontext.SaveChangesAsync());
        }*/

        // POST api/<Songs2Controller>
        [HttpPost]
        public async Task<IActionResult> PostNewSongWithFilePath([FromForm] Song song)
        {
            var imageurl = await FileUpload.Fileupload(song.Image);

            song.Path = imageurl;
            await _dbcontext.Songs.AddAsync(song);

            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);

            //return Ok("No of record inserted : " + );
        }

        // PUT api/<Songs2Controller>/5
        [HttpPut("{id}")]
        public string UpdateByid(int id, [FromBody] Song song)
        {
            var record = _dbcontext.Songs.Find(id);
            record.Title = song.Title;
            record.Language = song.Language;
            record.Duration = song.Duration;
            return "No of record updated : " + _dbcontext.SaveChanges();
        }

        // DELETE api/<Songs2Controller>/5
        [HttpDelete("{id}")]
        public string Delete(int id, [FromBody] Song song)
        {
            var record = _dbcontext.Songs.Find(id);
            _dbcontext.Songs.Remove(record);
            return "No of record updated : " + _dbcontext.SaveChanges();

        }


    }
}
