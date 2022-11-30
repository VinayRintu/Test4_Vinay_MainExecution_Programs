using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4_Department
{
    public class DepartmentExecution
    {
        public void DepartmentMainMethod()
        {
            try
            {
                //Adding Record by Using List
                DepartmentListEntry objDeptList=new DepartmentListEntry();
                string resultInsert= objDeptList.InsertDepartmentDataIntoDB();
                Console.WriteLine(resultInsert); 
                Console.WriteLine("-----------------------------");

                //Creating New List by selecting values from database
                string resultSelect= objDeptList.SelectDepartmentDataToNewList();
                Console.WriteLine(resultSelect); 
                Console.WriteLine("-----------------------------");

                //Showing New List which is added by Database
                objDeptList.DisplayNewList();
                Console.WriteLine("-----------------------------");

                //Department Edit And Delete
                EditDepartment objDeptEdit = new EditDepartment();
                objDeptEdit.UpdateDepartmentData();
                objDeptEdit.DeleteEmployeeData();
                Console.WriteLine("-----------------------------");

                //Enter Department Record By Console To List And Adding into Database
                Console.WriteLine("Inserting Department Record by Console");
                DepartmentConsoleEntry objDeptConsole = new DepartmentConsoleEntry();
                string resultListDB= objDeptConsole.InsertDeptListRecordToDB();
                Console.WriteLine(resultListDB);  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
