using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_CapLaiCTRepository : IRepository<ChungChiHanhNgheY_CapLaiCT>
    {
        ChungChiHanhNgheY_CapLaiCT NganhY_ChungChiHanhNgheY_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_CapLaiCT NganhY_ChungChiHanhNgheY_CapLaiCT_GetByCapLaiID(long CapLaiID);

        bool NganhY_ChungChiHanhNgheY_CapLaiCT_Ins(ChungChiHanhNgheY_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_CapLaiCT_Upd(ChungChiHanhNgheY_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
