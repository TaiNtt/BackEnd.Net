using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IPD_Thuoc_GN_HTT_DSThuocRepository : IRepository<PD_Thuoc_GN_HTT_DSThuoc>
    {
        IEnumerable<PD_Thuoc_GN_HTT_DSThuoc> NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_GetByPDThuocGNHTTId(long PDThuocGNHTTId);
        bool NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_Ins(List<PD_Thuoc_GN_HTT_DSThuoc> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_DelByPDThuocGNHTTId(long PDThuocGNHTTId, IDbConnection conns, IDbTransaction trans);
    }
}
