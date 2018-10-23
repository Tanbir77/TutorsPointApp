using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorsPointRepository;
using TutorsPointInterface;
using TutorsPointEntity;

namespace TutorsPointApp.Models
{
    public class Login
    {
        public string CheckLogin(String email,String password)
        {
            TutorsDBContext context = new TutorsDBContext();
            Tutor tutor=context.Tutors.SingleOrDefault(t => t.Email == email && t.Password==password);
            Parent parent = context.Parents.SingleOrDefault(t => t.Email == email && t.Password == password);
            if (tutor != null)
            {
                return "tutor";
            }
            else if (parent != null)
            {
                return "parent";
            }
            else return "null";


        }
    }
}