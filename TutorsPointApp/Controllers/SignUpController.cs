using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorsPointRepository;
using TutorsPointInterface;
using TutorsPointEntity;

namespace TutorsPointApp.Controllers
{
    public class SignUpController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ParentSignUp()
        {
            return View();


        }

        [HttpPost]
        public ActionResult ParentSignUp(Parent parent)
        {
            if (ModelState.IsValid)
            {
                IParentRepo repo = new ParentRepo();
                repo.Insert(parent);
                TempData["welcome"] = "Your registration is completed succesfully!";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(parent);
            }


        }
        [HttpGet]
        public ActionResult TeacherSingUp()
        {
            return View();


        }

        [HttpPost]
        public ActionResult TeacherSingUp(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                ITutorRepo repo = new TutorRepo();
                repo.Insert(tutor);
                ViewBag.Message = "Your registration is completed succesfully!";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(tutor);
            }


        }
    }
}