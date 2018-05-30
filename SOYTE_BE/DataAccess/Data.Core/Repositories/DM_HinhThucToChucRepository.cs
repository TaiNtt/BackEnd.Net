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
    public class DM_HinhThucToChucRepository : Repository<DM_HinhThucToChuc>, IDM_HinhThucToChucRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_HinhThucToChuc";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_HinhThucToChucRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<MTDanhMuc>("DBMaster_DM_HinhThucToChuc_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<MTDanhMuc> ?? datas.ToList();

                    return lstdm;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
        public IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll(IDbConnection conns)
        {
            try
            {
                var datas = conns.Query<MTDanhMuc>("DBMaster_DM_TrinhDoChuyenMon_GetAll", commandType: CommandType.StoredProcedure);

                var lstdm = datas as IList<MTDanhMuc> ?? datas.ToList();

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
