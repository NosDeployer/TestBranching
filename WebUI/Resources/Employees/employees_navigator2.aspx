<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master"  AutoEventWireup="true" CodeBehind="employees_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_navigator2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Team Members" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Team Members" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddTeamMember" Text="Add Team Member"></telerik:RadPanelItem>
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
        <!-- Page element: Search & Sort components , 6 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td colspan="3">
                    </td>
                    <td style="width: 135px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px"
                            EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForConditionList"
                            DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 345px" SkinID="TextBox"
                            EnableViewState="False">%</asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 125px"
                            EnableViewState="False" DataMember="DefaultView" DataSourceID="odsSortByList"
                            DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px"
                            OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                      <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDecimalNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use an decimal number, % or leave the field empty)" 
                            OnServerValidate="cvForDecimalNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 7px">
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
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one team member."
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
                         DataSourceID="odsNavigator" OnDataBound="grdNavigator_DataBound" 
                         OnSorting="grdNavigator_Sorting" AllowSorting="true"
                         DataKeyNames="EmployeeID" SkinID="GridView" Width="600px">
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
                                <asp:TemplateField HeaderText="EmployeeID" Visible ="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeId" runat="server" Style="width: 100px" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 2--%>
                                <asp:TemplateField HeaderText="LoginID" Visible ="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLoginId" runat="server" Style="width: 100px" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 3--%>
                                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">                                    
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstName" runat="server" Style="width: 150px" Text='<%# Eval("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                                                
                                <%--Column 4--%>
                                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">                                    
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastName" runat="server" Style="width: 200px" Text='<%# Eval("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>

                                <%--Column 5--%>                                         
                                <asp:TemplateField HeaderText="Email" SortExpression="eMail">                                                              
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Style="width: 200px" Text='<%# Eval("eMail") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                
                                <%--Column 6--%>                               
                                <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Style="width: 200px" Text='<%# GetType(Eval("Type")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                
                                <%--Column 7--%>
                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Style="width: 200px" Text='<%# GetState(Eval("State")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                
                                <%--Column 8--%>
                                <asp:TemplateField HeaderText="Category" SortExpression="Category">                                    
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Style="width: 200px" Text='<%# Eval("Category") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                
                                <%--Column 9--%>
                                <asp:TemplateField HeaderText="Job Class" SortExpression="JobClassType">                                    
                                    <ItemTemplate>
                                        <asp:Label ID="lblJobClassType" runat="server" Style="width: 200px" Text='<%# Eval("JobClassType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                                                
                                <%--Column 10--%>                               
                                <asp:TemplateField HeaderText="Is Salesman?" SortExpression="IsSalesman">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIsSalesman" runat="server" Checked='<%# Eval("IsSalesman") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 11--%> 
                                <asp:TemplateField HeaderText="Approve Timesheets?" SortExpression="ApproveTimesheets">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxApproveTimesheets" runat="server" Checked='<%# Eval("ApproveTimesheets") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 12--%> 
                                <asp:TemplateField HeaderText="Request Timesheet?" SortExpression="RequestProjectTime">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxRequestProjectTime" runat="server" Checked='<%# Eval("RequestProjectTime") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 13--%>
                                <asp:TemplateField HeaderText="Salaried" SortExpression="Salaried">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSalaried" runat="server" Checked='<%# Eval("Salaried") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 14--%> 
                                <asp:TemplateField HeaderText="Assignable SR'S" SortExpression="AssignableSRs">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxAssignableSRs" runat="server" Checked='<%# Eval("AssignableSRs") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 15--%>
                                <asp:TemplateField HeaderText="Vacations Manager?" SortExpression="IsVacationsManager">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIsVacationsManager" runat="server" Checked='<%# Eval("IsVacationsManager") %>' onclick="return cbxClick();" EnableViewState="true" />
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                
                                <%--Column 16--%>
                                <asp:TemplateField HeaderText="Personnel Agency" SortExpression="PersonalAgencyName">                                    
                                    <ItemTemplate>
                                        <asp:Label ID="lblPersonalAgencyName" runat="server" Style="width: 200px" Text='<%# Eval("PersonalAgencyName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                
                                <%--Column 17--%>
                                <asp:TemplateField HeaderText="Pay Rate (CAD)" SortExpression="PayRateCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPayRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("PayRateCad"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 18--%>
                                <asp:TemplateField HeaderText="Burden Rate (CAD)" SortExpression="BurdenRateCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurdenRateCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("BurdenRateCad"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>                                
                                
                                <%--Column 19--%>
                                <asp:TemplateField HeaderText="Total Cost (CAD)" SortExpression="TotalCostCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalCostCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("TotalCostCad"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 20--%>
                                <asp:TemplateField HeaderText="Benefit Factor (CAD)" SortExpression="BenefitFactorCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBenefitFactorCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 21--%>
                                <asp:TemplateField HeaderText="Pay Rate (USD)" SortExpression="PayRateCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPayRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("PayRateUsd"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 22--%>
                                <asp:TemplateField HeaderText="Burden Rate (USD)" SortExpression="BurdenRateUsd">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBurdenRateUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("BurdenRateUsd"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>                                
                                
                                <%--Column 23--%>
                                <asp:TemplateField HeaderText="Total Cost (USD)" SortExpression="TotalCostUsd">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalCostUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("TotalCostUsd"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 24--%>
                                <asp:TemplateField HeaderText="Benefit Factor (USD)" SortExpression="BenefitFactorUsd">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBenefitFactorUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <%--Column 25--%>
                                <asp:TemplateField HeaderText="Health Benefit (USD)" SortExpression="HealthBenefitUsd">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHealthBenefitUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("HealthBenefitUsd"),2) %>'></asp:Label>
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
                    <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_navigator2">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsViewForConditionList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Common.ResourceTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Employee" Name="resourceType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                            <asp:SessionParameter Name="admin" SessionField="sgLFS_RESOURCES_EMPLOYEES_ADMIN"
                                Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Common.ResourceTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Employee" Name="resourceType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>