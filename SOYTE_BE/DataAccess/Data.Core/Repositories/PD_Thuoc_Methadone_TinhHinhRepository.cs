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
    public class PD_Thuoc_Methadone_TinhHinhRepository : Repository<PD_Thuoc_Methadone_TinhHinh>, IPD_Thuoc_Methadone_TinhHinhRepository
    {
        private readonly ILog _logger;
        private const string TableName = "PD_Thuoc_Methadone_TinhHinh";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;

        public PD_Thuoc_Methadone_TinhHinhRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        public IEnumerable<PD_Thuoc_Methadone_TinhHinh> NganhDuoc_PD_Thuoc_Methadone_TinhHinh_GetByPDMethadoneId(long PDMethadoneId)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("PDMethadoneId", PDMethadoneId, DbType.Int64, ParameterDirection.Input);
                    var datas = conns.Query<PD_Thuoc_Methadone_TinhHinh>("NganhDuoc_PD_Thuoc_Methadone_TinhHinh_GetByPDMethadoneId"
                        , parameters, commandType: CommandType.StoredProcedure);

                    var lstHT = datas as IList<PD_Thuoc_Methadone_TinhHinh> ?? datas.ToList();

                    return lstHT;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_TinhHinh_Ins(List<PD_Thuoc_Methadone_TinhHinh> lstmodel, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                foreach (var model in lstmodel)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("PDMethadoneId", model.PDMethadoneId, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenThuoc", model.TenThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViTinh", model.DonViTinh, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLTonKhoKyTruoc", model.SLTonKhoKyTruoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLNhapTrongKy", model.SLNhapTrongKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("TongSo", model.TongSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLXuatTrongKy", model.SLXuatTrongKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLHaoHut", model.SLHaoHut, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLDuThua", model.SLDuThua, DbType.String, ParameterDirection.Input);
                    parameters.Add("TonKhoCuoiKy", model.TonKhoCuoiKy, DbType.String, ParameterDirection.Input);
                    parameters.Add("TongSoNguoiBenhThamGiaDieuTri", model.TongSoNguoiBenhThamGiaDieuTri, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLNguoiBenhDuKienTangKyToi", model.SLNguoiBenhDuKienTangKyToi, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLDuTruKyToi", model.SLDuTruKyToi, DbType.String, ParameterDirection.Input);
                    parameters.Add("SLDuyetDuTru", model.SLDuyetDuTru, DbType.String, ParameterDirection.Input);
                    parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                    parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);                    
                    parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);
                    conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_TinhHinh_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_Methadone_TinhHinh_DelByPDMethadoneId(long PDMethadoneId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PDMethadoneId", PDMethadoneId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_Methadone_TinhHinh_DelByPDMethadoneId", parameters, trans, commandType: CommandType.StoredProcedure);
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
