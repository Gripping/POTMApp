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

        public async Task<player> managerCreatePlayer(player player)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(Url + "managerCreatePlayer?clubId=1130",
                                new StringContent(
                                    JsonConvert.SerializeObject(player),
                                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<player>(
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
    }
}