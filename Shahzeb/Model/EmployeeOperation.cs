using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahzeb.Model
{
    public class EmployeeOperation
    {
        private static List<Employee> ObjEmployeesList;
        public EmployeeOperation()
        {
            ObjEmployeesList = new List<Employee>()
            {
                new Employee() {EmployeeId =101,Fristname = "Shahzeb", Lastname = "Alam", EmailId="mdshahzebalam007@gmali.com",Location="Delhi", DateOfBirth= "27/08/2000"},
                new Employee() {EmployeeId =102, Fristname = "Abdul" , Lastname="Qayyum", EmailId="test@abc.com", Location="Hyderabad",DateOfBirth="10/10/1998"},
                new Employee() {EmployeeId =103,Fristname="Mohammed" , Lastname="Ali", EmailId="test@abc.com", Location="Hyderabad",DateOfBirth="10/10/1998"}
            };

        }

        public List<Employee> GetAll()
        {
            return ObjEmployeesList;
        }

        public bool Add (Employee employee) 
        {
            
            //ObjEmployeesList.Append(employee);
            ObjEmployeesList.Add(new Employee() { EmployeeId = employee.EmployeeId, Fristname = employee.Fristname,Lastname= employee.Lastname,EmailId=employee.EmailId,Location=employee.Location,DateOfBirth= employee.DateOfBirth });
            //ObjEmployeesList.Add(employee);
            return true;
        }

        public bool Delete (Employee employee) 
        {
            bool IsDeleted = false;
            for(int i = 0; i < ObjEmployeesList.Count; i++)
            {
                if (ObjEmployeesList[i].EmployeeId == employee.EmployeeId)
                {
                    ObjEmployeesList.RemoveAt(i);
                    IsDeleted = true;
                    break; }
            }
            return IsDeleted;
        }
        public bool Update (Employee employee) 
        {
            bool IsUpdated = false;
            for(int i = 0;i < ObjEmployeesList.Count;i++) 
            {
                if (ObjEmployeesList[i].EmployeeId == employee.EmployeeId) 
                {
                    ObjEmployeesList[i].Fristname = employee.Fristname;
                    ObjEmployeesList[i].Lastname = employee.Lastname;
                    ObjEmployeesList[i].EmailId = employee.EmailId;
                    ObjEmployeesList[i].Location = employee.Location;
                    ObjEmployeesList[i].DateOfBirth = employee.DateOfBirth;
                    IsUpdated= true;
                    break;
                }
            }
            return IsUpdated;
        }
    }
}
