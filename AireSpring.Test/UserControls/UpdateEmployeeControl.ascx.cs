using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AireSpring.DAL;
using AireSpring.Test.App_Start;

namespace AireSpring.Test.UserControls
{
    public partial class UpdateEmployeeControl : System.Web.UI.UserControl
    {
        protected DbHelper db { get; set; }

        private string _Mode;
        public string Mode
        {
            get
            {
                if (string.IsNullOrEmpty(_Mode))
                {
                    _Mode = (string)Request.QueryString[Vars.Mode];
                    if (string.IsNullOrEmpty(_Mode))
                    {
                        _Mode = Vars.ModeCreate;
                    }
                    else
                        return _Mode;
                }
                return _Mode;  
            }
            set
            {  
                _Mode = value;
                SelectMode(_Mode);
            }
        }

        private string _EmployeeId;
        public String EmployeeId
        {
            get
            {
                if (string.IsNullOrEmpty(_EmployeeId))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString[Vars.EmployeeId].ToString()))
                        _EmployeeId = Request.QueryString[Vars.EmployeeId].ToString();
                    else
                        _EmployeeId = string.Empty;
                }
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        protected Employee CurrentEmployee { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    this.SelectMode(Mode);
                }
                catch(Exception ex)
                {

                }    
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SelectMode(string mode)
        {
            switch (mode.ToLower())
            {
                case "create":
                    { 
                        this.LoadCreateForm();
                        break;
                    }
                case "edit":
                    {
                        if (!(string.IsNullOrEmpty(this.EmployeeId)))
                        {
                            CurrentEmployee = DAL.Employees.LoadById(this.EmployeeId);
                            if (!(CurrentEmployee is null))
                            {
                                this.LoadEditForm(CurrentEmployee);
                            }
                            else
                                throw new NullReferenceException("Employee record not found!");
                            
                        }
                        else
                            throw new ArgumentNullException("EmployeeID", "Employee Id is not specified.");
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(string.Format("Mode: {0}", mode), "Null or unknown mode specified.");
                    }
            }
        }

        private void ClearForm()
        {
            litMode.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtZip.Text = string.Empty;
            dtDateHired.SelectedDate = null;
        }

        private void LoadCreateForm()
        {
            ClearForm();
            litMode.Text = " Create ";
            SaveButton.Text = "Create";
        }

        private void LoadEditForm(Employee emp)
        {
            ClearForm();
            litMode.Text = " Edit ";
            SaveButton.Text = "Modify";
            txtEmployeeId.Text = emp.EmployeeId;
            txtLastName.Text = emp.EmployeeLastName;
            txtFirstName.Text = emp.EmployeeFirstName;
            txtPhone.Text = emp.EmployeePhone;
            txtZip.Text = emp.EmployeeZip;
            dtDateHired.SelectedDate = emp.HireDate;
            Session[Vars.SessionCurrentEmployee] = emp;
        }

        private void SaveForm(string mode)
        {
            Employee emp = new Employee();       
            emp.EmployeeLastName = txtLastName.Text;
            emp.EmployeeFirstName = txtFirstName.Text;
            emp.EmployeePhone = txtPhone.Text;
            emp.EmployeeZip = txtZip.Text;
            emp.HireDate = (DateTime)dtDateHired.DbSelectedDate;
            if (mode == Vars.ModeCreate)
            {
                emp.EmployeeId = System.Guid.NewGuid().ToString();
                CurrentEmployee = DAL.Employees.Create(emp);
            }
            else
            {
                emp.EmployeeId = txtEmployeeId.Text;
                CurrentEmployee = DAL.Employees.SaveChanges(emp);
            }
            Session[Vars.SessionCurrentEmployee] = CurrentEmployee;
            this.EmployeeId = CurrentEmployee.EmployeeId;
            this.Mode = "edit";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            SaveForm(Mode);
            Response.Redirect("~/Employees/List");
        }

        protected void SaveCancel_Click(object sender, EventArgs e)
        {
            Session[Vars.SessionCurrentEmployee] = null;
            Response.Redirect("~/Employees/List");
        }
    }
}