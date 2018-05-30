using System;
using System.Data;
using System.Linq;
using Business.Entities;
using Dapper;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;
using Core.Common.Utilities;

namespace Data.Core.Repositories
{
    public class ParameterRepository : Repository<DMParameter>, IParameterRepository
    {
        private readonly ILog _logger;
        private const string TableName = "DM_Parameters";

        public ParameterRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }

        public DMParameter GetParameterByKey(string key)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("Key", key, DbType.String, ParameterDirection.Input, 50);

                    var retval = conn.Query<DMParameter>("TTHC_DM_Parameter_ByKey_Get", parameters, commandType: CommandType.StoredProcedure);
                    return retval.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new DMParameter();
            }
        }

        public int InsParameter(DMParameter item)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", item.Id, DbType.Int32,ParameterDirection.Input);
                    parameters.Add("@Key", item.Key, DbType.String, ParameterDirection.Input);
                    parameters.Add("@Value", item.Value, DbType.String, ParameterDirection.Input);
                    parameters.Add("@Description", item.Description, DbType.String, ParameterDirection.Input);
                    var id = conn.ExecuteScalar("TTHC_Parameter_Ins", parameters, commandType: CommandType.StoredProcedure);
                    return Converter.ToInt(id.ToString());

                }
}
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }
        }
    }
}
