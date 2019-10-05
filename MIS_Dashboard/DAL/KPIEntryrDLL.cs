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
    public class KPIEntryrDLL
    {
        SqlHelper sql = new SqlHelper();
        public DataSet BindDivision()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_DIVISION_DROPDOWN", sqlPrm, "");
        }

        public DataSet BindRegion()
        {
            MySqlParameter[] sqlPrm = { };
            return sql.getDataSet("PROC_BIND_REGION_DROPDOWN", sqlPrm, "");
        }
        public DataSet BindGrid(int masterId, int Office_Type)
        {
            MySqlParameter[] sqlPrm = {
                                      new MySqlParameter("Master_Id",masterId),
                                      new MySqlParameter("Office_Type",Office_Type)
                                      };
            return sql.getDataSet("PROC_BIND_KPI_DETAILS", sqlPrm, "");
        }


        public int SaveUpdateKPIDetails(int masterId, string kpiName, int DivisionRegionRecno, int OfficeStatus, int activestatus, string createdBy)
        {
            MySqlParameter[] sqlPrm ={
                                        new MySqlParameter("Master_Id",masterId),
                                        new MySqlParameter("KpiName",kpiName),
                                        new MySqlParameter("DivisionRegionRecno",DivisionRegionRecno),
                                        new MySqlParameter("OfficeStatus",OfficeStatus),
                                        new MySqlParameter("ActiveStatus",activestatus),
                                        new MySqlParameter("CreatedBy",createdBy),
                                    };
            return sql.execStoredProcudure("PROC_SAVE_UPDATE_KPI_DETAILS", sqlPrm);
        }

        public DataSet BindGrid()
        {
            MySqlParameter[] spmLogin = {

                                        };
            DataSet result = sql.getDataSet("PROC_BIND_KPI_DETAILS12", spmLogin, "");
            return result;
        }

        public DataSet BindData()
        {
            MySqlParameter[] sL = {
                                    };
            DataSet result = sql.getDataSet("PROC_BIND_KPI_DETAILS12", sL,"");
            return result;
        }
    }
}
