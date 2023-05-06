using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Models;
using RegistrationLogin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository repo = new LoginRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateLogin()
        {
            return View();
        }
        public IActionResult ListLogin()
        {
            List<LoginVM> lst = repo.ListLogin(0);
            return View(lst);
        }
        public IActionResult EditLogin(int userid)
        {
            List<LoginVM> lst = new List<LoginVM>();
            lst = repo.ListLogin(userid);
            if (lst.Count > 0)
            {
                return View(lst[0]);
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateLogin(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                
                Login obj = new Login()
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                repo.CreateLogin(obj);
            }
            
            
            return View();
        }
        [HttpPost]
        public IActionResult EditLogin(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                Login obj = new Login()
                {
                    userid = model.userid,
                    UserName = model.UserName,
                    Password = model.Password,

                };
                repo.EditLogin(obj);
            }
            
            return View(model);
        }
    }
}
