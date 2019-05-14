<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AireSpring.Test.Employees.List" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" >
<div class="row">
    <div class="col-md-12">
    <h2><asp:Literal ID="litPageTitle" runat="server"></asp:Literal></h2>
    <hr />
    <div class="page-container">
    <div class="container">
        <div class="alert-">
        </div>
         <div class="row">
               <div class="col-md-12">
                   <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RadGrid1_NeedDataSource" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" ShowFooter="True" ShowStatusBar="True" Skin="Bootstrap" Width="100%">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
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
                               <telerik:GridBoundColumn DataField="EmployeeId" FilterControlAltText="Filter EmployeeId column" HeaderText="Emp. Id" UniqueName="EmployeeId" AutoPostBackOnFilter="True" DataFormatString="{0:N}">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="EmployeeFirstName" FilterControlAltText="Filter EmployeeFirstName column" HeaderText="First Name" UniqueName="EmployeeFirstName" AutoPostBackOnFilter="True" MaxLength="50">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="EmployeeLastName" FilterControlAltText="Filter EmployeeLastName column" HeaderText="Last Name" UniqueName="EmployeeLastName" AutoPostBackOnFilter="True" MaxLength="50">
                               </telerik:GridBoundColumn>
                               <telerik:GridMaskedColumn DataField="EmployeePhone" FilterControlAltText="Filter EmployeePhone column" HeaderText="Phone No." UniqueName="EmployeePhone" Mask="(###) ###-####" MaxLength="15" AutoPostBackOnFilter="True">
                               </telerik:GridMaskedColumn>
                               <telerik:GridNumericColumn DataField="EmployeeZip" FilterControlAltText="Filter EmployeeZip column" HeaderText="Zip" UniqueName="EmployeeZip" MaxLength="5" AutoPostBackOnFilter="True">
                               </telerik:GridNumericColumn>
                               <telerik:GridDateTimeColumn DataField="HireDate" FilterControlAltText="Filter HireDate column" HeaderText="Date Hired" UniqueName="HireDate" DataFormatString="{0:MM/dd/yyyy}" AutoPostBackOnFilter="True" DataType="System.DateTime">
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
</div>
</telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Height="100%" Modal="True" Width="100%"></telerik:RadAjaxLoadingPanel>
</asp:Content>
