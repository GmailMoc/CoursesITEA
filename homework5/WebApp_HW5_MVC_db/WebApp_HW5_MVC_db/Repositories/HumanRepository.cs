using System.Collections.Generic;
using System.Linq;
using WebApp_HW5_MVC_db.Models;

namespace WebApp_HW5_MVC_db.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private WebAppDbContext _context { get; }

        public HumanRepository(WebAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }

        public IEnumerable<Human> GetHuman(int id)
        {
            return _context.Humans.Where(human => human.Id == id);
        }

        public void CreateHuman(Human human)
        {
            _context.Add(human);
            _context.SaveChanges();
        }

        public void ModifyHuman(Human human)
        {
            _context.Update(human);
            _context.SaveChanges();
        }

        public void DeleteHuman(int id)
        {
            _context.Humans.Remove(_context.Humans.First(human => human.Id == id));
            _context.SaveChanges();
        }
    }
}
