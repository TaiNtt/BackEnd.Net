using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanLuongYRepository : IRepository<GiayChungNhanLuongY>
    {
        GiayChungNhanLuongY NganhY_GiayChungNhanLuongY_GetByHoSoID(long HoSoID);

        GiayChungNhanLuongY NganhY_GiayChungNhanLuongY_GetByID(long GiayChungNhanLuongYID);

        IEnumerable<GiayChungNhanLuongYViewModel> NganhY_GiayChungNhanLuongY_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string SoGiayTo, int pageIndex, int pageSize, out int totalItems);

        long NganhY_GiayChungNhanLuongY_Ins(GiayChungNhanLuongY model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayChungNhanLuongY_UpdByID(GiayChungNhanLuongY model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayChungNhanLuongY_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayChungNhanLuongY_DelByHoSoID(long HoSoID, long GiayChungNhanLuongYID, IDbConnection conns, IDbTransaction trans);

        bool CheckExistSoChungNhanLuongY(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName,
            string keyCheckName);
    }
}
