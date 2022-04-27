using LolRiTTeRBotAPI;
using LolRiTTeRBotAPI.DataTypes;
API api = new API();
Queue q = api.GetQueue();
Console.WriteLine(q.QueueLength + " " + q.PrioQueueLength);