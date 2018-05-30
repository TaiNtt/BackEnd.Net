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
    public class CN_LuuHanhMyPhamRepository : Repository<CN_LuuHanhMyPham>, ICN_LuuHanhMyPhamRepository
    {
        private readonly ILog _logger;
        private const string TableName = "CN_LuuHanhMyPham";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public CN_LuuHanhMyPhamRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public CN_LuuHanhMyPham NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_LuuHanhMyPham>("NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_LuuHanhMyPham();
            }
        }
        public CN_LuuHanhMyPham NganhDuoc_CN_LuuHanhMyPham_GetByID(long LuuHanhMyPhamId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("LuuHanhMyPhamId", LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<CN_LuuHanhMyPham>("NganhDuoc_CN_LuuHanhMyPham_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new CN_LuuHanhMyPham();
            }
        }
        public IEnumerable<CN_LuuHanhMyPhamViewModel> NganhDuoc_CN_LuuHanhMyPham_Search(string SoChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCongTy, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoChungNhan", SoChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenCongTy", TenCongTy, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<CN_LuuHanhMyPhamViewModel>("NganhDuoc_CN_LuuHanhMyPham_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var cN_LuuHanhMyPhamViewModels = datas as IList<CN_LuuHanhMyPhamViewModel> ??
                                                          datas.ToList();
                    totalItems = cN_LuuHanhMyPhamViewModels.FirstOrDefault() != null
                        ? cN_LuuHanhMyPhamViewModels.First().TotalItems.Value
                        : 0;
                    return cN_LuuHanhMyPhamViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_CN_LuuHanhMyPham_Ins(CN_LuuHanhMyPham model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoChungNhan", model.SoChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapChungNhan", model.NgayCapChungNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenCongTy", model.TenCongTy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
                parameters.Add("TenNhaSanXuat", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
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
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_CN_LuuHanhMyPham_UpdByID(CN_LuuHanhMyPham model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("LuuHanhMyPhamId", model.LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoChungNhan", model.SoChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapChungNhan", model.NgayCapChungNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenCongTy", model.TenCongTy, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDKKD", model.SoDKKD, DbType.String, ParameterDirection.Input);
                parameters.Add("TenNhaSanXuat", model.TenNhaSanXuat, DbType.String, ParameterDirection.Input);
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
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(long HoSoID, long LuuHanhMyPhamId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("LuuHanhMyPhamId", LuuHanhMyPhamId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
