using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICN_GPPRepository : IRepository<CN_GPP>
    {
        CN_GPP NganhDuoc_CN_GPP_GetByHoSoID(long HoSoID);
        CN_GPP NganhDuoc_CN_GPP_GetByID(long THTGPPId);
        IEnumerable<CN_GPPViewModel> NganhDuoc_CN_GPP_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_CN_GPP_Ins(CN_GPP model, IDbConnection conns, IDbTransaction trans);
        long NganhDuoc_CN_GPP_UpdByID(CN_GPP model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GPP_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GPP_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GPP_DelByTHTGPPID(long THTGPPID, IDbConnection conns, IDbTransaction trans);
        DataTableViewModel NganhDuoc_CN_GPP_InDeXuat(long Id);
        DataTableViewModel NganhDuoc_CN_GPP_InChungChi(long Id);
        DataTableViewModel NganhDuoc_CN_GPP_XuatDanhSach(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
        , string TenCoSo, string SoDKKD);
        DataTableViewModel NganhDuoc_CN_GPP_CongBoWebsite(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
        , string TenCoSo, string SoDKKD);
    }
}
