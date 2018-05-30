using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_TDCMRepository : IRepository<ChungChiHanhNgheY_TDCM>
    {
        //Test
        IEnumerable<ChungChiHanhNgheY_TDCM> NganhY_ChungChiHanhNgheY_TDCM_GetByCCHNYID(long ChungChiHanhNgheYId);

        bool NganhY_ChungChiHanhNgheY_TDCM_Ins(List<ChungChiHanhNgheY_TDCM> model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_TDCM_DelByCCHNYID(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans);
    }
}
