<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mReport1.Master" AutoEventWireup="true" CodeBehind="production_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.production_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" Text="Select Country" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="1">Canada</asp:ListItem>
                        <asp:ListItem Value="2">USA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Select Client" EnableViewState="False"></asp:Label>
                </td>
            </tr>       
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                SkinID="DropDownListLookup" Width="160px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Select Project" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width:160px">
                                            <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="160px" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress> 
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel> 
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
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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