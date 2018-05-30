using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Entities.ViewModels;
using Core.Common.Utilities;
using Business.Entities.BindingModels;

namespace Data.Core.Repositories
{
    public class ThuTucHanhChinhRepository : Repository<ThuTucHanhChinh>, IThuTucHanhChinhRepository
    {
        private readonly ILog _logger;
        private const string TableName = "ThuTucHanhChinh";

        public ThuTucHanhChinhRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        public ThuTucHanhChinhEditViewModel GetThuTucHanhChinhById(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("Id", id, DbType.String, ParameterDirection.Input, 128);
                    var dataMultiple = conn.QueryMultiple("TTHC_ThuTucHanhChinh_ById_Get", parameters,
                        commandType: CommandType.StoredProcedure);

                    var thutuchanhchinh = dataMultiple.Read<ThuTucHanhChinh>();
                    var maudons = dataMultiple.Read<TTHC_MauDonToKhai>();
                    var lienthongs = dataMultiple.Read<TTHC_LienThong>();
                    var capdonvis = dataMultiple.Read<DanhMuc>();
                    var donvis = dataMultiple.Read<DanhMuc>();
                    var doituongs = dataMultiple.Read<DanhMuc>();
                    var dvctructuyens = dataMultiple.Read<DanhMuc>();
                    var linhvucs = dataMultiple.Read<DanhMuc>();

                    var result = new ThuTucHanhChinhEditViewModel
                    {
                        ThuTucHanhChinh = thutuchanhchinh.FirstOrDefault(),
                        MauDons = maudons,
                        LienThongs = lienthongs,
                        CapDonVis = capdonvis,
                        DonVis = donvis,
                        DoiTuongs = doituongs,
                        DvcTrucTuyens = dvctructuyens,
                        LinhVucs = linhvucs
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }

        }

        public List<HoSoKemTheoViewModel> GetHoSoKemTheoByPaged(string tenHoSoKemTheo,string linhVucId, int pageSize, int pageIndex)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("TenHoSoKemTheo", tenHoSoKemTheo, DbType.String, ParameterDirection.Input, 265);
                    parameters.Add("LinhVucId", linhVucId, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    var data = conn.Query<HoSoKemTheoViewModel>("TTHC_DM_HoSoKemTheo_ByPaged", parameters,
                        commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<TTHC_BieuDoThongKe> GetBieuDoThongKe(string chartKey)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ChartKey", chartKey, DbType.String, ParameterDirection.Input, 265);
                    var result = conn.Query<TTHC_BieuDoThongKe>("TTHC_BieuDoThongKe_Get", parameters,
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByDongBoPaged(string tenThuTuc,
            bool? conHieuLuc,
            bool? hetHieuLuc, bool? congKhai, bool? khongCongKhai, bool? tthcDacThu, string coQuanThucHien,
            string linhVucId, int pageIndex, int pageSize,
            out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("TenThuTuc", tenThuTuc, DbType.String, ParameterDirection.Input, 256);
                    parameters.Add("ConHieuLuc", conHieuLuc, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("HetHieuLuc", hetHieuLuc, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("CongKhai", congKhai, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("KhongCongKhai", khongCongKhai, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("TTHCDacThu", tthcDacThu, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("CoQuanThucHien", coQuanThucHien, DbType.String, ParameterDirection.Input, 500);
                    parameters.Add("LinhVucId", linhVucId, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<ThuTucHanhChinhDongBoViewModel>("TTHC_ThuTucHanhChinh_ByDongBo_GetPaged",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var thuTucHanhChinhDongBoViewModels = datas as IList<ThuTucHanhChinhDongBoViewModel> ??
                                                          datas.ToList();
                    totalItems = thuTucHanhChinhDongBoViewModels.FirstOrDefault() != null
                        ? thuTucHanhChinhDongBoViewModels.First().TotalItems
                        : 0;
                    return thuTucHanhChinhDongBoViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public IEnumerable<DanhMuc> GetThuTucHanhChinhByLinhVucId(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("id", id, DbType.String, ParameterDirection.Input, 128);
                    var result = conn.Query<DanhMuc>("TTHC_ThuTucHanhChinh_ByLinhVucId_Get", parameters,
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMuc> GetThuTucHanhChinhByDonViId(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("id", id, DbType.String, ParameterDirection.Input, 128);
                    var result = conn.Query<DanhMuc>("TTHC_ThuTucHanhChinh_ByDonViId_Get", parameters,
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMuc> GetDonViByCapDonViId(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("id", id, DbType.String, ParameterDirection.Input, 128);
                    var result = conn.Query<DanhMuc>("TTHC_DMDonVi_ByCapDonViId_Get", parameters,
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMuc> GetLinhVucByDonViId(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("id", id, DbType.String, ParameterDirection.Input, 128);
                    var result = conn.Query<DanhMuc>("TTHC_LinhVuc_ByDonViId_Get", parameters,
                        commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new List<DanhMuc>();
            }
        }

        public string InsThuTucHanhChinh(TTHCEditBindingModel model)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("Id", model.ThucTucHanhChinh.Id, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenThuTuc", model.ThucTucHanhChinh.TenThuTuc, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("MaTTHC", model.ThucTucHanhChinh.MaTTHC, DbType.String, ParameterDirection.Input);
                    parameters.Add("MaTTHC_Bo", model.ThucTucHanhChinh.MaTTHC_Bo, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("CapDonViID", model.ThucTucHanhChinh.CapDonViID, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("DonViID", model.ThucTucHanhChinh.DonViID, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenDonVi", model.ThucTucHanhChinh.TenDonVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("LinhVucID", model.ThucTucHanhChinh.LinhVucID, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LinhVuc", model.ThucTucHanhChinh.LinhVuc, DbType.String, ParameterDirection.Input);
                    parameters.Add("CongKhai", model.ThucTucHanhChinh.CongKhai, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("TTHCDacThu", model.ThucTucHanhChinh.TTHCDacThu, DbType.Boolean,
                        ParameterDirection.Input);
                    parameters.Add("CoQuanThucHien", model.ThucTucHanhChinh.CoQuanThucHien, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("CoQuanQD", model.ThucTucHanhChinh.CoQuanQD, DbType.String, ParameterDirection.Input);
                    parameters.Add("CoQuanPhoiHop", model.ThucTucHanhChinh.CoQuanPhoiHop, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("CoQuanUyQuyen", model.ThucTucHanhChinh.CoQuanUyQuyen, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("DiaChiTiepNhan", model.ThucTucHanhChinh.DiaChiTiepNhan, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("CachThucTH", model.ThucTucHanhChinh.CachThucTH, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("ThanhPhanHoSo", model.ThucTucHanhChinh.ThanhPhanHoSo, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("DoiTuongThucHien", model.ThucTucHanhChinh.DoiTuongThucHien, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("ThoiHanGiaiQuyet", model.ThucTucHanhChinh.ThoiHanGiaiQuyet, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TrinhTuThucHien", model.ThucTucHanhChinh.TrinhTuThucHien, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("PhamVi", model.ThucTucHanhChinh.PhamVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("KetQuaThucHien", model.ThucTucHanhChinh.KetQuaThucHien, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LePhi", model.ThucTucHanhChinh.LePhi, DbType.String, ParameterDirection.Input);
                    parameters.Add("SoQuyetDinh", model.ThucTucHanhChinh.SoQuyetDinh, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("NgayQuyetDinh", model.ThucTucHanhChinh.NgayQuyetDinh, DbType.DateTime,
                        ParameterDirection.Input);
                    parameters.Add("SoBoHS", model.ThucTucHanhChinh.SoBoHS, DbType.String, ParameterDirection.Input);
                    parameters.Add("LVBiSuaBoSungKey", model.ThucTucHanhChinh.LVBiSuaBoSungKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVBiSuaBoSungName", model.ThucTucHanhChinh.LVBiSuaBoSungName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCBiSuaBoSungKey", model.ThucTucHanhChinh.TTHCBiSuaBoSungKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCBiSuaBoSungName", model.ThucTucHanhChinh.TTHCBiSuaBoSungName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVHienTaiKey", model.ThucTucHanhChinh.LVHienTaiKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVHienTaiName", model.ThucTucHanhChinh.LVHienTaiName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCHienTaiKey", model.ThucTucHanhChinh.TTHCHienTaiKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCHienTaiName", model.ThucTucHanhChinh.TTHCHienTaiName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVSuaBoSungKey", model.ThucTucHanhChinh.LVSuaBoSungKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVSuaBoSungName", model.ThucTucHanhChinh.LVSuaBoSungName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCSuaBoSungKey", model.ThucTucHanhChinh.TTHCSuaBoSungKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCSuaBoSungName", model.ThucTucHanhChinh.TTHCSuaBoSungName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVBiThayTheKey", model.ThucTucHanhChinh.LVBiThayTheKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVBiThayTheName", model.ThucTucHanhChinh.LVBiThayTheName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCBiThayTheKey", model.ThucTucHanhChinh.TTHCBiThayTheKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCBiThayTheName", model.ThucTucHanhChinh.TTHCBiThayTheName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVThayTheKey", model.ThucTucHanhChinh.LVThayTheKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("LVThayTheName", model.ThucTucHanhChinh.LVThayTheName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCThayTheKey", model.ThucTucHanhChinh.TTHCThayTheKey, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("TTHCThayTheName", model.ThucTucHanhChinh.TTHCThayTheName, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("CanCuPhapLy", model.ThucTucHanhChinh.CanCuPhapLy, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("YeuCauDieuKien", model.ThucTucHanhChinh.YeuCauDieuKien, DbType.String,
                        ParameterDirection.Input);
                    parameters.Add("NgayCoHieuLuc", model.ThucTucHanhChinh.NgayCoHieuLuc, DbType.DateTime,
                        ParameterDirection.Input);
                    parameters.Add("NgayHetHieuLuc", model.ThucTucHanhChinh.NgayHetHieuLuc, DbType.DateTime,
                        ParameterDirection.Input);
                    parameters.Add("DVBCCongIch", model.ThucTucHanhChinh.DVBCCongIch, DbType.Boolean,
                        ParameterDirection.Input);
                    parameters.Add("CongKhaiCongTT", model.ThucTucHanhChinh.CongKhaiCongTT, DbType.Boolean,
                        ParameterDirection.Input);
                    parameters.Add("DVCTrucTuyen", model.ThucTucHanhChinh.DVCTrucTuyen, DbType.Int32,
                        ParameterDirection.Input);
                    parameters.Add("IsActive", model.ThucTucHanhChinh.IsActive, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("CreatedUserID", model.ThucTucHanhChinh.CreatedUserID, DbType.Int32,
                        ParameterDirection.Input);
                    parameters.Add("CreatedDate", model.ThucTucHanhChinh.CreatedDate, DbType.DateTime,
                        ParameterDirection.Input);
                    parameters.Add("LastUpdUserID", model.ThucTucHanhChinh.LastUpdUserID, DbType.Int32,
                        ParameterDirection.Input);
                    parameters.Add("LastUpdDate", model.ThucTucHanhChinh.LastUpdDate, DbType.DateTime,
                        ParameterDirection.Input);
                    parameters.Add("IsUpdate", model.ThucTucHanhChinh.IsUpdate, DbType.Boolean, ParameterDirection.Input);
                    parameters.AddDynamicParams(new { LienThong = model.LienThongs.ToDataTable().AsTableValuedParameter() });
                    parameters.AddDynamicParams(new { MauDonToKhai =model.MauDons.ToDataTable().AsTableValuedParameter()});
                    parameters.AddDynamicParams(new { HoSoKemTheo =model.HoSoKemTheos.ToDataTable().AsTableValuedParameter()});
                    var id = conn.ExecuteScalar("TTHC_ThuTucHanhChinh_InsUpd", parameters,
                        commandType: CommandType.StoredProcedure);
                    return id.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByUserDonViPaged(string tenThuTuc,
            bool? congKhai, bool? khongCongKhai, bool? buuChinhCongIch, int? dichVuCongCap, string linhVucId,
            int? userId, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("TenThuTuc", tenThuTuc, DbType.String, ParameterDirection.Input, 256);
                    parameters.Add("CongKhai", congKhai, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("KhongCongKhai", khongCongKhai, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("DVBCCongIch", buuChinhCongIch, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("DVCTrucTuyen", dichVuCongCap, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("LinhVucId", linhVucId, DbType.String, ParameterDirection.Input);
                    parameters.Add("UserId", userId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<ThuTucHanhChinhDongBoViewModel>("TTHC_ThuTucHanhChinh_ByUserDonVi_GetPaged",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var thuTucHanhChinhDongBoViewModels = datas as IList<ThuTucHanhChinhDongBoViewModel> ??
                                                          datas.ToList();
                    totalItems = thuTucHanhChinhDongBoViewModels.FirstOrDefault() != null
                        ? thuTucHanhChinhDongBoViewModels.First().TotalItems
                        : 0;
                    return thuTucHanhChinhDongBoViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public IEnumerable<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhMoiByDongBoPaged(string tenThuTuc, string capDonVi, string coQuanThucHien, string linhVucId, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("TenThuTuc", tenThuTuc, DbType.String, ParameterDirection.Input, 256);
                    parameters.Add("CapDonViId", capDonVi, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("CoQuanThucHien", coQuanThucHien, DbType.String, ParameterDirection.Input, 500);
                    parameters.Add("LinhVucId", linhVucId, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<ThuTucHanhChinhDongBoViewModel>("TTHC_ThuTucHanhChinhMoi_ByDongBo_GetPaged", parameters,
                        commandType: CommandType.StoredProcedure);

                    var thuTucHanhChinhDongBoViewModels = datas as IList<ThuTucHanhChinhDongBoViewModel> ?? datas.ToList();
                    totalItems = thuTucHanhChinhDongBoViewModels.FirstOrDefault() != null ? thuTucHanhChinhDongBoViewModels.First().TotalItems : 0;
                    return thuTucHanhChinhDongBoViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public int UpdThuTucHanhChinhCongKhai(List<TTHC_DonVi> model)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { TTHCDonVi = model.ToDataTable().AsTableValuedParameter() });
                    conn.Query("TTHC_ThuTucHanhChinh_CongKhai_Upd", parameters, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public int UpdTTHCSoQuyetDinh(List<TTHCUpdSoQuyetDinhBindingModel> model)
        {
            try
            {
                using (IDbConnection conn=Connection)
                {
                    conn.Open();
                    var parameters=new DynamicParameters();
                    parameters.AddDynamicParams(new { TTHCCapNhatQuyetDinh =model.ToDataTable().AsTableValuedParameter()});
                    conn.Query("TTHC_ThuTucHanhChinh_CapNhatQuyetDinh_Upd", parameters, commandType: CommandType.StoredProcedure);
                    return 1;
                }
               
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public int UpdThuTucHanhChinhBuuChinhCongIch(List<TTHC_DonVi> model)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { TTHCDonVi = model.ToDataTable().AsTableValuedParameter() });
                    conn.Query("TTHC_ThuTucHanhChinh_BuuChinhCongIch_Upd", parameters, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public int CongKhaiThuTucHanhByLstId(string thuTucHCIds, int userId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("ThuTucHCIds", thuTucHCIds, DbType.String, ParameterDirection.Input, 1500);
                    parameters.Add("UserId", userId, DbType.Int32, ParameterDirection.Input);
                    conn.Query("TTHC_ThuTucHanhChinh_Upd_ByLstId", parameters, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }


        public ThuTucHanhChinhCongKhaiViewModel GetThuTucHanhChinhCongKhaiById(string id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("Id", id, DbType.String, ParameterDirection.Input, 128);
                    var dataMultiple = conn.QueryMultiple("TTHC_ThuTucHanhChinhCongKhai_ById_Get", parameters,
                        commandType: CommandType.StoredProcedure);

                    var thutuchanhchinh = dataMultiple.Read<TTHCCongKhai>();
                    var hosokemtheos = dataMultiple.Read<ThanhPhanHoSo>();
                    var lienthongs = dataMultiple.Read<TTHC_LienThong>();
                    var donvis = dataMultiple.Read<DanhMuc>();
                    var thutuchanhchinhs = dataMultiple.Read<DanhMuc>();
                    var dvctructuyens = dataMultiple.Read<DanhMuc>();
                    var result = new ThuTucHanhChinhCongKhaiViewModel
                    {
                        TTHCCongKhai = thutuchanhchinh.FirstOrDefault(),
                        ThanhPhanHoSos = hosokemtheos,
                        LienThongs = lienthongs,
                        DonVis = donvis,
                        ThuTucHanhChinhs = thutuchanhchinhs,
                        DvcTrucTuyens = dvctructuyens,
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }

        }
    }
}
