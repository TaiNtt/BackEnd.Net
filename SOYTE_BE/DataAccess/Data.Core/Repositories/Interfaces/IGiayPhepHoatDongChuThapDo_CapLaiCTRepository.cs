using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongChuThapDo_CapLaiCTRepository : IRepository<GiayPhepHoatDongChuThapDo_CapLaiCT>
    {
        GiayPhepHoatDongChuThapDo_CapLaiCT NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(long CapLaiID);
        GiayPhepHoatDongChuThapDo_CapLaiCT NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Ins(GiayPhepHoatDongChuThapDo_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Upd(GiayPhepHoatDongChuThapDo_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
