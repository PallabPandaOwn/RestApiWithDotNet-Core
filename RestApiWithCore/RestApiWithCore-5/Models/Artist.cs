using System.ComponentModel.DataAnnotations;
using System;
namespace RestApiWithCore_5.Models
{
    public class Artist
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Required,Value canot be empty")]
        public string ImageUrl { get; set; }


    }
}
