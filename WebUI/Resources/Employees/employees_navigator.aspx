<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="employees_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_navigator" %> 

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
        <!-- Page element: Search & Sort components , 4 columns-->
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
                    <asp:ObjectDataSource ID="odsViewForConditionList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Common.ResourceTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Employee" Name="resourceType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                            <asp:SessionParameter Name="admin" SessionField="sgLFS_RESOURCES_EMPLOYEES_ADMIN" Type="Boolean" />
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
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                    
                    <asp:HiddenField ID="hdfResourceType" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
