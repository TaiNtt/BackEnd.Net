using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_TrinhDoChuyenMonRepository : IRepository<DM_TrinhDoChuyenMon>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_TrinhDoChuyenMon_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_TrinhDoChuyenMon_GetAll(IDbConnection conns);
    }
}
