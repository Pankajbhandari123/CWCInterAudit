using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BAL
{
    public class UnitMasterBLL
    {
        UnitMasterDLL dll = new UnitMasterDLL();

        public DataSet BindGrid(int masterId)
        {
            return dll.BindGrid(masterId);
        }

        public int SaveUpdateScheme(int activeStatus, string createdBy, string unitName, int masterID)
        {
            return dll.SaveUpdateScheme(activeStatus, createdBy, unitName, masterID);
        }
    }
}
