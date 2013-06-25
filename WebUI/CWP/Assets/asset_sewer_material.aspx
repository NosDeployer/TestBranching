<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true"
    Codebehind="asset_sewer_material.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Assets.asset_sewer_material"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 430px;">
        <!-- Page element: 2 columns - material info -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 400px">
            <tr>
                <td colspan="2" rowspan="9" style="width: 400px">
                     <asp:UpdatePanel id="upnlSewerMaterial" runat="server">
                        <contenttemplate>
                        <asp:GridView ID="grdMaterials" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                            PageSize="10" OnDataBound="grdMaterials_DataBound" OnRowCommand="grdMaterials_RowCommand"
                            OnRowDeleting="grdMaterials_RowDeleting" OnRowUpdating="grdMaterials_RowUpdating"
                            AllowPaging="True" ShowFooter="True" DataSourceID="odsMaterialType" DataKeyNames="AssetID, RefID"
                            OnRowDataBound="grdMaterials_RowDataBound" Width="400px">
                            <Columns>
                                <asp:TemplateField Visible="False" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAssetIDEdit" runat="server" SkinID="Label" Text='<%# Bind("AssetID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetID" runat="server" SkinID="Label" Text='<%# Bind("AssetID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCOMPANY_IDEdit" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDeletedEdit" runat="server" SkinID="Label" Text='<%# Bind("Deleted") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeleted" runat="server" SkinID="Label" Text='<%# Bind("Deleted") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInDatabaseEdit" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInDatabase" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material Type">
                                    <EditItemTemplate>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: middle">
                                                        <asp:DropDownList ID="ddlMaterialTypeEdit" runat="server" SkinID="DropDownListLookup"
                                                            DataSourceID="odsMaterialsList" Width="190px" ValidationGroup="materialDataEdit"
                                                            DataValueField="MaterialType" DataTextField="MaterialType" AutoPostBack="True"
                                                            __designer:wfdid="w7">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvMaterialType" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="materialDataEdit" InitialValue="(Select a material type)"
                                                            ErrorMessage="Please select a material type" ControlToValidate="ddlMaterialTypeEdit"
                                                            __designer:wfdid="w8"></asp:RequiredFieldValidator>
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
                                                        <asp:DropDownList ID="ddlMaterialTypeFooter" runat="server" SkinID="DropDownListLookup"
                                                            DataSourceID="odsMaterialsList" Width="190px" ValidationGroup="materialDataFooter"
                                                            DataValueField="MaterialType" DataTextField="MaterialType" AutoPostBack="True"
                                                            __designer:wfdid="w9">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvMaterialTypeFooter" runat="server" SkinID="Validator"
                                                            EnableViewState="False" ValidationGroup="materialDataFooter" InitialValue="(Select a material type)"
                                                            ErrorMessage="Please select a material type" ControlToValidate="ddlMaterialTypeFooter"
                                                            __designer:wfdid="w10"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </FooterTemplate>
                                    <HeaderStyle Width="200px" Wrap="False"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialType" runat="server" SkinID="Label" Text='<%# Bind("MaterialType") %>'
                                            __designer:wfdid="w6"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date &amp; Time">
                                    <EditItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDate_Edit" runat="server" SkinID="Label" Text='<%# Bind("Date_", "{0:g}") %>'></asp:Label>
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
                                                    <asp:Label ID="lblDate_Footer" runat="server" SkinID="Label" />
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <HeaderStyle Width="150px"></HeaderStyle>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDate_" runat="server" SkinID="Label" Text='<%# Bind("Date_", "{0:g}") %>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnAccept" runat="server" CommandName="Update" SkinID="GridView_Update" />
                                                </td>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="Cancel" SkinID="GridView_Cancel" />
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
                                        </table>
                                    </FooterTemplate>
                                    <HeaderStyle Width="50px"></HeaderStyle>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" SkinID="GridView_Edit" />
                                                </td>
                                                <td style="width: 50%">
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" SkinID="GridView_Delete"
                                                        OnClientClick='return confirm("Are you sure you want to delete this material?");' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </contenttemplate> </asp:UpdatePanel>
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
                    <asp:ObjectDataSource ID="odsMaterialsList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.MaterialTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a material type)" Name="materialType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsMaterialType" runat="server" SelectMethod="GetMaterials"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.Assets.asset_sewer_material" DeleteMethod="DummyMaterialsNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyMaterialsNew" InsertMethod="DummyMaterialsNew"
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
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
    <div style="width: 430px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 340px; height: 24px;" align="right">
                    <asp:Button ID="btnSave1" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Save" Style="width: 80px" OnClick="btnSave_Click" />
                </td>
                <td style="width: 90px; height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close" Style="width: 80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
