<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mForm6.Master" AutoEventWireup="true" CodeBehind="unitsOfMeasurement_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement.unitsOfMeasurement_navigator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Units Of Measurement" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mModuleAssociation" Text="Module Association"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            
        </table>                        
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlGrdUnitsOfMeasurement" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdUnitsOfMeasurement" runat="server" SkinID="GridView" OnRowUpdating="grdUnitsOfMeasurement_RowUpdating"
                                OnRowDeleting="grdUnitsOfMeasurement_RowDeleting" OnRowCommand="grdUnitsOfMeasurement_RowCommand" OnRowEditing="grdUnitsOfMeasurement_RowEditing"
                                OnDataBound="grdUnitsOfMeasurement_DataBound" ShowFooter="True" DataSourceID="odsUnitOfMeasurementNew"
                                DataKeyNames="UnitOfMeasurementID" AllowPaging="True" AutoGenerateColumns="False" PageSize="5"
                                Width="340">
                                <Columns>
                                    <asp:TemplateField SortExpression="UnitOfMeasurementID" Visible="False" HeaderText="UnitOfMeasurementID">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblUnitOfMeasurementId" runat="server" Text='<%# Eval("UnitOfMeasurementID") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitOfMeasurementId" runat="server" Text='<%# Eval("UnitOfMeasurementID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Unit of Measurement Info">
                                        <EditItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10px; height: 10px">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>                    
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDescriptionEdit" runat="server" SkinID="Label" 
                                                                Text="Description" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAbbreviationEdit" runat="server" SkinID="Label" Text="Abbreviation"
                                                                EnableViewState="False" ></asp:Label>
                                                        </td>                                                
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDescriptionEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Description") %>'
                                                                Width="100px" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxAbbreviationEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Abbreviation") %>'
                                                                Width="100px" ></asp:TextBox>
                                                        </td>
                                               
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                                                                SkinID="Validator" EnableViewState="False"
                                                                ValidationGroup="dataEdit" ErrorMessage="Please provide a description" Display="Dynamic"
                                                                ControlToValidate="tbxDescriptionEdit" ></asp:RequiredFieldValidator></td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rvAbbreviation" runat="server" 
                                                                SkinID="Validator" EnableViewState="False"
                                                                ValidationGroup="dataEdit" ErrorMessage="Please provide an abbreviation" Display="Dynamic"
                                                                ControlToValidate="tbxAbbreviationEdit"></asp:RequiredFieldValidator></td>
                                                        
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
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td style="width:10px; height: 12px">
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                   <td>
                                                        <asp:Label ID="lblDescriptionNew" runat="server" 
                                                            EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAbbreviationNew" runat="server"  
                                                            EnableViewState="False" SkinID="Label" Text="Abbreviation"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>                                                
                                                        <asp:TextBox ID="tbxDescriptionNew" runat="server" 
                                                            SkinID="TextBox" Text='<%# Eval("Description") %>' Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxAbbreviationNew" runat="server" 
                                                            SkinID="TextBox" Text='<%# Eval("Abbreviation") %>' Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                                                             ControlToValidate="tbxDescriptionNew" Display="Dynamic" 
                                                            EnableViewState="False" ErrorMessage="Please provide a description" 
                                                            SkinID="Validator" ValidationGroup="dataNew"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rvAbbreviation" runat="server" 
                                                             ControlToValidate="tbxAbbreviationNew" 
                                                            Display="Dynamic" EnableViewState="False" 
                                                            ErrorMessage="Please provide an abbreviation" SkinID="Validator" 
                                                            ValidationGroup="dataNew"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 12px">
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                       
                                            </table>
                                        </FooterTemplate>
                                        <HeaderStyle Width="610px"></HeaderStyle>
                                        <ItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10px; height: 10px">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDescription" runat="server" SkinID="Label" Text="Description" 
                                                                EnableViewState="False"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblAbbreviation" runat="server" SkinID="Label" 
                                                                Text="Abbreviation" EnableViewState="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDescription" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Description") %>'
                                                                Width="100px" ></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="tbxAbbreviation" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Abbreviation") %>'
                                                                Width="100px" ></asp:TextBox></td>
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
                                    
                                                             
                                    
                                    
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="height: 12px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnAccept" runat="server" CommandName="Update" SkinID="GridView_Update"
                                                            ToolTip="Update" />
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="Cancel" SkinID="GridView_Cancel"
                                                            ToolTip="Cancel" />
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
                                                        <asp:ImageButton ID="ibtnAdd" runat="server" CommandName="Add" SkinID="GridView_Add"
                                                            ToolTip="Add" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </FooterTemplate>
                                        <HeaderStyle Width="90px"></HeaderStyle>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="GridView_Edit"
                                                            ToolTip="Edit" />
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" SkinID="GridView_Delete"
                                                            OnClientClick='return confirm("Are you sure you want to delete this unit of measurement?");'
                                                            ToolTip="Delete" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField></Columns></asp:GridView>
                        </contenttemplate></asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUnitOfMeasurementNew" runat="server" SelectMethod="GetUnitOfMeasurementNew"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement.unitsOfMeasurement_navigator" DeleteMethod="DummyUnitOfMeasurementNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyUnitOfMeasurementNew">
                        <DeleteParameters>
                            <asp:Parameter Name="UnitOfMeasurementID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UnitOfMeasurementID" Type="Int32" />
                        </UpdateParameters>
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

</asp:Content>