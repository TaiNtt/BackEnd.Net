using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_QuyTrinh_BuocRepository : IRepository<DM_QuyTrinh_Buoc>
    {
        DM_QuyTrinh_Buoc MotCua_DM_QuyTrinh_Buoc_GetByBuocID(int BuocID);
        IEnumerable<DM_QuyTrinh_Buoc_NguoiNhanList> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(int thuTucID, int pageIndex, int pageSize, out int totalItems);
        int MotCua_DM_QuyTrinh_Buoc_Ins(DM_QuyTrinh_Buoc model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_DM_QuyTrinh_Buoc_UpdByBuocID(DM_QuyTrinh_Buoc model, IDbConnection conns, IDbTransaction trans);
    }
}
