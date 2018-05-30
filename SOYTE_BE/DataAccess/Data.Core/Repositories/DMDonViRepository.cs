using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;

namespace Data.Core.Repositories
{
    public class DMDonViRepository : Repository<DM_DonVi>, IDMDonViRepository
    {
        private const string TableName = "DM_DonVi";
        private readonly ILog _logger;

        public DMDonViRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        public List<DM_DonVi> GetDMDonViConditionByPaged(string ten, string capDonViId, bool? isActive, int pageSize, int pageIndex)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("Ten", ten, DbType.String, ParameterDirection.Input, 512);
                    parameters.Add("CapDonViID", capDonViId, DbType.String, ParameterDirection.Input, 128);
                    parameters.Add("IsActive", isActive, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("PageIndex", pageIndex, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);
                    
                    var datas = conn.Query<DM_DonVi>("QT_DM_DonVi_ByCondition_GetPaged", parameters, commandType: CommandType.StoredProcedure);
                    return datas.ToList();
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
