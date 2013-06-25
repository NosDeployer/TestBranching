<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="employees_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_summary" Title="LFS Live"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Team Member Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mRole" Text="ROLE" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;" >                       
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />    
                                                    
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
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
                    <asp:Label ID="lblEmployeeDetails" runat="server" SkinID="LabelTitle1" Text="Employee Details"></asp:Label>
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
                    <asp:TextBox ID="tbxFisrtName" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxLastName" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxeMail" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
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
                    <asp:TextBox ID="tbxType" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxCategory" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxJobClassType" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxCrew" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxIsSalesman" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
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
                    <asp:Label ID="lblPersonalAgency" runat="server" EnableViewState="False" SkinID="Label" Text="Personnel Agency"></asp:Label>
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
                    <asp:CheckBox ID="ckbxSalaried" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxAssignableSrs" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxPersonalAgency" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxVacationsManager" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxRequestTimesheet" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
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
                    <asp:CheckBox ID="ckbxApproveTimesheets" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
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
                    <asp:CheckBox ID="ckbxField" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxField44" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxMechanicManufactoring" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxOfficeAdmin" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
                </td>                
                <td>
                    <asp:CheckBox ID="ckbxSpecialForces" runat="server" SkinID="CheckBox" onclick="return cbxClick();"></asp:CheckBox>
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
        
        <!-- Table element: 6 columns - Detailed Information title -->
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="0" CssClass="ajax_tabcontainer" Height="640px">
                        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="Costs" OnClientClick="tpCostDataClientClick">                        
                            <HeaderTemplate>
                                Costs
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div runat="server" id="dvLabourHourInformation" style="overflow-x: auto; overflow-y: hidden;
                                    width: 710px">
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
                                        </tr>
                                        <tr>
                                            <td  colspan="4">
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
                                                        <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" DataKeyNames="CostID" DataMember="DefaultView" 
                                                            DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound"  PageSize="13" 
                                                            SkinID="GridViewInTabs" Width="700px">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True"
                                                                            OnCheckedChanged="cbxSelectedCost_CheckedChanged" Width="25px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("Date", "{0:d}") %>' Width="120px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pay Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPayRateCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("PayRateCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Burden Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBurdenRateCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BurdenRateCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCostCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Benefit Factor (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBenefitFactorCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:TemplateField HeaderText="Pay Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPayRateUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("PayRateUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Burden Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBurdenRateUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCostUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Benefit Factor (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBenefitFactorUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:TemplateField HeaderText="Health Benefit (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHealthBenefitUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                 
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
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
                                            <td style="vertical-align: top">
                                                <asp:UpdatePanel ID="upCostsExceptions" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdCostsExceptions" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" DataKeyNames="CostID,RefID" 
                                                            DataMember="DefaultView" DataSourceID="odsCostsExceptions" 
                                                            OnDataBound="grdCostsExceptions_DataBound" PageSize="13" 
                                                            SkinID="GridViewInTabs">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Type of Work">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionTypeOfWork" runat="server" SkinID="Label" 
                                                                            Style="width: 100px" Text='<%# Bind("Work_") %>' Width="120px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Style="width: 85px" Text='<%# Bind("UnitOfMeasurement") %>' Width="100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pay Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionPayRateCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("PayRateCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Burden Rate (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBurdenRateCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BurdenRateCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionTotalCostCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Benefit Factor (CAD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBenefitFactorCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:TemplateField HeaderText="Pay Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionPayRateUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("PayRateUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Burden Rate (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBurdenRateUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionTotalCostUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("TotalCostUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Benefit Factor (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionBenefitFactorUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:TemplateField HeaderText="Health Benefit (USD)">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionHealthBenefitUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 30px">
                                                <asp:ObjectDataSource ID="odsCosts" runat="server" SelectMethod="GetCostsNew" FilterExpression="(Deleted = 0)"
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_summary">
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsCostsExceptions" runat="server" SelectMethod="GetCostsExceptionsNew" FilterExpression="(Deleted = 0)"
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_summary">
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
                                                    <asp:Label ID="lblTitleGrdVacations" runat="server" SkinID="Label" Text="Details"></asp:Label>
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
                                                <td>
                                                </td>
                                                <td style="height: 30px">
                                                    <asp:ObjectDataSource ID="odsVacations" runat="server" SelectMethod="GetVacationsNew" FilterExpression="(Deleted = 0)"
                                                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_summary">
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
                                                            DataSourceID="odsNotes" 
                                                            OnDataBound="grdNotes_DataBound"  DataKeyNames="EmployeeID, RefID" AllowPaging="True" AutoGenerateColumns="False"
                                                            PageSize="5">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="EmployeeID" Visible="False" HeaderText="EmployeeID">                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">                                                                    
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">                                                                    
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
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True"></asp:TextBox>
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
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">                                                                                       
                                                                                    </td>
                                                                                    <td style="width: 50%">                                                                                       
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
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetNotesNew"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_summary">
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