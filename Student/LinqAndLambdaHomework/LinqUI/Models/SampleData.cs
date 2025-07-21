namespace LinqUI.Models
{
    public static class SampleData
    {
        public static List<PlayerModel> GetPlayerData()
        {
            return new List<PlayerModel>
            {
                new PlayerModel { PlayerId =  1, Name = "LeBron James",      Team = "Cavaliers" },
                new PlayerModel { PlayerId =  2, Name = "Lew Alcindor",      Team = "Bucks" },
                new PlayerModel { PlayerId =  3, Name = "Karl Malone",       Team = "Jazz" },
                new PlayerModel { PlayerId =  4, Name = "Kobe Bryant",       Team = "Lakers" },
                new PlayerModel { PlayerId =  5, Name = "Michael Jordan",    Team = "Bulls" },
                new PlayerModel { PlayerId =  6, Name = "Dirk Nowitzki",     Team = "Mavericks" },
                new PlayerModel { PlayerId =  7, Name = "Wilt Chamberlain",  Team = "Warriors" },
                new PlayerModel { PlayerId =  8, Name = "Kevin Durant",      Team = "Thunder" },
                new PlayerModel { PlayerId =  9, Name = "Shaquille O'Neal",  Team = "Lakers" },
                new PlayerModel { PlayerId = 10, Name = "Carmelo Anthony",   Team = "Nuggets" },

                new PlayerModel { PlayerId = 11, Name = "Bill Russell",      Team = "Celtics" },
                new PlayerModel { PlayerId = 12, Name = "Moses Malone",      Team = "Rockets" },
                new PlayerModel { PlayerId = 13, Name = "Elvin Hayes",       Team = "Bullets" },
                new PlayerModel { PlayerId = 14, Name = "Tim Duncan",        Team = "Spurs" },
                new PlayerModel { PlayerId = 15, Name = "Robert Parish",     Team = "Celtics" },
                new PlayerModel { PlayerId = 16, Name = "Kevin Garnett",     Team = "Timberwolves" },
                new PlayerModel { PlayerId = 17, Name = "Dwight Howard",     Team = "Heat" },

                new PlayerModel { PlayerId = 18, Name = "Stephen Curry",     Team = "Warriors" },
                new PlayerModel { PlayerId = 19, Name = "James Harden",      Team = "Rockets" },
                new PlayerModel { PlayerId = 20, Name = "Ray Allen",         Team = "Bucks" },
                new PlayerModel { PlayerId = 21, Name = "Damian Lillard",    Team = "Trail Blazors" },
                new PlayerModel { PlayerId = 22, Name = "Klay Thompson",     Team = "Warriors" },
                new PlayerModel { PlayerId = 23, Name = "Reggie Miller",     Team = "Pacers" },
                new PlayerModel { PlayerId = 24, Name = "Kyle Korver",       Team = "Hawks" },
                new PlayerModel { PlayerId = 25, Name = "Paul George",       Team = "Pacers" },
                new PlayerModel { PlayerId = 26, Name = "Vince Carter",      Team = "Raptors" }
            };
        }
        public static List<StatsModel> GetStatsData()
        {
            return new List<StatsModel>
            {
                new StatsModel { PlayerId =  1, Points = 42184, Made3Pt = 2140, Rebounds = 11512, GamesPlayed = 1583 },
                new StatsModel { PlayerId =  2, Points = 38387, Made3Pt = 1,    Rebounds = 17440, GamesPlayed = 1560 },
                new StatsModel { PlayerId =  3, Points = 36928, Made3Pt = 85,   Rebounds = 14968, GamesPlayed = 1476 },
                new StatsModel { PlayerId =  4, Points = 33643, Made3Pt = 85,   Rebounds = 14968, GamesPlayed = 1346 },
                new StatsModel { PlayerId =  5, Points = 32292, Made3Pt = 581,  Rebounds = 6672,  GamesPlayed = 1072 },
                new StatsModel { PlayerId =  6, Points = 31560, Made3Pt = 1982, Rebounds = 11289, GamesPlayed = 1522 },
                new StatsModel { PlayerId =  7, Points = 31419, Made3Pt = 0,    Rebounds = 23924, GamesPlayed = 1045 },
                new StatsModel { PlayerId =  8, Points = 30571, Made3Pt = 2124, Rebounds = 7423,  GamesPlayed = 1072 },
                new StatsModel { PlayerId =  9, Points = 28596, Made3Pt = 1,    Rebounds = 13099, GamesPlayed = 1207 },
                new StatsModel { PlayerId = 10, Points = 28289, Made3Pt = 1731, Rebounds = 7656,  GamesPlayed = 1260 },

                new StatsModel { PlayerId = 11, Points = 14522, Made3Pt = 0,    Rebounds = 21620, GamesPlayed = 963 },
                new StatsModel { PlayerId = 12, Points = 27409, Made3Pt = 2,    Rebounds = 16212, GamesPlayed = 1329 },
                new StatsModel { PlayerId = 13, Points = 27313, Made3Pt = 0,    Rebounds = 16279, GamesPlayed = 1303 },
                new StatsModel { PlayerId = 14, Points = 26496, Made3Pt = 30,   Rebounds = 15091, GamesPlayed = 1392 },
                new StatsModel { PlayerId = 15, Points = 23434, Made3Pt = 18,   Rebounds = 14715, GamesPlayed = 1611 },
                new StatsModel { PlayerId = 16, Points = 26071, Made3Pt = 537,  Rebounds = 14662, GamesPlayed = 1462 },
                new StatsModel { PlayerId = 17, Points = 19865, Made3Pt = 15,   Rebounds = 14627, GamesPlayed = 1242 },

                new StatsModel { PlayerId = 18, Points = 23190, Made3Pt = 4058, Rebounds = 4527,  GamesPlayed = 963 },
                new StatsModel { PlayerId = 19, Points = 25305, Made3Pt = 3175, Rebounds = 5899,  GamesPlayed = 1000 },
                new StatsModel { PlayerId = 20, Points = 24505, Made3Pt = 2973, Rebounds = 5272,  GamesPlayed = 1300 },
                new StatsModel { PlayerId = 21, Points = 19836, Made3Pt = 2804, Rebounds = 3279,  GamesPlayed = 769 },
                new StatsModel { PlayerId = 22, Points = 14817, Made3Pt = 2697, Rebounds = 3282,  GamesPlayed = 793 },
                new StatsModel { PlayerId = 23, Points = 25279, Made3Pt = 2560, Rebounds = 4125,  GamesPlayed = 1389 },
                new StatsModel { PlayerId = 24, Points = 12232, Made3Pt = 2450, Rebounds = 3459,  GamesPlayed = 1232 },
                new StatsModel { PlayerId = 25, Points = 16177, Made3Pt = 2349, Rebounds = 4816,  GamesPlayed = 867 },
                new StatsModel { PlayerId = 26, Points = 25728, Made3Pt = 2290, Rebounds = 6186,  GamesPlayed = 1541 }
            };
        }
    }
}
