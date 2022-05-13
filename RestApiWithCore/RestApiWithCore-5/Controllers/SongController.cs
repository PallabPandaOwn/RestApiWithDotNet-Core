using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiWithCore_5.Models;
using System.Collections.Generic;

namespace RestApiWithCore_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class SongController : ControllerBase
    {
        private static List<Song> songs = new List<Song>()
        {
            new Song(){Id = 1 , Title="test1" , Language = "Hindi"},
        
        };

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songs;
                
        }

        [HttpPost]
        public void Post([FromBody]Song song)
        {
            songs.Add(song);
        }

        [HttpPut("{index}")]
        public void Put(int index , [FromBody] Song song)
        {
            songs[index]= song;
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            songs.RemoveAt(index);
        }
    }
}
