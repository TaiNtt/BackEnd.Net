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
    public class DangKyQCTrangThietBiRepository : Repository<DangKyQCTrangThietBi>, IDangKyQCTrangThietBiRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DangKyQCTrangThietBi";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public DangKyQCTrangThietBiRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<DangKyQCTrangThietBi>("NganhY_DangKyQCTrangThietBi_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DangKyQCTrangThietBi();
            }
        }

        public DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByID(long DangKyQCTrangThietBiID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("DangKyQCTrangThietBiID", DangKyQCTrangThietBiID, DbType.Int64, ParameterDirection.Input);
                    var retval = conn.Query<DangKyQCTrangThietBi>("NganhY_DangKyQCTrangThietBi_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DangKyQCTrangThietBi();
            }
        }

        public IEnumerable<DangKyQCTrangThietBiViewModel> NganhY_DangKyQCTrangThietBi_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string DichVuQuangCao, string DonViDK_Ten, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("DichVuQuangCao", DichVuQuangCao, DbType.String, ParameterDirection.Input);
                    parameters.Add("DonViDK_Ten", DonViDK_Ten, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DangKyQCTrangThietBiViewModel>("NganhY_DangKyQCTrangThietBi_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dangKyQCTrangThietBiViewModels = datas as IList<DangKyQCTrangThietBiViewModel> ??
                                                          datas.ToList();
                    totalItems = dangKyQCTrangThietBiViewModels.FirstOrDefault() != null
                        ? dangKyQCTrangThietBiViewModels.First().TotalItems.Value
                        : 0;
                    return dangKyQCTrangThietBiViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public long NganhY_DangKyQCTrangThietBi_Ins(DangKyQCTrangThietBi model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayDangKy", model.SoGiayDangKy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("DichVuQuangCao", model.DichVuQuangCao, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Ten", model.DonViDK_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_MaDoanhNghiep", model.DonViDK_MaDoanhNghiep, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_TinhID", model.DonViDK_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_HuyenID", model.DonViDK_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_XaID", model.DonViDK_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_SoNha", model.DonViDK_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_DiaChi", model.DonViDK_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Phone", model.DonViDK_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Email", model.DonViDK_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Ten", model.NCTN_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCap", model.NCTN_NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCap", model.NCTN_NoiCap, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Phone", model.NCTN_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Email", model.NCTN_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                var iD = conns.ExecuteScalar("NganhY_DangKyQCTrangThietBi_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_DangKyQCTrangThietBi_UpdByID(DangKyQCTrangThietBi model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DangKyQCTrangThietBiID", model.DangKyQCTrangThietBiID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayDangKy", model.SoGiayDangKy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("DichVuQuangCao", model.DichVuQuangCao, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Ten", model.DonViDK_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_MaDoanhNghiep", model.DonViDK_MaDoanhNghiep, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_TinhID", model.DonViDK_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_HuyenID", model.DonViDK_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_XaID", model.DonViDK_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDK_SoNha", model.DonViDK_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_DiaChi", model.DonViDK_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Phone", model.DonViDK_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDK_Email", model.DonViDK_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Ten", model.NCTN_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCap", model.NCTN_NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCap", model.NCTN_NoiCap, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Phone", model.NCTN_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_Email", model.NCTN_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                conns.ExecuteScalar("NganhY_DangKyQCTrangThietBi_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_DangKyQCTrangThietBi_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_DangKyQCTrangThietBi_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_DangKyQCTrangThietBi_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_DangKyQCTrangThietBi_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool CheckExistSoTiepNhanDangKyQuangCaoNganhY(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName, string keyCheckName)
        {
            return CheckExists(primaryKeyNameValue, keyCheckNameValue, primaryKeyName, keyCheckName);
        }
    }
}
