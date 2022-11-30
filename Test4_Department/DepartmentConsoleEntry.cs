using DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Test4_Department
{
    public class DepartmentConsoleEntry:DepartmentProperties
    {
        string connection;
        SqlConnection con;
        string query;
        string cnstr;       

        public DepartmentConsoleEntry()
        {
            try
            {
                cnstr = DBConnections.conStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private SqlConnection DBconnection()
        {
            con = new SqlConnection(cnstr);
            return con;
        }

        public  List<DepartmentConsoleEntry> AddDepartmentByConsoleToList()
        {
            Console.WriteLine("Enter Department Name ");
            string DName=Console.ReadLine();
            Console.WriteLine("Enter Department Short Name");
            string DShortName=Console.ReadLine();

            List<DepartmentConsoleEntry> deptNewList = new List<DepartmentConsoleEntry>
            {
                new DepartmentConsoleEntry{ DeptName =DName,DeptShortName=DShortName}
            };
            return deptNewList;            
        }
        public string InsertDeptListRecordToDB()
        {
            bool isDataInserted = true;
            var deptNewList = AddDepartmentByConsoleToList();
            query= "insert into Department values(@DeptName,@DeptShortName)";
            foreach(var dept in deptNewList)
            {
                DBconnection();
                con.Open();
                SqlCommand cmd=new SqlCommand(query, con);               
                cmd.Parameters.Add("@DeptName",System.Data.SqlDbType.NVarChar, 100).Value = dept.DeptName;
                cmd.Parameters.Add("@DeptShortName", System.Data.SqlDbType.NVarChar, 100).Value = dept.DeptShortName;
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    isDataInserted= false;
                    break;
                }
                con.Close();
            }
            return isDataInserted == true ? "Successfully Department Record Inserted " : "Falied to Insert Department Record";
        }
    }
   

    
}
