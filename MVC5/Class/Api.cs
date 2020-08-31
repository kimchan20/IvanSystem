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
        
        private static string hostname = lcoal;

        public Dictionary<string, string> appDict = new Dictionary<string, string>()
        {
            {"insert",hostname +"/api/InserUser/"},
            {"login",hostname+ "/api/loginUser/"},
            {"getuser",hostname+"/api/getUserList/"},
            {"getuserDetails",hostname+"/api/getEdituser/"},
        };
    }
}