using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IQuaTrinhXuLyRepository : IRepository<QuaTrinhXuLy>
    {
        long MotCua_QuaTrinhXuLy_Ins(QuaTrinhXuLy model, IDbConnection conns, IDbTransaction trans);

        long MotCua_QuaTrinhXuLy_InsUpd(long HoSoID, int? NguoiXuLyHienTaiID, int? NguoiXuLyTiepTheoID, int? TrangThaiHienTaiID, int? TrangThaiTiepTheoID,
            IDbConnection conns, IDbTransaction trans);

        bool MotCua_QuaTrinhXuLy_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);

        IEnumerable<QuaTrinhXuLyViewModel> MotCua_QuaTrinhXuLys_GetByHoSoID(long hoSoId, IDbConnection conns);

        DataTableViewModel MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(long hoSoId);
    }
}
