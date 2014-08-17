using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;
using Orchard.Alias.Redirects.Routing;

namespace Orchard.Alias.Redirects
{
    public class Routes : IRouteProvider
    {
        private readonly IRedirectPathConstraint _redirectPathConstraint;

        public Routes(IRedirectPathConstraint redirectPathConstraint)
        {
            _redirectPathConstraint = redirectPathConstraint;
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Route = new Route(                                                         
                        "{alias}",
                        new RouteValueDictionary {      
                                                    {"area", "Orchard.Alias.Redirects"},
                                                    {"controller", "Redirect"},
                                                    {"action", "Index"},                                                                                      
                                                },
                        new RouteValueDictionary{ {"alias", _redirectPathConstraint}}, 
                        new RouteValueDictionary {
                                                    {"area", "Orchard.Alias.Redirects"}
                                                },
                        new MvcRouteHandler())   
                        },
                new RouteDescriptor {
                    Route = new Route(                                                         
                        "{alias}/{alias2}",
                        new RouteValueDictionary {      
                                                    {"area", "Orchard.Alias.Redirects"},
                                                    {"controller", "Redirect"},
                                                    {"action", "Index"},                                                                                      
                                                },
                        new RouteValueDictionary{ {"alias", _redirectPathConstraint}, 
                                                {"alias2", _redirectPathConstraint}
                        }, 
                        new RouteValueDictionary {
                                                    {"area", "Orchard.Alias.Redirects"}
                                                },
                        new MvcRouteHandler())   
                        }


            };
        }
    }
}