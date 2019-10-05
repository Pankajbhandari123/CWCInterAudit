using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Web.UI.WebControls;
using System.Data;


namespace DAL
{
    public class DashboardKpiReportDLL
    {
        SqlHelper sql = new SqlHelper();
        public DataSet GetDetailsDashboardKpiReport(string type, string initiative, string kpi)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_TYPE",type),
                                            new MySqlParameter("P_INITIATIVE",initiative),
                                            new MySqlParameter("P_KPI_RECNO",kpi)
                                        };
            DataSet result = sql.getDataSet("PROC_BIND_DASHBOARD_KPI_REPORT", spmLogin, "");
            return result;
        }

        public DataSet Fetchdashboardalues(string kpivlaue, string division, string page, string index)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_KPI_RECNO",kpivlaue),
                                            new MySqlParameter("P_DIVISION_RECNO",division),
                                            new MySqlParameter("P_PAGE",page),
                                            new MySqlParameter("P_INDEX",index)
                                        };
            DataSet result = sql.getDataSet("PROC_GET_DATA_FOR_KPI_DASHBOARD", spmLogin, "");
            return result;
        }
    }
}
