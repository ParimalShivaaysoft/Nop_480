using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Web.Areas.Admin.Model;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial interface IOfferInfoModelFactory
    {
        /// <summary>
        /// for this factory layout and list page shown/ List
        /// </summary>
        /// <param name="offer">Offer Info Model</param>
        /// <returns></returns>
        OfferInfoSearchModel PrepareOfferSearchInfoModelAsync(OfferInfoSearchModel offer);


        /// <summary>
        /// when the method of post of List that time we used Listmodel
        /// whatever we searched those data filter and come into the list and return list
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<OfferListModel> PrepareOfferListModelAsync(OfferInfoSearchModel offer);


        /// <summary>
        /// Inserting
        /// </summary>
        /// <returns></returns>
        OfferInfoModel PrepareOfferInfoModel(OfferInfoModel model, OfferInfoTable offer);
                
    }
}
