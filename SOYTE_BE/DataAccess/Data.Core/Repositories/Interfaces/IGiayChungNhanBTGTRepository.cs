using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanBTGTRepository : IRepository<GiayChungNhanBTGT>
    {
        GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetByHoSoID(long HoSoID);
        GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetByID(long GiayChungNhanBTGTID);
        GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(string SoGiayChungNhan);
        IEnumerable<GiayChungNhanBTGTViewModel> NganhY_GiayChungNhanBTGT_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string TenBaiThuoc, int pageIndex, int pageSize, out int totalItems);
        long NganhY_GiayChungNhanBTGT_Ins(GiayChungNhanBTGT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_UpdByID(GiayChungNhanBTGT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_DelByHoSoID(long HoSoID, long GiayChungNhanBTGTID, IDbConnection conns, IDbTransaction trans);
    }
}
