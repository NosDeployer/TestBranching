<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="toDoList_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList.toDoList_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="To Do List Summary" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 70px">
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleSubjectLabel" runat="server" Text="Subject:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleSubjectName" runat="server" Text="> Subject1" SkinID="LabelPageTitle2"></asp:Label>
                </td>
                <td>
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
                            <telerik:RadPanelItem Expanded="True" Text="To Do List" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddToDoList" Text="Add To Do List"></telerik:RadPanelItem>
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



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mActions" Text="ACTIONS" PostBack="false">
                                <items>
                                    <telerik:RadMenuItem Value="mAssign" Text="Assign to user" />
                                    <telerik:RadMenuItem Value="mComment" Text="Add Comment" />  
                                    <telerik:RadMenuItem Value="mPutOnHold" Text="Put On Hold" /> 
                                    <telerik:RadMenuItem Value="mComplete" Text="Complete" /> 
                                </items>
                            </telerik:RadMenuItem>
                            
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
        
        <!-- Table element: 1 columns - Section Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">            
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Section Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblCreatedBy" runat="server" EnableViewState="False" SkinID="Label" Text="Created By"></asp:Label>
                </td>
                <td style="width: 125px">                   
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblCreationDate" runat="server" EnableViewState="False" SkinID="Label" Text="Creation Date"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxCreatedBy" runat="server" 
                        ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 365px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxCreationDate" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
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
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblAssignedUser" runat="server" EnableViewState="False" 
                        SkinID="Label" Text="Assigned User"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblDueDate" runat="server" EnableViewState="False" 
                        SkinID="Label" Text="Due Date (optional)"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblUnit" runat="server" EnableViewState="False" SkinID="Label" 
                        Text="Unit / Equipment (optional)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxAssignedUser" runat="server" 
                        ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 365px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDueDate" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxUnit" runat="server" 
                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
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
      
        
        <!-- Table element: 6 columns - To Do List Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblToDoListDetails" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
                              
        <!-- Table element: 1 column  -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">            
            <tr>
                <td>
                    <asp:GridView id="grdToDoList" runat="server" SkinID="GridViewInTabs" Width="740px" AutoGenerateColumns="False" DataSourceID="odsToDoList" 
                        DataKeyNames="ToDoID,RefID" OnDataBound="grdToDoList_DataBound" OnRowDataBound="grdToDoList_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Type" SortExpression="Type" Visible="False">
                                <EditItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type_") %>'></asp:Label> 
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type_") %>'></asp:Label>                 
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="To Do List Activity">
                                <HeaderStyle Width="690px"></HeaderStyle>                                                            
                                <ItemTemplate>                                                                            
                                    <!-- Page element : 6 columns - To Do List Activity Information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tr>
                                            <td style="width: 10px; height: 10px">
                                            </td>
                                            <td style="width: 136px;">
                                            </td>
                                            <td style="width: 136px">
                                            </td>
                                            <td style="width: 136px">
                                            </td>
                                           <td style="width: 136px">
                                            </td>
                                            <td style="width: 136px"> 
                                            </td>                                                                            
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDateTime" runat="server" Text="Date & Time" SkinID="Label" EnableViewState="True"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUser" runat="server" Text="User" SkinID="Label" EnableViewState="True"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td> 
                                            </td>                                                                            
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxDateTime" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="262px" Text='<%# Eval("DateTime_") %>' EnableViewState="True"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxUser" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="262px" Text='<%# Eval("EmployeeFullName") %>' EnableViewState="True"></asp:TextBox>
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
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>                                           
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="5">
                                                <asp:Label ID="lblComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="5">
                                                <asp:TextBox ID="tbxComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="670px" Text='<%# Eval("Comment") %>' EnableViewState="True"></asp:TextBox>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
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
                                    
                                </ItemTemplate>                                                        
                            </asp:TemplateField>

                            <asp:TemplateField>  
                                <HeaderStyle Width="55px"></HeaderStyle>                                                     
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
                    <asp:ObjectDataSource ID="odsToDoList" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetToDoNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList.toDoList_summary">                        
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfToDoId" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                    <asp:HiddenField ID="hdfAssignedUser" runat="server" />
                    <asp:HiddenField ID="hdfState" runat="server" />
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
