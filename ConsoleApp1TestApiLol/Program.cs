using LolRiTTeRBotAPI;
using LolRiTTeRBotAPI.DataTypes;

API api = new API();
Stats stats = api.GetStats("LolRiTTeR");
Console.WriteLine(stats.UserName);