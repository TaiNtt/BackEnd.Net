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
    public class PD_Thuoc_GN_HTTRepository : Repository<PD_Thuoc_GN_HTT>, IPD_Thuoc_GN_HTTRepository
    {
        private readonly ILog _logger;
        private const string TableName = "PD_Thuoc_GN_HTT";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public PD_Thuoc_GN_HTTRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public PD_Thuoc_GN_HTT NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<PD_Thuoc_GN_HTT>("NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new PD_Thuoc_GN_HTT();
            }
        }
        public PD_Thuoc_GN_HTT NganhDuoc_PD_Thuoc_GN_HTT_GetByID(long PDThuocGNHTTId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("PDThuocGNHTTId", PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<PD_Thuoc_GN_HTT>("NganhDuoc_PD_Thuoc_GN_HTT_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new PD_Thuoc_GN_HTT();
            }
        }
        public IEnumerable<PD_Thuoc_GN_HTTViewModel> NganhDuoc_PD_Thuoc_GN_HTT_Search(string SoPheDuyet, DateTime? tuNgay, DateTime? denNgay
            , string TenDonVi, string TenCongTyCungUng, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoPheDuyet", SoPheDuyet, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenDonVi", TenDonVi, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenCongTyCungUng", TenCongTyCungUng, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<PD_Thuoc_GN_HTTViewModel>("NganhDuoc_PD_Thuoc_GN_HTT_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var pD_Thuoc_GN_HTTViewModels = datas as IList<PD_Thuoc_GN_HTTViewModel> ??
                                                          datas.ToList();
                    totalItems = pD_Thuoc_GN_HTTViewModels.FirstOrDefault() != null
                        ? pD_Thuoc_GN_HTTViewModels.First().TotalItems.Value
                        : 0;
                    return pD_Thuoc_GN_HTTViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_PD_Thuoc_GN_HTT_Ins(PD_Thuoc_GN_HTT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGuiDuyet", model.SoGuiDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("SoPheDuyet", model.SoPheDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayDuyet", model.NgayDuyet, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
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
                parameters.Add("TenCongTyCungUng", model.TenCongTyCungUng, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_PD_Thuoc_GN_HTT_UpdByID(PD_Thuoc_GN_HTT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PDThuocGNHTTId", model.PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoGuiDuyet", model.SoGuiDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("SoPheDuyet", model.SoPheDuyet, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayDuyet", model.NgayDuyet, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDonVi", model.TenDonVi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
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
                parameters.Add("TenCongTyCungUng", model.TenCongTyCungUng, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(long HoSoID, long PDThuocGNHTTId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("PDThuocGNHTTId", PDThuocGNHTTId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
