using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICN_GDPRepository : IRepository<CN_GDP>
    {
        CN_GDP NganhDuoc_CN_GDP_GetByHoSoID(long HoSoID);
        CN_GDP NganhDuoc_CN_GDP_GetByID(long THTGDPId);
        IEnumerable<CN_GDPViewModel> NganhDuoc_CN_GDP_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_CN_GDP_Ins(CN_GDP model, IDbConnection conns, IDbTransaction trans);
        long NganhDuoc_CN_GDP_UpdByID(CN_GDP model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GDP_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GDP_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GDP_DelByTHTGDPID(long THTGDPID, IDbConnection conns, IDbTransaction trans);
        DataTableViewModel NganhDuoc_CN_GDP_InDeXuat(long Id);
        DataTableViewModel NganhDuoc_CN_GDP_InChungChi(long Id);
        DataTableViewModel NganhDuoc_CN_GDP_XuatDanhSach(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
        , string TenCoSo, string SoDKKD);
        DataTableViewModel NganhDuoc_CN_GDP_CongBoWebsite(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
        , string TenCoSo, string SoDKKD);
    }
}
