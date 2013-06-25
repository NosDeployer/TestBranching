<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm7.Master" AutoEventWireup="true" CodeBehind="actual_costs_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Actual Costs" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Actual Costs" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddActualCosts" Text="Add Actual Costs"></telerik:RadPanelItem>                                    
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
                                    <telerik:RadPanelItem runat="server" Value="mAddCategoryItems" Text="Add Category Items" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mActualCostsReport" Text="Print Actual Costs" ></telerik:RadPanelItem>
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
        <asp:Panel ID="pnlClientProjectSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 730px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 130px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                    </td>
                    <td  colspan="2">
                        <asp:Label ID="lblProject" runat="server" EnableViewState="False" SkinID="Label" Text="Project"></asp:Label>
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td  colspan="2">
                        <asp:UpdatePanel id="upnlClient" runat="server" >
                            <contenttemplate>
                                <asp:DropDownList id="ddlClient" EnableViewState="true" runat="server" SkinID="DropDownListLookup" Width="290px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td  colspan="2">
                        <asp:UpdatePanel id="upnlProject" runat="server">
                            <contenttemplate>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 290px">
                                                <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="290px"  EnableViewState="true"></asp:DropDownList>
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
                                <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" ></asp:AsyncPostBackTrigger>
                            </triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="text-align: right">                        
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel> 
        
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 730px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 150px">
                        <asp:Label ID="lblCategory" runat="server" SkinID="Label" Text="Category" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 150px">                        
                    </td>
                    <td style="width: 200px">                        
                        <asp:Label ID="lblTextForSearch" runat="server" EnableViewState="False" SkinID="Label" Text="Rate Usd/Cad"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 130px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel id="upnlCategory" runat="server" >
                            <contenttemplate>
                               <asp:DropDownList ID="ddlCategory" runat="server"
                                    SkinID="DropDownList" Width="140px" AutoPostBack="True"  EnableViewState="true" 
                                    onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                                    <asp:ListItem Value="All" Text="(All)"></asp:ListItem>
                                    <asp:ListItem Value="Subcontractors" Text="Subcontractors"></asp:ListItem>
                                    <asp:ListItem Value="Rentals" Text="Rentals"></asp:ListItem>
                                    <asp:ListItem Value="Hotels" Text="Hotels"></asp:ListItem>
                                    <asp:ListItem Value="Bonding" Text="Bonding"></asp:ListItem>
                                    <asp:ListItem Value="Fuel" Text="Fuel"></asp:ListItem>
                                    <asp:ListItem Value="Traffic Control" Text="Traffic Control"></asp:ListItem>
                                    <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                    <asp:ListItem Value="Permits" Text="Permits"></asp:ListItem>
                                    <asp:ListItem Value="Insurance" Text="Insurance"></asp:ListItem>                            
                                    <asp:ListItem Value="Meals" Text="Meals"></asp:ListItem>
                                    <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                </asp:DropDownList>
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                         <asp:UpdatePanel id="upnlCategoryValues" runat="server" UpdateMode="Always">
                            <contenttemplate>                                                                
                                <asp:DropDownList Width="140px" ID="ddlSubcontractor" runat="server" SkinID="DropDownList"
                                    DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"  EnableViewState="true"
                                    DataSourceID="odsSubcontractorsList">
                                </asp:DropDownList>                                                           
                                
                                <asp:DropDownList ID="ddlHotels" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                    DataMember="DefaultView" DataValueField="COMPANIES_ID"  EnableViewState="true"
                                    DataSourceID="odsHotelsList"
                                    Width="140px">
                                </asp:DropDownList> 
                                
                                <asp:DropDownList ID="ddlBonding" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                    DataMember="DefaultView" DataValueField="COMPANIES_ID" DataSourceID="odsBondingList"  EnableViewState="true"
                                    Width="140px">
                                </asp:DropDownList>
                                
                                <asp:DropDownList ID="ddlInsurance" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                    DataMember="DefaultView" DataValueField="COMPANIES_ID" DataSourceID="odsInsuranceList"  EnableViewState="true"
                                    Width="140px">
                                </asp:DropDownList>                                                                                          
                            </contenttemplate>
                        </asp:UpdatePanel>                        
                    </td>
                    <td>
                         <asp:TextBox ID="tbxTextForSearch" Width="190px" runat="server" SkinID="TextBox" EnableViewState="true">%</asp:TextBox>                            
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 90px" EnableViewState="true">                            
                            <asp:ListItem Text="Client" Value="Client" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Project" Value="Project"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px"
                            OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
                
        <asp:Panel ID="pnpFilterByDate" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 300px" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       <asp:CheckBox ID="cbxFilterByRangeOfDates" runat="server" Text="Filter By Range of Dates" SkinID="CheckBox"  EnableViewState="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="140px"  EnableViewState="true"
                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upnlEndDate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="140px"  EnableViewState="true"
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
                    
                    <asp:ObjectDataSource ID="odsHotelsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Hotels.HotelsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="hotelId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsuranceList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="insuranceCompanyId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondingList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesList">
                        <SelectParameters>                            
                            <asp:Parameter DefaultValue="-1" Name="bondingCompanyId" Type="Int32" />
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

