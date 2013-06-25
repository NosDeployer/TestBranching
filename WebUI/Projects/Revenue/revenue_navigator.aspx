<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mForm7.Master" AutoEventWireup="true" CodeBehind="revenue_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Revenue.revenue_navigator" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Project Revenue" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Revenue" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddRevenue" Text="Add Revenue"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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
        <!-- Page element: Search & Sort components , 5 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 115px">
                    </td>                    
                    <td style="width: 230px" colspan="2">
                    </td>                    
                    <td style="width: 230px">
                    </td>                    
                      <td style="width: 75px">
                    </td>
                    <td style="width: 90px">
                    </td>                     
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" EnableViewState="False" 
                            SkinID="Label" Text="Country"></asp:Label>
                        </td>                    
                    <td colspan="2">
                        <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                    </td>                    
                    <td>
                        <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                    </td>                    
                    <td></td>                    
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlCountry" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCountry" runat="server" 
                                    DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID" 
                                    SkinID="DropDownList" Width="105px">
                                </asp:DropDownList>
                             </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td colspan="2">
                        <asp:UpdatePanel ID="upnlClient" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                 <table cellspacing="0" cellpadding="0" width="100%" border="0">                                
                                    <tr>
                                        <td style="width: 230px">
                                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" DataMember="DefaultView"
                                                DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                                SkinID="DropDownListLookup" Width="220px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>                               
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>                    
                    <td>
                        <asp:UpdatePanel ID="upnlProject" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">                                
                                    <tr>
                                        <td style="width: 230px">
                                            <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" DataMember="DefaultView"  
                                                DataSourceID="odsProject" DataTextField="NAME" DataValueField="ProjectID" 
                                                SkinID="DropDownListLookup" Width="220px" >
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
                    <td></td>                   
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px"
                            OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                    
                </tr>                                
                <tr>
                    <td colspan="6" style="height: 7px">
                    </td>
                </tr>               
                <tr>
                    <td>
                        <asp:Label ID="lblStartDate" runat="server" EnableViewState="False" 
                            SkinID="Label" Text="Start Date"></asp:Label>
                    </td>                    
                    <td>
                        <asp:Label ID="lblEndDate" runat="server" EnableViewState="False" 
                            SkinID="Label" Text="End Date"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" 
                            Text="Sort By"></asp:Label>
                    </td> 
                    <td></td>
                    <td>
                    </td>                   
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" 
                            Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                            SkinID="RadDatePicker" Width="105px">
                            <Calendar DayNameFormat="Short" ShowRowHeaders="False" 
                                UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                            </DateInput>
                        </telerik:RadDatePicker>
                    </td>                   
                    <td>
                        <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" 
                                    Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                                    SkinID="RadDatePicker" Width="105px">
                                    <Calendar DayNameFormat="Short" ShowRowHeaders="False" 
                                        UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upnlEndDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSortBy" runat="server" EnableViewState="False" 
                                    SkinID="DropDownList" Width="105px">
                                    <asp:ListItem Text="Date" Value="Date"></asp:ListItem>
                                    <asp:ListItem Text="Client" Value="ClientId"></asp:ListItem>
                                    <asp:ListItem Text="Project" Value="ProjectId"></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>                                               
                    </td>                    
                    <td>
                    </td>                    
                    <td></td>
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
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItemByCountryId"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
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
                    
                     <asp:ObjectDataSource ID="odsCountry" runat="server" CacheDuration="120"
                        EnableCaching="True" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int64" />
                            <asp:Parameter DefaultValue="All" Name="name" Type="String" />
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
                    <asp:HiddenField ID="hdfResourceType" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
