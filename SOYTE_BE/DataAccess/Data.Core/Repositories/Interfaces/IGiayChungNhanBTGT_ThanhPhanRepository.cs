using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayChungNhanBTGT_ThanhPhanRepository : IRepository<GiayChungNhanBTGT_ThanhPhan>
    {
        IEnumerable<GiayChungNhanBTGT_ThanhPhan> NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID(long GiayChungNhanBTGTID);
        bool NganhY_GiayChungNhanBTGT_ThanhPhan_Ins(List<GiayChungNhanBTGT_ThanhPhan> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayChungNhanBTGT_ThanhPhan_DelByGCNID(long GiayChungNhanBTGTID, IDbConnection conns, IDbTransaction trans);
    }
}
