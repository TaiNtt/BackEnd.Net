using System;
using System.Collections.Generic;
using System.Data;
using Business.Entities;
using Core.Common.Utilities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using System.Linq;

namespace Data.Core.Repositories
{
    public class LinhVucRepository : Repository<DMLinhVuc>, ILinhVucRepository
    {
        private const string TableName = "DM_LinhVuc";
        private readonly ILog _logger;

        public LinhVucRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        public bool AddLinhVucByPaging(List<DMLinhVuc> items)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var table = items.ToDataTable();

                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { LinhVucTVP = table.AsTableValuedParameter() });
                    conn.Query("TTHC_DM_LinhVuc_ByPaging_Ins", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<DMLinhVuc> GetDanhMucLinhVuc(string keySearch, int pageSize, int pageIndex)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@KeySearch", keySearch, DbType.String);
                    parameters.Add("@PageSize", pageSize, DbType.Int32);
                    parameters.Add("@PageIndex", pageIndex, DbType.Int32);
                    var result = conn.Query<DMLinhVuc>("DM_LinhVuc_ByTenLinhVuc_Get", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new List<DMLinhVuc>();
            }
        }

        public List<DMLinhVuc> GetDMLinhVucByPaging(string keySearch, int pageSize, int pageIndex, out int totalItems)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("KeySearch", keySearch, DbType.String);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32);
                    parameters.Add("PageSize", pageSize, DbType.Int32);                   
                    parameters.Add("TotalItems", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    var datas = conn.Query<DMLinhVuc>("DM_LinhVuc_ByTenLinhVuc_Get", parameters, 
                        commandType: CommandType.StoredProcedure);
                    totalItems = parameters.Get<int>("TotalItems");
                    return datas.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return null;
            }
        }
    }
}