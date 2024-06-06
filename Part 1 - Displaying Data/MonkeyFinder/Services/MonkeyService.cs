using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    List<Monkey> monkeyList = new List<Monkey>();

    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }
    public async Task<List<Monkey>> GetMonkeys()
    {

        if(monkeyList.Count > 0)
            return monkeyList;

        //online
        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if(response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
        }

        //offline
        using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);

        return monkeyList;
    }
}
