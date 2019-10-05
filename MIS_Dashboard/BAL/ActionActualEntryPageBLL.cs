using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using DAL;
using System.Web.UI.WebControls;

namespace BAL
{
  public  class ActionActualEntryPageBLL
    {
      ActionActualEntryPageDLL odll = new ActionActualEntryPageDLL();

      public DataSet BindDivision(int UserRecno)
        {
            return odll.BindDivision(UserRecno);
        }

        public DataSet BindRegion()
        {
            return odll.BindRegion();
        }

        public DataSet BindGridForEditDetails(int masterid, string recordDate)
        {
            return odll.BindGridForEditDetails(masterid, recordDate);
        }

        public DataSet BindUnit()
        {
            return odll.BindUnit();
        }

        //public int SaveUpdateDetails(int masterid, string recorddate, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno, string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string august, string firstYear, string secondYear, string thirdYear, string fourthYear, string fifthYear, string parameterRemarks, string hundredDyasRemarks, string augustRemarks, string firstYearRemarks, string secondYearRemarks, string thirdYearRemarks, string fourthYearRemarks,
        //                 string fifthYearRemarks, string createdBy)
        //{
        //    return odll.SaveUpdateDetails(masterid, recorddate, officetype, divisionRegionRecno, divisionRegionName, initiativerecno, initiativeName, scheme, requireChnages, requirechangesRemarks, parameter, unitname, hundredDyas, august, firstYear, secondYear, thirdYear, fourthYear, fifthYear, parameterRemarks, hundredDyasRemarks, augustRemarks, firstYearRemarks, secondYearRemarks, thirdYearRemarks, fourthYearRemarks,
        //                  fifthYearRemarks, createdBy);
        //}

        public int SaveUpdateDetails(int masterid, string recorddate, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno, string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string parameterRemarks, string hundredDyasRemarks, string kpirecno, string createdBy, string CompletedStatus)
        {
            return odll.SaveUpdateDetails(masterid, recorddate, officetype, divisionRegionRecno, divisionRegionName, initiativerecno, initiativeName, scheme, requireChnages, requirechangesRemarks, parameter, unitname, hundredDyas, parameterRemarks, hundredDyasRemarks, kpirecno, createdBy, CompletedStatus);
        }

        public DataSet GetBindGridData(int ID, string recordDate, string kpi)
        {
            return odll.GetBindGridData(ID, recordDate, kpi);
        }

        public void BindFirstKPI(DropDownList ddlKpiRange)
        {
            DataSet ds = new DataSet();
            ds = odll.BindFirstKPI();
            ddlKpiRange.DataSource = ds;
            ddlKpiRange.DataTextField = "KPI_NAME";
            ddlKpiRange.DataValueField = "KPI_RECNO";
            ddlKpiRange.DataBind();
            ddlKpiRange.Items.Insert(0, new ListItem("Select", "0"));
        }

        public DataSet BindGridForEditDetailsPgaeActual(int masterid, string recordDate, int kpiid)
        {
            return odll.BindGridForEditDetailsPgaeActual(masterid, recordDate, kpiid);
        }
    }
}
