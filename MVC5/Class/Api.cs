using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC5.Class
{
    public class Api
    {
        private static string server = WebConfigurationManager.AppSettings["ServerApi"];
        private static string lcoal = WebConfigurationManager.AppSettings["localApi"];
        


        public Dictionary<string, string> appDict = new Dictionary<string, string>()
        {
            {"insert",server +"/api/InserUser/"},
            {"login",server+ "/api/loginUser/"},
            {"getuser",server+"/api/getUserList/"},
        };
    }
}