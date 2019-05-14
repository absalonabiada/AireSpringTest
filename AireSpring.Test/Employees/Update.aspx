<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="AireSpring.Test.Employees.Update" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/UpdateEmployeeControl.ascx" TagPrefix="uc1" TagName="UpdateEmployeeControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:radajaxpanel id="RadAjaxPanel1" runat="server" height="100%" width="100%" horizontalalign="NotSet" loadingpanelid="RadAjaxLoadingPanel1" rendermode="Block">
        <uc1:UpdateEmployeeControl runat="server" ID="UpdateEmployeeControl1" />
    </telerik:radajaxpanel>
    <telerik:radajaxloadingpanel id="RadAjaxLoadingPanel1" runat="server" skin="Default" height="100%" modal="True" width="100%"></telerik:radajaxloadingpanel>
</asp:Content>