using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace MIS_Dashboard.Masters
{
    public partial class AssignUserRights : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        AppConstants OAp = new AppConstants();
        CommonDAL oCommonDAL = new CommonDAL();
        UserBAL oUserBLL = new UserBAL();

        public int vsIntUserRecNo
        {
            get
            {
                if (ViewState["vsIntUserRecNo"] == null)
                    return 0;
                else
                    return (int)ViewState["vsIntUserRecNo"];
            }
            set
            {
                ViewState["vsIntUserRecNo"] = value;
            }
        }

        public int vsIntRoleRecNo
        {
            get
            {
                if (ViewState["vsIntRoleRecNo"] == null)
                    return 0;
                else
                    return (int)ViewState["vsIntRoleRecNo"];
            }
            set
            {
                ViewState["vsIntRoleRecNo"] = value;
            }
        }

        public int vsUserRoleRecNo
        {
            get
            {
                if (ViewState["vsUserRoleRecNo"] == null)
                    return 0;
                else
                    return (int)ViewState["vsUserRoleRecNo"];
            }
            set
            {
                ViewState["vsUserRoleRecNo"] = value;
            }
        }

        #region Permission Control added by sachin 10/06/2019
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
            try
            {
                if (!Page.IsPostBack)
                {
                    if ((Request.QueryString["rn"] != null) && (Request.QueryString["rn"].ToString() != ""))
                    {
                        vsIntUserRecNo = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["rn"].ToString()));

                        if ((Request.QueryString["Role"] != null) && (Request.QueryString["Role"].ToString() != ""))
                        {
                            vsUserRoleRecNo = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["Role"].ToString()));
                        }
                    }
                    else
                    {
                        if ((Request.QueryString["tn"] != null) && (Request.QueryString["tn"].ToString() != ""))
                        {
                            vsIntRoleRecNo = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["tn"].ToString()));
                        }
                        else
                        {
                            Response.Redirect("AssignUserRights.aspx");
                        }
                    }

                    if (Request.QueryString["md"] != null && Request.QueryString["md"].ToString() != string.Empty)
                    {
                        int intPageRights = Convert.ToInt32(oCommonDAL.DecodeString(Request.QueryString["md"].ToString()));
                        intPageRights = 1;

                        if (intPageRights == 1)
                        {
                            tblPageRights.Enabled = true;
                            btnAssign.Enabled = true;
                        }
                        else if (intPageRights == 0)
                        {
                            tblPageRights.Enabled = false;
                            btnAssign.Enabled = false;
                            btnCancel.Text = "Close";
                        }
                        else
                        {
                            tblPageRights.Enabled = false;
                            btnAssign.Enabled = false;
                            // Response.Redirect("~/UnderConstraction.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("UserMaster.aspx");
                    }
                }
                DisplayMenuItems();
            }
            catch (Exception ex)
            {


                string title = "Message from System";
                string msg = "<p>Dear User</p><br/> <p>Something went wrong. Please try later.</p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
            }
        }

        private void DisplayMenuItems()
        {
            try
            {
                DataTable dt = oUserBLL.GetAllMenuItems(vsUserRoleRecNo);
                int k = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    decimal parentID = -1;

                    if (Convert.ToInt32(dr["Parent_ID"]) == 0)
                    {
                        TableRow th = new TableRow();
                        TableCell tc = new TableCell();
                        tc.ColumnSpan = 2;
                        tc.Text = dr["MENU_NAME"].ToString();
                        th.Cells.Add(tc);
                        tc.HorizontalAlign = HorizontalAlign.Left;
                        tc.Style.Add("background-color", "#088CD6");
                        tc.Style.Add("color", "#ffffff");
                        tc.CssClass = "panel-heading";
                        tblPageRights.Rows.Add(th);
                        parentID = -1;
                    }
                    else if (Convert.ToString(dr["MENU_URL"]) == "#")
                    {
                        TableRow th = new TableRow();
                        TableCell tc = new TableCell();
                        tc.ColumnSpan = 2;
                        tc.Text = dr["MENU_NAME"].ToString();
                        th.Cells.Add(tc);
                        tc.HorizontalAlign = HorizontalAlign.Left;
                        tc.BorderWidth = 0;
                        tc.Style.Add("padding-left", "20px");
                        tc.CssClass = "";
                        tc.CssClass = "panel-heading btn-success";
                        tblPageRights.Rows.Add(th);
                        parentID = Convert.ToDecimal(dr["Menu_ID"]);
                    }
                    else
                    {
                        TableRow tblRow = new TableRow();
                        TableCell tc1 = new TableCell();
                        CheckBox chkView = new CheckBox();

                        chkView.ID = "chk" + k.ToString();
                        k++;
                        chkView.Text = dr["MENU_NAME"].ToString();
                        chkView.AutoPostBack = true;
                        tc1.Controls.Add(chkView);

                        tblRow.Cells.Add(tc1);
                        tc1.HorizontalAlign = HorizontalAlign.Left;
                        if (Convert.ToDecimal(dr["Parent_ID"]) == parentID)
                        {
                            tc1.Style.Add("padding-left", "20px");
                        }

                        TableCell tc2 = new TableCell();
                        CheckBox chkEdit = new CheckBox();
                        chkEdit.Text = dr["MENU_NAME"].ToString();
                        chkEdit.AutoPostBack = true;
                        chkEdit.CheckedChanged += new EventHandler(chkEdit_CheckedChanged);
                        chkEdit.ID = "chk" + k.ToString();

                        k++;
                        tc2.Controls.Add(chkEdit);
                        tblRow.Cells.Add(tc2);
                        tc2.HorizontalAlign = HorizontalAlign.Left;
                        if (Convert.ToDecimal(dr["PARENT_ID"]) == parentID)
                        {
                            tc2.Style.Add("padding-left", "20px");
                        }

                        TableCell tc3 = new TableCell();
                        HiddenField hdnVal = new HiddenField();
                        hdnVal.ID = "hdn" + k.ToString();
                        hdnVal.Value = dr["Menu_ID"].ToString();
                        tc3.Controls.Add(hdnVal);
                        tblRow.Cells.Add(tc3);
                        tc3.Style.Add("border-width", "0px");
                        tblPageRights.Rows.Add(tblRow);
                        k++;
                    }
                }

                if (vsIntUserRecNo != 0)
                {
                    DataTable dt1 = oUserBLL.GetMenuRightsForUser(vsIntUserRecNo, vsUserRoleRecNo);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            k = 0;
                            for (int m = 1; m < tblPageRights.Rows.Count; m++)
                            {
                                int cellCount = tblPageRights.Rows[m].Cells.Count;
                                if (cellCount > 1)
                                {
                                    HiddenField hdnMenuID = (HiddenField)tblPageRights.Rows[m].FindControl(("hdn" + (k + 3).ToString()));
                                    if (hdnMenuID.Value == dr["MENU_ID"].ToString())
                                    {
                                        CheckBox chkView = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 1).ToString());
                                        if (dr["EDITVIEW_RIGHTS"].ToString() == "0")
                                        {
                                            chkView.Checked = true;
                                        }
                                        else if (dr["EDITVIEW_RIGHTS"].ToString() == "1")
                                        {
                                            CheckBox chkEdit = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 2).ToString());
                                            chkView.Checked = true;
                                            chkView.Enabled = false;
                                            chkEdit.Checked = true;
                                        }
                                        break;
                                    }
                                    k = k + 3;
                                }
                            }
                        }
                    }
                    else
                    {

                        DataTable dt2 = oUserBLL.GetMenuRightsForUserRoleBased(vsUserRoleRecNo);
                        foreach (DataRow dr in dt2.Rows)
                        {
                            k = 0;
                            for (int m = 1; m < tblPageRights.Rows.Count; m++)
                            {
                                int cellCount = tblPageRights.Rows[m].Cells.Count;
                                if (cellCount > 1)
                                {
                                    HiddenField hdnMenuID = (HiddenField)tblPageRights.Rows[m].FindControl(("hdn" + (k + 3).ToString()));
                                    if (hdnMenuID.Value == dr["MENU_ID"].ToString())
                                    {
                                        CheckBox chkView = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 1).ToString());
                                        if (dr["EDITVIEW_RIGHTS"].ToString() == "0")
                                        {
                                            chkView.Checked = true;
                                        }
                                        else if (dr["EDITVIEW_RIGHTS"].ToString() == "1")
                                        {
                                            CheckBox chkEdit = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 2).ToString());
                                            chkView.Checked = true;
                                            chkView.Enabled = false;
                                            chkEdit.Checked = true;
                                        }
                                        break;
                                    }
                                }
                                k = k + 3;
                            }
                        }
                    }
                }

                else
                {
                    if (vsIntRoleRecNo != 0)
                    {
                        DataTable dt4 = oUserBLL.GetMenuRightsForUserRoleBased(vsIntRoleRecNo);
                        if (dt4.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt4.Rows)
                            {
                                k = 0;
                                for (int m = 1; m < tblPageRights.Rows.Count; m++)
                                {
                                    int cellCount = tblPageRights.Rows[m].Cells.Count;
                                    if (cellCount > 1)
                                    {
                                        HiddenField hdnMenuID = (HiddenField)tblPageRights.Rows[m].FindControl(("hdn" + (k + 3).ToString()));
                                        if (hdnMenuID.Value == dr["MENU_ID"].ToString())
                                        {
                                            CheckBox chkView = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 1).ToString());
                                            if (dr["EDITVIEW_RIGHTS"].ToString() == "0")
                                            {
                                                chkView.Checked = true;

                                            }
                                            else if (dr["EDITVIEW_RIGHTS"].ToString() == "1")
                                            {
                                                CheckBox chkEdit = (CheckBox)tblPageRights.Rows[m].FindControl("chk" + (k + 2).ToString());
                                                chkView.Checked = true;
                                                chkView.Enabled = false;
                                                chkEdit.Checked = true;
                                            }
                                            break;
                                        }
                                        k = k + 3;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "Dear User,<br/> <p>Something went wrong while fetching the menu details and existing rights of this user. Please try later or contact to system administrator.</p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);
                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "DisplayMenuItems";
                String MODULE_NAME = "AssignUserRights";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;
                string id = chk.ID;
                int viewId = Convert.ToInt32(id.Substring(3)) - 1;
                CheckBox chkView = (CheckBox)(tblPageRights.FindControl("chk" + viewId.ToString()));

                if (chk.Checked)
                {
                    if (chkView != null)
                    {
                        chkView.Checked = true;
                        chkView.Enabled = false;
                    }
                }
                else
                {
                    chkView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "<p>Dear User</p><br/> <p>Something went wrong while assigning this menu to current selected user. Please try later or contact to system administrator.</p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "chkEdit_CheckedChanged";
                String MODULE_NAME = "AssignUserRights";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);
            }
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                int k = 0;
                if (vsIntUserRecNo != 0)
                {
                    for (int i = 1; i < tblPageRights.Rows.Count; i++)
                    {
                        int cellCount = tblPageRights.Rows[i].Cells.Count;
                        if (cellCount > 1)
                        {
                            CheckBox chkView = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 1).ToString());
                            CheckBox chkEdit = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 2).ToString());
                            HiddenField hdnVal = (HiddenField)tblPageRights.Rows[i].FindControl(("hdn" + (k + 3).ToString()));
                            k = k + 3;

                            int MenuID = 0;
                            int USER_REC_N = 0;
                            int EDITVIEW_RIGHTS = -1;
                            MenuID = Convert.ToInt32(hdnVal.Value);
                            USER_REC_N = vsIntUserRecNo;
                            if (chkView.Checked)
                            {
                                EDITVIEW_RIGHTS = 0;
                            }
                            if (chkEdit.Checked)
                            {
                                EDITVIEW_RIGHTS = 1;
                            }

                            int status = 0;
                            if (EDITVIEW_RIGHTS != -1)
                            {
                                if (vsUserRoleRecNo == 4 || vsIntRoleRecNo == 4)
                                {
                                    status = oUserBLL.InsertMenuPermissionsForClient(MenuID, USER_REC_N, EDITVIEW_RIGHTS, vsUserRoleRecNo);
                                }
                                else
                                {
                                    status = oUserBLL.InsertMenuPermissionsForClient(MenuID, USER_REC_N, EDITVIEW_RIGHTS, vsUserRoleRecNo);
                                }
                            }
                            else
                            {
                                if (vsUserRoleRecNo == 4 || vsIntRoleRecNo == 4)
                                {
                                    status = oUserBLL.DeleteMenuPermissions(MenuID, USER_REC_N, EDITVIEW_RIGHTS, vsUserRoleRecNo);
                                }
                                else
                                {
                                    status = oUserBLL.DeleteMenuPermissions(MenuID, USER_REC_N, EDITVIEW_RIGHTS, vsUserRoleRecNo);
                                }
                            }
                            if (status > 0)
                            {
                                string Url = "UserMaster.aspx";
                                string title = "Message from System";
                                string msg = "<p>Dear User</p><br/> <p>Pages rights successfully assigned to current selected user.</p>";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');function Redirect(){window.location='" + Url + "';}setTimeout('Redirect()', 4000);", true);

                            }
                        }
                    }
                }
                else
                {
                    DataTable dt8 = oUserBLL.GetAllUserRecNo(vsIntRoleRecNo);
                    int RESULT = oUserBLL.DeleteMenuPermissionsBasedonRole(vsIntRoleRecNo);
                    if (dt8.Rows.Count > 0)
                    {
                        foreach (DataRow dr4 in dt8.Rows)
                        {
                            k = 0;
                            for (int i = 1; i < tblPageRights.Rows.Count; i++)
                            {
                                int cellCount = tblPageRights.Rows[i].Cells.Count;
                                if (cellCount > 1)
                                {
                                    CheckBox chkView = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 1).ToString());
                                    CheckBox chkEdit = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 2).ToString());
                                    HiddenField hdnVal = (HiddenField)tblPageRights.Rows[i].FindControl(("hdn" + (k + 3).ToString()));

                                    k = k + 3;

                                    int MenuID2 = Convert.ToInt32(hdnVal.Value);
                                    int Userrecno2 = Convert.ToInt32(dr4["USER_RECNO"]);

                                    int RoleMENU_ID = Convert.ToInt32(hdnVal.Value);
                                    int RoleRecno = vsIntRoleRecNo;
                                    int EditViewForMenupermission = -1;
                                    if (chkView.Checked)
                                    {
                                        EditViewForMenupermission = 0;
                                        EditViewForMenupermission = 0;
                                    }
                                    if (chkEdit.Checked)
                                    {
                                        EditViewForMenupermission = 1;
                                        EditViewForMenupermission = 1;
                                    }

                                    int status = 0;
                                    if (EditViewForMenupermission != -1)
                                    {
                                        status = oUserBLL.InsertUserRecNoRolePermission(RoleMENU_ID, RoleRecno, EditViewForMenupermission);

                                        if (vsIntRoleRecNo == 4 || vsIntRoleRecNo == 4)
                                        {
                                            status = oUserBLL.InsertMenuRolePermissions(Userrecno2, MenuID2, EditViewForMenupermission, vsIntRoleRecNo);
                                        }
                                        else
                                        {
                                            status = oUserBLL.InsertMenuRolePermissions(Userrecno2, MenuID2, EditViewForMenupermission, vsIntRoleRecNo);
                                        }
                                    }
                                    else
                                    {
                                        if (vsIntRoleRecNo == 4 || vsIntRoleRecNo == 4)
                                        {
                                            status = oUserBLL.DeleteMenuPermissions(Userrecno2, MenuID2, EditViewForMenupermission, vsIntRoleRecNo);
                                            status = oUserBLL.DeleteMenuRolePermissions(RoleRecno, RoleMENU_ID);
                                        }
                                        else
                                        {
                                            status = oUserBLL.DeleteMenuPermissions(Userrecno2, MenuID2, EditViewForMenupermission, vsIntRoleRecNo);
                                            status = oUserBLL.DeleteMenuRolePermissions(RoleRecno, RoleMENU_ID);
                                        }
                                    }
                                    if (status > 0)
                                    {
                                        string Url = "UserMaster.aspx";
                                        string title = "Message from System";
                                        string msg = "<p>Dear User</p><br/> <p>Pages rights successfully assigned to current selected role.</p>";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');function Redirect(){window.location='" + Url + "';}setTimeout('Redirect()', 4000);", true);

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        k = 0;
                        for (int i = 1; i < tblPageRights.Rows.Count; i++)
                        {
                            int cellCount = tblPageRights.Rows[i].Cells.Count;
                            if (cellCount > 1)
                            {
                                CheckBox chkView = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 1).ToString());
                                CheckBox chkEdit = (CheckBox)tblPageRights.Rows[i].FindControl("chk" + (k + 2).ToString());
                                HiddenField hdnVal = (HiddenField)tblPageRights.Rows[i].FindControl(("hdn" + (k + 3).ToString()));

                                k = k + 3;

                                int RolePermissionMenuID = Convert.ToInt32(hdnVal.Value);
                                int RolePermissionRoleRecno = vsIntRoleRecNo;
                                int RolePermissionEditView = -1;

                                if (chkView.Checked)
                                {
                                    RolePermissionEditView = 0;

                                }
                                if (chkEdit.Checked)
                                {
                                    RolePermissionEditView = 1;

                                }

                                int status = 0;
                                if (RolePermissionEditView != -1)
                                {
                                    status = oUserBLL.InsertUserRecNoRolePermission(RolePermissionMenuID, RolePermissionRoleRecno, RolePermissionEditView);
                                }
                                else
                                {
                                    if (vsIntRoleRecNo == 4 || vsIntRoleRecNo == 4)
                                    {
                                        status = oUserBLL.DeleteMenuRolePermissions(RolePermissionRoleRecno, RolePermissionMenuID);
                                    }
                                    else
                                    {
                                        status = oUserBLL.DeleteMenuRolePermissions(RolePermissionRoleRecno, RolePermissionMenuID);
                                    }
                                }
                                if (status > 0)
                                {
                                    string Url = "UserMaster.aspx";
                                    string title = "Message from System";
                                    string msg = "<p>Dear User</p><br/> <p>Pages rights successfully assigned to current selected user.</p>";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-success','" + msg + "');function Redirect(){window.location='" + Url + "';}setTimeout('Redirect()', 4000);", true);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string title = "Message from System";
                string msg = "<p>Dear User</p><br/> <p>Something went wrong while saving the assigned menus to user. Please try later.</p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Message('" + title + "','btn-danger','" + msg + "');", true);

                AppConstants OAp = new AppConstants();
                String FUNCTION_NAME = "btnAssign_Click";
                String MODULE_NAME = "AssignUserRights";
                String ERROR_TYPE = "Application";
                String ERROR_DESC = ex.Message;
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                OAp.InsertException(FUNCTION_NAME, MODULE_NAME, ERROR_TYPE, ERROR_DESC, url, lineNumber);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMaster.aspx", false);
        }
    }
}