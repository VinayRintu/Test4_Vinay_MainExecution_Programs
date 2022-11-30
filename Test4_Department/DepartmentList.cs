using System.Collections.Generic;

namespace Test4_Department
{
    public class DepartmentList : DepartmentProperties
    {
        public List<DepartmentList> DepartmentListMethod()
        {
            List<DepartmentList> departmentList = new List<DepartmentList>
            {
                 new DepartmentList { DeptName = "Human Resource", DeptShortName = "HR" },
                 new DepartmentList { DeptName = "Electricity", DeptShortName = "EC" },
                 new DepartmentList { DeptName = "Home Department", DeptShortName = "HD" },
                 new DepartmentList { DeptName = "Health Department", DeptShortName = "HL" },
                 new DepartmentList { DeptName = "Finance", DeptShortName = "FN" }
            };
            return departmentList;
        }
    }
}
