using BoardGamesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BoardGamesProject.Interfaces
{
    interface ICookieManager
    {
        Queue<CookieObject> GetCookies(string cookie);
        string SetCookies(int id, string cookie);
        CookieObject CreateCookieObject();
    }
}
