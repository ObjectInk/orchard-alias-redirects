using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Alias.Redirects.Services;
using System.Web.Routing;

namespace Orchard.Alias.Redirects.Routing
{
    public class RedirectPathConstraint : IRedirectPathConstraint
    {
        private readonly IRedirectService _redirectService;

        public RedirectPathConstraint(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value))
            {
                var parameterValue = Convert.ToString(value);

                return _redirectService.ContainsAlias(parameterValue);
            }
            return false;
        }
    }
}