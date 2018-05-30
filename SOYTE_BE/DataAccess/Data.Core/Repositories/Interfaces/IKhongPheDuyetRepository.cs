using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IKhongPheDuyetRepository : IRepository<KhongPheDuyet>
    {
        bool MotCua_KhongPheDuyet_Ins(KhongPheDuyet model, IDbConnection conns, IDbTransaction trans);
    }
}
