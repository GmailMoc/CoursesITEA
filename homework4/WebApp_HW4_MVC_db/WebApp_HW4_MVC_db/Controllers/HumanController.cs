using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp_HW4_MVC_db.Models;

namespace WebApp_HW4_MVC_db.Controllers
{
    public class HumanController : Controller
    {
        private IHumanRepository _humanRepository { get; }

        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }


        public IActionResult Index(int id)
        {
            if (id == 0)
                ViewData["Humans"] = _humanRepository.GetAllHumans().ToList();
            else
                ViewData["Humans"] = _humanRepository.GetHuman(id).ToList();

            return View();
        }

        public IActionResult Country(string countryName)
        {
            /*var human = _context.Humans.First(human => human.Id == humanId); //Lazy loading. (Выбираем 1 строку, а не набор данных из таблицы) //нежелательно использовать в цикле
            ViewData["CountryName"] = human.Country.Name;*/

            ViewData["Humans"] = _humanRepository.GetHumansByCountry(countryName).ToList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            _humanRepository.DeleteHuman(id);
            return RedirectPermanent("Index");
        }

        public IActionResult Modify(int id, string firstName, int age)
        {
            Human human = _humanRepository.GetHuman(id).First();

            human.FirstName = firstName;
            human.Age = age;

            _humanRepository.ModifyHuman(human);

            return RedirectPermanent("Index");
        }

        public IActionResult Create(/*int id, */string firstName, int age, string gender)
        {
            _humanRepository.CreateHuman(new Human { /*Id = id, */FirstName = firstName, LastName = "DefaultLastNmae", Age = age, IsSick = false, Gender = gender, CountryId = 2 });
            return RedirectPermanent("Index");
        }
    }
}
