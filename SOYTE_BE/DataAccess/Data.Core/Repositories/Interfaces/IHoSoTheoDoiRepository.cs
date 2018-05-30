using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IHoSoTheoDoiRepository : IRepository<HoSoTheoDoi>
    {
        long MotCua_HoSoTheoDoi_Ins(HoSoTheoDoi model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_HoSoTheoDoi_Del(long HoSoID, long UserID, IDbConnection conns, IDbTransaction trans);
    }
}
