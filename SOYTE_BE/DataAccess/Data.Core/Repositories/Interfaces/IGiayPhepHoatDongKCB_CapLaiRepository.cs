using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongKCB_CapLaiRepository : IRepository<GiayPhepHoatDongKCB_CapLai>
    {
        GiayPhepHoatDongKCB_CapLai NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(long HoSoId);
        GiayPhepHoatDongKCB_CapLai NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);
        long NganhY_GiayPhepHoatDongKCB_CapLai_Ins(GiayPhepHoatDongKCB_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_CapLai_Upd(GiayPhepHoatDongKCB_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID(long HoSoID, long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
