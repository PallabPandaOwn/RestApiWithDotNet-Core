using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiWithCore_5.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Required,Value canot be empty")]
        public DateTime UploadedDate { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public int Duration { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public IFormFile AudioFile { get; set; }
        public string AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }


        //public int Author { get; set; }
    }
}
