using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_QuanHuyenRepository : IRepository<DM_QuanHuyen>
    {
        IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetAll();
        IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetAll(IDbConnection conns);
        IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetByTinhID(int TinhThanhID, IDbConnection conns);
    }
}
