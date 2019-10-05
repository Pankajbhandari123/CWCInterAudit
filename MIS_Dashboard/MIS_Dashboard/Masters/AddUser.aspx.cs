using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace MIS_Dashboard.Masters
{
    public partial class AddUser : System.Web.UI.Page
    {   
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
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
        public int vsIntUserRecNo
        {
            get
            {
                if (ViewState["vsIntUserRecNo"] == null)
                    return 0;
                else
                    return (int)ViewState["vsIntUserRecNo"];
            }
            set { ViewState["vsIntUserRecNo"] = value; }
        }
        public string vsStrPswd
        {
            get
            {
                if (ViewState["vsStrPswd"] == null)
                    return string.Empty;
                else
                    return (string)ViewState["vsStrPswd"];
            }
            set { ViewState["vsStrPswd"] = value; }
        }
        #region Permission Control added by RENU 10/06/2019
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoginName"] = "ADMINISTRATOR";
            bool boolDecodeError = false;
            try
            {
                if (Session["LoginName"] == null || Session["LoginName"].ToString() == string.Empty)
                {
                    Session["SessionExpire"] = true;
                    //Response.Redirect("~/Mainpage.aspx", false);
                    //return;
                }

                if (!Page.IsPostBack)
                {

                    string strRecentPage = (lblHead.Text.Trim() + "-" + DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt")).ToString();
                    oUserBLL.InsertUserActivityDetails(strRecentPage, Session["LoginName"].ToString());

                    #region Permission Control added by Renu 11/06/2019
                    int pageID = 16;
                    int rights = oCommonDAL.GetPermissions(pageID, Convert.ToInt32(Session["UserRecNo"]));
                    if (rights >= 0)
                    {
                        vsIntRights = rights;
                        if (vsIntRights == 0)
                        {

                            btnSave.Visible = false;
                            btnUpdate.Visible = false;
                        }
                        else
                        {
                            btnSave.Visible = true;
                            btnUpdate.Visible = false;
                        }
                    }
                    else
                    {
                        //Access denied
                        Response.Redirect("~/AccessDenied.aspx", false);
                    }
                    #endregion
                    //oUserBLL.GetSIDCODistrict(ddlDistrict);

                    oUserBLL.BindRole(ddlRole);
                    oUserBLL.BindDivision(ddlDivision);
                    if (Request.QueryString["md"] != null && Request.QueryString["md"].ToString() != string.Empty)
                    {
                        string mode = oCommonDAL.DecodeString(Request.QueryString["md"].ToString());
                        boolDecodeError = false;

                        if (mode == "VIEW")
                        {
                            boolDecodeError = true;
                            vsIntUserRecNo = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["rn"].ToString()));
                            boolDecodeError = false;

                            DisplayUserInfo(vsIntUserRecNo);

                            btnCancel.Text = "Close";
                            lblHead.Text = "View User";
                            btnSave.Visible = false;
                            btnClear.Visible = false;
                            btnUpdate.Visible = false;
                            DisableControls();
                        }
                        else if (mode == "ADD")
                        {
                            btnSave.Visible = true;
                            btnUpdate.Visible = false;
                            lblHead.Text = "Add User";
                        }
                        else if (mode == "EDIT")
                        {
                            boolDecodeError = true;
                            vsIntUserRecNo = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["rn"].ToString()));
                            boolDecodeError = false;

                            btnSave.Visible = false;
                            btnUpdate.Visible = true;
                            DisplayUserInfo(vsIntUserRecNo);
                            lblHead.Text = "Edit User";
                            btnClear.Visible = false;
                        }

                    }
                    else
                    {
                        // Response.Redirect("~/SessionOut.aspx", false);

                    }
                }

            }
            catch (Exception ex)
            {

                if (boolDecodeError == true)
                {

                    string title = "Message from System";
                    string msg = "Something Wrong Happened.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "AddUsers";
                    String ERROR_TYPE = "Application";
                    String ERROR_DESC = ex.Message;
                    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                }
                else
                {

                    string title = "Message from System";
                    string msg = "Something Wrong Happened.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                    String FUNCTION_NAME = "Page_Load";
                    String MODULE_NAME = "AddUsers";
                    String ERROR_TYPE = "Application";
                    String ERROR_DESC = ex.Message;
                    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

                }
            }

        }

        protected void chkbxPswd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Attributes.Add("Value", "");
                txtConfirmPassword.Attributes.Add("Value", "");
                if (chkbxPswd.Checked)
                {
                    //modified code -tanshi
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtConfirmPassword.Enabled = false;
                    txtPassword.Enabled = false;
                    chkChangePassword.Checked = true;
                    chkChangePassword.Enabled = false;

                    //modified code -tanshi
                }
                else
                {
                    //modified code -tanshi
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtConfirmPassword.Enabled = true;
                    txtPassword.Enabled = true;
                    chkChangePassword.Checked = false;
                    chkChangePassword.Enabled = true;
                    txtPassword.Attributes.Add("Value", vsStrPswd);
                    txtConfirmPassword.Attributes.Add("Value", vsStrPswd);
                    //modified code -tanshi
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtPassword.Text.Trim(), txtConfirmPassword.Text.Trim()) == 0)
                {
                    DateTime expiryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    //int District_recno = Convert.ToInt32(ddlDistrict.SelectedValue);
                    //int Ind_recno = Convert.ToInt32(ddlIIE.SelectedValue);

                    string LOGIN_NAME = txtLoginName.Text.Trim();
                    string DISPLAY_NAME = txtDisplayName.Text.Trim().ToUpper();
                    string CONTACT_NO = txtContactNo.Text.Trim();
                    string EMAILID = txtEmailID.Text.Trim();
                    DateTime PASSWORD_EXPIRYDATE = expiryDate.AddDays(90);// 3 months
                    decimal ROLE_RECNO = Convert.ToDecimal(ddlRole.SelectedValue);
                    int divisionrecno = Convert.ToInt32(ddlDivision.SelectedValue);
                    int ACTIVE_STATUS = 0;
                    if (chkbxInactive.Checked)
                    {
                        ACTIVE_STATUS = 1;
                    }
                    else
                    {
                        ACTIVE_STATUS = 0;
                    }
                    string PASSWORD = "";
                    string CHANGE_PASSWORD = "";
                    if (chkbxPswd.Checked == false)
                    {

                        PASSWORD = oCommonDAL.EncodeString(txtPassword.Text.Trim());

                        if (chkChangePassword.Checked == true)
                        {
                            CHANGE_PASSWORD = "T";
                        }
                        else
                        {
                            CHANGE_PASSWORD = "F";
                        }
                    }
                    else
                    {
                        PASSWORD = oCommonDAL.EncodeString(AppConstants.defaultPswd);
                        CHANGE_PASSWORD = "T";
                    }
                    string LOCKED = "";
                    if (chkbxLock.Checked)
                    {
                        LOCKED = "T";
                    }
                    else
                    {
                        LOCKED = "F";
                    }

                    string CREATED_BY = HttpContext.Current.Session["LoginName"].ToString();
                    int result = oUserBLL.InsertUserdetails(LOGIN_NAME, DISPLAY_NAME, CONTACT_NO, EMAILID, PASSWORD_EXPIRYDATE, ROLE_RECNO, ACTIVE_STATUS, PASSWORD, CHANGE_PASSWORD, LOCKED, CREATED_BY, divisionrecno);
                    string title = "";
                    string msg = "";
                    switch (result)
                    {
                        case 1:
                            title = "Message from System";
                            msg = "User details Inserted sucessfully:" + LOGIN_NAME + " and an email has been sent to the user with all Important details.";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                            String Action_Type = "insert";
                            GenerateMailFormat(txtDisplayName.Text, txtEmailID.Text, txtLoginName.Text, oCommonDAL.DecodeString(PASSWORD), result, Action_Type);
                            DisplayPopUpMessage(this, "User details inserted sucessfully: and an email has been sent to the user with all Important details.", "UserMaster.aspx");
                            clear();
                            break;
                        case -1:
                            title = "Message from System";
                            msg = "Total No of User Licenses provided by Vendor already utilised.Please contact to the system Administrator";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important details.", "UserMaster.aspx");
                            break;
                        case 0:
                            title = "Message from System";
                            msg = "This User Name (<b>" + LOGIN_NAME + "</b>) is already exists.Please check user information and then try again.";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important details.", "UserMaster.aspx");
                            break;
                        default:
                            title = "Message from System";
                            msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important details.", "UserMaster.aspx");
                            break;
                    }


                }
                else
                {
                    string title = "Message from System";
                    string msg = "Password and Confirm Password does not match.please check!!!";
                    ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                }


            }

            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "InsertUserdetails";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        #region For Mail
        private void GenerateMailFormat(string DisplayName, String EmailID, String LoginName, string Password, int result, String Action_type)
        {
            if (Action_type == "insert")
            {
                string link = "Now you can login in Prabha Energy Portal";
                string body = this.PopulateBody(DisplayName, EmailID, LoginName, Password, link);
                string Sub = "User login Details ";

                this.sendMail(EmailID, Sub, body, link);
            }
            else
            {
                string link = "Now you can login in Prabha Energy Portal";
                string body = this.PopulateBody(DisplayName, EmailID, LoginName, Password, link);
                string Sub = "Updated User login Details";

                this.sendMail(EmailID, Sub, body, link);
            }
        }


        private string PopulateBody(string DisplayName, String EmailID, String LoginName, string Password, string Link)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("AddUsers.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{DisplayName}", DisplayName);
            body = body.Replace("{LoginName}", LoginName);
            body = body.Replace("{Password}", Password);
            body = body.Replace("{Link}", Link);


            return body;
        }

        private void sendMail(string EmailID, string Subject, string Body, string link)
        {
            MailMessage msg = new MailMessage();
            try
            {
                msg.From = new MailAddress(AppConstants.fromMail);
                if (EmailID != "" || EmailID != string.Empty)
                {
                    msg.To.Add(EmailID);
                    msg.Body = Body;
                    msg.IsBodyHtml = true;
                    msg.Subject = Subject;
                    SmtpClient smt = new SmtpClient(AppConstants.mailHost);
                    smt.Port = AppConstants.mailPort;
                    smt.Credentials = new NetworkCredential(AppConstants.fromMail, AppConstants.fromMailPwd);
                    smt.EnableSsl = true;
                    smt.Send(msg);
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {

                msg.Dispose();
            }
        }
        #endregion


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(txtPassword.Text.Trim(), txtConfirmPassword.Text.Trim()) == 0)
                {
                    DateTime expiryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    string LOGIN_NAME = txtLoginName.Text.Trim();
                    string DISPLAY_NAME = txtDisplayName.Text.Trim().ToUpper();
                    string CONTACT_NO = txtContactNo.Text.Trim();
                    string EMAILID = txtEmailID.Text.Trim();
                    DateTime PASSWORD_EXPIRYDATE = expiryDate.AddDays(90);// 3 months
                    decimal ROLE_RECNO = Convert.ToDecimal(ddlRole.SelectedValue);
                    int divisionrecno = Convert.ToInt32(ddlDivision.SelectedValue);
                    int ACTIVE_STATUS = 0;
                    if (chkbxInactive.Checked)
                    {
                        ACTIVE_STATUS = 1;
                    }
                    else
                    {
                        ACTIVE_STATUS = 0;
                    }
                    string PASSWORD = "";

                    char CHANGE_PASSWORD;
                    if (chkbxPswd.Checked == false)
                    {
                        PASSWORD = oCommonDAL.EncodeString(txtPassword.Text.Trim());

                        if (chkChangePassword.Checked == true)
                        {
                            CHANGE_PASSWORD = 'T';
                        }
                        else
                        {
                            CHANGE_PASSWORD = 'F';
                        }
                    }
                    else
                    {
                        PASSWORD = oCommonDAL.EncodeString(AppConstants.defaultPswd);
                        CHANGE_PASSWORD = 'T';
                    }
                    char LOCKED;
                    if (chkbxLock.Checked)
                    {
                        LOCKED = 'T';
                    }
                    else
                    {
                        LOCKED = 'F';
                    }

                    string CREATED_BY = HttpContext.Current.Session["LoginName"].ToString();
                    int result = oUserBLL.UpdateUserdetails(vsIntUserRecNo, LOGIN_NAME, DISPLAY_NAME, CONTACT_NO, EMAILID, PASSWORD_EXPIRYDATE, ROLE_RECNO, ACTIVE_STATUS, PASSWORD, CHANGE_PASSWORD, LOCKED, CREATED_BY, divisionrecno);
                    string title = "";
                    string msg = "";
                    switch (result)
                    {
                        case 1:
                            title = "Message from System";
                            msg = "User details updated sucessfully:" + LOGIN_NAME + " and an email has been sent to the user with all Important detailes.";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                            String Action_Type = "Update";
                            GenerateMailFormat(txtDisplayName.Text, txtEmailID.Text, txtLoginName.Text, oCommonDAL.DecodeString(PASSWORD), result, Action_Type);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important detailes.", "UserMaster.aspx");
                            break;
                        case -1:
                            title = "Message from System";
                            msg = "Total No of User Licenses provided by Vendor already utilised.Please contact to the system Administrator";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important detailes.", "UserMaster.aspx");
                            break;
                        case 0:
                            title = "Message from System";
                            msg = "This User Name (<b>" + LOGIN_NAME + "</b>) is already exists.Please check user information and then try again.";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important detailes.", "UserMaster.aspx");
                            break;
                        default:
                            title = "Message from System";
                            msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                            ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                            DisplayPopUpMessage(this, "User details updated sucessfully: and an email has been sent to the user with all Important detailes.", "UserMaster.aspx");
                            break;
                    }
                }
                else
                {
                    string title = "Message from System";
                    string msg = "Password and Confirm Password does not match.please check!!!";
                    ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-warning','" + msg + "');", true);
                }


            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "InsertUserdetails";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void DisplayPopUpMessage(Control control, string message, string url)
        {
            string msg = "";
            msg += "alert('" + message + "');";
            if (url != string.Empty)
            {
                msg += "window.location.href = '" + url + "';";
            }
            ScriptManager.RegisterStartupScript(control, control.GetType(), "Popup", msg, true);

        }
        protected void clear()
        {
            try
            {
                //ddlDistrict.SelectedIndex = 0;
                //ddlIIE.SelectedIndex = 0;
                txtLoginName.Text = "";
                txtDisplayName.Text = "";
                txtContactNo.Text = "";
                txtEmailID.Text = "";
                ddlRole.SelectedIndex = 0;
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                chkbxInactive.Checked = false;
                chkbxPswd.Checked = false;
                chkChangePassword.Checked = false;
                chkbxLock.Checked = false;
            }
            catch (Exception ex)
            {

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnClear_Click";
                String MODULE_NAME = "Masters_frm_AddUsers";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                FUNCTION_NAME = "";
                MODULE_NAME = "";
                ERROR_TYPE = "";
                ERROR_DESC = "";

                Response.Redirect("~/Invalid.aspx", false);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        //added code - tanshi
        public static bool IsValidEmailId(string InputEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
        //added code - tanshi
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Masters/UserMaster.aspx", false);
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnCancel_Click";
                String MODULE_NAME = "Masters_frm_UserMaster";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                FUNCTION_NAME = "";
                MODULE_NAME = "";
                ERROR_TYPE = "";
                ERROR_DESC = "";



                Response.Redirect("~/Invalid.aspx", false);
            }
        }

        //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlDistrict.SelectedIndex > 0)
        //    {
        //        oUserBLL.GetSIDCOIIE(Convert.ToInt32(ddlDistrict.SelectedValue), ddlIIE);
        //    }
        //    else
        //    {
        //        if (ddlIIE.Items.Count > 0)
        //            ddlIIE.Items.Clear();
        //    }
        //}

        private void DisplayUserInfo(int userRecNo)
        {
            try
            {
                ds = null;
                ds = oUserBLL.DisplayUserDetails(userRecNo);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["District_Recno"].ToString();
                        //oUserBLL.GetSIDCOIIE(Convert.ToInt32(ddlDistrict.SelectedValue), ddlIIE);
                        //ddlIIE.SelectedValue = ds.Tables[0].Rows[0]["Ind_area_recno"].ToString();
                        txtLoginName.Text = ds.Tables[0].Rows[0]["LOGIN_NAME"].ToString();
                        txtDisplayName.Text = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
                        txtEmailID.Text = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                        txtContactNo.Text = ds.Tables[0].Rows[0]["CONTACT_NO"].ToString();
                        ddlRole.SelectedValue = ds.Tables[0].Rows[0]["ROLE_RECNO"].ToString();

                        if (ds.Tables[0].Rows[0]["CHANGE_PASSWORD"].ToString() == "T")
                            chkbxPswd.Checked = true;
                        else
                            chkbxPswd.Checked = false;

                        if (ds.Tables[0].Rows[0]["LOCKED"].ToString() == "T")
                            chkbxLock.Checked = true;
                        else
                            chkbxLock.Checked = false;

                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["ACTIVE_STATUS"]) == 1)
                            chkbxInactive.Checked = true;
                        else
                            chkbxInactive.Checked = false;

                        ddlDivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DIVISION_RECNO"]);



                        vsStrPswd = ds.Tables[0].Rows[0]["PASSWORD"].ToString();

                        if (ds.Tables[0].Rows[0]["CHANGE_PASSWORD"].ToString() == "T")
                        {
                            txtConfirmPassword.Enabled = false;
                            txtPassword.Enabled = false;
                            chkChangePassword.Checked = true;
                            chkChangePassword.Enabled = false;
                            txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
                            txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");

                        }
                        else
                        {
                            txtConfirmPassword.Enabled = true;
                            txtPassword.Enabled = true;
                            chkChangePassword.Checked = false;
                            chkChangePassword.Enabled = true;
                            txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                            txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                            txtPassword.Attributes.Add("Value", oCommonDAL.DecodeString(ds.Tables[0].Rows[0]["PASSWORD"].ToString()));
                            txtConfirmPassword.Attributes.Add("Value", oCommonDAL.DecodeString(ds.Tables[0].Rows[0]["PASSWORD"].ToString()));
                            vsStrPswd = oCommonDAL.DecodeString(ds.Tables[0].Rows[0]["PASSWORD"].ToString());

                        }
                    }
                    else
                    {
                        string title = "Message from System";
                        string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                        ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);


                    }
                }
                else
                {
                    string title = "Message from System";
                    string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                    ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);


                }
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(txtLoginName, txtLoginName.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "DisplayUserdetails";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

            }
        }

        private void DisableControls()
        {
            try
            {
                //ddlDistrict.Enabled = false;
                //ddlIIE.Enabled = false;
                txtLoginName.Enabled = false;
                txtDisplayName.Enabled = false;
                txtContactNo.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                txtEmailID.Enabled = false;
                txtConfirmPassword.Enabled = false;
                txtPassword.Enabled = false;
                ddlRole.Enabled = false;
                chkbxLock.Enabled = false;
                chkbxPswd.Enabled = false;
                chkChangePassword.Enabled = false;
                chkbxInactive.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtEmailID_TextChanged(object sender, EventArgs e)
        {
            String UserEmail = txtEmailID.Text;
            if (IsValidEmailId(UserEmail))
            {
                return;
            }
            else
            {
                string msg = "<script>alert('Please enter valid email id')</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                txtEmailID.Text = "";
            }
        }




    }
}