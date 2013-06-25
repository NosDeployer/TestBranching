<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_employee_hours_for_restart_week.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_employee_hours_for_restart_week" Title="LFS Live"%>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeType" runat="server" SkinID="Label" Text="Select Team Member Type" EnableViewState="False"></asp:Label>
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEmployeeType" runat="server" SkinID="DropDownList" Width="160px" EnableViewState="False">
                        <asp:ListItem>(All)</asp:ListItem>
                        <asp:ListItem Value="LFSCA">LFS Canada</asp:ListItem>
                        <asp:ListItem Value="LFSUS">LFS USA</asp:ListItem>
                        <asp:ListItem Value="LFS">All LFS</asp:ListItem>
                        <asp:ListItem Value="PAGCA">PAG Canada</asp:ListItem>
                        <asp:ListItem Value="PAGUS">PAG USA</asp:ListItem>
                        <asp:ListItem Value="PAG">All PAG</asp:ListItem>
                        <asp:ListItem Value="SOTA">SOTA</asp:ListItem>
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
                <td style="height: 7px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>