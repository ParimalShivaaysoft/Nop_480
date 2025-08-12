using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Core.Domain.Catalog;
namespace Nop.Data.CustomMigration
{
    [NopMigration("2025-07-31 16:41:00", "Create OfferInfoTable")]

    public class CreateOfferTable : ForwardOnlyMigration
    {
        /// <summary>
        /// for add migration
        /// </summary>
        public override void Up()
        {

            Create.TableFor<OfferInfoTable>();
            Create.TableFor<OfferInfoTable>();
        }
    }
}
