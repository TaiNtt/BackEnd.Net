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
    public class GiayChungNhanATSH_DSThietBiRepository : Repository<GiayChungNhanATSH_DSThietBi>, IGiayChungNhanATSH_DSThietBiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanATSH_DSThietBi";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayChungNhanATSH_DSThietBiRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<GiayChungNhanATSH_DSThietBi> NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID(long GiayChungNhanATSHID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayChungNhanATSH_DSThietBi>("NganhY_GiayChungNhanATSH_DSThietBi_GetByGCNID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<GiayChungNhanATSH_DSThietBi> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_GiayChungNhanATSH_DSThietBi_Ins(List<GiayChungNhanATSH_DSThietBi> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanATSHID", model.GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThietBi", model.TenThietBi, DbType.String, ParameterDirection.Input);
                    parameters.Add("KyHieu", model.KyHieu, DbType.String, ParameterDirection.Input);
                    parameters.Add("HangSX", model.HangSX, DbType.String, ParameterDirection.Input);
                    parameters.Add("NuocSX", model.NuocSX, DbType.String, ParameterDirection.Input);
                    parameters.Add("NamSX", model.NamSX, DbType.String, ParameterDirection.Input);
                    parameters.Add("TinhTrangSuDung", model.TinhTrangSuDung, DbType.String, ParameterDirection.Input);
                    parameters.Add("BaoDuong", model.BaoDuong, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_GiayChungNhanATSH_DSThietBi_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_DSThietBi_DelByGCNID(long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_DSThietBi_DelByGCNID", parameters, trans, commandType: CommandType.StoredProcedure);
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
