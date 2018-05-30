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
using System.Reflection;

namespace Data.Core.Repositories
{

    public class HoSoTiepNhanRepository : Repository<HoSoTiepNhan>, IHoSoTiepNhanRepository
    {
        private readonly ILog _logger;
        private const string TableName = "HoSoTiepNhan";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public HoSoTiepNhanRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public HoSoTiepNhan MotCua_HoSoTiepNhan_GetByHoSoId(long hoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", hoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<HoSoTiepNhan>("MotCua_HoSoTiepNhan_GetByHoSoId", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new HoSoTiepNhan();
            }
        }
        public string MotCua_GenSoBienNhanByThuTucID(long ThuTucID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("ThuTucID", ThuTucID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.ExecuteScalar("MotCua_GenSoBienNhan", parameters
                        , commandType: CommandType.StoredProcedure);
                    return Convert.ToString(retval);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return "";
            }
        }
        public bool MotCua_KiemTraSoBienNhan(string SoBienNhan)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoBienNhan", SoBienNhan, DbType.String, ParameterDirection.Input);

                    var retval = conn.ExecuteScalar("MotCua_KiemTraSoBienNhan", parameters
                        , commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(retval);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public long MotCua_HoSoTiepNhan_Ins(HoSoTiepNhan model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayNhan", model.NgayNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayHenTra", model.NgayHenTra, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LinhVucID", model.LinhVucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenLinhVuc", model.TenLinhVuc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenThuTuc", model.TenThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("HoTenNguoiNop", model.HoTenNguoiNop, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinhID", model.GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhID", model.TinhThanhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTinhThanh", model.TenTinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHuyenID", model.QuanHuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenQuanHuyen", model.TenQuanHuyen, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongXaID", model.PhuongXaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenPhuongXa", model.TenPhuongXa, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("LoaiGiayToID", model.LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenLoaiGiayTo", model.TenLoaiGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiHoSoID", model.TrangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTrangThaiHoSo", model.TenTrangThaiHoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HienNayTinhThanhID", model.HienNayTinhThanhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenTinhThanh", model.HienNayTenTinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNayQuanHuyenID", model.HienNayQuanHuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenQuanHuyen", model.HienNayTenQuanHuyen, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNayPhuongXaID", model.HienNayPhuongXaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenPhuongXa", model.HienNayTenPhuongXa, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNaySoNha", model.HienNaySoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("LePhi", model.LePhi, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrinhDoChuyenMonID", model.TrinhDoChuyenMonID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTrinhDoChuyenMon", model.TenTrinhDoChuyenMon, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhThucToChucID", model.HinhThucToChucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenHinhThucToChuc", model.TenHinhThucToChuc, DbType.String, ParameterDirection.Input);
                parameters.Add("NoiNhanKetQuaID", model.NoiNhanKetQuaID, DbType.Int32, ParameterDirection.Input);
                var hoSoId = conns.ExecuteScalar("MotCua_HoSoTiepNhan_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (hoSoId != null)
                    return Convert.ToInt64(hoSoId);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_GetByCondition(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? userDangNhapID, int? trangThaiHoSoID,
            int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("linhVucID", linhVucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("thuTucID", thuTucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("soBienNhan", soBienNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("hoTenNguoiNop", hoTenNguoiNop, DbType.String, ParameterDirection.Input);
                    parameters.Add("soGiayTo", soGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("userDangNhapID", userDangNhapID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("trangThaiHoSoID", trangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<HoSoTiepNhanViewModel>("MotCua_HoSoTiepNhan_GetByCondition",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var hoSoTiepNhanViewModels = datas as IList<HoSoTiepNhanViewModel> ??
                                                          datas.ToList();
                    totalItems = hoSoTiepNhanViewModels.FirstOrDefault() != null
                        ? hoSoTiepNhanViewModels.First().TotalItems.Value
                        : 0;
                    return hoSoTiepNhanViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_XuatDanhSach(int? linhVucID, int? thuTucID, string soBienNhan,
           DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? userDangNhapID, int? trangThaiHoSoID, string listHoSoID)
        {
            try
            {

                using (var conn = Connection)
                {
                    conn.Open();
                
                    var parameters = new DynamicParameters();
                    parameters.Add("linhVucID", linhVucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("thuTucID", thuTucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("soBienNhan", soBienNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("hoTenNguoiNop", hoTenNguoiNop, DbType.String, ParameterDirection.Input);
                    parameters.Add("soGiayTo", soGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("userDangNhapID", userDangNhapID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("trangThaiHoSoID", trangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("listHoSoID", listHoSoID, DbType.String, ParameterDirection.Input);
                    var datas = conn.ExecuteReader("MotCua_HoSoTiepNhan_XuatDanhSach",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachHoSo";
                    return dt;

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_InBienNhan(long hoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", hoSoId, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("MotCua_HoSoTiepNhan_InBienNhan", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "HoSoTiepNhan";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(long hoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
               
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", hoSoId, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "HoSoTiepNhan";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_Search(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int? trangThaiHoSoID,
            int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("linhVucID", linhVucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("thuTucID", thuTucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("soBienNhan", soBienNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("hoTenNguoiNop", hoTenNguoiNop, DbType.String, ParameterDirection.Input);
                    parameters.Add("soGiayTo", soGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("trangThaiHoSoID", trangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<HoSoTiepNhanViewModel>("MotCua_HoSoTiepNhan_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var hoSoTiepNhanViewModels = datas as IList<HoSoTiepNhanViewModel> ??
                                                          datas.ToList();
                    totalItems = hoSoTiepNhanViewModels.FirstOrDefault() != null
                        ? hoSoTiepNhanViewModels.First().TotalItems.Value
                        : 0;
                    return hoSoTiepNhanViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public IEnumerable<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_SearchFromHomePage(string traCuu, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("traCuu", traCuu, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<HoSoTiepNhanViewModel>("MotCua_HoSoTiepNhan_SearchFromHomePage",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var hoSoTiepNhanViewModels = datas as IList<HoSoTiepNhanViewModel> ??
                                                          datas.ToList();
                    totalItems = hoSoTiepNhanViewModels.FirstOrDefault() != null
                        ? hoSoTiepNhanViewModels.First().TotalItems.Value
                        : 0;
                    return hoSoTiepNhanViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public bool MotCua_HoSoTiepNhan_UpdByHoSoID(HoSoTiepNhan model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayNhan", model.NgayNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayHenTra", model.NgayHenTra, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LinhVucID", model.LinhVucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenLinhVuc", model.TenLinhVuc, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenThuTuc", model.TenThuTuc, DbType.String, ParameterDirection.Input);
                parameters.Add("HoTenNguoiNop", model.HoTenNguoiNop, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinhID", model.GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhID", model.TinhThanhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTinhThanh", model.TenTinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanHuyenID", model.QuanHuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenQuanHuyen", model.TenQuanHuyen, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongXaID", model.PhuongXaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenPhuongXa", model.TenPhuongXa, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("LoaiGiayToID", model.LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenLoaiGiayTo", model.TenLoaiGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiHoSoID", model.TrangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTrangThaiHoSo", model.TenTrangThaiHoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HienNayTinhThanhID", model.HienNayTinhThanhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenTinhThanh", model.HienNayTenTinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNayQuanHuyenID", model.HienNayQuanHuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenQuanHuyen", model.HienNayTenQuanHuyen, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNayPhuongXaID", model.HienNayPhuongXaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("HienNayTenPhuongXa", model.HienNayTenPhuongXa, DbType.String, ParameterDirection.Input);
                parameters.Add("HienNaySoNha", model.HienNaySoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("LePhi", model.LePhi, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrinhDoChuyenMonID", model.TrinhDoChuyenMonID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTrinhDoChuyenMon", model.TenTrinhDoChuyenMon, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhThucToChucID", model.HinhThucToChucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenHinhThucToChuc", model.TenHinhThucToChuc, DbType.String, ParameterDirection.Input);
                parameters.Add("NoiNhanKetQuaID", model.NoiNhanKetQuaID, DbType.Int32, ParameterDirection.Input);
                conns.ExecuteScalar("MotCua_HoSoTiepNhan_UpdByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID(long HoSoID, long QuaTrinhXuLyHienTaiID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("QuaTrinhXuLyHienTaiID", QuaTrinhXuLyHienTaiID, DbType.Int64, ParameterDirection.Input);
                conns.ExecuteScalar("MotCua_HoSoTiepNhan_UpdQuaTrinhXuLyHienTaiByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_HoSoTiepNhan_UpdTrangThaiHoSoByHoSoID(long HoSoID, int TrangThaiHoSoID, string TenTrangThaiHoSo, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("TrangThaiHoSoID", TrangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenTrangThaiHoSo", TenTrangThaiHoSo, DbType.String, ParameterDirection.Input);
                conns.ExecuteScalar("MotCua_HoSoTiepNhan_UpdTrangThaiHoSoByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_HoSoTiepNhan_UpdDaCapByHoSoID(long HoSoID, int TrangThaiHoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("TrangThaiHoSoID", TrangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                conns.ExecuteScalar("MotCua_HoSoTiepNhan_UpdDaCapByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool MotCua_HoSoTiepNhan_DelByHoSoID(long HoSoID, int? UserID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UserID", HoSoID, DbType.Int32, ParameterDirection.Input);
                conns.ExecuteScalar("MotCua_HoSoTiepNhan_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
