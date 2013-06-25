<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true"
    Codebehind="jl_comments.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_comments"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 735px;">
        <!-- Page element: 1 columns - comment info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td rowspan="12">
                    <asp:UpdatePanel id="upnlComments" runat="server">
                        <contenttemplate>
                    <asp:GridView ID="grdComments" runat="server" SkinID="GridViewInTabs" PageSize="3"
                        ShowFooter="True" AllowPaging="True" DataKeyNames="WorkID, RefID" OnRowDataBound="grdComments_RowDataBound"
                        OnDataBound="grdComments_DataBound" OnRowCommand="grdComments_RowCommand" OnRowDeleting="grdComments_RowDeleting"
                        OnRowUpdating="grdComments_RowUpdating" AutoGenerateColumns="False" DataSourceID="odsComments" OnRowEditing="grdComments_RowEditing"
                        Width="725px">
                        <Columns>
                            <asp:TemplateField SortExpression="WorkID" Visible="False" HeaderText="ServiceID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label>
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
                            <asp:TemplateField SortExpression="LIBRARY_FILES_ID" Visible="False" HeaderText="LIBRARY_FILES_ID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblLIBRARY_FILES_IDEdit" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblLIBRARY_FILES_IDNew" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLIBRARY_FILES_ID" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="UserID" Visible="False" HeaderText="UserID">
                                <EditItemTemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="Type" Visible="False" HeaderText="Type">
                                <EditItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
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
                                                    <asp:Label ID="lblSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                        __designer:wfdid="w197"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox Style="width: 385px" ID="tbxSubjectEdit" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Subject") %>' __designer:wfdid="w198"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="3">
                                                    <asp:RequiredFieldValidator ID="rfvSubjectEdit" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataEdit" ErrorMessage="Please provide a subject"
                                                        Display="Dynamic" ControlToValidate="tbxSubjectEdit" __designer:wfdid="w199"></asp:RequiredFieldValidator>
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
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDateEdit" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"
                                                        __designer:wfdid="w200"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                        EnableViewState="False" __designer:wfdid="w201"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistoryEdit" runat="server" SkinID="Label" Text="To History"
                                                        EnableViewState="False" __designer:wfdid="w202"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxDateEdit" runat="server" SkinID="TextBoxSmallReadOnly"
                                                        Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w203"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# GetCommentCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w204"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistoryEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("ToHistory") %>'
                                                        __designer:wfdid="w205"></asp:CheckBox></td>
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
                                                    <asp:Label ID="lblSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                        __designer:wfdid="w206"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistoryNew" runat="server" SkinID="Label" Text="To History" EnableViewState="False"
                                                        __designer:wfdid="w207"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 264px" ID="tbxSubjectNew" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Subject") %>' __designer:wfdid="w208"></asp:TextBox></td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistoryNew" runat="server" SkinID="CheckBox" __designer:wfdid="w209">
                                                    </asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="rfvSubjectNew" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataAdd" ErrorMessage="Please provide a subject"
                                                        Display="Dynamic" ControlToValidate="tbxSubjectNew" __designer:wfdid="w210"></asp:RequiredFieldValidator></td>
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
                                                    <asp:Label ID="lblSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                        __designer:wfdid="w189"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox Style="width: 385px" ID="tbxSubject" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# Eval("Subject") %>' ReadOnly="True" __designer:wfdid="w190"></asp:TextBox>
                                                </td>
                                                <td colspan="1">
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
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"
                                                        __designer:wfdid="w191"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCreatedBy" runat="server" SkinID="Label" Text="Created By" EnableViewState="False"
                                                        __designer:wfdid="w192"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblToHistory" runat="server" SkinID="Label" Text="To History" EnableViewState="False"
                                                        __designer:wfdid="w193"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxDate" runat="server" SkinID="TextBoxSmallReadOnly"
                                                        Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w194"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox Style="width: 122px" ID="tbxCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# GetCommentCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w195"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckbxToHistory" onclick="return cbxClick();" runat="server" SkinID="CheckBox"
                                                        Checked='<%# Eval("ToHistory") %>' __designer:wfdid="w196"></asp:CheckBox>
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
                            
                            
                            
                            <asp:TemplateField HeaderText="Comments &amp; Attachment">
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
                                                    <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"
                                                        __designer:wfdid="w213"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxCommentsEdit" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Comment") %>' __designer:wfdid="w214" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="rfvCommentsEdit" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataEdit" ErrorMessage="Please provide a comment"
                                                        Display="Dynamic" ControlToValidate="tbxCommentsEdit" __designer:wfdid="w215"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="lblCommentsNew" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"
                                                        __designer:wfdid="w216"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxCommentsNew" runat="server" SkinID="TextBox"
                                                        Text='<%# Eval("Comment") %>' __designer:wfdid="w217" Rows="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="rfvCommentsNew" runat="server" SkinID="Validator"
                                                        EnableViewState="False" ValidationGroup="commentsDataAdd" ErrorMessage="Please provide a comment"
                                                        Display="Dynamic" ControlToValidate="tbxCommentsNew" __designer:wfdid="w218"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"
                                                        __designer:wfdid="w211"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox Style="width: 250px" ID="tbxComments" runat="server" SkinID="TextBoxReadOnly"
                                                        Text='<%# Eval("Comment") %>' ReadOnly="True" __designer:wfdid="w212" Rows="5"
                                                        TextMode="MultiLine"></asp:TextBox>
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
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsComments" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCommentsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_comments"
                        DeleteMethod="DummyCommentNew" InsertMethod="DummyCommentNew" UpdateMethod="DummyCommentNew">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfAdminPermission" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfCreatedBy" runat="server" />
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfCreationDateTime" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfSection_" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <div style="width: 735px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 645px; height: 24px;" align="right">
                    <asp:Button ID="btnSave1" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Save" Style="width: 80px" OnClick="btnSave_Click" />
                </td>
                <td style="height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close" Style="width: 80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
