using Domain.Content;
using Domain.Content.Poco;
using Domain.MySQLIdentity;
using Illium_Forum.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Illium_Forum.Controllers
{
    public class ThreadController : Controller
    {

        private IContentRepository repository;

        public ThreadController(IContentRepository rep)
        {
            repository = rep;
        }

        [HttpPost]
        public ActionResult InsertThread(InsertThreadViewModel model)
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            model.userId = user;
            if (model.threadText == null | model.threadName == null) return Redirect(Request.UrlReferrer.ToString());
            var result = repository.InsertThread(model.threadName, model.threadText, model.subId, model.userId);
            if (result != -1)
                return RedirectToAction("GetThread", "Thread", new { threadId = result, subId = model.subId });
            else return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult CreateThread(int subId)
        {
            var model = new InsertThreadViewModel();
            model.subId = subId;
            return PartialView("~/Views/Thread/InsertThread.cshtml", model);
        }


        [Route("t/{threadId}")]
      //  [ActionName("GetNewThread")]
        public ActionResult GetThread(int threadId)
        {   
            var model = new InsideThreadViewModel();
            var thread = repository.GetThread(threadId);
            if (thread == null) return HttpNotFound();
            var threadViewModel = new ThreadViewModel();
            threadViewModel.Date = thread.Date;
            threadViewModel.Name = thread.Name;
            threadViewModel.SubId = thread.SubId;
            threadViewModel.Text = thread.Text;
            threadViewModel.ThreadId = thread.ThreadId;
            threadViewModel.PostCount = 0;
            threadViewModel.UserId = thread.UserId;
            if (thread.UserId is null) threadViewModel.Username = "Неизвестный";
            else
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindById(thread.UserId);
                threadViewModel.Username = user is null ? "Неизвестный" : user.UserName;
            }
            model.thread = threadViewModel;
            
            model.posts = (List<Post>) repository.GetPosts(threadId);

            return View(model);
        }

        // [Route("subject/{subId}/{threadId}")]

    /*    public ActionResult GetThread(int threadId)
        {
            var model = new InsideThreadViewModel();
            var thread = repository.GetThread(threadId);
            if (thread == null) return HttpNotFound();
            var threadViewModel = new ThreadViewModel();
            threadViewModel.Date = thread.Date;
            threadViewModel.Name = thread.Name;
            threadViewModel.SubId = thread.SubId;
            threadViewModel.Text = thread.Text;
            threadViewModel.ThreadId = thread.ThreadId;
            threadViewModel.PostCount = 0;
            threadViewModel.UserId = thread.UserId;
            if (thread.UserId is null) threadViewModel.Username = "Неизвестный";
            else
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindById(thread.UserId);
                threadViewModel.Username = user is null ? "Неизвестный" : user.UserName;
            }
            model.thread = threadViewModel;
            model.posts = null;
            return View(model);
        }
        */
        public PartialViewResult Post(Post post)
        {

            var model = new PostViewModel();
            model.Date = post.Date;
            model.Text = post.Text;
            model.ThreadId = post.ThreadId;
            model.UserId = post.UserId;
            if (post.UserId is null) model.Username = "Неизвестный";
            else
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindById(post.UserId);
                model.Username = user is null ? "Неизвестный" : user.UserName;
            }
            return PartialView(model);

        }


        [HttpPost]
        public ActionResult InsertPost(InsertPostViewModel model)
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            model.userId = user;
            if (model.postText == null ) return Redirect(Request.UrlReferrer.ToString());
            repository.InsertPost(model.postText, model.threadId, model.userId);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}