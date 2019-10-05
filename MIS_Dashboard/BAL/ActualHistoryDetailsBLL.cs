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
  public   class ActualHistoryDetailsBLL
    {
      ActualHistoryDetailsDLL odll = new ActualHistoryDetailsDLL();

      public void BindDivision(DropDownList ddlDivision)
      {
          DataSet ds = odll.BindDivision();
          if (ds.Tables[0].Rows.Count > 0)
          {
              ddlDivision.DataSource = ds;
              ddlDivision.DataTextField = "DIVISION_NAME";
              ddlDivision.DataValueField = "DIVISION_RECNO";
              ddlDivision.DataBind();
              ddlDivision.Items.Insert(0, new ListItem("All", "0"));
          }
          else
          {
              ddlDivision.Items.Insert(0, new ListItem("Record Not Found", "0"));
          }
      }

      public void BindInitiaative(DropDownList ddlInitiative, int divisionid)
      {
          DataSet ds = odll.BindInitiaative(divisionid);

          ddlInitiative.DataSource = ds;
          ddlInitiative.DataTextField = "INITIATIVE";
          ddlInitiative.DataValueField = "INITIATIVE_RECNO";
          ddlInitiative.DataBind();
          ddlInitiative.Items.Insert(0, new ListItem("All", "0"));
      }



      public void BindFirstKPI(DropDownList ddlKpiRange)
      {
          DataSet ds = new DataSet();
          ds = odll.BindFirstKPI();
          ddlKpiRange.DataSource = ds;
          ddlKpiRange.DataTextField = "KPI_NAME";
          ddlKpiRange.DataValueField = "KPI_RECNO";
          ddlKpiRange.DataBind();
          ddlKpiRange.Items.Insert(0, new ListItem("All", "0"));
      }

      public void BindProgressDate(DropDownList ddlProgressDate, int divisionid)
      {
          DataSet ds = new DataSet();
          ds = odll.BindProgressDate(divisionid);
          ddlProgressDate.DataSource = ds;
          ddlProgressDate.DataTextField = "RECORD_ENTRY_DATE";
          ddlProgressDate.DataValueField = "RECORD_ENTRY_DATE";
          ddlProgressDate.DataBind();
          ddlProgressDate.Items.Insert(0, new ListItem("All", "0"));
      }

      public DataSet BindHistoryActualDetailsGrid(int divisionid, int initiativeid, int kpirecno, string progressdate)
      {
          return odll.BindHistoryActualDetailsGrid( divisionid,  initiativeid,  kpirecno,  progressdate);
      }
    }
}
