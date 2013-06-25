<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm7.Master" AutoEventWireup="true" CodeBehind="actual_costs_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2" %>

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
                                <asp:DropDownList id="ddlClient" runat="server" SkinID="DropDownListLookup" Width="290px"  EnableViewState="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
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
                                    SkinID="DropDownList" Width="140px" AutoPostBack="True"   EnableViewState="true"
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
                         <asp:TextBox ID="tbxTextForSearch" Width="190px" runat="server" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>                            
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 90px" EnableViewState="True" >                            
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
        
        <!-- Page element: Section title - Results-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one category cost."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="width: 625px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
        </table>                
                        
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">                             
            <tr>
                <td style="vertical-align: top">
                
                    <asp:UpdatePanel ID="upnlGrids" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        
                            <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                             
                                    <tr>
                                        <td style="vertical-align: top; width:615px">
                                                                                    
                                            <asp:Panel ID="pnlGridData" runat="server" Height="330px" Width="615px" ScrollBars="Auto" SkinID="Panel">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%"> 
                                                    <tr>
                                                        <td  style="vertical-align: top">                                       
                                                             <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                 <tr>
                                                                    <td style="height: 10px">
                                                                    </td>
                                                                 </tr>
                                                                 <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSubcontractorLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                            Text="Subcontractor Costs"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSubcontratorRowsLabel" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Subcontractor Costs Rows"></asp:Label>
                                                                        <asp:CustomValidator ID="cvSubcontractorGrid" runat="server" ErrorMessage="Please select one subcontractor cost."
                                                                            Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                                                                    </td>                                                                    
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="grdSubcontractorNavigator" runat="server" AutoGenerateColumns="False"
                                                                         DataSourceID="odsNavigator" OnDataBound="grdSubcontractorNavigator_DataBound" OnRowDataBound="grdSubcontractorNavigator_RowDataBound"
                                                                         OnSorting="grdSubcontractorNavigator_Sorting" AllowSorting="true"
                                                                         DataKeyNames="SubcontractorID,ProjectID,RefID" SkinID="GridView" Width="600px">
                                                                            <Columns>
                                                                                                 
                                                                                <%--Column 0--%>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle HorizontalAlign="Center" />                            
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                            Checked='<%# Eval("Selected") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 1--%>
                                                                                <asp:TemplateField HeaderText="SubcontractorID" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSubcontractorID" runat="server" Style="width: 1px" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 2--%>
                                                                                <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblProjectID" runat="server" Style="width: 1px" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 3--%>
                                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRefIDID" runat="server" Style="width: 1px" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 4--%>
                                                                                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                                    <ItemStyle HorizontalAlign="Center" />                            
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDate" runat="server" Style="width: 100px" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                                                
                                                                                <%--Column 5--%>
                                                                                <asp:TemplateField HeaderText="Subcontractor" SortExpression="Subcontractor">                                    
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSubcontractor" runat="server" Style="width: 200px" Text='<%# Eval("Subcontractor") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="200px" />
                                                                                </asp:TemplateField>

                                                                                <%--Column 6--%>                                         
                                                                                <asp:TemplateField HeaderText="Client" SortExpression="Client">                                                              
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClient" runat="server" Style="width: 200px" Text='<%# Eval("Client") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="200px" />
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 7--%>                               
                                                                                <asp:TemplateField HeaderText="Project" SortExpression="Project">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblProject" runat="server" Style="width: 200px" Text='<%# Eval("Project") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="200px" />
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 8--%>
                                                                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblQuantity" runat="server" Width="100px" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 9--%>
                                                                                <asp:TemplateField HeaderText="Rate" SortExpression="RateCad">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateCad"),2) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="70px" />
                                                                                </asp:TemplateField>                               
                                                                                
                                                                                <%--Column 10--%>
                                                                                <asp:TemplateField HeaderText="Total" SortExpression="TotalCad">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTotalCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("TotalCad"),2) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="70px" />
                                                                                </asp:TemplateField>
                                                                                
                                                                                <%--Column 11--%>
                                                                                <asp:TemplateField HeaderText="Rate" SortExpression="RateUsd" Visible="false">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateUsd"),2) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="70px" />
                                                                                </asp:TemplateField>                               
                                                                                
                                                                                <%--Column 12--%>
                                                                                <asp:TemplateField HeaderText="Total" SortExpression="TotalUsd" Visible="false">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTotalUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("TotalUsd"),2) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="70px" />
                                                                                </asp:TemplateField>
                                                                                
                                                                            </Columns>
                                                                        </asp:GridView>     
                                                                    </td>
                                                                </tr>                                   
                                                            </table>  
                                                        </td>                                                              
                                                    </tr>                                                                                
                                                </table>
                                            </asp:Panel>
                                        </td>                
                                        <td style="vertical-align: top;  width:125px">
                                            <!-- Page element : Buttons -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                                        Style="width: 80px" OnClick="btnSubcontractorsOpen_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                                            Style="width: 80px" OnClick="btnSubcontractorsEdit_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsExportList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                            Text="Delete" Style="width: 80px" OnClick="btnSubcontractorsDelete_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSubcontractorsClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                                                    </td>
                                                </tr>  
                                            </table>
                                        </td>                        
                                    </tr>
                                </table>        
                            </asp:Panel>
                            
                            <asp:Panel ID="pnlHotelGrid" runat="server" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                             
                                    <tr>
                                        <td style="vertical-align: top; width:615px">
                                            <!-- Page element : Grid -->
                                            <asp:Panel ID="pnlHotelGridData" runat="server" Height="230px" Width="615px" ScrollBars="Auto"  SkinID="Panel">   
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                     </tr>
                                                     <tr>
                                                        <td>
                                                            <asp:Label ID="lblHotelLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                Text="Hotel Costs"></asp:Label></td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblHotelRowsLabel" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="Hotel Rows"></asp:Label>
                                                            <asp:CustomValidator ID="cvHotelsGrid" runat="server" ErrorMessage="Please select one hotel cost."
                                                              Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                                                        </td>                                                                                                              
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdHotelNavigator" runat="server" AutoGenerateColumns="False"
                                                                 DataSourceID="odsHotelNavigator" OnDataBound="grdHotelNavigator_DataBound" OnRowDataBound="grdHotelNavigator_RowDataBound"
                                                                 OnSorting="grdHotelNavigator_Sorting" AllowSorting="true"
                                                                 DataKeyNames="ProjectID,RefID" SkinID="GridView" Width="600px">
                                                                    <Columns>
                                                                                         
                                                                        <%--Column 0--%>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle HorizontalAlign="Center" />                            
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxHotelSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                    Checked='<%# Eval("Selected") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 1--%>
                                                                        <asp:TemplateField HeaderText="HotelID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelID" runat="server" Style="width: 1px" Text='<%# Eval("HotelID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 2--%>
                                                                        <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelProjectID" runat="server" Style="width: 1px" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                
                                                                        <%--Column 3--%>
                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelRefID" runat="server" Style="width: 1px" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 4--%>
                                                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                            <ItemStyle HorizontalAlign="Center" />                            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelDate" runat="server" Style="width: 100px" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                                        
                                                                        <%--Column 5--%>
                                                                        <asp:TemplateField HeaderText="Hotel" SortExpression="Hotel">                                    
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotel" runat="server" Style="width: 200px" Text='<%# Eval("Hotel") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>

                                                                        <%--Column 6--%>                                         
                                                                        <asp:TemplateField HeaderText="Client" SortExpression="Client">                                                              
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelClient" runat="server" Style="width: 200px" Text='<%# Eval("Client") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 7--%>                               
                                                                        <asp:TemplateField HeaderText="Project" SortExpression="Project">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelProject" runat="server" Style="width: 200px" Text='<%# Eval("Project") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>                                                                              
                                                                        
                                                                        <%--Column 8--%>
                                                                        <asp:TemplateField HeaderText="Rate" SortExpression="RateCad">
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateCad"),2) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="70px" />
                                                                        </asp:TemplateField> 
                                                                        
                                                                        <%--Column 9--%>
                                                                        <asp:TemplateField HeaderText="Rate" SortExpression="RateUsd" Visible="false">
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHotelRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateUsd"),2) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="70px" />
                                                                        </asp:TemplateField>                                                                       
                                                                        
                                                                    </Columns>
                                                                </asp:GridView> 
                                                        </td>
                                                    </tr>
                                                </table>       
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: top;  width:125px">
                                            <!-- Page element : Buttons -->
                                             <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                                        Style="width: 80px" OnClick="btnHotelsOpen_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                                            Style="width: 80px" OnClick="btnHotelsEdit_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsExportList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                            Text="Delete" Style="width: 80px" OnClick="btnHotelsDelete_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnHotelsClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                                                    </td>
                                                </tr>  
                                            </table>
                                       
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            
                            <asp:Panel ID="pnlInsuranceGrid" runat="server" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                             
                                    <tr>
                                        <td style="vertical-align: top; width:615px">
                                            <!-- Page element : Grid -->
                                            <asp:Panel ID="pnlInsuranceGridData" runat="server" Height="230px" Width="615px" ScrollBars="Auto" SkinID="Panel">   
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                     </tr>
                                                     <tr>
                                                        <td>
                                                            <asp:Label ID="lblInsuranceLable" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                Text="Insurance Company Costs"></asp:Label></td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInsuranceRowsLabel" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="Insurance Costs Rows"></asp:Label>
                                                            <asp:CustomValidator ID="cvInsuranceGrid" runat="server" ErrorMessage="Please select one insurance company cost."
                                                              Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                                                        </td>                                                       
                                                    </tr>
                                                    <tr>
                                                        <td> 
                                                            <asp:GridView ID="grdInsuranceNavigator" runat="server" AutoGenerateColumns="False"
                                                                 DataSourceID="odsInsuranceNavigator" OnDataBound="grdInsuranceNavigator_DataBound" OnRowDataBound="grdInsuranceNavigator_RowDataBound"
                                                                 OnSorting="grdInsuranceNavigator_Sorting" AllowSorting="true"
                                                                 DataKeyNames="ProjectID,RefID" SkinID="GridView" Width="600px">
                                                                    <Columns>
                                                                                         
                                                                        <%--Column 0--%>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle HorizontalAlign="Center" />                            
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxInsuranceSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                    Checked='<%# Eval("Selected") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 1--%>
                                                                        <asp:TemplateField HeaderText="InsuranceCompanyID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceCompanyID" runat="server" Style="width: 1px" Text='<%# Eval("InsuranceCompanyID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 2--%>
                                                                        <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceProjectID" runat="server" Style="width: 1px" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 3--%>
                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceRefID" runat="server" Style="width: 1px" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 4--%>
                                                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                            <ItemStyle HorizontalAlign="Center" />                            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceDate" runat="server" Style="width: 100px" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                                        
                                                                        <%--Column 5--%>
                                                                        <asp:TemplateField HeaderText="Insurance" SortExpression="Insurance">                                    
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsurance" runat="server" Style="width: 200px" Text='<%# Eval("Insurance") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>

                                                                        <%--Column 6--%>                                         
                                                                        <asp:TemplateField HeaderText="Client" SortExpression="Client">                                                              
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceClient" runat="server" Style="width: 200px" Text='<%# Eval("Client") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Column 7--%>                               
                                                                        <asp:TemplateField HeaderText="Project" SortExpression="Project">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceProject" runat="server" Style="width: 200px" Text='<%# Eval("Project") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>                                                                              
                                                                        
                                                                        <%--Column 8--%>
                                                                        <asp:TemplateField HeaderText="Rate" SortExpression="RateCad">
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateCad"),2) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="70px" />
                                                                        </asp:TemplateField> 
                                                                        
                                                                        <%--Column 9--%>
                                                                        <asp:TemplateField HeaderText="Rate" SortExpression="RateUsd" Visible="false">
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInsuranceRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateUsd"),2) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="70px" />
                                                                        </asp:TemplateField>                                                                       
                                                                        
                                                                    </Columns>
                                                                </asp:GridView>  
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: top;  width:125px">
                                            <!-- Page element : Buttons -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsuranceOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                                        Style="width: 80px" OnClick="btnInsuranceOpen_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsuranceEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                                            Style="width: 80px" OnClick="btnInsuranceEdit_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsurancePreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsuranceExportList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsuranceDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                            Text="Delete" Style="width: 80px" OnClick="btnInsuranceDelete_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnInsuranceClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                                                    </td>
                                                </tr>  
                                            </table>
                                       
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            
                            <asp:Panel ID="pnlBondingGrid" runat="server" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                             
                                    <tr>
                                        <td style="vertical-align: top; width:615px">
                                            <!-- Page element : Grid -->
                                            <asp:Panel ID="pnlBondingGridData" runat="server" Height="230px" Width="615px" ScrollBars="Auto" SkinID="Panel">              
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                     </tr>
                                                     <tr>
                                                        <td>
                                                            <asp:Label ID="lblBondingLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                Text="Bonding Company Costs"></asp:Label></td>                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblBondingRowsLabel" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="bonding Costs Rows"></asp:Label>
                                                            <asp:CustomValidator ID="cvBondingGrid" runat="server" ErrorMessage="Please select one bonding company cost."
                                                              Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                                                        </td>                                        
                                                    </tr>
                                                    <tr>
                                                        <td>     
                                                            <asp:GridView ID="grdBondingNavigator" runat="server" AutoGenerateColumns="False"
                                                             DataSourceID="odsBondingNavigator" OnDataBound="grdBondingNavigator_DataBound" OnRowDataBound="grdBondingNavigator_RowDataBound"
                                                             OnSorting="grdBondingNavigator_Sorting" AllowSorting="true"
                                                             DataKeyNames="ProjectID,RefID" SkinID="GridView" Width="600px">
                                                                <Columns>
                                                                                             
                                                                    <%--Column 0--%>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbxBondingSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                Checked='<%# Eval("Selected") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 1--%>
                                                                    <asp:TemplateField HeaderText="BondingCompanyID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingCompanyID" runat="server" Style="width: 1px" Text='<%# Eval("BondingCompanyID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 2--%>
                                                                    <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingProjectID" runat="server" Style="width: 1px" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 3--%>
                                                                    <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingRefID" runat="server" Style="width: 1px" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 4--%>
                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingDate" runat="server" Style="width: 100px" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                                                    
                                                                    <%--Column 5--%>
                                                                    <asp:TemplateField HeaderText="Bonding" SortExpression="Bonding">                                    
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBonding" runat="server" Style="width: 200px" Text='<%# Eval("Bonding") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>

                                                                    <%--Column 6--%>                                         
                                                                    <asp:TemplateField HeaderText="Client" SortExpression="Client">                                                              
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingClient" runat="server" Style="width: 200px" Text='<%# Eval("Client") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 7--%>                               
                                                                    <asp:TemplateField HeaderText="Project" SortExpression="Project">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingProject" runat="server" Style="width: 200px" Text='<%# Eval("Project") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>                                                                              
                                                                    
                                                                    <%--Column 8--%>
                                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RateCad">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateCad"),2) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="70px" />
                                                                    </asp:TemplateField> 
                                                                    
                                                                    <%--Column 9--%>
                                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RateUsd" Visible="false">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBondingRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateUsd"),2) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="70px" />
                                                                    </asp:TemplateField>                                                                       
                                                                    
                                                                </Columns>
                                                            </asp:GridView>     
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: top;  width:125px">
                                            <!-- Page element : Buttons -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                                        Style="width: 80px" OnClick="btnBondingOpen_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                                            Style="width: 80px" OnClick="btnBondingEdit_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingExportList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                            Text="Delete" Style="width: 80px" OnClick="btnBondingDelete_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBondingClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                                                    </td>
                                                </tr>  
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            
                            <asp:Panel ID="pnlOtherGrid" runat="server" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                             
                                    <tr>
                                        <td style="vertical-align: top; width:615px">                                        
                                            <!-- Page element : Grid -->
                                            <asp:Panel ID="pnlOtherGridData" runat="server" Height="230px" Width="615px" ScrollBars="Auto" SkinID="Panel">           
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                                                
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                     </tr>
                                                     <tr>
                                                        <td>
                                                            <asp:Label ID="lblOtherLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                Text="Other Costs"></asp:Label></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOtherRowsLabel" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="OtherRows Costs"></asp:Label>
                                                            <asp:CustomValidator ID="cvOtherCostsGrid" runat="server" ErrorMessage="Please select a cost."
                                                              Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                                                        </td>                                        
                                                    </tr>
                                                    <tr>
                                                        <td>         
                                                            <asp:GridView ID="grdOtherNavigator" runat="server" AutoGenerateColumns="False"
                                                             DataSourceID="odsOtherNavigator" OnDataBound="grdOtherNavigator_DataBound" OnRowDataBound="grdOtherNavigator_RowDataBound"
                                                             OnSorting="grdOtherNavigator_Sorting" AllowSorting="true"
                                                             DataKeyNames="ProjectID,RefID" SkinID="GridView" Width="600px">
                                                                <Columns>
                                                                                     
                                                                    <%--Column 0--%>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbxOtherSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                Checked='<%# Eval("Selected") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 1--%>
                                                                    <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherProjectID" runat="server" Style="width: 1px" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 2--%>
                                                                    <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherRefID" runat="server" Style="width: 1px" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 3--%>
                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherDate" runat="server" Style="width: 100px" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                                                    
                                                                    <%--Column 4--%>
                                                                    <asp:TemplateField HeaderText="Category" SortExpression="Category">                                    
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategory" runat="server" Style="width: 200px" Text='<%# Eval("Category") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>

                                                                    <%--Column 5--%>                                         
                                                                    <asp:TemplateField HeaderText="Client" SortExpression="Client">                                                              
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherClient" runat="server" Style="width: 200px" Text='<%# Eval("Client") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>
                                                                    
                                                                    <%--Column 6--%>                               
                                                                    <asp:TemplateField HeaderText="Project" SortExpression="Project">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherProject" runat="server" Style="width: 200px" Text='<%# Eval("Project") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" />
                                                                    </asp:TemplateField>                                                                              
                                                                    
                                                                    <%--Column 7--%>
                                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RateCad">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateCad"),2) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="70px" />
                                                                    </asp:TemplateField> 
                                                                    
                                                                    <%--Column 8--%>
                                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RateUsd" Visible="false">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOtherRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("RateUsd"),2) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="70px" />
                                                                    </asp:TemplateField>                                                                       
                                                                    
                                                                </Columns>
                                                            </asp:GridView>     
                                                        </td>
                                                    </tr>
                                                </table> 
                                            </asp:Panel>
                                                                                       
                                        </td>
                                        <td style="vertical-align: top;  width:125px">
                                            <!-- Page element : Buttons -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                                        Style="width: 80px" OnClick="btnOtherCostsOpen_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                                            Style="width: 80px" OnClick="btnOtherCostsEdit_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsExportList" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                            Text="Delete" Style="width: 80px" OnClick="btnOtherCostsDelete_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOtherCostsClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                                            Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                                                    </td>
                                                </tr>  
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                                                                                                                                                                                                                                                                                                                                                                          
                        </ContentTemplate>
                    </asp:UpdatePanel>                            
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
                    
                    <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsHotelNavigator" runat="server" SelectMethod="GetHotelNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsuranceNavigator" runat="server" SelectMethod="GetInsuranceCompaniesNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondingNavigator" runat="server" SelectMethod="GetBondingCompaniesNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherNavigator" runat="server" SelectMethod="GetOtherNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_navigator2">
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