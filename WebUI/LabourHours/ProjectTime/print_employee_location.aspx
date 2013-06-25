<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_employee_location.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_employee_location" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblEmployee" runat="server" SkinID="Label" Text="Select Team Member" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEmployee" runat="server" DataSourceID="odsEmployee" DataTextField="FullName"
                        DataValueField="EmployeeID" SkinID="DropDownList" Width="160px" EnableViewState="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectTimeState" runat="server" SkinID="Label" Text="Select Project Time State" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProjectTimeState" runat="server" SkinID="DropDownList" Width="160px" EnableViewState="False">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Unapproved">For Approval</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLocation" runat="server" SkinID="Label" Text="Location" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxLocation" runat="server" SkinID="TextBox" Width="160px" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td style="height: 10px;">
                </td>
            </tr>
        </table>
        
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>