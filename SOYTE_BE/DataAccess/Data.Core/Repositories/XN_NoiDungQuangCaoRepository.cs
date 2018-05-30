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
    public class XN_NoiDungQuangCaoRepository : Repository<XN_NoiDungQuangCao>, IXN_NoiDungQuangCaoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "XN_NoiDungQuangCao";
        private static readonly string NganhDuocConn = ConfigurationManager.ConnectionStrings["NganhDuoc.ConnString"].ConnectionString;


        public XN_NoiDungQuangCaoRepository(ILog logger) : base(TableName, NganhDuocConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public XN_NoiDungQuangCao NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<XN_NoiDungQuangCao>("NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new XN_NoiDungQuangCao();
            }
        }
        public XN_NoiDungQuangCao NganhDuoc_XN_NoiDungQuangCao_GetByID(long NoiDungQCId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("NoiDungQCId", NoiDungQCId, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<XN_NoiDungQuangCao>("NganhDuoc_XN_NoiDungQuangCao_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new XN_NoiDungQuangCao();
            }
        }
        public IEnumerable<XN_NoiDungQuangCaoViewModel> NganhDuoc_XN_NoiDungQuangCao_Search(string SoXacNhan, DateTime? tuNgay, DateTime? denNgay
            , string TOCHUC_CANHAN, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("SoXacNhan", SoXacNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("TOCHUC_CANHAN", TOCHUC_CANHAN, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<XN_NoiDungQuangCaoViewModel>("NganhDuoc_XN_NoiDungQuangCao_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var xN_NoiDungQuangCaoViewModels = datas as IList<XN_NoiDungQuangCaoViewModel> ??
                                                          datas.ToList();
                    totalItems = xN_NoiDungQuangCaoViewModels.FirstOrDefault() != null
                        ? xN_NoiDungQuangCaoViewModels.First().TotalItems.Value
                        : 0;
                    return xN_NoiDungQuangCaoViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public long NganhDuoc_XN_NoiDungQuangCao_Ins(XN_NoiDungQuangCao model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoXacNhan", model.SoXacNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapXacNhan", model.NgayCapXacNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TOCHUC_CANHAN", model.TOCHUC_CANHAN, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhId", model.TinhThanhId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanh", model.TinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanId", model.QuanId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Quan", model.Quan, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongId", model.PhuongId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Phuong", model.Phuong, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKem", model.TapTinDinhKem, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKemGoc", model.TapTinDinhKemGoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CreateUserId", model.CreateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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
        public bool NganhDuoc_XN_NoiDungQuangCao_UpdByID(XN_NoiDungQuangCao model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("NoiDungQCId", model.NoiDungQCId, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoBienNhan", model.SoBienNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("SoXacNhan", model.SoXacNhan, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapXacNhan", model.NgayCapXacNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TOCHUC_CANHAN", model.TOCHUC_CANHAN, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhThanhId", model.TinhThanhId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TinhThanh", model.TinhThanh, DbType.String, ParameterDirection.Input);
                parameters.Add("QuanId", model.QuanId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Quan", model.Quan, DbType.String, ParameterDirection.Input);
                parameters.Add("PhuongId", model.PhuongId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Phuong", model.Phuong, DbType.String, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("SoDienThoai", model.SoDienThoai, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKem", model.TapTinDinhKem, DbType.String, ParameterDirection.Input);
                parameters.Add("TapTinDinhKemGoc", model.TapTinDinhKemGoc, DbType.String, ParameterDirection.Input);
                parameters.Add("ACTIVE", model.Active, DbType.Int32, ParameterDirection.Input);
                parameters.Add("GhiChu", model.GhiChu, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("DonViID", model.DonViID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("UpdateUserId", model.UpdateUserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UpdateDate", model.UpdateDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
        public bool NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(long HoSoID, long NoiDungQCId, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NoiDungQCId", NoiDungQCId, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
