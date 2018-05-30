using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanATSH_DSThietBiRepository : IRepository<GiayChungNhanATSH_DSThietBi>
    {
        IEnumerable<GiayChungNhanATSH_DSThietBi> NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID(long GiayChungNhanATSHID);
        bool NganhY_GiayChungNhanATSH_DSThietBi_Ins(List<GiayChungNhanATSH_DSThietBi> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_DSThietBi_DelByGCNID(long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans);
    }
}
