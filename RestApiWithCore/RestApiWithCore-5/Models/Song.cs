using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiWithCore_5.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Required,Value canot be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public int Duration { get; set; }
        public string Path { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //public int Author { get; set; }
    }
}
