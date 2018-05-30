using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_PhamViHoatDongChuyenMonRepository : IRepository<DM_PhamViHoatDongChuyenMon>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_PhamViHoatDongChuyenMon_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_PhamViHoatDongChuyenMon_GetAll(IDbConnection conns);
    }
}
