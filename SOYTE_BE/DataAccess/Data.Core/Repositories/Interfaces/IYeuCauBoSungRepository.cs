using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IYeuCauBoSungRepository : IRepository<YeuCauBoSung>
    {
        bool MotCua_YeuCauBoSung_Ins(YeuCauBoSung model, IDbConnection conns, IDbTransaction trans);
    }
}
