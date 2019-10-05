using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace MIS_Dashboard
{
    public partial class ForgetPassword : System.Web.UI.Page
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
            try
            {
                if (!IsPostBack)
                {
                    FillCapctha();
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "Page_Load";
                String MODULE_NAME = "ForgetPassword.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }

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
                String MODULE_NAME = "ForgetPassword.aspx";
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (Session["captcha"].ToString() != txtCaptcha.Text)
                    {
                        lblCaptcha.Text = "Enter Correct Captca Code";
                        lblCaptcha.ForeColor = System.Drawing.Color.Red;
                        Clear();
                        CommonDAL.DisplayPopUpMessage(this, "Please Enter Captca.", "");
                    }
                    else
                    {
                        string username = Request.Form["txtUsername"];
                        string ted = txtForgetUser.Value.ToString();
                        string DisplayName;
                        string LoginName;
                        string EmailID;
                        string Password;
                        if (txtForgetUser.Value.ToString() != "")
                        {
                            //FOR DIFFERENTCIATE BETWEEN CLIENT USER AND Authority USER(ADDED BY SACHIN 06-09-2015)
                            string Name = "Authority";
                            DateTime expiryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            ds = oUserBLL.GetForgetPasswordUserInfo(Name, txtForgetUser.Value.ToString().ToLower());
                            if (ds != null)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["User_auth"] != DBNull.Value)
                                    {
                                        if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "11")
                                        {
                                            //  CommonDAL.DisplayPopUpMessage(this, "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "User( " + txtForgetUser.Value.ToString() + " ) is not authorized for this Portal.Please Check username.";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "1" || ds.Tables[0].Rows[0]["User_auth"].ToString() == "2")
                                        {
                                            //CommonDAL.DisplayPopUpMessage(this, "Dear User,<br/>Your UserName/Passowrd is Incorrect.<br/><b>Note: Too many bad attempts cause account locks.</b>", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "Dear User,<br/>Your UserName/Passowrd is Incorrect.<br/><b>Note: Too many bad attempts cause account locks.</b>";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "0")
                                        {
                                            CommonDAL.DisplayPopUpMessage(this, "Dear User,<br/>your account is locked.Please Contact to system administrator.", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "Dear User,<br/>your account is locked.Please Contact to system administrator.";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else
                                        {
                                            Session["UserRecNo"] = ds.Tables[0].Rows[0]["USER_RECNO"].ToString();
                                            Session["LoginName"] = ds.Tables[0].Rows[0]["LOGIN_NAME"].ToString();
                                            Session["DisplayName"] = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
                                            //  Session["IIE_recno"] = ds.Tables[0].Rows[0]["Ind_area_recno"].ToString();
                                            //  Session["IIEName"] = ds.Tables[0].Rows[0]["Ind_area_name"].ToString();
                                            // Session["District_recno"] = ds.Tables[0].Rows[0]["District_Recno"].ToString();
                                            // Session["District_Name"] = ds.Tables[0].Rows[0]["District_Name"].ToString();
                                            Session["UserType"] = ds.Tables[0].Rows[0]["ROLE_USER_TYPE"].ToString();
                                            Session["SessionID"] = Session.SessionID + DateTime.Now.ToString();
                                            Session["RoleRecNo"] = ds.Tables[0].Rows[0]["ROLE_RECNO"].ToString();
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                String Action_type = "Passsword Changed";
                                                DisplayName = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString().Trim();
                                                LoginName = ds.Tables[0].Rows[0]["LOGIN_NAME"].ToString().Trim();
                                                EmailID = ds.Tables[0].Rows[0]["EMAILID"].ToString().Trim();
                                                Password = ds.Tables[0].Rows[0]["PASSWORD"].ToString().Trim();
                                                GenerateMailFormat(DisplayName, LoginName, EmailID, oCommonDAL.DecodeString(Password), Action_type);

                                                CommonDAL.DisplayPopUpMessage(this, "Your Login Credentials Send to Your Rgistered Mail", "HomePage.aspx");

                                            }
                                            //Response.Redirect("~/HomePage.aspx", false);
                                           
                                        }
                                    }
                                }
                                else
                                {
                                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                    //string title = "Message from System";
                                    //string msg = "Dear User,<br/>Unable to recognize this user or Something wrong happened";
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                    CommonDAL.DisplayPopUpMessage(this, "Dear User,Unable to recognize this user or Something wrong happened", "");
                                }
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                //string title = "Message from System";
                                //string msg = "Dear User,<br/>Unable to recognize this user or Something wrong happened";
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                CommonDAL.DisplayPopUpMessage(this, "Dear User,Unable to recognize this user or Something wrong happened", "");
                            }

                        }
                        else
                        {
                            CommonDAL.DisplayPopUpMessage(this, "User( " + txtForgetUser.Value.ToString() + " ) is not authorized for this Portal.Please Check username.", "");
                           
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                //string title = "Message from System";
                //string msg = "Dear User,<br/>Something wrong happened. Unable to complete login process please try again with correct information.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                CommonDAL.DisplayPopUpMessage(this, "Dear User,Something wrong happened. Unable to complete Forget Password process please try again with correct information.", "");
                           
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnSubmit_Click";
                String MODULE_NAME = "ForgetPassword.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

            }
        }
        private void GenerateMailFormat(string DisplayName, string LoginName, string EmailID, string Password, string Action_type)
        {
            if (Action_type == "Passsword Changed")
            {
                string link = "Now you can login in MyDashboard Portal";
                string body = this.PopulateBody(DisplayName, EmailID, LoginName, Password, link);
                string Sub = "User login Details";

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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx");
        }
    }
}