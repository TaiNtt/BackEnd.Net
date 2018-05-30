using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongKCBRepository : IRepository<GiayPhepHoatDongKCB>
    {
        GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetByHoSoID(long HoSoID);
        GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetByID(long GiayPhepKhamChuaBenhID);
        GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(string SoGiayPhep);
        IEnumerable<GiayPhepHoatDongKCBViewModel> NganhY_GiayPhepHoatDongKCB_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string CoSoDK_Ten, long? CoSoDK_HuyenID, long? CoSoDK_XaID, int pageIndex, int pageSize, out int totalItems);
        long NganhY_GiayPhepHoatDongKCB_Ins(GiayPhepHoatDongKCB model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_UpdByID(GiayPhepHoatDongKCB model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_DelByHoSoID(long HoSoID, long GiayPhepKhamChuaBenhID, IDbConnection conns, IDbTransaction trans);
    }
}
