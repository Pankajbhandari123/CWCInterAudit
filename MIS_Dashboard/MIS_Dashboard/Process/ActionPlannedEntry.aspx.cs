using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BAL;

namespace MIS_Dashboard.Process
{
    public partial class ActionPlannedEntry : System.Web.UI.Page
    {
        ActionPlannedEntryBLL obll = new ActionPlannedEntryBLL();
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
            try
            {
                if (!Page.IsPostBack)
                {
                    UserRecno = Convert.ToInt32(Session["UserRecNo"]);
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
                   PageLoadBindGrid();
                }
               
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "Page_Load";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }


        }

        public void BindDivision(int UserRecno)
        {
            try
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
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "BindDivision";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
           
        }

        public void BindRegion()
        {
            try
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
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "BindRegion";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
           
        }

        public void BindUnit()
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                    DataSet ds = obll.BindUnit();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlUnit.DataSource = ds;
                        ddlUnit.DataTextField = "Unit_Name";
                        ddlUnit.DataValueField = "Unit_Recno";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else
                    {
                        ddlUnit.Items.Insert(0, new ListItem("Record Not Found", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "BindUnit";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void BindGrid()
        {
            try
            {
                int masterid;
                if (ddlOfficeStatus.SelectedValue == "0")
                {
                    masterid = Convert.ToInt32(ddlDivision.SelectedValue);
                }
                else
                {
                    masterid = Convert.ToInt32(ddlRegion.SelectedValue);
                }

                DataSet ds = obll.BindGridForEditDetails(masterid);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                
                if (ds.Tables[0].Rows[0]["PLANNED_RECNO"].ToString() != "0")
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        HiddenField hdnInitiativeRecNo = (HiddenField)GridView1.Rows[i].FindControl("hdnInitiativeRecNo");
                        HiddenField hdnPlannedRecno = (HiddenField)GridView1.Rows[i].FindControl("hdnPlannedRecno");
                        Label lblInitiative = (Label)GridView1.Rows[i].FindControl("lblInitiative");
                        Label lblScheme = (Label)GridView1.Rows[i].FindControl("lblScheme");
                        DropDownList ddlRequireChanges = (DropDownList)GridView1.Rows[i].FindControl("ddlRequireChanges");
                        TextBox txtRequireChangesRemarks = (TextBox)GridView1.Rows[i].FindControl("txtRequireChangesRemarks");
                        TextBox txtParameter = (TextBox)GridView1.Rows[i].FindControl("txtParameter");
                        Label ddlUnit = (Label)GridView1.Rows[i].FindControl("ddlUnit");
                        TextBox txtIn100Days = (TextBox)GridView1.Rows[i].FindControl("txtIn100Days");
                        TextBox txt15August = (TextBox)GridView1.Rows[i].FindControl("txt15August");
                        TextBox txt1year = (TextBox)GridView1.Rows[i].FindControl("txt1year");
                        TextBox txt2Year = (TextBox)GridView1.Rows[i].FindControl("txt2Year");
                        TextBox txt3Year = (TextBox)GridView1.Rows[i].FindControl("txt3Year");
                        TextBox txt4Year = (TextBox)GridView1.Rows[i].FindControl("txt4Year");
                        TextBox txt5Year = (TextBox)GridView1.Rows[i].FindControl("txt5Year");
                        TextBox txtParameterRemarks = (TextBox)GridView1.Rows[i].FindControl("txtParameterRemarks");
                        TextBox txtIn100DaysRemarks = (TextBox)GridView1.Rows[i].FindControl("txtIn100DaysRemarks");
                        TextBox txt15AugustRemarks = (TextBox)GridView1.Rows[i].FindControl("txt15AugustRemarks");
                        TextBox txt1yearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt1yearRemarks");
                        TextBox txt2YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt2YearRemarks");
                        TextBox txt3YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt3YearRemarks");
                        TextBox txt4YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt4YearRemarks");
                        TextBox txt5YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt5YearRemarks");

                        if (hdnPlannedRecno.Value == ds.Tables[0].Rows[i]["PLANNED_RECNO"].ToString())
                        {
                            ddlRequireChanges.SelectedValue = ds.Tables[0].Rows[i]["REQUIRE_CHANGES"].ToString();
                            if (ddlRequireChanges.SelectedValue == "0")
                            { txtRequireChangesRemarks.Visible = true; txtRequireChangesRemarks.Text = ds.Tables[0].Rows[i]["REQUIRE_CHANGES_REMARKS"].ToString(); }
                            txtParameter.Text = ds.Tables[0].Rows[i]["PARAMETER"].ToString();
                            txtIn100Days.Text = ds.Tables[0].Rows[i]["100_days"].ToString();
                            txt15August.Text = ds.Tables[0].Rows[i]["15_august"].ToString();
                            txt1year.Text = ds.Tables[0].Rows[i]["1_Year"].ToString();
                            txt2Year.Text = ds.Tables[0].Rows[i]["2_Year"].ToString();
                            txt3Year.Text = ds.Tables[0].Rows[i]["3_Year"].ToString();
                            txt4Year.Text = ds.Tables[0].Rows[i]["4_Year"].ToString();
                            txt5Year.Text = ds.Tables[0].Rows[i]["5_Year"].ToString();
                            txtParameterRemarks.Text = ds.Tables[0].Rows[i]["PARAMETER_REMARKS"].ToString();
                            txtIn100DaysRemarks.Text = ds.Tables[0].Rows[i]["100DAYS_REMARKS"].ToString();
                            txt15AugustRemarks.Text = ds.Tables[0].Rows[i]["15AUGUST_REMARKS"].ToString();
                            txt1yearRemarks.Text = ds.Tables[0].Rows[i]["1YEAR_REMARKS"].ToString();
                            txt2YearRemarks.Text = ds.Tables[0].Rows[i]["2YEAR_REMARKS"].ToString();
                            txt3YearRemarks.Text = ds.Tables[0].Rows[i]["3YEAR_REMARKS"].ToString();
                            txt4YearRemarks.Text = ds.Tables[0].Rows[i]["4YEAR_REMARKS"].ToString();
                            txt5YearRemarks.Text = ds.Tables[0].Rows[i]["5YEAR_REMARKS"].ToString();
                        }
                    }

                }

                divPlannedGrid.Visible = true;
                divSubmition.Visible = true;
                //  BindUnit();


            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "BindGrid";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void PageLoadBindGrid()
        {
            try
            {
                int ID = 0;
                DataSet ds = obll.GetBindGridData(ID);

                grdvUser.DataSource = ds;
                grdvUser.DataBind(); 
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "PageLoadBindGrid";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
         

        }

        protected void ddlOfficeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "ddlOfficeStatus_SelectedIndexChanged";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
           
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
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
                        BindRegion();
                        BindRegion();
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
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "lnkbtnEdit_Click";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
            divGirdShow.Visible = false;
            divEnterDetails.Visible = true;
            divPlannedGrid.Visible = false;
            divSubmition.Visible = false;
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindGrid();
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string createdBy = "admin";
                foreach (GridViewRow item in GridView1.Rows)
                {
                    int officetype = Convert.ToInt32(ddlOfficeStatus.SelectedValue);
                    int divisionRegionRecno;
                    string divisionRegionName ;
                    int masterid = 0;

                    HiddenField hdnInitiativeRecNo = (HiddenField)item.FindControl("hdnInitiativeRecNo");
                    HiddenField hdnPlannedRecno = (HiddenField)item.FindControl("hdnPlannedRecno");
                    Label lblInitiative = (Label)item.FindControl("lblInitiative");
                    Label lblScheme = (Label)item.FindControl("lblScheme");
                    DropDownList ddlRequireChanges = (DropDownList)item.FindControl("ddlRequireChanges");
                    TextBox txtRequireChangesRemarks = (TextBox)item.FindControl("txtRequireChangesRemarks");
                    TextBox txtParameter = (TextBox)item.FindControl("txtParameter");
                    Label ddlUnit = (Label)item.FindControl("ddlUnit");
                    TextBox txtIn100Days = (TextBox)item.FindControl("txtIn100Days");
                    TextBox txt15August = (TextBox)item.FindControl("txt15August");
                    TextBox txt1year = (TextBox)item.FindControl("txt1year");
                    TextBox txt2Year = (TextBox)item.FindControl("txt2Year");
                    TextBox txt3Year = (TextBox)item.FindControl("txt3Year");
                    TextBox txt4Year = (TextBox)item.FindControl("txt4Year");
                    TextBox txt5Year = (TextBox)item.FindControl("txt5Year");
                    TextBox txtParameterRemarks = (TextBox)item.FindControl("txtParameterRemarks");
                    TextBox txtIn100DaysRemarks = (TextBox)item.FindControl("txtIn100DaysRemarks");
                    TextBox txt15AugustRemarks = (TextBox)item.FindControl("txt15AugustRemarks");
                    TextBox txt1yearRemarks = (TextBox)item.FindControl("txt1yearRemarks");
                    TextBox txt2YearRemarks = (TextBox)item.FindControl("txt2YearRemarks");
                    TextBox txt3YearRemarks = (TextBox)item.FindControl("txt3YearRemarks");
                    TextBox txt4YearRemarks = (TextBox)item.FindControl("txt4YearRemarks");
                    TextBox txt5YearRemarks = (TextBox)item.FindControl("txt5YearRemarks");


                    masterid = Convert.ToInt32(hdnPlannedRecno.Value);
                    if (officetype == 0)
                    { divisionRegionRecno = Convert.ToInt32(ddlDivision.SelectedValue); divisionRegionName = ddlDivision.SelectedItem.Text; }
                    else
                    { divisionRegionRecno = Convert.ToInt32(ddlRegion.SelectedValue); divisionRegionName = ddlRegion.SelectedItem.Text; }
                    int initiativerecno = Convert.ToInt32(hdnInitiativeRecNo.Value);
                    string initiativeName = lblInitiative.Text;
                    string scheme = lblScheme.Text;
                    int requireChnages = Convert.ToInt32(ddlRequireChanges.SelectedValue);
                    string requirechangesRemarks = txtRequireChangesRemarks.Text;
                    string parameter = txtParameter.Text;
                    string unitname = ddlUnit.Text;
                    string hundredDyas = txtIn100Days.Text;
                    string august = txt15August.Text;
                    string firstYear = txt1year.Text;
                    string secondYear = txt2Year.Text;
                    string thirdYear = txt3Year.Text;
                    string fourthYear = txt4Year.Text;
                    string fifthYear = txt5Year.Text;
                    string parameterRemarks = txtParameterRemarks.Text ;
                    string hundredDyasRemarks = txtIn100DaysRemarks.Text;
                    string augustRemarks = txt15AugustRemarks.Text;
                    string firstYearRemarks = txt1yearRemarks.Text;
                    string secondYearRemarks = txt2YearRemarks.Text;
                    string thirdYearRemarks = txt3YearRemarks.Text;
                    string fourthYearRemarks = txt4YearRemarks.Text;
                    string fifthYearRemarks = txt5YearRemarks.Text;


                    if (masterid == 0)
                    {
                        int result = obll.SaveUpdateDetails(masterid, officetype, divisionRegionRecno, divisionRegionName, initiativerecno, initiativeName,
                        scheme, requireChnages, requirechangesRemarks, parameter, unitname, hundredDyas, august, firstYear, secondYear, thirdYear, fourthYear, fifthYear,
                        parameterRemarks, hundredDyasRemarks,augustRemarks, firstYearRemarks,secondYearRemarks, thirdYearRemarks, fourthYearRemarks,
                        fifthYearRemarks, createdBy);
                        if (result == -2)
                        {
                            CommonDAL.DisplayPopUpMessage(this, "Duplicate value of Action Planned Record", "");
                            return;
                        }
                        else if (result > 0)
                        {
                            CommonDAL.DisplayPopUpMessage(this, "Action Planned Record Saved", "ActionPlannedEntry.aspx");
                        }
                    }
                    else
                    {
                        int result = obll.SaveUpdateDetails(masterid, officetype, divisionRegionRecno, divisionRegionName, initiativerecno, initiativeName,
                        scheme, requireChnages, requirechangesRemarks, parameter, unitname, hundredDyas, august, firstYear, secondYear, thirdYear, fourthYear, fifthYear,
                        parameterRemarks, hundredDyasRemarks, augustRemarks, firstYearRemarks, secondYearRemarks, thirdYearRemarks, fourthYearRemarks,
                        fifthYearRemarks, createdBy);
                        if (result == -2)
                        {
                            CommonDAL.DisplayPopUpMessage(this, "Duplicate value of Action Planned Record", "");
                            return;
                        }
                        else if (result > 0)
                        {
                            CommonDAL.DisplayPopUpMessage(this, "Action Planned Record Updated", "ActionPlannedEntry.aspx");
                        }
                    }
                    

                   
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSave_Click";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
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
                Response.Redirect("~/Process/ActionPlannedEntry.aspx");
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnBack_Click";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
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
                HiddenField hdnDivisionRecno = (HiddenField)row.FindControl("hdnDivisionRecno");
                int divisionrecno = Convert.ToInt32(hdnDivisionRecno.Value);

                DataSet ds = obll.GetBindGridData(divisionrecno);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    divSubmition.Visible = true;
                    divPlannedGrid.Visible = true;
                    divEnterDetails.Visible = true;
                    divGirdShow.Visible = false;
                    btnSave.Text = "Update";

                    ddlDivision.SelectedValue = divisionrecno.ToString();
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    //foreach (GridViewRow item in GridView1.Rows)
                    //{
                    //    int officetype = Convert.ToInt32(ddlOfficeStatus.SelectedValue);
                    //    int divisionRegionRecno;
                    //    string divisionRegionName;
                    //    int masterid = 0;

                    //    HiddenField hdnInitiativeRecNo = (HiddenField)item.FindControl("hdnInitiativeRecNo");
                    //    HiddenField hdnPlannedRecno = (HiddenField)item.FindControl("hdnPlannedRecno");
                    //    Label lblInitiative = (Label)item.FindControl("lblInitiative");
                    //    Label lblScheme = (Label)item.FindControl("lblScheme");
                    //    DropDownList ddlRequireChanges = (DropDownList)item.FindControl("ddlRequireChanges");
                    //    TextBox txtRequireChangesRemarks = (TextBox)item.FindControl("txtRequireChangesRemarks");
                    //    TextBox txtParameter = (TextBox)item.FindControl("txtParameter");
                    //    Label ddlUnit = (Label)item.FindControl("ddlUnit");
                    //    TextBox txtIn100Days = (TextBox)item.FindControl("txtIn100Days");
                    //    TextBox txt15August = (TextBox)item.FindControl("txt15August");
                    //    TextBox txt1year = (TextBox)item.FindControl("txt1year");
                    //    TextBox txt2Year = (TextBox)item.FindControl("txt2Year");
                    //    TextBox txt3Year = (TextBox)item.FindControl("txt3Year");
                    //    TextBox txt4Year = (TextBox)item.FindControl("txt4Year");
                    //    TextBox txt5Year = (TextBox)item.FindControl("txt5Year");
                    //    TextBox txtParameterRemarks = (TextBox)item.FindControl("txtParameterRemarks");
                    //    TextBox txtIn100DaysRemarks = (TextBox)item.FindControl("txtIn100DaysRemarks");
                    //    TextBox txt15AugustRemarks = (TextBox)item.FindControl("txt15AugustRemarks");
                    //    TextBox txt1yearRemarks = (TextBox)item.FindControl("txt1yearRemarks");
                    //    TextBox txt2YearRemarks = (TextBox)item.FindControl("txt2YearRemarks");
                    //    TextBox txt3YearRemarks = (TextBox)item.FindControl("txt3YearRemarks");
                    //    TextBox txt4YearRemarks = (TextBox)item.FindControl("txt4YearRemarks");
                    //    TextBox txt5YearRemarks = (TextBox)item.FindControl("txt5YearRemarks");
                    //}

                    if (ds.Tables[0].Rows[0]["PLANNED_RECNO"].ToString() != "0")
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            HiddenField hdnInitiativeRecNo = (HiddenField)GridView1.Rows[i].FindControl("hdnInitiativeRecNo");
                            HiddenField hdnPlannedRecno = (HiddenField)GridView1.Rows[i].FindControl("hdnPlannedRecno");
                            Label lblInitiative = (Label)GridView1.Rows[i].FindControl("lblInitiative");
                            Label lblScheme = (Label)GridView1.Rows[i].FindControl("lblScheme");
                            DropDownList ddlRequireChanges = (DropDownList)GridView1.Rows[i].FindControl("ddlRequireChanges");
                            TextBox txtRequireChangesRemarks = (TextBox)GridView1.Rows[i].FindControl("txtRequireChangesRemarks");
                            TextBox txtParameter = (TextBox)GridView1.Rows[i].FindControl("txtParameter");
                            Label ddlUnit = (Label)GridView1.Rows[i].FindControl("ddlUnit");
                            TextBox txtIn100Days = (TextBox)GridView1.Rows[i].FindControl("txtIn100Days");
                            TextBox txt15August = (TextBox)GridView1.Rows[i].FindControl("txt15August");
                            TextBox txt1year = (TextBox)GridView1.Rows[i].FindControl("txt1year");
                            TextBox txt2Year = (TextBox)GridView1.Rows[i].FindControl("txt2Year");
                            TextBox txt3Year = (TextBox)GridView1.Rows[i].FindControl("txt3Year");
                            TextBox txt4Year = (TextBox)GridView1.Rows[i].FindControl("txt4Year");
                            TextBox txt5Year = (TextBox)GridView1.Rows[i].FindControl("txt5Year");
                            TextBox txtParameterRemarks = (TextBox)GridView1.Rows[i].FindControl("txtParameterRemarks");
                            TextBox txtIn100DaysRemarks = (TextBox)GridView1.Rows[i].FindControl("txtIn100DaysRemarks");
                            TextBox txt15AugustRemarks = (TextBox)GridView1.Rows[i].FindControl("txt15AugustRemarks");
                            TextBox txt1yearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt1yearRemarks");
                            TextBox txt2YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt2YearRemarks");
                            TextBox txt3YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt3YearRemarks");
                            TextBox txt4YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt4YearRemarks");
                            TextBox txt5YearRemarks = (TextBox)GridView1.Rows[i].FindControl("txt5YearRemarks");

                            if (hdnPlannedRecno.Value == ds.Tables[0].Rows[i]["PLANNED_RECNO"].ToString())
                            {
                                ddlRequireChanges.SelectedValue = ds.Tables[0].Rows[i]["REQUIRE_CHANGES"].ToString();
                                if (ddlRequireChanges.SelectedValue == "0")
                                { txtRequireChangesRemarks.Visible = true; txtRequireChangesRemarks.Text = ds.Tables[0].Rows[i]["REQUIRE_CHANGES_REMARKS"].ToString(); }
                                txtParameter.Text = ds.Tables[0].Rows[i]["PARAMETER"].ToString();
                                txtIn100Days.Text = ds.Tables[0].Rows[i]["100_days"].ToString();
                                txt15August.Text = ds.Tables[0].Rows[i]["15_august"].ToString();
                                txt1year.Text = ds.Tables[0].Rows[i]["1_Year"].ToString();
                                txt2Year.Text = ds.Tables[0].Rows[i]["2_Year"].ToString();
                                txt3Year.Text = ds.Tables[0].Rows[i]["3_Year"].ToString();
                                txt4Year.Text = ds.Tables[0].Rows[i]["4_Year"].ToString();
                                txt5Year.Text = ds.Tables[0].Rows[i]["5_Year"].ToString();
                                txtParameterRemarks.Text = ds.Tables[0].Rows[i]["PARAMETER_REMARKS"].ToString();
                                txtIn100DaysRemarks.Text = ds.Tables[0].Rows[i]["100DAYS_REMARKS"].ToString();
                                txt15AugustRemarks.Text = ds.Tables[0].Rows[i]["15AUGUST_REMARKS"].ToString();
                                txt1yearRemarks.Text = ds.Tables[0].Rows[i]["1YEAR_REMARKS"].ToString();
                                txt2YearRemarks.Text = ds.Tables[0].Rows[i]["2YEAR_REMARKS"].ToString();
                                txt3YearRemarks.Text = ds.Tables[0].Rows[i]["3YEAR_REMARKS"].ToString();
                                txt4YearRemarks.Text = ds.Tables[0].Rows[i]["4YEAR_REMARKS"].ToString();
                                txt5YearRemarks.Text = ds.Tables[0].Rows[i]["5YEAR_REMARKS"].ToString();
                            }
                        }

                    }

                    divPlannedGrid.Visible = true;
                    divSubmition.Visible = true;
                    //  BindUnit();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "lnkbtnEdit_Click";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
           
        }

        protected void ddlRequireChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = GridView1.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);
                GridViewRow row = GridView1.Rows[rowindex];
                DropDownList ddlRequireChanges = (DropDownList)row.FindControl("ddlRequireChanges");
                TextBox txtRequireChangesRemarks = (TextBox)row.FindControl("txtRequireChangesRemarks");

                if (ddlRequireChanges.SelectedValue == "0")
                {
                    txtRequireChangesRemarks.Visible = true;
                }
                else
                {
                    txtRequireChangesRemarks.Visible = false;
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "ddlRequireChanges_SelectedIndexChanged";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
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
                String MODULE_NAME = "ActionPlannedEntry.aspx";
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
                    e.Row.Cells[0].Visible = false; // Invisibiling Period Header Cell
                    e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
                    e.Row.Cells[2].Visible = false; // Invisibiling  Header Cell
                    e.Row.Cells[3].Visible = false; // Invisibiling  Header Cell
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "GridView1_RowDataBound";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView ProductGrid = (GridView)sender;
                    GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    //Adding sl Column
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = "Sl.No.";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.RowSpan = 3;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderCell.Font.Bold = true;

                    HeaderRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Initiative";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.RowSpan = 3;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderRow.Cells.Add(HeaderCell);
                    HeaderCell.Font.Bold = true;

                    //Adding scheme Column
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Scheme/ program, if any";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.RowSpan = 3;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderCell.Width = 7;
                    HeaderRow.Cells.Add(HeaderCell);
                    HeaderCell.Font.Bold = true;

                    //Adding changes  Column
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Requires changes in law (Yes/No)";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.RowSpan = 3;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderCell.Width = 10;
                    HeaderRow.Cells.Add(HeaderCell);
                    HeaderCell.Font.Bold = true;

                    //Adding kpi Column
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Key Performance Indicator (KPIs)";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.ColumnSpan = 9;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderRow.Cells.Add(HeaderCell);
                    HeaderCell.Font.Bold = true;


                    ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);

                    HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    //Adding quantitative Debit Column
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Quantitative Target";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.ColumnSpan = 9;
                    HeaderCell.CssClass = "HeaderStyle";
                    HeaderRow.Cells.Add(HeaderCell);
                    HeaderCell.Font.Bold = true;


                    ProductGrid.Controls[0].Controls.AddAt(1, HeaderRow);
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "GridView1_RowCreated";
                String MODULE_NAME = "ActionPlannedEntry.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
           
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            //try
            //{
            //    int j = 0;

            //    j = GridView1.Rows.Count;
            //    if (j > 0)
            //    {
            //        GridView1.UseAccessibleHeader = false;
            //        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //        GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            //        int CellCount = GridView1.FooterRow.Cells.Count;
            //        GridView1.FooterRow.Cells.Clear();
            //        GridView1.FooterRow.Cells.Add(new TableCell());
            //        GridView1.FooterRow.Cells[0].ColumnSpan = CellCount - 1;
            //        GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            //        GridView1.FooterRow.Cells.Add(new TableCell());

            //        TableFooterRow tfr = new TableFooterRow();
            //        for (int i = 0; i < CellCount; i++)
            //        {
            //            tfr.Cells.Add(new TableCell());

            //            GridView1.FooterRow.Controls[1].Controls.Add(tfr);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    AppConstants OAp = new AppConstants();
            //    String FUNCTION_NAME = "grdvUser_PreRender";
            //    String MODULE_NAME = "ActionPlannedEntry.aspx";
            //    String ERROR_TYPE = "Application";
            //    String ERROR_DESC = ex.Message;
            //    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            //    string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            //}
        }
    }
}