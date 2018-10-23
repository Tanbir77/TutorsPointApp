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
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ITutorRepo tRepo = new TutorRepo();
            TempData["count"] = tRepo.CountTutors();
            IPostRepo repo = new PostRepo();
            TempData["countPost"] = repo.CountPosts();
            return View();
        }

    }
}