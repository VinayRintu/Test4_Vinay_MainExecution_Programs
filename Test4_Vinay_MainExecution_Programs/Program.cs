//// See https://aka.ms/new-console-template for more information
//using System.Data.Common;
//using Test4_Department;
//using Test4_Employee;

//DB_Connection objDeptDBConnection = new DB_Connection();

//DepartmentConsoleEntry objDeptConsole = new DepartmentConsoleEntry();
//EditDepartment objDeptEditDepartments = new EditDepartment();
//Department_Add_New_List objDeptnewList = new Department_Add_New_List();

//EditEmployee objEditEmployee = new EditEmployee();
//EmployeeConsoleEntry objConsoleEntry = new EmployeeConsoleEntry();

//Console.WriteLine("Select One Option" + Environment.NewLine +
//    "1.Add Department Record By List " + Environment.NewLine +
//    "2.Add Department By Console" + Environment.NewLine +
//    "3.Update Departmenmt" + Environment.NewLine +
//    "4.Delete Department" + Environment.NewLine +
//    "5.Display New List Records" + Environment.NewLine +
//    "6.Truncate All Table Data" + Environment.NewLine +
//    "7.Add Employee Records By List" + Environment.NewLine +
//    "8.Add Employee By Console" + Environment.NewLine +
//    "9.Update Employee" + Environment.NewLine +
//    "10.Delete Employee" + Environment.NewLine +
//    "11.Display New List Records");


//int option = int.Parse(Console.ReadLine());
//switch (option)
//{
//    case 1:
//        DB_Connection objDbConnection = new DB_Connection();
//        objDbConnection.DBconnection();
//        break;
//    case 2:
//        objDeptConsole.AddDepartment();
//        break;
//    case 3:
//        objDeptEditDepartments.UpdateDepartmentData();
//        break;
//    case 4:
//        objDeptEditDepartments.DeleteEmployeeData();
//        break;
//    case 5:
//        objDeptnewList.AddDepartmentNewList();
//        objDeptnewList.DisplayNewListDepartments();
//        break;
//    case 6:
//        objDeptnewList.ClearDb();
//        break;
//    case 7:
//        DB_Connection_Employee objDBConnection = new DB_Connection_Employee();
//        objDBConnection.DBconnection();
//        break;
//    case 8:
//        objConsoleEntry.AddEmployee();
//        break;
//    case 9:
//        objEditEmployee.UpdateEmployeeData();
//        break;
//    case 10:
//        objEditEmployee.DeleteEmployeeData();
//        break;
//    case 11:
//        Employee_NewList_FromDatabase objNewList = new Employee_NewList_FromDatabase();
//        objNewList.EmployeeNewList();
//        objNewList.DisplayNewList();
//        break;

//}

using Test4_Employee;

DB_Connection_Employee obj = new DB_Connection_Employee();

string result= obj.SetEmployeeData("insert into Employee values (@EmpName,@EmpAge,@Gender,@DeptID)");

Console.WriteLine(result);