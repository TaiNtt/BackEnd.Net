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
    public class GiayPhepHoatDongKCBRepository : Repository<GiayPhepHoatDongKCB>, IGiayPhepHoatDongKCBRepository
    {
        private readonly ILog _logger;
        private const string TableName = "GiayPhepHoatDongKCB";
        private static readonly string NganhYConn = ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString;


        public GiayPhepHoatDongKCBRepository(ILog logger) : base(TableName, NganhYConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetByHoSoID(long HoSoID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongKCB>("NganhY_GiayPhepHoatDongKCB_GetByHoSoID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongKCB();
            }
        }

        public GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetByID(long GiayPhepKhamChuaBenhID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("GiayPhepKhamChuaBenhID", GiayPhepKhamChuaBenhID, DbType.Int64, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongKCB>("NganhY_GiayPhepHoatDongKCB_GetByID", parameters
                        , commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new GiayPhepHoatDongKCB();
            }
        }

        public GiayPhepHoatDongKCB NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(string SoGiayPhep)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("SoGiayPhep", SoGiayPhep, DbType.String, ParameterDirection.Input);

                    var retval = conn.Query<GiayPhepHoatDongKCB>("NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep", parameters
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

        public IEnumerable<GiayPhepHoatDongKCBViewModel> NganhY_GiayPhepHoatDongKCB_Search(string SoGiayPhep, DateTime? tuNgay, DateTime? denNgay
            , string CoSoDK_Ten, long? CoSoDK_HuyenID, long? CoSoDK_XaID, int pageIndex, int pageSize, out int totalItems)
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
                    parameters.Add("CoSoDK_Ten", CoSoDK_Ten, DbType.String, ParameterDirection.Input);
                    parameters.Add("CoSoDK_HuyenID", CoSoDK_HuyenID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("CoSoDK_XaID", CoSoDK_XaID, DbType.Int64, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<GiayPhepHoatDongKCBViewModel>("NganhY_GiayPhepHoatDongKCB_Search",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var giayPhepHoatDongKCBViewModels = datas as IList<GiayPhepHoatDongKCBViewModel> ??
                                                          datas.ToList();
                    totalItems = giayPhepHoatDongKCBViewModels.FirstOrDefault() != null
                        ? giayPhepHoatDongKCBViewModels.First().TotalItems.Value
                        : 0;
                    return giayPhepHoatDongKCBViewModels;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }

        public long NganhY_GiayPhepHoatDongKCB_Ins(GiayPhepHoatDongKCB model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("CoSoDK_Ten", model.CoSoDK_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_MaDoanhNghiep", model.CoSoDK_MaDoanhNghiep, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_HinhThucToChucID", model.CoSoDK_HinhThucToChucID, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_TinhID", model.CoSoDK_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_HuyenID", model.CoSoDK_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_XaID", model.CoSoDK_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_SoNha", model.CoSoDK_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_DiaChi", model.CoSoDK_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_Phone", model.CoSoDK_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_Email", model.CoSoDK_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_ChungChiHanhNgheYID", model.NCTN_ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NCTN_HoTen", model.NCTN_HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCapGiayTo", model.NCTN_NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCapGiayTo", model.NCTN_NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianLamViec", model.ThoiGianLamViec, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var iD = conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
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

        public bool NganhY_GiayPhepHoatDongKCB_UpdByID(GiayPhepHoatDongKCB model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("GiayPhepKhamChuaBenhID", model.GiayPhepKhamChuaBenhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("SoGiayPhep", model.SoGiayPhep, DbType.String, ParameterDirection.Input);
                parameters.Add("NgayCap", model.NgayCap, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("CoSoDK_Ten", model.CoSoDK_Ten, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_MaDoanhNghiep", model.CoSoDK_MaDoanhNghiep, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_HinhThucToChucID", model.CoSoDK_HinhThucToChucID, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_TinhID", model.CoSoDK_TinhID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_HuyenID", model.CoSoDK_HuyenID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_XaID", model.CoSoDK_XaID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("CoSoDK_SoNha", model.CoSoDK_SoNha, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_DiaChi", model.CoSoDK_DiaChi, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_Phone", model.CoSoDK_Phone, DbType.String, ParameterDirection.Input);
                parameters.Add("CoSoDK_Email", model.CoSoDK_Email, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_ChungChiHanhNgheYID", model.NCTN_ChungChiHanhNgheYID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NCTN_HoTen", model.NCTN_HoTen, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgaySinh", model.NCTN_NgaySinh, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_GioiTinhID", model.NCTN_GioiTinhID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_LoaiGiayToID", model.NCTN_LoaiGiayToID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NCTN_SoGiayTo", model.NCTN_SoGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("NCTN_NgayCapGiayTo", model.NCTN_NgayCapGiayTo, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NCTN_NoiCapGiayTo", model.NCTN_NoiCapGiayTo, DbType.String, ParameterDirection.Input);
                parameters.Add("ThoiGianLamViec", model.ThoiGianLamViec, DbType.String, ParameterDirection.Input);
                parameters.Add("PhamViHoatDongID", model.PhamViHoatDongID, DbType.String, ParameterDirection.Input);
                parameters.Add("TrangThaiGiayPhepID", model.TrangThaiGiayPhepID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_UpdByID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_UpdDaCap(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_UpdDaCap", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool NganhY_GiayPhepHoatDongKCB_DelByHoSoID(long HoSoID, long GiayPhepKhamChuaBenhID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("GiayPhepKhamChuaBenhID", GiayPhepKhamChuaBenhID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("NganhY_GiayPhepHoatDongKCB_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
