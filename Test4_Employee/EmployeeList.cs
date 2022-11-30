using System.Collections.Generic;

namespace Test4_Employee
{
    public class EmployeeList : EmployeeProperties
    {
        public List<EmployeeList> EmployeeListMethod()
        {
            List<EmployeeList> employeeList = new List<EmployeeList>
            {
                 new EmployeeList {EmpName = "Vinay", EmpAge = 20,EmpGender="M",DeptID=1},
                 new EmployeeList {EmpName = "Sravan", EmpAge = 21,EmpGender="M",DeptID=2},
                 new EmployeeList {EmpName = "Durga", EmpAge = 22,EmpGender="F",DeptID=3},
                 new EmployeeList {EmpName = "Mounika", EmpAge = 23,EmpGender="F",DeptID=4},
                 new EmployeeList {EmpName = "Dawood", EmpAge = 24,EmpGender="M",DeptID=5}
            };
            return employeeList;
        }
    }
}
