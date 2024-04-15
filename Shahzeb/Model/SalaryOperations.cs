using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shahzeb.Model
{
    public class SalaryOperations
    {
        private static List<Employee> ObjEmployeesList;
        private static List<Employee_Salary> ObjEmployeesSalaryList;
        private static List<Employee_Salary> ObjSalaryList;
        public SalaryOperations()
        {
            
            ObjEmployeesSalaryList = new List<Employee_Salary>()
             {
                new Employee_Salary() {EmployeeId = 101,Payroll=1,Type="Benefit",Name="Basic",Value=50000 },
                new Employee_Salary() { EmployeeId = 101, Payroll = 2, Type = "Benefit", Name = "HRA", Value = 20000 },
                new Employee_Salary() { EmployeeId = 101, Payroll = 3, Type = "Deduction", Name = "Tax", Value = 1700 },
                new Employee_Salary() {EmployeeId = 102,Payroll=1,Type="Benefit",Name="Basic",Value=40000 },
                new Employee_Salary() { EmployeeId = 102, Payroll = 2, Type = "Benefit", Name = "HRA", Value = 24000 },
                new Employee_Salary() { EmployeeId = 102, Payroll = 3, Type = "Deduction", Name = "Tax", Value = 1400 },
                new Employee_Salary() {EmployeeId = 103,Payroll=1,Type="Benefit",Name="Basic",Value=35600 },
                new Employee_Salary() { EmployeeId = 103, Payroll = 2, Type = "Benefit", Name = "HRA", Value = 15600 },
                new Employee_Salary() { EmployeeId = 103, Payroll = 3, Type = "Deduction", Name = "Tax", Value = 1100 },
            };


        }
        public List<Employee_Salary> GetAllS(Employee employee)
        {
            ObjSalaryList = new List<Employee_Salary>();
            if (employee == null)
                return ObjEmployeesSalaryList;
            foreach (var item in ObjEmployeesSalaryList)
            {
                if (item.EmployeeId == employee.EmployeeId)
                {
                    ObjSalaryList.Add(item);
                }
            }

            return ObjSalaryList;
            //return ObjEmployeesSalaryList;
        }
        public bool AddS(Employee_Salary employee)
        {
            ObjEmployeesSalaryList.Add(new Employee_Salary() { EmployeeId=employee.EmployeeId,Name=employee.Name,Payroll=employee.Payroll,Type=employee.Type,Value=employee.Value});
            return true;
        }
        public bool DeleteS(Employee_Salary employee)
        {
            bool IsDeleted = false;
            for (int i = 0; i < ObjEmployeesSalaryList.Count; i++)
            {
                if (ObjEmployeesSalaryList[i].Payroll == employee.Payroll && ObjEmployeesSalaryList[i].EmployeeId==employee.EmployeeId)
                {
                    ObjEmployeesSalaryList.RemoveAt(i);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }
    }
}
