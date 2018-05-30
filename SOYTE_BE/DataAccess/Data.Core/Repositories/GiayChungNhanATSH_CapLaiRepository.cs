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
    public class GiayChungNhanATSH_CapLaiRepository : Repository<GiayChungNhanATSH_CapLai>, IGiayChungNhanATSH_CapLaiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanATSH_CapLai";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayChungNhanATSH_CapLaiRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public GiayChungNhanATSH_CapLai NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<GiayChungNhanATSH_CapLai>("NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH_CapLai();
            }
        }

        public GiayChungNhanATSH_CapLai NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<GiayChungNhanATSH_CapLai>("NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH_CapLai();
            }
        }

        public long NganhY_GiayChungNhanATSH_CapLai_Ins(GiayChungNhanATSH_CapLai model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Cap", model.Cap, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GiayChungNhanATSHIDGoc", model.GiayChungNhanATSHIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhanCu", model.SoGiayChungNhanCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input); 
                parameters.Add("ThoiHanCu", model.ThoiHanCu, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LanCapLai", model.LanCapLai, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoCapLaiID", model.LyDoCapLaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaCapLai", model.DaCapLai, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLai_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_GiayChungNhanATSH_CapLai_Upd(GiayChungNhanATSH_CapLai model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Cap", model.Cap, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GiayChungNhanATSHIDGoc", model.GiayChungNhanATSHIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhanCu", model.SoGiayChungNhanCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHanCu", model.ThoiHanCu, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LanCapLai", model.LanCapLai, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoCapLaiID", model.LyDoCapLaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaCapLai", model.DaCapLai, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLai_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLai_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        
        public bool NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(long HoSoID, long CapLaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
