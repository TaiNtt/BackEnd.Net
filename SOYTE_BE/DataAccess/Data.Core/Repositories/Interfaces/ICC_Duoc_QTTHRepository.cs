using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface ICC_Duoc_QTTHRepository : IRepository<CC_Duoc_QTTH>
    {
        IEnumerable<CC_Duoc_QTTH> NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(long ChungChiDuocID);

        bool NganhDuoc_CC_Duoc_QTTH_Ins(List<CC_Duoc_QTTH> lstmodel, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_QTTH_DelByChungChiDuocID(long ChungChiDuocID, IDbConnection conns, IDbTransaction trans);
    }
}
