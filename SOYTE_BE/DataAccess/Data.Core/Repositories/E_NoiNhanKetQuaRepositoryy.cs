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
    public class E_NoiNhanKetQuaRepository : Repository<E_NoiNhanKetQua>, IE_NoiNhanKetQuaRepository
    {
        private readonly ILog _logger;
        private const string TableName = "E_NoiNhanKetQua";
        private static readonly string MotCuaConn = ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString;


        public E_NoiNhanKetQuaRepository(ILog logger) : base(TableName, MotCuaConn)
        {
            _logger = logger;
        }
        //--------------------------------------------------//
        public IEnumerable<E_NoiNhanKetQua> MotCua_E_NoiNhanKetQua_GetAll()
        {
            try
            {
                using (IDbConnection conns = Connection)
                {
                    conns.Open();
                    var datas = conns.Query<E_NoiNhanKetQua>("MotCua_E_NoiNhanKetQua_GetAll", commandType: CommandType.StoredProcedure);

                    var lstdm = datas as IList<E_NoiNhanKetQua> ?? datas.ToList();

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