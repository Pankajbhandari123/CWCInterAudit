using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DAL
{
    public class MenuDLL
    {
        SqlHelper sql = new SqlHelper();



        public int GetPermissions(int menuID, int userRecNo)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_USER_RECNO",userRecNo),
                                       new MySqlParameter("@P_MENU_ID",menuID) 
                                      };

            int result = sql.execStoredProcudure("SIDCO_PROC_PERMISSIONS_GET", spmLogin);
            return result;

        }

        public DataSet GetUserInfo(string Name, string loginName, string password)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_NAME",Name),
                                       new MySqlParameter("@P_USERNAME",loginName),
                                        new MySqlParameter("@P_PASSWORD",password) 
                                      };

            DataSet ds = sql.getDataSet("SIDCO_PROC_AUTHENTICATED_GET_USER", spmLogin, "");
            return ds;
        }


        public DataSet GetMenuDetails(int userRecNo)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("p_P_USER_RECNO",userRecNo) 
                                       };
            DataSet ds = sql.getDataSet("SIDCO_PROC_MENU_GET_DETAILS", spmLogin, "");
            return ds;
        }


        public DataSet GetMenuDetailsForClient(int userRecNo)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_USER_RECNO",userRecNo) 
                                       };
            DataSet ds = sql.getDataSet("SIDCO_PROC_MENU_GET_DETAILS_FOR_CLIENT", spmLogin, "");
            return ds;
        }

        public DataTable GetAllMenuItems(int Role_recno)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_Role_recno",Role_recno)
                                       };
            DataTable ds = sql.getDataTable("SIDCO_PROC_MENU_ITEMS_GET_ALL", spmLogin, "");
            return ds;

        }

        public DataTable GetMenuRightsForUser(int UserRecno, int Role_recno)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_USER_REC_NO",UserRecno),
                                        new MySqlParameter("@P_Role_recno",Role_recno)
                                       };
            DataTable ds = sql.getDataTable("SIDCO_PROC_MENU_RIGHTS_GETBY_USER", spmLogin, "");
            return ds;

        }

        public DataTable GetMenuRightsForUserRoleBased(int RoleRecno)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("@P_ROLE_RECNO",RoleRecno)
                                                                              };
            DataTable ds = sql.getDataTable("SIDCO_PROC_MENU_RIGHTS_GETBY_USER_ROLE", spmLogin, "");
            return ds;

        }

        public int InsertMenuPermissionsForClient(int ID, int userRecno, int EditView, int Role_recno)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_MENU_ID",ID),
                                             new MySqlParameter("P_USER_REC_NO",userRecno),
                                             new MySqlParameter("P_EDITVIEW_RIGHTS",EditView),
                                             new MySqlParameter("P_Role_recno",Role_recno)                                            
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_MENU_PERMISSION_INSERT1", spmLogin);
            return result;

        }

        public int DeleteMenuPermissions(int ID, int userRecno, int EditView, int Role_Recno)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_MENU_ID",ID),
                                             new MySqlParameter("P_USER_REC_NO",userRecno),                                             
                                             new MySqlParameter("P_Role_recno",Role_Recno)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_MENU_PERMISSION_DELETE", spmLogin);
            return result;

        }

        public DataTable GetAllUserRecNo(int vsIntRoleRecNo)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_ROLE_RECNO",vsIntRoleRecNo)
                                             
                                       };
            DataTable ds = sql.getDataTable("SIDCO_PROC_USER_GET_BY_ROLE_REC_NO", spmLogin, "");
            return ds;

        }

        public int DeleteMenuPermissionsBasedonRole(int vsIntRoleRecNo)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_ROLE_RECNO",vsIntRoleRecNo)                                            
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_MENU_PERMISSION_DELETE_BASED_ROLE", spmLogin);
            return result;

        }

        public int InsertUserRecNoRolePermission(int MenuID, int RoleRecno, int EditView)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_MENU_ID",MenuID),
                                             new MySqlParameter("P_RoleRecno",RoleRecno),
                                             new MySqlParameter("P_EDITVIEW_RIGHTS",EditView)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_USER_INSERT_ROLE_DETAILS", spmLogin);
            return result;

        }

        public int DeleteMenuRolePermissions(int RolRecno, int MenuID)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_ROLE_RECNO",RolRecno),
                                             new MySqlParameter("P_MENU_ID",MenuID)                                             
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_MENU_ROLE_PERMISSION_DELETE", spmLogin);
            return result;

        }

        public int InsertMenuRolePermissions(int UserRecno, int MenuID, int EditView, int Role_Recno)
        {
            MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_USER_REC_NO",UserRecno),
                                             new MySqlParameter("P_MENU_ID",MenuID),
                                              new MySqlParameter("P_EDITVIEW_RIGHTS",EditView),
                                             new MySqlParameter("P_Role_Recno",Role_Recno)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_MENU_PERMISSION_INSERT_ROLE", spmLogin);
            return result;

        }

        public int InsertMenuPermissionsForClient(int MenuID, int USER_REC_N, int EDITVIEW_RIGHTS)
        {
            throw new NotImplementedException();
        }

        public int DeleteMenuPermissions(int MenuID, int USER_REC_N, int EDITVIEW_RIGHTS)
        {
            throw new NotImplementedException();
        }

        public DataTable GetMenuRightsForUser(int vsIntUserRecNo)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllMenuItems()
        {
            throw new NotImplementedException();
        }
    }
}
