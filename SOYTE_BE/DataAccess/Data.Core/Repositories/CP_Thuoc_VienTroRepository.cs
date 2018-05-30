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
    public class CP_Thuoc_VienTroRepository : Repository<CP_Thuoc_VienTro>, ICP_Thuoc_VienTroRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CP_Thuoc_VienTro";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CP_Thuoc_VienTroRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CP_Thuoc_VienTro NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CP_Thuoc_VienTro>("NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CP_Thuoc_VienTro();
            }
        }
        public CP_Thuoc_VienTro NganhDuoc_CP_Thuoc_VienTro_GetByID(long ThuocVienTroId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("ThuocVienTroId", ThuocVienTroId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CP_Thuoc_VienTro>("NganhDuoc_CP_Thuoc_VienTro_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CP_Thuoc_VienTro();
            }
        }
        public IEnumerable<CP_Thuoc_VienTroViewModel> NganhDuoc_CP_Thuoc_VienTro_Search(string SoTiepNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CP_Thuoc_VienTroViewModel>("NganhDuoc_CP_Thuoc_VienTro_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var cP_Thuoc_VienTroViewModels = datas as IList<CP_Thuoc_VienTroViewModel> ??
                                                          datas.ToList();
                    totalItems = cP_Thuoc_VienTroViewModels.FirstOrDefault() != null
                        ? cP_Thuoc_VienTroViewModels.First().TotalItems.Value
                        : 0;
                    return cP_Thuoc_VienTroViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_CP_Thuoc_VienTro_Ins(CP_Thuoc_VienTro model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoCongVanDeNghi", model.SoCongVanDeNghi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayGui", model.NgayGui, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("DonViGui", model.DonViGui, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGPHD", model.SoGPHD, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhDVId", model.TinhThanhDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhDV", model.TinhThanhDV, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanDVId", model.QuanDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanDV", model.QuanDV, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongDVId", model.PhuongDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongDV", model.PhuongDV, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaDV", model.SoNhaDV, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiDV", model.DiaChiDV, DbType.String, ParameterDirection.Input);
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

                var iD = conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_CP_Thuoc_VienTro_UpdByID(CP_Thuoc_VienTro model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuocVienTroId", model.ThuocVienTroId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoCongVanDeNghi", model.SoCongVanDeNghi, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayGui", model.NgayGui, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("DonViGui", model.DonViGui, DbType.String, ParameterDirection.Input);
                parameters.Add("SoTiepNhan", model.SoTiepNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayTiepNhan", model.NgayTiepNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGPHD", model.SoGPHD, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhDVId", model.TinhThanhDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanhDV", model.TinhThanhDV, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanDVId", model.QuanDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("QuanDV", model.QuanDV, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongDVId", model.PhuongDVId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhuongDV", model.PhuongDV, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNhaDV", model.SoNhaDV, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChiDV", model.DiaChiDV, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(long HoSoID, long ThuocVienTroId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuocVienTroId", ThuocVienTroId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
