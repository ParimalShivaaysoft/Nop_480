using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Services.OfferInfo;
using Nop.Web.Areas.Admin.Model;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public partial class OfferInfoModelFactory : IOfferInfoModelFactory
{
    #region Field

    private readonly IOfferInfoService _service;

    #endregion


    #region ctor
    public OfferInfoModelFactory(IOfferInfoService service)
    {
        _service = service;
    }

    #endregion


    #region Methods
    /// <summary>
    /// using this method grid will be shown 
    /// </summary>
    /// <param name="offer Search model"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public OfferInfoSearchModel PrepareOfferSearchInfoModelAsync(OfferInfoSearchModel offer)
    {
        if (offer == null)
            throw new System.ArgumentNullException(nameof(OfferInfoSearchModel));

        offer.SetGridPageSize();
        return offer;
    }


    /// <summary>
    /// Search model filter data come to the offer list model and return list- offer list model
    /// </summary>
    /// <param name="offerSearchInfoModel"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual async Task<OfferListModel> PrepareOfferListModelAsync(OfferInfoSearchModel offerSearchInfoModel)
    {
        if (offerSearchInfoModel == null)
            throw new ArgumentNullException(nameof(offerSearchInfoModel));
        //Get offerinfo
        var offer = await _service.GetAllOfferInfosAsync();

        var model = await new OfferListModel().PrepareToGridAsync(offerSearchInfoModel, offer, () =>
        {
            return offer.SelectAwait(async x =>
            {
                var offerModel = new OfferInfoModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Active = x.Active,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                };
                return offerModel;
            });
        });
        return model;
    }


    /// <summary>
    /// This factory use for inserting
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public OfferInfoModel PrepareOfferInfoModel(OfferInfoModel model, OfferInfoTable tbl)
    {
        //set default values for the new model, if tbl has not data or null that time it create new model
        if (model == null)
        {
            model = new OfferInfoModel();
        }
        if (tbl != null)
        {
            model.Id = tbl.Id;
            model.Name = tbl.Name;
            model.Description = tbl.Description;
            model.Active = tbl.Active;
            model.StartDate = tbl.StartDate;
            model.EndDate = tbl.EndDate;
        }
        return model;
    }


    #endregion
}
