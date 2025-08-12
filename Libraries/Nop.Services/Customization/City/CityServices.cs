using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Directory;

namespace Nop.Services.City
{
    public partial class CityServices : ICityService
    {

        #region Fields

        private readonly IRepository<Cities> _repository;
        private readonly IStoreContext _storeContext;


        #endregion

        #region ctor


        public CityServices(IRepository<Cities> repository)
        {
            _repository = repository;
        }

        #endregion

        #region methods

        public virtual async Task<IList<Cities>> GetAllCityAsync()
        {
            var city = await _repository.GetAllAsync(query =>
            {
                return query;
            });
            return city; 
        }

        public async Task<Cities> GetByCityIdAsync(int CityId)
        {
            return await _repository.GetByIdAsync(CityId);
        }

        #endregion
    }
}
