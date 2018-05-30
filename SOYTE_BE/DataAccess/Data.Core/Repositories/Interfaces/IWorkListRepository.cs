using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IWorkListRepository : IRepository<WorkList>
    {
        IEnumerable<WorkListViewModel> MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(int UserID);
        IEnumerable<WorkListViewModel> MotCua_WorkList_CountByFilter(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo,int UserID);
        bool MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(int? UserID, int? TrangThaiHoSoID, int? TrangThaiCapNhat,
            IDbConnection conns, IDbTransaction trans);
    }
}
