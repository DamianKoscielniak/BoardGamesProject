using BoardGamesProject.Interfaces;
using BoardGamesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BoardGamesProject.Managers
{
    public class WebSiteCookieManager : ICookieManager
    {
        public CookieObject CreateCookieObject()
        {
            return new CookieObject()
            {
                Date = DateTime.Now,
                VisitType = Enumerates.VisitType.WebSite
            };
        }

        public Queue<CookieObject> GetCookies(string cookie)
        {
            Queue<CookieObject> toReturn;
            if (cookie != null)
            {
                toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<Queue<CookieObject>>(cookie);
            }
            else
            {
                toReturn = new Queue<CookieObject>();
            }
            return toReturn;
        }

        public string SetCookies(int id, string cookie)
        {
            var cookies = GetCookies(cookie);
            var newCookie = CreateCookieObject();
            cookies.Enqueue(newCookie);
            while (cookies.Count > 10)
            {
                cookies.Dequeue();
            }
            var cookieObjectsJson = new JavaScriptSerializer().Serialize(cookies);
            return cookieObjectsJson;
        }
    }
}