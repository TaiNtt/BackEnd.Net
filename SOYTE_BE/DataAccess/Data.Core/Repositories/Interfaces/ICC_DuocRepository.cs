using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICC_DuocRepository : IRepository<CC_Duoc>
    {
        CC_Duoc NganhDuoc_CC_Duoc_GetByID(long ChungChiDuocID);

        CC_Duoc NganhDuoc_CC_Duoc_GetByHoSoID(long HoSoId);

        CC_Duoc NganhDuoc_CC_Duoc_GetBySoChungChi(string SoChungChi);

        IEnumerable<CC_DuocViewModel> NganhDuoc_CC_Duoc_Search(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize, out int totalItems);

        IEnumerable<CC_DuocViewModel> NganhDuoc_CC_Duoc_Lst(string SoChungChi, DateTime? tuNgay,
            DateTime? denNgay
            , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize, out int totalItems);

        long NganhDuoc_CC_Duoc_Ins(CC_Duoc model, IDbConnection conns, IDbTransaction trans);

        long NganhDuoc_CC_Duoc_UpdByChungChiDuocID(CC_Duoc model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_UpdDaCapByChungChiDuocID(long ChungChiDuocID, int TrangThaiGiayPhepID, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool CheckExistSoChungChi(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName,
            string keyCheckName);
        bool NganhDuoc_CC_Duoc_DelByChungChiDuocId(long ChungChiDuocId, IDbConnection conns, IDbTransaction trans);
        DataTableViewModel NganhDuoc_CC_Duoc_InDeXuat(long Id);
        DataTableViewModel NganhDuoc_CC_Duoc_InChungChi(long Id);
        DataTableViewModel NganhDuoc_CC_Duoc_XuatDanhSach(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
       , string HoTen, string SoGiayTo, string TrangThai);
        DataTableViewModel NganhDuoc_CC_Duoc_CongBoWebsite(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
        , string HoTen, string SoGiayTo, string TrangThai);

    }
}
