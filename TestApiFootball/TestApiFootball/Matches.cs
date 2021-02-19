using System;
using System.Collections.Generic;
using System.Text;

namespace TestApiFootball
{
    public class Games
    {
        public int count { get; set; }
        public Matches[] matches { get; set; }
    }

    public class Matches
    {
        public long id { get; set; }
        public DateTime utcDate { get; set; }
        public Score score { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
    }

    public class Score
    {
        public string winner { get; set; }

        public FullTime fullTime { get; set; }
    }

    public class HomeTeam
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class AwayTeam
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class FullTime
    {
        public int? homeTeam { get; set; }
        public int? awayTeam { get; set; }
    }
}
