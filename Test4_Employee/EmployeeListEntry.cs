
using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Test4_Department;

namespace Test4_Employee
{
    public class EmployeeListEntry : EmployeeList
    {        
        SqlConnection con;
        SqlCommand cmd;
        string conStr = "";
        string query;
        public EmployeeListEntry()
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
        public string InsertEmployeeDataIntoDB()
        {
            bool isDataInserted = true;
            var Emplist = EmployeeListMethod();
            query = "insert into Employee values(@EmpName,@EmpAge,@Gender,@DeptID)";
            foreach (var dept in Emplist)
            {
                DBConnection();
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@EmpName", System.Data.SqlDbType.NVarChar, 100).Value = dept.EmpName;
                cmd.Parameters.Add("@EmpAge", System.Data.SqlDbType.NVarChar, 100).Value = dept.EmpAge;
                cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 100).Value = dept.EmpGender;
                cmd.Parameters.Add("@DeptID", System.Data.SqlDbType.NVarChar, 100).Value = dept.DeptID;
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    isDataInserted = false;
                    break;
                }
                con.Close();
            }
            return isDataInserted == true ? "Success" : "Falied";
        }
        List<EmployeeListEntry> newList = new List<EmployeeListEntry>();
        public string SelectEmployeeDataToNewList()
        {
            bool isDataSelected = true;
            DBConnection();
            con.Open();
            query = "select * from Employee";
            cmd =new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    newList.Add(new EmployeeListEntry()
                    {
                        EmpID = (int)dr["EmpID"],
                        EmpName = dr["EmpName"].ToString(),
                        EmpAge = (int)(decimal)dr["EmpAge"],
                        EmpGender = dr["Gender"].ToString(),
                        DeptID = (int)dr["DeptID"]                        
                    });                    
                }                   
            }
            con.Close();
            return isDataSelected == true ? "Successfully Selected From DataBase" : "No Data Selected";
        }
        public void DisplayNewList()
        {
            foreach (var item in newList)
            {
                Console.WriteLine("Employee ID : " + item.EmpID);
                Console.WriteLine("Employee Name : " + item.EmpName);
                Console.WriteLine("Employee Age : " + item.EmpAge);
                Console.WriteLine("Employee Gender : " + item.EmpGender);
                Console.WriteLine("Employee Dept ID : " + item.DeptID);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
