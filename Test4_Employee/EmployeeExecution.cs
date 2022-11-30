using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4_Employee
{
    public class EmployeeExecution
    {
        EditEmployee objEditEmployee = new EditEmployee();
        EmployeeConsoleEntry objConsoleEntry = new EmployeeConsoleEntry();
        public void EmployeeMainMethod()
        {
            try
            {
                //Adding Record by Using List
                EmployeeListEntry objEmpList =new EmployeeListEntry();
                string resultDept= objEmpList.InsertEmployeeDataIntoDB();
                Console.WriteLine(resultDept);
                Console.WriteLine("-----------------------------");

                //Creating New List by selecting values from database
                string result= objEmpList.SelectEmployeeDataToNewList();
                Console.WriteLine(result);
                Console.WriteLine("-----------------------------");

                //Showing New List which is added by Database
                objEmpList.DisplayNewList();
                Console.WriteLine("-----------------------------");

                //Employee Delete and Update
                EditEmployee objeditemp = new EditEmployee();
                objeditemp.UpdateEmployeeData();
                objeditemp.DeleteEmployeeData();
                Console.WriteLine("-----------------------------");

                //Enter Employee Record By Console To List And Adding into Database
                Console.WriteLine("Inserting Employee Record by Console");
                EmployeeConsoleEntry objEmpconsole = new EmployeeConsoleEntry();
                string resultConsole= objConsoleEntry.InsertEmployeeConsoleRecord();
                Console.WriteLine(resultConsole);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

}
