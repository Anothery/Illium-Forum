using Domain.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Illium_Forum.Controllers
{
    public class MenuController : Controller
    {
        private IContentRepository repository;

        public MenuController(IContentRepository rep)
        {
            repository = rep;
        }
        // GET: Menu
        public PartialViewResult SubList()
        {
            return PartialView(repository.GetSubjectList());
        }
    }
}