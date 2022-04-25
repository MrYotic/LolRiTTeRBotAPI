using Newtonsoft.Json;

namespace LolRiTTeRBotAPI.DataTypes;
public class Stats
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Uuid { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Joins { get; set; }
    public int Leaves { get; set; }
    public int AdminLevel { get; set; }
}