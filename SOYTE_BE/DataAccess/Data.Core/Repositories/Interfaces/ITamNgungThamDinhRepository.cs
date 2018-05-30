using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface ITamNgungThamDinhRepository : IRepository<TamNgungThamDinh>
    {
        bool MotCua_TamNgungThamDinh_Ins(TamNgungThamDinh model, IDbConnection conns, IDbTransaction trans);
    }
}
