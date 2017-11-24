using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace FaceSpace.Controllers
{
    public class FriendModelsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: FriendModels
        public ActionResult Index()
        {
            var friends = db.Friends.Include(f => f.Friend).Include(f => f.User);
            return View(friends.ToList());
        }

        // GET: FriendModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            return View(friendModel);
        }

        // GET: FriendModels/Create
        public ActionResult Create()
        {
            ViewBag.FriendID = new SelectList(db.Users, "ID", "Nick");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Nick");
            return View();
        }

        // POST: FriendModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelationID,UserID,FriendID")] FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friendModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FriendID = new SelectList(db.Users, "ID", "Nick", friendModel.FriendID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Nick", friendModel.UserID);
            return View(friendModel);
        }

        // GET: FriendModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FriendID = new SelectList(db.Users, "ID", "Nick", friendModel.FriendID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Nick", friendModel.UserID);
            return View(friendModel);
        }

        // POST: FriendModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelationID,UserID,FriendID")] FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FriendID = new SelectList(db.Users, "ID", "Nick", friendModel.FriendID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Nick", friendModel.UserID);
            return View(friendModel);
        }

        // GET: FriendModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            return View(friendModel);
        }

        // POST: FriendModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FriendModel friendModel = db.Friends.Find(id);
            db.Friends.Remove(friendModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
