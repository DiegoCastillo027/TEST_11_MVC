namespace PhotosProject.Models
{
    public class PhotoViewModel
    {
        public IEnumerable<Photo> Photos { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalPhotos { get; set; }
    }
}
