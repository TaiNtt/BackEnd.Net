using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanATSH_CapLaiRepository : IRepository<GiayChungNhanATSH_CapLai>
    {
        GiayChungNhanATSH_CapLai NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoId);
        GiayChungNhanATSH_CapLai NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);
        long NganhY_GiayChungNhanATSH_CapLai_Ins(GiayChungNhanATSH_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLai_Upd(GiayChungNhanATSH_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(long HoSoID, long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
