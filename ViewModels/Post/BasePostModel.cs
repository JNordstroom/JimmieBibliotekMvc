using System.ComponentModel.DataAnnotations;

namespace MyLibrary.mvc.ViewModels
{
    public class BasePostModel
    {
        [Required(ErrorMessage = "Titel måste anges!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivning måste anges!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Utgivningsår måste anges!")]
        public int ReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Genre måste anges!")]
        public string GenreType { get; set; }

        [Required(ErrorMessage = "Vilken sida måste anges!")]
        public string SiteName { get; set; }
        
        public string ImageUrl { get; set; }
    }
}