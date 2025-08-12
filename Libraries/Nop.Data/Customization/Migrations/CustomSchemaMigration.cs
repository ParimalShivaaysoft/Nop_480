using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations
{
    [NopMigration("2025-08-08 11:41:00", "CustomSchemaMigration for 4.60.0")]

    public partial class CustomSchemaMigration : Migration
    {
       
        public override void Up()
        {
            //This condition for if table not exist in database then those table create on database
            //.net version 4.6

            if (!Schema.Table(nameof(OfferInfoTable)).Exists())
                Create.TableFor<OfferInfoTable>();

            if (!Schema.Table(nameof(Employee)).Exists())
                Create.TableFor<Employee>();

            if (!Schema.Table(nameof(Cities)).Exists())
                Create.TableFor<Cities>();

        }

        public override void Down()
        {
            
        }

    }
}
