namespace LolRiTTeRBotAPI.DataTypes;
public class PrioQueue
{
    public PrioQueue(string json)
    {
        string[] args = json.Replace('[', ' ').Replace(']', ' ').Split(',');
        Ticks = ulong.Parse(args[0]);
        Queue = int.Parse(args[1]);
    }
    public ulong Ticks { get; set; }
    public int Queue { get; set; }
}