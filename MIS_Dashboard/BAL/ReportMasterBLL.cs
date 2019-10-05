using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BAL
{
    public class ReportMasterBLL
    {
        ReportMasterDLL oDLL = new ReportMasterDLL();
        public int SaveUpdateReportDetails(string ReportNumber, string employee, DateTime auditToDate, DateTime auditFromDate, string Description, string Status, int ReportID, string createdBy)
        {
            return oDLL.SaveUpdateReportDetails(ReportNumber, employee, auditToDate, auditFromDate, Description, Status, ReportID, createdBy);
        }

        public DataSet BindUserDetails()
        {
            return oDLL.BindUserDetails();
        }

        public DataSet BindReportDetails(int ReportID)
        {
            return oDLL.BindReportDetails(ReportID);
        }


        public DataSet ReportMasterEditDetails(int divisionrecno)
        {
            return oDLL.ReportMasterEditDetails(divisionrecno);
        }
    }
}
