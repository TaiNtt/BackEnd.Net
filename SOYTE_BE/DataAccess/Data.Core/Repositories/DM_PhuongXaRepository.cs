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
    public class DM_PhuongXaRepository : Repository<DM_PhuongXa>, IDM_PhuongXaRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_PhuongXa";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_PhuongXaRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<DanhMucParentID>("DBMaster_DM_PhuongXa_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<DanhMucParentID> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetAll(IDbConnection conns)
        {
            try
            {
                var datas = conns.Query<DanhMucParentID>("DBMaster_DM_PhuongXa_GetAll", commandType: CommandType.StoredProcedure);

                var lstdm = datas as IList<DanhMucParentID> ?? datas.ToList();

                return lstdm;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetByQuanID(int QuanID, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("QuanID", QuanID, DbType.Int32, ParameterDirection.Input);
                var datas = conns.Query<DanhMucParentID>("DBMaster_DM_PhuongXa_GetByQuanID", parameters, commandType: CommandType.StoredProcedure);

                var lstdm = datas as IList<DanhMucParentID> ?? datas.ToList();

                return lstdm;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}
