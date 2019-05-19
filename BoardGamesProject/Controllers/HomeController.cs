using BoardGamesProject.DAL;
using BoardGamesProject.Interfaces;
using BoardGamesProject.Managers;
using BoardGamesProject.Models;
using BoardGamesProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BoardGamesProject.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        ICookieManager cookieManager = new WebSiteCookieManager();

        public ActionResult Index()
        {
            var model = db.BoardGames.Select(x => new SingleBoardGame()
            {
                ID = x.ID,
                Name = x.Name,
                MinimalAge = x.MinimalAge,
                ReleaseDate = x.ReleaseDate
            }).AsEnumerable();
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            string cookieName = String.Format("BoardGame-{0}", id);
            var cookies = Request.Cookies[cookieName];
            var lastVisits = cookieManager.GetCookies(cookies?.Value);
            var cookie = new HttpCookie(cookieName);
            cookie.Value = cookieManager.SetCookies((int)id, cookies?.Value);
            Response.Cookies.Add(cookie);

            BoardGameDetailsViewModel model = new BoardGameDetailsViewModel()
            {
                Description = boardGame.Description,
                ID = boardGame.ID,
                MinimalAge = boardGame.MinimalAge,
                Name = boardGame.Name,
                ReleaseDate = boardGame.ReleaseDate,
                LastVisits = lastVisits.OrderByDescending(x => x.Date).AsEnumerable()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoardGameCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                BoardGame boardGame = new BoardGame()
                {
                    Description = model.Description,
                    MinimalAge = model.MinimalAge,
                    Name = model.Name,
                    ReleaseDate = model.ReleaseDate
                };
                db.BoardGames.Add(boardGame);
                try
                {
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }        
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            BoardGameEditViewModel model = new BoardGameEditViewModel()
            {
                Description = boardGame.Description,
                ID = boardGame.ID,
                MinimalAge = boardGame.MinimalAge,
                Name = boardGame.Name,
                ReleaseDate = boardGame.ReleaseDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoardGameEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                BoardGame boardGame = db.BoardGames.Find(model.ID);
                if(boardGame == null)
                {
                    return HttpNotFound();
                }
                boardGame.Description = model.Description;
                boardGame.MinimalAge = model.MinimalAge;
                boardGame.Name = model.Name;
                boardGame.ReleaseDate = model.ReleaseDate;

                db.Entry(boardGame).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            db.BoardGames.Remove(boardGame);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(boardGame);
            }
            return RedirectToAction("Index");
        }
    }
}