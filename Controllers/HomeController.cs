using MyCms.Context;
using MyCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class HomeController : Controller
    {
        CmsContext db = new CmsContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            var pages = db.Pages.Where(p => p.ShowInSlider).Select(p => new SliderViewModel()
            {
                PageId = p.PageId,
                Title = p.Title,
                ImageName = p.ImageName,
                CreateDate = p.CreateDate,
                ShortDescription = p.ShortDescription
            });
            return PartialView(pages);
        }

        [Route("Archieve/{groupId?}/{groupTitle?}")]
        public ActionResult Archieve(int groupId=0)
        {
            IQueryable<Page> pages = db.Pages;

            if (groupId != 0)
            {
                pages = pages.Where(p => p.GroupId == groupId);

                ViewBag.GroupTitle = db.PageGroups.Where(g => g.GroupId == groupId).Select(g => g.GroupTitle).Single();
            }
            return View(pages);
        }

        [ChildActionOnly]
        public ActionResult LastNews()
        {
            var pages = db.Pages.OrderByDescending(p => p.CreateDate).Take(4);
            return PartialView(pages);
        }
    }
}