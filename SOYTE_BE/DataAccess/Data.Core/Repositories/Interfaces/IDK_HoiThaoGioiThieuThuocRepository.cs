using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IDK_HoiThaoGioiThieuThuocRepository : IRepository<DK_HoiThaoGioiThieuThuoc>
    {
        DK_HoiThaoGioiThieuThuoc NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(long HoSoID);
        DK_HoiThaoGioiThieuThuoc NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(long HoiThaoThuocID);
        IEnumerable<DK_HoiThaoGioiThieuThuocViewModel> NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, string HoTen, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_DK_HoiThaoGioiThieuThuoc_Ins(DK_HoiThaoGioiThieuThuoc model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdByID(DK_HoiThaoGioiThieuThuoc model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(long HoSoID, long HoiThaoThuocID, IDbConnection conns, IDbTransaction trans);
    }
}
