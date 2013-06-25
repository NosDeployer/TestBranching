<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_3_chart_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_3_chart_report" Title="LFS Live" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
           <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"/>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
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
        </table>
    </div>
</asp:Content>