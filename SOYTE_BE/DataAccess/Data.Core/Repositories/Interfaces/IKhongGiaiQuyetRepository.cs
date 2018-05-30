using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IKhongGiaiQuyetRepository : IRepository<KhongGiaiQuyet>
    {
        bool MotCua_KhongGiaiQuyet_Ins(KhongGiaiQuyet model, IDbConnection conns, IDbTransaction trans);
    }
}
