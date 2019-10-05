using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;


namespace MIS_Dashboard.Report
{
    public partial class DashboardKpiReport : System.Web.UI.Page
    {
        DashboardKpiReportBLL obll = new DashboardKpiReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserRecNo"].ToString() != null || Session["UserRecNo"].ToString() != string.Empty)
                //{
                //    lblUserId.Text = Session["UserRecNo"].ToString();
                //    lblLoginName.Text = Session["LoginName"].ToString();

                if (Request.QueryString["Mode"] != null)
                {
                    string kpivlaue = (Request.QueryString["kpi"].ToString());
                    string division = (Request.QueryString["division"].ToString());
                    string initiativerecno = (Request.QueryString["InitRec"].ToString());

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "getspeedoMeterStatus(" + "'" + kpivlaue + "'" + "," 
                      + "'" + division + "'" + "," + "'" + initiativerecno + "'" + ");", true);

                    BindGrid();

                }
                //    else
                //    {
                //        //BindGrid(Convert.ToInt32(Session["Emp_Recno"]));
                //    }
                //}
            }
        }

        public void BindGrid()
        {
            string type = (Request.QueryString["Mode"].ToString()).Trim();
            string initiative = (Request.QueryString["Status"].ToString());

            DataSet ds = obll.GetDetailsDashboardKpiReport(type, initiative);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // bindSpeedoMeter();
            }

            grdvUser.DataSource = ds;
            grdvUser.DataBind();

            divGirdShow.Visible = true;
            divSubmition.Visible = true;
        }

        protected void grdvUser_PreRender(object sender, EventArgs e)
        {
            try
            {
                int j = 0;

                j = grdvUser.Rows.Count;
                if (j > 0)
                {
                    grdvUser.UseAccessibleHeader = false;
                    grdvUser.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdvUser.FooterRow.TableSection = TableRowSection.TableFooter;
                    int CellCount = grdvUser.FooterRow.Cells.Count;
                    grdvUser.FooterRow.Cells.Clear();
                    grdvUser.FooterRow.Cells.Add(new TableCell());
                    grdvUser.FooterRow.Cells[0].ColumnSpan = CellCount - 1;
                    grdvUser.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    grdvUser.FooterRow.Cells.Add(new TableCell());

                    TableFooterRow tfr = new TableFooterRow();
                    for (int i = 0; i < CellCount; i++)
                    {
                        tfr.Cells.Add(new TableCell());

                        grdvUser.FooterRow.Controls[1].Controls.Add(tfr);
                    }
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "grdvUser_PreRender";
                String MODULE_NAME = "DashboardKpiReport.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void grdvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    e.Row.Cells[0].Visible = false; // Invisibiling Period Header Cell
                //    e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
                //    e.Row.Cells[2].Visible = false; // Invisibiling  Header Cell
                //    e.Row.Cells[3].Visible = false; // Invisibiling  Header Cell
                //}
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "grdvUser_RowDataBound";
                String MODULE_NAME = "DashboardKpiReport.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }

        }

        protected void grdvUser_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    GridView ProductGrid = (GridView)sender;
                //    GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //    //Adding sl Column
                //    TableCell HeaderCell = new TableCell();
                //    HeaderCell.Text = "Sl.No.";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.RowSpan = 3;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderCell.Font.Bold = true;

                //    HeaderRow.Cells.Add(HeaderCell);

                //    HeaderCell = new TableCell();
                //    HeaderCell.Text = "Initiative";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.RowSpan = 3;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderRow.Cells.Add(HeaderCell);
                //    HeaderCell.Font.Bold = true;

                //    //Adding scheme Column
                //    HeaderCell = new TableCell();
                //    HeaderCell.Text = "Scheme/ program, if any";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.RowSpan = 3;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderRow.Cells.Add(HeaderCell);
                //    HeaderCell.Font.Bold = true;

                //    //Adding changes  Column
                //    HeaderCell = new TableCell();
                //    HeaderCell.Text = "Requires changes in law (Yes/No)";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.RowSpan = 3;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderRow.Cells.Add(HeaderCell);
                //    HeaderCell.Font.Bold = true;

                //    //Adding kpi Column
                //    HeaderCell = new TableCell();
                //    HeaderCell.Text = "Key Performance Indicator (KPIs)";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.ColumnSpan = 9;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderRow.Cells.Add(HeaderCell);
                //    HeaderCell.Font.Bold = true;


                //    ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);

                //    HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //    //Adding quantitative Debit Column
                //    HeaderCell = new TableCell();
                //    HeaderCell.Text = "Quantitative Target";
                //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //    HeaderCell.ColumnSpan = 9;
                //    HeaderCell.CssClass = "HeaderStyle";
                //    HeaderRow.Cells.Add(HeaderCell);
                //    HeaderCell.Font.Bold = true;


                //    ProductGrid.Controls[0].Controls.AddAt(1, HeaderRow);
                //}
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "grdvUser_RowCreated";
                String MODULE_NAME = "DashboardKpiReport.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }

        }


    }
}