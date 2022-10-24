using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCms.Context;
using MyCms.Models;

namespace MyCms.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private CmsContext db = new CmsContext();

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var pages = db.Pages.Include(p => p.PageGroup);
            return View(pages.ToList());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,Tags,ImageName,ShowInSlider")] Page page , HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visits = 0;
                page.CreateDate = DateTime.Now;

                if(imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + System.IO.Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/") + page.ImageName);
                }
                else
                {
                    ModelState.AddModelError("ImageName", "لطفا یک عکس آپلود نمایید");
                }
                 
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,Tags,ImageName,CreateDate,Visits,ShowInSlider")] Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if(imgUp != null)
                {
                    if(page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/") + page.ImageName);
                    }
                    page.ImageName = Guid.NewGuid() + System.IO.Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/") + page.ImageName);
                }
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            if(page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/") + page.ImageName);
            }
            db.Pages.Remove(page);
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
