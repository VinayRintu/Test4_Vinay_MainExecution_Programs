using DBConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4_Employee
{
    public class EmployeeConsoleEntry:EmployeeProperties
    {
        string cnstr="";
        SqlConnection con;       

        public EmployeeConsoleEntry()
        {
            try
            {
                cnstr = DBConnections.conStr;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private SqlConnection DBconnection()
        {
            con= new SqlConnection(cnstr);
            return con;
        }
        public List<EmployeeConsoleEntry> AddEmployeeByConsole()
        {
            bool isDataInserted = true;
            Console.WriteLine("Enter Employee Name ");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Employee Age");
            int empAge =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Gender");
            string empGender=Console.ReadLine();
            Console.WriteLine("Enter Employee ID Based on Employee");
            int empDeptID = int.Parse(Console.ReadLine());
            
            List<EmployeeConsoleEntry> empConsoleNewList = new List<EmployeeConsoleEntry>
            {
                new EmployeeConsoleEntry{ EmpName =empName,EmpAge=empAge,EmpGender=empGender,DeptID=empDeptID}
            };
            return empConsoleNewList;   
        }     
        public string InsertEmployeeConsoleRecord()
        {
            bool isDataInserted=true;
            var EmpNewList = AddEmployeeByConsole();
            string query = "insert into Employee values(@EmpName,@EmpAge,@Gender,@DeptID)";

            foreach (var emp in EmpNewList)
            {
                DBconnection();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@EmpName", System.Data.SqlDbType.NVarChar, 100).Value = emp.EmpName;
                cmd.Parameters.Add("@EmpAge", System.Data.SqlDbType.NVarChar, 100).Value = emp.EmpAge;
                cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 100).Value = emp.EmpGender;
                cmd.Parameters.Add("@DeptID", System.Data.SqlDbType.NVarChar, 100).Value = emp.DeptID;
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    isDataInserted = false;
                    break;
                }
                con.Close();
            }
            return isDataInserted == true ? "Successfully Employee Record Inserted " : "Falied to Insert Employee Record";
        }
    }
}
