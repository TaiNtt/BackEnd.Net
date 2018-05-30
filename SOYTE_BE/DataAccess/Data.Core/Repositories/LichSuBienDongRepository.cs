using System;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using Core.Common.Utilities;
using System.Collections.Generic;
using System.Configuration;
using Business.Entities.ViewModels;

namespace Data.Core.Repositories
{
    public class LichSuBienDongRepository : Repository<LichSuBienDong>, ILichSuBienDongRepository
    {
        private readonly ILog _logger;
        private const string TableName = "LichSuBienDong";
        private static readonly string BaoCaoThongKeConn = ConfigurationManager.ConnectionStrings["BaoCaoThongKe.ConnString"].ConnectionString;
        public LichSuBienDongRepository(ILog logger) : base(TableName, BaoCaoThongKeConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<LichSuBienDongViewModel> BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(long GiayPhepID, int LoaiCapPhepID)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepID", GiayPhepID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("LoaiCapPhepID", LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<LichSuBienDongViewModel>("BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var lichSuBienDongViewModel = datas as IList<LichSuBienDongViewModel> ??
                                                          datas.ToList();
                    return lichSuBienDongViewModel;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool BaoCaoThongKe_LichSuBienDong_Ins(LichSuBienDong model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LoaiBienDongID", model.LoaiBienDongID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GiayPhepID", model.GiayPhepID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("LoaiCapPhepID", model.LoaiCapPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoLan", model.SoLan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NgayBienDong", model.NgayBienDong, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LyDoID", model.LyDoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("BaoCaoThongKe_LichSuBienDong_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
    }
}
