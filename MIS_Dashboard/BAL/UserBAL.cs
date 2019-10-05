using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using DAL;

namespace BAL
{
    public class UserBAL
    {
        UserDAL oUserDLL = new UserDAL();
        DataSet ds = new DataSet();
        CommonDAL oCommonDAL = new CommonDAL();
        AppConstants OAp = new AppConstants();
        MenuDLL oMenuDetails = new MenuDLL();

        public int InsertUserActivityDetails(string strlastActivity, string LoginName)
        {
            return oUserDLL.InsertUserActivityDetails(strlastActivity, LoginName);
        }

        public int BindAllUsers(GridView grdvUser, string Condtion, Int32 User_Recno)
        {
            int COUNT = 0;
            ds = oUserDLL.BindAllUsers(Condtion, User_Recno);
            if (ds.Tables.Count > 0)
            {
                grdvUser.DataSource = ds;
                grdvUser.DataBind();
                COUNT = ds.Tables[0].Rows.Count;
                return COUNT;
            }
            else
            {

                return COUNT;
            }

        }

        //public int GetPermissions(int menuID, int userRecNo)
        //{
        //    return oUserDLL.GetPermissions(menuID, userRecNo);
        //}

        public void DeleteUser(GridView grdvUser, object sender, int Current_user_recno, string condtion)
        {
            try
            {

                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);

                GridViewRow row = grdvUser.Rows[rowindex];
                HiddenField hdnUserRecNo = (HiddenField)row.FindControl("hdnUserRecNo");
                int USER_RECNO = Convert.ToInt32(hdnUserRecNo.Value);
                string MODIFIED_BY = HttpContext.Current.Session["LoginName"].ToString();

                int result = oUserDLL.DeleteUserDetails(USER_RECNO, MODIFIED_BY);
                if (result == 1)
                {
                    //CommonDAL.DisplayPopUpMessage(this, "User Deleted Successfully", "");
                    //string title = "Message from System";
                    //string msg = "<i></i> User Deleted successfully!!! ";
                    //ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                }
                else
                {
                    string title = "Message from System";
                    string msg = "<i ></i> Unable to delete this user please try again and In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com ";
                    ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                }



                BindAllUsers(grdvUser, condtion, Current_user_recno);
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "DeleteUser";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void EditUser(GridView grdvUser, object sender)
        {
            try
            {

                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);

                GridViewRow row = grdvUser.Rows[rowindex];
                HiddenField hdnUserRecNo = (HiddenField)row.FindControl("hdnUserRecNo");
                int userRecNoRecNo = Convert.ToInt32(hdnUserRecNo.Value);

                HttpContext.Current.Response.Redirect("~/Masters/AddUser.aspx?rn=" + oCommonDAL.EncodeString(userRecNoRecNo.ToString()) + "&md=" + oCommonDAL.EncodeString("EDIT"), false);
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "EditUser";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void ViewUser(GridView grdvUser, object sender)
        {
            try
            {
                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);

                GridViewRow row = grdvUser.Rows[rowindex];
                HiddenField hdnUserRecNo = (HiddenField)row.FindControl("hdnUserRecNo");
                int userRecNo = Convert.ToInt32(hdnUserRecNo.Value);

                HttpContext.Current.Response.Redirect("~/Masters/AddUser.aspx?rn=" + oCommonDAL.EncodeString(userRecNo.ToString()) + "&md=" + oCommonDAL.EncodeString("VIEW"), false);
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "ViewUser";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void AssignRights(GridView grdvUser, object sender, int vsIntPageRights)
        {
            try
            {
                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);

                GridViewRow row = grdvUser.Rows[rowindex];
                HiddenField hdnROLE_RECNO = (HiddenField)row.FindControl("hdnROLE_RECNO");
                HiddenField hdnUserRecNo = (HiddenField)row.FindControl("hdnUserRecNo");
                int userRecNoRecNo = Convert.ToInt32(hdnUserRecNo.Value);
                int UserRoleRecno = Convert.ToInt32(hdnROLE_RECNO.Value);
                HttpContext.Current.Response.Redirect("AssignUserRights.aspx?rn=" + oCommonDAL.EncodeString(userRecNoRecNo.ToString()) + "&md=" + oCommonDAL.EncodeString(vsIntPageRights.ToString()) + "&Role=" + oCommonDAL.EncodeString(UserRoleRecno.ToString()), false);

            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "AssignRights";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        public void AssignDashboardRights(GridView grdvUser, object sender, int vsIntPageRights)
        {
            try
            {
                GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);    // get reference to the row
                GridViewRow row1 = grdvUser.Rows[gridViewRow.RowIndex];
                int rowindex = Convert.ToInt16(row1.RowIndex);

                GridViewRow row = grdvUser.Rows[rowindex];
                HiddenField hdnROLE_RECNO = (HiddenField)row.FindControl("hdnROLE_RECNO");
                HiddenField hdnUserRecNo = (HiddenField)row.FindControl("hdnUserRecNo");
                int userRecNoRecNo = Convert.ToInt32(hdnUserRecNo.Value);
                int UserRoleRecno = Convert.ToInt32(hdnROLE_RECNO.Value);
                HttpContext.Current.Response.Redirect("~/DashboardPermissions.aspx?rn=" + oCommonDAL.EncodeString(userRecNoRecNo.ToString()) + "&md=" + oCommonDAL.EncodeString(vsIntPageRights.ToString()) + "&Role=" + oCommonDAL.EncodeString(UserRoleRecno.ToString()), false);

            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(grdvUser, grdvUser.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "AssignRights";
                String MODULE_NAME = "UserBLL";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        //public void GetSIDCODistrict(DropDownList ddlSIDCODistrict)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        ds = oUserDLL.GetSIDCODistrict();
        //        ddlSIDCODistrict.DataSource = ds;
        //        ddlSIDCODistrict.DataTextField = "DISTRICT_NAME";
        //        ddlSIDCODistrict.DataValueField = "DISTRICT_RECNO";
        //        ddlSIDCODistrict.DataBind();
        //        ddlSIDCODistrict.Items.Insert(0, new ListItem("Select", ""));
        //    }
        //    catch (Exception ex)
        //    {
        //        //if error
        //        AppConstants OAp = new AppConstants();
        //        String FUNCTION_NAME = "GetSIDCODistrict";
        //        String MODULE_NAME = "BindingHelper";
        //        String ERROR_TYPE = "Application";
        //        String ERROR_DESC = ex.Message;
        //        string url = HttpContext.Current.Request.Url.AbsoluteUri; string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
        //        OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

        //        string title = "Message from System";
        //        string msg = "Something Wrong happened please try again.in case you face similar issue please contect our help deskemailid: helpdesk@sidco.com";
        //        ScriptManager.RegisterStartupScript(ddlSIDCODistrict, ddlSIDCODistrict.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

        //    }

        //}

        #region UserMaster
        public void BindRole(DropDownList ddl)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = oUserDLL.GetAllRole();
                if (ds.Tables.Count > 0)
                {
                    ddl.DataSource = ds;
                    ddl.DataTextField = "ROLE_NAME";
                    ddl.DataValueField = "ROLE_RECNO";
                    ddl.DataBind();

                    ddl.Items.Insert(0, new ListItem("Select", "0"));

                }
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Something Wrong Happened. Unable to get Roles.please try again.In case you face similar issue please contact our help desk Emailid: helpdesk@sidco.com";
                ScriptManager.RegisterStartupScript(ddl, ddl.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                String FUNCTION_NAME = "BindingHelper";
                String MODULE_NAME = "BindRole";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }
        #endregion

        public int InsertUserdetails(string lOGIN_NAME, string dISPLAY_NAME, string cONTACT_NO, string eMAILID, DateTime pASSWORD_EXPIRYDATE, decimal rOLE_RECNO, int aCTIVE_STATUS, string pASSWORD, string cHANGE_PASSWORD, string lOCKED, string cREATED_BY, int divisionrecno)
        {
            return oUserDLL.InsertUserdetails(lOGIN_NAME, dISPLAY_NAME, cONTACT_NO, eMAILID, pASSWORD_EXPIRYDATE, rOLE_RECNO, aCTIVE_STATUS, pASSWORD, cHANGE_PASSWORD, lOCKED, cREATED_BY, divisionrecno);
        }

        public int UpdateUserdetails(int vsIntUserRecNo, string lOGIN_NAME, string dISPLAY_NAME, string cONTACT_NO, string eMAILID, DateTime pASSWORD_EXPIRYDATE, decimal rOLE_RECNO, int aCTIVE_STATUS, string pASSWORD, char cHANGE_PASSWORD, char lOCKED, string cREATED_BY, int divisionrecno)
        {
            return oUserDLL.UpdateUserdetails(vsIntUserRecNo, lOGIN_NAME, dISPLAY_NAME, cONTACT_NO, eMAILID, pASSWORD_EXPIRYDATE, rOLE_RECNO, aCTIVE_STATUS, pASSWORD, cHANGE_PASSWORD, lOCKED, cREATED_BY, divisionrecno);
        }

        public void GetSIDCOIIE(int Dist_recno, DropDownList ddlLocation)
        {
            DataSet ds = new DataSet();
            ds = oUserDLL.GetSIDCOIIE(Dist_recno);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = ds;
                ddlLocation.DataTextField = "Ind_area_name";
                ddlLocation.DataValueField = "Ind_area_recno";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        public DataSet DisplayUserDetails(int userRecNo)
        {
            return oUserDLL.DisplayUserDetails(userRecNo);
        }

        public DataTable GetAllMenuItems(int Role_recno)
        {
            return oMenuDetails.GetAllMenuItems(Role_recno);
        }

        public DataTable GetMenuRightsForUser(int Userecno, int Role_recno)
        {
            return oMenuDetails.GetMenuRightsForUser(Userecno, Role_recno);
        }

        public DataTable GetMenuRightsForUserRoleBased(int RoleRecno)
        {
            return oMenuDetails.GetMenuRightsForUserRoleBased(RoleRecno);
        }

        public int InsertMenuPermissionsForClient(int ID, int UseRecno, int EditView, int RoleRecNo)
        {
            return oMenuDetails.InsertMenuPermissionsForClient(ID, UseRecno, EditView, RoleRecNo);
        }

        // DELETE MENU PERMISSION BY MENUID,USERRECNO,EDITVIEWRIGHTS
        public int DeleteMenuPermissions(int ID, int UseRecno, int EditView, int Role_Recno)
        {
            return oMenuDetails.DeleteMenuPermissions(ID, UseRecno, EditView, Role_Recno);
        }
        //END

        public DataTable GetAllUserRecNo(int vsIntRoleRecNo)
        {
            return oMenuDetails.GetAllUserRecNo(vsIntRoleRecNo);
        }

        public int DeleteMenuPermissionsBasedonRole(int ID)
        {
            return oMenuDetails.DeleteMenuPermissionsBasedonRole(ID);
        }

        public int InsertUserRecNoRolePermission(int MenuID, int RoleRecno, int EditView)
        {
            return oMenuDetails.InsertUserRecNoRolePermission(MenuID, RoleRecno, EditView);
        }

        public int DeleteMenuRolePermissions(int Rolerecno, int MenuID)
        {
            return oMenuDetails.DeleteMenuRolePermissions(Rolerecno, MenuID);
        }

        public int InsertMenuRolePermissions(int UserRecno, int MenuID, int EditView, int Role_Recno)
        {
            return oMenuDetails.InsertMenuRolePermissions(UserRecno, MenuID, EditView, Role_Recno);
        }

        public void GetROLETYPE(DropDownList ddlRoleType)
        {
            DataSet ds = new DataSet();
            ds = oUserDLL.GetROLETYPE();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlRoleType.DataSource = ds;
                    ddlRoleType.DataTextField = "ROLE_TYPE";
                    ddlRoleType.DataValueField = "ROLE_TYPE_RECNO";
                    ddlRoleType.DataBind();
                    ddlRoleType.Items.Insert(0, new ListItem("Select", ""));
                }
            }
        }

        public void GetroleDetails(GridView grdvAddrole, HtmlGenericControl Griddiv)
        {

            try
            {
                ds = oUserDLL.GetroleDetails();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdvAddrole.DataSource = ds;
                        grdvAddrole.DataBind();

                    }
                    else
                    {
                        grdvAddrole.DataSource = ds;
                        grdvAddrole.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "GetOwnershipDetails";
                String MODULE_NAME = "Ownership.aspx";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                FUNCTION_NAME = "";
                MODULE_NAME = "";
                ERROR_TYPE = "";
                ERROR_DESC = "";
            }
        }

        public int insertRole(TextBox txtrolename, DropDownList ddlRoleType, string createdby)
        {
            //try
            //{
            string Role = Convert.ToString(ddlRoleType.SelectedValue);
            int result = oUserDLL.insertRole(txtrolename.Text, Role, createdby);
            return result;

            //}

            //catch (Exception ex)
            //{
            //    AppConstants OAp = new AppConstants();
            //    String FUNCTION_NAME = "insertcategory";
            //    String MODULE_NAME = "Category";
            //    String ERROR_TYPE = "Application";
            //    String ERROR_DESC = ex.Message;
            //    string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            //    string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //    OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            //    FUNCTION_NAME = "";
            //    MODULE_NAME = "";
            //    ERROR_TYPE = "";
            //    ERROR_DESC = "";
            //}
        }

        public void updaterole(HiddenField hdnRole, TextBox txtrolename, DropDownList ddlRoleType, object sender, HtmlGenericControl MainDiv, HtmlGenericControl Griddiv, string modifiedby)
        {
            try
            {
                int Role_Recno = Convert.ToInt32(hdnRole.Value);
                string Role = Convert.ToString(ddlRoleType.SelectedValue);
                int result = oUserDLL.updaterole(Role_Recno, txtrolename.Text, Role, modifiedby);
                if (result > 0)
                {
                    string title = "Message from System";
                    string msg = "Role Details Updated Successfully";
                    ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                }
                else if (result == -2)
                {
                    string title = "Message from System";
                    string msg = "Role Details must be distinct values ";
                    ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');", true);
                }
                else
                {
                    string title = "Message from System";
                    string msg = "Role Details Not Updated Successfully";
                    ScriptManager.RegisterStartupScript(txtrolename, txtrolename.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                }
            }
            catch (Exception ex)
            {
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "updatecategory";
                String MODULE_NAME = "Category";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
                FUNCTION_NAME = "";
                MODULE_NAME = "";
                ERROR_TYPE = "";
                ERROR_DESC = "";
            }
        }

        public DataSet GetRole(int role_Recno)
        {
            return oUserDLL.GetRole(role_Recno);
        }

        public DataSet GetUserInfo(string Name, string loginName, string password)
        {
            return oUserDLL.GetUserInfo(Name, loginName, password);
        }


        public int GetPermissions(int pageID, int p)
        {
            return oUserDLL.GetPermissions(pageID, p);
        }

        public int UpdatePassword(int userRecno, string oldpassword, string newpassword, string changepassword, string createdBy)
        {
            return oUserDLL.UpdatePassword(userRecno, oldpassword, newpassword, changepassword, createdBy);
        }

        public DataSet GetEmailId(int p)
        {
            return oUserDLL.GetEmailId(p);
        }

        public DataSet Get_Chart_Details_For_Permission()
        {
            return oUserDLL.Get_Chart_Details_For_Permission();
        }

        public DataSet Get_Chart_Permission_Details(int RoleRecNo)
        {
            return oUserDLL.Get_Chart_Permission_Details(RoleRecNo);
        }

        public int Insert_Chart_Permission(int chart_recno, int editright, int RoleRecNo)
        {
            return oUserDLL.Insert_Chart_Permission(chart_recno, editright, RoleRecNo);
        }

        public DataSet GetForgetPasswordUserInfo(string Name, string username)
        {
            return oUserDLL.GetForgetPasswordUserInfo( Name,  username);
        }

        public void BindDivision(DropDownList ddlDivision)
        {
            ddlDivision.DataSource = oUserDLL.BindDivision();
            ddlDivision.DataTextField = "DIVISION_NAME";
            ddlDivision.DataValueField = "DIVISION_RECNO";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, new ListItem("For Admin", "0"));
        }
    }
}
