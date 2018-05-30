using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICP_Thuoc_VienTroRepository : IRepository<CP_Thuoc_VienTro>
    {
        CP_Thuoc_VienTro NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(long HoSoID);
        CP_Thuoc_VienTro NganhDuoc_CP_Thuoc_VienTro_GetByID(long ThuocVienTroId);
        IEnumerable<CP_Thuoc_VienTroViewModel> NganhDuoc_CP_Thuoc_VienTro_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_CP_Thuoc_VienTro_Ins(CP_Thuoc_VienTro model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CP_Thuoc_VienTro_UpdByID(CP_Thuoc_VienTro model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(long HoSoID, long ThuocVienTroId, IDbConnection conns, IDbTransaction trans);
    }
}
