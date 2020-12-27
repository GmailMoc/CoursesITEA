using System;

namespace WebApp_HW5_MVC_db.Models
{
    public class Human
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsSick { get; set; }
        public string Gender { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}
