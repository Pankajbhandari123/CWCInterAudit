using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDAL
    {
        SqlHelper sql = new SqlHelper();
        DataSet ds = new DataSet();
        MenuDLL oMenuDetails = new MenuDLL();

        public int InsertUserActivityDetails(string strlastActivity, string LoginName)
        {

            MySqlParameter[] spmLogin ={new MySqlParameter("P_LAST_ACTIVITY",strlastActivity),
                                       new MySqlParameter("P_LOGIN_NAME",LoginName)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_UPDATE_USER_LAST_ACTIVITY", spmLogin);
            return result;
        }

        public DataSet BindAllUsers(string condtion, Int32 user_recno)
        {
            MySqlParameter[] spmLogin = { new MySqlParameter("P_CONDITION", condtion),
                                          new MySqlParameter("P_USER_RECNO", user_recno)
                                         };
            ds = sql.getDataSet("SIDCO_PROC_GET_USER_DETAILS", spmLogin, "");
            return ds;
        }

        //public int GetPermissions(int menuID, int userRecNo)
        //{
        //    MySqlParameter[] spmLogin ={new MySqlParameter("P_USER_RECNO",menuID),
        //                               new MySqlParameter("P_MENU_ID",userRecNo)
        //                               };
        //    int result = sql.execStoredProcudure("SIDCO_PROC_PERMISSIONS_GET", spmLogin);
        //    return result;

        //}

        public int DeleteUserDetails(int USER_RECNO, string MODIFIED_BY)
        {
            try
            {
                MySqlParameter[] spmLogin ={new MySqlParameter("P_USER_RECNO",USER_RECNO),
                                       new MySqlParameter("P_MODIFIED_BY",MODIFIED_BY)
                                       };
                int result = sql.execStoredProcudure("SIDCO_PROC_DELETE_USER_DETAILS", spmLogin);
                return result;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        //public DataSet GetSIDCODistrict()
        //{
        //    MySqlParameter[] spmLogin = {  };
        //    ds = sql.getDataSet("SIDCO_GET_DISTRICT_DETAILS", spmLogin, "");
        //    return ds;

        //}

        public DataSet GetAllRole()
        {
            MySqlParameter[] spmLogin = { };
            ds = sql.getDataSet("SIDCO_PROC_GET_ROLE_ALL", spmLogin, "");
            return ds;

        }

        public int InsertUserdetails(string LOGIN_NAME, string DISPLAY_NAME, string CONTACT_NO, string EMAILID, DateTime PASSWORD_EXPIRYDATE, decimal ROLE_RECNO, int ACTIVE_STATUS, string PASSWORD, string CHANGE_PASSWORD, string LOCKED, string CREATED_BY, int divisionrecno)
        {
            try
            {
                MySqlParameter[] spmLogin ={
                                            
                                             new MySqlParameter("P_LOGIN_NAME",LOGIN_NAME),
                                             new MySqlParameter("P_DISPLAY_NAME",DISPLAY_NAME),
                                             new MySqlParameter("P_CONTACT_NO",CONTACT_NO),
                                             new MySqlParameter("P_EMAILID",EMAILID),
                                             new MySqlParameter("P_EXPIRYDATE",PASSWORD_EXPIRYDATE),
                                             new MySqlParameter("P_ROLE_RECNO",ROLE_RECNO),
                                             new MySqlParameter("P_ACTIVE_STATUS",ACTIVE_STATUS),
                                             new MySqlParameter("P_PASSWORD",PASSWORD),
                                             new MySqlParameter("P_CHANGE_PASSWORD",CHANGE_PASSWORD),
                                             new MySqlParameter("P_LOCKED",LOCKED),
                                             new MySqlParameter("P_CREATED_BY",CREATED_BY),
                                             new MySqlParameter("P_DIVISION_RECNO", divisionrecno)
                                       };
                int result = sql.execStoredProcudure("SIDCO_PROC_INSERT_USER_DETAILS", spmLogin);
                return result;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public int UpdateUserdetails(int vsIntUserRecNo, string LOGIN_NAME, string DISPLAY_NAME, string CONTACT_NO, string EMAILID, DateTime PASSWORD_EXPIRYDATE, decimal ROLE_RECNO, int ACTIVE_STATUS, string PASSWORD, char CHANGE_PASSWORD, char LOCKED, string CREATED_BY, int divisionrecno)
        {
            try
            {
                MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_USER_RECNO",vsIntUserRecNo),
                                            
                                             new MySqlParameter("P_LOGIN_NAME",LOGIN_NAME),
                                             new MySqlParameter("P_DISPLAY_NAME",DISPLAY_NAME),
                                             new MySqlParameter("P_CONTACT_NO",CONTACT_NO),
                                             new MySqlParameter("P_EMAILID",EMAILID),
                                             new MySqlParameter("P_EXPIRYDATE",PASSWORD_EXPIRYDATE),
                                             new MySqlParameter("P_ROLE_RECNO",ROLE_RECNO),
                                             new MySqlParameter("P_ACTIVE_STATUS",ACTIVE_STATUS),
                                             new MySqlParameter("P_PASSWORD",PASSWORD),
                                             new MySqlParameter("P_CHANGE_PASSWORD",CHANGE_PASSWORD),
                                             new MySqlParameter("P_LOCKED",LOCKED),
                                             new MySqlParameter("P_CREATED_BY",CREATED_BY),
                                             new MySqlParameter("P_DIVISION_RECNO", divisionrecno)
                                       };
                int result = sql.execStoredProcudure("SIDCO_PROC_USER_DETAILS_UPDATE", spmLogin);
                return result;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public DataSet GetSIDCOIIE(int Dist_recno)
        {
            MySqlParameter[] spmLogin = { new MySqlParameter("P_District_Recno", Dist_recno) };
            ds = sql.getDataSet("SIDCO_GET_INDUSTRIAL_ESTATE_DETAILS", spmLogin, "");
            return ds;

        }

        public DataSet DisplayUserDetails(int userRecNo)
        {
            ds = null;
            try
            {
                MySqlParameter[] spmLogin = { new MySqlParameter("P_USER_RECNO", userRecNo) };
                ds = sql.getDataSet("SIDCO_PROC_GET_USER_BY_REC_NO", spmLogin, "");
                return ds;
            }
            catch (Exception ex)
            {

                return ds;
            }
        }

        public DataSet GetROLETYPE()
        {
            MySqlParameter[] spmLogin = { };
            ds = sql.getDataSet("SIDCO_PROC_GET_ROLE_TYPE_DETAILS", spmLogin, "");
            return ds;

        }

        public DataSet GetroleDetails()
        {
            MySqlParameter[] spmLogin = { };
            DataSet ds = sql.getDataSet("SIDCO_PROC_GET_ROLE_DETAILS", spmLogin, "");
            return ds;

        }

        public int insertRole(string ROLE_NAME, string Roletype, string createdby)
        {
            try
            {
                MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_ROLE_NAME",ROLE_NAME),
                                             new MySqlParameter("P_ROLE_USER_TYPE",Roletype),   
                                                 new MySqlParameter("P_CREATED_BY",createdby) 
                                       };
                int result = sql.execStoredProcudure("SIDCO_PROC_INSERT_ROLE_DETAILS", spmLogin);
                return result;

            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public int updaterole(int Role_recno, string ROLE_NAME, string Roletype, string modifiedby)
        {
            try
            {
                MySqlParameter[] spmLogin ={
                                             new MySqlParameter("P_Role",Role_recno),
                                             new MySqlParameter("P_ROLE_NAME",ROLE_NAME),
                                             new MySqlParameter("P_ROLE_USER_TYPE",Roletype),
                                               new MySqlParameter("P_MODIFIED_BY",modifiedby)
                                       };
                int result = sql.execStoredProcudure("SIDCO_PROC_UPDATE_ROLE_TYPE_DETAILS", spmLogin);
                return result;

            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public DataSet GetRole(int Role_Recno)
        {
            MySqlParameter[] spmLogin = { new MySqlParameter("P_Role", Role_Recno) };
            DataSet ds = sql.getDataSet("SIDCO_PROC_EDIT_ROLE_TYPE_DETAILS", spmLogin, "");
            return ds;

        }

        public DataSet GetUserInfo(string Name, string loginName, string password)
        {
            MySqlParameter[] spmLogin = {
                                         new MySqlParameter("P_NAME", Name),
                                         new MySqlParameter("P_USERNAME", loginName),
                                         new MySqlParameter("P_PASSWORD", password)
                                         };
            DataSet ds = sql.getDataSet("SIDCO_PROC_AUTHENTICATED_GET_USER", spmLogin, "");
            return ds;

        }




        public int GetPermissions(int pageID, int User_Recno)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("P_USER_RECNO",User_Recno),
                                       new MySqlParameter("P_MENU_ID",pageID)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_PERMISSIONS_GET", spmLogin);
            return result;
        }

        public int UpdatePassword(int userRecno, string oldpassword, string newpassword, string changepassword, string createdBy)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("P_USER_RECNO",userRecno),
                                           new MySqlParameter("P_OLD_PASSWORD",oldpassword),
                                       new MySqlParameter("P_NEW_PASSWORD",newpassword),
                                        new MySqlParameter("P_CHANGE_PASSWORD",changepassword),
                                        new MySqlParameter("P_CREATED_BY",createdBy)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_CHANGE_USER_PASSWORD", spmLogin);
            return result;
        }

        public DataSet GetEmailId(int p)
        {
            MySqlParameter[] spmLogin ={new MySqlParameter("P_USER_RECNO",p)
                                       };
            DataSet result = sql.getDataSet("SIDCO_PROC_GET_EMAIL_ID", spmLogin, "");
            return result;
        }

        public System.Data.DataSet Get_Chart_Details_For_Permission()
        {
            MySqlParameter[] spmLogin ={
                                           //new MySqlParameter("P_USER_RECNO",p)
                                       };
            DataSet result = sql.getDataSet("SIDCO_PROC_CHART_GET_DETAILS_FOR_PERMISSION", spmLogin, "");
            return result;
        }

        public System.Data.DataSet Get_Chart_Permission_Details(int RoleRecNo)
        {
            MySqlParameter[] spmLogin ={
                                           new MySqlParameter("P_Role_RecNo",RoleRecNo)
                                       };
            DataSet result = sql.getDataSet("SIDCO_PROC_CHART_GET_PERMISSIONS", spmLogin, "");
            return result;
        }

        public int Insert_Chart_Permission(int chart_recno, int editright, int RoleRecNo)
        {
            MySqlParameter[] spmLogin ={
                                           new MySqlParameter("P_CHART_ID",chart_recno),
                                           new MySqlParameter("P_EDITVIEW_RIGHTS",editright),
                                           new MySqlParameter("P_Role_Recno",RoleRecNo)
                                       };
            int result = sql.execStoredProcudure("SIDCO_PROC_INSERT_CHART_PERMISSION_DETAILS", spmLogin);
            return result;
        }

        public DataSet GetForgetPasswordUserInfo(string Name, string username)
        {
            MySqlParameter[] spmLogin ={
                                           new MySqlParameter("P_NAME",Name),
                                           new MySqlParameter("P_USERNAME",username)
                                       };
            DataSet result = sql.getDataSet("PROC_GET_USERDETAILS_FOR_FORGET_PAGE", spmLogin, "");
            return result;
        }

        public object BindDivision()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_DIVISION_DROPDOWN", sqlPrm, "");
        }
    }
}
