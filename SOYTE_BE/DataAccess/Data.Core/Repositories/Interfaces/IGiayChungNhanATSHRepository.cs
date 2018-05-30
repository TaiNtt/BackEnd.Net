using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanATSHRepository : IRepository<GiayChungNhanATSH>
    {
        GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetByHoSoID(long HoSoId);
        GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetByID(long GiayChungNhanATSHID);
        GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(string SoGiayChungNhan);
        IEnumerable<GiayChungNhanATSHViewModel> NganhY_GiayChungNhanATSH_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCoSo, string TenPhongXetNghiem, long? HuyenID, int pageIndex, int pageSize, out int totalItems);
        long NganhY_GiayChungNhanATSH_Ins(GiayChungNhanATSH model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_UpdByID(GiayChungNhanATSH model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_DelByHoSoID(long HoSoID, long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans);

        bool CheckExistSoGiayChungNhanATSH(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName,
            string keyCheckName);
    }
}
