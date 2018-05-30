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
    public class GiayPhepDoanKCBRepository : Repository<GiayPhepDoanKCB>, IGiayPhepDoanKCBRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepDoanKCB";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayPhepDoanKCBRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayPhepDoanKCB NganhY_GiayPhepDoanKCB_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepDoanKCB>("NganhY_GiayPhepDoanKCB_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepDoanKCB();
            }
        }
        public GiayPhepDoanKCB NganhY_GiayPhepDoanKCB_GetByID(long GiayPhepDoanKCBID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepDoanKCBID", GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepDoanKCB>("NganhY_GiayPhepDoanKCB_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepDoanKCB();
            }
        }
        public IEnumerable<GiayPhepDoanKCBViewModel> NganhY_GiayPhepDoanKCB_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string TenDoanKCB, DateTime? tuNgayKCB, DateTime? denNgayKCB, long? NoiKCB_HuyenID, long? NoiKCB_XaID, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayPhep", SoGiayPhep, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TenDoanKCB", TenDoanKCB, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgayKCB", tuNgayKCB, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgayKCB", denNgayKCB, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("NoiKCB_HuyenID", NoiKCB_HuyenID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("NoiKCB_XaID", NoiKCB_XaID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayPhepDoanKCBViewModel>("NganhY_GiayPhepDoanKCB_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayPhepDoanKCBViewModels = datas as IList<GiayPhepDoanKCBViewModel> ??
                                                          datas.ToList();
                    totalItems = giayPhepDoanKCBViewModels.FirstOrDefault() != null
                        ? giayPhepDoanKCBViewModels.First().TotalItems.Value
                        : 0;
                    return giayPhepDoanKCBViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhY_GiayPhepDoanKCB_Ins(GiayPhepDoanKCB model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDoanKCB", model.TenDoanKCB, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayKCB", model.NgayKCB, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiKCB_HuyenID", model.NoiKCB_HuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiKCB_XaID", model.NoiKCB_XaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoNguoiDuocKham", model.SoNguoiDuocKham, DbType.Int32, ParameterDirection.Input);
                parameters.Add("KinhPhi", model.KinhPhi, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Ten", model.DonViDeNghi_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_TinhID", model.DonViDeNghi_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_HuyenID", model.DonViDeNghi_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_XaID", model.DonViDeNghi_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_SoNha", model.DonViDeNghi_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_DiaChi", model.DonViDeNghi_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_NguoiXinPhep", model.DonViDeNghi_NguoiXinPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Phone", model.DonViDeNghi_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Email", model.DonViDeNghi_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_HoTen", model.NCTN_HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCapGiayTo", model.NCTN_NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCapGiayTo", model.NCTN_NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("YKien", model.YKien, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhY_GiayPhepDoanKCB_UpdByID(GiayPhepDoanKCB model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayPhepDoanKCBID", model.GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDoanKCB", model.TenDoanKCB, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayKCB", model.NgayKCB, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiKCB_HuyenID", model.NoiKCB_HuyenID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NoiKCB_XaID", model.NoiKCB_XaID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoNguoiDuocKham", model.SoNguoiDuocKham, DbType.Int32, ParameterDirection.Input);
                parameters.Add("KinhPhi", model.KinhPhi, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Ten", model.DonViDeNghi_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_TinhID", model.DonViDeNghi_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_HuyenID", model.DonViDeNghi_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_XaID", model.DonViDeNghi_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_SoNha", model.DonViDeNghi_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_DiaChi", model.DonViDeNghi_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_NguoiXinPhep", model.DonViDeNghi_NguoiXinPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Phone", model.DonViDeNghi_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("DonViDeNghi_Email", model.DonViDeNghi_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_HoTen", model.NCTN_HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCapGiayTo", model.NCTN_NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCapGiayTo", model.NCTN_NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("YKien", model.YKien, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayPhepDoanKCB_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayPhepDoanKCB_DelByHoSoID(long HoSoID, long GiayPhepDoanKCBID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GiayPhepDoanKCBID", GiayPhepDoanKCBID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepDoanKCB_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
