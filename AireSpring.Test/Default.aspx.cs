using AireSpring.Test.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AireSpring.Test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
            litPageTitle.Text = "";
            Page.Title = "Home";
            var MyMaster = (SiteMaster)this.Master;
            ButtonSearch = MyMaster.ButtonSearch;
            TextSearch = MyMaster.TextSearch;
            ButtonSearch.Click += new EventHandler(Button1_Click);
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