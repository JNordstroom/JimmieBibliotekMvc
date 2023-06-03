using System.ComponentModel.DataAnnotations;

namespace MyLibrary.mvc.ViewModels
{
    public class MoviePostViewModel : BasePostModel
    { 
       [Required(ErrorMessage = "Längd måste anges!")]
       
        public int Lenght { get; set; }
    }
    
}