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
    public class PD_Thuoc_GN_HTT_DSThuocRepository : Repository<PD_Thuoc_GN_HTT_DSThuoc>, IPD_Thuoc_GN_HTT_DSThuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "PD_Thuoc_GN_HTT_DSThuoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public PD_Thuoc_GN_HTT_DSThuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<PD_Thuoc_GN_HTT_DSThuoc> NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_GetByPDThuocGNHTTId(long PDThuocGNHTTId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("PDThuocGNHTTId", PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<PD_Thuoc_GN_HTT_DSThuoc>("NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_GetByPDThuocGNHTTId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<PD_Thuoc_GN_HTT_DSThuoc> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_Ins(List<PD_Thuoc_GN_HTT_DSThuoc> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("PDThuocGNHTTId", model.PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenThuoc", model.TenThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViTinh", model.DonViTinh, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLTonKhoKyTruoc", model.SLTonKhoKyTruoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLNhapTrongKy", model.SLNhapTrongKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("TongSo", model.TongSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("TongSoXuatTrongKy", model.TongSoXuatTrongKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("TonKhoCuoiKy", model.TonKhoCuoiKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLDuTru", model.SLDuTru, DbType.String, ParameterDirection.Input);
                    parameters.Add("Duyet", model.Duyet, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_DelByPDThuocGNHTTId(long PDThuocGNHTTId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PDThuocGNHTTId", PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_DSThuoc_DelByPDThuocGNHTTId", parameters, trans, commandType: CommandType.StoredProcedure);
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
