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
    public class P_CongBoMyPhamRepository : Repository<P_CongBoMyPham>, IP_CongBoMyPhamRepository
    {
        private readonly ILog _logger;
        private const string TableName = "P_CongBoMyPham";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public P_CongBoMyPhamRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public P_CongBoMyPham NganhDuoc_P_CongBoMyPham_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<P_CongBoMyPham>("NganhDuoc_P_CongBoMyPham_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new P_CongBoMyPham();
            }
        }
        public P_CongBoMyPham NganhDuoc_P_CongBoMyPham_GetByID(long CongBoSPMyPhamId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("CongBoSPMyPhamId", CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<P_CongBoMyPham>("NganhDuoc_P_CongBoMyPham_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new P_CongBoMyPham();
            }
        }
        public IEnumerable<P_CongBoMyPhamViewModel> NganhDuoc_P_CongBoMyPham_Search(string SoCongBo, int? ThoiHanTu, int? ThoiHanDen
            , string NhanHang, string TenSanPham, string TenNhaSanXuat, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoCongBo", SoCongBo, DbType.String, ParameterDirection.Input);
                    parameters.Add("ThoiHanTu", ThoiHanTu, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("ThoiHanDen", ThoiHanDen, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("NhanHang", NhanHang, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenSanPham", TenSanPham, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenNhaSanXuat", TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<P_CongBoMyPhamViewModel>("NganhDuoc_P_CongBoMyPham_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var p_CongBoMyPhamViewModels = datas as IList<P_CongBoMyPhamViewModel> ??
                                                          datas.ToList();
                    totalItems = p_CongBoMyPhamViewModels.FirstOrDefault() != null
                        ? p_CongBoMyPhamViewModels.First().TotalItems.Value
                        : 0;
                    return p_CongBoMyPhamViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_P_CongBoMyPham_Ins(P_CongBoMyPham model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoCongBo", model.SoCongBo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NhanHang", model.NhanHang, DbType.String, ParameterDirection.Input);
                parameters.Add("TenSanPham", model.TenSanPham, DbType.String, ParameterDirection.Input);
                parameters.Add("DangSanPhamIds", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("DangSanPhams", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("TenNhaSanXuat", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhId", model.TinhThanhId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanh", model.TinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanId", model.QuanId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Quan", model.Quan, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongId", model.PhuongId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Phuong", model.Phuong, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("Duong", model.Duong, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (iD != null)
                    return Convert.ToInt64(iD);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_UpdByID(P_CongBoMyPham model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CongBoSPMyPhamId", model.CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoCongBo", model.SoCongBo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NhanHang", model.NhanHang, DbType.String, ParameterDirection.Input);
                parameters.Add("TenSanPham", model.TenSanPham, DbType.String, ParameterDirection.Input);
                parameters.Add("DangSanPhamIds", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("DangSanPhams", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("TenNhaSanXuat", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhId", model.TinhThanhId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanh", model.TinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanId", model.QuanId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Quan", model.Quan, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongId", model.PhuongId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Phuong", model.Phuong, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("Duong", model.Duong, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_P_CongBoMyPham_DelByHoSoID(long HoSoID, long CongBoSPMyPhamId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CongBoSPMyPhamId", CongBoSPMyPhamId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_P_CongBoMyPham_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
