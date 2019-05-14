using AireSpring.DAL;
using AireSpring.Test.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AireSpring.Test.Employees
{

    /// <summary>
    /// Class that manages the list of employees and 
    /// provides UI features for users.
    /// </summary>
    public partial class List : System.Web.UI.Page
    {

        protected Button ButtonSearch { get; set; }

        protected TextBox TextSearch { get; set; }

        public string _SearchString { get; set; }

        /// <summary>
        /// Search String converted to a strongly-typed variable for 
        /// coding convenience.  Logic-wise it provides validation features
        /// </summary>
        public string SearchString
        {
            get
            {
                if (string.IsNullOrEmpty(_SearchString))
                {
                    _SearchString = (string)Request.QueryString[Vars.SearchString];
                    if (string.IsNullOrEmpty(_SearchString))
                    {
                        _SearchString = string.Empty;
                    }
                    else
                        return _SearchString;
                }
                return _SearchString;
            }
            set
            {
                _SearchString = value;

            }
        }
        /// <summary>
        /// A collection manager for Employees
        /// </summary>
        protected DAL.Employees employees { get; set; }


        /// <summary>
        /// hold the results of the search query
        /// </summary>
        protected DataTable results { get; set; }

        /// <summary>
        /// Event where we can intialize data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            litPageTitle.Text = "Employees List";
            var MyMaster = (SiteMaster)this.Master;
            ButtonSearch = MyMaster.ButtonSearch;
            TextSearch = MyMaster.TextSearch;
            ButtonSearch.Click += new EventHandler(Button1_Click);

            if (!IsPostBack)
            {
                Session[Vars.SessionEmployeesList] = null;
            }
            this.LoadSessionData();
        }

        /// <summary>
        /// Calls the grid.DataBind() function to bind it's DATASOURCE
        /// property to our models.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RadGrid1.DataBind();
            }
        }

        /// <summary>
        /// An automatically executing function separate from the
        /// libraries, web application and other classes that we 
        /// commonly use.  This method reloads the data of the grid
        /// as if it were queried very recently.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = employees.Table;
        }

        /// <summary>
        /// We want to gain access to the session variables used
        /// in the system.  This gets the current value of the session
        /// after its last save earlier today. Any variable mapped to
        /// an actual database object may not necessarily be insynch at the m
        /// moment it is used.
        /// </summary>
        private void LoadSessionData()
        {
            if(Session[Vars.SessionEmployeesList] ==  null)
            {
                Session[Vars.SessionEmployeesList] = new DAL.Employees();
            }
            employees = (DAL.Employees)Session[Vars.SessionEmployeesList];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //DAL.Employees emps = new DAL.Employees();
            //results = DAL.Employees.Search(TextSearch.Text);
            //Session[Vars.SessionEmployeesList] = emps;
            Response.Redirect(string.Format("~/Employees/Search/?SearchText={0}", TextSearch.Text));
        }

       
    }
}