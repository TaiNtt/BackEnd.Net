using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_QuyTrinh_Buoc_NguoiNhanRepository : IRepository<DM_QuyTrinh_Buoc_NguoiNhan>
    {
        DM_QuyTrinh_Buoc_NguoiNhan MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(int BuocID);
        IEnumerable<DM_QuyTrinh_Buoc_NguoiNhan> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(int BuocID);
        bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Ins(DM_QuyTrinh_Buoc_NguoiNhan model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Del(int BuocID, IDbConnection conns, IDbTransaction trans);
        IEnumerable<MotCua_ListUsersRoles> MotCua_ListUsersRoles();
    }
}
