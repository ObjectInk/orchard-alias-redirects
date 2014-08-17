using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Alias.Redirects.Models;
using Orchard.Caching;

namespace Orchard.Alias.Redirects.Services
{
    public class RedirectService : IRedirectService
    {
        private readonly IRepository<RedirectModelRecord> _repository;

        public RedirectService(IRepository<RedirectModelRecord> repository)
        {
            _repository = repository;
        }

        public List<RedirectModelRecord> GetAll()
        {
            return _repository.Table.ToList();
        }

        public bool Create(string url, string alias)
        {
            if (GetByAlias(alias) != null)
                return true;

            RedirectModelRecord record = new RedirectModelRecord()
            {                
                Alias = alias,
                Url = url
            };

            _repository.Create(record);

            _repository.Flush();            

            return true;
        }

        public RedirectModelRecord GetById(int id)
        {
            return _repository.Get(id);
        }

        public RedirectModelRecord GetByAlias(string alias)
        {
            return _repository.Get(r => r.Alias == alias);
        }

        public bool ContainsAlias(string alias)
        {
            var redirects = GetAll();

            var result = redirects.Any(x => x.Alias.ToLower().Contains(alias.ToLower()));

            return result;
        }

        public bool Delete(int id)
        {
            _repository.Delete(GetById(id));

            _repository.Flush();   

            return true;
        }

        public bool Update(RedirectModelRecord entity)
        {
            _repository.Update(entity);

            _repository.Flush();   

            return true;
        }
    }
}