using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public class Plop
        {
            public string username { get; set; }
            public string password { get; set; }
            public string grant_type { get; set; }

        }
        [HttpPost]
        public async Task<ActionResult> About(Plop troll)
        {
            troll.username = "clara.romero";
            troll.password = "123456";
            troll.grant_type = "password";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vmdev26273.cloudapp.net/WebAPI_PRUEBA/api/Committee/PostReport");
                client.DefaultRequestHeaders.Accept.Clear();
                //var postTask = await client.PostAsJsonAsync<Plop>("http://vmdev26273.cloudapp.net/WebAPI_AA/oauth/token", troll);

                var tokenModel = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", troll.username},
                    {"password", troll.password},
                };
                var response = await client.PostAsync("http://vmdev26273.cloudapp.net/WebAPI_AA/oauth/token", new FormUrlEncodedContent(tokenModel));

                // postTask.wa;
                var s = new HttpStatusCodeResult(response.StatusCode, response.ReasonPhrase);

                var result = response;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Contact(Plop troll)
        {
            //REFERENCIA : http://www.anilsezer.com/token-based-authentication-using-aspnet-web-api-with-owin
            //PARA AUTENTICANSE CON TOKEN
            troll.username = "clara.romero";
            troll.password = "123456";
            troll.grant_type = "password";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://vmdev26273.cloudapp.net/WebAPI_PRUEBA/api/Committee/PostReport");
                client.DefaultRequestHeaders.Accept.Clear();
                //var postTask = await client.PostAsJsonAsync<Plop>("http://vmdev26273.cloudapp.net/WebAPI_AA/oauth/token", troll);

                var tokenModel = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", troll.username},
                    {"password", troll.password},
                };
                var response = await client.PostAsync("http://vmdev26273.cloudapp.net/WebAPI_AA/oauth/token", new FormUrlEncodedContent(tokenModel));

                // postTask.wa;
                var s = new HttpStatusCodeResult(response.StatusCode, response.ReasonPhrase);

                var result = response;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}