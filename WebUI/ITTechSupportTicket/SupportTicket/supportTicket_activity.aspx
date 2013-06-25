<%@ Page Language="C#" MasterPageFile="../../mForm8.master" AutoEventWireup="true" CodeBehind="supportTicket_activity.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket.supportTicket_activity" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Support Ticket Activity" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Label ID="lblTitleSubjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Support Tickets" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddTicket" Text="Add Support Ticket"></telerik:RadPanelItem>
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
                    <%--<telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mSupportTicketMyToDoReport" Text="To Do's I Created" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSupportTicketMyAssignedToDoReport" Text="To Do's Assigned To Me" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>--%>
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
                    <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
                </td>
                <td align="right">                    
                </td>
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Table element: 1 columns -  -->
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
                    <asp:Label ID="lblCategoryName" runat="server" EnableViewState="False" SkinID="Label" Text="Category"></asp:Label>
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
                    <asp:TextBox ID="tbxCategoryName" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
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
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel id="uplAssignedUser" runat="server" UpdateMode="Always">
                        <contenttemplate>
                            <asp:TextBox ID="tbxAssignedUser" runat="server"  AutoPostBack="true"
                        ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 365px"></asp:TextBox>
                        </contenttemplate>
                    </asp:UpdatePanel>                                                    
                </td>
                <td>
                    <asp:TextBox ID="tbxDueDate" runat="server" 
                        ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td colspan="2">                    
                </td>
            </tr>            
        </table>        
        
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
        
        <!-- Table element: 6 columns - Support Ticket List Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSupportTicketDetails" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="False"></asp:Label>
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
                <td style="width: 100%">                               
                                  
                    <!-- Table element: 1 column  -->
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel id="upnlSupportTicket" runat="server">
                                    <contenttemplate>
                                        <asp:GridView ID="grdSupportTicket" runat="server" SkinID="GridViewInTabs" 
                                            Width="740px" AutoGenerateColumns="False" 
                                            ShowFooter="True" DataSourceID="odsSupportTicket" DataKeyNames="SupportTicketID,RefID" OnDataBound="grdSupportTicket_DataBound" 
                                            OnRowDataBound="grdSupportTicket_RowDataBound" 
                                            OnRowCommand="grdSupportTicket_RowCommand" OnRowDeleting="grdSupportTicket_RowDeleting" 
                                            OnRowUpdating="grdSupportTicket_RowUpdating" 
                                            OnRowEditing="grdSupportTicket_RowEditing">
                                            <Columns>
                                            
                                                <asp:TemplateField HeaderText="SupportTicketID" SortExpression="SupportTicketID" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblSupportTicketID" runat="server" Text='<%# Eval("SupportTicketID") %>'></asp:Label> 
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSupportTicketID" runat="server" Text='<%# Eval("SupportTicketID") %>'></asp:Label>                 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                
                                                
                                                <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label> 
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>                 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                
                                                
                                                <asp:TemplateField HeaderText="Type" SortExpression="Type" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type_") %>'></asp:Label> 
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type_") %>'></asp:Label>                 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                
                                                
                                                <asp:TemplateField HeaderText="InDataBase" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblInDataBase" runat="server" Text='<%# Eval("InDataBase") %>'></asp:Label> 
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInDataBase" runat="server" Text='<%# Eval("InDataBase") %>'></asp:Label>                 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                
                                            
                                                <asp:TemplateField HeaderText="Support Ticket Activity">
                                                    <HeaderStyle Width="690px"></HeaderStyle>
                                                    
                                                    <ItemTemplate>                                                            
                                                        <!-- Page element : 6 columns - Repair Information -->                                                                    
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                            <tr>
                                                                <td style="width: 10px; height: 10px">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
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
                                                    
                                                    <EditItemTemplate>                                                        
                                                        <!-- Page element : 6 columns - Support Ticket Information -->                                                                    
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                            <tr>
                                                                <td style="width: 10px; height: 10px">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDateTimeEdit" runat="server" Text="Date & Time" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblUserEdit" runat="server" Text="User" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                               <td>
                                                                </td>
                                                                <td> 
                                                                </td>                                                                                  
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td  colspan="2">
                                                                    <asp:TextBox ID="tbxDateTimeEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" 
                                                                    Width="262px" Text='<%# Eval("DateTime_") %>' EnableViewState="True"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="ddlAssignToTeamMemberEdit" runat="server" 
                                                                        DataMember="DefaultView" DataSourceID="odsEmployee" 
                                                                        DataTextField="FullName" DataValueField="EmployeeID" SkinID="DropDownList" 
                                                                        Style="width: 262px">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="tbxUserEdit" runat="server" EnableViewState="True" 
                                                                        ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("EmployeeFullName") %>' 
                                                                        Width="262px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>                                                                                                                                                                                                                           
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td colspan="2">                                                                        
                                                                    <asp:CustomValidator ID="cvTeamMemberEdit" runat="server" 
                                                                        ControlToValidate="ddlAssignToTeamMemberEdit" Display="Dynamic" 
                                                                        ErrorMessage="Please select a team member." 
                                                                        OnServerValidate="cvTeamMemberEdit_ServerValidate" SkinID="Validator" 
                                                                        ValidationGroup="activityDataEdit"></asp:CustomValidator>
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
                                                                    <asp:Label ID="lblCommentsEdit" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="5">
                                                                    <asp:TextBox ID="tbxCommentsEdit" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="670px" Text='<%# Eval("Comment") %>' EnableViewState="True"></asp:TextBox>
                                                                    
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="5">
                                                                    <asp:CustomValidator ID="cvProblemDescription" runat="server" 
                                                                        ControlToValidate="tbxCommentsEdit" Display="Dynamic" 
                                                                        ErrorMessage="Please provide a comment." ValidateEmptyText="true" 
                                                                        OnServerValidate="cvProblemDescriptionEdit_ServerValidate" SkinID="Validator" 
                                                                        ValidationGroup="activityDataEdit"></asp:CustomValidator>                                                                    
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
                                                    </EditItemTemplate>
                                                    
                                                    <FooterTemplate>
                                                        <!-- Page element : 6 columns - Support Ticket Information -->                                                                                                                                        
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tr>
                                                                <td style="width: 10px; height: 10px">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:UpdatePanel id="upllabels" runat="server" UpdateMode="Always">
                                                                        <contenttemplate>
                                                                            <asp:Label ID="lblActionNew" runat="server" Text="Action" SkinID="Label"  EnableViewState="True"></asp:Label>
                                                                            <asp:Label ID="lblClosed" runat="server" Text="The Support Ticket is closed" SkinID="LabelError" EnableViewState="True"></asp:Label>
                                                                        </contenttemplate>
                                                                    </asp:UpdatePanel>    
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
                                                                <td colspan = "2" >
                                                                    <asp:DropDownList ID="ddlActionsNew" runat="server" SkinID="DropDownListLookup" 
                                                                        Width="262px" AutoPostBack="True" 
                                                                        onselectedindexchanged="ddlActionsNew_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Assign To User" Text="Assign To User"></asp:ListItem>
                                                                        <asp:ListItem Value="Assign To Owner" Text="Assign To Owner"></asp:ListItem>
                                                                        <asp:ListItem Value="Add Comment" Text="Add Comment"></asp:ListItem>
                                                                        <asp:ListItem Value="Put On Hold" Text="Put On Hold"></asp:ListItem>
                                                                        <asp:ListItem Value="Complete" Text="Complete"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>                                                                
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="6">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                                                                                        
                                                        
                                                        <!-- Page element : 6 columns - Support Ticket Information -->                                                                    
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                            <tr>
                                                                <td style="width: 10px; height: 10px">
                                                                </td>
                                                                <td style="width: 136px;">
                                                                    <asp:Label ID="lblDateTimeNew" runat="server" Text="Date & Time" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                                <td style="width: 136px">
                                                                </td>
                                                                <td style="width: 136px">
                                                                    <asp:Label ID="lblUserNew" runat="server" Text="User" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                               <td style="width: 136px">
                                                                </td>
                                                                <td style="width: 136px"> 
                                                                </td>                                                                            
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="tbxDateTimeNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="262px" EnableViewState="True"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel id="upnlTeamMembers" runat="server" UpdateMode="Always">
                                                                        <contenttemplate>
                                                                            <asp:DropDownList ID="ddlAssignToTeamMemberNew" runat="server" 
                                                                                DataMember="DefaultView" DataSourceID="odsEmployee"                                                                                 
                                                                                DataTextField="FullName" DataValueField="EmployeeID" SkinID="DropDownList" 
                                                                                Style="width: 262px">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="tbxUserNew" runat="server" EnableViewState="True" 
                                                                                ReadOnly="true" SkinID="TextBoxReadOnly" Width="262px"></asp:TextBox>                                                                                
                                                                       </contenttemplate>
                                                                    </asp:UpdatePanel>         
                                                                </td>
                                                                <td>
                                                                </td>                                                             
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>                                                                
                                                                <td colspan="2">
                                                                    <asp:CustomValidator ID="cvTeamMemberNew" runat="server" 
                                                                        ControlToValidate="ddlAssignToTeamMemberNew" Display="Dynamic" 
                                                                        ErrorMessage="Please select a team member."  
                                                                        OnServerValidate="cvTeamMemberNew_ServerValidate" SkinID="Validator" 
                                                                        ValidationGroup="activityDataNew"></asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="6">
                                                                </td>
                                                            </tr>                                                                                                                        
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblCommentsNew" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="5">
                                                                    <asp:TextBox ID="tbxCommentsNew" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="670px" EnableViewState="True"></asp:TextBox>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:CustomValidator ID="cvProblemDescriptionNew" runat="server" 
                                                                                ControlToValidate="tbxCommentsNew" Display="Dynamic" ValidateEmptyText="true" 
                                                                                ErrorMessage="Please provide a comment."
                                                                                OnServerValidate="cvProblemDescriptionNew_ServerValidate" SkinID="Validator" 
                                                                                ValidationGroup="activityDataNew"></asp:CustomValidator> 
                                                                            <tr>
                                                                                <td colspan="6" style="height: 10px">
                                                                                </td>
                                                                            </tr>
                                                                        </td>
                                                                    </tr>
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
                                                                                                            
                                                       
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                
                                                
                                                 <asp:TemplateField HeaderText="SendMail" SortExpression="Type" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblSendMail" runat="server" Text='<%# Eval("SendMail") %>'></asp:Label> 
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSendMail" runat="server" Text='<%# Eval("SendMail") %>'></asp:Label>                 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                

                                                <asp:TemplateField>
                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                
                                                    <EditItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnAccept" ToolTip="Accept" runat="server" SkinID="GridView_Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png" CommandName="Update"></asp:ImageButton>
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnCancel" ToolTip="Cancel" runat="server" SkinID="GridView_Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png" CommandName="Cancel"></asp:ImageButton>
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
                                                                        <asp:ImageButton ID="ibtnAdd" ToolTip="Add" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" CommandName="Add"></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>                                                            
                                                    </FooterTemplate>
                                                    
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnEdit" ToolTip="Edit" runat="server" SkinID="GridView_Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" CommandName="Edit"></asp:ImageButton>
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnDelete" ToolTip="Delete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this activity?");'></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>                                                            
                                                    </ItemTemplate>                                                           
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    
                    <!-- Table element: 1 column - Bottom space -->
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        <tr>
                            <td style="height: 30px">
                            </td>
                        </tr>
                    </table>                                
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
                    <asp:ObjectDataSource ID="odsSupportTicket" runat="server" SelectMethod="GetToDoNew"
                        TypeName="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket.supportTicket_activity" DeleteMethod="DummyToDoNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyToDoNew" InsertMethod="DummyToDoNew">                        
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
                    <asp:HiddenField ID="hdfSupportTicketId" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                    <asp:HiddenField ID="hdfAction" runat="server" />
                    <asp:HiddenField ID="hdfAssignedUser" runat="server" />                    
                    <asp:HiddenField ID="hdfSupportTicketState" runat="server" />
                    <asp:HiddenField ID="hdfCreatedById" runat="server" /> 
                    
                    <asp:UpdatePanel ID="upCompleted" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdfCompleted" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
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



<asp:Content ID="Content6" ContentPlaceHolderID="FooterSpacePlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Page element : Footer separation -->
        <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>