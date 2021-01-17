using System;

namespace GeneralHomework.ViewModels
{
    public class CountryIndexViewModel
    {
        public int Id { get; set; }
        public string NameCountry { get; set; }
        public int SickCount { get; set; }
        public int DeadCount { get; set; }
        public int RecoveredCount { get; set; }
    }
}
