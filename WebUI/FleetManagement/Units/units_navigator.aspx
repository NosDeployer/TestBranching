<%@ Page Language="C#" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="units_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_navigator" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Search Units" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuUnits" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Units" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddUnit" Text="Add Unit"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mCategories" Text="Categories" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCompanyLevels" Text="Company Levels" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mUnitsInformationReport" Text="Units Information Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsChecklistReport" Text="Units Checklists Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsWithAlarmsReport" Text="Units With Alarms Report" ></telerik:RadPanelItem>
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
                        EnableViewState="False"></asp:Label>
                </td>
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
                    <td style="width: 355px">
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
                            EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList"
                            DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
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
                    <td>
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)"
                            OnServerValidate="cvForDateRange_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            SkinID="Validator" ValidateEmptyText="True" OnServerValidate="cvForBoolean_ServerValidate">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForMoneyCondition" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use #.## format)"
                            OnServerValidate="cvForMoneyCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
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
        <asp:Panel ID="pnlDefaultViewSearch" runat="server" Width="100%" DefaultButton="btnGo">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td>
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList Style="width: 540px" ID="ddlView" runat="server" SkinID="DropDownListLookup">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewAdd" runat="server" Style="width: 16px; height: 16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" Style="width: 16px; height: 16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" Style="width: 16px; height: 16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px"
                            EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" />
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
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0"
            style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td>
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
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
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Units" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Units" Name="fmType" Type="String" />
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
                    <asp:HiddenField ID="hdfSelectedUnitId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>