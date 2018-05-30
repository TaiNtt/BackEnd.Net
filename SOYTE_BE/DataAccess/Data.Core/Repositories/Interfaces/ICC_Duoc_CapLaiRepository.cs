using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface ICC_Duoc_CapLaiRepository : IRepository<CC_Duoc_CapLai>
    {
        CC_Duoc_CapLai NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans);

        CC_Duoc_CapLai NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long HoSoId);

        long NganhDuoc_CC_Duoc_CapLai_Ins(CC_Duoc_CapLai model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_CapLai_Upd(CC_Duoc_CapLai model, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);

        bool NganhDuoc_CC_Duoc_CapLai_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans);
    }
}
