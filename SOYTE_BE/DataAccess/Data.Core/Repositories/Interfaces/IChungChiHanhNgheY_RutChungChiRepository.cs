using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_RutChungChiRepository : IRepository<ChungChiHanhNgheY_RutChungChi>
    {
        long NganhY_ChungChiHanhNgheY_RutChungChi_Ins(ChungChiHanhNgheY_RutChungChi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_RutChungChi_Upd(ChungChiHanhNgheY_RutChungChi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_RutChungChi_HuyRut(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans);
    }
}
