using System.Text.Json.Serialization;
using System.Text.Json;

class GiveTankNamesAPI
{
    public static async Task<Root> GiveTank()
    {
        using HttpClient client = new HttpClient();
        var url = "https://raw.githubusercontent.com/Sgambe33/WarThunder-Vehicles-API/main/assets/locales/es.json";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            Root root = JsonSerializer.Deserialize<Root>(content);
            //Root randomValue = GetRandomVehicleValue(root.Vehicles);
            return root;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"NO SE PUDO LEER LA API: {e.Message}");
            throw;
        }
    }
    public class Root
    {
        [JsonPropertyName("vehicles")]
        public Dictionary<string, string> Vehicles { get; set; }
    }
}


