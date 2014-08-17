using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace Orchard.Alias.Redirects.Models
{
    public class RedirectModelRecord 
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage="*")]
        public virtual string Url { get; set; }
        [Required(ErrorMessage = "*")]
        [CustomValidation(typeof(RedirectEntity), "AliasValidation")]
        public virtual string Alias { get; set; }

        public RedirectModelRecord()
        {            
        }        
    }

    public class IndexViewModel
    {
        public IEnumerable<RedirectEntity> ExistingRedirects { get; set; }
    }

    public class RedirectEntity
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Url { get; set; }
        [Required(ErrorMessage = "*")]
        [CustomValidation(typeof(RedirectEntity), "AliasValidation")]
        public string Alias { get; set; }

        public static ValidationResult AliasValidation(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new ValidationResult("Please provide a valid alias.");

            return ValidationResult.Success;
        }
    }
}