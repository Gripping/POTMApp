using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Potm.Data
{
    public class CollectionManager
    {
        const string Url = "https://potm.bootsmann.dk/Umbraco/Api/Collection/";

        //private async Task<AuthToken> GetToken()
        //{
        //    HttpClient client = new HttpClient();

        //    var response = await client.PostAsync(AuthUrl, new StringContent(Credentials, Encoding.UTF8, "application/json"));

        //    AuthToken Token = JsonConvert.DeserializeObject<AuthToken>(await response.Content.ReadAsStringAsync());

        //    return Token;
        //}

        //Requires no authentication -> Guest login
        public async Task<List<teams>> GetTeams(int clubId)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(Url + "GetTeams?clubId=" + clubId);
            List<teams> response = JsonConvert.DeserializeObject<List<teams>>(await result.Content.ReadAsStringAsync());
            return response;
        }

		public async Task<team> GetTeam(int teamId)
		{
			HttpClient client = new HttpClient();
			var result = await client.GetAsync(Url + "GetTeam?teamId=" + teamId);
			team response = JsonConvert.DeserializeObject<team>(await result.Content.ReadAsStringAsync());
            return response;
		}

		public async Task<List<sport>> GetAllSports()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(Url + "GetAllSports");
			List<sport> response = JsonConvert.DeserializeObject<List<sport>>(await result.Content.ReadAsStringAsync());

            return response;
        }


    }
}