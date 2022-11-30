using DBConnection;
using System;
using System.Data.SqlClient;

namespace Test4_Department
{
    public class EditDepartment
    {
        SqlConnection con;
        SqlCommand cmd;
        string conStr = "";
        public EditDepartment()
        {
            try
            {
                conStr = DBConnections.conStr;
            }
            catch (System.Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
        }
        private SqlConnection DBConnection()
        {
            con = new SqlConnection(conStr);
            return con;
        }

        public void UpdateDepartmentData()
        {
            Console.WriteLine("Enter Department ID  where to Update ");
            int deptID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Department Name");
            string dName = Console.ReadLine();
            Console.WriteLine("Enter Department Short Name");
            string DShortName=Console.ReadLine();

            DBConnection();
            con.Open();
            string query = "update Department set DeptName='" + dName + "',DeptShortName='"+DShortName+"' where DeptID=" + deptID + "";
            SqlCommand cmd = new SqlCommand(query, con);
            int objDone = cmd.ExecuteNonQuery();
            con.Close();
            if (objDone == 1)
            {
                Console.WriteLine("Updated Record Successfully");
            }
            else
                Console.WriteLine("No Record Inserted");
        }
        public void DeleteEmployeeData()
        {
            Console.WriteLine("Enter Department ID  to Delete ");
            int deptId = int.Parse(Console.ReadLine());

            DBConnection();
            con.Open();
            string query = "delete Department where DeptID=" + deptId + "";
            SqlCommand cmd = new SqlCommand(query, con);
            int objDone = cmd.ExecuteNonQuery();
            cmd.Clone();
            if (objDone == 1)
            {
                Console.WriteLine("Department Record Deleted Successfully");
            }
            else
                Console.WriteLine("No Record Inserted");
        }
    }
}
