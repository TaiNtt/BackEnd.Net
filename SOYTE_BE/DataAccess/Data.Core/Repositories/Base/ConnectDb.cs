using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Core.Repositories.Base
{
  
    public abstract class ConnectDb
    {

        internal IDbConnection ConnNganhY => new SqlConnection(ConfigurationManager.ConnectionStrings["NganhY.ConnString"].ConnectionString);
        internal IDbConnection ConnMotCua => new SqlConnection(ConfigurationManager.ConnectionStrings["MotCua.ConnString"].ConnectionString);

    }
}
