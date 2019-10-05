using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
  public  class ActionPlannedEntryDLL
    {
      SqlHelper sql = new SqlHelper();
      public DataSet BindDivision(int UserRecno)
        {
            MySqlParameter[] sqlPrm = { 
                                          new MySqlParameter("P_USER_RECNO",UserRecno)
                                      };
            return sql.getDataSet("PROC_BIND_DIVISION_DROPDOWN_ONUSERBASIS", sqlPrm, "");
        }

        public DataSet BindRegion()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_REGION_DROPDOWN", sqlPrm, "");
        }



        public DataSet BindGridForEditDetails(int masterid)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_MASTER_ID",masterid)
                                        };
            DataSet result = sql.getDataSet("PROC_BIND_ACTION_PLANNED_GRID_FOR_EDIT", spmLogin, "");
            return result;
        }

        public DataSet BindUnit()
        {
            MySqlParameter[] spmLogin = {
                                            
                                        };
            DataSet result = sql.getDataSet("PROC_DDL_UNIT", spmLogin, "");
            return result;
        }

        public int SaveUpdateDetails(int masterid, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno, 
            string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string august,
            string firstYear, string secondYear, string thirdYear, string fourthYear, string fifthYear, string parameterRemarks, string hundredDyasRemarks, 
            string augustRemarks, string firstYearRemarks, string secondYearRemarks, string thirdYearRemarks, string fourthYearRemarks,
                       string fifthYearRemarks, string createdBy)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_MASTER_ID",masterid),
                                             new MySqlParameter("P_DIVISION_REGION_RECNO",divisionRegionRecno),
                                             new MySqlParameter("P_OFFICE_TYPE",officetype),
                                             new MySqlParameter("P_DIVISION_REGION_NAME",divisionRegionName),
                                             new MySqlParameter("P_INITIATIVE_RECNO",initiativerecno),
                                             new MySqlParameter("P_INITIATIVE",initiativeName),
                                             new MySqlParameter("P_SCHEME",scheme),
                                             new MySqlParameter("P_REQUIRE_CHANGES",requireChnages),
                                             new MySqlParameter("P_REQUIRE_CHANGES_REMARKS",requirechangesRemarks),
                                             new MySqlParameter("P_PARAMETER",parameter),
                                             new MySqlParameter("P_UNIT_NAME",unitname),
                                             new MySqlParameter("P_100_days",hundredDyas),
                                             new MySqlParameter("P_15_august",august),
                                             new MySqlParameter("P_1_Year",firstYear),
                                             new MySqlParameter("P_2_Year",secondYear),
                                             new MySqlParameter("P_3_Year",thirdYear),
                                             new MySqlParameter("P_4_Year",fourthYear),
                                             new MySqlParameter("P_5_Year",fifthYear),
                                             new MySqlParameter("P_PARAMETER_REMARKS",parameterRemarks),
                                             new MySqlParameter("P_100DAYS_REMARKS",hundredDyasRemarks),
                                             new MySqlParameter("P_15AUGUST_REMARKS",augustRemarks),
                                             new MySqlParameter("P_1YEAR_REMARKS",firstYearRemarks),
                                             new MySqlParameter("P_2YEAR_REMARKS",secondYearRemarks),
                                             new MySqlParameter("P_3YEAR_REMARKS",thirdYearRemarks),
                                             new MySqlParameter("P_4YEAR_REMARKS",fourthYearRemarks),
                                             new MySqlParameter("P_5YEAR_REMARKS",fifthYearRemarks),
                                             new MySqlParameter("P_CREATED_BY",createdBy)
                                        };
            int result = sql.execStoredProcudure("PROC_SAVE_UPDATE_PLANNED_DETAILS", spmLogin);
            return result;
        }

        public DataSet GetBindGridData(int ID)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_ID",ID)
                                        };
            DataSet result = sql.getDataSet("PROC_GET_BIND_GRID_FOR_PLANNEDDATA", spmLogin, "");
            return result;
        }
    }
}
