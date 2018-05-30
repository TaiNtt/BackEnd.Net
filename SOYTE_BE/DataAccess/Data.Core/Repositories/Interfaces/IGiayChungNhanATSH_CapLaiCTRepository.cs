using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanATSH_CapLaiCTRepository : IRepository<GiayChungNhanATSH_CapLaiCT>
    {
        GiayChungNhanATSH_CapLaiCT NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(long CapLaiID);
        GiayChungNhanATSH_CapLaiCT NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLaiCT_Ins(GiayChungNhanATSH_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLaiCT_Upd(GiayChungNhanATSH_CapLaiCT model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
