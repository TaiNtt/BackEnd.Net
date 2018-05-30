using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Core.Repositories
{
    public class TTHCDonViMappingRepository : Repository<TTHCDonViMapping>, ITTHCDonViMappingRepository
    {
        private const string TableName = "TTHC_DonVi_Mapping";
        private readonly ILog _logger;

        public TTHCDonViMappingRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }
        public List<DanhMuc> GetTTHCDonViByCapDonViPaged(string keySearch, string capDonViId, int pageSize, int pageIndex, out int totalItems)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("KeySearch", keySearch, DbType.String);
                    parameters.Add("CapDonViID", capDonViId, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("PageSize", pageSize, DbType.Int32);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32);
                    var result = conn.Query<DanhMuc>("TTHC_TTHC_DonVi_Mapping_Get", parameters, commandType: CommandType.StoredProcedure);
                    var danhMucs = result as IList<DanhMuc> ?? result.ToList();
                    totalItems = danhMucs.FirstOrDefault() != null ? danhMucs.First().TotalItems : 0;
                    return danhMucs.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                totalItems = 0;
                return new List<DanhMuc>();
            }
        }
    }
}
