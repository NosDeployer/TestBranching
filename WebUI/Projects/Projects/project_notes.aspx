<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true"
    Codebehind="project_notes.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_notes"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 735px;">
        <!-- Page element: 1 columns - comment info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td rowspan="12">
                    <asp:UpdatePanel id="upnlNotes" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                            ShowFooter="True" AutoGenerateColumns="False" 
                            DataKeyNames="ProjectID,RefID" OnDataBound="grdNotes_DataBound" OnRowCommand="grdNotes_RowCommand"
                            OnRowDeleting="grdNotes_RowDeleting" OnRowUpdating="grdNotes_RowUpdating" OnRowEditing="grdNotes_RowEditing" 
                            DataSourceID="odsNotes">
                            <Columns>
                                <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProjectIDEdit" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectID" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                
                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRefIDEdit" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                
                                <asp:TemplateField  Visible="False" HeaderText="FileName" >                                                            
                                    <EditItemTemplate>
                                        <asp:Label ID="lblFileNameEdit" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                  
                                
                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                    <EditItemTemplate>
                                        <!-- Page element : 2 columns - Notes Information -->
                                        <table style="width: 100%; vertical-align: top;" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 155px;">
                                                    </td>
                                                    <td style="width: 155px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                            Text='<%# Eval("Subject") %>'></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit"></asp:RequiredFieldValidator></td>
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
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoteDateEdit" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                            EnableViewState="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDateEdit" runat="server" SkinID="TextBoxReadOnly"
                                                            Text='<%# Eval("DateTime") %>' ReadOnly="True"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                            Text='<%# GetNoteCreatedBy(Eval("LoginID")) %>' ReadOnly="True"></asp:TextBox></td>
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
                                        <!-- Page element : 2 columns - Notes Information -->
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 160px;">
                                                    </td>
                                                    <td style="width: 160px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1">
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                            Text='<%# Eval("Subject") %>' ></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew"></asp:RequiredFieldValidator></td>
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
                                                </tr>
                                            </tbody>
                                        </table>
                                    </FooterTemplate>
                                    
                                    <HeaderStyle Width="320px"></HeaderStyle>
                                    
                                    <ItemTemplate>
                                        <!-- Page element : 2 columns - Notes Information -->
                                        <table style="width: 100%; vertical-align: top;" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 160px;">
                                                    </td>
                                                    <td style="width: 160px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1">
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                            Text='<%# Eval("Subject") %>' ReadOnly="True"></asp:TextBox></td>
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
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By" EnableViewState="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                            Text='<%# Eval("DateTime") %>' ReadOnly="True"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                            ReadOnly="True" Text='<%# GetNoteCreatedBy(Eval("LoginID")) %>'></asp:TextBox></td>
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
                                
                                
                                
                                <asp:TemplateField SortExpression="NoteAttachment" HeaderText="Note &amp; Attachment">
                                    <EditItemTemplate>
                                        <!-- Page element : 2 columns - Notes and attachment information -->
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 220px">
                                                    </td>
                                                    <td style="width: 90px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                            Text='<%# Eval("Note") %>' TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit"></asp:RequiredFieldValidator></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteAttachmentEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                            Text="Attachment"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="vertical-align: top;">
                                                        <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px"
                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Delete" TabIndex="6" />
                                                        <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Add" TabIndex="4" /></td>
                                                </tr>--%>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </EditItemTemplate>
                                    
                                    <FooterTemplate>
                                        <!-- Page element : 2 columns - Notes and attachment information -->
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 220px">
                                                    </td>
                                                    <td style="width: 90px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                            Text='<%# Eval("Note") %>' Rows="1"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note"
                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew"></asp:RequiredFieldValidator></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td style="height: 7px">
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
                                                        <asp:Label ID="lblNoteAttachmentNew" runat="server" EnableViewState="False" SkinID="Label"
                                                            Text="Attachment"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' ReadOnly="True"></asp:TextBox>
                                                        <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>' Visible ="False"/>    
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAddFooter" Width="80px" runat="server" SkinID="Button" Text="Add" TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("RefID") %>' /></td>
                                                </tr>--%>
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
                                    
                                    <HeaderStyle Width="320px"></HeaderStyle>
                                    
                                    <ItemTemplate>
                                        <!-- Page element : 2 columns - Notes and attachment information -->
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 10px; height: 10px">
                                                    </td>
                                                    <td style="width: 220px">
                                                    </td>
                                                    <td style="width: 90px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                            Text='<%# Eval("Note") %>' ReadOnly="True" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                                                </tr>
                                                <%--<tr>
                                                    <td></td>
                                                    <td colspan="2" style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label"
                                                            Text="Attachment"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 200px"
                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="vertical-align: top">
                                                        <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Download"/></td>
                                                </tr>--%>
                                                <tr>
                                                    <td style="height: 10px" colspan="3">
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
                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                            ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"></asp:ImageButton>
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                            ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"></asp:ImageButton>
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
                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                            ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </FooterTemplate>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    <ItemTemplate>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                            ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                            OnClientClick='return confirm("Are you sure you want to delete this note?");'
                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"></asp:ImageButton>
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
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_notes"
                        DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
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
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfCreationDateTime" runat="server" Value="no" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
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
