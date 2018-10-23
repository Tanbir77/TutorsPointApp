using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorsPointRepository;
using TutorsPointEntity;
using TutorsPointInterface;
namespace TutorsPointApp.Controllers
{
    public class FindController : Controller
    {
        
        public ActionResult Index()
        {
            IPostRepo repo = new PostRepo();
            List<Post>postList=repo.GetAll();
            IApplyInfoRepo ApplyRepo = new ApplyInfoRepo();
            TempData["count"] = ApplyRepo.CountApplies();
            return View(postList);
        }
        public ActionResult Apply(int id)
        {
            if (Session["tutor"] == "True")
            {
                ApplyInfo info = new ApplyInfo();
                info.PostId = id;
                info.TutorEmail = Session["UserEmail"].ToString();
                IApplyInfoRepo repo = new ApplyInfoRepo();
                repo.Insert(info);
                TempData["Apply"] = "You succesfully Applied for this post !";
                IPostRepo Prepo = new PostRepo();
                List<Post> postList = Prepo.GetAll();
                return View(postList);
                
            }
            else
            {
                TempData["Welcome"] = "You need to be looged in to Apply!";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}