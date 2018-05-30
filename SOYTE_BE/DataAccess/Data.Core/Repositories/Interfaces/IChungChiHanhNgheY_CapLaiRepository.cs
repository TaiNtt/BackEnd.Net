using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_CapLaiRepository : IRepository<ChungChiHanhNgheY_CapLai>
    {
        ChungChiHanhNgheY_CapLai NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_CapLai NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(long HoSoId);

        long NganhY_ChungChiHanhNgheY_CapLai_Ins(ChungChiHanhNgheY_CapLai model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_CapLai_Upd(ChungChiHanhNgheY_CapLai model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
    }
}
