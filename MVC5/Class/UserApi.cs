using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using MVC5.Models;
using Newtonsoft.Json;

namespace MVC5.Class
{
    public class UserApi
    {
        private Api apilist = new Api();
        public string Insert(AccountModel.RegisterModel accountModel)
        {
            Uri uri = new Uri(string.Format(apilist.appDict.Keys("insert")));
            string jsonData = JsonConvert.SerializeObject(accountModel);
            string remBraket = jsonData.Replace('[', ' ');

            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                return Encoding.ASCII.GetString(client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(remBraket.Replace(']',' '))));
            }

        }



        public string loginUser(AccountModel.LoginModel loginModel)
        {
            Uri uri = new Uri(string.Format(apilist.Apilist[1] + loginModel.userName + "/" + loginModel.passWorld));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            request.ContentType = "application/json";
            request.ServerCertificateValidationCallback = delegate { return true; };

            using (var rsps = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return rsps.ReadToEnd();
            }
        }
    }
}