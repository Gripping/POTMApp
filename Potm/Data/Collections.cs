﻿using System;
using System.Collections.Generic;

namespace Potm.Data
{
    public class club
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class teams
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class team
    {
        public string name { get; set; }
        public List<player> players { get; set; }
        public List<match> matches { get; set; }
        public int managerId { get; set; }
        public sport sport { get; set; }
    }

    public class player
    {
        public int id { get; set; }
        public string playerName { get; set; }
        public int playerNumber { get; set; }
        public string playerAge { get; set; }
        public object playerPicture { get; set; }
    }

    public class match
    {
        public string matchLocation { get; set; }
        public string matchTime { get; set; }
    }

    public class sport
    {
        public int id { get; set; }
        public string sportName { get; set; }
    }

    public class AuthToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}