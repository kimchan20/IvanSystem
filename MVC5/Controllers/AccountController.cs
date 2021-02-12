using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC5.Class;
using MVC5.Models;
using MVC5.Repository;
using Xunit.Sdk;

namespace MVC5.Controllers
{
    [TestClass]
    public class AccountController : Controller
    {

        private readonly IClassRepository2 _classREpository;

        public AccountController() { }
        public AccountController(IClassRepository2 classRepository)
        {
            _classREpository = classRepository;
        }

        [HttpGet]
        [Route("test/{hello?}")]
        public ActionResult test(string hello)
        {
            var res = _classREpository.tostring(hello);
            return View(res);
        }

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

        [HandleError(ExceptionType = typeof(HttpAntiForgeryException), View = "login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(AccountModel.LoginModel login, string ReturnUrl)
        {

            ViewBag.returnUri = ReturnUrl == null ? "" : ReturnUrl;
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (User.Identity.IsAuthenticated)
            {
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
            }

            UserApi userApi = new UserApi();
            //      var res = userApi.loginUser(login);
            if (true)
            {
                FormsAuthentication.SetAuthCookie(login.userName, false);
                RouteCollection collection = new RouteCollection();
                var completeRoute = this.ControllerContext.RouteData.Route;

                test();
                if (ReturnUrl != null)
                {
                    var islocal = Url.IsLocalUrl(ReturnUrl);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {

                        var ss = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("username", "You are not allow to do that!");
                        return RedirectToAction("Home", "Index");
                    }

                }

                ViewBag.loginMessage = "Login Success";
                return RedirectToAction("Home", "Index");
            }
            else if ("Error".Contains("Error"))
            {
                ModelState.AddModelError("username", "Error : " + "");
            }
            else
            {
                ModelState.AddModelError("username", "Username and Password didnt match.");
            }

            return View();
        }

        void test()
        {
            Assembly asm = Assembly.GetAssembly(typeof(MVC5.MvcApplication));

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

          
          
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
                UserName = registerModel.UserName,
                PassWord = sd.setPassword(registerModel.PassWord).TrimEnd(),
            };

            //getting api result
            var res = userApi.Insert(registerModel);
            ViewBag.result = res;
            return View();
        }

    }
}