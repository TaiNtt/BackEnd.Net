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
    public class GiayChungNhanATSHRepository : Repository<GiayChungNhanATSH>, IGiayChungNhanATSHRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayChungNhanATSH";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayChungNhanATSHRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetByHoSoID(long HoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", HoSoId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanATSH>("NganhY_GiayChungNhanATSH_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH();
            }
        }
        public GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetByID(long GiayChungNhanATSHID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanATSH>("NganhY_GiayChungNhanATSH_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayChungNhanATSH();
            }
        }
        public GiayChungNhanATSH NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayChungNhan", SoGiayChungNhan, DbType.String, ParameterDirection.Input);

                    var retval = conn.Query<GiayChungNhanATSH>("NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan", parameters
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
        public IEnumerable<GiayChungNhanATSHViewModel> NganhY_GiayChungNhanATSH_Search(string SoGiayChungNhan, DateTime? tuNgay, DateTime? denNgay
            , string TenCoSo, string TenPhongXetNghiem, long? HuyenID, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("TenCoSo", TenCoSo, DbType.String, ParameterDirection.Input);
                    parameters.Add("TenPhongXetNghiem", TenPhongXetNghiem, DbType.String, ParameterDirection.Input);
                    parameters.Add("HuyenID", HuyenID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayChungNhanATSHViewModel>("NganhY_GiayChungNhanATSH_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayChungNhanATSHViewModels = datas as IList<GiayChungNhanATSHViewModel> ??
                                                          datas.ToList();
                    totalItems = giayChungNhanATSHViewModels.FirstOrDefault() != null
                        ? giayChungNhanATSHViewModels.First().TotalItems.Value
                        : 0;
                    return giayChungNhanATSHViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhY_GiayChungNhanATSH_Ins(GiayChungNhanATSH model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Cap", model.Cap, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenCoSo", model.TenCoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("TenPhongXetNghiem", model.TenPhongXetNghiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                var iD = conns.ExecuteScalar("NganhY_GiayChungNhanATSH_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhY_GiayChungNhanATSH_UpdByID(GiayChungNhanATSH model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayChungNhanATSHID", model.GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Cap", model.Cap, DbType.Int32, ParameterDirection.Input);
                parameters.Add("SoGiayChungNhan", model.SoGiayChungNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("ThoiHan", model.ThoiHan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TenCoSo", model.TenCoSo, DbType.String, ParameterDirection.Input);
                parameters.Add("TenPhongXetNghiem", model.TenPhongXetNghiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("IsDauKy", model.IsDauKy, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("SoBienNhanDauKy", model.SoBienNhanDauKy, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayHenTraDauKy", model.NgayHenTraDauKy, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NgayNhanDauKy", model.NgayNhanDauKy, DbType.DateTime, ParameterDirection.Input);
                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayChungNhanATSH_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhY_GiayChungNhanATSH_DelByHoSoID(long HoSoID, long GiayChungNhanATSHID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GiayChungNhanATSHID", GiayChungNhanATSHID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayChungNhanATSH_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool CheckExistSoGiayChungNhanATSH(string primaryKeyNameValue, string keyCheckNameValue, string primaryKeyName, string keyCheckName)
        {
            return CheckExists(primaryKeyNameValue, keyCheckNameValue, primaryKeyName, keyCheckName);
        }
    }
}
