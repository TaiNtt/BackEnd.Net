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
    public class E_LoaiLyDoRepository : Repository<E_LoaiLyDo>, IE_LoaiLyDoRepository
    {
        private readonly ILog _logger;
        private const string TableName = "E_LoaiLyDo";
        private static readonly string DBMasterConn = ConfigurationManager.ConnectionStrings["DBMaster.ConnString"].ConnectionString;


        public E_LoaiLyDoRepository(ILog logger) : base(TableName, DBMasterConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<E_LoaiLyDo> DBMaster_E_LoaiLyDo_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<E_LoaiLyDo>("DBMaster_E_LoaiLyDo_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<E_LoaiLyDo> ?? datas.ToList();

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