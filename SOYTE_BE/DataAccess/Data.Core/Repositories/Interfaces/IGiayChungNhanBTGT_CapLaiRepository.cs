using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanBTGT_CapLaiRepository : IRepository<GiayChungNhanBTGT_CapLai>
    {
        GiayChungNhanBTGT_CapLai NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(long HoSoId);
        GiayChungNhanBTGT_CapLai NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);
        long NganhY_GiayChungNhanBTGT_CapLai_Ins(GiayChungNhanBTGT_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLai_Upd(GiayChungNhanBTGT_CapLai model, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID(long HoSoID, long CapLaiID, IDbConnection conns, IDbTransaction trans);
    }
}
