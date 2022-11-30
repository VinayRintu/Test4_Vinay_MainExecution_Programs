// See https://aka.ms/new-console-template for more information
using Test4_Department;
using Test4_Employee;
using static System.Net.Mime.MediaTypeNames;




Console.WriteLine("Select One Option"+"\n"+"1.Employee "+"\n"+"2.Department");
int option=int.Parse(Console.ReadLine());

switch (option)
{
    case 1:
        EmployeeExecution objEmp = new EmployeeExecution();
        objEmp.EmployeeMainMethod();
        break;
    case 2:
        DepartmentExecution objDept=new DepartmentExecution();
        objDept.DepartmentMainMethod();
        break;
}