using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.Alias.Redirects.Services;
using Orchard.Alias.Redirects.Models;
using Orchard.Security;
using System.Web.Routing;
using Orchard.UI.Admin;
using OMVC = Orchard.Mvc;

namespace Orchard.Alias.Redirects.Controllers
{
    [Admin] 
    public class AdminController : Controller
    {
        private readonly IRedirectService _redirectService;
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public AdminController(IRedirectService redirectService, IOrchardServices orchardServices)
        {
            _redirectService = redirectService;
            Services = orchardServices;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.ExistingRedirects = new List<RedirectEntity>();

            LoadExistingRedirects(model);

            return View(model);
        }

        [HttpPost]
        [OMVC.FormValueRequired("submit.Save")]
        public ActionResult Edit(RedirectEntity entity)
        {
            if (!ModelState.IsValid)
                return View(entity);

            var model = _redirectService.GetById(int.Parse(entity.Id));

            model.Alias = entity.Alias;
            model.Url = entity.Url;

            _redirectService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [OMVC.FormValueRequired("submit.Delete")]
        [ActionName("Edit")]
        public ActionResult Delete(RedirectEntity entity)
        {
            _redirectService.Delete(int.Parse(entity.Id));  

            return RedirectToAction("Index");
        }

        private void LoadExistingRedirects(IndexViewModel model)
        {
            List<RedirectEntity> entities = new List<RedirectEntity>();
            List<RedirectModelRecord> redirects = _redirectService.GetAll();
            foreach (var redirect in redirects)
            {
                entities.Add(new RedirectEntity()
                {
                    Url = redirect.Url,
                    Id = redirect.Id.ToString(),
                    Alias = redirect.Alias
                }
                );
            }
            model.ExistingRedirects = entities;
        }

        public ActionResult Edit(string id)
        {
            var model = _redirectService.GetById(int.Parse(id));

            var entity = new RedirectEntity();
            entity.Id = id;
            entity.Alias = model.Alias;
            entity.Url = model.Url;

            return View(entity);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [OMVC.FormValueRequired("submit.Create")]
        public ActionResult Create(RedirectEntity entity)
        {
            if (!ModelState.IsValid)
                return View(entity);

            _redirectService.Create(entity.Url, entity.Alias);

            return RedirectToAction("Index");
        }

    }
}