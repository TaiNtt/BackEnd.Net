using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;

namespace Data.Core.Repositories.Interfaces
{
    public interface IXN_NoiDungQuangCaoRepository : IRepository<XN_NoiDungQuangCao>
    {
        XN_NoiDungQuangCao NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(long HoSoID);
        XN_NoiDungQuangCao NganhDuoc_XN_NoiDungQuangCao_GetByID(long NoiDungQCId);
        IEnumerable<XN_NoiDungQuangCaoViewModel> NganhDuoc_XN_NoiDungQuangCao_Search(string SoXacNhan, DateTime? tuNgay, DateTime? denNgay
            , string TOCHUC_CANHAN, int pageIndex, int pageSize, out int totalItems);
        long NganhDuoc_XN_NoiDungQuangCao_Ins(XN_NoiDungQuangCao model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_XN_NoiDungQuangCao_UpdByID(XN_NoiDungQuangCao model, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans);
        bool NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(long HoSoID, long NoiDungQCId, IDbConnection conns, IDbTransaction trans);
    }
}
