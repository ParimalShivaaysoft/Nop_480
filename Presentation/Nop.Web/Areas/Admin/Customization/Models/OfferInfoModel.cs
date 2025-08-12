using System;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Model
{
    public partial record OfferInfoModel : BaseNopEntityModel
    {
        public OfferInfoModel()
        {
            OfferSearchInfoModel = new OfferInfoSearchModel();
        }

        [NopResourceDisplayName("Admin.OfferInfos.Fields.Name")]
        public string Name { get; set; }


        [NopResourceDisplayName("Admin.OfferInfos.Fields.Description")]
        public string Description { get; set; }


        [NopResourceDisplayName("Admin.OfferInfos.Fields.Active")]
        public bool Active { get; set; }


        [NopResourceDisplayName("Admin.OfferInfos.Fields.StartDate")]
        public DateTime StartDate { get; set; }


        [NopResourceDisplayName("Admin.OfferInfos.Fields.EndDate")]
        public DateTime EndDate { get; set; }

        public OfferInfoSearchModel OfferSearchInfoModel { get; set; }
    }
}
