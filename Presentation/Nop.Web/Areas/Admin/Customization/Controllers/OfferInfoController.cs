using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.OfferInfo;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Model;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class OfferInfoController :  BaseAdminController
    {
        #region fields
        private readonly IOfferInfoService _offerInfoservice;
        private readonly IOfferInfoModelFactory _offerInfoModelFactory;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        #endregion

        #region Ctor
        public OfferInfoController(IOfferInfoService offerInfoService,
            IOfferInfoModelFactory offerInfoModelFactory,
          ILocalizationService localizationService,
          INotificationService notificationService)
        {
            _offerInfoservice = offerInfoService;
            _offerInfoModelFactory = offerInfoModelFactory;
            _localizationService = localizationService;
            _notificationService = notificationService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var model = _offerInfoModelFactory.PrepareOfferSearchInfoModelAsync(new OfferInfoSearchModel());
            //var tbl = await_offerInfoservice.GetAllOfferInfosAsync();

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(OfferInfoSearchModel search)
        {
            search.Draw = "1";
            //prepare model
            var abc = await _offerInfoModelFactory.PrepareOfferListModelAsync(search);
            return Json(abc);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Create()
        {
            var model = _offerInfoModelFactory.PrepareOfferInfoModel(new OfferInfoModel(), null);
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(OfferInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var tbl = new Core.Domain.Catalog.OfferInfoTable()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Active = model.Active,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };
                await _offerInfoservice.InsertOfferAsync(tbl);
            }

            model = _offerInfoModelFactory.PrepareOfferInfoModel(model, null);
            return RedirectToAction("List");

        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit1(int id)
        {
            var offer = await _offerInfoservice.GetOfferByIdAsync(id);
            if (offer == null)
                return RedirectToAction("List");

            //prepare model
            var model = _offerInfoModelFactory.PrepareOfferInfoModel(null, offer);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("Save-Continue", "ContinueEdit")]
        public virtual async Task<IActionResult> Edit1(OfferInfoModel offerInfoModel, bool continueEditing)
        {
            var tbl = await _offerInfoservice.GetOfferByIdAsync(offerInfoModel.Id);
            if (tbl == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                tbl.Name = offerInfoModel.Name;
                tbl.Description = offerInfoModel.Description;
                tbl.Active = offerInfoModel.Active;
                tbl.StartDate = offerInfoModel.StartDate;
                tbl.EndDate = offerInfoModel.EndDate;
                await _offerInfoservice.UpdateOfferAsync(tbl);
            }
            await _offerInfoservice.UpdateOfferAsync(tbl);

            if (!continueEditing)
                return RedirectToAction("List");

            return RedirectToAction("Edit", new { id = tbl.Id });

        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var model = await _offerInfoservice.GetOfferByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("List");
            }
            await _offerInfoservice.DeleteOfferAsync(model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.OfferInfos.Deleted"));

            return RedirectToAction("List");
        }


        #endregion
    }
}
