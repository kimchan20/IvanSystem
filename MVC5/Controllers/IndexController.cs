using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC5.Class;
using MVC5.Models;
using Newtonsoft.Json;

namespace MVC5.Controllers
{

    [Authorize()]
    public class IndexController : Controller
    {

        private UserApi userApi = new UserApi();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public async Task<ActionResult> _userList()
        {
            try
            {
                userApi = new UserApi();
                var userlist = new List<AccountModel.getUser>();
                var result = userApi.userlist();
                if (result.IsCompleted)
                {
                    userlist = JsonConvert.DeserializeObject<List<AccountModel.getUser>>(result.Result);
                    return View(userlist);
                }
            }
            catch
            {
                return HttpNotFound("404");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            userApi = new UserApi();
            AccountModel.getUser getuser = new AccountModel.getUser();
            var result = userApi.getUser(id);
            if (result.IsCompleted)
            {
                getuser = JsonConvert.DeserializeObject<AccountModel.getUser>(result.Result);
                return View(getuser);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AccountModel.getUser getusermodel)
        {
            return View(getusermodel);
        }


        public ActionResult MultipleSample()
        {
            return View();
        }

        public ActionResult _multiple(OtherModel.Multiplemodel model )
        {
            return View(model);
        }
    }
}