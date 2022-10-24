using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCms.Context;
using MyCms.Models;
using System.Data.Entity;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        CmsContext db = new CmsContext();



        [ChildActionOnly]
        public ActionResult ShowGroups()
        {
            var groups = db.PageGroups.Select(g => new ShowGroupsViewModel()
            {
                GroupId = g.GroupId,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            });
            return PartialView(groups);
        }


        [ChildActionOnly]
        public ActionResult MenuGroups()
        {
            return PartialView(db.PageGroups);
        }

        [ChildActionOnly]
        public ActionResult PopularNews()
        {
            var news = db.Pages.OrderByDescending(p => p.Visits).Select(p => new PopularNewsViewModel()
            {
                PageId = p.PageId,
                Title = p.Title,
                ImageName = p.ImageName,
                CreateDate = p.CreateDate
            }).Take(4);
            return PartialView(news);
        }


        [Route("News/{id}")]
        public ActionResult SingleNews(int id)
        {
            var page = db.Pages.SingleOrDefault(p => p.PageId == id);
            if (page == null)
            {
                return HttpNotFound();
            }
            page.Visits += 1;
            db.Entry(page).State = EntityState.Modified;
            db.SaveChanges();

            return View(page);
        }



        public ActionResult AddComment(int id, string name, string email , string comment)
        {
            db.PageComments.Add(new PageComment()
            {
                PageId = id,
                Name = name,
                Email = email,
                Comment = comment,
                CreateDate = DateTime.Now
            });
            db.SaveChanges();

            var comments = db.PageComments.Where(p => p.PageId == id);
            return PartialView("ShowComments" , comments);
        }


        public ActionResult ShowComments(int id)
        {
            var comments = db.PageComments.Where(p => p.PageId == id);
            return PartialView(comments);
        }

        [Route("Search")]
        public ActionResult SearchNews(string q)
        {
            ViewBag.query = q;
            q = q.ToLower().Trim();
            var pages = db.Pages.Where(p => p.Title.ToLower().Contains(q) || p.ShortDescription.ToLower().Contains(q) || p.Tags.ToLower().Contains(q) || p.Text.ToLower().Contains(q)).Distinct();
            return View(pages);
        }
    }
}