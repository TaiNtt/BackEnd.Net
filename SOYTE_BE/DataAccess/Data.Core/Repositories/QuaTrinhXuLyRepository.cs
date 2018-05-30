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
    public class QuaTrinhXuLyRepository : Repository<QuaTrinhXuLy>, IQuaTrinhXuLyRepository
    {
        private readonly ILog _logger;
        private const string TableName = "QuaTrinhXuLy";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public QuaTrinhXuLyRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }

        public long MotCua_QuaTrinhXuLy_Ins(QuaTrinhXuLy model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", model.HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NgayNhan", model.NgayNhan, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NguoiXuLyHienTaiID", model.NguoiXuLyHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NgayChuyen", model.NgayChuyen, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("NguoiXuLyTiepTheoID", model.NguoiXuLyTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHienTaiID", model.TrangThaiHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiTiepTheoID", model.TrangThaiTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("IsQuaTrinhHienTai", model.IsQuaTrinhHienTai, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("CreatedUserID", model.CreatedUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedDate", model.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", model.LastUpdUserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdDate", model.LastUpdDate, DbType.DateTime, ParameterDirection.Input);

                var quaTrinhXuLyId = conns.ExecuteScalar("MotCua_QuaTrinhXuLy_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (quaTrinhXuLyId != null)
                    return Convert.ToInt64(quaTrinhXuLyId);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public long MotCua_QuaTrinhXuLy_InsUpd(long HoSoID, int? NguoiXuLyHienTaiID, int? NguoiXuLyTiepTheoID, int? TrangThaiHienTaiID, int? TrangThaiTiepTheoID,
            IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("NguoiXuLyHienTaiID", NguoiXuLyHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NguoiXuLyTiepTheoID", NguoiXuLyTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHienTaiID", TrangThaiHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiTiepTheoID", TrangThaiTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedUserID", NguoiXuLyHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("LastUpdUserID", NguoiXuLyHienTaiID, DbType.Int32, ParameterDirection.Input);
                var quaTrinhXuLyID = conns.ExecuteScalar("MotCua_QuaTrinhXuLy_InsUpd", parameters, trans, commandType: CommandType.StoredProcedure);
                if (quaTrinhXuLyID != null)
                    return Convert.ToInt64(quaTrinhXuLyID);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }

        public bool MotCua_QuaTrinhXuLy_DelByHoSoID(long HoSoID, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_QuaTrinhXuLy_DelByHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<QuaTrinhXuLyViewModel> MotCua_QuaTrinhXuLys_GetByHoSoID(long hoSoId, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoId", hoSoId, DbType.Int64, ParameterDirection.Input);
                var datas = conns.Query<QuaTrinhXuLyViewModel>("MotCua_QuaTrinhXuLys_GetByHoSoID", parameters, commandType: CommandType.StoredProcedure);

                var lstquatrinhxuly = datas as IList<QuaTrinhXuLyViewModel> ?? datas.ToList();

                return lstquatrinhxuly;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public DataTableViewModel MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(long hoSoId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("HoSoId", hoSoId, DbType.Int64, ParameterDirection.Input);

                    var datas = conn.ExecuteReader("MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo", parameters
                        , commandType: CommandType.StoredProcedure);
                    DataTableViewModel dt = new DataTableViewModel(datas);
                    dt.Name = "QuaTrinhXuLy";
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}
