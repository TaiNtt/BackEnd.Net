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
    public class P_CongBoMyPham_ThanhPhanRepository : Repository<P_CongBoMyPham_ThanhPhan>, IP_CongBoMyPham_ThanhPhanRepository
    {
        private readonly ILog _logger;
        private const string TableName = "P_CongBoMyPham_ThanhPhan";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public P_CongBoMyPham_ThanhPhanRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<P_CongBoMyPham_ThanhPhan> NganhDuoc_P_CongBoMyPham_ThanhPhan_GetByCongBoSPMyPhamId(long CongBoSPMyPhamId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("CongBoSPMyPhamId", CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<P_CongBoMyPham_ThanhPhan>("NganhDuoc_P_CongBoMyPham_ThanhPhan_GetByCongBoSPMyPhamId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<P_CongBoMyPham_ThanhPhan> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_ThanhPhan_Ins(List<P_CongBoMyPham_ThanhPhan> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("CongBoSPMyPhamId", model.CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThanhPhan", model.TenThanhPhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("TyLe", model.TyLe, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_ThanhPhan_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_ThanhPhan_DelCongBoSPMyPhamId(long CongBoSPMyPhamId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CongBoSPMyPhamId", CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_ThanhPhan_DelCongBoSPMyPhamId", parameters, trans, commandType: CommandType.StoredProcedure);
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
