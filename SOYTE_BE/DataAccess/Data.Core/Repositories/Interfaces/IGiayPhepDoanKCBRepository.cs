using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepDoanKCBRepository : IRepository<GiayPhepDoanKCB>
    {
        GiayPhepDoanKCB NganhY_GiayPhepDoanKCB_GetByHoSoID(long HoSoID);
        GiayPhepDoanKCB NganhY_GiayPhepDoanKCB_GetByID(long GiayPhepDoanKCBID);
        IEnumerable<GiayPhepDoanKCBViewModel> NganhY_GiayPhepDoanKCB_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string TenDoanKCB, DateTime? tuNgayKCB, DateTime? denNgayKCB, long? NoiKCB_HuyenID, long? NoiKCB_XaID, int pageIndex, int pageSize, out int totalItems);
        long NganhY_GiayPhepDoanKCB_Ins(GiayPhepDoanKCB model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepDoanKCB_UpdByID(GiayPhepDoanKCB model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepDoanKCB_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepDoanKCB_DelByHoSoID(long HoSoID, long GiayPhepDoanKCBID, IDbConnection conns, IDbTransaction trans);
    }
}
