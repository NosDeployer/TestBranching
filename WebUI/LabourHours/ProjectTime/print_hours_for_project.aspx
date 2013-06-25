<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_hours_for_project.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_hours_for_project" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblProjectTimeState" runat="server" SkinID="Label" Text="Select Project Time State" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProjectTimeState" runat="server" SkinID="DropDownList" Width="160px">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Unapproved">For Approval</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
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
                <td >
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList id="ddlClient" runat="server" SkinID="DropDownListLookup" Width="160px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="True" DataMember="DefaultView" DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID">
                            </asp:DropDownList> 
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Select Project" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlProject" runat="server">
                        <contenttemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TR><TD style="WIDTH: 160px"><asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="160px" AutoPostBack="True" DataMember="DefaultView" DataSourceID="odsProject" DataTextField="NAME" DataValueField="ProjectID">
                                            </asp:DropDownList> </TD><TD style="VERTICAL-ALIGN: middle"><asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress> </TD></TR></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" EnableViewState="False" SkinID="Label" Text="Select Team Member Type"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEmployeeType" runat="server" EnableViewState="False" SkinID="DropDownList"
                        Width="160px">
                        <asp:ListItem>(All)</asp:ListItem>
                        <asp:ListItem Value="LFSCA">LFS Canada</asp:ListItem>
                        <asp:ListItem Value="LFSUS">LFS USA</asp:ListItem>
                        <asp:ListItem Value="LFS">All LFS</asp:ListItem>
                        <asp:ListItem Value="PAGCA">PAG Canada</asp:ListItem>
                        <asp:ListItem Value="PAGUS">PAG USA</asp:ListItem>
                        <asp:ListItem Value="PAG">All PAG</asp:ListItem>
                        <asp:ListItem Value="SOTA">SOTA</asp:ListItem>
                        <asp:ListItem Value="Salaried">Salaried</asp:ListItem>
                        <asp:ListItem Value="Subcontractor">Subcontractor</asp:ListItem>
                    </asp:DropDownList></td>
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
                <td style="height: 7px;">
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
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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