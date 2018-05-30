using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongChuThapDo_CapLaiRepository : IRepository<GiayPhepHoatDongChuThapDo_CapLai>
    {
        GiayPhepHoatDongChuThapDo_CapLai NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(long HoSoId);
        GiayPhepHoatDongChuThapDo_CapLai NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);
        long NganhY_GiayPhepHoatDongChuThapDo_CapLai_Ins(GiayPhepHoatDongChuThapDo_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_Upd(GiayPhepHoatDongChuThapDo_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID(long HoSoID, long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
