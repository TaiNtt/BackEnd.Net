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
    public class DK_HoiThaoGioiThieuThuocRepository : Repository<DK_HoiThaoGioiThieuThuoc>, IDK_HoiThaoGioiThieuThuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DK_HoiThaoGioiThieuThuoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public DK_HoiThaoGioiThieuThuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public DK_HoiThaoGioiThieuThuoc NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<DK_HoiThaoGioiThieuThuoc>("NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DK_HoiThaoGioiThieuThuoc();
            }
        }
        public DK_HoiThaoGioiThieuThuoc NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(long HoiThaoThuocID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoiThaoThuocID", HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<DK_HoiThaoGioiThieuThuoc>("NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DK_HoiThaoGioiThieuThuoc();
            }
        }
        public IEnumerable<DK_HoiThaoGioiThieuThuocViewModel> NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, string HoTen, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoTiepNhan", SoTiepNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenDonVi", TenDonVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DK_HoiThaoGioiThieuThuocViewModel>("NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var hoiThaoGioiThieuThuocViewModels = datas as IList<DK_HoiThaoGioiThieuThuocViewModel> ??
                                                          datas.ToList();
                    totalItems = hoiThaoGioiThieuThuocViewModels.FirstOrDefault() != null
                        ? hoiThaoGioiThieuThuocViewModels.First().TotalItems.Value
                        : 0;
                    return hoiThaoGioiThieuThuocViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_DK_HoiThaoGioiThieuThuoc_Ins(DK_HoiThaoGioiThieuThuoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayDangKy", model.SoGiayDangKy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGPHD", model.SoGPHD, DbType.String, ParameterDirection.Input);
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
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinh", model.ThangSinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinh", model.NamSinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDu", model.NgaySinhDayDu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayToId", model.LoaiGiayToId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToId", model.NoiCapGiayToId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoaiNCTN", model.SoDienThoaiNCTN, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailNCTN", model.EmailNCTN, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaDiemToChuc", model.DiaDiemToChuc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianToChuc", model.ThoiGianToChuc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdByID(DK_HoiThaoGioiThieuThuoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoiThaoThuocID", model.HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayDangKy", model.SoGiayDangKy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGPHD", model.SoGPHD, DbType.String, ParameterDirection.Input);
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
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinh", model.ThangSinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinh", model.NamSinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDu", model.NgaySinhDayDu, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayToId", model.LoaiGiayToId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToId", model.NoiCapGiayToId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoaiNCTN", model.SoDienThoaiNCTN, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailNCTN", model.EmailNCTN, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaDiemToChuc", model.DiaDiemToChuc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianToChuc", model.ThoiGianToChuc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(long HoSoID, long HoiThaoThuocID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoiThaoThuocID", HoiThaoThuocID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
