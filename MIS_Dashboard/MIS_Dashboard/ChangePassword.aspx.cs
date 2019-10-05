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
using System.Text;

namespace MIS_Dashboard
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();
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
                if (Session["UserRecNo"].ToString() != null || Session["UserRecNo"].ToString() != string.Empty)
                {
                    lblUserId.Text = Session["UserRecNo"].ToString();
                    lblLoginName.Text = Session["LoginName"].ToString();
                }
                FillCapctha();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int userRecno = Convert.ToInt32(lblUserId.Text);
                string createdBy = "";
                string oldpassword = string.Empty;
                string newpassword = string.Empty;
                string confirmpassword = string.Empty;
                string DisplayName;
                string LoginName;
                string EmailID;
                string Password;

                if (Session["captcha"].ToString() != txtCaptcha.Text)
                {
                    lblCaptcha.Text = "Enter Correct Captca Code";
                    lblCaptcha.ForeColor = System.Drawing.Color.Red;
                    Clear();
                    CommonDAL.DisplayPopUpMessage(this, "Please Enter Captca.", "");
                }
                else
                {
                    if (txtOldPassword.Text != "" && txtNewPassword.Text != "" && txtConfirmPassword.Text != "")
                    {
                        if (txtNewPassword.Text == txtConfirmPassword.Text)
                        {
                            oldpassword = oCommonDAL.EncodeString(txtOldPassword.Text.Trim());
                            newpassword = oCommonDAL.EncodeString(txtNewPassword.Text.Trim());
                            confirmpassword = oCommonDAL.EncodeString(txtConfirmPassword.Text.Trim());
                            string changepassword = "F";

                            int result = oUserBLL.UpdatePassword(userRecno, oldpassword, newpassword, changepassword, createdBy);

                            if (result > 0)
                            {

                                DataSet ds = new DataSet();
                                String Action_type = "Passsword Changed";
                                ds = oUserBLL.GetEmailId(Convert.ToInt32(lblUserId.Text));
                                if (ds != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayName = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString().Trim();
                                    LoginName = ds.Tables[0].Rows[0]["LOGIN_NAME"].ToString().Trim();
                                    EmailID = ds.Tables[0].Rows[0]["EMAILID"].ToString().Trim();
                                    Password = ds.Tables[0].Rows[0]["PASSWORD"].ToString().Trim();
                                    GenerateMailFormat(DisplayName, LoginName, EmailID, oCommonDAL.DecodeString(Password), Action_type);

                                    DisplayPopUpMessage(this, "User Password Changed Successfully and an email has been sent to the user with all Important details.", "Default1.aspx");

                                }

                            }
                            else
                            {
                                string msg = "<script>alert('Old Password is Not Correct')</script>";
                                ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                            }
                        }

                        else
                        {
                            string msg = "<script>alert('New Password and Confirm Password Need to be Same')</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                        }

                    }
                    else
                    {
                        string msg = "<script>alert('All Fields Are need to be filled ')</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                    }
                }



            }
            catch (Exception ex)
            {

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

        private void GenerateMailFormat(string DisplayName, string LoginName, string EmailID, string Password, string Action_type)
        {
            if (Action_type == "Passsword Changed")
            {
                string link = "Now you can login in MyDashboard Portal";
                string body = this.PopulateBody(DisplayName, EmailID, LoginName, Password, link);
                string Sub = "Updated User login Details";

                this.sendMail(EmailID, Sub, body, link);
            }
            else
            {

            }
        }

        private void sendMail(string EmailID, string Sub, string body, string link)
        {
            MailMessage msg = new MailMessage();
            try
            {
                msg.From = new MailAddress(AppConstants.fromMail);
                if (EmailID != "" || EmailID != string.Empty)
                {
                    msg.To.Add(EmailID);
                    msg.Body = body;
                    msg.IsBodyHtml = true;
                    msg.Subject = Sub;
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

        private string PopulateBody(string DisplayName, string EmailID, string LoginName, string Password, string link)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("AddUsers1.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{DisplayName}", DisplayName);
            body = body.Replace("{LoginName}", LoginName);
            body = body.Replace("{Password}", Password);
            body = body.Replace("{Link}", link);


            return body;
        }

        //protected void GenerateMailFormat()
        //{
        //    string email = oUserBLL.GetEmailId(Convert.ToInt32(lblUserId.Text));
        //    //string body = this.PopulateBody(txtEmailAddress.Text, txtCompanyName.Text);


        //    ////Pass Parameters to SendMail function
        //    //this.sendMail(txtEmailAddress.Text, Convert.ToString("Login Credentials"), body);

        //}

        //private string PopulateBody(String EmailID, string CompanyName)
        //{
        //    string body = string.Empty;
        //    using (StreamReader reader = new StreamReader(Server.MapPath("RegistrationEmail.html")))
        //    {
        //        body = reader.ReadToEnd();
        //    }
        //    body = body.Replace("{Company_Name}", CompanyName);


        //    return body;
        //}

        //private void sendMail(string EmailID, string Subject, string Body)
        //{
        //    MailMessage msg = new MailMessage();
        //    try
        //    {
        //        msg.From = new MailAddress(AppConstants.fromMail);
        //        if (EmailID != "" || EmailID != string.Empty)
        //        {
        //            msg.To.Add(EmailID);
        //            msg.Body = Body;
        //            msg.IsBodyHtml = true;
        //            msg.Subject = Subject;
        //            SmtpClient smt = new SmtpClient(AppConstants.mailHost);
        //            smt.Port = AppConstants.mailPort;
        //            smt.Credentials = new NetworkCredential(AppConstants.fromMail, AppConstants.defaultPswd);
        //            smt.EnableSsl = true;
        //            smt.Send(msg);
        //        }

        //    }
        //    catch (Exception Ex)
        //    {

        //    }
        //    finally
        //    {

        //        msg.Dispose();
        //    }
        //}   

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default1.aspx");
        }

        protected void ImgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCapctha();
        }

        public void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                Session["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "~/GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "FillCapctha()";
                String MODULE_NAME = "HomePage.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        private void Clear()
        {
            //  txtUName.Text = string.Empty;
            //  txtPwd.Text = string.Empty;
            txtCaptcha.Text = string.Empty;

        }
    }
}