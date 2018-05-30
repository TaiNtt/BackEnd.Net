using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IDM_GoiYRepository : IRepository<DM_GoiY>
    {
        IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search);

        IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search, IDbConnection conns);
        int DBMaster_DM_GoiY_PopupIns(DM_GoiYSave model, IDbConnection conns, IDbTransaction trans);
        int DBMaster_DM_GoiY_PopupUpd(DM_GoiYSave model, IDbConnection conns, IDbTransaction trans);
        bool DBMaster_DM_GoiY_PopupDel(int GoiYID, IDbConnection conns, IDbTransaction trans);
        IEnumerable<DM_GoiYList> DBMaster_DM_GoiY_List(int? LoaiCapPhepID, int? LoaiGoiYID, string tuKhoa, int pageIndex, int pageSize, out int totalItems);
        DM_GoiY DBMaster_DM_GoiY_GetByGoiYID(int GoiYID);
        bool DBMaster_DM_GoiY_Ins(DM_GoiY model, IDbConnection conns, IDbTransaction trans);
        bool DBMaster_DM_GoiY_UpdByGoiYID(DM_GoiY model, IDbConnection conns, IDbTransaction trans);
    }
}
