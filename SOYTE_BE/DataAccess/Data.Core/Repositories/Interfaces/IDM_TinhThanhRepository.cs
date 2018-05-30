using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_TinhThanhRepository : IRepository<DM_TinhThanh>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_TinhThanh_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_TinhThanh_GetAll(IDbConnection conns);
    }
}
