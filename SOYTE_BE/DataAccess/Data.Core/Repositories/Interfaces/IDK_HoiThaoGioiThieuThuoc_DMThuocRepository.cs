using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IDK_HoiThaoGioiThieuThuoc_DMThuocRepository : IRepository<DK_HoiThaoGioiThieuThuoc_DMThuoc>
    {
        IEnumerable<DK_HoiThaoGioiThieuThuoc_DMThuoc> NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_GetByHoiThaoThuocID(long HoiThaoThuocID);
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_Ins(List<DK_HoiThaoGioiThieuThuoc_DMThuoc> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DMThuoc_DelByHoiThaoThuocID(long HoiThaoThuocID, IDbConnection conns, IDbTransaction trans);
    }
}
