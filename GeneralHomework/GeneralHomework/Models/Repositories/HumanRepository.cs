using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Models.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private GeneralDbContext _context { get; }

        public HumanRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public void RemoveHuman(int humanId)
        {
            _context.Humans.Remove(_context.Humans.First(human => human.Id == humanId));
            _context.SaveChanges();
        }

        public void AddHuman(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChanges();
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans.ToList();
        }
    }
}
