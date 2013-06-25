<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mDialog2.master" AutoEventWireup="true" CodeBehind="employees_personal_agency.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_personal_agency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblInstrucction" runat="server" Text="Please enter all the Personnel Agencies" SkinID="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <!-- Page element: 2 columns - personal agencies info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 380px">
            <tr>
                <td colspan="2" rowspan="9" style="width: 380px">
                                                
                    <asp:Panel ID="pnlPersonalAgency" runat="server" Width="405px" Height ="320px" ScrollBars="Auto">                                     
                        <asp:UpdatePanel id="upnlPersonalAgency" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdPersonalAgency" runat="server" SkinID="GridView" Width="180px"
                                    DataKeyNames="PersonalAgencyName" DataSourceID="odsPersonalAgency"  ShowFooter="True" 
                                    OnRowUpdating="grdPersonalAgency_RowUpdating" 
                                    OnRowDeleting="grdPersonalAgency_RowDeleting" OnRowCommand="grdPersonalAgency_RowCommand"
                                    OnDataBound="grdPersonalAgency_DataBound"  AutoGenerateColumns="False" 
                                    onrowediting="grdPersonalAgency_RowEditing">
                                    <Columns>
                                       
                                       
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <EditItemTemplate>
                                                  <asp:Label ID="lblPersonalAgencyNameEdit" runat="server" SkinID="Label" Text='<%# Bind("PersonalAgencyName") %>'></asp:Label>
                                            </EditItemTemplate> 
                                            <ItemTemplate>
                                                  <asp:Label ID="lblPersonalAgencyName" runat="server" SkinID="Label" Text='<%# Bind("PersonalAgencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                       <asp:TemplateField HeaderText="Name">
                                            <HeaderStyle width="330px" wrap="False"></HeaderStyle>
                                            
                                            <EditItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxPersonalAgencyNameEdit" runat="server" SkinID="TextBox" Text='<%# Eval("PersonalAgencyName") %>' Width="320px"></asp:TextBox>
                                                            <asp:HiddenField ID="hdfPersonalAgencyNameEdit" runat="server" Value='<%# Eval("PersonalAgencyName") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvPersonalAgencyNameEdit" runat="server" ControlToValidate="tbxPersonalAgencyNameEdit" Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a name."
                                                                SkinID="Validator" ValidationGroup="personalAgencyDataEdit">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvPersonalAgencyNameEdit" style="width: 120px" runat="server" SkinID="Validator" Display="Dynamic" 
                                                                ValidationGroup="personalAgencyDataEdit" ControlToValidate="tbxPersonalAgencyNameEdit" ErrorMessage="The name is already in use. Please provide other name." 
                                                                OnServerValidate="cvPersonalAgencyNameEdit_ServerValidate">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </EditItemTemplate>    
                                            
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxPersonalAgencyName" runat="server" SkinID="TextBoxReadOnly" readonly="true" Text='<%# Eval("PersonalAgencyName") %>' Width="320px"></asp:TextBox>                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvPersonalAgencyName" style="width: 320px" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="personalAgencyData"
                                                                ControlToValidate="tbxPersonalAgencyName" ErrorMessage="You cannot delete the personal agency because it's associated with employees." OnServerValidate="cvPersonalAgencyName_ServerValidate">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            
                                            <FooterTemplate>
                                              <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxPersonalAgencyNameNew" runat="server" SkinID="TextBox" Text='<%# Eval("PersonalAgencyName") %>' Width="320px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvPersonalAgencyNameNew" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="personalAgencyDataNew"
                                                                ControlToValidate="tbxPersonalAgencyNameNew" ErrorMessage="Please provide a name." >
                                                            </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvPersonalAgencyNameNew" style="width: 120px" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="personalAgencyDataNew"
                                                                ControlToValidate="tbxPersonalAgencyNameNew" ErrorMessage="The name is already in use. Please provide other name." OnServerValidate="cvPersonalAgencyNameNew_ServerValidate">
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
                                                                OnClientClick='return confirm("Are you sure you want to delete this personal agency?");' />
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
                    <asp:ObjectDataSource ID="odsPersonalAgency" runat="server" SelectMethod="GetPersonalAgency"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_personal_agency" DeleteMethod="DummyPersonalAgencyNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyPersonalAgencyNew" InsertMethod="DummyPersonalAgencyNew"
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="PersonalAgencyName" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="PersonalAgencyName" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="PersonalAgencyName" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" /> 
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />                
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 410px; ">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
            <tr>
                <td style="width: 320px; height: 24px;" align="right">
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