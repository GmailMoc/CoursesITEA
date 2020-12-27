using System.Collections.Generic;

namespace WebApp_HW5_MVC_db.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zone { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual List<Human> Human { get; set; }
    }
}
