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
    public class DM_QuanHuyenRepository : Repository<DM_QuanHuyen>, IDM_QuanHuyenRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_QuanHuyen";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_QuanHuyenRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<DanhMucParentID>("DBMaster_DM_QuanHuyen_GetAll", commandType: CommandType.StoredProcedure);

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

        public IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetAll(IDbConnection conns)
        {
            try
            {
                var datas = conns.Query<DanhMucParentID>("DBMaster_DM_QuanHuyen_GetAll", commandType: CommandType.StoredProcedure);

                var lstdm = datas as IList<DanhMucParentID> ?? datas.ToList();

                return lstdm;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetByTinhID(int TinhThanhID, IDbConnection conns)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("TinhThanhID", TinhThanhID, DbType.Int32, ParameterDirection.Input);
                var datas = conns.Query<DanhMucParentID>("DBMaster_DM_QuanHuyen_GetByTinhID", parameters, commandType: CommandType.StoredProcedure);

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
