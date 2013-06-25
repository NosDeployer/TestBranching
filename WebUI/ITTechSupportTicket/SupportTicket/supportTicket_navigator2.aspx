<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm7.Master" AutoEventWireup="true" CodeBehind="supportTicket_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket.supportTicket_navigator2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td >
                    <asp:Label ID="lblTitle" runat="server" Text="Search IT Tech Support Ticket" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Support Tickets" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddTicket" Text="Add Support Ticket"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mCategoriesSetup" Text="Categories Setup" ></telerik:RadPanelItem>                                    
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
                   <%-- <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mToDoListMyToDoReport" Text="To Do's I Created" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToDoListMyAssignedToDoReport" Text="To Do's Assigned To Me" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>--%>
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
        
        <!-- Page element: Section title - Results-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label></td>
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
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select a support ticket."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator></td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
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
                    <div runat="server" id="dvGrid" style="overflow-x:auto; overflow-y:hidden; Width:625px">
                    <asp:GridView ID="grdSupportTicketNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="SupportTicketID"
                        SkinID="GridView">
                        <Columns>
                        
                            <%--Column 0--%>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                        Checked='<%# Bind("Selected") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 1--%>
                            <asp:TemplateField HeaderText="SupportTicketID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupportTicketId" runat="server" Style="width: 100px" Text='<%# Bind("SupportTicketID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            
                            <%--Column 2--%>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCreationDate" runat="server" Style="width: 100px" Text='<%# Bind("CreationDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 3--%>
                            <asp:TemplateField HeaderText="Category">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryName" runat="server" Style="width: 100px" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                                          
                            <%--Column 4--%>
                            <asp:TemplateField HeaderText="Created By">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" Style="width: 100px" Text='<%# Bind("OwnerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 5--%>
                            <asp:TemplateField HeaderText="Assigned To">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssignedTo" runat="server" Style="width: 100px" Text='<%# Bind("LastAssignedTeamMemberName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 6--%>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Style="width: 120px" Text='<%# Bind("Subject") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 7--%>
                            <asp:TemplateField HeaderText="Last Comment">
                                <ItemTemplate>
                                    <asp:Label ID="lblComment" runat="server" Style="width: 120px" Text='<%# Bind("LastComment") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 8--%>
                            <asp:TemplateField HeaderText="Due Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDueDate" runat="server" Style="width: 100px" Text='<%# Bind("DueDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                                                  
                            <%--Column 9--%>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="lblState" runat="server" Style="width: 100px" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                                                        
                        </Columns>
                    </asp:GridView>
                    
                    </div>
                </td>
                <td style="vertical-align: top">
                
                    <!-- Table element: 1 column -->
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
            <tr>
                <td style="height: 60px">
                </td>
                <td>
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