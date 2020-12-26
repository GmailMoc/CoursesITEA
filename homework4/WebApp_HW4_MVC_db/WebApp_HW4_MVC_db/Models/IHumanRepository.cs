using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_HW4_MVC_db.Models
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        IEnumerable<Human> GetHumansByCountry(string countryName);

        IEnumerable<Human> GetHuman(int id);

        void CreateHuman(Human human);

        void ModifyHuman(Human human);

        void DeleteHuman(int id);
    }
}
