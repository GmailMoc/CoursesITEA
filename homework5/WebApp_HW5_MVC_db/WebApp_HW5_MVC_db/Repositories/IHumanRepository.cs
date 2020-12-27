using System.Collections.Generic;
using WebApp_HW5_MVC_db.Models;

namespace WebApp_HW5_MVC_db.Repositories
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        IEnumerable<Human> GetHuman(int id);

        void CreateHuman(Human human);

        void ModifyHuman(Human human);

        void DeleteHuman(int id);
    }
}
