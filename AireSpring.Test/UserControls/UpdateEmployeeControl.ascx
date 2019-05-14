<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateEmployeeControl.ascx.cs" Inherits="AireSpring.Test.UserControls.UpdateEmployeeControl" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    <div class="row">
    <div class="col-md-12">
<div class="form-horizontal">
    <h2> <asp:Literal ID="litMode" runat="server"></asp:Literal> Employee </h2>
        <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
   <div class="form-body">
    <div class="form-group">
        <label class="col-md-2 control-label">Employee ID</label>
        <div class="col-md-10">
            <asp:TextBox ID="txtEmployeeId" runat="server" TextMode="SingleLine" CssClass="form-control" placeholder="Auto-generated" ReadOnly="True" Wrap="False"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-md-2 control-label">Last Name</label>
        <div class="col-md-10">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" TextMode="SingleLine" MaxLength="50" Wrap="False"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-md-2 control-label">First Name</label>
        <div class="col-md-10">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" TextMode="SingleLine" MaxLength="50" Wrap="False"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-md-2 control-label">Phone</label>
        <div class="col-md-10">
                <telerik:RadMaskedTextBox ID="txtPhone" Runat="server" Mask="(###) ###-####" CssClass="form-control" Height="34px" LabelWidth="40%" RoundNumericRanges="False" Skin="" Wrap="False">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None" cssclass="form-control" font-size="14px"></EnabledStyle>
                </telerik:RadMaskedTextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-md-2 control-label">Zip</label>
        <div class="col-md-3">
                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Zip Code" TextMode="Number" MaxLength="5" ></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-md-2 control-label">Hire Date</label>
        <div class="col-md-10">
            <telerik:RadDatePicker ID="dtDateHired" runat="server" EnableTheming="False" Culture="en-US" Height="34px">
<Calendar runat="server" RowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"></Calendar>

<DateInput runat="server" DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%" CssClass="form-control" Font-Size="14px" Height="34px" EnabledStyle-PaddingLeft="12">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>

            </telerik:RadDatePicker>           
        </div>
    </div>
    <div class="form-actions">
    <div class="row">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-info" OnClick="SaveButton_Click" />
            <asp:Button ID="CancelButton" runat="server" Text="Cancel " CssClass="btn btn-default" OnClick="SaveCancel_Click" />
        </div>
    </div>
</div>
    </div>
</div>
   </div>

    </div>


