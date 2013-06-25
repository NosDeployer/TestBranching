<%@ Page Language="C#" MasterPageFile="./../mDialog2.master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.RAF.contact" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: 2 columns - contact info -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" SkinID="Label" Text="Name" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxName" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="430px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Address"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxAddress" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" TextMode="MultiLine" Width="430px" Height="56px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCity" runat="server" EnableViewState="False" SkinID="Label" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCountry" runat="server" EnableViewState="False" SkinID="Label" Text="Country"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:TextBox ID="tbxCity" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="205px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxCountry" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="205px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProvState" runat="server" EnableViewState="False" SkinID="Label" Text="Prov/State"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPostalCode" runat="server" EnableViewState="False" SkinID="Label" Text="Postal Code"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxProvState" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="120px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxPostalCode" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelephones" runat="server" EnableViewState="False" SkinID="Label" Text="Telephones"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                
                    <asp:Panel ID="pnlGrdTelephones" runat="server" Width="430px" ScrollBars="Auto">                                     
                
                        <asp:UpdatePanel id="upnlTelephones" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdTelephones" runat="server" SkinID="GridView" Width="100%"
                                DataKeyNames="PHONE_ID" DataSourceID="odsPhones"  
                                OnDataBound="grdTelephones_DataBound" PageSize="5" AutoGenerateColumns="False">
                                    <Columns>
                                                                              
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblPHONE_ID" runat="server" SkinID="Label" Text='<%# Bind("PHONE_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                            
                                        
                                        
                                        <asp:TemplateField HeaderText="Telephone" SortExpression="TELEPHONE">
                                            <ItemStyle horizontalalign="Center" wrap="False" ></ItemStyle>
                                            <HeaderStyle width="145px" wrap="false"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelephone" runat="server" SkinID="Label" Text='<%# Bind("TELEPHONE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Extension" SortExpression="TELEPHONE_EXT">
                                            <HeaderStyle width="105px"></HeaderStyle>
                                            <ItemStyle  HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelephoneExtension" runat="server" SkinID="Label" Text='<%# Bind("TELEPHONE_EXT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Type" SortExpression="TELEPHONE_TYPE">
                                            <HeaderStyle width="105px"></HeaderStyle>
                                            <ItemStyle wrap="false" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelephoneType" runat="server" SkinID="Label" Text='<%# Bind("TELEPHONE_TYPE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Primary" SortExpression="PRIMARY_PHONE">
                                            <HeaderStyle width="60px"></HeaderStyle>
                                            <ItemStyle wrap="false" HorizontalAlign="Center"/>
                                            <ItemTemplate>
                                                <asp:CheckBox id="cbxPrimaryPhone" onclick="return cbxClick(this);" runat="server" SkinID="CheckBox" Checked='<%# Eval("PRIMARY_PHONE") %>'></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                    </Columns>
                                </asp:GridView>
                            </contenttemplate>    
                        </asp:UpdatePanel>
                    </asp:Panel>
               
                                    
                </td>
            </tr>          

        </table>
        
         <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsPhones" runat="server" FilterExpression="(ACTIVE = 1)"
                        SelectMethod="GetPhonesNew" TypeName="LiquiForce.LFSLive.WebUI.RAF.contact">
                    </asp:ObjectDataSource>                    
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfContactId" runat="server" />
                </td>
            </tr>
        </table>
                      
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 450;">
        <table border="0" cellpadding="0" cellspacing="0" width="430">
            <tr>
                <td style="width: 350px">
                </td>
                <td style="width: 80px">
                    <asp:Button ID="btnCancel" runat="server" EnableViewState="False" OnClientClick="javascript:window.close();"
                        SkinID="Button" Text="Close" Width="80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
