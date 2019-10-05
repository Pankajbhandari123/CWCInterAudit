using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.Web.Services;
using System.Security.Cryptography;
using System.IO;

namespace MIS_Dashboard
{
    public partial class HomePage : System.Web.UI.Page
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
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
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
                String MODULE_NAME = "HomePage.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                        string ted = txtUsername.Value.ToString();
                        if (txtUsername.Value.ToString() != "" && txtPassword.Value.ToString() != "")
                        {
                            string Name = "Authority";
                            DateTime expiryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            ds = oUserBLL.GetUserInfo(Name, txtUsername.Value.ToString().ToLower(), oCommonDAL.EncodeString(txtPassword.Value.ToString().Trim()));
                            if (ds != null)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["User_auth"] != DBNull.Value)
                                    {
                                        if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "11")
                                        {
                                            CommonDAL.DisplayPopUpMessage(this, "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "1" || ds.Tables[0].Rows[0]["User_auth"].ToString() == "2")
                                        {
                                            CommonDAL.DisplayPopUpMessage(this, "Dear User,Your UserName/Passowrd is Incorrect.Note: Too many bad attempts cause account locks.", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "Dear User,<br/>Your UserName/Passowrd is Incorrect.<br/><b>Note: Too many bad attempts cause account locks.</b>";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else if (ds.Tables[0].Rows[0]["User_auth"].ToString() == "0")
                                        {
                                            CommonDAL.DisplayPopUpMessage(this, "Dear User, your account is locked.Please Contact to system administrator.", "");
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                            string title = "Message from System";
                                            string msg = "Dear User,<br/>your account is locked.Please Contact to system administrator.";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                        }
                                        else if (ds.Tables[0].Rows[0]["CHANGE_PASSWORD"].ToString() == "T")
                                        {
                                            Session["UserRecNo"] = ds.Tables[0].Rows[0]["USER_RECNO"].ToString();
                                            Session["LoginName"] = ds.Tables[0].Rows[0]["LOGIN_NAME"].ToString();
                                            Session["DisplayName"] = ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
                                            //Session["IIE_recno"] = ds.Tables[0].Rows[0]["Ind_area_recno"].ToString();
                                            //Session["IIEName"] = ds.Tables[0].Rows[0]["Ind_area_name"].ToString();
                                            //Session["District_recno"] = ds.Tables[0].Rows[0]["District_Recno"].ToString();
                                            //Session["District_Name"] = ds.Tables[0].Rows[0]["District_Name"].ToString();
                                            Session["UserType"] = ds.Tables[0].Rows[0]["ROLE_USER_TYPE"].ToString();
                                            Session["SessionID"] = Session.SessionID + DateTime.Now.ToString();
                                            Session["RoleRecNo"] = ds.Tables[0].Rows[0]["ROLE_RECNO"].ToString();
                                            Session["IsDefaultPswd"] = "T";
                                            Response.Redirect("~/ChangePassword.aspx", false);

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
                                            Response.Redirect("~/Default1.aspx", false);
                                            //     Response.Redirect("~/Masters/DivisionMaster.aspx", false);
                                            // Response.Redirect("~/Dashboard/ActivityPlanActualDashboard.aspx");
                                            //   Response.Redirect("~/GNG/LithologyData.aspx", false);
                                            //   Response.Redirect("~/WorkOver/Work_Over_Details_Per_well.aspx", false);
                                            //    Response.Redirect("~/WorkOver/RigDeploymentSchedule.aspx", false);
                                            //  Response.Redirect("~/Drilling/DPR.aspx", false);
                                            // Response.Redirect("~/Drilling/DrillingPlan.aspx", false);
                                            //  Response.Redirect("~/Production/DateWiseProduction.aspx", false);
                                            // Response.Redirect("~/LandAcquisition/OwnerPaymentdetails.aspx", false);
                                            //   Response.Redirect("~/LandAcquisition/ActivityStatus.aspx", false);
                                            // Response.Redirect("~/LandAcquisition/Civil_Work.aspx", false);
                                            //  Response.Redirect("~/Master/LandOwnerDetails.aspx", false);

                                            //  Response.Redirect("~/Master/WellLocation.aspx", false);
                                            //  Response.Redirect("~/Process/ActivityMaster.aspx", false);
                                            // Response.Redirect("~/Master/WellLocation.aspx", false);
                                            // Response.Redirect("~/WellStatus/WellStatus.aspx", false);
                                            //  Response.Redirect("~/WellStatus/DateWiseWellStatus.aspx", false);
                                            //  Response.Redirect("~/Master/UserMaster.aspx", false);
                                            //   Response.Redirect("~/Master/RoleMaster.aspx", false);
                                            //  Response.Redirect("~/Report/WellStatusReport.aspx", false);
                                            //  Response.Redirect("~/ChangePassword.aspx", false);
                                            //   Response.Redirect("~/WellStatus/LandPlan.aspx", false);
                                            //  Response.Redirect("~/Report/ActivityWiseWellStatus.aspx", false);
                                            // Response.Redirect("~/Dashboard/ActivityWiseWellStatusDashboard.aspx");
                                            //  Response.Redirect("~/Dashboard/ActivityCompletedStatusDashboard.aspx");
                                            // Response.Redirect("~/Dashboard/PrdtnDashBordDayWise.aspx");
                                            //  Response.Redirect("~/Report/DateWiseProductionReport.aspx", false);
                                            //   Response.Redirect("~/Report/OwnerPaymentPendingReport.aspx", false);
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                    string title = "Message from System";
                                    string msg = "Dear User,<br/>Unable to recognize this user or Something wrong happened";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                string title = "Message from System";
                                string msg = "Dear User,<br/>Unable to recognize this user or Something wrong happened";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                            }

                        }
                        else
                        {
                            CommonDAL.DisplayPopUpMessage(this, "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.", "");
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                string title = "Message from System";
                string msg = "Dear User,<br/>Something wrong happened. Unable to complete login process please try again with correct information.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btn_login_Click";
                String MODULE_NAME = "MainPage.aspx";
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
            catch(Exception ex)
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

        #region Encryption Password
        [WebMethod(enableSession: true)]
        public static string Encrypt(string plainText)
        { //data: "{'Value' : asas}", 
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            byte[] cipherTextBytes;
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        #endregion 
    }
}