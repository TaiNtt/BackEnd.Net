using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_LinhVucRepository : IRepository<DM_LinhVuc>
    {
        IEnumerable<DM_LinhVuc> MotCua_DM_LinhVuc_GetAll();
        IEnumerable<DM_LinhVucList> MotCua_DM_LinhVuc_List(string tuKhoa, int pageIndex, int pageSize, out int totalItems);
        DM_LinhVuc MotCua_DM_LinhVuc_GetByLinhVucID(int LinhVucID);
        bool MotCua_DM_LinhVuc_Ins(DM_LinhVuc model, IDbConnection conns, IDbTransaction trans);
        bool MotCua_DM_LinhVuc_UpdID(DM_LinhVuc model, IDbConnection conns, IDbTransaction trans);
    }
}
