using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
  public class ActualHistoryDetailsDLL
    {
        SqlHelper sql = new SqlHelper();
        public DataSet BindDivision()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_DIVISION_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindInitiaative(int divisionid)
        {
            MySqlParameter[] sqlPrm = {
                                          new MySqlParameter("P_DIVISION_ID",divisionid)
                                      };
            return sql.getDataSet("PROC_BIND_DROPDOWN_INITIATIVE_ON_DIVISION", sqlPrm, "");
        }

        public DataSet BindFirstKPI()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_KPI_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindProgressDate(int divisionid)
        {
            MySqlParameter[] sqlPrm = {
                                          new MySqlParameter("P_DIVISION_ID",divisionid)
                                      };
            return sql.getDataSet("PROC_BIND_DROPDOWN_PROGRESSDATE_ON_DIVISION", sqlPrm, "");
        }

        public DataSet BindHistoryActualDetailsGrid(int divisionid, int initiativeid, int kpirecno, string progressdate)
        {
            MySqlParameter[] sqlPrm = {
                                          new MySqlParameter("P_DIVISION_ID",divisionid),
                                          new MySqlParameter("P_INITIATIVE_RECNO",initiativeid),
                                          new MySqlParameter("P_KPI_RECNO",kpirecno),
                                          new MySqlParameter("P_RECORD_ENTRY_DATE",progressdate)
                                      };
            return sql.getDataSet("PROC_BIND_GRID_ACTUAL_HISTORY_DETAILS_REPORT", sqlPrm, "");
        }
    }
}
