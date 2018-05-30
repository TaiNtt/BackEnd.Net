using Business.Entities;
using Business.Entities.ViewModels;
using Data.Core.Repositories.Base;
using System;
using System.Data;
using System.Collections.Generic;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_ThuHoiRepository : IRepository<ChungChiHanhNgheY_ThuHoi>
    {
        long NganhY_ChungChiHanhNgheY_ThuHoi_Ins(ChungChiHanhNgheY_ThuHoi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_ThuHoi_Upd(ChungChiHanhNgheY_ThuHoi model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_ThuHoi_HuyThuHoi(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans);
    }
}
