<%@ Control Language="C#" AutoEventWireup="true" Codebehind="wucMyToDoList.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucMyToDoList" %>
    
<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Add To Do -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnAddToDo" runat="server" EnableViewState="False" SkinID="LinkButton">Add To Do List</asp:LinkButton></td>
        </tr>        
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table> 
    
    <!-- Table element: 1 columns - My To Do Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblMyToDoList" runat="server" SkinID="LabelTitle2" Text="My To Do" EnableViewState="False"></asp:Label>        
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
    
    <!-- Table element: 1 columns - Dropdownlist for working location -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblState" runat="server" SkinID="Label" Text="State"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlStateMyToDo" runat="server" EnableViewState="False" AutoPostBack="true" SkinID="DropDownList" Style="width: 220px" OnSelectedIndexChanged="ddlStateMyToDo_SelectedIndexChanged">
                    <asp:ListItem Text="(All)" Value="(All)" ></asp:ListItem>
                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                    <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                    <asp:ListItem Text="New" Value="New"></asp:ListItem>
                    <asp:ListItem Text="New &amp; In Progress" Value="New &amp; In Progress" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
        
    <!-- Table element: 1 columns - My To Do Grid -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100px">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlMyToDos" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="grdMyToDoList" runat="server" SkinID="GridView" Width="220px"
                            DataKeyNames="ToDoID" DataSourceID="odsMyToDoList" OnDataBound="grdMyToDoList_DataBound"
                            PageSize="8" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdMyToDoList_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                    
                                <asp:BoundField ReadOnly="True" DataField="ToDoID" Visible="False" SortExpression="ToDoID" HeaderText="ToDoID"></asp:BoundField>
                                    
                                <asp:TemplateField HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblUnitCodeAssignedToMe" runat="server" Style="width: 30px" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="To Do List">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkMyToDo" runat="server" SkinID="HyperLink" Text='<%# Bind("Subject") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("ToDoID")) %>' ToolTip='<%# Bind("LastComment") %>' Target="_parent" >
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblState" runat="server" Style="width: 60px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </contenttemplate>
                </asp:UpdatePanel>    
            </td>
        </tr>        
    </table>
    
    <!-- Table element: 1 columns - Separator -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 10px">
            </td>
        </tr>        
    </table> 
    
    <!-- Table element: 1 columns - My To Do Grid On Hold-->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100px">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlOnHold" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="grdMyToDoListOnHold" runat="server" SkinID="GridView" Width="220px"
                            DataKeyNames="ToDoID" DataSourceID="odsMyToDoListOnHold" OnDataBound="grdMyToDoListOnHold_DataBound"
                            PageSize="5" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdMyToDoListOnHold_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID"
                                    HeaderText="COMPANY_ID"></asp:BoundField>
                                    
                                <asp:BoundField ReadOnly="True" DataField="ToDoID" Visible="False" SortExpression="ToDoID"
                                    HeaderText="ToDoID"></asp:BoundField>
                                    
                                <asp:TemplateField HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblUnitCodeAssignedToMeOnHold" runat="server" Style="width: 30px" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="To Do List On Hold">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkMyToDo" runat="server" SkinID="HyperLink" Text='<%# Bind("Subject") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("ToDoID")) %>'  ToolTip='<%# Bind("LastComment") %>' Target="_parent" >
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblState" runat="server" Style="width: 60px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </contenttemplate>
                </asp:UpdatePanel>    
            </td>
        </tr>        
    </table>
    
    <!-- Table element: 1 columns - Go To Navigator -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnAssignServiceRequest" runat="server" EnableViewState="False" 
                SkinID="LinkButton" OnClick="lkbtnViewNavigator_Click">View all my to do</asp:LinkButton>
            </td>                
        </tr>        
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table> 
    
    <!-- Table element: 1 columns - Space -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 15px">
            </td>
        </tr>
    </table>
        
    <!-- Page element: Data objects -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:ObjectDataSource ID="odsMyToDoList" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucMyToDoList">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMyToDoListOnHold" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDetailsOnHold" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucMyToDoList">
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