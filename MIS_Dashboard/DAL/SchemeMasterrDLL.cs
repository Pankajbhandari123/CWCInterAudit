using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DAL
{
    public class SchemeMasterrDLL
    {
        SqlHelper sql = new SqlHelper();
        public int SaveUpdateScheme(int activeStatus, string createdBy, int masterId, string schemeName)
        {
            MySqlParameter[] spmScheme = { new MySqlParameter("activeStatus", activeStatus),
                                          new MySqlParameter("createdBy", createdBy),
                                          new MySqlParameter("schemeName", schemeName),
                                          new MySqlParameter("masterId", masterId)

                                         };

            int result = sql.execStoredProcudure("PROC_SAVE_UPDATE_SCHEME", spmScheme);
            return result;
        }

        public DataSet bindGrid(int masterId)
        {
            MySqlParameter[] sqlPrm ={
                                       new MySqlParameter("MASTER_ID",masterId)
                                   };
            DataSet ds = sql.getDataSet("PROC_GET_SCHEME", sqlPrm, "");
            return ds;
        }
    }
}
