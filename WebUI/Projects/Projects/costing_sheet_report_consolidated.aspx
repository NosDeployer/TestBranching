<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="costing_sheet_report_consolidated.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.costing_sheet_report_consolidated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Select Client" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlClient" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlClient" runat="server" SkinID="DropDownListLookup" Width="160px"
                                OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="True" DataMember="DefaultView"
                                DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Select Project" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="width: 160px">
                                        <asp:DropDownList ID="ddlProject" runat="server" SkinID="DropDownListLookup" Width="160px"
                                            AutoPostBack="True" DataMember="DefaultView" DataSourceID="odsProject" DataTextField="NAME"
                                            DataValueField="ProjectID">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="vertical-align: middle">
                                        <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                            <ProgressTemplate>
                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
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