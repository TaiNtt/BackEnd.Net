using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IGiayPhepDoanKCB_ThanhVienRepository : IRepository<GiayPhepDoanKCB_ThanhVien>
    {
        IEnumerable<GiayPhepDoanKCB_ThanhVien> NganhY_GiayPhepDoanKCB_ThanhVien_GetByGPID(long GiayPhepDoanKCBID);
        bool NganhY_GiayPhepDoanKCB_ThanhVien_Ins(List<GiayPhepDoanKCB_ThanhVien> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhY_GiayPhepDoanKCB_ThanhVien_DelByGPID(long GiayPhepDoanKCBID, IDbConnection conns, IDbTransaction trans);
    }
}
