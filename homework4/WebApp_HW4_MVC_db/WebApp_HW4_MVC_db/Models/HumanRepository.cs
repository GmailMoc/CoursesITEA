using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_HW4_MVC_db.Models
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

        public IEnumerable<Human> GetHumansByCountry(string countryName)
        {
            return _context.Humans.Where(human => human.CountryId == _context.Countries.First(country => country.Name == countryName).Id).ToList();
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
