<%@ Page Language="C#" MasterPageFile="../../mForm7.Master" AutoEventWireup="true" CodeBehind="toDoList_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList.toDoList_navigator" Title="LFS Live" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td >
                    <asp:Label ID="lblTitle" runat="server" Text="Search To Do List" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="To Do List" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddToDoList" Text="Add To Do List"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false"></telerik:RadPanelItem>
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
                            <telerik:RadPanelItem Expanded="True" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mToDoListMyToDoReport" Text="To Do's I Created" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToDoListMyAssignedToDoReport" Text="To Do's Assigned To Me" ></telerik:RadPanelItem>
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
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="width: 135px">
                        <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" 
                            Text="State"></asp:Label>
                    </td>
                    <td style="width: 135px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 210px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" DataMember="DefaultView" 
                            DataSourceID="odsState" DataTextField="State" DataValueField="State" 
                            EnableViewState="False" SkinID="DropDownList" Style="width: 125px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>                
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                        
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 7px">
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
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query."></asp:Label>
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
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="ToDoList" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource><asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="ToDoList" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource><asp:ObjectDataSource ID="odsState" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.ToDoList.ToDoListStateList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
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
                    <asp:HiddenField ID="hdfSelectedServiceId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>