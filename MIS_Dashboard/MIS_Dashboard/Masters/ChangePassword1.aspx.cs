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

namespace MIS_Dashboard.Masters
{
    public partial class ChangePassword : System.Web.UI.Page
    {
       
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserRecNo"].ToString() != null || Session["UserRecNo"].ToString() != string.Empty)
                {
                    lblUserId.Text = Session["UserRecNo"].ToString();
                    lblLoginName.Text = Session["LoginName"].ToString();
                }

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

                                CommonDAL.DisplayPopUpMessage(this, "User Password Changed Successfully and an email has been sent to the user with all Important details.", "Default.aspx");
                              //  DisplayPopUpMessage(this, "User Password Changed Successfully and an email has been sent to the user with all Important details.", "");
                              
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
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("AddUsers.html")))
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
            Response.Redirect("~/Default.aspx");
        }
    }
}