using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_QTTHRepository : IRepository<ChungChiHanhNgheY_QTTH>
    {
        IEnumerable<ChungChiHanhNgheY_QTTH> NganhY_ChungChiHanhNgheY_QTTH_GetByCCHNYID(long ChungChiHanhNgheYId);

        bool NganhY_ChungChiHanhNgheY_QTTH_Ins(List<ChungChiHanhNgheY_QTTH> lstmodel, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_QTTH_DelByCCHNYID(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans);
    }
}
