using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard;
using Orchard.Alias.Redirects.Models;

namespace Orchard.Alias.Redirects.Services
{
    public interface IRedirectService : IDependency
    {
        List<RedirectModelRecord> GetAll();
        bool Create(string url, string alias);
        RedirectModelRecord GetById(int id);
        bool Delete(int id);
        RedirectModelRecord GetByAlias(string alias);
        bool ContainsAlias(string alias);
        bool Update(RedirectModelRecord entity);
    }
}
