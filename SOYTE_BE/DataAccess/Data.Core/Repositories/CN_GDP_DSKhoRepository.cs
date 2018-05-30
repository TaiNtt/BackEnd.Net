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
    public class CN_GDP_DSKhoRepository : Repository<CN_GDP_DSKho>, ICN_GDP_DSKhoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CN_GDP_DSKho";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public CN_GDP_DSKhoRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<CN_GDP_DSKho> NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(long THTGDPId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPId", THTGDPId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<CN_GDP_DSKho>("NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId", parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<CN_GDP_DSKho> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_CN_GDP_DSKho_Ins(List<CN_GDP_DSKho> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPId", model.THTGDPId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenKho", model.TenKho, DbType.String, ParameterDirection.Input);
                    parameters.Add("DiaChiKho", model.DiaChiKho, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CN_GDP_DSKho_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GDP_DSKho_InsAndUpd(List<CN_GDP_DSKho> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPDSKhoId", model.THTGDPDSKhoId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("THTGDPId", model.THTGDPId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenKho", model.TenKho, DbType.String, ParameterDirection.Input);
                    parameters.Add("DiaChiKho", model.DiaChiKho, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_CN_GDP_DSKho_InsAndUpd", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GDP_DSKho_DelByTHTGDPId(long THTGDPId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("THTGDPId", THTGDPId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GDP_DSKho_DelByTHTGDPId", parameters, trans, commandType: CommandType.StoredProcedure);
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
