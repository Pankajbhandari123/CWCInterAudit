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
    public class InitiativeManagementDLL
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

        public DataSet BindScheme()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_SCHEME_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindUnit()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_UNIT_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindGrid(int masterId, int Office_Type)
        {
            MySqlParameter[] sqlPrm = {
                                      new MySqlParameter("Master_Id",masterId),
                                      new MySqlParameter("Office_Type",Office_Type)
                                      };
            return sql.getDataSet("PROC_BIND_INITIATIVE_MANAGEMENT", sqlPrm, "");
        }

        public int SaveUpdateInitiveManagement(string InitiativeName, int officeType, int divisionRecno, int schemeRecno, int unitRecno, int masterID, int activestatus, string createdBy, string unitname, string parameterName, int parametervalue)
        {
            MySqlParameter[] sqlPrm = {
                                      new MySqlParameter("OfficeType",officeType),
                                      new MySqlParameter("DivisionRegionRecno",divisionRecno) ,
                                      new MySqlParameter("SchemeRecno",schemeRecno)         ,
                                      new MySqlParameter("UnitRecno",unitRecno)           ,
                                      new MySqlParameter("PInitiative",InitiativeName)         ,
                                      new MySqlParameter("ActiveStatus",activestatus)        ,
                                      new MySqlParameter("MasterId",masterID)            ,
                                      new MySqlParameter("CreatedBy",createdBy)   ,
                                      new MySqlParameter("P_Unit",unitname)        ,
                                      new MySqlParameter("P_Parameter",parameterName)            ,
                                      new MySqlParameter("P_Parameter_Status",parametervalue)      
                                      };
            return sql.execStoredProcudure("PROC_SAVE_UPDATE_INITIATIVE_DETAILS", sqlPrm);
        }
    }
}
