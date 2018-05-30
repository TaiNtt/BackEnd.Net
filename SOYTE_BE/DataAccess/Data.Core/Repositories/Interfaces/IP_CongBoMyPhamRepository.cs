using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IP_CongBoMyPhamRepository : IRepository<P_CongBoMyPham>
    {
        P_CongBoMyPham NganhDuoc_P_CongBoMyPham_GetByHoSoID(long HoSoID);
        P_CongBoMyPham NganhDuoc_P_CongBoMyPham_GetByID(long CongBoSPMyPhamId);
        IEnumerable<P_CongBoMyPhamViewModel> NganhDuoc_P_CongBoMyPham_Search(string SoCongBo, int? ThoiHanTu, int? ThoiHanDen
             , string NhanHang, string TenSanPham, string TenNhaSanXuat, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_P_CongBoMyPham_Ins(P_CongBoMyPham model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_P_CongBoMyPham_UpdByID(P_CongBoMyPham model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_P_CongBoMyPham_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_P_CongBoMyPham_DelByHoSoID(long HoSoID, long CongBoSPMyPhamId, IDbConnection conns, IDbTransaction trans);
    }
}
