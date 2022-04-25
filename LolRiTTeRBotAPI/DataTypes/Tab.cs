using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace LolRiTTeRBotAPI.DataTypes;
public class Tab
{
    public Tab(string json)
    {
        object[] source = JsonConvert.DeserializeObject<object[]>(json);
        object[] tab = ((JArray)source.GetValue(0)).Values().Select(z => z.ToObject<object>()).ToArray();
        TPS = double.Parse(((string)tab[0]).Replace(".", ","));
        PlayerCount = int.Parse((string)tab[1]);
        Ping = int.Parse((string)tab[2]);
        Unfined = (bool)tab[3];
        foreach(JToken obj in ((JArray)source.GetValue(1)).Values())
        {
            TabPlayer player = ((JProperty)obj).Value.ToObject<TabPlayer>();
            player.UserName = ((JProperty)obj).Name;
            Players.Add(player);
        }
    }
    public double TPS { get; set; }
    public int PlayerCount { get; set; }
    public int Ping { get; set; }
    public bool Unfined { get; set; }
    public List<TabPlayer> Players { get; set; } = new List<TabPlayer>();
}