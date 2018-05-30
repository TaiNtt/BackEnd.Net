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
    public class CV_XNKThuoc_PhiMauDichRepository : Repository<CV_XNKThuoc_PhiMauDich>, ICV_XNKThuoc_PhiMauDichRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CV_XNKThuoc_PhiMauDich";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CV_XNKThuoc_PhiMauDichRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CV_XNKThuoc_PhiMauDich NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CV_XNKThuoc_PhiMauDich>("NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CV_XNKThuoc_PhiMauDich();
            }
        }
        public CV_XNKThuoc_PhiMauDich NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(long XNKThuocPhiMauDichId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("XNKThuocPhiMauDichId", XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CV_XNKThuoc_PhiMauDich>("NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CV_XNKThuoc_PhiMauDich();
            }
        }
        public IEnumerable<CV_XNKThuoc_PhiMauDichViewModel> NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(string SoCongVan, DateTime? tuNgay, DateTime? denNgay
            , string HoTenNguoiNhanThuoc, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoCongVan", SoCongVan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTenNguoiNhanThuoc", HoTenNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CV_XNKThuoc_PhiMauDichViewModel>("NganhDuoc_CV_XNKThuoc_PhiMauDich_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var cV_XNKThuoc_PhiMauDichViewModels = datas as IList<CV_XNKThuoc_PhiMauDichViewModel> ??
                                                          datas.ToList();
                    totalItems = cV_XNKThuoc_PhiMauDichViewModels.FirstOrDefault() != null
                        ? cV_XNKThuoc_PhiMauDichViewModels.First().TotalItems.Value
                        : 0;
                    return cV_XNKThuoc_PhiMauDichViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_CV_XNKThuoc_PhiMauDich_Ins(CV_XNKThuoc_PhiMauDich model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayLamDonDeNghi", model.NgayLamDonDeNghi, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoCongVan", model.SoCongVan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayBanHanh", model.NgayBanHanh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.String, ParameterDirection.Input);
                parameters.Add("HoTenNguoiNhanThuoc", model.HoTenNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhNguoiNhanThuoc", model.NgaySinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinhNguoiNhanThuoc", model.ThangSinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinhNguoiNhanThuoc", model.NamSinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDuNguoiNhanThuoc", model.NgaySinhDayDuNguoiNhanThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("GioiTinhNguoiNhanThuoc", model.GioiTinhNguoiNhanThuoc, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayToNguoiNhanThuocId", model.LoaiGiayToNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayToNguoiNhanThuoc", model.SoGiayToNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayToNguoiNhanThuoc", model.NgayCapGiayToNguoiNhanThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToNguoiNhanThuocId", model.NoiCapGiayToNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToNguoiNhanThuoc", model.NoiCapGiayToNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiNhanThuocId", model.TinhThanhTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiNhanThuoc", model.TinhThanhTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiNhanThuocId", model.QuanTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiNhanThuoc", model.QuanTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiNhanThuocId", model.PhuongTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiNhanThuoc", model.PhuongTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaTTNguoiNhanThuoc", model.SoNhaTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongTTNguoiNhanThuoc", model.DuongTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiTTNguoiNhanThuoc", model.DiaChiTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiNhanThuocId", model.TinhThanhHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiNhanThuoc", model.TinhThanhHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiNhanThuocId", model.QuanHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiNhanThuoc", model.QuanHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiNhanThuocId", model.PhuongHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiNhanThuoc", model.PhuongHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaHTNguoiNhanThuoc", model.SoNhaHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongHTNguoiNhanThuoc", model.DuongHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiHTNguoiNhanThuoc", model.DiaChiHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoaiNguoiNhanThuoc", model.SoDienThoaiNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailNguoiNhanThuoc", model.EmailNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TGSongTaiVN", model.TGSongTaiVN, DbType.String, ParameterDirection.Input);
                parameters.Add("LaNguoiSuDung", model.LaNguoiSuDung, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("HoTenNguoiSDThuoc", model.HoTenNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhNguoiSDThuoc", model.NgaySinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinhNguoiSDThuoc", model.ThangSinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinhNguoiSDThuoc", model.NamSinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDuNguoiSDThuoc", model.NgaySinhDayDuNguoiSDThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiSDThuocId", model.TinhThanhTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiSDThuoc", model.TinhThanhTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiSDThuocId", model.QuanTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiSDThuoc", model.QuanTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiSDThuocId", model.PhuongTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiSDThuoc", model.PhuongTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaTTNguoiSDThuoc", model.SoNhaTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongTTNguoiSDThuoc", model.DuongTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiTTNguoiSDThuoc", model.DiaChiTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiSDThuocId", model.TinhThanhHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiSDThuoc", model.TinhThanhHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiSDThuocId", model.QuanHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiSDThuoc", model.QuanHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiSDThuocId", model.PhuongHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiSDThuoc", model.PhuongHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaHTNguoiSDThuoc", model.SoNhaHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongHTNguoiSDThuoc", model.DuongHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiHTNguoiSDThuoc", model.DiaChiHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdByID(CV_XNKThuoc_PhiMauDich model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("XNKThuocPhiMauDichId", model.XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayLamDonDeNghi", model.NgayLamDonDeNghi, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoCongVan", model.SoCongVan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayBanHanh", model.NgayBanHanh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.String, ParameterDirection.Input);
                parameters.Add("HoTenNguoiNhanThuoc", model.HoTenNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhNguoiNhanThuoc", model.NgaySinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinhNguoiNhanThuoc", model.ThangSinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinhNguoiNhanThuoc", model.NamSinhNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDuNguoiNhanThuoc", model.NgaySinhDayDuNguoiNhanThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("GioiTinhNguoiNhanThuoc", model.GioiTinhNguoiNhanThuoc, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayToNguoiNhanThuocId", model.LoaiGiayToNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayToNguoiNhanThuoc", model.SoGiayToNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayToNguoiNhanThuoc", model.NgayCapGiayToNguoiNhanThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToNguoiNhanThuocId", model.NoiCapGiayToNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiCapGiayToNguoiNhanThuoc", model.NoiCapGiayToNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiNhanThuocId", model.TinhThanhTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiNhanThuoc", model.TinhThanhTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiNhanThuocId", model.QuanTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiNhanThuoc", model.QuanTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiNhanThuocId", model.PhuongTTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiNhanThuoc", model.PhuongTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaTTNguoiNhanThuoc", model.SoNhaTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongTTNguoiNhanThuoc", model.DuongTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiTTNguoiNhanThuoc", model.DiaChiTTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiNhanThuocId", model.TinhThanhHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiNhanThuoc", model.TinhThanhHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiNhanThuocId", model.QuanHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiNhanThuoc", model.QuanHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiNhanThuocId", model.PhuongHTNguoiNhanThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiNhanThuoc", model.PhuongHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaHTNguoiNhanThuoc", model.SoNhaHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongHTNguoiNhanThuoc", model.DuongHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiHTNguoiNhanThuoc", model.DiaChiHTNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoaiNguoiNhanThuoc", model.SoDienThoaiNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailNguoiNhanThuoc", model.EmailNguoiNhanThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TGSongTaiVN", model.TGSongTaiVN, DbType.String, ParameterDirection.Input);
                parameters.Add("LaNguoiSuDung", model.LaNguoiSuDung, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("HoTenNguoiSDThuoc", model.HoTenNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhNguoiSDThuoc", model.NgaySinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThangSinhNguoiSDThuoc", model.ThangSinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NamSinhNguoiSDThuoc", model.NamSinhNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinhDayDuNguoiSDThuoc", model.NgaySinhDayDuNguoiSDThuoc, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiSDThuocId", model.TinhThanhTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhTTNguoiSDThuoc", model.TinhThanhTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiSDThuocId", model.QuanTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanTTNguoiSDThuoc", model.QuanTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiSDThuocId", model.PhuongTTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongTTNguoiSDThuoc", model.PhuongTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaTTNguoiSDThuoc", model.SoNhaTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongTTNguoiSDThuoc", model.DuongTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiTTNguoiSDThuoc", model.DiaChiTTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiSDThuocId", model.TinhThanhHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhHTNguoiSDThuoc", model.TinhThanhHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiSDThuocId", model.QuanHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanHTNguoiSDThuoc", model.QuanHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiSDThuocId", model.PhuongHTNguoiSDThuocId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongHTNguoiSDThuoc", model.PhuongHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaHTNguoiSDThuoc", model.SoNhaHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DuongHTNguoiSDThuoc", model.DuongHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiHTNguoiSDThuoc", model.DiaChiHTNguoiSDThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("Active", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(long HoSoID, long XNKThuocPhiMauDichId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XNKThuocPhiMauDichId", XNKThuocPhiMauDichId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
