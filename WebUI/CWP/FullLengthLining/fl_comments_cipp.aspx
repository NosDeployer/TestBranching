<%@ Page Language="C#" Title="LFS Live" AutoEventWireup="true" CodeBehind="fl_comments_cipp.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_comments_cipp" MasterPageFile="./../../mDialog2.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 735px;">
        <!-- Page element: 2 columns - comment info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td rowspan="12">
                    <asp:UpdatePanel id="upnlComments" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdComments" runat="server" SkinID="GridViewInTabs" Width="725px"
                                DataSourceID="odsComments" AutoGenerateColumns="False" PageSize="3" ShowFooter="True"
                                AllowPaging="True" DataKeyNames="WorkID, RefID" OnDataBound="grdComments_DataBound"
                                OnRowCommand="grdComments_RowCommand" OnRowDeleting="grdComments_RowDeleting" OnRowEditing="grdComments_RowEditing"
                                OnRowUpdating="grdComments_RowUpdating" OnRowDataBound="grdComments_RowDataBound">
                                <Columns>
                                    <asp:TemplateField SortExpression="WorkID" Visible="False" HeaderText="WorkID">
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
                                    
                                    <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                        <EditItemTemplate>
                                            <!-- Page element : 3 columns - Comments Information -->
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TextBox Style="width: 395px" ID="tbxSubjectEdit" runat="server" SkinID="TextBox"
                                                                Text='<%# Eval("Subject") %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:RequiredFieldValidator ID="rfvSubjectEdit" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="commentsDataEdit" ErrorMessage="Please provide a subject"
                                                                Display="Dynamic" ControlToValidate="tbxSubjectEdit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDateEdit" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                                EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTypeEdit" runat="server" SkinID="Label" Text="Type" EnableViewState="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox Style="width: 125px" ID="tbxDateEdit" runat="server" SkinID="TextBoxSmallReadOnly"
                                                                Text='<%# Eval("DateTime_") %>' ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox Style="width: 125px" ID="tbxCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                Text='<%# GetCommentCreatedBy(Eval("UserID")) %>' ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upTypeEdit" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTypeEdit" runat="server" SkinID="DropDownListLookup" Width="125px"
                                                                        DataSourceID="odsCommentTypeWetOut" ValidationGroup="commentsDataEdit" AutoPostBack="True"
                                                                        DataTextField="Type" DataValueField="Type">
                                                                    </asp:DropDownList>                                                               
                                                                    <asp:TextBox Style="width: 125px" ID="tbxTypeEdit" runat="server" SkinID="TextBoxSmallReadOnly"
                                                                        Text='<%# Eval("Type") %>' ReadOnly="True" AutoPostBack="True"></asp:TextBox>
                                                                </ContentTemplate>
                                                           </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvTypeEdit" runat="server" SkinID="Validator" EnableViewState="False"
                                                                ValidationGroup="commentsDataEdit" ErrorMessage="Please select a type" Display="Dynamic"
                                                                ControlToValidate="ddlTypeEdit" InitialValue="(Select)"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
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
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTypeFooter" runat="server" SkinID="Label" Text="Type" EnableViewState="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox Style="width: 260px" ID="tbxSubjectNew" runat="server" SkinID="TextBox"
                                                                Text='<%# Eval("Subject") %>'></asp:TextBox></td>
                                                        <td colspan="1">
                                                            <asp:UpdatePanel ID="upTypeEdit" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTypeNew" runat="server" SkinID="DropDownListLookup" Width="125px"
                                                                        DataSourceID="odsCommentTypeWetOut" ValidationGroup="commentsDataAdd" AutoPostBack="True"
                                                                        DataTextField="Type" DataValueField="Type">
                                                                    </asp:DropDownList>                                                            
                                                                </ContentTemplate>
                                                           </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RequiredFieldValidator ID="rfvSubjectNew" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="commentsDataAdd" ErrorMessage="Please provide a subject"
                                                                Display="Dynamic" ControlToValidate="tbxSubjectNew"></asp:RequiredFieldValidator></td>
                                                        <td colspan="1">
                                                            <asp:RequiredFieldValidator ID="rfvTypeNew" runat="server" SkinID="Validator" EnableViewState="False"
                                                                ValidationGroup="commentsDataAdd" ErrorMessage="Please provide a type" Display="Dynamic"
                                                                ControlToValidate="ddlTypeNew" InitialValue="(Select)"></asp:RequiredFieldValidator></td>
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
                                        <HeaderStyle Width="405px"></HeaderStyle>
                                        <ItemTemplate>
                                            <!-- Page element : 2 columns - Comments Information -->
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TextBox Style="width: 395px" ID="tbxSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                Text='<%# Eval("Subject") %>' ReadOnly="True"></asp:TextBox>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCreatedBy" runat="server" SkinID="Label" Text="Created By" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblType" runat="server" SkinID="Label" Text="Type" EnableViewState="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox Style="width: 125px" ID="tbxDate" runat="server" SkinID="TextBoxSmallReadOnly"
                                                                Text='<%# Eval("DateTime_") %>' ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox Style="width: 125px" ID="tbxCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                Text='<%# GetCommentCreatedBy(Eval("UserID")) %>' ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox Style="width: 125px" ID="tbxType" runat="server" SkinID="TextBoxReadOnly"
                                                                Text='<%# (Eval("Type")) %>' ReadOnly="True"></asp:TextBox></td>
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
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comments &amp; Attachment">
                                        <EditItemTemplate>
                                            <!-- Page element : 2 columns - Comments and attachment information -->
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox Style="width: 260px" ID="tbxCommentsEdit" runat="server" SkinID="TextBox"
                                                                Text='<%# Eval("Comment") %>' TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
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
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <!-- Page element : 2 columns - Comments and attachment information -->
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCommentsNew" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox Style="width: 260px" ID="tbxCommentsNew" runat="server" SkinID="TextBox"
                                                                Text='<%# Eval("Comment") %>' Rows="1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
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
                                                        <td style="width: 135px; height: 10px">
                                                        </td>
                                                        <td style="width: 135px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comment" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox Style="width: 260px" ID="tbxComments" runat="server" SkinID="TextBoxReadOnly"
                                                                Text='<%# Eval("Comment") %>' ReadOnly="True" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="2">
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
                        </contenttemplate> 
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsComments" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCommentsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_comments_cipp"
                        DeleteMethod="DummyCommentNew" InsertMethod="DummyCommentNew" UpdateMethod="DummyCommentNew">
                    </asp:ObjectDataSource>                    
                    <asp:ObjectDataSource ID="odsCommentTypeWetOut" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkCommentTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="commentType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="Full Length Lining Wet Out" Name="workType" Type="String" />
                        </SelectParameters>
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
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfRunDetail" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- Page element: Buttons -->
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
