using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepHoatDongKCB_DSNhanSuRepository : IRepository<GiayPhepHoatDongKCB_DSNhanSu>
    {
        IEnumerable<GiayPhepHoatDongKCB_DSNhanSu> NganhY_GiayPhepHoatDongKCB_DSNhanSu_GetByGPID(long ChungChiHanhNgheYId);
        bool NganhY_GiayPhepHoatDongKCB_DSNhanSu_Ins(List<GiayPhepHoatDongKCB_DSNhanSu> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepHoatDongKCB_DSNhanSu_DelByGPID(long GiayPhepKhamChuaBenhID, IDbConnection conns, IDbTransaction trans);
    }
}
