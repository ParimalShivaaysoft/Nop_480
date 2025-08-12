using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Employees
{
   public partial interface IEmployeeService
    {
        /// <summary>
        /// Get all stored data in list
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        Task<IPagedList<Employee>>GetAllEmployeeAsync(int pageIndex = 0, int pagesize = int.MaxValue);


        /// <summary>
        /// Insert data in table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task InsertEmployeeAsync(Employee employee);



        /// <summary>
        /// Update table data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateEmployeeAsync(Employee employee);



        /// <summary>
        /// Delete emp data 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(Employee employee);


        /// <summary>
        /// Get particular emp id data  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeByIdAsync(int id);

    }
}
