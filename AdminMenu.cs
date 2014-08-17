using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Navigation;
using Orchard.Localization;
using Orchard.Security;

namespace Orchard.Alias.Redirects
{
    public class AdminMenu : INavigationProvider
    {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Redirects"), "3", item => item.Action("Index", "Admin", new { area = "Orchard.Alias.Redirects" }).Permission(StandardPermissions.AccessAdminPanel));
        }
    }
}