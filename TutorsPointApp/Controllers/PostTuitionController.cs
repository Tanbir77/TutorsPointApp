using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorsPointInterface;
using TutorsPointEntity;
using TutorsPointRepository;

namespace TutorsPointApp.Controllers
{
    public class PostTuitionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ITutorRepo Repo = new TutorRepo();
            TempData["count"] = Repo.CountTutors();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Post post)
        {
            IPostRepo repo = new PostRepo();
            if (ModelState.IsValid)
            {
                post.ParentEmail = Session["UserEmail"].ToString();
                repo.Insert(post);
                ITutorRepo ApplyRepo = new TutorRepo();
                TempData["count"] = ApplyRepo.CountTutors();
                return View();
            }
            else
            {
                return View(post);
            }
                
        }
    }
}