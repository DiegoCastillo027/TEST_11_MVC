namespace PhotosProject.Models
{
    public class PhotoService
    {
        private readonly HttpClient _httpClient;

        public PhotoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Photo>>("https://jsonplaceholder.typicode.com/photos");
        }
    }
}
