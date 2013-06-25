<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master"  AutoEventWireup="true" 
CodeBehind="gerencial_daily_production_report.aspx.cs"  Title="LFS Live"
Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.gerencial_daily_production_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">            
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text="Date" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr> 
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>