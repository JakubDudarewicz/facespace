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
    public class ActivityModelsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: ActivityModels
        public ActionResult Index()
        {
            //var activity = db.Activity.Include(a => a.User);
            return View(db.Activity.ToList());
        }

        // GET: ActivityModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModel activityModel = db.Activity.Find(id);
            if (activityModel == null)
            {
                return HttpNotFound();
            }
            return View(activityModel);
        }

        // GET: ActivityModels/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Users, "ID", "Nick");
            return View();
        }

        // POST: ActivityModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumberOfPosts,NumberOfComments")] ActivityModel activityModel)
        {
            if (ModelState.IsValid)
            {
                db.Activity.Add(activityModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Users, "ID", "Nick", activityModel.ID);
            return View(activityModel);
        }

        // GET: ActivityModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModel activityModel = db.Activity.Find(id);
            if (activityModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Users, "ID", "Nick", activityModel.ID);
            return View(activityModel);
        }

        // POST: ActivityModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumberOfPosts,NumberOfComments")] ActivityModel activityModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Users, "ID", "Nick", activityModel.ID);
            return View(activityModel);
        }

        // GET: ActivityModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityModel activityModel = db.Activity.Find(id);
            if (activityModel == null)
            {
                return HttpNotFound();
            }
            return View(activityModel);
        }

        // POST: ActivityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityModel activityModel = db.Activity.Find(id);
            db.Activity.Remove(activityModel);
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
