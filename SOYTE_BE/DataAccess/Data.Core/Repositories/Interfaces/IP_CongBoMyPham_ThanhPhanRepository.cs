using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IP_CongBoMyPham_ThanhPhanRepository : IRepository<P_CongBoMyPham_ThanhPhan>
    {
        IEnumerable<P_CongBoMyPham_ThanhPhan> NganhDuoc_P_CongBoMyPham_ThanhPhan_GetByCongBoSPMyPhamId(long CongBoSPMyPhamId);
        bool NganhDuoc_P_CongBoMyPham_ThanhPhan_Ins(List<P_CongBoMyPham_ThanhPhan> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_P_CongBoMyPham_ThanhPhan_DelCongBoSPMyPhamId(long CongBoSPMyPhamId, IDbConnection conns, IDbTransaction trans);
    }
}
