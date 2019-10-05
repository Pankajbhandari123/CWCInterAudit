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
    public class InitiativeManagementBLL
    {
        InitiativeManagementDLL odll = new InitiativeManagementDLL();
        public DataSet BindDivision(int UserRecno)
        {
            return odll.BindDivision(UserRecno);
        }

        public DataSet BindRegion()
        {
            return odll.BindRegion();
        }

        public DataSet BindScheme()
        {
            return odll.BindScheme();
        }

        public DataSet BindUnit()
        {
            return odll.BindUnit();
        }

        public DataSet BindGrid(int masterId, int Office_Type)
        {
            return odll.BindGrid(masterId, Office_Type);
        }

        public int SaveUpdateInitiveManagement(string InitiativeName, int officeType, int divisionRecno, int schemeRecno, int unitRecno, int masterID, int activestatus, string createdBy,string unitname, string parameterName, int parametervalue)
        {
            return odll.SaveUpdateInitiveManagement(InitiativeName, officeType, divisionRecno, schemeRecno, unitRecno, masterID, activestatus, createdBy,  unitname,  parameterName,  parametervalue);
        }
    }
}
