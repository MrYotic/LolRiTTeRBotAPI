This API is very easy to use.

Start with: 
```
using LolRiTTeRBotAPI;
using LolRiTTeRBotAPI.DataTypes;
API api = new(); // On Net.5 and below use Api api = new API();
```

Examples:
 1. To get priority queue.
  ```
  int prioQueue = api.GetPrioQueue().Queue;
  ```
 2. To get seen player.
  ```
  DateTime date = api.GetSeen("username").Time;
  ```
 3. To get all players on server (Tab).
  ```
  Tab tab = api.GetTab();
  ```
 4. To get player statistic.
  ```
  Stats stats = api.GetStats("username");
  ```
 5. To get last death player.
  ```
  Stats stats = api.GetLastDeath("username");
  ```
 6. To get last kill player.
  ```
  LastDeath death = api.GetLastKill("username");
  ```
 7. To get last kill player.
  ```
  LastKill kill = api.GetLastKill("username");
  ```
 8. To get one statistic about all accounts by nickname.
  ```
  Stats stats = api.GetStackStats("username");
  ```
 9. To get statistics all accounts by nickname.
  ```
  Stats[] stats = api.GetStatsAllAccount("username");
  ```
 
