<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="employees_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Team Member Information" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleTeamMember" runat="server" Text="Team Member:" SkinID="LabelPageTitle2"></asp:Label>                    
                </td>
                <td>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Team Members" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddTeamMember" Text="Add Team Member"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mPersonalAgencies" Text="Personnel Agencies" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVacationsSetup" Text="Vacations Setup" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCostingSetup" Text="Job Costing Factors" ></telerik:RadPanelItem>
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
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;">  
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">        
        <!-- Table element: 1 columns - Employee Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeDetails" runat="server" SkinID="LabelTitle1" Text="Basic Information"
                        EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Employee Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblFirstName" runat="server" EnableViewState="False" SkinID="Label" Text="First Name"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblLastName" runat="server" EnableViewState="False" SkinID="Label" Text="Last Name"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lbleMail" runat="server" EnableViewState="False" SkinID="Label" Text="eMail"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxFisrtName" runat="server" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxLastName" runat="server" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxeMail" runat="server" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblType" runat="server" EnableViewState="False" SkinID="Label" Text="Type"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCategory" runat="server" EnableViewState="False" SkinID="Label" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblJobClassType" runat="server" EnableViewState="False" SkinID="Label" Text="Job Class"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCrew" runat="server" EnableViewState="False" SkinID="Label" Text="Crew"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIsSalesman" runat="server" EnableViewState="False" SkinID="Label" Text="Is Salesman?"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlType" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlType" runat="server" DataSourceID="odsType" DataTextField="Description"
                                                DataValueField="Type" SkinID="DropDownListLookup" Width="115px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" DataSourceID="odsState" DataTextField="Description"
                        DataValueField="State" SkinID="DropDownListLookup" Width="115px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="odsCategory" DataTextField="Category"
                        DataValueField="Category" SkinID="DropDownListLookup" Width="115px">
                    </asp:DropDownList>
                </td>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlJobClassType" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList Style="width: 115px" ID="ddlJobClassType" runat="server" SkinID="DropDownListLookup">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress ID="upJobClassType" runat="server" AssociatedUpdatePanelID="upnlType">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCrew" runat="server" DataSourceID="odsCrew" DataTextField="Crew"
                        DataValueField="Crew" SkinID="DropDownListLookup" Width="115px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" onclick="return cbxClick();" ID="ckbxIsSalesman"></asp:CheckBox>
                </td>                
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a category."
                        InitialValue="(Select a category)" SkinID="Validator" ValidationGroup="General">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                    <%--<asp:RequiredFieldValidator ID="rfvCrew" runat="server" ControlToValidate="ddlCrew"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a crew."
                        InitialValue="(Select a crew)" SkinID="Validator" ValidationGroup="General">
                    </asp:RequiredFieldValidator>--%>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIsSalaried" runat="server" EnableViewState="False" SkinID="Label" Text="Salaried"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIsAssignableSrs" runat="server" EnableViewState="False" SkinID="Label" Text="Assignable SR'S"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPersonalAgency" runat="server" EnableViewState="false" SkinID="Label" Text="Personnel Agency"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblVacationsManager" runat="server" EnableViewState="False" SkinID="Label" Text="Vacations Manager?"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRequestTimesheet" runat="server" EnableViewState="False" SkinID="Label" Text="Request Timesheet?"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxSalaried"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxAssignableSrs"></asp:CheckBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPersonalAgency" runat="server" DataSourceID="odsPersonalAgency" DataTextField="PersonalAgencyName"
                        DataValueField="PersonalAgencyName" SkinID="DropDownListLookup" Width="115px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxVacationsManager"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxRequestTimesheet"></asp:CheckBox>
                </td>
                <td>
                </td>  
            </tr>
        </table>
        
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
        
        <!-- Table element: 6 columns - Approve Timesheet Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">                    
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">                    
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">                    
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblApproveTimesheets" runat="server" SkinID="Label" Text="Approve Timesheets?"></asp:Label>
                </td>
                <td colspan="5">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxApproveTimesheets"></asp:CheckBox>
                </td>
                <td colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblCategoriesApproveTimesheets" runat="server" SkinID="Label" Text="Select the categories that the team member will be able to approve"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblField" runat="server" SkinID="Label" Text="Field"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblField44" runat="server" SkinID="Label" Text="Field 44"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMechanicManufactoring" runat="server" SkinID="LabelSmall" Text="Mechanic/Manufactoring"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOfficeAdmin" runat="server" SkinID="Label" Text="Office/Admin"></asp:Label>
                </td>                
                <td>
                    <asp:Label ID="lblSpecialForces" runat="server" SkinID="Label" Text="Special Forces"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckbxField" runat="server" SkinID="CheckBox"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxField44" runat="server" SkinID="CheckBox""></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxMechanicManufactoring" runat="server" SkinID="CheckBox"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxOfficeAdmin" runat="server" SkinID="CheckBox"></asp:CheckBox>
                </td>                
                <td>
                    <asp:CheckBox ID="ckbxSpecialForces" runat="server" SkinID="CheckBox"></asp:CheckBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:CustomValidator ID="cvCategoriesApproveTimesheets" Display="Dynamic" runat="server" ErrorMessage="You must select at least one category."
                        OnServerValidate="cvCategoriesApproveTimesheets_ServerValidate" SkinID="Validator" ValidationGroup="General"></asp:CustomValidator>
                </td>
            </tr>
        </table>
        
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
        
        <!-- Table element: 6 columns - Employees Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Tab Control -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>                
                    <!-- Page element : Tab control -->
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="1" CssClass="ajax_tabcontainer" Height="640px">
                        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="Costs" OnClientClick="tpCostDataClientClick">
                            <HeaderTemplate>
                                Costs
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div runat="server" id="dvLabourHourInformation" style="overflow-x: auto; overflow-y: hidden; width: 710px">
                                    <!-- Table element: 4 columns - Job Costing factors -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 175px; height: 10px;">
                                            </td>
                                            <td style="width: 175px">
                                            </td>
                                            <td style="width: 175px">
                                            </td>
                                            <td style="width: 175px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblbCostingFactors" runat="server" SkinID="Label" Text="Job Costing Factors"></asp:Label>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBourdenFactor" runat="server" SkinID="Label" Text="Burden Factor (%)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUSHealthBenefitFactor" runat="server" SkinID="Label" Text="US Health Benefit Factor (%)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBenefitFactorCad" runat="server" SkinID="Label" Text="Benefit Factor (CAD)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBenefitFactorUsd" runat="server" SkinID="Label" Text="Benefit Factor (USD)"></asp:Label>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxBourdenFactor" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 165px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxUSHealthBenefitFactor" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 165px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxBenefitFactorCad" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 165px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxBenefitFactorUsd" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 165px"></asp:TextBox>
                                            </td>
                                            <td></td>                                            
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblJoxCostingFactorsError" runat="server" SkinID="LabelError" Visible="false" Text="The team member don't have all job costing factors defined in the system."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">                                                
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 1 columns - Costs -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 700px; height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCostHistory" runat="server" SkinID="Label" Text="Cost History"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upCosts" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" ShowFooter="True" OnRowCommand="grdCosts_RowCommand" OnRowUpdating="grdCosts_RowUpdating" OnRowDeleting="grdCosts_RowDeleting"
                                                            AutoGenerateColumns="False" DataKeyNames="CostID" DataMember="DefaultView"  OnRowDataBound="grdCosts_RowDataBound" OnRowEditing="grdCosts_RowEditing"
                                                            DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound" PageSize="13" 
                                                            SkinID="GridViewInTabs" Width="700px">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True"
                                                                            OnCheckedChanged="cbxSelectedCost_CheckedChanged" Width="25px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("Date", "{0:d}") %>' Width="120px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" Width="120px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                    </telerik:RadDatePicker>
                                                                                </td>                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" ControlToValidate="tkrdpDateEdit"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="EditCost">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CustomValidator id="cvEditDate" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="EditCost" ControlToValidate="tkrdpDateEdit" ErrorMessage="You cannot add cost in that date." 
                                                                                        OnServerValidate="cvEditDate_ServerValidate"  ValidateEmptyText="True">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                                        
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadDatePicker ID="tkrdpDateNew" runat="server" Width="120px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                    </telerik:RadDatePicker>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateNew" runat="server" ControlToValidate="tkrdpDateNew"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="AddCost">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CustomValidator id="cvAddDate" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="AddCost" ControlToValidate="tkrdpDateNew" ErrorMessage="You cannot add cost in that date." 
                                                                                        OnServerValidate="cvAddDate_ServerValidate"  ValidateEmptyText="True">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="85px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementEdit" runat="server" SkinID="DropDownList"
                                                                        DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                        DataSourceID="odsUnitsOfMeasurementLH">
                                                                </asp:DropDownList>  
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementNew" runat="server" SkinID="DropDownList"
                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                    DataSourceID="odsUnitsOfMeasurementLH">
                                                                </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Pay Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPayRateCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PayRateCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxPayRateCadEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("PayRateCad"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvPayRateCadEdit" runat="server" ControlToValidate="tbxPayRateCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Please provide a pay rate." SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvPayRateCadEdit" runat="server" ControlToValidate="tbxPayRateCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxPayRateCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvPayRateCadNew" runat="server" ControlToValidate="tbxPayRateCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Please provide a pay rate." SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvPayRateCadNew" runat="server" ControlToValidate="tbxPayRateCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Burden Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBurdenRateCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BurdenRateCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBurdenRateCadEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Text='<%# GetRound(Eval("BurdenRateCad"),2) %>'></asp:TextBox>                                                                                
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBurdenRateCadNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCostCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxTotalCostCadEdit" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("TotalCostCad"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxTotalCostCadNew" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Benefit Factor (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBenefitFactorCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBenefitFactorCadEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>'></asp:TextBox>                                                                                
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>                                                                        
                                                                            <asp:TextBox Style="width: 70px" ID="tbxBenefitFactorCadNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Pay Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPayRateUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PayRateUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxPayRateUsdEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("PayRateUsd"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvPayRateUsdEdit" runat="server" ControlToValidate="tbxPayRateUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvPayRateUsdEdit" runat="server" ControlToValidate="tbxPayRateUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxPayRateUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvPayRateUsdNew" runat="server" ControlToValidate="tbxPayRateUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvPayRateUsdNew" runat="server" ControlToValidate="tbxPayRateUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Burden Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBurdenRateUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBurdenRateUsdEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>'></asp:TextBox>                                                                                
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                            <asp:TextBox Style="width: 70px" ID="tbxBurdenRateUsdNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                                                                                                        
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCostUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxTotalCostUsdEdit" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("TotalCostUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxTotalCostUsdNew" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Benefit Factor (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBenefitFactorUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBenefitFactorUsdEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                        Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>'></asp:TextBox>                                                                                
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxBenefitFactorUsdNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>                                                                                                                              
                                                                
                                                                <asp:TemplateField HeaderText="Health Benefit (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHealthBenefitUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxHealthBenefitUsdEdit" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxHealthBenefitUsdNew" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCostIDEdit" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="inDataBase" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInDataBase" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblInDataBase" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </EditItemTemplate>
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
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel"  
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" 
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
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit"  
                                                                                            CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" 
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
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCostExceptions" runat="server" SkinID="Label" Text="Cost Exceptions"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upCostsExceptions" runat="server">
                                                    <ContentTemplate>
                                                       <asp:GridView ID="grdCostsExceptions" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CostID,RefID" DataMember="DefaultView" OnRowEditing="grdCostsExceptions_RowEditing"
                                                            DataSourceID="odsCostsExceptions" ShowFooter="True" OnRowCommand="grdCostsExceptions_RowCommand" OnRowUpdating="grdCostsExceptions_RowUpdating" OnRowDeleting="grdCostsExceptions_RowDeleting"
                                                            OnDataBound="grdCostsExceptions_DataBound" OnRowDataBound="grdCostsExceptions_RowDataBound" PageSize="13" SkinID="GridViewInTabs">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Type of Work">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWork_" runat="server" SkinID="Label" Style="width: 100px"
                                                                            Text='<%# Bind("Work_") %>' Width="120px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList Style="width: 120px" ID="ddlExceptionWork_Edit" runat="server"
                                                                                        SkinID="DropDownList" DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionWork_Edit" runat="server" ControlToValidate="ddlExceptionWork_Edit"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a type of work." SkinID="Validator"
                                                                                        InitialValue="(Select)" ValidationGroup="EditCostException">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList Style="width: 120px" ID="ddlExceptionWork_New" runat="server" SkinID="DropDownList"
                                                                                        DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionWork_New" runat="server" ControlToValidate="ddlExceptionWork_New"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a type of work." SkinID="Validator"
                                                                                        InitialValue="(Select)" ValidationGroup="AddCostException">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList Width="105px" ID="ddlExceptionUnitOfMeasurementEdit" runat="server" SkinID="DropDownList"
                                                                            DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                            DataSourceID="odsUnitsOfMeasurementLH">
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList Width="105px" ID="ddlExceptionUnitOfMeasurementNew" runat="server" SkinID="DropDownList"
                                                                            DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                            DataSourceID="odsUnitsOfMeasurementLH">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Pay Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionPayRateCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PayRateCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxExceptionPayRateCadEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("PayRateCad"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionPayRateCadEdit" runat="server" ControlToValidate="tbxExceptionPayRateCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionPayRateCadEdit" runat="server" ControlToValidate="tbxExceptionPayRateCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxExceptionPayRateCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionPayRateCadNew" runat="server" ControlToValidate="tbxExceptionPayRateCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionPayRateCadNew" runat="server" ControlToValidate="tbxExceptionPayRateCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Burden Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBurdenRateCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BurdenRateCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBurdenRateCadEdit" runat="server"
                                                                            Text='<%# GetRound(Eval("BurdenRateCad"),2) %>' ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>                                                                                
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>                                                                        
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBurdenRateCadNew" runat="server"
                                                                           ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>                                                                        
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionTotalCostCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionTotalCostCadEdit" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("TotalCostCad"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionTotalCostCadNew" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Benefit Factor (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBenefitFactorCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBenefitFactorCadEdit" runat="server"
                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>'></asp:TextBox>                                                                              
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBenefitFactorCadNew" runat="server"
                                                                        SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                               
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Pay Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionPayRateUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PayRateUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxExceptionPayRateUsdEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("PayRateUsd"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionPayRateUsdEdit" runat="server" ControlToValidate="tbxExceptionPayRateUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionPayRateUsdEdit" runat="server" ControlToValidate="tbxExceptionPayRateUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 70px" ID="tbxExceptionPayRateUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionPayRateUsdNew" runat="server" ControlToValidate="tbxExceptionPayRateUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Please provide a pay rate."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionPayRateUsdNew" runat="server" ControlToValidate="tbxExceptionPayRateUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Burden Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBurdenRateUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBurdenRateUsdEdit" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBurdenRateUsdNew" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionTotalCostUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionTotalCostUsdEdit" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("TotalCostUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionTotalCostUsdNew" ReadOnly="true" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Benefit Factor (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBenefitFactorUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBenefitFactorUsdEdit" runat="server"
                                                                           SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionBenefitFactorUsdNew" runat="server"
                                                                        SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>                                                                               
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                 <asp:TemplateField HeaderText="Health Benefit (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionHealthBenefitUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionHealthBenefitUsdEdit" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox Style="width: 70px" ID="tbxExceptionHealthBenefitUsdNew" runat="server"
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>                                                                                
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostIDEdit" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefIDEdit" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="inDataBase" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInDataBase" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblInDataBase" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </EditItemTemplate>
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
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this exception?");'
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
                                            <td style="height: 30px">
                                                <asp:ObjectDataSource ID="odsCosts" runat="server" FilterExpression="(Deleted = 0)"
                                                    SelectMethod="GetCostsNew" 
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_edit"
                                                    DeleteMethod="DummyCostsNew" InsertMethod="DummyCostsNew" UpdateMethod="DummyCostsNew">
                                                </asp:ObjectDataSource>
                                                
                                                <asp:ObjectDataSource ID="odsCostsExceptions" runat="server" filterexpression="Deleted=0"
                                                    SelectMethod="GetCostsExceptionsNew" 
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_edit"
                                                    DeleteMethod="DummyCostsExceptionsNew" InsertMethod="DummyCostsExceptionsNew" UpdateMethod="DummyCostsExceptionsNew">            
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        <cc1:TabPanel ID="tpVacationsData" runat="server" HeaderText="Vacations" OnClientClick="tpVacationsDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 1 column  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px;">
                                                <asp:Label ID="lblNoExistVacations" runat="server" SkinID="LabelError" Visible="false" Text="The team member don't have vacations defined in the system."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upnlYear" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlYear" runat="server" SkinID="DropDownList" Width="100px"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <asp:UpdateProgress ID="upYear" runat="server" AssociatedUpdatePanelID="upnlYear">
                                                            <ProgressTemplate>
                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Panel element -->
                                    <asp:Panel ID="pnlVacations" runat="server" SkinID="PanelReadOnly" Width="705px">
                                        <!-- Table element: 4 columns  -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 700px">
                                            <tr>
                                                <td style="width: 10px; height: 10px;">
                                                </td>
                                                <td style="width: 230px;">
                                                </td>
                                                <td style="width: 230px;">
                                                </td
                                                <td style="width: 230px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMax" runat="server" Text="Max # of paid vacation days per Year" SkinID="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRemaining" runat="server" Text="Remaining Paid Vacation Days" SkinID="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotalApproved" runat="server" Text="Total Approved Vacations" SkinID="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlMax" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="tbxMax" runat="server" SkinID="TextBoxReadOnly" Width="220px" ReadOnly="true"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlRemaining" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="tbxRemaining" runat="server" SkinID="TextBoxReadOnly" Width="220px"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlTotalApproved" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="tbxTotalApproved" runat="server" SkinID="TextBoxReadOnly" Width="220px"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" height: 7px;" colspan="4">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <!-- Table element: 2 columns  -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 690px">
                                            <tr>
                                                <td style="width: 10px;">                                                    
                                                </td>
                                                <td style="width: 680px;">
                                                    <asp:Label ID="lblTitleGrdVacations" runat="server" SkinID="Label" Text="Vacations"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlVacations" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdVacations" runat="server" AllowPaging="True" 
                                                                AutoGenerateColumns="False" DataKeyNames="RequestID" DataMember="DefaultView" 
                                                                DataSourceID="odsVacations" OnDataBound="grdVacations_DataBound" PageSize="13" 
                                                                SkinID="GridViewInTabs" Width="680px">
                                                                <Columns>
                                                                
                                                                    <asp:TemplateField HeaderText="Start Date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStartDate" runat="server" SkinID="Label" 
                                                                                Text='<%# Bind("StartDate", "{0:d}") %>' Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="End Date">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEndDate" runat="server" SkinID="Label" 
                                                                                Text='<%# Bind("EndDate", "{0:d}") %>' Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="Total Paid Days">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTotalDays" runat="server" SkinID="Label" 
                                                                                Text='<%# Bind("TotalPaidVacationDays") %>' Width="120px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="State">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblState" runat="server" SkinID="Label" 
                                                                                Text='<%# Bind("State") %>' Width="110px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>                                            
                                            </tr>
                                            <tr>
                                                <td style="height: 30px">
                                                    <asp:ObjectDataSource ID="odsVacations" runat="server" SelectMethod="GetVacationsNew" FilterExpression="(Deleted = 0)"
                                                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_edit">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                        
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes" OnClientClick="tpNotesDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 5 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="5" colspan="5">
                                                <asp:UpdatePanel id="upnlNotes" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                            DataSourceID="odsNotes" OnRowUpdating="grdNotes_RowUpdating"
                                                            OnRowDeleting="grdNotes_RowDeleting" OnRowCommand="grdNotes_RowCommand" OnDataBound="grdNotes_DataBound"
                                                            DataKeyNames="EmployeeID,RefID" AllowPaging="True" AutoGenerateColumns="False"
                                                            ShowFooter="True" PageSize="5" onrowediting="grdNotes_RowEditing">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="EmployeeID" Visible="False" HeaderText="EmployeeID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w76"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w77"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject"
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit" __designer:wfdid="w78"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteDateEdit" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w79"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w80"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDateEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w81"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w82"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w83"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w84"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew" __designer:wfdid="w85"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w70"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w71"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w72"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w73"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w74"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w75"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Notes" HeaderText="Notes">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 160px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w64"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" TextMode="MultiLine" Rows="4"
                                                                                            __designer:wfdid="w65"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit" __designer:wfdid="w66"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 2 columns - Notes  information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w67"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" Rows="1" __designer:wfdid="w68"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew" __designer:wfdid="w69"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w62"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" ReadOnly="True" TextMode="MultiLine"
                                                                                            Rows="4" __designer:wfdid="w63"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this note?");'
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
                                                </contenttemplate> </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element: 6 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <HeaderTemplate>
                                Notes 
                            </HeaderTemplate>
                        </cc1:TabPanel>
                                 
                    </cc1:TabContainer>                
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
                
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                                        
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" 
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_edit"
                        DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="Load" 
                        TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeTypeGateway"
                        OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsPersonalAgency" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.PersonalAgencyList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="personalAgencyName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCrew" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.CrewList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="crew" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsState" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeStateGateway"
                        OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeCategoryList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a category)" Name="category" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWork_" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeWorkList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="work" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLH" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members" Name="module" Type="String" />
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
                    <asp:HiddenField ID="hdfCurrentEmployeeId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfResourceType" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />                    
                    <asp:HiddenField ID="hdfLoginId" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>