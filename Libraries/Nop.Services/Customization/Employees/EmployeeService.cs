using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Data;

namespace Nop.Services.Employees
{
    public partial class EmployeeService : IEmployeeService
    {
        #region Fields

        private readonly IRepository<Employee> _employeeRepository;

        #endregion


        #region ctor

        public EmployeeService(IRepository<Employee> repository)
        {
            _employeeRepository = repository;
        }

        #endregion


        #region method

        public async Task<IPagedList<Employee>> GetAllEmployeeAsync(int pageIndex = 0, int pagesize = int.MaxValue)
        {
            var category = await _employeeRepository.GetAllAsync(query =>
            {
                return query;
            });
            return new PagedList<Employee>(category, pageIndex, pagesize);
        }

        public async Task InsertEmployeeAsync(Employee employee)
        {
            await _employeeRepository.InsertAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        #endregion
    }
}
