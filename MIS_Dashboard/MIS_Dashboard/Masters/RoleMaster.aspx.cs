using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Configuration;

namespace MIS_Dashboard.Masters
{
    public partial class RoleMaster : System.Web.UI.Page
    {

        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommomDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();

        public int vsIntPageRights
        {
            get
            {
                if (ViewState["vsIntPageRights"] == null)
                    return -1;
                else
                    return (int)ViewState["vsIntPageRights"];
            }
            set { ViewState["vsIntPageRights"] = value; }
        }
        #region Permission Control
        public int vsIntRights
        {
            get
            {
                if (ViewState["vsIntRights"] == null)
                    return 0;
                else
                    return (int)ViewState["vsIntRights"];
            }
            set { ViewState["vsIntRights"] = value; }
        }
        #endregion
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
            if (Session["LoginName"] == null || Session["LoginName"].ToString() == string.Empty)
            {
                Session["SessionExpire"] = true;
                //Response.Redirect("~/Mainpage.aspx", false);
                //return;
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    int pageID = 10;
                    //#region Permission Control 
                    //int rights = oCommomDAL.GetPermissions(pageID, Convert.ToInt32(Session["UserRecNo"]));
                  
                    //if (rights >= 0)
                    //{
                    //    vsIntRights = rights;
                    //    if (vsIntRights == 0)
                    //    {

                    //        lbtnAddRole.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lbtnAddRole.Visible = true;
                    //    }
                    //}
                    //else
                    //{
                    //    //Access denied
                    //    Response.Redirect("~/AccessDenied.aspx", false);
                    //}
                    //#endregion
                    oUserBLL.GetROLETYPE(ddlRoleType);
                    BindGrid();
                    // divEnterDetails.Visible = false;

                }
                catch (Exception ex)
                {
                    AppConstants OAp = new AppConstants();
                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "RoleMaster.aspx";
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
            try
            {
                oUserBLL.GetroleDetails(grdvAddrole, divGirdShow);
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "BindGrid";
                String MODULE_NAME = "RoleMaster.aspx";
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

        public void clear()
        {
            txtrolename.Text = "";
            ddlRoleType.SelectedValue = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    string createdby = Session["LoginName"].ToString();
                    //oUserBLL.insertRole(txtrolename, ddlRoleType, createdby);
                    ////string msg = "<script>alert('RoleMaster Data Saved Successfully')</script>";
                    ////ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                    //divEnterDetails.Visible = false;
                    //divGirdShow.Visible = true;
                    //lbtnAddRole.Text = "Add Role";
                    //lbtnAddRole.Visible = true;
                    //BindGrid();
                    int result = oUserBLL.insertRole(txtrolename, ddlRoleType, createdby);
                    if (result > 0)
                    {
                        string title = "Message from System";
                        string msg = "Role Details Inserted Successfully";
                        //  ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                        divEnterDetails.Visible = false;
                        divGirdShow.Visible = true;
                        lbtnAddRole.Text = "Add Role";
                        lbtnAddRole.Visible = true;
                        BindGrid();
                    }
                    else if (result == -2)
                    {
                        string title = "Message from System";
                        string msg = "Role Details must be distinct values ";
                        //  ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                        return;
                    }
                    else
                    {
                        string title = "Message from System";
                        string msg = "Role Details Not Inserted Successfully";
                        //  ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                        return;
                    }

                }
                else
                {
                    string modifiedby = Session["LoginName"].ToString();
                    oUserBLL.updaterole(hdnRole, txtrolename, ddlRoleType, sender, divEnterDetails, divGirdShow, modifiedby);
                    string msg = "<script>alert('RoleMaster Data Updated Successfully')</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                    CommonDAL.DisplayPopUpMessage(this, "", "");
                    btnSave.Text = "Save";
                    divEnterDetails.Visible = false;
                    divGirdShow.Visible = true;
                    lbtnAddRole.Text = "Add Role";
                    BindGrid();
                }
            }
            catch (Exception ex)
            {

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "RoleMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);


            }
        }

        protected void lkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Text = "Update";

                DataSet ds = new DataSet();
                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
                lbtnAddRole.Text = "Back";
                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);
                HiddenField hdnRolerecno = (HiddenField)gridViewRow.FindControl("hdnRolerecno");

                hdnRole.Value = hdnRolerecno.Value;

                int Role_Recno = Convert.ToInt32(hdnRolerecno.Value);
                ds = oUserBLL.GetRole(Role_Recno);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        txtrolename.Text = ds.Tables[0].Rows[0]["ROLE_NAME"].ToString();

                        //foreach (ListItem item in ddlRoleType.Items)
                        //{
                        //    if (item.Text == ds.Tables[0].Rows[0]["ROLE_USER_TYPE"].ToString())
                        //    {
                        //        item.Selected = true;
                        //        break;
                        //    }
                        //}
                        ddlRoleType.SelectedValue = ds.Tables[0].Rows[0]["ROLE_USER_TYPE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "lkbtnEdit_Click";
                String MODULE_NAME = "RoleMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);


            }
        }

        protected void grdvAddrole_PreRender(object sender, EventArgs e)
        {
            try
            {
                int j = 0;

                j = grdvAddrole.Rows.Count;
                if (j > 0)
                {
                    grdvAddrole.UseAccessibleHeader = false;
                    grdvAddrole.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdvAddrole.FooterRow.TableSection = TableRowSection.TableFooter;
                    int CellCount = grdvAddrole.FooterRow.Cells.Count;
                    grdvAddrole.FooterRow.Cells.Clear();
                    grdvAddrole.FooterRow.Cells.Add(new TableCell());
                    grdvAddrole.FooterRow.Cells[0].ColumnSpan = CellCount - 1;
                    grdvAddrole.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    grdvAddrole.FooterRow.Cells.Add(new TableCell());

                    TableFooterRow tfr = new TableFooterRow();
                    for (int i = 0; i < CellCount; i++)
                    {
                        tfr.Cells.Add(new TableCell());

                        grdvAddrole.FooterRow.Controls[1].Controls.Add(tfr);
                    }
                }
            }
            catch (Exception ex)
            {

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "grdvAddrole_PreRender";
                String MODULE_NAME = "RoleMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);


            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divEnterDetails.Visible = false;
            divGirdShow.Visible = true;

            clear();
        }

        protected void grdvAddrole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //#region Right Permissions Check added by Renu 11 June 2019
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton lkbtnEdit = e.Row.FindControl("lkbtnEdit") as LinkButton;

            //    if (vsIntRights == 0)
            //    {

            //        lkbtnEdit.Visible = false;
            //    }
            //    else
            //    {
            //        lkbtnEdit.Visible = true;
            //    }
            //}
            //#endregion
        }

        protected void lbtnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
                btnSave.Text = "Save";
                btnSave.Visible = true;
                clear();
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "lbtnAddRole_Click";
                String MODULE_NAME = "RoleMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

            }
           
        }

    }
}