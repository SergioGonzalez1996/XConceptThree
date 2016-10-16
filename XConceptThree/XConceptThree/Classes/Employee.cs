using SQLite.Net.Attributes;
using System;

namespace XConceptThree
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime ContractDate { get; set; }

        public decimal Salary { get; set; }

        public bool Active { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public override int GetHashCode()
        {
            return EmployeeId;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", EmployeeId, FullName);
        }
    }
}