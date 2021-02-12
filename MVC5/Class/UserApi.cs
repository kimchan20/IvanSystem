using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MVC5.Models;
using MVC5.Repository;
using Newtonsoft.Json;

namespace MVC5.Class
{
    public class UserApi : IClassRepository2
    {
        private Api apilist = new Api();
        public string Insert(AccountModel.RegisterModel accountModel)
        {
            Uri uri = new Uri(string.Format(apilist.appDict["insert"]));
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
            try
            {
                Uri uri = new Uri(string.Format(apilist.appDict["login"] + loginModel.userName + "/" +
                                                loginModel.passWorld));
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);

                request.Method = "GET";
                request.ProtocolVersion = HttpVersion.Version11;
                request.ContentType = "application/json";
                request.ServerCertificateValidationCallback = delegate { return true; };

                using (var rsps = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    return rsps.ReadToEnd();
                }
            }
            catch (Exception ee)
            {
                return "Error : " + ee.Message;
            }
        }


        public async Task<string> userlist()
        {
            List<AccountModel.getUser> getUser = new List<AccountModel.getUser>();

            Uri uri = new Uri(string.Format(apilist.appDict["getuser"]));
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


        public async Task<string> getUser(int id)
        {
            Uri uri = new Uri(string.Format(apilist.appDict["getuserDetails"] + id));
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

        public Task<string> tostring(string data)
        {
            return  Task.FromResult(string.Empty);
        }
    }
}