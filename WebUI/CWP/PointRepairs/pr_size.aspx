<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true" CodeBehind="pr_size.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_size" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 210px;">
        <!-- Page element: 2 columns - material info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 180px">
            <tr>
                <td colspan="2" rowspan="9" style="width: 180px">
                                                
                    <asp:Panel ID="pnlSize" runat="server" Width="205px" Height ="320px" ScrollBars="Auto">                                     
                        <asp:UpdatePanel id="upnlSize" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdSize" runat="server" SkinID="GridView" Width="180px" OnRowDataBound="grdSize_RowDataBound"
                                    DataKeyNames="Size_, COMPANY_ID" DataSourceID="odsSize"  ShowFooter="True" 
                                    OnRowUpdating="grdSize_RowUpdating" OnRowDeleting="grdSize_RowDeleting" OnRowCommand="grdSize_RowCommand"
                                    OnDataBound="grdSize_DataBound"  AutoGenerateColumns="False">
                                    <Columns>
                                       
                                       
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <EditItemTemplate>
                                                  <asp:Label ID="lblSize_Edit" runat="server" SkinID="Label" Text='<%# Bind("Size_") %>'></asp:Label>
                                            </EditItemTemplate> 
                                            <ItemTemplate>
                                                  <asp:Label ID="lblSize_" runat="server" SkinID="Label" Text='<%# Bind("Size_") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <EditItemTemplate>
                                                  <asp:Label ID="lblCOMPANY_IDEdit" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                       <%--<asp:TemplateField ShowHeader="False" Visible="False">
                                            <EditItemTemplate>
                                                  <asp:Label ID="lblDeletedEdit" runat="server" SkinID="Label" Text='<%# Bind("Deleted") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblDeleted" runat="server" SkinID="Label" Text='<%# Bind("Deleted") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <EditItemTemplate>
                                                  <asp:Label ID="lblInDatabaseEdit" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblInDatabase" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        
                                        
                                        
                                        <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center" />                            
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                    Checked='<%# Bind("Selected") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Size">
                                            <HeaderStyle width="130px" wrap="False"></HeaderStyle>
                                            
                                            <EditItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxSizeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Size_") %>' Width="120px"></asp:TextBox>
                                                            <asp:HiddenField ID="hdfSizeEdit" runat="server" Value='<%# Eval("Size_") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvSizeEdit" runat="server" ControlToValidate="tbxSizeEdit" Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a size"
                                                                SkinID="Validator" ValidationGroup="sizeDataEdit">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvSizeEdit" style="WIDTH: 120px" runat="server" SkinID="Validator" Display="Dynamic" 
                                                                ValidationGroup="sizeDataEdit" ControlToValidate="tbxSizeEdit" ErrorMessage="The size is already in use. Please provide other size" 
                                                                OnServerValidate="cvSizeEdit_ServerValidate">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </EditItemTemplate>    
                                            
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBoxReadOnly" readonly="true" Text='<%# Eval("Size_") %>' Width="120px"></asp:TextBox>                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvSize" style="WIDTH: 120px" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="sizeData"
                                                                ControlToValidate="tbxSize" ErrorMessage="You cannot delete the size because it's associated with a Repair Point" OnServerValidate="cvSize_ServerValidate">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            
                                            <FooterTemplate>
                                              <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxSizeNew" runat="server" SkinID="TextBox" Text='<%# Eval("Size_") %>' Width="120px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvSizeNew" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="sizeDataNew"
                                                                ControlToValidate="tbxSizeNew" ErrorMessage="Please provide a size" >
                                                            </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvSizeNew" style="WIDTH: 120px" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="sizeDataNew"
                                                                ControlToValidate="tbxSizeNew" ErrorMessage="The size is already in use. Please provide other size" OnServerValidate="cvSizeNew_ServerValidate">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>

                                        </asp:TemplateField>
                                        
                                        
                                                                           
                                        
                                        <asp:TemplateField>
                                            <HeaderStyle Width="50px"></HeaderStyle>
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%"> 
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnAccept" runat="server" CommandName="Update" SkinID="GridView_Update" />
                                                        </td>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="Cancel" SkinID="GridView_Cancel" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>                                                                
                                                </table>                                                            
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ibtnAdd" runat="server" CommandName="Add" SkinID="GridView_Add" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>                                                        
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="GridView_Edit" />
                                                        </td>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" SkinID="GridView_Delete" 
                                                                OnClientClick='return confirm("Are you sure you want to delete this size?");' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </contenttemplate>    
                        </asp:UpdatePanel>
                   </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>               
                    <asp:ObjectDataSource ID="odsSize" runat="server" SelectMethod="GetSize"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_size" DeleteMethod="DummySizeNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummySizeNew" InsertMethod="DummySizeNew"
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="Size_" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Size_" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Size_" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfRepairPointId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 210px; ">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
            <tr>
                <td style="width: 120px; height: 24px;" align="right">
                    <asp:Button ID="btnSave1" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Save" Style="width: 80px" 
                        OnClick="btnSave_Click" />
                </td>
                <td style="width: 90px; height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close" Style="width: 80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>