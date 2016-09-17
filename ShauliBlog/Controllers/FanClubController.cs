using ShauliBlog.Data;
using ShauliBlog.Models;
using ShauliBlog.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class FanClubController : Controller
    {
        private ShauliBlogDbContext _context;

        public FanClubController()
        {
            _context = new ShauliBlogDbContext();
        }

        #region Http GET actions
        //Display Fan List
        public ActionResult Index()
        {
            var fanList = _context.Fans
                .OrderBy(f => f.Name);

            return View(fanList);
        }

        //Display Fan Details
        public ActionResult Details(int id)
        {
            var fan = _context.Fans.SingleOrDefault(f => f.Id == id);

            return View(fan);
        }

        //Display Empty Fan Form
        public ActionResult Create()
        {
            var fanForm = new FanFormViewModel();
            fanForm.Heading = "Create a new Fan";
            fanForm.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "Male"},
                new SelectListItem { Value = "F", Text = "Female" }
            };
            return View("FanForm", fanForm);
        }

        //Display Filled Fan Form 
        public ActionResult Update(int id)
        {
            var fan = _context.Fans.SingleOrDefault(f => f.Id == id);

            if (fan == null)
                return HttpNotFound();

            var viewModel = new FanFormViewModel()
            {
                Id = fan.Id,
                Heading = $"Edit {fan.Name} {fan.LastName}",
                Name = fan.Name,
                LastName = fan.LastName,
                Gender = fan.Gender,
                DateOfBirth = fan.DateOfBirth.ToString("dd/mm/yyyy"),
                SeniorityInYears = fan.SeniorityInYears,
                GenderList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                }

            };

            return View("FanForm", viewModel);
        }

        //Delete by Id
        public ActionResult Delete(int id)
        {
            var fanInDb = _context.Fans.Where(m => m.Id == id).SingleOrDefault();

            if (fanInDb == null)
                return HttpNotFound();

            _context.Fans.Remove(fanInDb); //TODO:support cascading using entity's fluent api
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        #endregion

        #region Http POST actions

        [HttpPost]
        public ActionResult Create(FanFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                };
                return View("FanForm", viewModel);
            }

            //Create new fan
            var fan = new Fan
            {
                Name = viewModel.Name,
                LastName = viewModel.LastName,
                Gender = viewModel.Gender,
                DateOfBirth = viewModel.GetDateTimeOfBirth(),
                SeniorityInYears = viewModel.SeniorityInYears
            };

            _context.Fans.Add(fan);
            _context.SaveChanges();

            return RedirectToAction("Index", "FanClub");
        }

        [HttpPost]
        public ActionResult Update(FanFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GenderList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "M", Text = "Male"},
                    new SelectListItem { Value = "F", Text = "Female" }
                };
                return View("FanForm", viewModel);
            }

            //Update existing fan
            var fanInDb = _context.Fans.SingleOrDefault(f => f.Id == viewModel.Id);

            if (fanInDb == null)
                return HttpNotFound();

            fanInDb.Name = viewModel.Name;
            fanInDb.LastName = viewModel.LastName;
            fanInDb.Gender = viewModel.Gender;
            fanInDb.DateOfBirth = viewModel.GetDateTimeOfBirth();
            fanInDb.SeniorityInYears = viewModel.SeniorityInYears;

            _context.SaveChanges();

            return RedirectToAction("Index", "FanClub");
        }

        #endregion


    }
}