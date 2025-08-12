using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Directory;

namespace Nop.Services.City
{
    public partial interface ICityService
    {
        Task<IList<Cities>> GetAllCityAsync();

        Task <Cities>GetByCityIdAsync(int CityId);


    }
}