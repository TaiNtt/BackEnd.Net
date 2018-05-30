using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ITD_KeHoachDauThau_DSGoiThauRepository : IRepository<TD_KeHoachDauThau_DSGoiThau>
    {
        IEnumerable<TD_KeHoachDauThau_DSGoiThau> NganhDuoc_TD_KeHoachDauThau_DSGoiThau_GetByKeHoachDauThauID(long KeHoachDauThauId);
        bool NganhDuoc_TD_KeHoachDauThau_DSGoiThau_Ins(List<TD_KeHoachDauThau_DSGoiThau> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_TD_KeHoachDauThau_DSGoiThau_DelByKeHoachDauThauID(long KeHoachDauThauId, IDbConnection conns, IDbTransaction trans);
    }
}
