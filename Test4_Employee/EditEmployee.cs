using DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4_Employee
{
    public class EditEmployee
    {
        string conStr="";
        SqlConnection con;
        string query;

        public EditEmployee()
        {
            try
            {
                conStr = DBConnections.conStr;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private SqlConnection DBConnection()
        {
            con = new SqlConnection(conStr);
            return con;
        }

        public void UpdateEmployeeData()
        {
            Console.WriteLine("Enter EmployeeID where to Update ");
            int eId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Employee Name");
            string eName=Console.ReadLine();

            DBConnection();
            con.Open();
            query = "update Employee set EmpName='" + eName + "' where EmpID=" + eId + "";
            SqlCommand cmd=new SqlCommand(query, con); 
            int objDone = cmd.ExecuteNonQuery();
            con.Close();
            if(objDone == 1)
            {
                Console.WriteLine("Updated Record Successfully");
            }
        }
        public void DeleteEmployeeData()
        {
            Console.WriteLine("Enter EmployeeID  to Delete ");
            int eId = int.Parse(Console.ReadLine());

            DBConnection();
            con.Open();
            query = "delete Employee where EmpID=" + eId + "";
            SqlCommand cmd = new SqlCommand(query, con);           
            int objDone = cmd.ExecuteNonQuery();
            cmd.Clone();
            if (objDone == 1)
            {
                Console.WriteLine("Employee Record Deleted Successfully");
            }
        }
    }
}
