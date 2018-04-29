﻿using Newtonsoft.Json;
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

        public async Task<player> managerCreatePlayer(string name)
        {

            player player = new player()
            {
                playerName = name
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(Url + "managerCreatePlayer?clubId=1130", 
                                new StringContent(
                                    JsonConvert.SerializeObject(player),
                                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<player>(
                await response.Content.ReadAsStringAsync());
        }

    }
}