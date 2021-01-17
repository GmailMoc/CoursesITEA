using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Models.Repositories
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        void RemoveHuman(int humanId);

        void AddHuman(Human human);
    }
}
