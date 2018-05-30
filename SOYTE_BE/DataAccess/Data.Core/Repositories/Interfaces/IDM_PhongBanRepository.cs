using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_PhongBanRepository : IRepository<DM_PhongBan>
    {
        IEnumerable<CanBoPhongBanList> DBMaster_ListCanBo_PhongBan();
    }
}
