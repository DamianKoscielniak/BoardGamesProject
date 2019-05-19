using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BoardGamesProject.DAL;
using BoardGamesProject.Interfaces;
using BoardGamesProject.Managers;
using BoardGamesProject.Models;

namespace BoardGamesProject.Controllers.WebAPI
{
    public class BoardGamesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        ICookieManager cookieManager = new WebServiceCookieManager();

        // GET: api/BoardGames
        public IQueryable<BoardGame> GetBoardGames(int? quantity = null)
        {
            if(quantity != null && quantity > 0)
            {
                return db.BoardGames.Take((int)quantity);
            }
            return db.BoardGames;
        }

        // GET: api/BoardGames/5
        [ResponseType(typeof(BoardGame))]
        public IHttpActionResult GetBoardGame(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return NotFound();
            }
            var cookieName = String.Format("BoardGame-{0}", id);
            var cookies = Request.Headers.GetCookies().Select(x => x.Cookies.Where(z => z.Name == cookieName).FirstOrDefault()).FirstOrDefault();
            var lastVisits = cookieManager.GetCookies(cookies?.Value);
            var newCookie = cookieManager.SetCookies(id, cookies?.Value);
            HttpCookie cookie = new HttpCookie(cookieName, newCookie);
            HttpContext.Current.Response.Cookies.Add(cookie);

            return Ok(boardGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardGameExists(int id)
        {
            return db.BoardGames.Count(e => e.ID == id) > 0;
        }
    }
}