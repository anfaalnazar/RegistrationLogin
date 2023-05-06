using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Models;
using RegistrationLogin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationRepository repo = new RegistrationRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateRegistration()
        {
            return View();
        }
        public IActionResult ListRegistration()
        {
            List<RegistrationVM> lst = repo.ListRegistration(0);
            return View(lst);
        }

        public IActionResult EditRegistration(int id)
        {
            List<RegistrationVM> lst = new List<RegistrationVM>();
            lst = repo.ListRegistration(id);
            if (lst.Count > 0)
            {
                return View(lst[0]);
            }
            return View();
        }
        [HttpPost]

        public IActionResult CreateRegistration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                Registration obj = new Registration()
                {
                    firstname = model.firstname,
                    lastname = model.lastname,
                    age = model.age,
                    email = model.email,
                    phone = model.phone,
                    username = model.username,
                    password = model.password,
                    confirmpassword = model.confirmpassword
                };
              int status=  repo.CreateRegistration(obj);
                switch (status)
                {
                    case -1:
                        ModelState.AddModelError( "username", "Username already exists.\\nPlease choose a different username.");
                        break;
                    case -2:
                        ModelState.AddModelError("email","Supplied email address has already been used.");
                        break;
                    default:
                        ModelState.AddModelError("", "Registration successful.");
                        break;
                }

            }
            return View();

        }
        [HttpPost]
        public IActionResult EditRegistration(RegistrationVM model)
        {
            Registration obj = new Registration()
            {
                id = model.id,
                firstname = model.firstname,
                lastname = model.lastname,
                age = model.age,
                email = model.email,
                phone = model.phone,
                username = model.username,
                password = model.password,
                confirmpassword = model.confirmpassword

            };
            repo.EditRegistration(obj);
            return View(model);
        }
        public JsonResult IsUserNameExists(string username)
        {
            bool result = false;
            int status = repo.IsUserNameExists(username);
            if (status == -1)
            {
                result = true;
            }
            return Json(result);
        }
    }
}
