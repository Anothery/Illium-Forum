using System.Linq;
using Domain.Content.Poco;
using System.Web.Mvc;
using Illium_Forum.Models;
using Domain.Content;
using Domain.MySQLIdentity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Illium_Forum.Controllers
{
    public class SubjectController : Controller
    {
        private IContentRepository repository;

        public SubjectController(IContentRepository rep)
        {
            repository = rep;
        }

        [Route("subject/{subName}")]
        public ActionResult Index(string subName)
        {
            if (repository.GetSubjectList().Any(p => p.Code == subName))
            {
                var subModel = repository.GetSubjectList().Single(p => p.Code == subName);
                var threadList = repository.GetThreadList(subModel.SubId).OrderByDescending(p => p.Date).ToList();
                var model = new SubjectViewModel()
                {
                    subject = subModel,
                    threads = threadList
                };
                return View(model);
            }
            else return HttpNotFound();
        }

        public PartialViewResult Thread(Thread thread)
        {

            var model = new ThreadViewModel();
            model.Date = thread.Date;
            model.Name = thread.Name;
            model.SubId = thread.SubId;
            model.Text = thread.Text;
            model.ThreadId = thread.ThreadId;
            model.PostCount = thread.PostCount is null ? 0 : thread.PostCount;
            model.UserId = thread.UserId;
            if (thread.UserId is null) model.Username = "Неизвестный";
            else
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindById(thread.UserId);
                model.Username = user is null ? "Неизвестный" : user.UserName;
            }
            return PartialView(model);

        }
    }
}