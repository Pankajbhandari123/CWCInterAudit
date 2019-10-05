using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;


namespace MIS_Dashboard
{
    public partial class HomePage1 : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string username = Request.Form["txtUsername"];
                    string ted = txtUsername.Value.ToString();
                    if (txtUsername.Value.ToString() != "" && txtPassword.Value.ToString() != "")
                    {
                        //FOR DIFFERENTCIATE BETWEEN CLIENT USER AND Authority USER(ADDED BY SACHIN 06-09-2015)
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
                                        //  CommonDAL.DisplayPopUpMessage(this, "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.", "");
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#AuthorityLogin').hide();", true);
                                        string title = "Message from System";
                                        string msg = "User( " + txtUsername.Value.ToString() + " ) is not authorized for this Portal.Please Check username.";
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
                                        Response.Redirect("~/Default.aspx", false);
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
    }
}