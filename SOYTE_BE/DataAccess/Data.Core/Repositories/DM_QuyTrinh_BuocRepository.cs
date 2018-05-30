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
    public class DM_QuyTrinh_BuocRepository : Repository<DM_QuyTrinh_Buoc>, IDM_QuyTrinh_BuocRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_QuyTrinh_Buoc";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public DM_QuyTrinh_BuocRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public DM_QuyTrinh_Buoc MotCua_DM_QuyTrinh_Buoc_GetByBuocID(int BuocID)
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("BuocID", BuocID, DbType.Int32, ParameterDirection.Input);

                    var retval = conns.Query<DM_QuyTrinh_Buoc>("MotCua_DM_QuyTrinh_Buoc_GetByBuocID", parameters
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
        public IEnumerable<DM_QuyTrinh_Buoc_NguoiNhanList> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(int thuTucID, int pageIndex, int pageSize, out int totalItems)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("thuTucID", thuTucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<DM_QuyTrinh_Buoc_NguoiNhanList>("MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    var dM_QuyTrinh_Buoc_NguoiNhanList = datas as IList<DM_QuyTrinh_Buoc_NguoiNhanList> ??
                                                          datas.ToList();
                    totalItems = dM_QuyTrinh_Buoc_NguoiNhanList.FirstOrDefault() != null
                        ? dM_QuyTrinh_Buoc_NguoiNhanList.First().TotalItems.Value
                        : 0;
                    return dM_QuyTrinh_Buoc_NguoiNhanList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
        public int MotCua_DM_QuyTrinh_Buoc_Ins(DM_QuyTrinh_Buoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHienTaiID", model.TrangThaiHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiTiepTheoID", model.TrangThaiTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                var buocID = conns.ExecuteScalar("MotCua_DM_QuyTrinh_Buoc_Ins", parameters, trans, commandType: CommandType.StoredProcedure);
                if (buocID != null)
                    return Convert.ToInt32(buocID);
                return -1;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
        public bool MotCua_DM_QuyTrinh_Buoc_UpdByBuocID(DM_QuyTrinh_Buoc model, IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("BuocID", model.BuocID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ThuTucID", model.ThuTucID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHienTaiID", model.TrangThaiHienTaiID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiTiepTheoID", model.TrangThaiTiepTheoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Used", model.Used, DbType.Boolean, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_DM_QuyTrinh_Buoc_UpdByBuocID", parameters, trans, commandType: CommandType.StoredProcedure);
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