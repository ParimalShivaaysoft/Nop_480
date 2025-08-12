using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Services.City;
using Nop.Services.Directory;
using Nop.Services.Employees;
using Nop.Web.Areas.Admin.Model;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial class EmployeeModelFactory : IEmployeeModelFactory
    {
        #region Field

        private readonly IEmployeeService _employeeService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ICityService _cityService;

        #endregion Ctor

        #region Ctor

        public EmployeeModelFactory(IEmployeeService employeeService, 
            ICountryService countryService, 
            IStateProvinceService stateProvinceService, 
            ICityService cityService)
        {
            _employeeService = employeeService;
            _countryService = countryService;
            _stateProvinceService = stateProvinceService;
            _cityService = cityService;
        }

        #endregion

        #region Utilies
        protected virtual void  PrepareDefaultItem(IList<SelectListItem> items, bool withSpecialDefaultItem, string defaultItemText = null, string defaultItemValue = "0")
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            //whether to insert the first special item for the default value
            if (!withSpecialDefaultItem)
                return;

            //prepare item text
            //defaultItemText ??= await _localizationService.GetResourceAsync("Admin.Common.All");

            //insert this default item at first
            items.Insert(0, new SelectListItem { Text = defaultItemText, Value = defaultItemValue });
        }
        #endregion

        //FormatException country dropdown we prepared dropdown here
        //Country
        #region State dropdown prpared

        public virtual async Task PrepareCountryAsync(IList<SelectListItem> CountryItems)
        {
            if (CountryItems == null)
                throw new ArgumentNullException(nameof(CountryItems));

            //prepare available stores
            var countries = await _countryService.GetAllCountriesAsync();
            foreach (var country in countries)
            {
                CountryItems.Add(new SelectListItem { Value = country.Id.ToString(), Text = country.Name });
            }
        }
        
        //State dropdown prpared
        public virtual async Task PrepareStateAsync(IList<SelectListItem> StateItems)
        {
            if (StateItems == null)
                throw new ArgumentNullException(nameof(StateItems));

            //prepare available states
            var states = await _stateProvinceService.GetStateProvincesAsync();
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem { Value = state.Id.ToString(), Text = state.Name });
            }
        }

       //City Dropdown prepared 
        public virtual async Task PrepareCityAsync(IList<SelectListItem> CityItems)
        {
            if (CityItems == null)
                throw new ArgumentNullException(nameof(CityItems));

            //prepare available Cities
            var cities = await _cityService.GetAllCityAsync();
            foreach(var city in cities)
            {
                CityItems.Add(new SelectListItem { Value= city.Id.ToString(), Text = city.Name });
            }
        }
        #endregion


        #region Methods

        //EmpSearchModel(Grid will be displayed)
        public EmployeeSearchModel PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new System.ArgumentNullException(nameof(searchModel));

            searchModel.SetGridPageSize();
            return searchModel;
        }

        ///Models EmpSerch model, list model, emp model
        ///EmpListModel
        /// <summary>
        /// Search model filter data come to the emp list model and return list- emp list model
        /// in this grid data will be prepared from "PrepareEmployeeListModelAsync" in this method
        /// </summary>
        /// <param name="SearchModel"></param>
        /// <returns></returns>
        public virtual async Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(EmployeeSearchModel));

            //Get empmodel
            var list = await _employeeService.GetAllEmployeeAsync();
            var model = await new EmployeeListModel().PrepareToGridAsync(searchModel, list, () =>
            {
                return list.SelectAwait(async x =>
                {
                    var listmodel = new EmployeeModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Designation = x.Designation,
                        PhoneNo = x.PhoneNo,
                        //using ThisExpressionSyntax id save in db and country name shown UI
                        Country = (await _countryService.GetCountryByIdAsync(x.CountryId))?.Name,
                        States = (await _stateProvinceService.GetStateProvinceByIdAsync(x.StateId))?.Name,
                        CityName= (await _cityService.GetByCityIdAsync(x.CityId))?.Name,
                  };
                    return listmodel;
                });
            });
            return model;
        }

        
        //Country/ city/ state prepared here...
        public async Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee)
        {
            //set default values for the new model, if tbl has not data or null that time it create new model
            if (model == null)
            {
                model = new EmployeeModel();
            }

            if (employee != null)
            {
                model.Id = employee.Id;
                model.Name = employee.Name;
                model.Designation = employee.Designation;
                model.PhoneNo = employee.PhoneNo;
                model.CountryId = employee.CountryId;
                model.StateId = employee.StateId;
                model.CityId = employee.CityId;
            }
            await PrepareCountryAsync(model.AvailableCountries);
            await PrepareStateAsync(model.AvailableStates);
            await PrepareCityAsync(model.AvailableCities);

            return model;
        }
        #endregion
    }
}
