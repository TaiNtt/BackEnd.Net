using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_HinhThucToChucRepository : IRepository<DM_HinhThucToChuc>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll(IDbConnection conns);
    }
}
