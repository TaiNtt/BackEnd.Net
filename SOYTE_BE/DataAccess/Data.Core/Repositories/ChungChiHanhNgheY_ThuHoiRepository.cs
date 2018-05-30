
using System;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using Core.Common.Utilities;
using System.Configuration;

namespace Data.Core.Repositories
{
    public class ChungChiHanhNgheY_ThuHoiRepository : Repository<ChungChiHanhNgheY_ThuHoi>, IChungChiHanhNgheY_ThuHoiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungChiHanhNgheY_ThuHoi";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public ChungChiHanhNgheY_ThuHoiRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public long NganhY_ChungChiHanhNgheY_ThuHoi_Ins(ChungChiHanhNgheY_ThuHoi model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiHanhNgheYID", model.ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NgayThuHoi", model.NgayThuHoi, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LyDoThuHoiID", model.LyDoThuHoiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_ThuHoi_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (iD != null)
                    return Convert.ToInt64(iD);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_ThuHoi_Upd(ChungChiHanhNgheY_ThuHoi model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuHoiID", model.ThuHoiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChungChiHanhNgheYID", model.ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NgayThuHoi", model.NgayThuHoi, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LyDoThuHoiID", model.LyDoThuHoiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_ThuHoi_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_ThuHoi_HuyThuHoi(long ChungChiHanhNgheYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiHanhNgheYID", ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_ThuHoi_HuyThuHoi", parameters, trans, commandType: CommandType.StoredProcedure);
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
