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
    public class ChungChiHanhNgheY_DieuChinhCTRepository : Repository<ChungChiHanhNgheY_DieuChinhCT>, IChungChiHanhNgheY_DieuChinhCTRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ChungChiHanhNgheY_DieuChinhCT";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public ChungChiHanhNgheY_DieuChinhCTRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public bool NganhY_ChungChiHanhNgheY_DieuChinhCT_Ins(ChungChiHanhNgheY_DieuChinhCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DieuChinhID", model.DieuChinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungTruoc", model.NoiDungTruoc, DbType.Xml, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);
                parameters.Add("FieldChange", model.FieldChange, DbType.String, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinhCT_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinhCT_Upd(ChungChiHanhNgheY_DieuChinhCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DieuChinhID", model.DieuChinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);
                parameters.Add("FieldChange", model.FieldChange, DbType.String, ParameterDirection.Input);
                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinhCT_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public ChungChiHanhNgheY_DieuChinhCT NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(long DieuChinhID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DieuChinhID", DieuChinhID, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<ChungChiHanhNgheY_DieuChinhCT>("NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ChungChiHanhNgheY_DieuChinhCT();
            }
        }

        public ChungChiHanhNgheY_DieuChinhCT NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID(long DieuChinhID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("DieuChinhID", DieuChinhID, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<ChungChiHanhNgheY_DieuChinhCT>("NganhY_ChungChiHanhNgheY_DieuChinhCT_GetByDieuChinhID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ChungChiHanhNgheY_DieuChinhCT();
            }
        }

        public bool NganhY_ChungChiHanhNgheY_DieuChinhCT_DelDieuChinhID(long DieuChinhID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DieuChinhID", DieuChinhID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_ChungChiHanhNgheY_DieuChinhCT_DelDieuChinhID", parameters, trans, commandType: CommandType.StoredProcedure);
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
