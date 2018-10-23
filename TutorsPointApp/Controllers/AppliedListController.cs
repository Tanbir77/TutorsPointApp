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
    public class AppliedListController : Controller
    {
        
        public ActionResult Index()
        {
            List<String> email = new List<String>();
            List<Tutor> tutorList = new List<Tutor>();
            IApplyInfoRepo repo = new ApplyInfoRepo();
            List<ApplyInfo> info=repo.GetAll();
            foreach(var item in info)
            {
                email.Add(item.TutorEmail);
            }
            ITutorRepo tutorRepo = new TutorRepo();
            foreach (var mailId in email)
            {
                tutorList.Add(tutorRepo.Get(mailId));
            }

            return View(tutorList);

        }
    }
}