using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.OfferInfo
{
    public partial interface IOfferInfoService
    {
        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        Task<IPagedList<OfferInfoTable>> GetAllOfferInfosAsync(int pageIndex=0, int pagesize=int.MaxValue);


        /// <summary>
        /// Insert data in table
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task InsertOfferAsync(OfferInfoTable info);

        /// <summary>
        /// Update data in table
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task UpdateOfferAsync(OfferInfoTable info);

        /// <summary>
        /// Delete paritucular id data
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task DeleteOfferAsync(OfferInfoTable info);

        /// <summary>
        /// Get by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OfferInfoTable> GetOfferByIdAsync(int id);
      
    }
}
