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
    public partial class Update : System.Web.UI.Page
    {

        /// <summary>
        /// 
        /// </summary>
        public DbHelper db { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected Button ButtonSearch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected TextBox TextSearch { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
        /// Accessible list of employees
        /// </summary>
        protected DAL.Employees employees { get; set; }

        /// <summary>
        /// hold the results of the search query
        /// </summary>
        protected DataTable results { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadSessionData()
        {
            if (Session[Vars.SessionEmployeesList] == null)
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
            Response.Redirect(string.Format("~/Employees/Search/?SearchText={0}", TextSearch.Text));
        }
    }
}