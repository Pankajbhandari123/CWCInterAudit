using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using DAL;

namespace BAL
{
   public class DashboardKpiReportBLL
    {
       DashboardKpiReportDLL odll = new DashboardKpiReportDLL();
       public DataSet GetDetailsDashboardKpiReport(string type, string initiative, string kpi)
        {
            return odll.GetDetailsDashboardKpiReport(type, initiative, kpi);
        }

        public DataSet Fetchdashboardalues(string kpivlaue, string division, string page, string index)
        {
            return odll.Fetchdashboardalues( kpivlaue,  division,  page,  index);
        }
    }
}
