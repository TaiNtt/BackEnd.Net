using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICN_LuuHanhMyPham_SanPhamRepository : IRepository<CN_LuuHanhMyPham_SanPham>
    {
        IEnumerable<CN_LuuHanhMyPham_SanPham> NganhDuoc_CN_LuuHanhMyPham_SanPham_GetByLuuHanhMyPhamId(long LuuHanhMyPhamId);
        bool NganhDuoc_CN_LuuHanhMyPham_SanPham_Ins(List<CN_LuuHanhMyPham_SanPham> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_LuuHanhMyPham_SanPham_DelLuuHanhMyPhamId(long LuuHanhMyPhamId, IDbConnection conns, IDbTransaction trans);
    }
}
