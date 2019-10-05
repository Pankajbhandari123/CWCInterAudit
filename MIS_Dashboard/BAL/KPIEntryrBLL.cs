using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using DAL;

namespace BAL
{
    public class KPIEntryrBLL
    {
        KPIEntryrDLL odll = new KPIEntryrDLL();
        public DataSet BindDivision()
        {
            return odll.BindDivision();
        }

        public DataSet BindRegion()
        {
            return odll.BindRegion();
        }

        public DataSet BindGrid(int masterId, int Office_Type)
        {
            return odll.BindGrid(masterId, Office_Type);
        }

        public int SaveUpdateKPIDetails(int masterId, string kpiName, int DivisionRegionRecno, int OfficeStatus, int activestatus, string createdBy)
        {
            return odll.SaveUpdateKPIDetails(masterId, kpiName, DivisionRegionRecno, OfficeStatus, activestatus, createdBy);
        }

        public DataSet BindGrid()
        {
            return odll.BindGrid();
        }

        public DataSet BindData()
        {
            DataSet ds = new DataSet();
            ds=odll.BindData();
            return ds;
        }
    }
}
