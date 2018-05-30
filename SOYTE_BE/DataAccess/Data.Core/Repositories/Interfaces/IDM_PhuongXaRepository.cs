using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_PhuongXaRepository : IRepository<DM_PhuongXa>
    {
        IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetAll();
        IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetAll(IDbConnection conns);
        IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetByQuanID(int QuanID, IDbConnection conns);
    }
}
