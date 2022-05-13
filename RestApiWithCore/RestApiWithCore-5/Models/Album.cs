using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiWithCore_5.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public int ArtistId { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
