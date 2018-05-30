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
    public class GiayChungNhanBTGT_ThanhPhanRepository : Repository<GiayChungNhanBTGT_ThanhPhan>, IGiayChungNhanBTGT_ThanhPhanRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanBTGT_ThanhPhan";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;

        public GiayChungNhanBTGT_ThanhPhanRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //------------------------------------------------------------//

        public IEnumerable<GiayChungNhanBTGT_ThanhPhan> NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID(long GiayChungNhanBTGTID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanBTGTID", GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<GiayChungNhanBTGT_ThanhPhan>("NganhY_GiayChungNhanBTGT_ThanhPhan_GetByGCNID", parameters, commandType: CommandType.StoredProcedure);

                    var lstNS = datas as IList<GiayChungNhanBTGT_ThanhPhan> ?? datas.ToList();

                    return lstNS;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhY_GiayChungNhanBTGT_ThanhPhan_Ins(List<GiayChungNhanBTGT_ThanhPhan> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanBTGTID", model.GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenViThuoc", model.TenViThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("LieuLuong", model.LieuLuong, DbType.Int64, ParameterDirection.Input);                    
                    conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_ThanhPhan_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayChungNhanBTGT_ThanhPhan_DelByGCNID(long GiayChungNhanBTGTID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanBTGTID", GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_ThanhPhan_DelByGCNID", parameters, trans, commandType: CommandType.StoredProcedure);
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
