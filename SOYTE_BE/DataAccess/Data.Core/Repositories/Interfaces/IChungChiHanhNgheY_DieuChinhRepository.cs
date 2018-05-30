using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_DieuChinhRepository : IRepository<ChungChiHanhNgheY_DieuChinh>
    {
        long NganhY_ChungChiHanhNgheY_DieuChinh_Ins(ChungChiHanhNgheY_DieuChinh model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_DieuChinh_Upd(ChungChiHanhNgheY_DieuChinh model, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_DieuChinh NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(long HoSoID, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_DieuChinh NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoId);

        bool NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
    }
}
