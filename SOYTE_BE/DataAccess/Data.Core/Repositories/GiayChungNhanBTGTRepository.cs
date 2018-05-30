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
    public class GiayChungNhanBTGTRepository : Repository<GiayChungNhanBTGT>, IGiayChungNhanBTGTRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanBTGT";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayChungNhanBTGTRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanBTGT>("NganhY_GiayChungNhanBTGT_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanBTGT();
            }
        }
        public GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetByID(long GiayChungNhanBTGTID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanBTGTID", GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanBTGT>("NganhY_GiayChungNhanBTGT_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanBTGT();
            }
        }
        public GiayChungNhanBTGT NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanBTGT>("NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan", parameters
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
        public IEnumerable<GiayChungNhanBTGTViewModel> NganhY_GiayChungNhanBTGT_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string TenBaiThuoc, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("HoTen", HoTen, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenBaiThuoc", TenBaiThuoc, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayChungNhanBTGTViewModel>("NganhY_GiayChungNhanBTGT_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayChungNhanBTGTViewModel = datas as IList<GiayChungNhanBTGTViewModel> ??
                                                          datas.ToList();
                    totalItems = giayChungNhanBTGTViewModel.FirstOrDefault() != null
                        ? giayChungNhanBTGTViewModel.First().TotalItems.Value
                        : 0;
                    return giayChungNhanBTGTViewModel;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhY_GiayChungNhanBTGT_Ins(GiayChungNhanBTGT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayTo", model.LoaiGiayTo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TenBaiThuoc", model.TenBaiThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ChiDinh", model.ChiDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("CachDung", model.CachDung, DbType.String, ParameterDirection.Input);
                parameters.Add("LieuDung", model.LieuDung, DbType.String, ParameterDirection.Input);
                parameters.Add("DangThuoc", model.DangThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ChongChiDinh", model.ChongChiDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("HanSuDung", model.HanSuDung, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhY_GiayChungNhanBTGT_UpdByID(GiayChungNhanBTGT model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanBTGTID", model.GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoQuyetDinh", model.SoQuyetDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayQuyetDinh", model.NgayQuyetDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("HoTen", model.HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NgaySinh", model.NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("GioiTinh", model.GioiTinh, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LoaiGiayTo", model.LoaiGiayTo, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayTo", model.SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapGiayTo", model.NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapGiayTo", model.NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TenBaiThuoc", model.TenBaiThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ChiDinh", model.ChiDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("CachDung", model.CachDung, DbType.String, ParameterDirection.Input);
                parameters.Add("LieuDung", model.LieuDung, DbType.String, ParameterDirection.Input);
                parameters.Add("DangThuoc", model.DangThuoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ChongChiDinh", model.ChongChiDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("HanSuDung", model.HanSuDung, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayChungNhanBTGT_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayChungNhanBTGT_DelByHoSoID(long HoSoID, long GiayChungNhanBTGTID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GiayChungNhanBTGTID", GiayChungNhanBTGTID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanBTGT_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
