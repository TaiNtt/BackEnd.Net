using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanBTGT_CapLaiCTRepository : IRepository<GiayChungNhanBTGT_CapLaiCT>
    {
        GiayChungNhanBTGT_CapLaiCT NganhY_GiayChungNhanBTGT_CapLaiCT_GetByCapLaiID(long CapLaiID);
        GiayChungNhanBTGT_CapLaiCT NganhY_GiayChungNhanBTGT_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLaiCT_Ins(GiayChungNhanBTGT_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLaiCT_Upd(GiayChungNhanBTGT_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
