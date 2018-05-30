using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICN_LuuHanhMyPhamRepository : IRepository<CN_LuuHanhMyPham>
    {
        CN_LuuHanhMyPham NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(long HoSoID);
        CN_LuuHanhMyPham NganhDuoc_CN_LuuHanhMyPham_GetByID(long LuuHanhMyPhamId);
        IEnumerable<CN_LuuHanhMyPhamViewModel> NganhDuoc_CN_LuuHanhMyPham_Search(string SoChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCongTy, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_CN_LuuHanhMyPham_Ins(CN_LuuHanhMyPham model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_LuuHanhMyPham_UpdByID(CN_LuuHanhMyPham model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(long HoSoID, long LuuHanhMyPhamId, IDbConnection conns, IDbTransaction trans);
    }
}
