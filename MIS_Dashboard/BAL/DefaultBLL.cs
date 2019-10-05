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
  public  class DefaultBLL
    {
      DefaultDLL odll = new DefaultDLL();

        public void BindFirstKPI(DropDownList ddlKpiRange)
        {
            DataSet ds = new DataSet();
            ds = odll.BindFirstKPI();
            ddlKpiRange.DataSource = ds;
            ddlKpiRange.DataTextField = "KPI_NAME";
            ddlKpiRange.DataValueField = "KPI_RECNO";
            ddlKpiRange.DataBind();
           // ddlKpiRange.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindAllDivision(DropDownList ddlDivision)
        {
            DataSet ds = new DataSet();
            ds = odll.BindAllDivision();
            ddlDivision.DataSource = ds;
            ddlDivision.DataTextField = "DIVISION_NAME";
            ddlDivision.DataValueField = "DIVISION_RECNO";
            ddlDivision.DataBind();
        }
    }
}
