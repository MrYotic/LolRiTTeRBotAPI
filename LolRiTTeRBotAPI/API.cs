using LolRiTTeRBotAPI.DataTypes;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace LolRiTTeRBotAPI;
public class API
{
    private readonly CookieContainer cookieContainer = new();    
    private string GetResponse(string url)
    {
        string site = url.Split('/')[2];
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.CookieContainer = cookieContainer;
        request.Accept = @"text/html, application/xhtml+xml, */*";
        request.Referer = site;
        request.Headers.Add("Accept-Language", "en-GB");
        request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
        request.Host = site;
        return new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd();
    }
    public Queue GetQueue() => new Queue(GetResponse("https://api.2b2t.dev/prioq") + ";" + GetResponse("https://2b2t.io/api/queue?last=true"));
    public Seen GetSeen(string username) => new Seen(username, GetResponse("https://api.2b2t.dev/seen?username=" + username));
    public Tab GetTab() => new Tab(GetResponse("https://api.2b2t.dev/status"));
    public Stats GetStats(string username)
    {
        string json = GetResponse("https://api.2b2t.dev/stats?username=" + username);
        return json != "[]" ? JsonConvert.DeserializeObject<Stats[]>(json)[0] : new Stats() { IsExists = false };
    }
    public Stats[] GetStatsAllAccount(string username)
    {
        string minecraftResponse = new WebClient().DownloadString(@"https://api.mojang.com/users/profiles/minecraft/" + username);
        if(minecraftResponse != "")
        {
            List<JToken> userPlayer = ((JObject)JsonConvert.DeserializeObject(minecraftResponse)).Children().ToList();
            (string name, string id) data = (userPlayer.First().ToObject<string>(), userPlayer.Last().ToObject<string>());
            return ((JArray)JsonConvert.DeserializeObject(new WebClient().DownloadString($@"https://api.mojang.com/user/profiles/{data.id}/names"))).Select(x => (x.Children().First(), x.Children().Last())).Select(x => (x.Item1.ToObject<string>(), x.Item2.ToObject<string>())).Select(z => GetStats(z.Item1)).ToArray();
        }
        return null;
    }
    public Stats GetStackStats(string username) =>
        GetStatsAllAccount(username).Aggregate((z, x) => new Stats()
        {
            AdminLevel = x.AdminLevel,
            Deaths = x.Deaths + z.Deaths,
            Id = x.Id,
            IsExists = x.IsExists || z.IsExists,
            Joins = x.Joins + z.Joins,
            Kills = x.Kills + z.Kills,
            Leaves = x.Leaves + z.Leaves,
            UserName = x.UserName,
            Uuid = z.Uuid != null ? z.Uuid : x.Uuid,
        });
    public LastDeath GetLastDeath(string username)
    {
        JToken data = ((JArray)JsonConvert.DeserializeObject(GetResponse("https://api.2b2t.dev/stats?lastdeath=" + username))).First();
        LastDeath.Raw raw = data.ToObject<LastDeath.Raw>();
        return new LastDeath()
        {
            ID = raw.ID,
            Message = raw.Message,
            UserName = raw.UserName,
            Time = DateTime.Parse(raw.Date + " " + raw.Time),
        };
    }
    public LastKill GetLastKill(string username)
    {
        JToken data = ((JArray)JsonConvert.DeserializeObject(GetResponse("https://api.2b2t.dev/stats?lastkill=" + username))).First();
        LastKill.Raw raw = data.ToObject<LastKill.Raw>();
        return new LastKill()
        {
            ID = raw.ID,
            Message = raw.Message,
            UserName = raw.UserName,
            Time = DateTime.Parse(raw.Date + " " + raw.Time),
        };
    }
}