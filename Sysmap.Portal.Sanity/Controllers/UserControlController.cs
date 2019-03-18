using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sysmap.Portal.Sanity.DAO;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.Controllers
{
    public class UserControlController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User")]
        public IActionResult ListUser([FromServices]UserDAO userDAO)
        {
            List<User> users = userDAO.GetAllUser();

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin")]
        public IActionResult CreateUser(User user, [FromServices]UserDAO userDAO)
        {
            user.DateCreate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool result = userDAO.CreateUser(user);

            if (result)
            {
                //var smtpClient = new SmtpClient {
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    Credentials = new NetworkCredential("from@gmail.com", "password")
                //};

                //using (var message = new MailMessage("from@gmail.com", user.Email)
                //{
                //    Subject = "Cadastro Portal Sanity",
                //    Body = "Body"
                //})
                //{
                //    smtpClient.SendMailAsync(message);
                //}

                return RedirectToAction("ListUser","UserControl");
            }

            ModelState.AddModelError("","Erro ao cadastrar usuario! Por favor entrar em");
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User")]
        public IActionResult EditUser(string email, [FromServices]UserDAO userDAO)
        {
            User user = userDAO.GetUser(email);

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User")]
        public IActionResult EditUser(User user, [FromServices]UserDAO userDAO)
        {

            userDAO.EditUser(user);

            return RedirectToAction("ListUser","UserControl");
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin")]
        public IActionResult DeleteUser(string email, [FromServices]UserDAO userDAO)
        {

            User user = userDAO.GetUser(email);

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin")]
        public IActionResult DeleteUser(User user, [FromServices]UserDAO userDAO)
        {

            userDAO.DeleteUser(user);

            return RedirectToAction("ListUser", "UserControl");
        }
    }
}