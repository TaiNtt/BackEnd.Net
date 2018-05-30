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
    public class GiayPhepHoatDongChuThapDoRepository : Repository<GiayPhepHoatDongChuThapDo>, IGiayPhepHoatDongChuThapDoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepHoatDongChuThapDo";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayPhepHoatDongChuThapDoRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongChuThapDo>("NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongChuThapDo();
            }
        }

        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByID(long GiayPhepHoatDongChuThapDoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepHoatDongChuThapDoID", GiayPhepHoatDongChuThapDoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongChuThapDo>("NganhY_GiayPhepHoatDongChuThapDo_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongChuThapDo();
            }
        }

        public GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(string SoGiayPhep)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayPhep", SoGiayPhep, DbType.String, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongChuThapDo>("NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep", parameters
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

        public IEnumerable<GiayPhepHoatDongChuThapDoViewModel> NganhY_GiayPhepHoatDongChuThapDo_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string TenDiem, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("TenDiem", TenDiem, DbType.String, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayPhepHoatDongChuThapDoViewModel>("NganhY_GiayPhepHoatDongChuThapDo_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayPhepHoatDongChuThapDoViewModels = datas as IList<GiayPhepHoatDongChuThapDoViewModel> ??
                                                          datas.ToList();
                    totalItems = giayPhepHoatDongChuThapDoViewModels.FirstOrDefault() != null
                        ? giayPhepHoatDongChuThapDoViewModels.First().TotalItems.Value
                        : 0;
                    return giayPhepHoatDongChuThapDoViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public long NganhY_GiayPhepHoatDongChuThapDo_Ins(GiayPhepHoatDongChuThapDo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoBienBanThamDinh", model.SoBienBanThamDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayThamDinh", model.NgayThamDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDiem", model.TenDiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("SoQDThanhLap", model.SoQDThanhLap, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapQDThanhLap", model.NgayCapQDThanhLap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapQDThanhLap", model.NoiCapQDThanhLap, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhThucToChucID", model.HinhThucToChucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhamViHoatDong", model.PhamViHoatDong, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianLamViec", model.ThoiGianLamViec, DbType.String, ParameterDirection.Input);
                parameters.Add("NguoiChiuTrachNhiem", model.NguoiChiuTrachNhiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_GiayPhepHoatDongChuThapDo_UpdByID(GiayPhepHoatDongChuThapDo model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayPhepHoatDongChuThapDoID", model.GiayPhepHoatDongChuThapDoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("SoBienBanThamDinh", model.SoBienBanThamDinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayThamDinh", model.NgayThamDinh, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("TenDiem", model.TenDiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TinhID", model.TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HuyenID", model.HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("XaID", model.XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoNha", model.SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("DiaChi", model.DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("Phone", model.Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("SoQDThanhLap", model.SoQDThanhLap, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCapQDThanhLap", model.NgayCapQDThanhLap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NoiCapQDThanhLap", model.NoiCapQDThanhLap, DbType.String, ParameterDirection.Input);
                parameters.Add("HinhThucToChucID", model.HinhThucToChucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("PhamViHoatDong", model.PhamViHoatDong, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianLamViec", model.ThoiGianLamViec, DbType.String, ParameterDirection.Input);
                parameters.Add("NguoiChiuTrachNhiem", model.NguoiChiuTrachNhiem, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
