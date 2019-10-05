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
    public partial class DashboardKpiReportChanged : System.Web.UI.Page
    {
        DashboardKpiReportBLL obll = new DashboardKpiReportBLL();
        public int initiativerecno
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

        public int Planned_Recno
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

        public string KpiName
        {
            get
            {
                if (ViewState["KpiName"] == null)
                    return string.Empty;
                else
                    return (string)ViewState["KpiName"];
            }
            set { ViewState["KpiName"] = value; }
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
            if (!IsPostBack)
            {
                //if (Session["UserRecNo"].ToString() != null || Session["UserRecNo"].ToString() != string.Empty)
                //{
                //    lblUserId.Text = Session["UserRecNo"].ToString();
                //    lblLoginName.Text = Session["LoginName"].ToString();

                if (Request.QueryString["Mode"] != null)
                {
                    string name = (Request.QueryString["Mode"].ToString());
                    string index = (Request.QueryString["Status"].ToString());
                    string kpivlaue = (Request.QueryString["kpi"].ToString());
                    string division = (Request.QueryString["division"].ToString());
                    string page = name;
                    DataSet ds = obll.Fetchdashboardalues(kpivlaue, division, page, index);

                    if(ds != null && ds.Tables[0].Rows.Count >0)
                    {
                        initiativerecno = Convert.ToInt32(ds.Tables[0].Rows[0]["INITIATIVE_RECNO"]);
                      Planned_Recno = Convert.ToInt32(ds.Tables[0].Rows[0]["PLANNED_RECNO"]);
                    }
                   
                    
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
            string initiative = (Planned_Recno.ToString());
            string kpi = (Request.QueryString["kpi"].ToString());

            DataSet ds = obll.GetDetailsDashboardKpiReport(type, initiative, kpi);
            
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
               // divheading.InnerText = ds.Tables[0].Rows[0]["Division"].ToString() + " (" + type + ")";
               // divheading.Attributes.Add("class","bold");
                lblInfo.Text = ds.Tables[0].Rows[0]["Division"].ToString() + " (" + type + ")";
                lblInfo.Font.Bold = true;
                // bindSpeedoMeter();
                KpiName = ds.Tables[0].Rows[0]["KPI"].ToString();
            }

          //  grdvUser.DataSource = ds;
          //  grdvUser.DataBind();


            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (type == "Planned")
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    grdvUser.DataSource = ds;
                    grdvUser.DataBind();
                }
            }

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
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[7].Text = KpiName;
                    //e.Row.Cells[2].Visible = false;
                }
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

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            try
            {
                int j = 0;

                j = GridView1.Rows.Count;
                if (j > 0)
                {
                    GridView1.UseAccessibleHeader = false;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
                    int CellCount = GridView1.FooterRow.Cells.Count;
                    GridView1.FooterRow.Cells.Clear();
                    GridView1.FooterRow.Cells.Add(new TableCell());
                    GridView1.FooterRow.Cells[0].ColumnSpan = CellCount - 1;
                    GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells.Add(new TableCell());

                    TableFooterRow tfr = new TableFooterRow();
                    for (int i = 0; i < CellCount; i++)
                    {
                        tfr.Cells.Add(new TableCell());

                        GridView1.FooterRow.Controls[1].Controls.Add(tfr);
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[7].Text = KpiName;
                    //e.Row.Cells[2].Visible = false;
                }
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
    }
}