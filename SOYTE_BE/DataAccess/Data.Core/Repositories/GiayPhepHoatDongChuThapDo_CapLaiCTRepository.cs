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
    public class GiayPhepHoatDongChuThapDo_CapLaiCTRepository : Repository<GiayPhepHoatDongChuThapDo_CapLaiCT>, IGiayPhepHoatDongChuThapDo_CapLaiCTRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepHoatDongChuThapDo_CapLaiCT";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayPhepHoatDongChuThapDo_CapLaiCTRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//

        public GiayPhepHoatDongChuThapDo_CapLaiCT NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(long CapLaiID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                    var retval = conns.Query<GiayPhepHoatDongChuThapDo_CapLaiCT>("NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongChuThapDo_CapLaiCT();
            }
        }

        public GiayPhepHoatDongChuThapDo_CapLaiCT NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                var retval = conns.Query<GiayPhepHoatDongChuThapDo_CapLaiCT>("NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_GetByCapLaiID", parameters, trans
                    , commandType: CommandType.StoredProcedure);
                return retval.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongChuThapDo_CapLaiCT();
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Ins(GiayPhepHoatDongChuThapDo_CapLaiCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungTruoc", model.NoiDungTruoc, DbType.Xml, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Upd(GiayPhepHoatDongChuThapDo_CapLaiCT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", model.CapLaiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungSau", model.NoiDungSau, DbType.Xml, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_Upd", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_DelByCapLaiID(long CapLaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CapLaiID", CapLaiID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_CapLaiCT_DelByCapLaiID", parameters, trans, commandType: CommandType.StoredProcedure);
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
