using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitMasterDLL
    {
        SqlHelper sql = new SqlHelper();
        public System.Data.DataSet BindGrid(int masterId)
        {
            MySqlParameter[] sqlPrm ={
                                         new MySqlParameter("@MASTER_ID",masterId)
            };
            return sql.getDataSet("PROC_GET_UNIT_DETAILS", sqlPrm, "");
        }

        public int SaveUpdateScheme(int activeStatus, string createdBy, string unitName, int masterID)
        {
            MySqlParameter[] sqlPrm ={
                                         new MySqlParameter("@masterID",masterID),
                                         new MySqlParameter("@activeStatus",activeStatus),
                                         new MySqlParameter("@createdBy",createdBy),
                                         new MySqlParameter("@unitName",unitName),
            };
            return sql.execStoredProcudure("PROC_SAVE_UPDATE_UNIT_DETAILS", sqlPrm);
        }
    }
}
