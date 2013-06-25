<%@ Page Language="C#" MasterPageFile="../../mReport1.Master"  AutoEventWireup="true" 
CodeBehind="gerencial_weekly_production_report.aspx.cs"  Title="LFS Live"
Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.gerencial_weekly_production_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">            
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" 
                                SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                onselecteddatechanged="tkrdpStartDate_SelectedDateChanged">
                                <dateinput autopostback="True">
                                </dateinput>
                                <calendar daynameformat="Short" showrowheaders="False" 
                                    usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                    viewselectortext="x">
                                </calendar>
                                <datepopupbutton hoverimageurl="" imageurl="" />
                            </telerik:RadDatePicker>
                        </ContentTemplate> 
                    </asp:UpdatePanel> 
                </td>
            </tr> 
            <tr>
                <td style="height:7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlEndDateValue" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:Label ID="lblEndDateValue" runat="server" Text="End Date Value" 
                                SkinID="Label"></asp:Label>
                        </ContentTemplate> 
                    </asp:UpdatePanel>    
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