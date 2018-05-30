using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanLuongY_QTHanhNgheRepository : IRepository<GiayChungNhanLuongY_QTHanhNghe>
    {
        IEnumerable<GiayChungNhanLuongY_QTHanhNghe> NganhY_GiayChungNhanLuongY_QTHanhNghe_GetByGCNLYID(long GiayChungNhanLuongYID);

        bool NganhY_GiayChungNhanLuongY_QTHanhNghe_Ins(List<GiayChungNhanLuongY_QTHanhNghe> lstmodel, IDbConnection conns, IDbTransaction trans);

        bool NganhY_GiayChungNhanLuongY_QTHanhNghe_DelByGCNLYID(long GiayChungNhanLuongYID, IDbConnection conns, IDbTransaction trans);
    }
}
