using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IXN_NoiDungQuangCao_SanPhamRepository : IRepository<XN_NoiDungQuangCao_SanPham>
    {
        IEnumerable<XN_NoiDungQuangCao_SanPham> NganhDuoc_XN_NoiDungQuangCao_SanPham_GetByNoiDungQCId(long NoiDungQCId);
        bool NganhDuoc_XN_NoiDungQuangCao_SanPham_Ins(List<XN_NoiDungQuangCao_SanPham> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_XN_NoiDungQuangCao_SanPham_DelByNoiDungQCId(long NoiDungQCId, IDbConnection conns, IDbTransaction trans);
    }
}
