using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls;
using DAL;

namespace BAL
{
   public class DivisionMasterBLL
    {
       DivisionMasterDLL odll = new DivisionMasterDLL();

       public int SaveUpdatedivisiondetails(int masterID, string divisionName, int activestatus, string createdBy)
       {
           return odll.SaveUpdatedivisiondetails( masterID,  divisionName,  activestatus,  createdBy);
       }

       public DataSet BindGrid()
       {
           return odll.BindGrid();
       }

       public DataSet GetEditDetails(int divisionrecno)
       {
           return odll.GetEditDetails(divisionrecno);
       }
    }
}
