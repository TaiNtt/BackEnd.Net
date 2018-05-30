using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IDangKyQCTrangThietBiRepository : IRepository<DangKyQCTrangThietBi>
    {
        DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByHoSoID(long HoSoId);

        DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByID(long DangKyQCTrangThietBiID);

        IEnumerable<DangKyQCTrangThietBiViewModel> NganhY_DangKyQCTrangThietBi_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string DichVuQuangCao, string DonViDK_Ten, int pageIndex, int pageSize, out int totalItems);

        long NganhY_DangKyQCTrangThietBi_Ins(DangKyQCTrangThietBi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_DangKyQCTrangThietBi_UpdByID(DangKyQCTrangThietBi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_DangKyQCTrangThietBi_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_DangKyQCTrangThietBi_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool CheckExistSoTiepNhanDangKyQuangCaoNganhY(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName,
            string keyCheckName);
    }
}
