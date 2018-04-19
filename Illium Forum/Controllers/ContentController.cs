using Domain.Content;
using Illium_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Illium_Forum.Controllers
{
    public class ContentController : Controller
    {
        private IContentRepository repository;

        public ContentController(IContentRepository rep)
        {
            repository = rep;
        }

        [Route("subject/{subName}")]
        public ActionResult Index(string subName)
        {
            if (repository.GetSubjectList().Any(p => p.Code == subName))
            {
                var model = repository.GetSubjectList().Single(p => p.Code == subName);
                return View(model);
            }
            else return HttpNotFound();
        }

        public ActionResult Thread(Thread thread)
        {
            if (thread != null)
            {
                string posts = "0 комментариев";
                var postCount = thread.Posts.Count;
                if (postCount % 100 >= 5 && postCount % 100 <= 20) posts = $"{postCount} комментариев";
                else if (postCount % 10 == 1) posts = $"{postCount} комментарий";
                else if (postCount % 10 >= 2 && postCount % 10 <= 4 ) posts = $"{postCount} комментария";

                var model = new ThreadViewModel
                {
                    ThreadId = thread.ThreadId,
                    Text = thread.Text,
                    Votecount = thread.Votecount,
                    Date = thread.Date.ToString("yyyyMMddHHmmss"),
                    Postcount = posts, 
                    UserName = "sas", 
                    ImagePath = thread.ImagePath
                };
                return PartialView(model);
            }
            else return HttpNotFound();
        }
    }
}