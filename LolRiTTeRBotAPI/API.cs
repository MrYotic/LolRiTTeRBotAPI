using LolRiTTeRBotAPI.DataTypes;
using System.Net;
using Newtonsoft.Json;
namespace LolRiTTeRBotAPI;
public class API
{
    private readonly CookieContainer cookieContainer = new();
    public string GetResponse(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.CookieContainer = cookieContainer;
        request.Accept = @"text/html, application/xhtml+xml, */*";
        request.Referer = "api.2b2t.dev";
        request.Headers.Add("Accept-Language", "en-GB");
        request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
        request.Host = "api.2b2t.dev";
        return new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd();
    }
    public PrioQueue GetPrioQueue() => new PrioQueue(GetResponse("https://api.2b2t.dev/prioq"));
    public Seen GetSeen(string username) => new Seen(username, GetResponse("https://api.2b2t.dev/seen?username=" + username));
    public Tab GetTab() => new Tab(GetResponse("https://api.2b2t.dev/status"));
    public Stats GetStats(string username) => JsonConvert.DeserializeObject<Stats[]>(GetResponse("https://api.2b2t.dev/stats?username=" + username))[0];
}