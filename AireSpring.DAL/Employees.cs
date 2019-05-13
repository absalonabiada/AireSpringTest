using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireSpring.DAL
{
   public class Employees
    {
        public DataTable Table { get; set; }

        public List<Employee> Items { get; set; }

        public static List<Employee> SearchItems { get; set; }

        public static string SelectSql = " SELECT [EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeePhone], [EmployeeZip], [HireDate] FROM [EMPLOYEES] ORDER BY [HireDate] ";
        public static string SelectByIdSql = " SELECT [EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeePhone], [EmployeeZip], [HireDate] FROM [EMPLOYEES] WHERE [EMPLOYEEID] = '{0}' ";
        public static string InsertSql = " INSERT INTO [EMPLOYEES] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName], [EmployeePhone], [EmployeeZip], [HireDate]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ";
        public static string UpdateSql = " UPDATE [EMPLOYEES] SET [EmployeeFirstName]='{1}', [EmployeeLastName]='{2}', [EmployeePhone]='{3}', [EmployeeZip]='{4}', [HireDate]='{5}' WHERE [EmployeeId] = '{0}' ";
        public static string SearchSql = " SELECT * FROM (( " +
                                         " SELECT[EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeePhone], [EmployeeZip], [HireDate] FROM [EMPLOYEES] WHERE [EmployeeLastName] Like '%{0}%' ) " +
                                         " UNION (" + 
                                         " SELECT[EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeePhone], [EmployeeZip], [HireDate] FROM [EMPLOYEES] WHERE [EmployeePhone] Like '%{0}%' ) " + 
                                         " ) AS SEARCH_RESULTS ORDER BY HireDate DESC ";
        public Employees()
        {
            Items = new List<Employee>();
            Table = new DataTable("Employees");
            this.GetEmployees();
        }
        
        public DataTable GetData()
        {
            var db = new DbHelper();
            Table = db.ExecuteSql(SelectSql);
            return Table;
        }

        private void GetEmployees()
        {
            var db = new DbHelper();
            Table = db.ExecuteSql(SelectSql);
            if (!(Table == null))
            {
                if (!(Table.Rows.Count == 0))
                {
                    foreach (DataRow row in Table.Rows)
                    {
                        var emp = new Employee(row);
                        Items.Add(emp);
                    }
                }
            }
        }

        public static Employee LoadById(string Key)
        {
            var db = new DbHelper();
            var tempSql = string.Format(SelectByIdSql, Key);
            var empList = db.ExecuteSql(tempSql);
            if (empList.Rows.Count > 1)
            {
                throw new OverflowException("Illegal duplicate record found!");
            }
            else if (empList.Rows.Count == 1)
            {
                var emp = new Employee(empList.Rows[0]);
                return emp;
            }
            else
                return null;
        }

        public static Employee SaveChanges(Employee emp)
        {
            var temp = LoadById(emp.EmployeeId);
            if (temp is null)
            {
                throw new NullReferenceException("Employee record does not exist in the database.");
            }
            else
            {
                temp = emp;
                var tempSql = string.Format(UpdateSql, temp.EmployeeId, temp.EmployeeFirstName, temp.EmployeeLastName, temp.EmployeePhone, temp.EmployeeZip, temp.HireDate);
                var db = new DbHelper();
                var count = db.UpdateSql(tempSql);
                if (count > 1)
                {
                    throw new DuplicateNameException("Duplicate records were found.");
                }
            }    
            return temp;
        }

        public static Employee Create(Employee emp)
        {
            var temp = LoadById(emp.EmployeeId);
            if(!(temp is null))
            {
                throw new IndexOutOfRangeException("Employee already exists in the database.");
            }
            else
            {
                temp = emp;
                var tempSql = string.Format(InsertSql, temp.EmployeeId, temp.EmployeeFirstName, temp.EmployeeLastName, temp.EmployeePhone, temp.EmployeeZip, temp.HireDate);
                var db = new DbHelper();
                db.UpdateSql(tempSql);
                return temp;
            }
           
        }

        public static DataTable Search(string search)
        {
            var db = new DbHelper();
            var tempSearchSql = string.Format(SearchSql, search);
            var table = db.ExecuteSql(tempSearchSql);
            SearchItems = new List<Employee>();
            if (!(table == null))
            {
                if (!(table.Rows.Count == 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var emp = new Employee(row);
                        SearchItems.Add(emp);
                    }
                }
            }
            return table;
        }
    }
}
