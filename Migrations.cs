using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Alias.Redirects.Services;

namespace Orchard.Alias.Redirects
{
    public class Migrations : DataMigrationImpl 
    {
        public int Create() {            
            SchemaBuilder.CreateTable("RedirectModelRecord",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Url", column => column.NotNull().Unlimited().WithDefault(""))
                    .Column<string>("Alias", column => column.NotNull().Unlimited().WithDefault(""))
                );
            return 1;
        }
    }
}