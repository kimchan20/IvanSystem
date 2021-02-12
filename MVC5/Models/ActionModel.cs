using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class ActionModel
    {
        public string Controller{ get;set;}
        public string Action{ get;set;}
        public string ReturnType{ get;set;}
        public string Attributes{ get;set;}
    }
}