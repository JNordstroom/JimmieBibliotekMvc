using System.ComponentModel.DataAnnotations;

namespace MyLibrary.mvc.ViewModels
{
    public class SeriePostViewModel : BasePostModel
    {
        [Required(ErrorMessage = "Antal säsonger måste anges!")]
        public int Seasons { get; set; }
    }
}