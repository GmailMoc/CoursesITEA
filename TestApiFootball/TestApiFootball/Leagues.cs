using System;
using System.Collections.Generic;
using System.Text;

namespace TestApiFootball
{
    public class Leagues
    {
        public uint? count { get; set; }

        public List<League> competitions { get; set; }
    }

    public class League
    {
        public uint id { get; set; }

        public string name { get; set; }

        public string plan { get; set; }
    }
}
