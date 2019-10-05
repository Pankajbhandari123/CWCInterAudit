using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Data.SqlClient;
using DAL;

namespace BAL
{
    public class PageClass
    {

        CommonDAL oCommonDAL = new CommonDAL();
        MenuDLL dal = new MenuDLL();
        public string RenderMenuPermissions(int userRecNo)
        {
            try
            {
                string MenuHTML = "";
                string BaseURL = "";

                DataSet ds = new DataSet();
                ds = dal.GetMenuDetails(userRecNo);

                DataView dv = new DataView(ds.Tables[0]);

                BaseURL = ConfigurationManager.AppSettings["BaseURL"].ToString();
                int i, zz = 0;

                MenuHTML += Environment.NewLine + "<ul id='nav' class='panel-heading'>" + Environment.NewLine;
                int val = 0;
                i = 0;
                MenuHTML += "<li> <a href='" + BaseURL + "/" + "Default1.aspx'>Dashboard</a></li>" + Environment.NewLine;
                int parentID = -1;
                ///int childParentID = -1;
                int count = 0;
                int count3Level = 0;
                foreach (DataRowView drv in dv)
                {
                    if (Convert.ToInt16(drv["PARENT_ID"]) == 0)
                    {
                        val = val + 1;
                        if (zz == 1)
                        {
                            if (count == -1)    //in case their are no 1st level submenu after 2nd level submenu for same parentID
                            {
                                if (count3Level == 3)
                                {
                                    MenuHTML += "</ul></li>" + Environment.NewLine;
                                    count3Level = 0;
                                }
                                MenuHTML += "</ul></li>" + Environment.NewLine;
                                MenuHTML += "</a></ul></li>";
                                count = 0;
                                zz = 0;
                            }
                            else
                            {
                                // MenuHTML += "</a></li></ul></li>";
                                MenuHTML += "</a></ul></li>";
                                zz = 0;
                                count = 0;
                            }
                        }
                        MenuHTML += Environment.NewLine + "<li>" + Environment.NewLine;
                        MenuHTML += "<a href=\"" + drv["MENU_URL"].ToString() + "\" >";
                        MenuHTML += drv["MENU_NAME"].ToString() + "</a>" + Environment.NewLine;
                    }
                    else
                    {
                        if (zz == 0)
                        {
                            MenuHTML += "<ul>" + Environment.NewLine;  //create dropdown for main tab in menu
                            parentID = Convert.ToInt16(drv["PARENT_ID"]);

                        }
                        if ((Convert.ToInt16(drv["PARENT_ID"]) != 0) && (Convert.ToInt16(drv["PARENT_ID"]) == parentID))
                        {
                            if (count == -1)    //in case their are  1st level submenu after 2nd level submenu for a given submenu for same parentID
                            {
                                if (count3Level == 3)
                                {
                                    MenuHTML += "</ul></li>" + Environment.NewLine;
                                    count3Level = 0;
                                }
                                MenuHTML += "</ul></li>" + Environment.NewLine;
                                count = 0;
                            }
                            else if (count >= 1) //close <a> tag for each submenu item 
                            {
                                MenuHTML += "</a></li>" + Environment.NewLine;
                                count = 0;
                            }
                            //MenuHTML += "<li><a href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString() + "</a>";
                            MenuHTML += "<li><a id='" + drv["MENU_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString();
                            zz = 1;
                            count++;
                        }
                        else
                        {

                            //generate 2nd level submenu
                            // MenuHTML += "</li>" + Environment.NewLine;
                            if (count >= 1)
                            {
                                MenuHTML += "<img src=\"" + "../Images/ar.png\" style=\"border-width:0px;vertical-align:middle\"  align=\"right\" alt=\"\"/></a>" + Environment.NewLine;
                                MenuHTML += "<ul>" + Environment.NewLine;
                                MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "' style =\"border-top:solid 1px #0f62ac;\">" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;

                                count = -1;
                            }
                            else
                            {
                                if (drv["MENU_URL"].ToString() == "#")
                                {
                                    //MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + drv["MENU_URL"].ToString() + "' >" + drv["MENU_NAME"].ToString() + "<img src=\"" + "/Images/arrow-right8.gif\" style=\"border-width:0px;vertical-align:middle\"  align=\"right\" alt=\"\"/></a>";
                                    MenuHTML += "<ul>" + Environment.NewLine;
                                    count3Level = 1;

                                }
                                else
                                {
                                    if (count3Level == 1)
                                    {
                                        MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "' style =\"border-top:solid 1px #0f62ac;\">" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;
                                        count3Level = 3;
                                    }
                                    else
                                    {
                                        MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;
                                    }
                                }

                            }
                        }
                    }
                }


                if (count >= 1)
                {
                    MenuHTML += "</a></li>";
                }
                //  MenuHTML += "</ul><li><a href='#'>Options</a>" + Environment.NewLine + "<ul><li><a href='../User/Change_Password.aspx'>Change Password</a></li>" + Environment.NewLine + "<li><a href='../Default.aspx'>Logout</a></li></ul></li>" + Environment.NewLine + "</ul>";

                MenuHTML = MenuHTML.Replace(BaseURL + "/#", "#"); //MenuHTML.Replace("/GCTS/#", "#");
                return MenuHTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RenderMenuPermissionsForClient(int userRecNo)
        {
            try
            {
                string MenuHTML = "";
                string BaseURL = "";

                DataSet ds = new DataSet();
                ds = dal.GetMenuDetailsForClient(userRecNo);

                DataView dv = new DataView(ds.Tables[0]);

                BaseURL = ConfigurationManager.AppSettings["BaseURL"].ToString();
                int i, zz = 0;

                MenuHTML += Environment.NewLine + "<ul id='nav' class='panel-heading'>" + Environment.NewLine;
                int val = 0;
                i = 0;

                MenuHTML += "<li> <a href='" + BaseURL + "/" + "ProjectManagement/Vendor_Profile.aspx'>Home</a></li>" + Environment.NewLine;
                int parentID = -1;
                ///int childParentID = -1;
                int count = 0;
                int count3Level = 0;
                foreach (DataRowView drv in dv)
                {
                    if (Convert.ToInt16(drv["PARENT_ID"]) == 0)
                    {
                        val = val + 1;
                        if (zz == 1)
                        {
                            if (count == -1)    //in case their are no 1st level submenu after 2nd level submenu for same parentID
                            {
                                if (count3Level == 3)
                                {
                                    MenuHTML += "</ul></li>" + Environment.NewLine;
                                    count3Level = 0;
                                }
                                MenuHTML += "</ul></li>" + Environment.NewLine;
                                MenuHTML += "</a></ul></li>";
                                count = 0;
                                zz = 0;
                            }
                            else
                            {
                                // MenuHTML += "</a></li></ul></li>";
                                MenuHTML += "</a></ul></li>";
                                zz = 0;
                                count = 0;
                            }
                        }
                        MenuHTML += Environment.NewLine + "<li>" + Environment.NewLine;
                        MenuHTML += "<a href=\"" + drv["MENU_URL"].ToString() + "\" >";
                        MenuHTML += drv["MENU_NAME"].ToString() + "</a>" + Environment.NewLine;
                    }
                    else
                    {
                        if (zz == 0)
                        {
                            MenuHTML += "<ul>" + Environment.NewLine;  //create dropdown for main tab in menu
                            parentID = Convert.ToInt16(drv["PARENT_ID"]);

                        }
                        if ((Convert.ToInt16(drv["PARENT_ID"]) != 0) && (Convert.ToInt16(drv["PARENT_ID"]) == parentID))
                        {
                            if (count == -1)    //in case their are  1st level submenu after 2nd level submenu for a given submenu for same parentID
                            {
                                if (count3Level == 3)
                                {
                                    MenuHTML += "</ul></li>" + Environment.NewLine;
                                    count3Level = 0;
                                }
                                MenuHTML += "</ul></li>" + Environment.NewLine;
                                count = 0;
                            }
                            else if (count >= 1) //close <a> tag for each submenu item 
                            {
                                MenuHTML += "</a></li>" + Environment.NewLine;
                                count = 0;
                            }
                            //MenuHTML += "<li><a href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString() + "</a>";
                            MenuHTML += "<li><a id='" + drv["MENU_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString();
                            zz = 1;
                            count++;
                        }
                        else
                        {

                            //generate 2nd level submenu
                            // MenuHTML += "</li>" + Environment.NewLine;
                            if (count >= 1)
                            {
                                MenuHTML += "<img src=\"" + "../Images/ar.png\" style=\"border-width:0px;vertical-align:middle\"  align=\"right\" alt=\"\"/></a>" + Environment.NewLine;
                                MenuHTML += "<ul>" + Environment.NewLine;
                                MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "' style =\"border-top:solid 1px #0f62ac;\">" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;

                                count = -1;
                            }
                            else
                            {
                                if (drv["MENU_URL"].ToString() == "#")
                                {
                                    MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + drv["MENU_URL"].ToString() + "' >" + drv["MENU_NAME"].ToString() + "<img src=\"" + "/Images/arrow-right8.gif\" style=\"border-width:0px;vertical-align:middle\"  align=\"right\" alt=\"\"/></a>";
                                    MenuHTML += "<ul>" + Environment.NewLine;
                                    count3Level = 1;

                                }
                                else
                                {
                                    if (count3Level == 1)
                                    {
                                        MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "' style =\"border-top:solid 1px #0f62ac;\">" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;
                                        count3Level = 3;
                                    }
                                    else
                                    {
                                        MenuHTML += "<li><a id='" + drv["PARENT_ID"].ToString() + "' href='" + BaseURL + "/" + drv["MENU_URL"].ToString() + "'>" + drv["MENU_NAME"].ToString() + "</a></li>" + Environment.NewLine;
                                    }
                                }

                            }
                        }
                    }
                }


                if (count >= 1)
                {
                    MenuHTML += "</a></li>";
                }
                //  MenuHTML += "</ul><li><a href='#'>Options</a>" + Environment.NewLine + "<ul><li><a href='../User/Change_Password.aspx'>Change Password</a></li>" + Environment.NewLine + "<li><a href='../Default.aspx'>Logout</a></li></ul></li>" + Environment.NewLine + "</ul>";

                MenuHTML = MenuHTML.Replace(BaseURL + "/#", "#"); //MenuHTML.Replace("/GCTS/#", "#");
                return MenuHTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllMenuItems()
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllMenuItems();
            return dt;
        }

        public DataTable GetMenuRightsForUser(int vsIntUserRecNo)
        {
            DataTable dt = new DataTable();
            dt = dal.GetMenuRightsForUser(vsIntUserRecNo);
            return dt;
        }

        public DataTable GetMenuRightsForUserRoleBased(int vsUserRoleRecNo)
        {
            DataTable dt = new DataTable();
            dt = dal.GetMenuRightsForUserRoleBased(vsUserRoleRecNo);
            return dt;
        }

        public int InsertMenuPermissionsForClient(int MenuID, int USER_REC_N, int EDITVIEW_RIGHTS)
        {
            DataTable dt = new DataTable();
            int Result = dal.InsertMenuPermissionsForClient(MenuID, USER_REC_N, EDITVIEW_RIGHTS);
            return Result;
        }

        public int DeleteMenuPermissions(int MenuID, int USER_REC_N, int EDITVIEW_RIGHTS)
        {
            DataTable dt = new DataTable();
            int Result = dal.DeleteMenuPermissions(MenuID, USER_REC_N, EDITVIEW_RIGHTS);
            return Result;
        }

        public DataTable GetAllUserRecNo(int vsIntRoleRecNo)
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllUserRecNo(vsIntRoleRecNo);
            return dt;
        }

        public int DeleteMenuPermissionsBasedonRole(int vsIntRoleRecNo)
        {
            int Result = dal.DeleteMenuPermissionsBasedonRole(vsIntRoleRecNo);
            return Result;
        }
    }
}
