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
    public class GiayChungNhanLuongYRepository : Repository<GiayChungNhanLuongY>, IGiayChungNhanLuongYRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanLuongY";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayChungNhanLuongYRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayChungNhanLuongY NganhY_GiayChungNhanLuongY_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanLuongY>("NganhY_GiayChungNhanLuongY_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanLuongY();
            }
        }

        public GiayChungNhanLuongY NganhY_GiayChungNhanLuongY_GetByID(long GiayChungNhanLuongYID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanLuongYID", GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanLuongY>("NganhY_GiayChungNhanLuongY_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanLuongY();
            }
        }

        public IEnumerable<GiayChungNhanLuongYViewModel> NganhY_GiayChungNhanLuongY_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string HoTen, string SoGiayTo, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("SoGiayTo", SoGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayChungNhanLuongYViewModel>("NganhY_GiayChungNhanLuongY_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayChungNhanLuongYViewModels = datas as IList<GiayChungNhanLuongYViewModel> ??
                                                          datas.ToList();
                    totalItems = giayChungNhanLuongYViewModels.FirstOrDefault() != null
                        ? giayChungNhanLuongYViewModels.First().TotalItems.Value
                        : 0;
                    return giayChungNhanLuongYViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public long NganhY_GiayChungNhanLuongY_Ins(GiayChungNhanLuongY model, IDbConnection conns, IDbTransaction trans)
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
                parameters.Add("ThuongTru_TinhID", model.ThuongTru_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_HuyenID", model.ThuongTru_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_XaID", model.ThuongTru_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_SoNha", model.ThuongTru_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_TinhID", model.ChoO_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_HuyenID", model.ChoO_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_XaID", model.ChoO_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_SoNha", model.ChoO_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_DiaChi", model.ChoO_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhAnh", model.HinhAnh, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                var iD = conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_GiayChungNhanLuongY_UpdByID(GiayChungNhanLuongY model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanLuongYID", model.GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);
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
                parameters.Add("ThuongTru_TinhID", model.ThuongTru_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_HuyenID", model.ThuongTru_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_XaID", model.ThuongTru_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ThuongTru_SoNha", model.ThuongTru_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ThuongTru_DiaChi", model.ThuongTru_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_TinhID", model.ChoO_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_HuyenID", model.ChoO_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_XaID", model.ChoO_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("ChoO_SoNha", model.ChoO_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("ChoO_DiaChi", model.ChoO_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhAnh", model.HinhAnh, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayChungNhanLuongY_DelByHoSoID(long HoSoID, long GiayChungNhanLuongYID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GiayChungNhanLuongYID", GiayChungNhanLuongYID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanLuongY_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool CheckExistSoChungNhanLuongY(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName, string keyCheckName)
        {
            return CheckExists(primaryKeyNameValue, keyCheckNameValue, primaryKeyName, keyCheckName);
        }
    }
}
