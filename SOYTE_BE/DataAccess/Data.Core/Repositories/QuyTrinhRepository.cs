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
    //public class HoSoTiepNhanRepository : Repository<HoSoTiepNhan>, IHoSoTiepNhanRepository
    public class QuyTrinhRepository : IQuyTrinhRepository
    {
        private readonly ILog _logger;
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public QuyTrinhRepository(ILog logger)
        {
            _logger = logger;
        }

        public IEnumerable<QuyTrinhViewModel> MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(int ThuTucID, int TrangThaiHienTaiID, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHienTaiID", TrangThaiHienTaiID, DbType.Int32, ParameterDirection.Input);
                var datas = conns.Query<QuyTrinhViewModel>("MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID", parameters, commandType: CommandType.StoredProcedure);

                var lstquytrinh = datas as IList<QuyTrinhViewModel> ?? datas.ToList();

                return lstquytrinh;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(long HoSoID, int TrangThaiTiepTheoID, int NguoiNhanID, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("HoSoID", HoSoID, DbType.Int64, ParameterDirection.Input);
                parameters.Add("TrangThaiTiepTheoID", TrangThaiTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("NguoiNhanID", NguoiNhanID, DbType.Int32, ParameterDirection.Input);
                var retval = conns.ExecuteScalar("MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID", parameters
                       , commandType: CommandType.StoredProcedure);
                return Convert.ToBoolean(retval);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
    }
}
