using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireSpring.DAL
{
    public class Employee
    {
        public String EmployeeId { get; set; }

        public String EmployeeLastName { get; set; }

        public String EmployeeFirstName { get; set; }

        public String EmployeePhone { get; set; }

        public String EmployeeZip { get; set; }

        public DateTime HireDate { get; set; }

        public Employee()
        {

        }

        public Employee(DataRow row)
        {
            this.EmployeeId = row["EmployeeID"].ToString();
            this.EmployeeLastName = row["EmployeeLastName"].ToString();
            this.EmployeeFirstName = row["EmployeeFirstName"].ToString();
            this.EmployeePhone = row["EmployeePhone"].ToString();
            this.EmployeeZip = row["EmployeeZip"].ToString();
            this.HireDate = (DateTime)row["HireDate"];
        }

    }
}
