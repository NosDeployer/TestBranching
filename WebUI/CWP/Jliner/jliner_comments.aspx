<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true"
    Codebehind="jliner_comments.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_comments"
    Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px;">
        <!-- Page element: 2 columns - contact info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlComments" runat="server">
                        <contenttemplate>
                    <asp:GridView ID="grdComments" runat="server" SkinID="GridViewInTabs" AutoGenerateColumns="False"
                        Width="725px" DataSourceID="odsComments" PageSize="3" OnRowUpdating="grdComments_RowUpdating"
                        OnRowDeleting="grdComments_RowDeleting" OnRowCommand="grdComments_RowCommand" OnRowEditing="grdComments_RowEditing"
                        OnDataBound="grdComments_DataBound" OnRowDataBound="grdComments_RowDataBound"
                        DataKeyNames="ID, RefID, COMPANY_ID, CommentID" AllowPaging="True" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField SortExpression="WorkID" Visible="False" HeaderText="ServiceID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
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
                            <asp:TemplateField SortExpression="CommentID" Visible="False" HeaderText="CommentID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblCommentID" runat="server" Text='<%# Eval("CommentID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCommentID" runat="server" Text='<%# Eval("CommentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="LoginID" Visible="False" HeaderText="LoginID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblLoginIDEdit" runat="server" Text='<%# Eval("LoginID") %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblLoginIDFooter" runat="server" Text='<%# Eval("LoginID") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLoginID" runat="server" Text='<%# Eval("LoginID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                <EditItemTemplate>
                                    <!-- Page element : 3 columns - Comments Information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 131px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDateEdit" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"
                                                        __designer:wfdid="w21"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                        EnableViewState="False" __designer:wfdid="w22"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistoryEdit" runat="server" SkinID="Label" Text="To History"
                                                        EnableViewState="False" __designer:wfdid="w23"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxDateEdit" runat="server" SkinID="TextBoxSmallReadOnly"
                                                        Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w24"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# GetCommentCreatedBy(Eval("LoginID")) %>' ReadOnly="True" __designer:wfdid="w25"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistoryEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("toHistory") %>'
                                                        __designer:wfdid="w26"></asp:CheckBox></td>
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
                                    <!-- Page element : 3 columns - Comments Information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 131px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistoryNew" runat="server" SkinID="Label" Text="To History" EnableViewState="False"
                                                        __designer:wfdid="w28"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistoryNew" runat="server" SkinID="CheckBox" __designer:wfdid="w30">
                                                    </asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 12px">
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </FooterTemplate>
                                <HeaderStyle Width="405px"></HeaderStyle>
                                <ItemTemplate>
                                    <!-- Page element : 2 columns - Comments Information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 132px">
                                                </td>
                                                <td style="width: 131px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"
                                                        __designer:wfdid="w12"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCreatedBy" runat="server" SkinID="Label" Text="Created By" EnableViewState="False"
                                                        __designer:wfdid="w13"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistory" runat="server" SkinID="Label" Text="To History" EnableViewState="False"
                                                        __designer:wfdid="w14"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxDate" runat="server" SkinID="TextBoxSmallReadOnly"
                                                        Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w15"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# GetCommentCreatedBy(Eval("LoginID")) %>' ReadOnly="True" __designer:wfdid="w16"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistory" onclick="return cbxClick();" runat="server" SkinID="CheckBox"
                                                        Checked='<%# Eval("toHistory") %>' __designer:wfdid="w17"></asp:CheckBox>
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
                                            </tr>
                                        </tbody>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <EditItemTemplate>
                                    <!-- Page element : 2 columns - Comments and attachment information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxCommentsEdit" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Comment") %>' Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="rfvCommentsEdit" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataEdit" ErrorMessage="Please provide a comment"
                                                        Display="Dynamic" ControlToValidate="tbxCommentsEdit"></asp:RequiredFieldValidator>
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
                                    <!-- Page element : 2 columns - Comments and attachment information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCommentsNew" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxCommentsNew" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Comment") %>' Rows="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="rfvCommentsNew" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataAdd" ErrorMessage="Please provide a comment"
                                                        Display="Dynamic" ControlToValidate="tbxCommentsNew"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 12px">
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
                                <HeaderStyle Width="270px"></HeaderStyle>
                                <ItemTemplate>
                                    <!-- Page element : 2 columns - Comments and attachment information -->
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 10px; height: 10px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                                <td style="width: 130px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxComments" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# Eval("Comment") %>' ReadOnly="True" Rows="5" TextMode="MultiLine"></asp:TextBox>
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
                                                    <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" ToolTip="Update"
                                                        CommandName="Update"></asp:ImageButton>
                                                </td>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" ToolTip="Cancel"
                                                        CommandName="Cancel"></asp:ImageButton>
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
                                                    <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" ToolTip="Add"
                                                        CommandName="Add"></asp:ImageButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </FooterTemplate>
                                <HeaderStyle Width="50px"></HeaderStyle>
                                <ItemTemplate>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" ToolTip="Edit"
                                                        CommandName="Edit"></asp:ImageButton>
                                                </td>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" OnClientClick='return confirm("Are you sure you want to delete this comment?");'
                                                        ToolTip="Delete" CommandName="Delete"></asp:ImageButton>
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
        
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfCreatedBy" runat="server" />
                    <asp:HiddenField ID="hdfId" runat="server" />
                    <asp:HiddenField ID="hdfRefId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfCreationDateTime" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfAdminPermission" runat="server" Value="no" />
                </td>
            </tr>
        </table>
       
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsComments" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCommentsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_comments"
                        DeleteMethod="DummyCommentNew" InsertMethod="DummyCommentNew" UpdateMethod="DummyCommentNew">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" />
                            <asp:Parameter Name="CommentID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" />
                            <asp:Parameter Name="CommentID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 750px;">
        <table border="0" cellpadding="0" cellspacing="0" width="750px">
            <tr>
                <td style="width: 660px; height: 24px;" align="right">
                    <asp:Button ID="btnSave1" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Save" Width="80px" OnClick="btnSave_Click" />
                </td>
                <td style="height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close"  Width="80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
