using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_DuDieuKienHanhNgheRepository : IRepository<DM_DuDieuKienHanhNghe>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_DuDieuKienHanhNghe_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_DuDieuKienHanhNghe_GetAll(IDbConnection conns);
    }
}
