using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface ICC_Duoc_TDCMRepository : IRepository<CC_Duoc_TDCM>
    {
        //Test
        IEnumerable<CC_Duoc_TDCM> NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(long ChungChiDuocID);

        bool NganhDuoc_CC_Duoc_TDCM_Ins(List<CC_Duoc_TDCM> model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_TDCM_DelByChungChiDuocID(long ChungChiDuocID, IDbConnection conns, IDbTransaction trans);
    }
}
