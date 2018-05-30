using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICN_GDP_DSKhoRepository : IRepository<CN_GDP_DSKho>
    {
        IEnumerable<CN_GDP_DSKho> NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(long THTGDPId);
        bool NganhDuoc_CN_GDP_DSKho_Ins(List<CN_GDP_DSKho> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GDP_DSKho_InsAndUpd(List<CN_GDP_DSKho> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CN_GDP_DSKho_DelByTHTGDPId(long THTGDPId, IDbConnection conns, IDbTransaction trans);
    }
}
