using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_LyDoRepository : IRepository<DM_LyDo>
    {
        IEnumerable<DM_LyDoList> DBMaster_DM_LyDo_List(int? LoaiCapPhepID, int? LoaiLyDoID, string tuKhoa, int pageIndex, int pageSize, out int totalItems);
        DM_LyDo DBMaster_DM_LyDo_GetByLyDoID(int LyDoID);
        bool DBMaster_DM_LyDo_Ins(DM_LyDo model, IDbConnection conns, IDbTransaction trans);
        bool DBMaster_DM_LyDo_UpdByLyDoID(DM_LyDo model, IDbConnection conns, IDbTransaction trans);
    }
}
