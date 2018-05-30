using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IPD_Thuoc_MethadoneRepository : IRepository<PD_Thuoc_Methadone>
    {
        PD_Thuoc_Methadone NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(long HoSoID);
        PD_Thuoc_Methadone NganhDuoc_PD_Thuoc_Methadone_GetByID(long PDMethadoneId);
        IEnumerable<PD_Thuoc_MethadoneViewModel> NganhDuoc_PD_Thuoc_Methadone_Search(string SoPheDuyet, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_PD_Thuoc_Methadone_Ins(PD_Thuoc_Methadone model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_Methadone_UpdByID(PD_Thuoc_Methadone model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(long HoSoID, long PDMethadoneId, IDbConnection conns, IDbTransaction trans);
    }
}
