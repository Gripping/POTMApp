using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Potm.Data
{
    public class ActionsManager
    {
        const string Url = "https://potm.bootsmann.dk/Umbraco/Api/Action/";

        public async Task<bool> managerCreatePlayer(player player, int clubId, int sportId)
        {
            HttpClient client = new HttpClient();
			var response = await client.PutAsync(Url + "managerCreatePlayer?clubId=" + clubId + "&sportId=" + sportId,
                                new StringContent(
                                    JsonConvert.SerializeObject(player),
                                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<bool>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<manager> managerLogin(string username, string password)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(username));
            var response = await client.PostAsync(Url + "managerLogin?username=" + username + "&password=" + password, content);

            manager clubId = new manager();
            clubId = JsonConvert.DeserializeObject<manager>(
                await response.Content.ReadAsStringAsync());
            
            return clubId;
        }

        public async Task<bool> votingHandler(vote newVote)
        {
            HttpClient client = new HttpClient();
            vote nVote = new vote();
            var content = new StringContent(JsonConvert.SerializeObject(newVote), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(Url + "votingHandler", content);

            return JsonConvert.DeserializeObject<bool>(
                await response.Content.ReadAsStringAsync());
        }

		public async Task<int> managerCreateTeam(newTeam team, int clubId)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsync(Url + "managerCreateTeam?clubId=" + clubId,
                                new StringContent(
                                    JsonConvert.SerializeObject(team),
                                    Encoding.UTF8, "application/json"));

			return JsonConvert.DeserializeObject<int>(
                await response.Content.ReadAsStringAsync());


        }
		public async Task<bool> choosePlayers(List<player> allPlayers, int teamId, int matchId = 0)
        {
            HttpClient client = new HttpClient();
			bool result = false;
			if (matchId == 0)
			{
				var response = await client.PutAsync(Url + "managerChoosePlayers?teamId=" + teamId,
				                                     new StringContent(
					                                     JsonConvert.SerializeObject(allPlayers),
					                                     Encoding.UTF8, "application/json"));
				result = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var response = await client.PutAsync(Url + "managerChoosePlayers?teamId=" + teamId + "&matchId=" + matchId,
                                                     new StringContent(
                                                         JsonConvert.SerializeObject(allPlayers),
                                                         Encoding.UTF8, "application/json"));
                result = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }


			return result;


        }
		public async Task<int> managerCreateMatch(match newMatch, int teamId)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsync(Url + "managerCreateMatch?teamId=" + teamId,
                                new StringContent(
                                    JsonConvert.SerializeObject(newMatch),
                                    Encoding.UTF8, "application/json"));
			var result = JsonConvert.DeserializeObject<int>(
                await response.Content.ReadAsStringAsync());
			return result;


        }

    }
}