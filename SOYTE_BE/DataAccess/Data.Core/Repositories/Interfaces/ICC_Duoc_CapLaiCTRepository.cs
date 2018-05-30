using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface ICC_Duoc_CapLaiCTRepository : IRepository<CC_Duoc_CapLaiCT>
    {
        CC_Duoc_CapLaiCT NganhDuoc_CC_Duoc_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);

        CC_Duoc_CapLaiCT NganhDuoc_CC_Duoc_CapLaiCT_GetByCapLaiID(long CapLaiID);

        bool NganhDuoc_CC_Duoc_CapLaiCT_Ins(CC_Duoc_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_CapLaiCT_Upd(CC_Duoc_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
