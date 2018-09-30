using Domain.Content;
using Domain.Content.Poco;
using Illium_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Illium_Forum.Controllers
{
    public class HomeController : Controller
    {
        private IContentRepository repository;

        public HomeController(IContentRepository rep)
        {
            repository = rep;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {

                Subject subModel = null;
                var threadList = repository.GetThreadList().OrderByDescending(p => p.Date).ToList();
                var model = new SubjectViewModel()
                {
                    subject = subModel,
                    threads = threadList
                };
                return View(model);
        }
    }
}