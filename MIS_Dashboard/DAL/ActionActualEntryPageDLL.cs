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
  public  class ActionActualEntryPageDLL
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



        public DataSet BindGridForEditDetails(int masterid, string recordDate)
        {
            DateTime record = Convert.ToDateTime(recordDate);
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_MASTER_ID",masterid),
                                            new MySqlParameter("P_RECORD_ENTRY_DATE",recordDate)
                                        };
            DataSet result = sql.getDataSet("PROC_BIND_ACTION_ACTUAL_GRID_FOR_EDIT", spmLogin, "");
            return result;
        }

        public DataSet BindUnit()
        {
            MySqlParameter[] spmLogin = {
                                            
                                        };
            DataSet result = sql.getDataSet("PROC_DDL_UNIT", spmLogin, "");
            return result;
        }

        //public int SaveUpdateDetails(int masterid, string recorddate, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno,
        //    string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string august,
        //    string firstYear, string secondYear, string thirdYear, string fourthYear, string fifthYear, string parameterRemarks, string hundredDyasRemarks,
        //    string augustRemarks, string firstYearRemarks, string secondYearRemarks, string thirdYearRemarks, string fourthYearRemarks,
        //               string fifthYearRemarks, string createdBy)
        //{
        //    MySqlParameter[] spmLogin = {
        //                                    new MySqlParameter("P_MASTER_ID",masterid),
        //                                    new MySqlParameter("P_RECORD_ENTRY_DATE",recorddate),
        //                                     new MySqlParameter("P_DIVISION_REGION_RECNO",divisionRegionRecno),
        //                                     new MySqlParameter("P_OFFICE_TYPE",officetype),
        //                                     new MySqlParameter("P_DIVISION_REGION_NAME",divisionRegionName),
        //                                     new MySqlParameter("P_INITIATIVE_RECNO",initiativerecno),
        //                                     new MySqlParameter("P_INITIATIVE",initiativeName),
        //                                     new MySqlParameter("P_SCHEME",scheme),
        //                                     new MySqlParameter("P_REQUIRE_CHANGES",requireChnages),
        //                                     new MySqlParameter("P_REQUIRE_CHANGES_REMARKS",requirechangesRemarks),
        //                                     new MySqlParameter("P_PARAMETER",parameter),
        //                                     new MySqlParameter("P_UNIT_NAME",unitname),
        //                                     new MySqlParameter("P_100_days",hundredDyas),
        //                                     new MySqlParameter("P_15_august",august),
        //                                     new MySqlParameter("P_1_Year",firstYear),
        //                                     new MySqlParameter("P_2_Year",secondYear),
        //                                     new MySqlParameter("P_3_Year",thirdYear),
        //                                     new MySqlParameter("P_4_Year",fourthYear),
        //                                     new MySqlParameter("P_5_Year",fifthYear),
        //                                     new MySqlParameter("P_PARAMETER_REMARKS",parameterRemarks),
        //                                     new MySqlParameter("P_100DAYS_REMARKS",hundredDyasRemarks),
        //                                     new MySqlParameter("P_15AUGUST_REMARKS",augustRemarks),
        //                                     new MySqlParameter("P_1YEAR_REMARKS",firstYearRemarks),
        //                                     new MySqlParameter("P_2YEAR_REMARKS",secondYearRemarks),
        //                                     new MySqlParameter("P_3YEAR_REMARKS",thirdYearRemarks),
        //                                     new MySqlParameter("P_4YEAR_REMARKS",fourthYearRemarks),
        //                                     new MySqlParameter("P_5YEAR_REMARKS",fifthYearRemarks),
        //                                     new MySqlParameter("P_CREATED_BY",createdBy)
        //                                };
        //    int result = sql.execStoredProcudure("PROC_SAVE_UPDATE_ACTUAL_DETAILS", spmLogin);
        //    return result;
        //}

        public int SaveUpdateDetails(int masterid, string recorddate, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno, string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string parameterRemarks, string hundredDyasRemarks, string kpirecno, string createdBy, string CompletedStatus)
        {
             MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_MASTER_ID",masterid),
                                            new MySqlParameter("P_RECORD_ENTRY_DATE",recorddate),
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
                                             new MySqlParameter("P_PARAMETER_REMARKS",parameterRemarks),
                                             new MySqlParameter("P_100DAYS_REMARKS",hundredDyasRemarks),
                                             new MySqlParameter("P_COMPLETED_STATUS",CompletedStatus),
                                              new MySqlParameter("P_KPI_RECNO",kpirecno),
                                             new MySqlParameter("P_CREATED_BY",createdBy)
                                        };
             int result = sql.execStoredProcudure("PROC_SAVE_UPDATE_ACTUAL_DETAILS", spmLogin);
             return result;
        }


        public DataSet GetBindGridData(int ID, string recordDate, string kpi)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_ID",ID),
                                            new MySqlParameter("P_RECORD_ENTRY_DATE",recordDate),
                                             new MySqlParameter("P_KPI_RECNO",kpi)
                                        };
            DataSet result = sql.getDataSet("PROC_GET_BIND_GRID_FOR_ACTUALDATA_FOR_ONKPIBASIS", spmLogin, "");
            return result;
        }

        public DataSet BindFirstKPI()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_KPI_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindGridForEditDetailsPgaeActual(int masterid, string recordDate, int kpiid)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_MASTER_ID",masterid),
                                            new MySqlParameter("P_RECORD_ENTRY_DATE",recordDate),
                                            new MySqlParameter("P_KPI_RECNO",kpiid)
                                        };
            DataSet result = sql.getDataSet("PROC_BIND_ACTUAL_GRID_FOR_ONKPIBASIS", spmLogin, "");
            return result;
        }
       
    }
}
