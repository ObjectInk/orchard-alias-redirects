using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Alias.Redirects.Services;
using Orchard;
using Orchard.Localization;
using Orchard.Alias.Redirects.Models;
using System.Web.Routing;

namespace Orchard.Alias.Redirects.Controllers
{
    public class RedirectController : Controller
    {
        private readonly IRedirectService _redirectService;

        public RedirectController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        public ActionResult Index(string alias, string alias2 = "")
        {
            if (string.IsNullOrEmpty(alias))
                throw new HttpException(404, "Page cannot be found");

            if (!string.IsNullOrEmpty(alias2))
                alias = String.Format("{0}/{1}", alias, alias2);

            var entity = _redirectService.GetByAlias(alias);

            if (entity == null)             
                throw new HttpException(404, "Page cannot be found");

            return Redirect(entity.Url);
        }
    }
}