<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm7.Master" AutoEventWireup="true" CodeBehind="subcontractor_hours_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractor_hours_navigator2" %>

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
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one subcontractor hour."
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
            <tr>
                <td>
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Panel ID="pnlGrid" runat="server" Height="330px" Width="625px" ScrollBars="Auto">
                    
                        <asp:GridView ID="grdNavigator" runat="server" AutoGenerateColumns="False"
                         DataSourceID="odsNavigator" OnDataBound="grdNavigator_DataBound" OnRowDataBound="grdNavigator_RowDataBound"
                         OnSorting="grdNavigator_Sorting" AllowSorting="true"
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
                             
                    </asp:Panel> 
                    
                </td>
                
                <td style="vertical-align: top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnExportList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>                       
                        
                    </table>
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
                    
                    <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractor_hours_navigator2">
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