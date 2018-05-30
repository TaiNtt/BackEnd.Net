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
    public class ChungChiHanhNgheY_DieuChinhRepository : Repository<ChungChiHanhNgheY_DieuChinh>, IChungChiHanhNgheY_DieuChinhRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungChiHanhNgheY_DieuChinh";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public ChungChiHanhNgheY_DieuChinhRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public long NganhY_ChungChiHanhNgheY_DieuChinh_Ins(ChungChiHanhNgheY_DieuChinh model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChungChiHanhNgheYIDGoc", model.ChungChiHanhNgheYIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChiCu", model.SoChungChiCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LanDieuChinh", model.LanDieuChinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoDieuChinhID", model.LyDoDieuChinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaDieuChinh", model.DaDieuChinh, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinh_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_ChungChiHanhNgheY_DieuChinh_Upd(ChungChiHanhNgheY_DieuChinh model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DieuChinhID", model.DieuChinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChungChiHanhNgheYIDGoc", model.ChungChiHanhNgheYIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChiCu", model.SoChungChiCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LanDieuChinh", model.LanDieuChinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoDieuChinhID", model.LyDoDieuChinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaDieuChinh", model.DaDieuChinh, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinh_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public ChungChiHanhNgheY_DieuChinh NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<ChungChiHanhNgheY_DieuChinh>("NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ChungChiHanhNgheY_DieuChinh();
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public ChungChiHanhNgheY_DieuChinh NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<ChungChiHanhNgheY_DieuChinh>("NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ChungChiHanhNgheY_DieuChinh();
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
