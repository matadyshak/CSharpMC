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
                new PlayerModel { PlayerId = 17, Name = "Dwight Howard",     Team = "HeatBulls" },

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
                new StatsModel { PlayerId =  1, /* LeBron James */      Points = 42184, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId =  2, /* Lew Alcindor" */     Points = 38387, Made3Pt = 0, Rebounds = 17440 },
                new StatsModel { PlayerId =  3, /* Karl Malone" */      Points = 36928, Made3Pt = 0, Rebounds = 14968 },
                new StatsModel { PlayerId =  4, /* Kobe Bryant" */      Points = 33643, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId =  5, /* Michael Jordan" */   Points = 32292, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId =  6, /* Dirk Nowitzki" */    Points = 31560, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId =  7, /* Wilt Chamberlain" */ Points = 31419, Made3Pt = 0, Rebounds = 23924 },
                new StatsModel { PlayerId =  8, /* Kevin Durant" */     Points = 30571, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId =  9, /* Shaquille O'Neal" */ Points = 28596, Made3Pt = 0, Rebounds = 0 },
                new StatsModel { PlayerId = 10, /* Carmelo Anthony" */  Points = 28289, Made3Pt = 0, Rebounds = 0 },

                new StatsModel { PlayerId = 11, /* Bill Russell" */     Points = 0, Made3Pt = 0, Rebounds = 21260 },
                new StatsModel { PlayerId = 12, /* Moses Malone" */     Points = 0, Made3Pt = 0, Rebounds = 16212 },
                new StatsModel { PlayerId = 13, /* Elvin Hayes" */      Points = 0, Made3Pt = 0, Rebounds = 16279 },
                new StatsModel { PlayerId = 14, /* Tim Duncan" */       Points = 0, Made3Pt = 0, Rebounds = 15091 },
                new StatsModel { PlayerId = 15, /* Robert Parish" */    Points = 0, Made3Pt = 0, Rebounds = 14715 },
                new StatsModel { PlayerId = 16, /* Kevin Garnett" */    Points = 0, Made3Pt = 0, Rebounds = 14662 },
                new StatsModel { PlayerId = 17, /* Dwight Howard" */    Points = 0, Made3Pt = 0, Rebounds = 14627 },

                new StatsModel { PlayerId = 18, /* Stephen Curry" */    Points = 0, Made3Pt = 4058, Rebounds = 0 },
                new StatsModel { PlayerId = 19, /* James Harden" */     Points = 0, Made3Pt = 3175, Rebounds = 0 },
                new StatsModel { PlayerId = 20, /* Ray Allen" */        Points = 0, Made3Pt = 2973, Rebounds = 0 },
                new StatsModel { PlayerId = 21, /* Damian Lillard" */   Points = 0, Made3Pt = 2804, Rebounds = 0 },
                new StatsModel { PlayerId = 22, /* Klay Thompson" */    Points = 0, Made3Pt = 2697, Rebounds = 0 },
                new StatsModel { PlayerId = 23, /* Reggie Miller" */    Points = 0, Made3Pt = 2560, Rebounds = 0 },
                new StatsModel { PlayerId = 24, /* Kyle Korver" */      Points = 0, Made3Pt = 2450, Rebounds = 0 },
                new StatsModel { PlayerId = 25, /* Paul George" */      Points = 0, Made3Pt = 2349, Rebounds = 0 },
                new StatsModel { PlayerId = 26, /* Vince Carter" */     Points = 0, Made3Pt = 2290, Rebounds = 0 }
            };
        }
    }
}
