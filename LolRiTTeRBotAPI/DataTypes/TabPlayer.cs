namespace LolRiTTeRBotAPI.DataTypes;
public class TabPlayer
{
    public string UserName { get; set; }
    public long Cooldown { get; set; }
    public string Uuid { get; set; }
    public long SpamScore { get; set; }
    public long PlayTime { get; set; }
}