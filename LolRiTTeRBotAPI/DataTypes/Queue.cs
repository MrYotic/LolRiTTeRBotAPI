namespace LolRiTTeRBotAPI.DataTypes;
public class Queue
{
    public Queue(string json)
    {
        json = json.Replace('[', ' ').Replace(']', ' ').Replace(" ", "");
        string[] pqArgs = json.Split(";")[0].Split(',');
        Ticks = ulong.Parse(pqArgs[0]);
        PrioQueueLength = int.Parse(pqArgs[1]);

        string[] qArgs = json.Split(";")[1].Split(',');
        QueueLength = int.Parse(qArgs[1]);
    }
    public ulong Ticks { get; set; }
    public int QueueLength { get; set; }
    public int PrioQueueLength { get; set; }
}