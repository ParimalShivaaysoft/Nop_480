using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping
{
    public partial class CustomBaseNameCompatibility : INameCompatibility
    {
        public Dictionary<Type, string> TableNames => new()
        {
            { typeof(OfferInfoTable), "OfferInfoTable" },
            { typeof(Employee), "Employee" },
        };

        public Dictionary<(Type, string), string> ColumnName => new ();
    }
}
