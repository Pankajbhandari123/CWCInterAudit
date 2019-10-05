using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace DAL
{
    public class RegionMasterDLL
    {
        SqlHelper sql = new SqlHelper();
        public DataSet bindGrid(int masterId)
        {
            MySqlParameter[] sqlPrm ={
                                       new MySqlParameter("MASTER_ID",masterId)
                                   };
            return sql.getDataSet("PROC_GET_REGION_DETAILS", sqlPrm, "");
        }

        public int SaveUpdateRegion(int activeStatus, string createdBy, string RegionName, string RegionCode, int masterID)
        {
            MySqlParameter[] sqlPrm ={
                                       new MySqlParameter("activeStatus",activeStatus),
                                       new MySqlParameter("createdBy",createdBy),
                                       new MySqlParameter("RegionName",RegionName),
                                       new MySqlParameter("RegionCode",RegionCode),
                                       new MySqlParameter("masterID",masterID)
                                   };
            return sql.execStoredProcudure("PROC_SAVE_UPDATE_REGION_DETAILS", sqlPrm);
        }
    }
}
