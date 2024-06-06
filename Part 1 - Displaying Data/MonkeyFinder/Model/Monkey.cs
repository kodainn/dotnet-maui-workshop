using System.Text.Json.Serialization;

namespace MonkeyFinder.Model;

public class Monkey
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public int Population { get; set; }
    public string Latitude {  get; set; }
    public string Longitude { get; set; }
}

[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext
{

}
