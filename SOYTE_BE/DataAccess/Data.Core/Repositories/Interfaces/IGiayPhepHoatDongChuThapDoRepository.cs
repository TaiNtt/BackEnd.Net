using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongChuThapDoRepository : IRepository<GiayPhepHoatDongChuThapDo>
    {
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(long HoSoID);
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByID(long GiayPhepHoatDongChuThapDoID);
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(string SoGiayPhep);
        IEnumerable<GiayPhepHoatDongChuThapDoViewModel> NganhY_GiayPhepHoatDongChuThapDo_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string TenDiem, int pageIndex, int pageSize, out int totalItems);
        long NganhY_GiayPhepHoatDongChuThapDo_Ins(GiayPhepHoatDongChuThapDo model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_UpdByID(GiayPhepHoatDongChuThapDo model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
    }
}
