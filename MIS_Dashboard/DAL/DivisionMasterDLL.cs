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
  public  class DivisionMasterDLL
    {
        SqlHelper sql = new SqlHelper();
        DataSet ds = new DataSet();

        public int SaveUpdatedivisiondetails(int masterID, string divisionName, int activestatus, string createdBy)
        {
            MySqlParameter[] spmLogin = { new MySqlParameter("P_MASTER_ID", masterID),
                                          new MySqlParameter("P_DIVISION_NAME", divisionName),
                                          new MySqlParameter("P_ACTIVE_STATUS", activestatus),
                                          new MySqlParameter("P_CREATED_BY", createdBy)
                                          
                                        };

            int result = sql.execStoredProcudure("PROC_INSERT_UPDATE_DIVISION_MASTER", spmLogin);
            return result;
        }

        public DataSet BindGrid()
        {
            MySqlParameter[] spmLogin = {

                                        };
            DataSet result = sql.getDataSet("PROC_BIND_DIVISION_GRID", spmLogin, "");
            return result;
        }

        public DataSet GetEditDetails(int divisionrecno)
        {
            MySqlParameter[] spmLogin = {
                                            new MySqlParameter("P_DIVISION_RECNO",divisionrecno)
                                        };
            DataSet result = sql.getDataSet("PROC_EDIT_DIVISION_DETAILS", spmLogin, "");
            return result;
        }
    }
}
