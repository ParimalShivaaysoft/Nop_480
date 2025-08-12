using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Model
{
    public partial record EmployeeModel : BaseNopEntityModel
    {
        public EmployeeModel()
        {
            //prepared dropdown list here means it can take default values that's
            //why we create in cosntructor and prepared the list here

            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableCities = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.employee.Fields.Name")]
        public string Name { get; set; }


        [NopResourceDisplayName("Admin.employee.Fields.Designation")]
        public string Designation { get; set; }


        [NopResourceDisplayName("Admin.employee.Fields.PhoneNo")]
        public string PhoneNo { get; set; }

        public string Country { get; set; }
         public string States {  get; set; }
        public string CityName { get; set; }

        //For Dropdown...
        
        [NopResourceDisplayName("Admin.employee.Fields.CountryId")]
        public int CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }

        public int StateId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        public int CityId { get; set; }
        public IList<SelectListItem> AvailableCities { get; set; }

    }
}
