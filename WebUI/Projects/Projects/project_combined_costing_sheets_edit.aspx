<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm6.master" AutoEventWireup="true" CodeBehind="project_combined_costing_sheets_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProject" runat="server" Text="Project:" SkinID="LabelPageTitle2" EnableViewState="False"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuCurrentProject" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Current Project" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mProject" Text="Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectCostingSheets" Text="Project Costing Sheets" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSections" Text="Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectSynopsis" Text="Project Synopsis"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuProjects" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Projects" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddProject" Text="Add Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mDuplicateProposal" Text="Duplicate Proposal Tool" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mBallparkSummaryReport" Text="Ballpark Summary"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mTotalValueOfProposalsReport" Text="Total Value Of Proposals" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCurrentActiveWorkOnHandReport" Text="Current Active Work On Hand" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectsSummaryReport" Text="Projects Summary" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar2_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProductionReport" Text="Production Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVideoCompleteReport" Text="Video Complete Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mDetailedCostingSheetReport" Text="Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCombinedDetailedCostingSheetReport" Text="Combined Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mConsolidatedCostingSheetReport" Text="Consolidated Costing Sheet"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Table element: 1 columns - Section Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="True"></asp:Label>
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                    <asp:TextBox ID="tbxState" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 175px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: 1 column - grid Team Members -->
        <div runat="server" id="dvLabourHourInformation" style="overflow-x: auto; overflow-y: hidden;
            width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblTeamMembers" runat="server" SkinID="Label" Text="Labour Hours"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlTeamMembers" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdTeamMembers" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,EmployeeID,RefID"
                                    DataSourceID="odsTeamMembers" OnDataBound="grdTeamMembers_DataBound" OnRowDataBound="grdTeamMembers_RowDataBound" 
                                    PageSize="10" OnRowUpdating="grdTeamMembers_RowUpdating" OnRowDeleting="grdTeamMembers_RowDeleting" OnRowEditing="grdTeamMembers_RowEditing"
                                    OnRowCommand="grdTeamMembers_RowCommand">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="EmployeeID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeID" runat="server" SkinID="Label" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEmployeeIDEdit" runat="server" SkinID="Label" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%--3--%>                        
                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTypeOfWork" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxTypeOfWorkEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Work_") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlTypeOfWork_New" runat="server" SkinID="DropDownList"
                                                                    DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="Team Member">
                                            <HeaderStyle Width="95px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTeamMember" Width="95px" runat="server" SkinID="Label" Text='<%# Eval("Name") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxTeamMemberEdit" Width="95px" runat="server" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Name") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="95px" ID="ddlTeamMemberNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="FullName" DataMember="DefaultView" DataValueField="EmployeeID"
                                                                    DataSourceID="odsEmployee">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="From">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="labourHoursEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="labourHoursEdit" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="labourHoursNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="labourHoursNew" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="To">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--8--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/LH">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementLH" Width="105px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("LHUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementLHEdit" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLH">
                                                                </asp:DropDownList>    
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>                                                                
                                                                <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementLHNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLH">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--9--%>
                                        <asp:TemplateField HeaderText="LH Qty">
                                            <HeaderStyle Width="58px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblLHQty" Width="58px" runat="server" Text='<%# Eval("LHQuantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxLHQtyEdit" Width="58px" runat="server" Text='<%# Eval("LHQuantity", "{0:n2}") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvLHQtyEdit" runat="server" ControlToValidate="tbxLHQtyEdit" ErrorMessage="Please enter a quantity." 
                                                                ValidationGroup="labourHoursEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                             </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxLHQtyNew" Width="58px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvLHQtyNew" runat="server" ControlToValidate="tbxLHQtyNew" ErrorMessage="Please enter a quantity." 
                                                                ValidationGroup="labourHoursNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                             </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--10--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/Meals" Visible="false">
                                            <HeaderStyle Width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementMeals" Width="120px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("MealsUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMealsEdit" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLHMeals">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMealsNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLHMeals">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--11--%>
                                        <asp:TemplateField HeaderText="Meals Qty" Visible="false">
                                            <HeaderStyle Width="65px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMealsQty" Width="65px" runat="server" Text='<%# Eval("MealsQuantity") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxMealsQtyEdit" Width="65px" runat="server" Text='<%# Eval("MealsQuantity") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxMealsQtyNew" Width="65px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--12--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/Motel" Visible="false">
                                            <HeaderStyle Width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementMotel" Width="120px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("MotelUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMotelEdit" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLHMotel">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMotelNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLHMotel">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--13--%>
                                        <asp:TemplateField HeaderText="Motel Qty" Visible="false">
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMotelQty" Width="60px" runat="server" Text='<%# Eval("MotelQuantity") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxMotelQtyEdit" Width="60px" runat="server" Text='<%# Eval("MotelQuantity") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxMotelQtyNew" Width="60px" runat="server" SkinID="Textbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--14--%>
                                        <asp:TemplateField HeaderText="LH Cost (CAD)">
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblLHCostCAD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxLHCostCADEdit" Width="90px" runat="server" SkinID="TextBox" Text='<%# Eval("LHCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvLHCostCADEdit" runat="server" ControlToValidate="tbxLHCostCADEdit" ErrorMessage="Please enter a cost." 
                                                                    ValidationGroup="labourHoursCadEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvLHCostCADEdit" runat="server" ControlToValidate="tbxLHCostCADEdit" Display="Dynamic" ValidationGroup="labourHoursCadEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxLHCostCADNew" Width="90px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvLHCostCADNew" runat="server" ControlToValidate="tbxLHCostCADNew" ErrorMessage="Please enter a cost." 
                                                                    ValidationGroup="labourHoursCadNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvLHCostCADNew" runat="server" ControlToValidate="tbxLHCostCADNew" Display="Dynamic" ValidationGroup="labourHoursCadNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--15--%>
                                        <asp:TemplateField HeaderText="Meals Cost (CAD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMealsCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMealsCostCADEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                    Text='<%# Eval("MealsCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMealsCostCADEdit" runat="server" ControlToValidate="tbxMealsCostCADEdit" Display="Dynamic" ValidationGroup="labourHoursCadEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMealsCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMealsCostCADNew" runat="server" ControlToValidate="tbxMealsCostCADNew" Display="Dynamic" ValidationGroup="labourHoursCadNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--16--%>
                                        <asp:TemplateField HeaderText="Motel Cost (CAD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMotelCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMotelCostCADEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                    Text='<%# Eval("MotelCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMotelCostCADEdit" runat="server" ControlToValidate="tbxMotelCostCADEdit" Display="Dynamic" ValidationGroup="labourHoursCadEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMotelCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMotelCostCADNew" runat="server" ControlToValidate="tbxMotelCostCADNew" Display="Dynamic" ValidationGroup="labourHoursCadNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--17--%>
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--18--%>
                                        <asp:TemplateField HeaderText="LH Cost (USD)">
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblLHCostUSD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxLHCostUSDEdit" Width="90px" runat="server" SkinID="TextBox" Text='<%# Eval("LHCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvLHCostUSDEdit" runat="server" ControlToValidate="tbxLHCostUSDEdit" ErrorMessage="Please enter a cost." 
                                                                    ValidationGroup="labourHoursUsdEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvLHCostUSDEdit" runat="server" ControlToValidate="tbxLHCostUSDEdit" Display="Dynamic" ValidationGroup="labourHoursUsdEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxLHCostUSDNew" Width="90px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvLHCostUSDNew" runat="server" ControlToValidate="tbxLHCostUSDNew" ErrorMessage="Please enter a cost." 
                                                                    ValidationGroup="labourHoursUsdNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvLHCostUSDNew" runat="server" ControlToValidate="tbxLHCostUSDNew" Display="Dynamic" ValidationGroup="labourHoursUsdNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--19--%>
                                        <asp:TemplateField HeaderText="Meals Cost (USD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMealsCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMealsCostUSDEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                    Text='<%# Eval("MealsCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMealsCostUSDEdit" runat="server" ControlToValidate="tbxMealsCostUSDEdit" Display="Dynamic" ValidationGroup="labourHoursUsdEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMealsCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMealsCostUSDNew" runat="server" ControlToValidate="tbxMealsCostUSDNew" Display="Dynamic" ValidationGroup="labourHoursUsdNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--20--%>
                                        <asp:TemplateField HeaderText="Motel Cost (USD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMotelCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMotelCostUSDEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                    Text='<%# Eval("MotelCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMotelCostUSDEdit" runat="server" ControlToValidate="tbxMotelCostUSDEdit" Display="Dynamic" ValidationGroup="labourHoursUsdEdit"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxMotelCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMotelCostUSDNew" runat="server" ControlToValidate="tbxMotelCostUSDNew" Display="Dynamic" ValidationGroup="labourHoursUsdNew"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--21--%>
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--Buttons--%>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 500px;">
                                </td>
                                <td style="width: 155px; text-align: right;">
                                    <asp:Label ID="lblTeamMembersTotalCost" Width="155px" runat="server" SkinID="Label"
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxTeamMembersTotalCostCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxTeamMembersTotalCostUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Units-->
        <div runat="server" id="dvTrucksEquipment" style="overflow-x: auto; overflow-y: hidden; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnits" runat="server" SkinID="Label" Text="Trucks / Equipment Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlUnits" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdUnits" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,UnitID,RefID"
                                    DataSourceID="odsUnits" OnDataBound="grdUnits_DataBound" OnRowDataBound="grdUnits_RowDataBound"
                                    PageSize="10" OnRowUpdating="grdUnits_RowUpdating" OnRowDeleting="grdUnits_RowDeleting" OnRowEditing="grdUnits_RowEditing"
                                    OnRowCommand="grdUnits_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="UnitID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitID" runat="server" SkinID="Label" Text='<%# Eval("UnitID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblUnitIDEdit" runat="server" SkinID="Label" Text='<%# Eval("UnitID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                                                
                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTypeOfWork" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxTypeOfWorkEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Work_") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlTypeOfWork_New" runat="server" SkinID="DropDownList"
                                                                    DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit Code">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitCode" Width="50px" runat="server" SkinID="Label" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxUnitCodeEdit" Width="50px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("UnitCode") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="50px" ID="ddlUnitCodeNew" runat="server" SkinID="DropDownListLookup"
                                                                    EnableViewState="True" DataTextField="UnitCode" DataValueField="UnitID" DataSourceID="odsUnitCode">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitDescription" Width="120px" runat="server" SkinID="Label" Text='<%# Eval("UnitDescription") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="120px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxUnitDescriptionEdit" Width="120px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("UnitDescription") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxUnitDescriptionNew" Width="120px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="unitsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="unitsEdit" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="unitsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="unitsNew" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementUnitsEdit" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="90px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementUnitsNew" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="90px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityEdit" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="unitsEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="unitsNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsCadEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    Display="Dynamic" ValidationGroup="unitsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsCadNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    Display="Dynamic" ValidationGroup="unitsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="100px" runat="server" SkinID="TextBoxReadOnly"
                                                                    ReadOnly="true" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="100px" runat="server" SkinID="TextBoxReadOnly"
                                                                    ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" runat="server" Width="105px" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDEdit" runat="server" Width="105px" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsUsdEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    Display="Dynamic" ValidationGroup="unitsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsUsdNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    Display="Dynamic" ValidationGroup="unitsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--Buttons--%>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 625px;">
                                </td>
                                <td style="width: 110px; text-align: right;">
                                    <asp:Label ID="lblUnitsTotalCosts" Width="110px" runat="server" SkinID="Label"
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxUnitsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxUnitsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Materials-->
        <div runat="server" id="dvMaterial" style="overflow-x: auto; overflow-y: hidden; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMaterials" runat="server" SkinID="Label" Text="Material Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlMaterials" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdMaterials" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,MaterialID,RefID"
                                    DataSourceID="odsMaterials" OnDataBound="grdMaterials_DataBound" OnRowDataBound="grdMaterials_RowDataBound" 
                                    PageSize="10" OnRowUpdating="grdMaterials_RowUpdating" OnRowDeleting="grdMaterials_RowDeleting" OnRowEditing="grdMaterials_RowEditing"
                                    OnRowCommand="grdMaterials_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="MaterialID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterialID" runat="server" SkinID="Label" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblMaterialIDEdit" runat="server" SkinID="Label" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProcess" Width="55px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="55px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProcessEdit" Width="55px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("WorkFunction") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProcessNew" Width="55px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDescription" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxDescriptionEdit" Width="85px" runat="server" SkinID="TextBoxReadOnly"
                                                                    ReadOnly="true" Text='<%# Eval("Description") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlDescriptionNew" runat="server" SkinID="DropDownListLookup"
                                                                    EnableViewState="True" DataTextField="Description" DataValueField="MaterialID"
                                                                    DataSourceID="odsMaterialsList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="materialsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="materialsEdit" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="materialsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="materialsNew" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsEdit" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="85px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsNew" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="85px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityEdit" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="materialsEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="materialsNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsCadEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    Display="Dynamic" ValidationGroup="materialsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADNew" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsCadNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    Display="Dynamic" ValidationGroup="materialsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsUsdEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    Display="Dynamic" ValidationGroup="materialsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsUsdNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    Display="Dynamic" ValidationGroup="materialsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--Buttons--%>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 500px;">
                                </td>
                                <td style="width: 110px; text-align: right;">
                                    <asp:Label ID="lblMaterialsTotalCosts" Width="110px" runat="server" SkinID="Label"
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxMaterialsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxMaterialsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Subcontractors-->
        <div runat="server" id="dvSubcontractors" style="overflow-x: auto; overflow-y: hidden; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubcontractors" runat="server" SkinID="Label" Text="Subcontractors Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlSubcontractors" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdSubcontractors" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,SubcontractorID,RefID"
                                    DataSourceID="odsSubcontractors" OnDataBound="grdSubcontractors_DataBound" OnRowDataBound="grdSubcontractors_RowDataBound"
                                    PageSize="10" OnRowUpdating="grdSubcontractors_RowUpdating" OnRowDeleting="grdSubcontractors_RowDeleting" OnRowEditing="grdSubcontractors_RowEditing"
                                    OnRowCommand="grdSubcontractors_RowCommand">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--1--%>
                                        <asp:TemplateField HeaderText="SubcontractorID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcontractorID" runat="server" SkinID="Label" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblSubcontractorIDEdit" runat="server" SkinID="Label" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                                     
                                         <%--3--%>                        
                                        <asp:TemplateField HeaderText="Subcontractor">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSubcontractor" Width="50px" runat="server" SkinID="Label" Text='<%# Eval("Subcontractor") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="80px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxSubcontractorEdit" Width="80px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Subcontractor") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="80px" ID="ddlSubcontractorNew" runat="server" SkinID="DropDownListLookup"
                                                                    DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                                                                    DataSourceID="odsSubcontractorsList" EnableViewState="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--4--%>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="subcontractorsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="subcontractorsEdit" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="subcontractorsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="subcontractorsNew" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorsEdit" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorsEdit" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorsNew" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorsNew" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementSubcontractorsEdit" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementLH" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="90px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnitOfMeasurementSubcontractorsNew" runat="server" 
                                                                    DataSourceID="odsUnitsOfMeasurementLH" DataTextField="Description" 
                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                    Width="90px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--7--%>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityEdit" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="subcontractorsEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="subcontractorsNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--8--%>
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsCadEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    Display="Dynamic" ValidationGroup="subcontractorsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsCadNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    Display="Dynamic" ValidationGroup="subcontractorsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--9--%>
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="100px" runat="server" SkinID="TextBoxReadOnly"
                                                                    ReadOnly="true" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="100px" runat="server" SkinID="TextBoxReadOnly"
                                                                    ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--10--%>
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" runat="server" Width="105px" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDEdit" runat="server" Width="105px" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsUsdEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    Display="Dynamic" ValidationGroup="subcontractorsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsUsdNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    Display="Dynamic" ValidationGroup="subcontractorsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <%--11--%>
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--12--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxComment" Width="200px" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxCommentNew" Width="200px" runat="server" SkinID="TextBox" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--Buttons--%>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 345px;">
                                </td>
                                <td style="width: 117px; text-align: right;">
                                    <asp:Label ID="lblSubcontractorsTotalCosts" Width="117px" runat="server" SkinID="Label"
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <td style="width: 200px; text-align: right;">
                                </td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
               
        
        <!-- Page element: 1 column - grid Other Costs-->
        <div runat="server" id="dvOtherCost" style="overflow-x: auto; overflow-y: hidden; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOtherCosts" runat="server" SkinID="Label" Text="Misc Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlOtherCosts" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdOtherCosts" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefID" DataSourceID="odsOtherCosts"
                                    ShowFooter="true" OnDataBound="grdOtherCosts_DataBound" OnRowDataBound="grdOtherCosts_RowDataBound" OnRowEditing="grdOtherCosts_RowEditing"
                                    PageSize="10" OnRowUpdating="grdOtherCosts_RowUpdating" OnRowDeleting="grdOtherCosts_RowDeleting"
                                    OnRowCommand="grdOtherCosts_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false">
                                                </telerik:RadDatePicker>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblWorkFunction" Width="150px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="150px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="150px" ID="ddlWorkFunctionEdit" runat="server" SkinID="DropDownList"
                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="150px" ID="ddlWorkFunctionNew" runat="server" SkinID="DropDownList"
                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDescription" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxDescriptionEdit" Width="100px" runat="server" SkinID="TextBox"
                                                                    Text='<%# Eval("Description") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvDescriptionEdit" runat="server" ControlToValidate="tbxDescriptionEdit" 
                                                                    ErrorMessage="Please enter a description." ValidationGroup="otherCostsEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxDescriptionNew" Width="100px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" ControlToValidate="tbxDescriptionNew" 
                                                                    ErrorMessage="Please enter a description." ValidationGroup="otherCostsNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="otherCostsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="otherCostsEdit" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="otherCostsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="otherCostsNew" SkinID="Validator"
                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                    Style="width: 100px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                    Calendar-DayNameFormat="Short">
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew" 
                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew" 
                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlUnitOfMeasurementOthersEdit" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementOthers">
                                                                </asp:DropDownList>    
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>                                                              
                                                                <asp:DropDownList Width="85px" ID="ddlUnitOfMeasurementOthersNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementOthers">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityEdit" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="otherCostsEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew" 
                                                                ErrorMessage="Please enter a quantity." ValidationGroup="otherCostsNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsCadEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit" 
                                                                    Display="Dynamic" ValidationGroup="otherCostsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsCadNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew" 
                                                                    Display="Dynamic" ValidationGroup="otherCostsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDEdit" Width="105px" runat="server" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsUsdEdit" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit" 
                                                                    Display="Dynamic" ValidationGroup="otherCostsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsUsdNew" SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                </asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew" 
                                                                    Display="Dynamic" ValidationGroup="otherCostsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="100px" runat="server" ReadOnly="true"
                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--Buttons--%>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 605px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblOtherCostsTotalCosts" runat="server" SkinID="Label" 
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlOtherCostsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCostsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="unplOtherCostsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCostsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
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
        
        <!-- Table element: 5 columns - Detailed information title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
            <tr>
                <td colspan="2" style="width:50px;">
                </td>
                <td style="width:150px;">
                </td>
                <td style="width:130px;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td>                    
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblGrandTotalCost" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlTotalCostCad" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxTotalCostCad" runat="server" SkinID="TextBoxRightReadOnly"
                                Width="120px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter">
                            </asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upnlTotalCostUsd" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxTotalCostUsd" runat="server" SkinID="TextBoxRightReadOnly"
                                Width="120px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter">
                            </asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        
        <div runat="server" id="dvRevenue" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRevenueInformation" runat="server" SkinID="Label" Text="Revenue Information"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlRevenue" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRevenue" runat="server" SkinID="GridView" Width="700px" AllowPaging="True" OnRowEditing="grdRevenue_RowEditing" OnRowDataBound="grdRevenue_RowDataBound" OnDataBound="grdRevenue_DataBound"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefIDRevenue" DataSourceID="odsRevenue" PageSize="9">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="RefIDRevenue" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefIDRevenue" runat="server" SkinID="Label" Text='<%# Eval("RefIDRevenue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                    Text='<%# Eval("Project") %>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="150px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Revenue">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRevenue" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Revenue", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="400px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="400px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 155px; text-align: right;">
                                    <asp:Label ID="lblRevenueTotal" Width="155px" runat="server" SkinID="Label" Text="Total Revenue : "></asp:Label>
                                </td>
                                <td style="width: 110px; text-align: right;">
                                    <asp:UpdatePanel ID="upTotalRevenue" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxRevenueTotal" runat="server" SkinID="TextBoxRightReadOnly" Width="110px"
                                                ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height:7px">
                    </td>
                </tr>
            </table>
            
            <table cellpadding="0" cellspacing="0" width="0" style="width: 480px">
                <tr>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblRevenueSummary" runat="server" SkinID="Label" Text="Revenue Summary"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandRevenue" runat="server" Text="Revenue" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandProfit" runat="server" Text="Profit" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandGrossMargin" runat="server" Text="Gross Margin" SkinID="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbxGrandTotal" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandRevenue" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandProfit" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandGrossMargin" runat="server" SkinID="TextBoxRightReadOnly"
                            ReadOnly="true" Width="110px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCostingSheetId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" /> 
                    <asp:HiddenField ID="hdfCostingSheetName" runat="server" />
                    <asp:HiddenField ID="hdfFromDate" runat="server" />
                    <asp:HiddenField ID="hdfToDate" runat="server" />
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                    <asp:ObjectDataSource ID="odsTeamMembers" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLabourHoursInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit"
                        DeleteMethod="DummyTeamMembersNew" InsertMethod="DummyTeamMembersNew" UpdateMethod="DummyTeamMembersNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnits" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit"
                        DeleteMethod="DummyUnitsNew" InsertMethod="DummyUnitsNew" UpdateMethod="DummyUnitsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterials" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetMaterialsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit"
                        DeleteMethod="DummyMaterialsNew" InsertMethod="DummyMaterialsNew" UpdateMethod="DummyMaterialsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractors" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetSubcontractorsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit"
                        DeleteMethod="DummySubcontractorsNew" InsertMethod="DummySubcontractorsNew" UpdateMethod="DummySubcontractorsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherCosts" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetOtherCostsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit"
                        DeleteMethod="DummyOtherCostsNew" InsertMethod="DummyOtherCostsNew" UpdateMethod="DummyOtherCostsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemNoSubcontractor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWork_" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeWorkList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="work" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitCode" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" CacheDuration="60"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Materials.MaterialsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a material)" Name="description" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="materialId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <%--Units of measurement--%>
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLH" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                                             
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLHMotel" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members - Motel" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLHMeals" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members - Meals" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementUnits" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="FM / Units" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementMaterials" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Materials" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementOthers" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsRevenue" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRevenueInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_edit">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>