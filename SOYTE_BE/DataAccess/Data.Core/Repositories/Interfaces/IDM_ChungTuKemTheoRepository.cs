using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_ChungTuKemTheoRepository : IRepository<DM_ChungTuKemTheo>
    {
        IEnumerable<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetAll();
        IEnumerable<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetByThuTucID(int ThuTucID);
        bool MotCua_DM_ChungTuKemTheo_Ins(DM_ChungTuKemTheo model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_DM_ChungTuKemTheo_DelByThuTucID(int ThuTucID, IDbConnection conns, IDbTransaction trans);
    }
}
