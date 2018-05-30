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
    public class CN_GDPRepository : Repository<CN_GDP>, ICN_GDPRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CN_GDP";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CN_GDPRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CN_GDP NganhDuoc_CN_GDP_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_GDP>("NganhDuoc_CN_GDP_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_GDP();
            }
        }
        public CN_GDP NganhDuoc_CN_GDP_GetByID(long THTGDPId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPId", THTGDPId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_GDP>("NganhDuoc_CN_GDP_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_GDP();
            }
        }
        public IEnumerable<CN_GDPViewModel> NganhDuoc_CN_GDP_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
              , string TenCoSo, string SoDKKD, int pageIndex, int pageSize, out int totalItems)
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

                    var datas = conn.Query<CN_GDPViewModel>("NganhDuoc_CN_GDP_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var cN_GDPViewModels = datas as IList<CN_GDPViewModel> ??
                                                          datas.ToList();
                    totalItems = cN_GDPViewModels.FirstOrDefault() != null
                        ? cN_GDPViewModels.First().TotalItems.Value
                        : 0;
                    return cN_GDPViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_CN_GDP_Ins(CN_GDP model, IDbConnection conns, IDbTransaction trans)
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

                var iD = conns.ExecuteScalar("NganhDuoc_CN_GDP_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public long NganhDuoc_CN_GDP_UpdByID(CN_GDP model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("THTGDPId", model.THTGDPId, DbType.Int64, ParameterDirection.Input);
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
                var iD = conns.ExecuteScalar("NganhDuoc_CN_GDP_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_CN_GDP_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GDP_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GDP_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                conns.ExecuteScalar("NganhDuoc_CN_GDP_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_GDP_DelByTHTGDPID(long THTGDPID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("THTGDPId", THTGDPID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_GDP_DelByTHTGDPID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_InDeXuat(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CN_GDP_InDeXuat", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CN_GDP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_InChungChi(long Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("THTGDPId", Id, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("NganhDuoc_CN_GDP_InChungChi", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "CN_GDP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_XuatDanhSach(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
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
                    var datas = conn.ExecuteReader("NganhDuoc_CN_GDP_XuatDanhSach", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachGDP";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DataTableViewModel();
            }
        }
        public DataTableViewModel NganhDuoc_CN_GDP_CongBoWebsite(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
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
                    var datas = conn.ExecuteReader("NganhDuoc_CN_GDP_CongBoWebsite", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "DanhSachGDP";
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
