namespace LolRiTTeRBotAPI.DataTypes;
public class LastDeath
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public DateTime Time { get; set; }
    public string Message { get; set; }
    public class Raw
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }
    }
}