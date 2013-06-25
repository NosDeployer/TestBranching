<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true"
    Codebehind="jliner_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_add"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wizard" runat="server" ActiveStepIndex="2" SkinID="Wizard" Width="100%"
                        Height="400px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick"
                        OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick"
                        TabIndex="50">
                        <WizardSteps>
                            <asp:WizardStep ID="Section1" runat="server" Title="Section1">
                                <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="lblRecordIdForSearch" runat="server" Text="Section ID" SkinID="Label"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="lblStreetForSearch" runat="server" Text="Street" SkinID="Label" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                        </td>
                                        <td style="width: 25%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxRecordIdForSearch" runat="server" SkinID="TextBox" TabIndex="1"
                                                Width="120px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxStreetForSearch" runat="server" SkinID="TextBox" TabIndex="1"
                                                Width="258px"></asp:TextBox>
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
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:CustomValidator ID="cvSection1" runat="server" Display="Dynamic" EnableViewState="False"
                                                ErrorMessage="Sections not found" SkinID="Validator" ValidationGroup="Section1"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep ID="Section2" runat="server" Title="Section2">
                                <!-- Page element: 1 column - grid -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlGrdSection" runat="server" Width="559px" Height="300px" ScrollBars="Vertical"
                                                BorderWidth="1px">
                                                <asp:GridView ID="grdSection" runat="server" Width="549px" OnDataBound="grdSection_DataBound"
                                                    DataSourceID="odsSections" DataKeyNames="ID" AutoGenerateColumns="False" SkinID="GridView">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Style="width: 100px" Text='<%# Bind("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Street" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStreetGrid" runat="server" Style="width: 100px" Text='<%# Bind("Street") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ActualLength" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblActualLengthGrid" runat="server" Style="width: 100px" Text='<%# Bind("ActualLength") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="USMH" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUsmh" runat="server" Style="width: 100px" Text='<%# Bind("USMH") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DSMH" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDsmh" runat="server" Style="width: 100px" Text='<%# Bind("DSMH") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                    Checked='<%# Bind("Selected") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Section ID">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="lblRecordId" runat="server" SkinID="Label" Text='<%# Eval("RecordID") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="97px"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Street">
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblStreet" runat="server" Text='<%# Eval("Street") %>' SkinID="Label"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="243px"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Laterals">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="lblNumLats" runat="server" SkinID="Label" Text='<%# Eval("NumLats") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="97px"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Not Lined Yet">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="lblNotLinedYet" runat="server" SkinID="Label" Text='<%# Eval("NotLinedYet") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="97px"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvSelection" runat="server" ValidationGroup="sectionsGrid"
                                                Display="Dynamic" SkinID="Validator" OnServerValidate="cvSelection_ServerValidate"
                                                ErrorMessage="Please select one section"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep ID="Jliner" runat="server" Title="Jliner">
                                <!-- Table element: 4 columns - Section data -->
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="lblRecordId" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Section ID"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                        </td>
                                        <td style="width: 25%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxRecordId" runat="server" SkinID="TextBoxReadOnly" Width="120px"
                                                ReadOnly="True" TabIndex="2"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxStreet" runat="server" SkinID="TextBoxReadOnly" Width="258px"
                                                ReadOnly="True" TabIndex="3"></asp:TextBox>
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblActualLength" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Actual Length"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxActualLength" runat="server" SkinID="TextBoxReadOnly" Width="120px"
                                                ReadOnly="True" TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxUSMH" runat="server" SkinID="TextBoxReadOnly" Width="120px" ReadOnly="True"
                                                TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxDSMH" runat="server" SkinID="TextBoxReadOnly" Width="120px" ReadOnly="True"
                                                TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td>
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
                                </table>
                                <!-- Page element: 1 column - grid -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLaterals" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Laterals"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel id="upnlColumnsToDisplay" runat="server">
                                                <contenttemplate>
                                                    <asp:GridView id="grdJliner2" runat="server" SkinID="GridView" Width="448px" 
                                                    OnRowUpdating="grdJliner2_RowUpdating" OnRowDeleting="grdJliner2_RowDeleting" 
                                                    OnRowCommand="grdJliner2_RowCommand" OnDataBound="grdJliner2_DataBound" 
                                                    DataKeyNames="ID,RefID,COMPANY_ID" AllowPaging="True" AutoGenerateColumns="False" 
                                                    OnRowDataBound="grdJliner2_RowDataBound" ShowFooter="True" DataSourceID="odsJliner2" 
                                                    OnRowEditing="grdJliner2_RowEditing"><Columns>
                                                    <asp:TemplateField Visible="False" HeaderText="ID" ShowHeader="False"><EditItemTemplate>
                                                            <asp:Label ID="lblIDEdit" runat="server" SkinID="Label" Text='<%# Bind("ID") %>'></asp:Label>
                                                        
</EditItemTemplate>
<ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" SkinID="Label" Text='<%# Bind("ID") %>'></asp:Label>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RefID" ShowHeader="False"><EditItemTemplate>
                                                            <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                                        
</EditItemTemplate>
<ItemTemplate>
                                                            <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="COMPANY_ID" ShowHeader="False"><EditItemTemplate>
                                                            <asp:Label ID="lblCOMPANY_IDEdit" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                                        
</EditItemTemplate>
<ItemTemplate>
                                                            <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="InDatabase" ShowHeader="False"><EditItemTemplate>
                                                            <asp:Label ID="lblInDatabaseEdit" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                        
</EditItemTemplate>
<ItemTemplate>
                                                            <asp:Label ID="lblInDatabase" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Lateral ID">
<EditItemTemplate>
    <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY>
        <TR>
            <TD><asp:TextBox id="tbxDetailIdEdit" runat="server" SkinID="TextBox" Text='<%# Eval("DetailID") %>' Width="80px" __designer:wfdid="w2"></asp:TextBox> </TD></TR><TR><TD><asp:CustomValidator id="cvDetailIdEdit" runat="server" SkinID="Validator" __designer:wfdid="w3" ControlToValidate="tbxDetailIdEdit" Display="Dynamic" ErrorMessage="Lateral ID is already in use" OnServerValidate="cvDetailIdEdit_ServerValidate" ValidationGroup="dataEdit"></asp:CustomValidator> <asp:CustomValidator id="cvProvideLateralIdEdit" runat="server" SkinID="Validator" __designer:wfdid="w4" ControlToValidate="tbxDetailIdEdit" Display="Dynamic" ErrorMessage="Please provide a Lateral ID" OnServerValidate="cvProvideLateralIdEdit_ServerValidate" ValidationGroup="dataEdit" ValidateEmptyText="True"></asp:CustomValidator> </TD></TR></TBODY></TABLE>
</EditItemTemplate>
<FooterTemplate>
    <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY>
        <TR>
            <TD style="HEIGHT: 7px"></TD>
        </TR>
        <TR>
            <TD><asp:TextBox id="tbxDetailIdFooter" runat="server" SkinID="TextBox" Text='<%# Eval("DetailID") %>' Width="80px" __designer:wfdid="w5"></asp:TextBox> </TD></TR><TR><TD><asp:CustomValidator id="cvDetailIdFooter" runat="server" SkinID="Validator" __designer:wfdid="w6" ControlToValidate="tbxDetailIdFooter" Display="Dynamic" ErrorMessage="Lateral ID is already in use" OnServerValidate="cvDetailIdFooter_ServerValidate" ValidationGroup="dataFooter"></asp:CustomValidator> <asp:CustomValidator id="cvProvideDetailIdFooter" runat="server" SkinID="Validator" __designer:wfdid="w7" ControlToValidate="tbxDetailIdFooter" Display="Dynamic" ErrorMessage="Please provide a Lateral ID" OnServerValidate="cvProvideLateralIdFooter_ServerValidate" ValidationGroup="dataFooter" ValidateEmptyText="True"></asp:CustomValidator> </TD></TR><TR><TD style="HEIGHT: 7px"></TD></TR></TBODY></TABLE>
</FooterTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
    <ItemTemplate>
    <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY>
        <TR>
            <TD style="TEXT-ALIGN: center"><asp:Label id="lblLateralId" runat="server" SkinID="Label" Text='<%# Bind("DetailID") %>' __designer:wfdid="w1"></asp:Label> 
            </TD>
        </TR>
    </TBODY></TABLE>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><EditItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD><asp:TextBox id="tbxAddressEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Address") %>' Width="188px" __designer:wfdid="w160"></asp:TextBox> </TD></TR></TBODY></TABLE>
</EditItemTemplate>
<FooterTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 7px"></TD></TR><TR><TD><asp:TextBox id="tbxAddressFooter" runat="server" SkinID="TextBox" Text='<%# Eval("Address") %>' Width="188px" __designer:wfdid="w161"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 7px"></TD></TR></TBODY></TABLE>
</FooterTemplate>

<HeaderStyle Width="188px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD><asp:Label id="lblAddress" runat="server" SkinID="Label" Text='<%# Bind("Address") %>' __designer:wfdid="w159"></asp:Label> </TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Distance (from USMH)"><EditItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxDistanceFromUSMHEdit" runat="server" SkinID="TextBox" Text='<%# Eval("DistanceFromUSMH", "{0:n1}") %>'
                                                                                Width="130px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvDistanceFromUsmhEdit" runat="server" ControlToValidate="tbxDistanceFromUSMHEdit"
                                                                                Display="Dynamic" ErrorMessage="The Distance From USMH of the Lateral is invalid (must be equal or greater than 0)"
                                                                                OnServerValidate="cvDistanceFromUsmhEdit_ServerValidate" SkinID="Validator" ValidationGroup="dataEdit"></asp:CustomValidator>
                                                                            <asp:CompareValidator ID="cvDistanceFromUsmhTypeEdit" runat="server" ControlToValidate="tbxDistanceFromUSMHEdit"
                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                            <asp:CustomValidator ID="cvDistanceDsmhEdit" runat="server" ControlToValidate="tbxDistanceFromUSMHEdit"
                                                                                Display="Dynamic" ErrorMessage="The calculation for Distance From DSMH  is invalid (must be equal or greater than 0)"
                                                                                OnServerValidate="cvDistanceDsmhEdit_ServerValidate" SkinID="Validator" ValidationGroup="dataEdit"></asp:CustomValidator></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        
</EditItemTemplate>
<FooterTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxDistanceFromUSMHFooter" runat="server" SkinID="TextBox" Text='<%# Eval("DistanceFromUSMH", "{0:n1}") %>'
                                                                                Width="130px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvDistanceFromUsmhFooter" runat="server" ControlToValidate="tbxDistanceFromUSMHFooter"
                                                                                Display="Dynamic" ErrorMessage="The Distance From USMH of the Lateral is invalid (must be equal or greater than 0)"
                                                                                OnServerValidate="cvDistanceFromUsmhFooter_ServerValidate" SkinID="Validator"
                                                                                ValidationGroup="dataFooter"></asp:CustomValidator>
                                                                            <asp:CustomValidator ID="cvDistanceDsmhFooter" runat="server" ControlToValidate="tbxDistanceFromUSMHFooter"
                                                                                Display="Dynamic" ErrorMessage="The calculation for Distance From DSMH  is invalid (must be equal or greater than 0)"
                                                                                OnServerValidate="cvDistanceDsmhFooter_ServerValidate" SkinID="Validator" ValidationGroup="dataFooter"></asp:CustomValidator>
                                                                            <asp:CompareValidator ID="cvDistanceFromUsmhTypeFooter" runat="server" ControlToValidate="tbxDistanceFromUSMHFooter"
                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        
</FooterTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="130px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="text-align: center">
                                                                            <asp:Label ID="lblDistanceFromUSMH" runat="server" SkinID="Label" Text='<%# Bind("DistanceFromUSMH", "{0:n1}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="History" ShowHeader="False"><EditItemTemplate>
                                                            <asp:Label ID="lblHistoryEdit" runat="server" SkinID="Label" Text='<%# Bind("History") %>'
                                                                __designer:wfdid="w171"></asp:Label>
                                                        
</EditItemTemplate>
<ItemTemplate>
                                                            <asp:Label ID="lblHistory" runat="server" SkinID="Label" Text='<%# Bind("History") %>'
                                                                __designer:wfdid="w170"></asp:Label>
                                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
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
                                                                            OnClientClick='return confirm("Are you sure you want to delete this lateral?");' />
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
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsSections" runat="server" SelectMethod="GetSectionsNew"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_add" FilterExpression="(Deleted = 0)">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsJliner2" runat="server" UpdateMethod="DummyJlinerNew"
                        FilterExpression="(Deleted = 0)" DeleteMethod="DummyJlinerNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_add"
                        SelectMethod="GetJlinerNew">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfRecordId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedId" runat="server" />
                    <asp:HiddenField ID="hdfStreet" runat="server" />
                    <asp:HiddenField ID="hdfActualLength" runat="server" />
                    <asp:HiddenField ID="hdfUsmh" runat="server" />
                    <asp:HiddenField ID="hdfDsmh" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
