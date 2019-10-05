using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ReportMasterDLL
    {
        SqlHelper sql = new SqlHelper();
        public int SaveUpdateReportDetails(string reportNumber, string employee, DateTime auditToDate, DateTime auditFromDate, string description, string status, int reportID, string createdBy)
        {
            MySqlParameter[] spmLogin =
            {
                new MySqlParameter("ReportId",reportID),
                new MySqlParameter("Employee",employee),
                new MySqlParameter("ReportNumber",reportNumber),
                new MySqlParameter("AuditToDate",auditToDate),
                new MySqlParameter("AuditFromDate",auditFromDate),
                new MySqlParameter("Description",description),
                new MySqlParameter("Status",status),
                new MySqlParameter("CreatedBy",createdBy)
            };
            return sql.execStoredProcudure("Proc_Save_Update_Report_Details", spmLogin);
        }

        public DataSet BindReportDetails(int ReportID)
        {
            MySqlParameter[] spmLogin = {
                new MySqlParameter("ReportID",ReportID)
                                        };
            return sql.getDataSet("PROC_BIND_GRID_REPORT", spmLogin, "");
        }

        public DataSet BindUserDetails()
        {
            MySqlParameter[] spmLogin = {

                                        };
            return sql.getDataSet("Proc_Get_User_Details", spmLogin, "");
        }


        public DataSet ReportMasterEditDetails(int divisionrecno)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_REPORT_ID",divisionrecno)
                                        };
            DataSet result = sql.getDataSet("PROC_EDIT_REPORT_MASTER_DETAILS", spmLogin, "");
            return result;
        }

    }
}
