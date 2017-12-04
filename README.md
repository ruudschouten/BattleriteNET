# BattleriteNET
A C# library for use with the official [Battlerite API](http://battlerite-docs.readthedocs.io/en/master/introduction.html)

## Basic Usage
```csharp
static void Main(string[] args) {
    //Create client
    Client client = new Client("apikey");
    //Set filters
    client.SetFilter(pageOffset: 0, pageLimit: 3, sortMethod: Client.SortMethod.createdAt, sortAscending: true);
    //Get 3 matches, because we set the filter to 3 matches.
    List<Match> matches = client.GetMatches();
    //Reset filters
    client.ResetFilter();
    //Get matches from playerId
    client.GetMatchesFromPlayerId("playerId");
}
```

## Methods
`GetMatches()`  
Gets first 5 matches from API with objects created per API documentation

`GetMatchesJson()`  
Gets first 5 matches from API with objects generated from JSON

`SetFilter(int pageOffset, int pageLimit, SortMethod sortMethod, bool sortAscending)`  
Sets filter

`ResetFilter()`  
Resets filter

`GetMatchesFromPlayedId(playerId)`  
Gets first 5 matches from API where player with `playerId` participated

`GetMatchesFromPlayerName(string name)`  
Gets first 5 matches from API where player with `playerName` participated

## Frameworks used:  
- [RestSharp](https://github.com/restsharp/RestSharp)
