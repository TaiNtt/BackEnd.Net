using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IQuyTrinhRepository
    {
        IEnumerable<QuyTrinhViewModel> MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(int ThuTucID, int TrangThaiHienTaiID, IDbConnection conns);
        bool MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(long HoSoID, int TrangThaiTiepTheoID, int NguoiNhanID, IDbConnection conns);
    }
}
