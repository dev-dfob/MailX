using MailX.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MailX.Controllers
{
    public class AuthController : ApiController
    {
        private ProjectContext db = new ProjectContext();

        [HttpGet]
        public IHttpActionResult Login(string code = "", string access_token = "", string error = "", string error_description = "")
        {
            if(string.IsNullOrEmpty(error))
            {
                string response = GetRequest("https://oauth.vk.com/access_token?client_id=6718768&client_secret=3gfRm5hc1ySMQEc9OLDx&redirect_uri=http://localhost:8080/api/auth/login&code=" + code);
                dynamic stuff = JsonConvert.DeserializeObject(response);
                if (string.IsNullOrEmpty(stuff.error))
                {
                    int id = Convert.ToInt32(stuff.user_id);
                    if (db.Users.Where(u => u.VkId == id).FirstOrDefault() == null)
                    {
                        var user = new User();
                        user.VkId = id;
                        user.Email = stuff.email;
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    return Redirect(MvcURL("Index", "Home", null));
                }
            }
            return Redirect(MvcURL("Index", "Home", null)); //TODO: Error View
        }

        private string GetRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        private static string MvcURL(string routeName, string controller, object routeValues)
        {
            var urlHelper = new System.Web.Mvc.UrlHelper(
                new RequestContext(
                    new HttpContextWrapper(HttpContext.Current),
                    HttpContext.Current.Request.RequestContext.RouteData),
                    RouteTable.Routes);

            return urlHelper.Action(routeName, controller, routeValues, HttpContext.Current.Request.Url.Scheme);
        }
    }
}
