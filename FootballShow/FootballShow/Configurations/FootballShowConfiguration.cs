
namespace FootballShow.Configurations
{
    public class FootballShowConfiguration
    {
        public class Email
        {
            public string EmailAddress { get; set; }
            public string EmailPassword { get; set; }
        }

        public class LoadMatches
        {
            public int DelayFromHours { get; set; }
            public string Token { get; set; }
            public string DefaultUrl { get; set; }
        }
    }
}
