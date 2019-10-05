using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.IO;
using DAL;
using System.Collections;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Drawing;

namespace BAL
{
    public class AppConstants
    {
        SqlHelper osqlHelper = new SqlHelper();
        #region Email
        public const string succesLoginStatus = "S";
        public const string failLoginStatus = "F";


        //Added by sachin for Online Payment CCAvenue
        public const string MerchantID = "104481";
        public const string AccessCode = "AVUA00DH48AG80AUGA";
        public const string WorkingKey = "2B1BEF7BC9120BD1A2930C438206B9E4";

        public const string defaultPswd = "123456";
        public const string fromMail = "vedangtestmail@gmail.com";
        public const string fromMailPwd = "vedang@2524";
        //public const string fromMail = "gnoidacity@gmail.com";
        //public const string fromMailPwd = "gnoida@123";
        public const string mailHost = "smtp.gmail.com";
        public const int mailPort = 587;
        #endregion

        #region Enumerations
        public enum ApplicationStatus { PendingatMI = 24, Approved = 4, Reject = 5, PendingatMINS = 48, }
        //public enum SingleWindowStatus { INPROCESS = 01, PENDING = "02", VIEWED = "03", VERIFIED = "04", FORWARDED = "05", APPROVED = "06", REJECTED = "07", QUERY_OBJECTION = "08", PUT_FOR_FURTHER_REVIEW = "09", SAVE_AS_DRAFT = "10", FEE_PAID = "11", FEE_PENDING = "12", FORM_SUBMITTED = "13", FORM_RESUBMITTED = "14", CERTIFICATE_NOCISSUED = "15" }
        #endregion

        #region Error
        public string InsertException(String FunctionName, String MODULE_NAME, String ERROR_TYPE, String ERROR_DESC, String url, string Line_No)
        {
            string Error_Refno = string.Empty;
            try
            {

                Hashtable ht = new Hashtable();
                ht.Add("@P_FUNCTION_NAME", FunctionName);
                ht.Add("@P_MODULE_NAME", MODULE_NAME);
                ht.Add("@P_ERROR_TYPE", ERROR_TYPE);
                ht.Add("@P_ERROR_DESC", ERROR_DESC);
                ht.Add("@P_ERROR_Page", url);
                ht.Add("@Line_No", Line_No);
                ht.Add("@ERROR_REFNO_out", "");
                // Error_Refno = osqlHelper.ExecuteQueryWithOutParamINString("PROC_INSERT_ERROR_DETAILS", ht);
                GenerateMailFormat(FunctionName, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, Line_No, Error_Refno);
                return Error_Refno;
            }
            catch (Exception ex)
            {
                Hashtable ht = new Hashtable();
                ht.Add("@P_FUNCTION_NAME", FunctionName);
                ht.Add("@P_MODULE_NAME", MODULE_NAME);
                ht.Add("@P_ERROR_TYPE", ERROR_TYPE);
                ht.Add("@P_ERROR_DESC", ex.ToString());
                ht.Add("@P_ERROR_Page", url);
                ht.Add("@Line_No", Line_No);
                ht.Add("@ERROR_REFNO_out", "");
                //  Error_Refno = osqlHelper.ExecuteQueryWithOutParamINString("PROC_INSERT_ERROR_DETAILS", ht);
                GenerateMailFormat(FunctionName, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, Line_No, Error_Refno);
                return Error_Refno;
            }
        }
        #endregion

        protected void GenerateMailFormat(String FunctionName, String ModuleName, String ErrorType, String ErrorDesc, String url, string Line_no, string Error_Refno)
        {
            try
            {
                string body = this.PopulateBody(FunctionName, ModuleName, ErrorType, ErrorDesc, url, Line_no, Error_Refno);

                //Pass Parameters to SendMail function
                this.sendMail("Sachin.bhatt@vedang.net", Convert.ToString("#Bug Details - INVESTGNIDA"), body);
            }
            catch (Exception ex)
            {

            }

        }

        private string PopulateBody(String FunctionName, string ModuleName, String ErrorName, String ErrorDesc, string url, string Error_Line_No, string Error_Refno)
        {
            try
            {
                string body = string.Empty;

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/ForError.html")))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{FunctionName}", FunctionName);
                body = body.Replace("{ModuleName}", ModuleName);
                body = body.Replace("{ErrorName}", ErrorName);
                body = body.Replace("{ErrorDesc}", ErrorDesc);
                body = body.Replace("{url}", url);
                body = body.Replace("{LineNo}", Error_Line_No);
                body = body.Replace("{Error_Refno}", Error_Refno);
                return body;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        private int sendMail(string EmailID, string Subject, string Body)
        {
            int intStatusMessage = 0;
            MailMessage message = null;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Host = AppConstants.mailHost;
                smtp.Port = AppConstants.mailPort;
                smtp.Credentials = new NetworkCredential(AppConstants.fromMail, AppConstants.fromMailPwd);

                message = new MailMessage();
                message.From = new MailAddress(AppConstants.fromMail);

                //if Multiple recipients
                string[] Multi = EmailID.Split(',');
                foreach (string MultiEmailID in Multi)
                {
                    if (MultiEmailID != "" && MultiEmailID != string.Empty)
                        message.To.Add(new MailAddress(MultiEmailID));
                }
                ////if Multiple CC recipients
                //string[] MultiCC = strMailCC.Split(',');
                //foreach (string EmailIDCC in MultiCC)
                //{
                //    if (EmailIDCC != "" && EmailIDCC != string.Empty)
                //        message.CC.Add(new MailAddress(EmailIDCC));
                //}

                //recipients

                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = Body;

                //if (strAttachPath != null && strAttachPath != string.Empty)
                //{
                //    Attachment attachment = new System.Net.Mail.Attachment(strAttachPath);
                //    message.Attachments.Add(attachment);
                //}

                smtp.Send(message);
                intStatusMessage = 1;

                return intStatusMessage;
            }
            catch (Exception ex)
            {
                //    String FUNCTION_NAME = "btnSaveApplicationDetails";
                //    String MODULE_NAME = "IndustriesApplicationForm";
                //    String ERROR_TYPE = "Application";
                //    String ERROR_DESC = ex.Message;
                //    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                //    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                //  string  Error_refno = InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                return intStatusMessage = 0;
            }
            finally
            {

                message.Dispose();
            }
        }
    }
}
