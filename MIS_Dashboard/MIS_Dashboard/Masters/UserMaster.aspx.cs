using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace MIS_Dashboard.Masters
{
    public partial class UserMaster : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();

        public string vsStrBindCondition
        {
            get
            {
                if (ViewState["vsStrBindCondition"] == null)
                    return string.Empty;
                else
                    return (string)ViewState["vsStrBindCondition"];
            }
            set { ViewState["vsStrBindCondition"] = value; }
        }
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
        public int vsIntCount
        {
            get
            {
                if (ViewState["vsIntCount"] == null)
                    return -1;
                else
                    return (int)ViewState["vsIntCount"];
            }
            set { ViewState["vsIntCount"] = value; }
        }
        public int vsIntUserRecno
        {
            get
            {
                if (ViewState["vsIntUserRecno"] == null)
                    return -1;
                else
                    return (int)ViewState["vsIntUserRecno"];
            }
            set { ViewState["vsIntUserRecno"] = value; }
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
            Session["LoginName"] = "ADMINISTRATOR";
            Session["UserRecNo"] = 1;
            vsStrBindCondition = "hELLO";
            if (Session["LoginName"] == null || Session["LoginName"].ToString() == string.Empty)
            {
                Session["SessionExpire"] = true;
                //Response.Redirect("~/Mainpage.aspx", false);
                //return;
            }
            try
            {
                int pageID = 16;
                if (!Page.IsPostBack)
                {
                    string strRecentPage = (lblHead.Text.Trim() + "-" + DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt")).ToString();

                    oUserBLL.InsertUserActivityDetails(strRecentPage, Session["LoginName"].ToString());
                    vsIntUserRecno = Convert.ToInt32(Session["UserRecNo"]);
                    //#region Permission Control added by Renu 10/06/2019
                    //int rights = oCommonDAL.GetPermissions(pageID, Convert.ToInt32(Session["UserRecNo"]));
                    //if (rights >= 0)
                    //{
                    //    vsIntRights = rights;
                    //    if (vsIntRights == 0)
                    //    {

                    //        btnAddNewUser.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        btnAddNewUser.Visible = true;
                    //    }
                    //}
                    //else
                    //{
                    //    //Access denied
                    //    Response.Redirect("~/AccessDenied.aspx", false);
                    //}
                    //#endregion

                    vsIntCount = oUserBLL.BindAllUsers(grdvUser, vsStrBindCondition, vsIntUserRecno);



                }

            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "Page_Load";
                String MODULE_NAME = "UserMaster";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

            }

        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (vsIntCount != null)
            {
                if (vsIntCount < 4000)
                {
                    Response.Redirect("~/Masters/AddUser.aspx?md=" + oCommonDAL.EncodeString("ADD"), false);
                }
                else
                {
                    string title = "Message from System";
                    string msg = "Only 4000 Users can be Created.Please Contact to system Administartor";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);


                }
            }
        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            oUserBLL.DeleteUser(grdvUser, sender, vsIntUserRecno, vsStrBindCondition);
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            oUserBLL.EditUser(grdvUser, sender);
        }

        protected void lnbtnViewDetails_Click(object sender, EventArgs e)
        {
            oUserBLL.ViewUser(grdvUser, sender);
        }

        protected void lnkbtnRights_Click(object sender, EventArgs e)
        {
            oUserBLL.AssignRights(grdvUser, sender, vsIntPageRights);
        }

        protected void grdvUser_PreRender(object sender, EventArgs e)
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

        protected void grdvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //#region Right Permissions Check added by Renu 11 June 2019
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton lnkbtnEdit = e.Row.FindControl("lnkbtnEdit") as LinkButton;
            //    LinkButton lnkbtnDelete = e.Row.FindControl("lnkbtnDelete") as LinkButton;
            //    LinkButton lnbtnViewDetails = e.Row.FindControl("lnbtnViewDetails") as LinkButton;
            //    LinkButton lnkbtnRights = e.Row.FindControl("lnkbtnRights") as LinkButton;
            //    if (vsIntRights == 0)
            //    {

            //        lnkbtnEdit.Visible = false;
            //        lnkbtnDelete.Visible = false;
            //        lnbtnViewDetails.Visible = false;
            //        lnkbtnRights.Visible = false;
            //    }
            //    else
            //    {
            //        lnkbtnEdit.Visible = true;
            //        lnkbtnDelete.Visible = true;
            //        lnbtnViewDetails.Visible = true;
            //        lnkbtnRights.Visible = true;
            //    }
            //}
            //#endregion
        }

        protected void lnkbtnDashboardRights_Click(object sender, EventArgs e)
        {
            oUserBLL.AssignDashboardRights(grdvUser, sender, vsIntPageRights);
        }
    }
}