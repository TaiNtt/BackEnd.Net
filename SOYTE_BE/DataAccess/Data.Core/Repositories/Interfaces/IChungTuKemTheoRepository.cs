using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungTuKemTheoRepository : IRepository<ChungTuKemTheo>
    {
        IEnumerable<ChungTuKemTheo> MotCua_ChungTuKemTheo_GetByHoSoID(long HoSoID);
        bool MotCua_ChungTuKemTheo_DelAllByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool MotCua_ChungTuKemTheo_Ins(ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_ChungTuKemTheo_UpdID(ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans);
    }
}
