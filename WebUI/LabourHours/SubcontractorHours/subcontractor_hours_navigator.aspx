<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm7.Master" AutoEventWireup="true" CodeBehind="subcontractor_hours_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractor_hours_navigator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Subcontractor Hours" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Subcontractor Hours" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursBySubcontractor" Text="Add Hours by Subcontractor"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursByClientProject" Text="Add Hours by Client and Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSubcontractors" Text="Add Subcontractors" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mSubcontractorHoursReport" Text="Print Subcontractor Hours" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort"
                        EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element: Search & Sort components , 4 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearchBySubcontractor">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 730px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 300px">
                        <asp:Label ID="lblSubcontractor" runat="server" SkinID="Label" Text="Subcontractor" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 130px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList Width="290px" ID="ddlSubcontractor" runat="server" SkinID="DropDownList"
                            DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                            DataSourceID="odsSubcontractorsList">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 290px" EnableViewState="False" >
                            <asp:ListItem Text="Date" Value="Date" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Subcontractor" Value="Subcontractor"></asp:ListItem>
                            <asp:ListItem Text="Client" Value="Client"></asp:ListItem>
                            <asp:ListItem Text="Project" Value="Project"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSearchBySubcontractor" runat="server" SkinID="Button" Text="Search" Style="width: 80px"
                            OnClick="btnSearchBySubcontractor_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlClientProjectSearch" runat="server" Width="100%" DefaultButton="btnSearchByProject">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 730px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 300px">
                    </td>
                    <td style="width: 300px">
                    </td>
                    <td style="width: 130px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblProject" runat="server" EnableViewState="False" SkinID="Label" Text="Project"></asp:Label>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel id="upnlClient" runat="server" >
                            <contenttemplate>
                                <asp:DropDownList id="ddlClient" runat="server" SkinID="DropDownListLookup" Width="290px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel id="upnlProject" runat="server">
                            <contenttemplate>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 290px">
                                                <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="290px"></asp:DropDownList>
                                            </td>
                                            <td style="VERTICAL-ALIGN: middle">
                                                <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                    <ProgressTemplate>
                                                        <asp:Image id="imAjax" runat="server" skinId="Ajax_Grey"></asp:Image> 
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress> 
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </contenttemplate>
                            <triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                            </triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSearchByProject" runat="server" SkinID="Button" Text="Search" Style="width: 80px"
                            OnClick="btnSearchByProject_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel> 
        
        <asp:Panel ID="pnpFilterByDate" runat="server" Width="100%" DefaultButton="btnSearchByProject">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 300px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       <asp:CheckBox ID="cbxFilterByRangeOfDates" runat="server" Text="Filter By Range of Dates" SkinID="CheckBox" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="140px"
                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upnlEndDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="140px"
                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td>
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
                </td>
            </tr>
        </table>
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
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

