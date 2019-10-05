using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BAL;
using MySql.Data.MySqlClient;

namespace MIS_Dashboard.Masters
{
    public partial class SchemeMaster : System.Web.UI.Page
    {
        SchemeMasterrBLL obll = new SchemeMasterrBLL();
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
                    bindGrid(0);
                }
                catch (Exception ex)
                {
                    AppConstants OAp = new AppConstants();
                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "SchemeMaster.aspx";
                    String ERROR_TYPE = "Application";
                    String ERROR_DESC = ex.Message;
                    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                }
            }
        }
        private void bindGrid(int masterId)
        {
            try
            {
                DataSet ds = obll.bindGrid(masterId);
                grdvUser.DataSource = ds;
                grdvUser.DataBind();
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "Page_Load";
                String MODULE_NAME = "SchemeMaster.aspx";
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
                string createdBy = "Admin"; // Session["LoginName"].ToString();
                string schemeName;
                if (btnSave.Text == "Save")
                {
                    int activeStatus = 0;
                    int masterID = 0;

                    if (txtSchemeName.Text != string.Empty && txtSchemeName.Text != "")
                    {
                        schemeName = txtSchemeName.Text;
                    }
                    else
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Name Rquired Field", "");
                        return;
                    }
                    int result = obll.SaveUpdateScheme(activeStatus, createdBy, schemeName, masterID);
                    if (result > 0)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Saved Successfully", "");
                        bindGrid(0);
                        divGirdShow.Visible = true;
                        divEnterDetails.Visible = false;
                    }
                    else if (result == -3)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Already Exist", "");
                        return;
                    }
                    else
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Not Saved", "");
                        return;
                    }
                }
                else
                {
                    int activeStatus;
                    string scheme;
                    if (rbtActive.Checked == true)
                    {
                        activeStatus = 0;
                    }
                    else
                    {
                        activeStatus = 1;
                    }
                    if (txtSchemeName.Text != string.Empty && txtSchemeName.Text != "")
                    {
                        scheme = txtSchemeName.Text;
                    }
                    else
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Name Rquired Field", "");
                        return;
                    }
                    int result = obll.SaveUpdateScheme(activeStatus, createdBy, scheme, Convert.ToInt32(ViewState["SchemeRecNo"]));
                    if (result > 0)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Updated Successfully", "");
                        bindGrid(0);
                        divGirdShow.Visible = true;
                        divEnterDetails.Visible = false;
                    }
                    else if (result == -3)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Already Exist", "");
                        return;
                    }
                    else
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Scheme Not Updated", "");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "SchemeMaster.aspx";
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
                Response.Redirect("SchemeMaster.aspx");
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnBack_Click";
                String MODULE_NAME = "SchemeMaster.aspx";
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
                String MODULE_NAME = "SchemeMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtSchemeName.Text = string.Empty;
                rbtActive.Checked = true;
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnClear_Click";
                String MODULE_NAME = "SchemeMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            divEnterDetails.Visible = true;
            divGirdShow.Visible = false;
            divForStatus.Visible = false;
            txtSchemeName.Text = string.Empty;
            btnSave.Text = "Save";
            rbtActive.Checked = true;
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;
            GridViewRow row1 = grdvUser.Rows[row.RowIndex];
            int rowindex = row1.RowIndex;
            GridViewRow Row = grdvUser.Rows[rowindex];

            HiddenField hdnSchemeRecNo = Row.FindControl("hdnSchemeRecNo") as HiddenField;
            DataSet ds = obll.bindGrid(Convert.ToInt32(hdnSchemeRecNo.Value));
            ViewState["SchemeRecNo"] = Convert.ToInt32(hdnSchemeRecNo.Value);
            txtSchemeName.Text = ds.Tables[0].Rows[0]["SCHEME"].ToString();
            if (ds.Tables[0].Rows[0]["ACTIVE_STATUS"].ToString() == "Active")
            {
                rbtActive.Checked = true;
            }
            else
            {
                rbtInactive.Checked = true;
            }
            divGirdShow.Visible = false;
            divForStatus.Visible = true;
            divEnterDetails.Visible = true;
            btnSave.Text = "Update";
        }

    }
}