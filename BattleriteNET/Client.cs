using System;
using System.Collections.Generic;
using System.Text;
using BattleriteNET.Json;
using BattleriteNET.MasterBattlerite;
using BattleriteNET.Objects;
using Newtonsoft.Json;
using RestSharp;

namespace BattleriteNET {
    public class Client {
        public RestRequest Request { get; set; }
        private RestClient client;
        private RestClient masterBattleriteClient;

        private SortMethod sortMethod = SortMethod.createdAt;
        private bool sortAscending = true;
        private int pageOffset = 0;
        private int pageLimit;
        private bool filtering = false;

        /// <summary>
        /// Setup RestClient with apikey
        /// </summary>
        /// <param name="apikey"></param>
        private void SetupClient(string apikey) {
            client = new RestClient(new Uri("https://api.dc01.gamelockerapp.com/shards/global/"));
            Request = new RestRequest("NaN", Method.GET);
            Request.AddHeader("Authorization", apikey);
            Request.AddHeader("Accept", "application/vnd.api+json");
        }
        
        /// <summary>
        /// Create a new client with your apikey.
        /// Can be obtained here: https://developer.battlerite.com/apps
        /// </summary>
        /// <param name="apikey"></param>
        public Client(string apikey) {
            SetupClient(apikey);
        }

        #region Filters
        //TODO: Add more methods
        public enum SortMethod {
            createdAt,
        }

        private void SetSort(SortMethod method, bool ascending) {
            string s = ascending ? "" : "-";
            Request?.AddQueryParameter("sort", $"{s}{method}");
        }

        private void SetPageOffset(int offset) {
            Request?.AddQueryParameter("page[offset]", offset.ToString());
        }

        private void SetPageLimit(int limit) {
            Request?.AddQueryParameter("page[limit]", limit.ToString());
        }

        private void SetPlayerName(string player) {
            Request?.AddQueryParameter("filter[playerNames]", player);
        }

        private void SetPlayerId(string player) {
            Request?.AddQueryParameter("filter[playerIds]", player);
        }

        private void SetPlayersName(IEnumerable<string> player) {
            Request?.AddQueryParameter("filter[playerNames]", string.Join(",", player));
        }

        private void SetPlayersId(IEnumerable<string> player) {
            Request?.AddQueryParameter("filter[playerIds]", string.Join(",", player));
        }

        private void ApplyFilter() {
            SetPageOffset(pageOffset);
            SetPageLimit(pageLimit);
            SetSort(sortMethod, sortAscending);
        }

        public void SetFilter(int pageOffset, int pageLimit, SortMethod sortMethod, bool sortAscending) {
            this.pageOffset = pageOffset;
            this.pageLimit = pageLimit;
            this.sortMethod = sortMethod;
            this.sortAscending = sortAscending;
            filtering = true;
        }

        public void ResetFilter() {
            sortMethod = SortMethod.createdAt;
            sortAscending = true;
            pageOffset = 0;
            pageLimit = 5;
            filtering = false;
        }
        #endregion

        /// <summary>
        /// Returns a matches as its defined on the API documentation.
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatches() {
            Request.Resource = "matches";
            if (filtering) {
                ApplyFilter();
            }
            var response = client.Execute(Request);
            string json = response.Content;
            List<Match> matches = new List<Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            foreach (var match in m.Data) {
                matches.Add(new Match(match.Id, match.Attributes, match.Relationships, m.Included));
            }
            return matches;
        }

        /// <summary>
        /// Returns a match with player specified by id
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatchesFromPlayerId(string id) {
            Request.Resource = "matches";
            if (filtering) {
                ApplyFilter();
            }
            SetPlayerId(id);
            var response = client.Execute(Request);
            string json = response.Content;
            List<Match> matches = new List<Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            foreach (var match in m.Data) {
                matches.Add(new Match(match.Id, match.Attributes, match.Relationships, m.Included));
            }
            return matches;
        }

        /// <summary>
        /// Returns a match with player specified by ids
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatchesFromPlayersId(List<string> ids) {
            Request.Resource = "matches";
            if (filtering) {
                ApplyFilter();
            }
            SetPlayersId(ids);
            var response = client.Execute(Request);
            string json = response.Content;
            List<Match> matches = new List<Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            foreach (var match in m.Data) {
                matches.Add(new Match(match.Id, match.Attributes, match.Relationships, m.Included));
            }
            return matches;
        }

        /// <summary>
        /// Returns a match with player specified by id
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatchesFromPlayerName(string name) {
            Request.Resource = "matches";
            if (filtering) {
                ApplyFilter();
            }
            SetPlayerId(GetPlayerIdFromName(name));
            var response = client.Execute(Request);
            string json = response.Content;
            List<Match> matches = new List<Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            foreach (var match in m.Data) {
                matches.Add(new Match(match.Id, match.Attributes, match.Relationships, m.Included));
            }
            return matches;
        }

        /// <summary>
        /// Returns a match with player specified by ids
        /// </summary>
        /// <returns></returns>
        public List<Match> GetMatchesFromPlayersName(List<string> names) {
            Request.Resource = "matches";
            if (filtering) {
                ApplyFilter();
            }

            List<string> ids = new List<string>();
            foreach (var name in names) {
                ids.Add(GetPlayerIdFromName(name));
            }
            SetPlayersId(ids);
            var response = client.Execute(Request);
            string json = response.Content;
            List<Match> matches = new List<Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            foreach (var match in m.Data) {
                matches.Add(new Match(match.Id, match.Attributes, match.Relationships, m.Included));
            }
            return matches;
        }

        public string GetPlayerIdFromName(string playerName) {
            string link = "https://masterbattlerite.com/";
            masterBattleriteClient = new RestClient(new Uri(link));
            var req = new RestRequest($"profile/{playerName}/lookup");
            var response = masterBattleriteClient.Execute(req);
            var json = response.Content;
            PlayerContainer container = JsonConvert.DeserializeObject<PlayerContainer>(json);
            return container.Player.UserId;
        }

        /// <summary>
        /// Returns a match as generated by JSON
        /// </summary>
        /// <returns></returns>
        public List<Matches.Match> GetMatchesJson() {
            Request.Resource = "matches";
            var response = client.Execute(Request);
            string json = response.Content;
            List<Matches.Match> matches = new List<Matches.Match>();
            Matches m = JsonConvert.DeserializeObject<Matches>(json);
            return m.Data;
        }
    }
}
