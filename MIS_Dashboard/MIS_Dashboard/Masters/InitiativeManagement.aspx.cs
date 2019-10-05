using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BAL;

namespace MIS_Dashboard.Masters
{
    public partial class InitiativeManagement : System.Web.UI.Page
    {
        InitiativeManagementBLL obll = new InitiativeManagementBLL();
        CommonDAL oCommonDAL = new CommonDAL();

        public int UserRecno
        {
            get
            {
                if (ViewState["UserRecno"] == null)
                    return 0;
                else
                    return (int)ViewState["UserRecno"];
            }
            set { ViewState["UserRecno"] = value; }
        } 

        #region Page_PreInit start
        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    SessionFixation();
        //    CoockieCheck();

        //    string UserId = Session["UserId"].ToString();
        //    if (UserId == "6")
        //    {
        //        PageAuthorization();
        //    }
        //    else
        //    {
        //        Response.Redirect("~/HomePage1.aspx");
        //    }
        //}
        //public void PageAuthorization()
        //{
        //    int pageID = 5;
        //    //MySqlParameter[] spm = { new MySqlParameter("@User_Id", Session["UserId"]),
        //    //                   new MySqlParameter("@page_ID",pageID)};
        //    //DataTable dt = nSQL.getDataTable("proc_page_authorization", spm, "tab");
        //    DataTable dt = oCommonDAL.pageAuth(pageID, Session["UserId"]);
        //    int PageRights;
        //    if (dt.Rows.Count > 0)
        //    {
        //        PageRights = Convert.ToInt32(dt.Rows[0]["v_CNT"].ToString());
        //        if (PageRights >= 0)
        //        {
        //            if (PageRights == 0)
        //            {
        //                Response.Redirect("~/HomePage.aspx");
        //            }
        //        }
        //    }


        //}
        //public void SessionFixation()
        //{
        //    string _sessionIPAdress = string.Empty;
        //    string _sessionBrowserInfo = string.Empty;

        //    if (HttpContext.Current.Session != null)
        //    {
        //        string _encryptedString = Convert.ToString(Session["encryptedSession"]);
        //        byte[] _encodedAsBytes = System.Convert.FromBase64String(_encryptedString);
        //        string _decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(_encodedAsBytes);
        //        char[] _separator = new char[] { '^' };
        //        if (_decryptedString != string.Empty && _decryptedString != "" && _decryptedString != null)
        //        {
        //            string[] _splitStrings = _decryptedString.Split(_separator);
        //            if (_splitStrings.Count() > 0)
        //            {
        //                if (_splitStrings[1].Count() > 0)
        //                {
        //                    string[] _userBrowserInfo = _splitStrings[2].Split('~');
        //                    if (_userBrowserInfo.Count() > 0)
        //                    {
        //                        _sessionBrowserInfo = _userBrowserInfo[0];
        //                        _sessionIPAdress = _userBrowserInfo[1];
        //                    }
        //                }
        //            }
        //        }
        //        string _currentuseripAddress;
        //        if (string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARD_FOR"]))
        //        {
        //            _currentuseripAddress = Request.ServerVariables["REMOTE_ADDR"];
        //        }
        //        else
        //        {
        //            _currentuseripAddress = Request.ServerVariables["HTTP_X_FORWARD_FOR"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        //        }
        //        System.Net.IPAddress result;
        //        if (!System.Net.IPAddress.TryParse(_currentuseripAddress, out result))
        //        {
        //            result = System.Net.IPAddress.None;
        //        }

        //        string _currentBrowserInfo = Request.Browser.Browser + Request.Browser.Version + Request.UserAgent;

        //        if (_sessionIPAdress != "" && _sessionIPAdress != string.Empty)
        //        {
        //            if (_sessionIPAdress != _currentuseripAddress || _sessionBrowserInfo != _currentBrowserInfo)
        //            {
        //                Session.RemoveAll();
        //                Session.Clear();
        //                Session.Abandon();
        //                Response.Cookies["ASP.Net_Session_Id"].Expires = DateTime.Now.AddSeconds(-30);
        //                Response.Cookies.Add(new HttpCookie("ASP.Net_Session_Id", ""));
        //            }
        //            else
        //            {
        //                //Valid
        //            }

        //        }
        //        //}
        //    }
        //    else
        //    {
        //        Response.Redirect("~/HomePage.aspx");
        //    }

        //}
        //public void CoockieCheck()
        //{
        //    try
        //    {
        //        Uri MyUrl = Request.UrlReferrer;
        //        string Port = Server.HtmlEncode(MyUrl.Port.ToString());
        //        string Scheme = Server.HtmlEncode(MyUrl.Scheme);
        //        string PreviousPath = Server.HtmlEncode(MyUrl.OriginalString);
        //        string path = HttpContext.Current.Request.Url.AbsolutePath;
        //        string AbsolutePathss = Server.HtmlEncode(MyUrl.AbsolutePath);
        //        string[] Section = PreviousPath.Split('/');
        //        string PagePath = "/MyDashboard/Masters/DivisionMaster.aspx";//C:\inetpub\wwwroot\Vispublished\Master\ComplainTypeMaster.aspx.cs

        //        if (path == PagePath && Port == "80" && Scheme == "http" && PreviousPath != string.Empty && Section[2] == "49.50.117.223" && Section[3] == "MyDashboard")
        //        //if (path == PagePath && Port == "80" && Scheme == "http" && PreviousPath != string.Empty && Section[2] == "49.50.101.77" && Section[3] == "FTSNEW")//&& Section[4] == "49.50.101.77" && Section[4] == "FTSNEW"
        //        {


        //        }
        //        else
        //        {
        //            Response.Redirect("~/HomePage.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/HomePage.aspx");
        //    }
        //}
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    UserRecno = Convert.ToInt32(Session["UserRecNo"]);
                    if (ddlOfficeStatus.SelectedValue == "0")
                    {
                        BindRegion();
                        BindDivision(UserRecno);
                        BindScheme();
                        BindUnit();
                        DivForDivision.Visible = true;
                        DivForRegion.Visible = false;
                    }
                    else if (ddlOfficeStatus.SelectedValue == "1")
                    {
                        BindDivision(UserRecno);
                        BindRegion();
                        BindScheme();
                        BindUnit();
                        DivForDivision.Visible = false;
                        DivForRegion.Visible = true;
                    }
                    BindGrid(0);
                }
                catch (Exception ex)
                {
                    AppConstants OAp = new AppConstants();
                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "InitiativeManagement.aspx";
                    String ERROR_TYPE = "Application";
                    String ERROR_DESC = ex.Message;
                    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                }
            }
        }

        private void BindGrid(int masterId)      
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    BindGrid();
                }
                catch(Exception ex)
                {
                    AppConstants OAp = new AppConstants();
                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "DivisionMaster.aspx";
                    String ERROR_TYPE = "Application";
                    String ERROR_DESC = ex.Message;
                    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                }
            }
        }

        public void BindGrid()
        { 
                int masterId=0;
                DataSet ds = obll.BindGrid(masterId, 0);
                grdvUser.DataSource = ds;
                grdvUser.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string createdBy = "Admin"; // Session["LoginName"].ToString();
                string InitiativeName;
                int activestatus;
                string parameterName="";
                int parametervalue=0;
                int masterID = 0;

                if (txtInitiativeName.Text != string.Empty)
                {
                    InitiativeName = txtInitiativeName.Text;
                }
                else
                {
                    CommonDAL.DisplayPopUpMessage(this, "Division Name Rquired Field", ""); return;
                }
                if (rbtActive.Checked == true)
                {
                    activestatus = 0;
                }
                else
                {
                    activestatus = 1;
                }
                int divisionRecno = 0;
                int officeType = Convert.ToInt32(ddlOfficeStatus.SelectedValue);
                if (officeType == 0)
                {
                    divisionRecno = Convert.ToInt32(ddlDivision.SelectedValue);
                }
                else
                {
                    divisionRecno = Convert.ToInt32(ddlRegion.SelectedValue);
                }
                int schemeRecno = Convert.ToInt32(ddlScheme.SelectedValue);
                int unitRecno = Convert.ToInt32(ddlUnit.SelectedValue);
                string unitname = ddlUnit.SelectedItem.Text;

                //if (rbtnNumeric.Checked == true)
                //{
                //    parameterName = txtParameter.Text;
                //    parametervalue = 0;
                //}
                //else
                //{
                //    if (txtParameterText.Text == string.Empty)
                //    {
                //        CommonDAL.DisplayPopUpMessage(this, "Parameter value can not be empty", "");
                //        return;
                //    }
                //    else
                //        parameterName = txtParameterText.Text;
                //    parametervalue = 1;
                //}


                masterID = Convert.ToInt32(ViewState["InitiativeRecNo"]);


                int result = obll.SaveUpdateInitiveManagement(InitiativeName, officeType, divisionRecno, schemeRecno, unitRecno, masterID, activestatus, createdBy,
                    unitname, parameterName, parametervalue);
                if (result == 1)
                {
                    CommonDAL.DisplayPopUpMessage(this, "Initiative Saved Successfully", "");
                    clear();
                    return;
                }
                else if (result == 2)
                {
                    CommonDAL.DisplayPopUpMessage(this, "Initiative Updated Successfully", "InitiativeManagement.aspx");
                }
                else if (result == -2)
                {
                    CommonDAL.DisplayPopUpMessage(this, "Initiative Already Exist", "");
                    return;
                }
                else
                {
                    CommonDAL.DisplayPopUpMessage(this, "Initiative Not Saved", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "InitiativeManagement.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("InitiativeManagement.aspx");
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnBack_Click";
                String MODULE_NAME = "InitiativeManagement.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
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
                String MODULE_NAME = "InitiativeManagement.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void BindDivision(int UserRecno)
        {
            DataSet ds = obll.BindDivision(UserRecno);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDivision.DataSource = ds;
                ddlDivision.DataTextField = "DIVISION_NAME";
                ddlDivision.DataValueField = "DIVISION_RECNO";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddlDivision.Items.Insert(0, new ListItem("Record Not Found", "0"));
            }
        }
        public void BindRegion()
        {
            DataSet ds = obll.BindRegion();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlRegion.DataSource = ds;
                ddlRegion.DataTextField = "REGION_NAME";
                ddlRegion.DataValueField = "REGION_RECNO";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddlRegion.Items.Insert(0, new ListItem("Record Not Found", "0"));
            }
        }
        public void BindScheme()
        {
            DataSet ds = obll.BindScheme();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlScheme.DataSource = ds;
                ddlScheme.DataTextField = "Scheme";
                ddlScheme.DataValueField = "Scheme_Recno";
                ddlScheme.DataBind();
                ddlScheme.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddlScheme.Items.Insert(0, new ListItem("Record Not Found", "0"));
            }
        }
        public void BindUnit()
        {
            DataSet ds = obll.BindUnit();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlUnit.DataSource = ds;
                ddlUnit.DataTextField = "UNIT_NAME";
                ddlUnit.DataValueField = "UNIT_Recno";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddlUnit.Items.Insert(0, new ListItem("Record Not Found", "0"));
            }
        }

        protected void ddlOfficeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                if (ddlOfficeStatus.SelectedValue == "0")
                {
                    BindRegion();
                    BindDivision(UserRecno);
                    BindScheme();
                    BindUnit();
                    DivForDivision.Visible = true;
                    DivForRegion.Visible = false;
                }
                else if (ddlOfficeStatus.SelectedValue == "1")
                {
                    BindRegion();
                    BindDivision(UserRecno);
                    BindScheme();
                    BindUnit();
                    DivForDivision.Visible = false;
                    DivForRegion.Visible = true;
                }
            }
            else
            {
                if (ddlOfficeStatus.SelectedValue == "0")
                {
                    BindRegion();
                    BindDivision(UserRecno);
                    DivForDivision.Visible = true;
                    DivForRegion.Visible = false;
                }
                else if (ddlOfficeStatus.SelectedValue == "1")
                {
                    BindDivision(UserRecno);
                    BindRegion();
                    DivForDivision.Visible = false;
                    DivForRegion.Visible = true;
                }
            }
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;
            GridViewRow row1 = grdvUser.Rows[row.RowIndex];
            int rowIndex = row1.RowIndex;
            GridViewRow Row = grdvUser.Rows[rowIndex];

            HiddenField hdnInitiativeRecNo = Row.FindControl("hdnInitiativeRecNo") as HiddenField;
            ViewState["InitiativeRecNo"] = hdnInitiativeRecNo.Value;
            Label lblOfficeType = Row.FindControl("lblOfficeType") as Label;
            int officeType;
            if (lblOfficeType.Text == "Corporation Office")
            {
                officeType = 0;
            }
            else
            {
                officeType = 1;
            }
            DataSet ds = obll.BindGrid(Convert.ToInt32(hdnInitiativeRecNo.Value), officeType);
            if ( ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtInitiativeName.Text = ds.Tables[0].Rows[0]["INITIATIVE"].ToString();
                ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Scheme_RECNO"].ToString();
                if (officeType == 0)
                {
                    ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["Division_Region_RECNO"].ToString();
                    DivForDivision.Visible = true;
                    DivForRegion.Visible = false;
                }
                else
                {
                    ddlRegion.SelectedValue = ds.Tables[0].Rows[0]["Division_Region_RECNO"].ToString();
                    DivForDivision.Visible = false;
                    DivForRegion.Visible = true;
                }
                ddlOfficeStatus.SelectedValue = officeType.ToString();
                ddlUnit.SelectedValue = ds.Tables[0].Rows[0]["Unit_RECNO"].ToString();
                int parametervalue = Convert.ToInt32(ds.Tables[0].Rows[0]["Parameter_Status"]);
                if (parametervalue == 0)
                {
                    txtParameter.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parameter"]);
                    rbtnNumeric.Checked = true;
                }
                else
                {
                    txtParameterText.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parameter"]);
                    rbtnTest.Checked = true;
                }

                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
                divForStatus.Visible = true;
                btnSave.Text = "Update";
            }
        }

        public void clear()
        {
            try
            {
                ddlDivision.SelectedIndex = 0;
                ddlRegion.SelectedIndex = 0;
                ddlScheme.SelectedIndex = 0;
                ddlUnit.SelectedIndex = 0;
                rbtActive.Checked = true;
                ddlOfficeStatus.SelectedIndex = 0;
                txtInitiativeName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "clear()";
                String MODULE_NAME = "InitiativeManagement.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Text = "Save";
                ddlDivision.SelectedIndex = 0;
                ddlRegion.SelectedIndex = 0;
                ddlScheme.SelectedIndex = 0;
                ddlUnit.SelectedIndex = 0;
                rbtActive.Checked = true;
                ddlOfficeStatus.SelectedIndex = 0;
                txtInitiativeName.Text = string.Empty;
                divForStatus.Visible = false;
                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnAddNew_Click";
                String MODULE_NAME = "InitiativeManagement.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }

        }

        protected void rbtnNumeric_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNumeric.Checked == true)
            {
                txtParameter.Visible = true;
                txtParameterText.Visible = false;
            }
            else
            {
                txtParameter.Visible = false;
                txtParameterText.Visible = true;
            }
        }

        protected void rbtnTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTest.Checked == true)
            {
                txtParameter.Visible = false;
                txtParameterText.Visible = true;
            }
            else
            {
                txtParameter.Visible = true;
                txtParameterText.Visible = false;
            }
        }

    }
}
