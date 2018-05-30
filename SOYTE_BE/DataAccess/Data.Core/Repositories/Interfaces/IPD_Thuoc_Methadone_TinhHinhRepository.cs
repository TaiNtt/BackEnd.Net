using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IPD_Thuoc_Methadone_TinhHinhRepository : IRepository<PD_Thuoc_Methadone_TinhHinh>
    {
        IEnumerable<PD_Thuoc_Methadone_TinhHinh> NganhDuoc_PD_Thuoc_Methadone_TinhHinh_GetByPDMethadoneId(long PDMethadoneId);
        bool NganhDuoc_PD_Thuoc_Methadone_TinhHinh_Ins(List<PD_Thuoc_Methadone_TinhHinh> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_PD_Thuoc_Methadone_TinhHinh_DelByPDMethadoneId(long PDMethadoneId, IDbConnection conns, IDbTransaction trans);
    }
}
