using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_NoiCapChungChiRepository : IRepository<DM_NoiCapChungChi>
    {
        IEnumerable<MTDanhMuc> DBMaster_DM_NoiCapChungChi_GetAll();

        IEnumerable<MTDanhMuc> DBMaster_DM_NoiCapChungChi_GetAll(IDbConnection conns);
    }
}
