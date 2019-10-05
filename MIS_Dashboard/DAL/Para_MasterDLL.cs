using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Para_MasterDLL
    {
        SqlHelper sql = new SqlHelper();
        public DataSet BindReportDropDown()
        {
            MySqlParameter[] smpLogin ={
            };
            return sql.getDataSet("Proc_Get_Report_Name", smpLogin, "");
        }

        public int SaveUpdateParaDetails(string ParaName, int ParaId, string ParaSubject, string ReportID)
        
        {
            MySqlParameter[] smpLogin ={
                new MySqlParameter("paraName",ParaName),
                new MySqlParameter("Master_Id",ParaId),
                new MySqlParameter("paraSubject",ParaSubject),
                new MySqlParameter("reportID",ReportID)
            };
            return sql.execStoredProcudure("PROC_SAVE_UPDATE_PARA_DETAILS", smpLogin);
        }








    }
}
