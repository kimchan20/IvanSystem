using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MVC5.Class;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult login(string ReturnUrl)
        {
            ViewBag.returnUri = ReturnUrl == null ? "" : ReturnUrl;
            return View();
        }


        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("login");
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(AccountModel.LoginModel login,string ReturnUrl)
        {
            
            ViewBag.returnUri = ReturnUrl == null ? "" : ReturnUrl;
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            UserApi userApi = new UserApi();
            var res = userApi.loginUser(login);
            if (userApi.loginUser(login).Contains("True"))
            {
                FormsAuthentication.SetAuthCookie(login.userName,false);
                RouteCollection collection = new RouteCollection();
                var completeRoute = this.ControllerContext.RouteData.Route;
            
                if (ReturnUrl != null)
                {
                    var ss = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
                    return Redirect(ReturnUrl);
                }

                ViewBag.loginMessage = "Login Success";
                return RedirectToAction("Home","Index");
            }
            else
            {
                ModelState.AddModelError("username","Username and Password didnt match.");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(AccountModel.RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            UserApi userApi = new UserApi();
            
            //hash password
            AccountModel.RegisterModel sd = new AccountModel.RegisterModel();
            ViewBag.hasPassword = sd.setPassword(registerModel.PassWord);
            ViewBag.verify = sd.verify(registerModel.PassWord, ViewBag.hasPassword);

            //model for user
            registerModel = new AccountModel.RegisterModel()
            {
                UserName =  registerModel.UserName,
                PassWord =  sd.setPassword(registerModel.PassWord).TrimEnd(),
            };

            //getting api result
            var res = userApi.Insert(registerModel);
            ViewBag.result = res;
            return View();
        }

    }
}