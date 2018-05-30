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
    public class CN_GPPRepository : Repository<CN_GPP>, ICN_GPPRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CN_GPP";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CN_GPPRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CN_GPP NganhDuoc_CN_GPP_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_GPP>("NganhDuoc_CN_GPP_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_GPP();
            }
        }
        public CN_GPP NganhDuoc_CN_GPP_GetByID(long THTGPPId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("THTGPPId", THTGPPId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_GPP>("NganhDuoc_CN_GPP_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_GPP();
            }
        }
        public IEnumerable<CN_GPPViewModel> NganhDuoc_CN_GPP_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCoSo,string SoDKKD, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenCoSo", TenCoSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoDKKD", SoDKKD, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CN_GPPViewModel>("NganhDuoc_CN_GPP_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var cN_GPPViewModels = datas as IList<CN_GPPViewModel> ??
                                                          datas.ToList();
                    totalItems = cN_GPPViewModels.FirstOrDefault() != null
                        ? cN_GPPViewModels.First().TotalItems.Value
                        : 0;
                    return cN_GPPViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_CN_GPP_Ins(CN_GPP model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapChungNhan", model.NgayCapChungNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NguoiKyQuyetDinh", model.NguoiKyQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("TenCoSo", model.TenCoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
                parameters.Add("TrucThuoc", model.TrucThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhCSId", model.TinhThanhCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhCS", model.TinhThanhCS, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanCSId", model.QuanCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanCS", model.QuanCS, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongCSId", model.PhuongCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongCS", model.PhuongCS, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaCS", model.SoNhaCS, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiCS", model.DiaChiCS, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("ChungChiDuocId", model.ChungChiDuocId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViKinhDoanhIds", model.PhamViKinhDoanhIds, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViKinhDoanhs", model.PhamViKinhDoanhs, DbType.String, ParameterDirection.Input);
                parameters.Add("TruongDoanKiemTra", model.TruongDoanKiemTra, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayKiemTra", model.NgayKiemTra, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UuDiem", model.UuDiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TonTai", model.TonTai, DbType.String, ParameterDirection.Input);
                parameters.Add("KetLuan", model.KetLuan, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_CN_GPP_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public long NganhDuoc_CN_GPP_UpdByID(CN_GPP model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("THTGPPId", model.THTGPPId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapChungNhan", model.NgayCapChungNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NguoiKyQuyetDinh", model.NguoiKyQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("TenCoSo", model.TenCoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
                parameters.Add("TrucThuoc", model.TrucThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhCSId", model.TinhThanhCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhCS", model.TinhThanhCS, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanCSId", model.QuanCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanCS", model.QuanCS, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongCSId", model.PhuongCSId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongCS", model.PhuongCS, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaCS", model.SoNhaCS, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiCS", model.DiaChiCS, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("ChungChiDuocId", model.ChungChiDuocId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoChungChi", model.SoChungChi, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViKinhDoanhIds", model.PhamViKinhDoanhIds, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViKinhDoanhs", model.PhamViKinhDoanhs, DbType.String, ParameterDirection.Input);
                parameters.Add("TruongDoanKiemTra", model.TruongDoanKiemTra, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayKiemTra", model.NgayKiemTra, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UuDiem", model.UuDiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TonTai", model.TonTai, DbType.String, ParameterDirection.Input);
                parameters.Add("KetLuan", model.KetLuan, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_CN_GPP_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_CN_GPP_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GPP_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GPP_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GPP_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GPP_DelByTHTGPPID(long THTGPPID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("THTGPPId", THTGPPID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GPP_DelByTHTGPPID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public DataTableViewModel NganhDuoc_CN_GPP_InDeXuat(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGPPId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CN_GPP_InDeXuat", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CN_GPP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_InChungChi(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGPPId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CN_GPP_InChungChi", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CN_GPP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_XuatDanhSach(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
           , string TenCoSo, string SoDKKD)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenCoSo", TenCoSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoDKKD", SoDKKD, DbType.String, ParameterDirection.Input);
                    var datas = conn.ExecuteReader("NganhDuoc_CN_GPP_XuatDanhSach", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachGPP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DataTableViewModel();
            }
        }
        public DataTableViewModel NganhDuoc_CN_GPP_CongBoWebsite(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
        , string TenCoSo, string SoDKKD)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenCoSo", TenCoSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoDKKD", SoDKKD, DbType.String, ParameterDirection.Input);
                    var datas = conn.ExecuteReader("NganhDuoc_CN_GPP_CongBoWebsite", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachGPP";
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
