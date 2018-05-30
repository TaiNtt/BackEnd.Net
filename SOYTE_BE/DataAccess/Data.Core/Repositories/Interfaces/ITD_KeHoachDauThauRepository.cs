using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ITD_KeHoachDauThauRepository : IRepository<TD_KeHoachDauThau>
    {
        TD_KeHoachDauThau NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(long HoSoID);
        TD_KeHoachDauThau NganhDuoc_TD_KeHoachDauThau_GetByID(long KeHoachDauThauId);
        IEnumerable<TD_KeHoachDauThauViewModel> NganhDuoc_TD_KeHoachDauThau_Search(string SoQuyetDinh, DateTime? tuNgay, DateTime? denNgay
            , string ChuDauTu, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_TD_KeHoachDauThau_Ins(TD_KeHoachDauThau model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_TD_KeHoachDauThau_UpdByID(TD_KeHoachDauThau model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_TD_KeHoachDauThau_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(long HoSoID, long KeHoachDauThauId, IDbConnection conns, IDbTransaction trans);
    }
}
