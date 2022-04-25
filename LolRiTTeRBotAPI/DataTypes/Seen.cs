namespace LolRiTTeRBotAPI.DataTypes;
using Newtonsoft.Json;
public class Seen
{
    public Seen(string name, string json)
    {
        Name = name;
        if(json == "Not Found")
            IsExists = false;
        else Time = DateTime.Parse(json.Substring(10, 19));        
    }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public bool IsExists { get; set; } = true;
}