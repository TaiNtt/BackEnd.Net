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
    public class WorkListRepository : Repository<WorkList>, IWorkListRepository
    {
        private readonly ILog _logger;
        private const string TableName = "WorkList";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;

        public WorkListRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        public IEnumerable<WorkListViewModel> MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(int UserID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("UserID", UserID, DbType.Int32, ParameterDirection.Input);

                    var datas = conn.Query<WorkListViewModel>("MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID", parameters
                        , commandType: CommandType.StoredProcedure);

                    var workLists = datas as IList<WorkListViewModel> ??
                                                          datas.ToList();

                    return workLists;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<WorkListViewModel> MotCua_WorkList_CountByFilter(int? linhVucID, int? thuTucID, string soBienNhan,
            DateTime? tuNgay, DateTime? denNgay, string hoTenNguoiNop, string soGiayTo, int UserID)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("linhVucID", linhVucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("thuTucID", thuTucID, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("soBienNhan", soBienNhan, DbType.String, ParameterDirection.Input);
                    parameters.Add("tuNgay", tuNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("denNgay", denNgay, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("hoTenNguoiNop", hoTenNguoiNop, DbType.String, ParameterDirection.Input);
                    parameters.Add("soGiayTo", soGiayTo, DbType.String, ParameterDirection.Input);
                    parameters.Add("UserID", UserID, DbType.Int32, ParameterDirection.Input);
                    var datas = conn.Query<WorkListViewModel>("MotCua_WorkList_CountByFilter", parameters
                        , commandType: CommandType.StoredProcedure);

                    var workLists = datas as IList<WorkListViewModel> ??
                                                          datas.ToList();

                    return workLists;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public bool MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID(int? UserID, int? TrangThaiHoSoID, int? TrangThaiCapNhat,
            IDbConnection conns, IDbTransaction trans)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserID", UserID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiHoSoID", TrangThaiHoSoID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("TrangThaiCapNhat", TrangThaiCapNhat, DbType.Int32, ParameterDirection.Input);

                conns.ExecuteScalar("MotCua_WorkList_InsUpdByUserIDandTrangThaiHoSoID", parameters, trans, commandType: CommandType.StoredProcedure);
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
