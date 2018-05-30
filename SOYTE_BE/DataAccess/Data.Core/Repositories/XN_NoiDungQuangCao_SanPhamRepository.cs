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
    public class XN_NoiDungQuangCao_SanPhamRepository : Repository<XN_NoiDungQuangCao_SanPham>, IXN_NoiDungQuangCao_SanPhamRepository
    {
        private readonly ILog _logger;
        private const string TableName = "XN_NoiDungQuangCao_SanPham";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public XN_NoiDungQuangCao_SanPhamRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<XN_NoiDungQuangCao_SanPham> NganhDuoc_XN_NoiDungQuangCao_SanPham_GetByNoiDungQCId(long NoiDungQCId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("NoiDungQCId", NoiDungQCId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<XN_NoiDungQuangCao_SanPham>("NganhDuoc_XN_NoiDungQuangCao_SanPham_GetByNoiDungQCId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<XN_NoiDungQuangCao_SanPham> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_SanPham_Ins(List<XN_NoiDungQuangCao_SanPham> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("NoiDungQCId", model.NoiDungQCId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenSanPham", model.TenSanPham, DbType.String, ParameterDirection.Input);
                    parameters.Add("PhieuCongBoId", model.PhieuCongBoId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("HinhThucQuangCao", model.HinhThucQuangCao, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_SanPham_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_SanPham_DelByNoiDungQCId(long NoiDungQCId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("NoiDungQCId", NoiDungQCId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_SanPham_DelByNoiDungQCId", parameters, trans, commandType: CommandType.StoredProcedure);
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
