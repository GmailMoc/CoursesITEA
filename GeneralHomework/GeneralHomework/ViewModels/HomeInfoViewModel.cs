using GeneralHomework.Models;
using System.Collections.Generic;

namespace GeneralHomework.ViewModels
{
    public class HomeInfoViewModel
    {
        public IEnumerable<Human> Humans { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}
