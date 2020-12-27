using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp_HW5_MVC_db.Models;
using WebApp_HW5_MVC_db.Repositories;

namespace WebApp_HW5_MVC_db.Controllers
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

        public IActionResult Create(string firstName, int age, string gender)
        {
            _humanRepository.CreateHuman(new Human { FirstName = firstName, LastName = "DefaultLastNmae", Age = age, IsSick = false, Gender = gender, DistrictId = 2 });
            return RedirectPermanent("Index");
        }

        [Route("{controller}/Region/{id:int:range(1,8)}")]
        public IActionResult District(int id)
        {
            Human human = _humanRepository.GetHuman(id).First(); //_humanRepository.GetAllHumans().Max(human => human.Id)
            ViewData["DistrictName"] = human.District.Name;

            return View();
        }
    }
}
