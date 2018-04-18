using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Content;
using System.Web.Mvc;

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
                var model = repository.GetSubjectList().Single(p => p.Code == subName);
                return View(model);
            }
            else return HttpNotFound();
        }
    }
}