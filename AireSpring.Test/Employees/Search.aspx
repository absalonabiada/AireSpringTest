<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AireSpring.Test.Employees.Search" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/SearchControl.ascx" TagPrefix="uc1" TagName="SearchControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:radajaxpanel id="RadAjaxPanel1" runat="server" height="100%" width="100%" horizontalalign="NotSet" loadingpanelid="RadAjaxLoadingPanel1">

<div class="row">
    <div class="col-md-12">
    <h2><asp:Literal ID="litPageTitle" runat="server" Text="Search Employees"></asp:Literal></h2>
    <hr />
    <div class="page-container">
    <div class="container">
        <div class="alert-">
        
        </div>
         <div class="row">
               <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  OnNeedDataSource="RadGrid1_NeedDataSource" ShowFooter="True" ShowStatusBar="True" Skin="Bootstrap" Width="100%">
                   <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                   <ClientSettings>
                       <Selecting AllowRowSelect="True" />
                       <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                       <Resizing AllowColumnResize="True" />
                   </ClientSettings>
                   <MasterTableView CommandItemDisplay="Top" DataKeyNames="EmployeeID">
                       <RowIndicatorColumn Visible="False">
                       </RowIndicatorColumn>
                       <ExpandCollapseColumn Created="True">
                       </ExpandCollapseColumn>
                       <Columns>
                           <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="EmployeeId" DataFormatString="{0:N}" FilterControlAltText="Filter EmployeeId column" HeaderText="Emp. Id" UniqueName="EmployeeId">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="EmployeeFirstName" FilterControlAltText="Filter EmployeeFirstName column" HeaderText="First Name" MaxLength="50" UniqueName="EmployeeFirstName">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn AutoPostBackOnFilter="True" DataField="EmployeeLastName" FilterControlAltText="Filter EmployeeLastName column" HeaderText="Last Name" MaxLength="50" UniqueName="EmployeeLastName">
                           </telerik:GridBoundColumn>
                           <telerik:GridMaskedColumn AutoPostBackOnFilter="True" DataField="EmployeePhone" FilterControlAltText="Filter EmployeePhone column" HeaderText="Phone No." Mask="(###) ###-####" MaxLength="15" UniqueName="EmployeePhone">
                           </telerik:GridMaskedColumn>
                           <telerik:GridNumericColumn AutoPostBackOnFilter="True" DataField="EmployeeZip" FilterControlAltText="Filter EmployeeZip column" HeaderText="Zip" MaxLength="5" UniqueName="EmployeeZip">
                           </telerik:GridNumericColumn>
                           <telerik:GridDateTimeColumn AutoPostBackOnFilter="True" DataField="HireDate" DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter HireDate column" HeaderText="Date Hired" UniqueName="HireDate">
                           </telerik:GridDateTimeColumn>
                           <%-- <telerik:GridButtonColumn CommandName="Modify" FilterControlAltText="Filter Modify column" Text="Modify" UniqueName="Modify">
                               </telerik:GridButtonColumn>--%>
                           <telerik:GridHyperLinkColumn AllowSorting="False" DataNavigateUrlFields="EmployeeId" DataNavigateUrlFormatString="~/Employees/Update/?mode=Edit&amp;EmployeeId={0}" FilterControlAltText="Filter column column" NavigateUrl="~/Employees/Update.aspx" Text="Edit" UniqueName="column">
                           </telerik:GridHyperLinkColumn>
                       </Columns>
                   </MasterTableView>
               </telerik:RadGrid>
         </div>
    </div>
</div>
    </div>
</div>
</telerik:radajaxpanel>
    <telerik:radajaxloadingpanel id="RadAjaxLoadingPanel1" runat="server" skin="Bootstrap" height="100%" modal="True" width="100%"></telerik:radajaxloadingpanel>
</asp:Content>




