This API is very easy to use.

Start with: 
```
using LolRiTTeRBotAPI;
using LolRiTTeRBotAPI.DataTypes;
API api = new(); // On Net.5 and below use Api api = new API();
```

Examples:
 1. To get Priority queue.
  ```
  int prioQueue = api.GetPrioQueue().Queue;
  ```
 2. To get Seen player.
  ```
  DateTime date = api.GetSeen("username").Time;
  ```
 3. To get All players on server (Tab).
  ```
  Tab tab = api.GetTab();
  ```
 4. To get Player stats.
  ```
  Stats stats = api.GetStats("username");
  ```
