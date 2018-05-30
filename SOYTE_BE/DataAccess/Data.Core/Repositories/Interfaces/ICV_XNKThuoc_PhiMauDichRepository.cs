using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICV_XNKThuoc_PhiMauDichRepository : IRepository<CV_XNKThuoc_PhiMauDich>
    {
        CV_XNKThuoc_PhiMauDich NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(long HoSoID);
        CV_XNKThuoc_PhiMauDich NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(long XNKThuocPhiMauDichId);
        IEnumerable<CV_XNKThuoc_PhiMauDichViewModel> NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(string SoCongVan, DateTime? tuNgay, DateTime? denNgay
            , string HoTenNguoiNhanThuoc, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_CV_XNKThuoc_PhiMauDich_Ins(CV_XNKThuoc_PhiMauDich model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdByID(CV_XNKThuoc_PhiMauDich model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(long HoSoID, long XNKThuocPhiMauDichId, IDbConnection conns, IDbTransaction trans);
    }
}
