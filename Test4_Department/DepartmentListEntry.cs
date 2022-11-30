using DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Test4_Department;

namespace Test4_Department
{
    public class DepartmentListEntry : DepartmentList
    {
        string conStr="";
        SqlConnection con;
        string query;
        SqlCommand cmd;

        public DepartmentListEntry()
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

        public string InsertDepartmentDataIntoDB()
        {
            bool isDataInserted = true;
            var deptList = DepartmentListMethod();
            DBConnection();
            query = "insert into Department(DeptName,DeptShortName)" + "values (@deptName,@deptShortName)";            
            foreach (var dept in deptList)
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@deptName", System.Data.SqlDbType.NVarChar, 100).Value = dept.DeptName;
                cmd.Parameters.Add("@deptShortName", System.Data.SqlDbType.NVarChar, 50).Value = dept.DeptShortName;
                int isdone = cmd.ExecuteNonQuery();               
                if (isdone == 0)
                {
                   isDataInserted= false;
                    break;
                }
                con.Close();
            }
            return isDataInserted == true ? "Department Record Inserted Successfully" : "No Record Inserted";
        }
        List<DepartmentListEntry> newDeptList= new List<DepartmentListEntry>();
        public string SelectDepartmentDataToNewList()
        {
            newDeptList.Clear();
            bool isDataSelected = true;
            DBConnection();
            con.Open();
            query = "select * from Department";
            cmd=new SqlCommand(query, con);
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    newDeptList.Add(new DepartmentListEntry()
                    {
                        DeptID = (int)dr["DeptID"],
                        DeptName = (string)dr["DeptName"],
                        DeptShortName = (string)dr["DeptShortName"]
                    });
                    
                }               
            }
            else
            {
                isDataSelected = false;
            }
            con.Close();
            return isDataSelected == true ? "Successfully Selected From DataBase" : "No Data Selected";
        }
        public void DisplayNewList()
        {
            foreach (var dept in newDeptList)
            {
                Console.WriteLine("Department ID : " + dept.DeptID);
                Console.WriteLine("Department Name : " + dept.DeptName);
                Console.WriteLine("Department Short Name : " + dept.DeptShortName);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
