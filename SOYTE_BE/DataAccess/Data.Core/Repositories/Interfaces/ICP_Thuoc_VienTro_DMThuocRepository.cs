using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICP_Thuoc_VienTro_DMThuocRepository : IRepository<CP_Thuoc_VienTro_DMThuoc>
    {
        IEnumerable<CP_Thuoc_VienTro_DMThuoc> NganhDuoc_CP_Thuoc_VienTro_DMThuoc_GetByThuocVienTroId(long ThuocVienTroId);
        bool NganhDuoc_CP_Thuoc_VienTro_DMThuoc_Ins(List<CP_Thuoc_VienTro_DMThuoc> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CP_Thuoc_VienTro_DMThuoc_DelThuocVienTroId(long ThuocVienTroId, IDbConnection conns, IDbTransaction trans);
    }
}
