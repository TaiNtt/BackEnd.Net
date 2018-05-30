using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface ICV_XNKThuoc_PhiMauDich_DSThuocRepository : IRepository<CV_XNKThuoc_PhiMauDich_DSThuoc>
    {
        IEnumerable<CV_XNKThuoc_PhiMauDich_DSThuoc> NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_GetByXNKThuocPhiMauDichId(long XNKThuocPhiMauDichId);
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_Ins(List<CV_XNKThuoc_PhiMauDich_DSThuoc> lstmodel, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DSThuoc_DelByXNKThuocPhiMauDichId(long XNKThuocPhiMauDichId, IDbConnection conns, IDbTransaction trans);
    }
}
