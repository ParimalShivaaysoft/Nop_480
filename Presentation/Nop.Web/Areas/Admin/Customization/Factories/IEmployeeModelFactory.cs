using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Web.Areas.Admin.Model;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial interface IEmployeeModelFactory
    {
        EmployeeSearchModel PrepareEmployeeSearchModelAsync(EmployeeSearchModel employeeSearchModel);
  
        Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel employeeSearchModel);

        Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee);

    }
}
