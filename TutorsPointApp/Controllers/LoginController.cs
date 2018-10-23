using TutorsPointApp.Models;
using TutorsPointRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorsPointInterface;
using TutorsPointEntity;


namespace TutorsPointApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            Login log = new Login();
            Session["UserEmail"]= user.EmailId;
            String validationInfo=log.CheckLogin(user.EmailId, user.Password);
            if (validationInfo == "tutor")
            {
                Session["tutor"] = "True";
                return RedirectToAction("Welcome");
            }
            else if(validationInfo=="parent"){
                Session["parent"] = "True";
                return RedirectToAction("WelcomeParent");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Welcome()
        {
            ITutorRepo repo = new TutorRepo();
            Tutor tutor=repo.Get(Session["UserEmail"].ToString());
            return View(tutor);
        }

        public ActionResult WelcomeParent()
        {
            IParentRepo repo = new ParentRepo();
            Parent parent = repo.Get(Session["UserEmail"].ToString());
            return View(parent);
        }
        public ActionResult UpdateTutor(int id)
        {
            ITutorRepo repo = new TutorRepo();
            return View(repo.Get(id));
        }

        [HttpPost]
        public ActionResult UpdateTutor(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                ITutorRepo repo = new TutorRepo();
                repo.Update(tutor);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(tutor);
            }
        }

        public ActionResult UpdateParent(int id)
        {
            IParentRepo repo = new ParentRepo();
            return View(repo.Get(id));
        }

        [HttpPost]
        public ActionResult UpdateParent(Parent parent)
        {
            if (ModelState.IsValid)
            {
                IParentRepo repo = new ParentRepo();
                repo.Update(parent);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(parent);
            }
        }
        public ActionResult DeleteTutor(int id)
        {
            ITutorRepo repo = new TutorRepo();
            repo.Delete(id);
            Session["tutor"] = "False";
            TempData["welcome"] = "Yor Account has been deleted Successfully";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteParent(int id)
        {
            IParentRepo repo = new ParentRepo();
            repo.Delete(id);
            Session["parent"] = "False";
            TempData["welcome"] = "Yor Account has been deleted Successfully";
            return RedirectToAction("Index", "Home");
        }


    }
}