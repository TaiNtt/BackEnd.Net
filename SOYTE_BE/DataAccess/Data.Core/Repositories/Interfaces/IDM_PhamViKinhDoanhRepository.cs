using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_PhamViKinhDoanhRepository : IRepository<DM_PhamViKinhDoanh>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_PhamViKinhDoanh_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_PhamViKinhDoanh_GetAll(IDbConnection conns);
    }
}
