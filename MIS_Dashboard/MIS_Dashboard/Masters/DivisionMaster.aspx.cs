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
    public partial class DivisionMaster : System.Web.UI.Page
    {

        DivisionMasterBLL obll = new DivisionMasterBLL();
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

        public int divisionRecno
        {
            get
            {
                if (ViewState["divisionRecno"] == null)
                    return 0;
                else
                    return (int)ViewState["divisionRecno"];
            }
            set { ViewState["divisionRecno"] = value; }
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    UserRecno = Convert.ToInt32(Session["UserRecNo"]);
                    BindGrid();
                }
                catch (Exception ex)
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

            DataSet ds = obll.BindGrid();

            grdvUser.DataSource = ds;
            grdvUser.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string createdBy = "Admin"; // Session["LoginName"].ToString();
                string divisionName;
                int activestatus;
                int masterID = 0;

                if (txtDivisionName.Text != string.Empty)
                { divisionName = txtDivisionName.Text; }
                else
                { CommonDAL.DisplayPopUpMessage(this, "Division Name Rquired Field", ""); return; }
                if (rbtActive.Checked == true)
                { activestatus = 0; }
                else
                { activestatus = 1; }

                masterID = divisionRecno;

                if (masterID == 0)
                {
                    int result = obll.SaveUpdatedivisiondetails(masterID, divisionName, activestatus, createdBy);
                    if (result == -2)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Record Already Exists.", "");
                        return;
                    }
                    else
                    {
                        clear();
                        CommonDAL.DisplayPopUpMessage(this, "Division Record Saved", "");
                        return;
                    }
                }
                else
                {
                    int result = obll.SaveUpdatedivisiondetails(masterID, divisionName, activestatus, createdBy);
                    if (result == -2)
                    {
                        CommonDAL.DisplayPopUpMessage(this, "Record Already Exists.", "");
                        return;
                    }
                    else
                    {
                        divGirdShow.Visible = true;
                        divEnterDetails.Visible = false;
                        clear();
                        CommonDAL.DisplayPopUpMessage(this, "Division Record Updated", "");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "DivisionMaster.aspx";
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
                Response.Redirect("~/Masters/DivisionMaster.aspx");
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnBack_Click";
                String MODULE_NAME = "DivisionMaster.aspx";
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
                String MODULE_NAME = "DivisionMaster.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            divGirdShow.Visible = false;
            divEnterDetails.Visible = true;
            clear();
            btnSave.Text = "Save";
            divactive.Visible = false;
        }

        public void clear()
        {
            txtDivisionName.Text = string.Empty;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
            GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
            int rowindex = Convert.ToInt16(row1.RowIndex);

            GridViewRow row = grdvUser.Rows[rowindex];
            HiddenField hdnDivisionrecno = (HiddenField)row.FindControl("hdnDivisionrecno");
            int divisionrecno = Convert.ToInt32(hdnDivisionrecno.Value);
            divisionRecno = divisionrecno;

            DataSet ds = obll.GetEditDetails(divisionrecno);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                divGirdShow.Visible = false;
                divEnterDetails.Visible = true;
                clear();
                btnSave.Text = "Update";


                txtDivisionName.Text = ds.Tables[0].Rows[0]["DIVISION_NAME"].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["ACTIVE_STATUS"]) == 0)
                    rbtActive.Checked = true;
                else
                    rbtInactive.Checked = true;
                divactive.Visible = true;
            }
            else
            {
                divisionRecno = 0;
            }

        }


    }
}