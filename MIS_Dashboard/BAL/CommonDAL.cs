using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using DAL;



namespace BAL
{
    public class CommonDAL
    {
        SqlHelper sql = new SqlHelper();

        #region string Encoding/Decoding
        public string EncodeString(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];

                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

                string encodedData = Convert.ToBase64String(encData_byte);

                return encodedData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encryption" + ex.Message);
            }
        }

        public string DecodeString(string sData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(sData);

                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

                char[] decoded_char = new char[charCount];

                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

                string result = new String(decoded_char);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Decryption : " + ex.Message);
                //InsertException("DecodeString", "CommonDAL", ex.Message);
            }
        }
        #endregion



        public static void DisplayPopUpMessage(Control control, string message, string url)
        {
            string msg = "";
            msg += "alert('" + message + "');";
            if (url != string.Empty)
            {
               msg += "window.location.href = '" + url + "';";
            }
            ScriptManager.RegisterStartupScript(control, control.GetType(), "Popup", msg, true);
        }

        #region Password Encryption/Decryption
        //Password Added by sachin 16-07-2016
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region Email and EmailwithAttachment
        //SOCB SACHIN 16-07-2016
        public static int SendMail(string strMailSubject, string strMessage, string strMailTo, string strMailCC)
        {
            MailMessage message = null;
            int intStatusMessage = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();

                smtp.Host = AppConstants.mailHost;
                smtp.Port = AppConstants.mailPort;
                smtp.Credentials = new NetworkCredential(AppConstants.fromMail, AppConstants.fromMailPwd);

                message = new MailMessage();
                //message.To.Add(new MailAddress(strMailTo));
                string[] Multi = strMailTo.Split(',');
                foreach (string MultiEmailID in Multi)
                {
                    message.To.Add(new MailAddress(MultiEmailID));
                }
                message.Subject = strMailSubject;
                message.From = new MailAddress(AppConstants.fromMail);
                message.IsBodyHtml = true;
                message.Body = strMessage;
                smtp.EnableSsl = true;
                smtp.Send(message);
                intStatusMessage = 1;
                return intStatusMessage;

            }
            catch (Exception ex)
            {
                message.Dispose();
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "SendMail";
                String MODULE_NAME = "CommonDal";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                return 0;
            }
        }

        //EOCB SACHIN 16-07-2016

        //SOCB SACHIN 16-07-2016
        public static int SendMailWithAttachment(string strMailSubject, string strMessage, string strMailTo, string strMailCC, string strAttachPath)
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
                string[] Multi = strMailTo.Split(',');
                foreach (string MultiEmailID in Multi)
                {
                    if (MultiEmailID != "" && MultiEmailID != string.Empty)
                        message.To.Add(new MailAddress(MultiEmailID));
                }
                //if Multiple CC recipients
                string[] MultiCC = strMailCC.Split(',');
                foreach (string EmailIDCC in MultiCC)
                {
                    if (EmailIDCC != "" && EmailIDCC != string.Empty)
                        message.CC.Add(new MailAddress(strMailCC));
                }

                //recipients

                message.Subject = strMailSubject;
                message.IsBodyHtml = true;
                message.Body = strMessage;
                if (strAttachPath != string.Empty)
                {
                    Attachment attachment = new System.Net.Mail.Attachment(strAttachPath);
                    message.Attachments.Add(attachment);
                }

                smtp.Send(message);
                intStatusMessage = 1;

                return intStatusMessage;

            }
            catch (Exception ex)
            {
                message.Dispose();
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "SendMailwithAttachment";
                String MODULE_NAME = "CommonDal";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                return 0;
            }
        }

        public static int sendMailCrystelReport(string EmailID, string Subject, string Body, MemoryStream File)
        {
            MailMessage msg = new MailMessage();
            int Status = 0;
            try
            {
                msg.From = new MailAddress(AppConstants.fromMail);
                if (EmailID != "" || EmailID != string.Empty)
                {
                    string[] multi = EmailID.Split(',');
                    foreach (string EM in multi)
                    {
                        msg.To.Add(EM);
                    }
                    if (File != null)
                    {
                        msg.Attachments.Add(new Attachment(File, "ApplicationForm.pdf"));

                    }
                    msg.Body = Body;
                    msg.IsBodyHtml = true;
                    msg.Subject = Subject;
                    SmtpClient smt = new SmtpClient(AppConstants.mailHost);
                    smt.Port = AppConstants.mailPort;
                    smt.Credentials = new NetworkCredential(AppConstants.fromMail, AppConstants.defaultPswd);
                    smt.EnableSsl = true;
                    smt.Send(msg);

                }
                return Status = 1;
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "sendMailCrystelReport";
                String MODULE_NAME = "PaymentReceipt";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string Error_refno = OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                return Status = 0;
            }
            finally
            {

                msg.Dispose();
            }
        }

        //EOCB SACHIN 16-07-2016
        #endregion

        #region SMS

        #endregion


       

        public int GetPermissions(int pageID, int User_recno)
        {
            UserBAL obal = new UserBAL();
            return obal.GetPermissions(pageID, User_recno);
        }

        public System.Data.DataTable pageAuth(int pageID, object userid)
        {
            MySqlParameter[] spm = { new MySqlParameter("@User_Id", userid),
                               new MySqlParameter("@page_ID",pageID)};
            DataTable dt = sql.getDataTable("proc_page_authorization", spm, "tab");
            return dt;
        }
    }
}
