namespace MyLibrary.mvc.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenreType { get; set; }
        public string Description { get; set; }
        public int ReleaseDate { get; set; }
        public string SiteName { get; set; }
        public string ImageUrl { get; set; }
    }
}