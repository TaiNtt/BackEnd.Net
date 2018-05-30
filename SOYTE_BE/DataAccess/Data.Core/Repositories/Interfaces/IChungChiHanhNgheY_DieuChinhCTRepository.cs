using Business.Entities;
using Data.Core.Repositories.Base;
using System.Data;


namespace Data.Core.Repositories.Interfaces
{
    public interface IChungChiHanhNgheY_DieuChinhCTRepository : IRepository<ChungChiHanhNgheY_DieuChinhCT>
    {
        bool NganhY_ChungChiHanhNgheY_DieuChinhCT_Ins(ChungChiHanhNgheY_DieuChinhCT model, IDbConnection conns, IDbTransaction trans);

        bool NganhY_ChungChiHanhNgheY_DieuChinhCT_Upd(ChungChiHanhNgheY_DieuChinhCT model, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_DieuChinhCT NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(long DieuChinhID, IDbConnection conns, IDbTransaction trans);

        ChungChiHanhNgheY_DieuChinhCT NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(long DieuChinhID);

        bool NganhY_ChungChiHanhNgheY_DieuChinhCT_DelDieuChinhID(long DieuChinhID, IDbConnection conns, IDbTransaction trans);
    }
}
