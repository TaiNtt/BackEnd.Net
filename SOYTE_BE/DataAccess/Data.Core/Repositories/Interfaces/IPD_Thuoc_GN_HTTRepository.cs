using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IPD_Thuoc_GN_HTTRepository : IRepository<PD_Thuoc_GN_HTT>
    {
        PD_Thuoc_GN_HTT NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(long HoSoID);
        PD_Thuoc_GN_HTT NganhDuoc_PD_Thuoc_GN_HTT_GetByID(long PDThuocGNHTTId);
        IEnumerable<PD_Thuoc_GN_HTTViewModel> NganhDuoc_PD_Thuoc_GN_HTT_Search(string SoPheDuyet, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, string TenCongTyCungUng, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_PD_Thuoc_GN_HTT_Ins(PD_Thuoc_GN_HTT model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_GN_HTT_UpdByID(PD_Thuoc_GN_HTT model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(long HoSoID, long PDThuocGNHTTId, IDbConnection conns, IDbTransaction trans);
    }
}
