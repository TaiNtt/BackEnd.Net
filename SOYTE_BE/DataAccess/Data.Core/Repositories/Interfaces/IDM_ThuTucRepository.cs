using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_ThuTucRepository : IRepository<DM_ThuTuc>
    {
        IEnumerable<DM_ThuTuc> MotCua_DM_ThuTuc_GetByLinhVucID(int LinhVucID);
        DM_ThuTuc MotCua_DM_ThuTuc_GetByThuTucID(int ThuTucID);
        IEnumerable<DM_ThuTucList> MotCua_DM_ThuTuc_List(string tuKhoa, int pageIndex, int pageSize, out int totalItems);
        int MotCua_DM_ThuTuc_Ins(DM_ThuTuc model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_DM_ThuTuc_UpdID(DM_ThuTuc model, IDbConnection conns, IDbTransaction trans);
    }
}
