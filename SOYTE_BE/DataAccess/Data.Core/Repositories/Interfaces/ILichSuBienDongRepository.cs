using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ILichSuBienDongRepository : IRepository<LichSuBienDong>
    {
        IEnumerable<LichSuBienDongViewModel> BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(long GiayPhepID, int LoaiCapPhepID);
        bool BaoCaoThongKe_LichSuBienDong_Ins(LichSuBienDong model, IDbConnection conns, IDbTransaction trans);
    }
}
