using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Services.Employees;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Model;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class EmployeeController : BaseAdminController
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeModelFactory _employeeModelFactory;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeService employeeService, 
            IEmployeeModelFactory employeeModelFactory,
         INotificationService notificationService, 
         ILocalizationService localizationService)
        {
            _employeeService = employeeService;
            _employeeModelFactory = employeeModelFactory;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var model = _employeeModelFactory.PrepareEmployeeSearchModelAsync(new EmployeeSearchModel());
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(EmployeeSearchModel searchModel)
        {
            //prepare model here...
            
            var model = await _employeeModelFactory.PrepareEmployeeListModelAsync(searchModel);
            return Json(model);
        }


        #region Create/ Edit/ Delete
        [HttpGet]
        public virtual async Task<IActionResult> Create()
        {
            //Prepare model
            var model = await _employeeModelFactory.PrepareEmployeeModelAsync(new EmployeeModel(), null);
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = employeeModel.Name,
                    Designation = employeeModel.Designation,
                    PhoneNo = employeeModel.PhoneNo,
                    CountryId= employeeModel.CountryId,
                    StateId= employeeModel.StateId,
                    CityId = employeeModel.CityId
                };
                await _employeeService.InsertEmployeeAsync(employee);
            }
            return RedirectToAction("List");
        }


        [HttpGet]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get a employee with the specified id
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return RedirectToAction("List");

            //Prepare model
            var model = await _employeeModelFactory.PrepareEmployeeModelAsync(null, employee);
            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("Save_Continue", "ContinueEdit")]
        public virtual async Task<IActionResult> Edit(EmployeeModel model, bool continueEditing)
        {
            //try to get a employee with the specified id
            var employee = await _employeeService.GetEmployeeByIdAsync(model.Id);
            if (employee == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                employee.Name = model.Name;
                employee.Designation = model.Designation;
                employee.PhoneNo = model.PhoneNo;
                employee.CountryId = model.CountryId;
                employee.StateId = model.StateId;
                employee.CityId = model.CityId;

                await _employeeService.UpdateEmployeeAsync(employee);

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = employee.Id });
            }

            //prepare model
            model = await _employeeModelFactory.PrepareEmployeeModelAsync (model, employee);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Deleted(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return RedirectToAction("List");
            }
            await _employeeService.DeleteEmployeeAsync(employee);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Employees.Deleted"));
            return new NullJsonResult();
        }


        /// <summary>
        /// when click on Edit button that time delete data on edit page.....
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync (id);
            if(employee == null)
            {
                return RedirectToAction("List");
            }
            await _employeeService.DeleteEmployeeAsync (employee);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Employees.Deleted"));

            return RedirectToAction("List");
        }
        #endregion
    }
}
#endregion