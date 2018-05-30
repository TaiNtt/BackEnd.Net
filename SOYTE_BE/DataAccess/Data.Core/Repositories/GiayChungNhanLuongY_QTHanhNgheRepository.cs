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
    public class GiayChungNhanLuongY_QTHanhNgheRepository : Repository<GiayChungNhanLuongY_QTHanhNghe>, IGiayChungNhanLuongY_QTHanhNgheRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanLuongY_QTHanhNghe";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayChungNhanLuongY_QTHanhNgheRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<GiayChungNhanLuongY_QTHanhNghe> NganhY_GiayChungNhanLuongY_QTHanhNghe_GetByGCNLYID(long GiayChungNhanLuongYID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanLuongYID", GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayChungNhanLuongY_QTHanhNghe>("NganhY_GiayChungNhanLuongY_QTHanhNghe_GetByGCNLYID", parameters, commandType: CommandType.StoredProcedure);

                    var lstQTHN = datas as IList<GiayChungNhanLuongY_QTHanhNghe> ?? datas.ToList();

                    return lstQTHN;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_QTHanhNghe_Ins(List<GiayChungNhanLuongY_QTHanhNghe> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanLuongYID", model.GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("ThoiGian", model.ThoiGian, DbType.String, ParameterDirection.Input);
                    parameters.Add("PhamViHoatDong", model.PhamViHoatDong, DbType.String, ParameterDirection.Input);
                    parameters.Add("NoiLamViec", model.NoiLamViec, DbType.String, ParameterDirection.Input);
                    parameters.Add("ChucVu", model.ChucVu, DbType.String, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_QTHanhNghe_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_QTHanhNghe_DelByGCNLYID(long GiayChungNhanLuongYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanLuongYID", GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_QTHanhNghe_DelByGCNLYID", parameters, trans, commandType: CommandType.StoredProcedure);
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
