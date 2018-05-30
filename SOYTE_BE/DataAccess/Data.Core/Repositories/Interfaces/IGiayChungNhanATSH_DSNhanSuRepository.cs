using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanATSH_DSNhanSuRepository : IRepository<GiayChungNhanATSH_DSNhanSu>
    {
        IEnumerable<GiayChungNhanATSH_DSNhanSu> NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID(long GiayChungNhanATSHID);
        bool NganhY_GiayChungNhanATSH_DSNhanSu_Ins(List<GiayChungNhanATSH_DSNhanSu> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_DSNhanSu_DelByGCNID(long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans);
    }
}
