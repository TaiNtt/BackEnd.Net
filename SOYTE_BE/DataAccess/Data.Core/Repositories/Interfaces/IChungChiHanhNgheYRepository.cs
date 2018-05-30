using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheYRepository : IRepository<ChungChiHanhNgheY>
    {
        ChungChiHanhNgheY NganhY_ChungChiHanhNgheY_GetByID(long ChungChiHanhNgheYId);

        ChungChiHanhNgheY NganhY_ChungChiHanhNgheY_GetByHoSoID(long HoSoId);

        ChungChiHanhNgheY NganhY_ChungChiHanhNgheY_GetBySoChungChi(string SoChungChi);

        IEnumerable<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Search(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize, out int totalItems);

        IEnumerable<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Lst(string SoChungChi, DateTime? tuNgay,
            DateTime? denNgay
            , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize, out int totalItems);

        long NganhY_ChungChiHanhNgheY_Ins(ChungChiHanhNgheY model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_UpdByCCHNYID(ChungChiHanhNgheY model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_UpdDaCapByCCHNYID(long ChungChiHanhNgheYID, int TrangThaiGiayPhepID, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool CheckExistSoChungChi(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName,
            string keyCheckName);

    }
}
