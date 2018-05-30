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
    public class DM_PhongBanRepository : Repository<DM_PhongBan>, IDM_PhongBanRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_PhongBan";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public DM_PhongBanRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<CanBoPhongBanList> DBMaster_ListCanBo_PhongBan()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<CanBoPhongBanList>("DBMaster_ListCanBo_PhongBan", commandType: CommandType.StoredProcedure);
                    var lst = datas as IList<CanBoPhongBanList> ?? datas.ToList();
                    return lst;
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