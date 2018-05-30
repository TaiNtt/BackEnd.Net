using System;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Configuration;
using Business.Entities.ViewModels;

namespace Data.Core.Repositories
{
    public class CC_DuocRepository : Repository<CC_Duoc>, ICC_DuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CC_Duoc";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CC_DuocRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CC_Duoc NganhDuoc_CC_Duoc_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CC_Duoc>("NganhDuoc_CC_Duoc_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CC_Duoc();
            }
        }

        public CC_Duoc NganhDuoc_CC_Duoc_GetByID(long ChungChiDuocID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CC_Duoc>("NganhDuoc_CC_Duoc_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CC_Duoc();
            }
        }

        public CC_Duoc NganhDuoc_CC_Duoc_GetBySoChungChi(string SoChungChi)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungChi", SoChungChi, DbType.String, ParameterDirection.Input);

                    var retval = conn.Query<CC_Duoc>("NganhDuoc_CC_Duoc_GetBySoChungChi", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<CC_DuocViewModel> NganhDuoc_CC_Duoc_Search(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungChi", SoChungChi, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoGiayTo", SoGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("lstTrangThai", lstTrangThai, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CC_DuocViewModel>("NganhDuoc_CC_Duoc_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var CC_DuocViewModels = datas as IList<CC_DuocViewModel> ??
                                                          datas.ToList();
                    totalItems = CC_DuocViewModels.FirstOrDefault() != null
                        ? CC_DuocViewModels.First().TotalItems.Value
                        : 0;
                    return CC_DuocViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public IEnumerable<CC_DuocViewModel> NganhDuoc_CC_Duoc_Lst(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
        , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungChi", SoChungChi, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoGiayTo", SoGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("TrangThai", TrangThai, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CC_DuocViewModel>("NganhDuoc_CC_Duoc_Lst",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var CC_DuocViewModels = datas as IList<CC_DuocViewModel> ??
                                                          datas.ToList();
                    totalItems = CC_DuocViewModels.FirstOrDefault() != null
                        ? CC_DuocViewModels.First().TotalItems.Value
                        : 0;
                    return CC_DuocViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public long NganhDuoc_CC_Duoc_Ins(CC_Duoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DotHoiDong", model.DotHoiDong, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHoiDong", model.NgayHoiDong, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayTrinhCap", model.NgayTrinhCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapChungChiID", model.NoiCapChungChiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayTo", model.LoaiGiayTo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_TinhID", model.ThuongTru_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_HuyenID", model.ThuongTru_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_XaID", model.ThuongTru_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_SoNha", model.ThuongTru_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_TinhID", model.ChoO_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_HuyenID", model.ChoO_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_XaID", model.ChoO_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_SoNha", model.ChoO_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhAnh", model.HinhAnh, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("DuDieuKienHanhNghe", model.DuDieuKienHanhNghe, DbType.String, ParameterDirection.Input);
                parameters.Add("AttachOriginalName", model.AttachOriginalName, DbType.String, ParameterDirection.Input);
                parameters.Add("AttachUploadName", model.AttachUploadName, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                var iD = conns.ExecuteScalar("NganhDuoc_CC_Duoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public long NganhDuoc_CC_Duoc_UpdByChungChiDuocID(CC_Duoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiDuocId", model.ChungChiDuocId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DotHoiDong", model.DotHoiDong, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHoiDong", model.NgayHoiDong, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayTrinhCap", model.NgayTrinhCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapChungChiID", model.NoiCapChungChiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayTo", model.LoaiGiayTo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_TinhID", model.ThuongTru_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_HuyenID", model.ThuongTru_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_XaID", model.ThuongTru_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_SoNha", model.ThuongTru_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_TinhID", model.ChoO_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_HuyenID", model.ChoO_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_XaID", model.ChoO_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_SoNha", model.ChoO_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhAnh", model.HinhAnh, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("DuDieuKienHanhNghe", model.DuDieuKienHanhNghe, DbType.String, ParameterDirection.Input);
                parameters.Add("AttachOriginalName", model.AttachOriginalName, DbType.String, ParameterDirection.Input);
                parameters.Add("AttachUploadName", model.AttachUploadName, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                var iD = conns.ExecuteScalar("NganhDuoc_CC_Duoc_UpdByChungChiDuocID", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhDuoc_CC_Duoc_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhDuoc_CC_Duoc_UpdDaCapByChungChiDuocID(long ChungChiDuocID, int TrangThaiGiayPhepID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiDuocID", ChungChiDuocID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_UpdDaCapByChungChiDuocID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhDuoc_CC_Duoc_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool CheckExistSoChungChi(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName, string keyCheckName)
        {
            return CheckExists(primaryKeyNameValue, keyCheckNameValue, primaryKeyName, keyCheckName);
        }

        public bool NganhDuoc_CC_Duoc_DelByChungChiDuocId(long ChungChiDuocId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ChungChiDuocId", ChungChiDuocId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CC_Duoc_DelByChungChiDuocId", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_InDeXuat(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CC_Duoc_InDeXuat", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CC_Duoc";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_InChungChi(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChungChiDuocId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CC_Duoc_InChungChi", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CC_Duoc";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_XuatDanhSach(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
        , string HoTen, string SoGiayTo, string TrangThai)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungChi", SoChungChi, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoGiayTo", SoGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("TrangThai", TrangThai, DbType.String, ParameterDirection.Input);
                    var datas = conn.ExecuteReader("NganhDuoc_CC_Duoc_XuatDanhSach", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachCCDuoc";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DataTableViewModel();
            }
        }
        public DataTableViewModel NganhDuoc_CC_Duoc_CongBoWebsite(string SoChungChi, DateTime? tuNgay, DateTime? denNgay
        , string HoTen, string SoGiayTo, string TrangThai)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungChi", SoChungChi, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoGiayTo", SoGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("TrangThai", TrangThai, DbType.String, ParameterDirection.Input);
                    var datas = conn.ExecuteReader("NganhDuoc_CC_Duoc_CongBoWebsite", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachCCDuoc";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DataTableViewModel();
            }
        }
    }
}
