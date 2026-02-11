using System.Net.Http.Json;

// Service class to load images from the assets list
public class VisualElementService
{
    private readonly HttpClient _http;

    public IEnumerable<string> Icons { get; private set; } = [];
    public IEnumerable<string> Photos { get; private set; } = [];
    public IEnumerable<string> Images { get; private set; } = [];
    public bool IsLoaded { get; private set; }
    
    public event Action? OnChange;

    public VisualElementService(HttpClient http)
    {
        _http = http;
    }

    //Http get to load the json list of assets in the class properties
    public async Task LoadAsync()
    {
        if (IsLoaded) return;

        var data = await _http.GetFromJsonAsync<AssetsManifest>("assets.json");

        if (data is null) return;

        Icons = data.Icons;
        Photos = data.Photos;
        Images = data.Images;

        IsLoaded = true;
        OnChange?.Invoke();
    }

    // Local DTO for the assets.json
    private class AssetsManifest
    {
        public List<string> Icons { get; set; } = [];
        public List<string> Photos { get; set; } = [];
        public List<string> Images { get; set; } = [];
    }
}
