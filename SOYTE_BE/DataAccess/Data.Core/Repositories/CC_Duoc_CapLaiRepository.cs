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
    public class CC_Duoc_CapLaiRepository : Repository<CC_Duoc_CapLai>, ICC_Duoc_CapLaiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CC_Duoc_CapLai";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CC_Duoc_CapLaiRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public CC_Duoc_CapLai NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<CC_Duoc_CapLai>("NganhDuoc_CC_Duoc_CapLai_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CC_Duoc_CapLai();
            }
        }

        public CC_Duoc_CapLai NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long HoSoId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<CC_Duoc_CapLai>("NganhDuoc_CC_Duoc_CapLai_GetByHoSoID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CC_Duoc_CapLai();
            }
        }

        public long NganhDuoc_CC_Duoc_CapLai_Ins(CC_Duoc_CapLai model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChungChiDuocIDGoc", model.ChungChiDuocIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChiCu", model.SoChungChiCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LanCapLai", model.LanCapLai, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoCapLaiID", model.LyDoCapLaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaCapLai", model.DaCapLai, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_CC_Duoc_CapLai_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhDuoc_CC_Duoc_CapLai_Upd(CC_Duoc_CapLai model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChungChiDuocIDGoc", model.ChungChiDuocIDGoc, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChiCu", model.SoChungChiCu, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapCu", model.NgayCapCu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LanCapLai", model.LanCapLai, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LyDoCapLaiID", model.LyDoCapLaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DaCapLai", model.DaCapLai, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_CapLai_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhDuoc_CC_Duoc_CapLai_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_CapLai_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        
        public bool NganhDuoc_CC_Duoc_CapLai_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_CapLai_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
