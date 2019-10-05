using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Saplin.Controls;

namespace MIS_Dashboard.Masters
{
    public partial class ReportMaster : System.Web.UI.Page
    {
        ReportMasterBLL obll = new ReportMasterBLL();

        public int vsintReportId
        {
            get
            {
                if (ViewState["vsintReportId"] == null)
                    return 0;
                else
                    return (int)ViewState["vsintReportId"];
            }
            set { ViewState["vsintReportId"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetReportData(0);
                BindEmployee();
                divEnterDetails.Visible = false;
              
            }
        }


        public void BindEmployee()
        {
            DataSet ds = obll.BindUserDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = ds;
                ddlEmployee.DataTextField = "DISPLAY_NAME";
                ddlEmployee.DataValueField = "USER_RECNO";
                ddlEmployee.DataBind();
            }
        }



        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
            GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
            GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
            int rowindex = Convert.ToInt16(row1.RowIndex);
            GridViewRow row = grdvUser.Rows[rowindex];
            HiddenField hdnReportId = (HiddenField)row.FindControl("hdnReportId");
            vsintReportId = Convert.ToInt32(hdnReportId.Value);

            DataSet ds = obll.ReportMasterEditDetails(vsintReportId);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int TotalSelected = 0;
                int No;
                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
                clear();
                btnSave.Text = "Update";
                txtReportNumber.Text = ds.Tables[0].Rows[0]["REPORTNUMBER"].ToString();
                txtAuditFromDate.Text = ds.Tables[0].Rows[0]["AUDIT_FROM_DATE"].ToString();
                txtAuditToDate.Text = ds.Tables[0].Rows[0]["AUDIT_TO_DATE"].ToString();
                txtRptDescription.Text = ds.Tables[0].Rows[0]["Discription"].ToString();

                string value = ds.Tables[0].Rows[0]["EmployeeID"].ToString().Trim();
                string[] plots = value.Split(',');
                foreach (ListItem a in ddlEmployee.Items)
                {
                    foreach (string plt in plots)
                    {
                        if (a.Value == plt)
                        {
                            a.Selected = true;
                            TotalSelected++;
                        }
                    }
                }
                if (TotalSelected == 1)
                {
                    ddlEmployee.Texts.SelectBoxCaption = ddlEmployee.SelectedItem.Text;

                }
                else if (TotalSelected > 1)
                {
                    ddlEmployee.Texts.SelectBoxCaption = "Selected Employee " + TotalSelected.ToString();

                }

            }
            else
            {
               
            }
           }
            catch(Exception ex)
            {
             
            }

     

        }


        public void clear()
        {
            txtAuditFromDate.Text = string.Empty;
            txtAuditToDate.Text = string.Empty;
            txtReportNumber.Text = string.Empty;
            ddlEmployee.SelectedIndex = 0;

        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal totl = 0;
            int TotalSelected = 0;

            foreach (ListItem items in ddlEmployee.Items)
            {

                if (items.Selected)
                {
                    string value = items.Value;

                    TotalSelected++;

                    if (TotalSelected == 1)
                    {
                        ddlEmployee.Texts.SelectBoxCaption = items.Text;
                    }
                    else if (TotalSelected > 1)
                    {
                        ddlEmployee.Texts.SelectBoxCaption = "Selected Employee " + TotalSelected.ToString();
                    }
                }
            }
            lblTotalExtend.Text = totl.ToString();
        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            ViewState["ReportId"] = "0";
            divEnterDetails.Visible = true;
            divGirdShow.Visible = false;
            divForStatus.Visible = false;
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
                String MODULE_NAME = "ReportMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDateTime(txtAuditToDate.Text) > Convert.ToDateTime(txtAuditFromDate.Text))
                {
                    string createdBy = "admin";
                    string employee = "";
                    int TotalSelect = 0;
                    foreach (ListItem chk in ddlEmployee.Items)
                    {
                        if (chk.Selected)
                        {
                            TotalSelect++;

                            if (TotalSelect == 1)
                            {
                                ddlEmployee.Texts.SelectBoxCaption = chk.Text;
                                employee += Convert.ToInt32(chk.Value);
                            }
                            else if (TotalSelect > 1)
                            {
                                ddlEmployee.Texts.SelectBoxCaption = "Selected Employee " + TotalSelect.ToString();
                                employee += "," + (chk.Value);
                            }
                        }
                    }
                    int Result = obll.SaveUpdateReportDetails(txtReportNumber.Text, employee, Convert.ToDateTime(txtAuditToDate.Text), Convert.ToDateTime(txtAuditFromDate.Text), txtRptDescription.Text, rbtnStatus.SelectedValue, vsintReportId, createdBy);
                    if (Result == 1)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Report Saved Successfully", "ReportMaster.aspx");
                    }
                    else if (Result == 3)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Report Updated Successfully", "ReportMaster.aspx");
                    }
                    else
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Report Not Saved", "ReportMaster.aspx");
                    }
                }
                else
                {
                    CommonDAL.DisplayPopUpMessage(this, "Audit To Date must be greater than Audit From Date", "ReportMaster.aspx");
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "ReportMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divGirdShow.Visible = true;
            divEnterDetails.Visible = false;

        }
        private void GetReportData(int ReportID)
        {
            try
            {
                DataSet ds = obll.BindReportDetails(ReportID);
                grdvUser.DataSource = ds;
                grdvUser.DataBind();
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "ReportMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }
    }
}