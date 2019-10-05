using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Para_MasterBLL
    {
        Para_MasterDLL oDll = new Para_MasterDLL();
        public DataSet BindReportDropDown()
        {
            return oDll.BindReportDropDown();
        }

        public int SaveUpdateParaDetails(string ParaName, int ParaId, string ParaSubject, string ReportID)
        {
            return oDll.SaveUpdateParaDetails(ParaName, ParaId, ParaSubject, ReportID);
        }
    }
}
