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
    public class GiayChungNhanATSH_CapLaiCTRepository : Repository<GiayChungNhanATSH_CapLaiCT>, IGiayChungNhanATSH_CapLaiCTRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanATSH_CapLaiCT";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayChungNhanATSH_CapLaiCTRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public GiayChungNhanATSH_CapLaiCT NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(long CapLaiID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<GiayChungNhanATSH_CapLaiCT>("NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH_CapLaiCT();
            }
        }

        public GiayChungNhanATSH_CapLaiCT NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<GiayChungNhanATSH_CapLaiCT>("NganhY_GiayChungNhanATSH_CapLaiCT_GetByCapLaiID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH_CapLaiCT();
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLaiCT_Ins(GiayChungNhanATSH_CapLaiCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungTruoc", model.NoiDungTruoc, DbType.Xml, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLaiCT_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLaiCT_Upd(GiayChungNhanATSH_CapLaiCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLaiCT_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_CapLaiCT_DelByCapLaiID", parameters, trans, commandType: CommandType.StoredProcedure);
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
