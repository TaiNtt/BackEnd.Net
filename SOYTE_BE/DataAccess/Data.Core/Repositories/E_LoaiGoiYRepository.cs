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
    public class E_LoaiGoiYRepository : Repository<E_LoaiGoiY>, IE_LoaiGoiYRepository
    {
        private readonly ILog _logger;
        private const string TableName = "E_LoaiGoiY";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public E_LoaiGoiYRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<E_LoaiGoiY> DBMaster_E_LoaiGoiY_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<E_LoaiGoiY>("DBMaster_E_LoaiGoiY_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<E_LoaiGoiY> ?? datas.ToList();

                    return lstdm;
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