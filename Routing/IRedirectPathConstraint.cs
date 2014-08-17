using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Orchard;

namespace Orchard.Alias.Redirects.Routing
{
    public interface IRedirectPathConstraint : IRouteConstraint, ISingletonDependency
    {
    }
}
