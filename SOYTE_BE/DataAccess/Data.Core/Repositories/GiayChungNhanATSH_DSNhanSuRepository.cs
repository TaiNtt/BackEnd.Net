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
    public class GiayChungNhanATSH_DSNhanSuRepository : Repository<GiayChungNhanATSH_DSNhanSu>, IGiayChungNhanATSH_DSNhanSuRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanATSH_DSNhanSu";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayChungNhanATSH_DSNhanSuRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }

        public IEnumerable<GiayChungNhanATSH_DSNhanSu> NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID(long GiayChungNhanATSHID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayChungNhanATSH_DSNhanSu>("NganhY_GiayChungNhanATSH_DSNhanSu_GetByGCNID", parameters, commandType: CommandType.StoredProcedure);

                    var lstTDCM = datas as IList<GiayChungNhanATSH_DSNhanSu> ?? datas.ToList();

                    return lstTDCM;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool NganhY_GiayChungNhanATSH_DSNhanSu_Ins(List<GiayChungNhanATSH_DSNhanSu> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanATSHID", model.GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("ChucDanh", model.ChucDanh, DbType.String, ParameterDirection.Input);
                    parameters.Add("TrinhDoChuyenMonID", model.TrinhDoChuyenMonID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CongViecPhuTrach", model.CongViecPhuTrach, DbType.String, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhY_GiayChungNhanATSH_DSNhanSu_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanATSH_DSNhanSu_DelByGCNID(long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_DSNhanSu_DelByGCNID", parameters, trans, commandType: CommandType.StoredProcedure);
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
