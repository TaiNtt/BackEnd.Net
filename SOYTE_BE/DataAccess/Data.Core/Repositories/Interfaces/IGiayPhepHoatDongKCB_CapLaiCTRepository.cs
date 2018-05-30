using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongKCB_CapLaiCTRepository : IRepository<GiayPhepHoatDongKCB_CapLaiCT>
    {
        GiayPhepHoatDongKCB_CapLaiCT NganhY_GiayPhepHoatDongKCB_CapLaiCT_GetByCapLaiID(long CapLaiID);

        GiayPhepHoatDongKCB_CapLaiCT NganhY_GiayPhepHoatDongKCB_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayPhepHoatDongKCB_CapLaiCT_Ins(GiayPhepHoatDongKCB_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayPhepHoatDongKCB_CapLaiCT_Upd(GiayPhepHoatDongKCB_CapLaiCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayPhepHoatDongKCB_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
