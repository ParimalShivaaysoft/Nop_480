using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Data;

namespace Nop.Services.OfferInfo
{
    public partial class OfferInfoService : IOfferInfoService
    {
        #region fields
        private readonly IRepository<OfferInfoTable> _IRepo;
        #endregion

        #region ctor
        public OfferInfoService(IRepository<OfferInfoTable> offerInfo)
        {
            _IRepo = offerInfo;
        }


        #endregion

        #region methods
        /// <summary>
        /// Get all offerinfos 
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<OfferInfoTable>> GetAllOfferInfosAsync(int pageIndex = 0, int pagesize = int.MaxValue)
        {
            var offerInfos = _IRepo.GetAll(query =>
            {
                return query;
            });
            return new PagedList<OfferInfoTable>(offerInfos, pageIndex, pagesize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">Offer Info </param>
        /// <returns></returns>
        public async Task InsertOfferAsync(OfferInfoTable info)
        {
            await _IRepo.InsertAsync(info);
        }



        /// <summary>
        /// Update offer 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task UpdateOfferAsync(OfferInfoTable info)
        {
            await _IRepo.UpdateAsync(info);
        }


        /// <summary>
        ///  Getbyid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<OfferInfoTable> GetOfferByIdAsync(int id)
        {
            return _IRepo.GetByIdAsync(id);
        }

        //Delete
        public async Task DeleteOfferAsync(OfferInfoTable info)
        {
            await _IRepo.DeleteAsync(info);
        }

        #endregion

    }
}
