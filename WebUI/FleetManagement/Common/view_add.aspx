<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true"
    Codebehind="view_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_add"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 600px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 600px">
                    <asp:Wizard ID="wzViews" Width="600px" Height="280px" runat="server" SkinID="Wizard"
                        ActiveStepIndex="2" DisplayCancelButton="True" DisplaySideBar="False" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick"
                        OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <!-- Page element: 4 columns - view general info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 560px">
                                    <tr>
                                        <td style="width: 150px">
                                            <asp:Label ID="lblName" runat="server" EnableViewState="False" SkinID="Label" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                            <asp:Label ID="lblType" runat="server" EnableViewState="False" SkinID="Label" Text="Type"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxName" runat="server" Style="width: 290px" SkinID="TextBox"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="upnlViewType" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:DropDownList Style="width: 140px" ID="ddlType" runat="server" SkinID="DropDownListLookup">
                                                    </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a name."
                                                SkinID="Validator" ValidationGroup="StepBegin"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a type."
                                                InitialValue="(Select a type)" SkinID="Validator" ValidationGroup="StepBegin">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="StepColumnsToDisplay" runat="server" Title="Columns To Display">
                                <!-- Page element: 4 columns - columns to display info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="2" style="width: 150px">
                                            <asp:Label ID="lblColumnsToDisplay" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlColumnsToDisplay" runat="server" Height="185px" Width="290px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlColumnsToDisplay" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView id="grdColumnsToDisplay" runat="server" SkinID="GridView" Width="273px" __designer:wfdid="w318" 
                                                            OnPageIndexChanging="grdColumnsToDisplay_PageIndexChanging" DataKeyNames="FmType,COMPANY_ID,DisplayID" DataSourceID="odsColumnsToDisplay" 
                                                            OnDataBound="grdColumnsToDisplay_DataBound" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" DataField="FmType" Visible="False" SortExpression="FmType" HeaderText="FmType"></asp:BoundField>
                                                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                                                <asp:BoundField ReadOnly="True" DataField="DisplayID" Visible="False" SortExpression="DisplayID" HeaderText="DisplayID"></asp:BoundField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Column">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblColumn" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                                <asp:CustomValidator ID="cvGrdColumnsToDisplay" runat="server" Display="Dynamic"
                                                    ErrorMessage="At least one option must be selected." OnServerValidate="cvgrdColumnsToDisplay_ServerValidate"
                                                    ValidationGroup="ColumsToDisplay" SkinID="Validator"></asp:CustomValidator>
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:ObjectDataSource ID="odsColumnsToDisplay" runat="server" SelectMethod="GetColumnsToDisplay"
                                                TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_add">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="StepConditions" runat="server" Title="Conditions">
                                <!-- Page element: 4 columns - conditions info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblConditions" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:UpdatePanel id="upnlConditions" runat="server">
                                                <contenttemplate>
                                                    <asp:GridView ID="grdConditions" runat="server" SkinID="GridView" Width="590px" __designer:wfdid="w334"
                                                        DataKeyNames="ID" DataSourceID="odsConditionsNew" OnDataBound="grdConditions_DataBound" OnRowEditing="grdConditions_RowEditing"
                                                        AutoGenerateColumns="False" OnRowUpdating="grdConditions_RowUpdating" OnRowDeleting="grdConditions_RowDeleting"
                                                        OnRowDataBound="grdConditions_RowDataBound" OnRowCommand="grdConditions_RowCommand"
                                                        ShowFooter="True" PageSize="8" AllowPaging="True">
                                                        <Columns>
                                                            <asp:TemplateField SortExpression="ID" Visible="False" HeaderText="ID">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' __designer:wfdid="w360"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>' __designer:wfdid="w359"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>' __designer:wfdid="w358"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>' __designer:wfdid="w357"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList Style="width: 40px" ID="ddlConditionNumber" runat="server" SkinID="DropDownList"
                                                                                        EnableViewState="False" __designer:wfdid="w355" SelectedValue='<%# GetConditionNumberSelected(Eval("ConditionNumber")) %>'>
                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
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
                                                                                    <asp:DropDownList Style="width: 40px" ID="ddlConditionNumber" runat="server" SkinID="DropDownList"
                                                                                        EnableViewState="False" __designer:wfdid="w356" SelectedValue='<%# GetConditionNumberSelected(Eval("ConditionNumber")) %>'>
                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblConditionNumber" runat="server" SkinID="Label" Text='<%# Eval("ConditionNumber") %>'
                                                                                        Width="40px" __designer:wfdid="w354"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Condition">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlName" runat="server" SkinID="DropDownListLookup" Width="160px"
                                                                                        __designer:wfdid="w352" DataSourceID="odsConditionsToDisplay" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" DataTextField="Name" DataValueField="ConditionID">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
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
                                                                                    <asp:DropDownList ID="ddlName" runat="server" SkinID="DropDownList" Width="160px"
                                                                                        __designer:wfdid="w353" DataSourceID="odsConditionsToDisplay" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="ddlNameNew_SelectedIndexChanged" DataTextField="Name"
                                                                                        DataValueField="ConditionID">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="170px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Eval("Name") %>'
                                                                                        __designer:wfdid="w351"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Operator">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlOperator" runat="server" SkinID="DropDownList" Width="160px"
                                                                                        EnableViewState="true" __designer:wfdid="w367">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
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
                                                                                    <asp:DropDownList ID="ddlOperator" runat="server" SkinID="DropDownList" Width="160px"
                                                                                        EnableViewState="true" __designer:wfdid="w368">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="170px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblOperator" runat="server" SkinID="Label" Text='<%# Eval("Operator") %>'
                                                                                        __designer:wfdid="w366"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Value">
                                                                <EditItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxValue" runat="server" SkinID="TextBox" Text='<%# Eval("Value_") %>'
                                                                                        Width="170px" __designer:wfdid="w336"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddlValue" runat="server" SkinID="DropDownList" Width="170px"
                                                                                        __designer:wfdid="w337" Visible="false">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RadioButton ID="rbtnYes" runat="server" SkinID="RadioButton" Text="Yes" __designer:wfdid="w338"
                                                                                        Visible="false" GroupName="rbtnValue"></asp:RadioButton>
                                                                                    <asp:RadioButton ID="rbtnNo" runat="server" SkinID="RadioButton" Text="No" __designer:wfdid="w339"
                                                                                        Visible="false" GroupName="rbtnValue"></asp:RadioButton>
                                                                                    <asp:Label ID="lblValidateValue" runat="server" SkinID="LabelError" Text="No values available, cannot use this field as a condition"
                                                                                        __designer:wfdid="w340" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CustomValidator ID="cvValueData" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                        ValidationGroup="ConditionsUpdate" ControlToValidate="tbxValue" ErrorMessage="htr"
                                                                                        __designer:wfdid="w341" OnServerValidate="cvValueData_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
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
                                                                                    <asp:TextBox ID="tbxValue" runat="server" SkinID="TextBox" Text='<%# Eval("Value_") %>'
                                                                                        Width="170px" __designer:wfdid="w342"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddlValue" runat="server" SkinID="DropDownList" Width="170px"
                                                                                        __designer:wfdid="w343" Visible="false">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RadioButton ID="rbtnYes" runat="server" SkinID="RadioButton" Text="Yes" __designer:wfdid="w344"
                                                                                        Visible="false" GroupName="rbtnValue" Checked="True"></asp:RadioButton>
                                                                                    <asp:RadioButton ID="rbtnNo" runat="server" SkinID="RadioButton" Text="No" __designer:wfdid="w345"
                                                                                        Visible="false" GroupName="rbtnValue" Checked="false"></asp:RadioButton>
                                                                                    <asp:Label ID="lblValidateValue" runat="server" SkinID="LabelError" Text="No Sub Areas available, cannot use this field as a condition"
                                                                                        __designer:wfdid="w346" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CustomValidator ID="cvValueData" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                        ValidationGroup="Conditions" ControlToValidate="tbxValue" ErrorMessage="" __designer:wfdid="w347"
                                                                                        OnServerValidate="cvValueData_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </FooterTemplate>
                                                                <HeaderStyle Width="180px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblValue" runat="server" SkinID="Label" Text='<%# Eval("Value_") %>'
                                                                                        Width="170px" __designer:wfdid="w335"></asp:Label>
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
                                                                                    <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w363"
                                                                                        CommandName="Update"></asp:ImageButton>
                                                                                </td>
                                                                                <td style="width: 50%">
                                                                                    <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w364"
                                                                                        CommandName="Cancel"></asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
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
                                                                                    <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w365"
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
                                                                                    <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w361"
                                                                                        CommandName="Edit"></asp:ImageButton>
                                                                                </td>
                                                                                <td style="width: 50%">
                                                                                    <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w362"
                                                                                        CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this condition?");'>
                                                                                    </asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                            </contenttemplate> </asp:UpdatePanel>
                                            <asp:CustomValidator ID="cvGrdConditions" runat="server" Display="Dynamic" ErrorMessage="Duplicated condition number (you already have this condition number here"
                                                OnServerValidate="cvGrdConditions_ServerValidate" ValidationGroup="ConditionsNext"
                                                SkinID="Validator"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepLogic" runat="server" Title="Logic">
                                <!-- Page element: 4 columns - conditions info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblLogic" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:UpdatePanel id="upnlLogic" runat="server">
                                                <contenttemplate>
<asp:GridView id="grdLogic" runat="server" SkinID="GridView" Width="590px" __designer:wfdid="w303" DataKeyNames="ID" DataSourceID="odsConditionsNew" AutoGenerateColumns="False" ShowFooter="True" PageSize="4" AllowPaging="True">
                                                        <Columns>
                                                        
                                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="False">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>                                                    
                                                            
                                                            <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="No">
                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblConditionNumber" runat="server" SkinID="Label" Text='<%# Eval("ConditionNumber") %>' Width="40px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>                                                        
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Condition">
                                                                <HeaderStyle Width="170px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Operator">
                                                                <HeaderStyle Width="170px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblOperator" runat="server" SkinID="Label" Text='<%# Eval("Operator") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Value">
                                                                <HeaderStyle Width="180px"></HeaderStyle>                                                                                                                
                                                                <ItemTemplate>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblValue" runat="server" SkinID="Label" Text='<%# Eval("Value_") %>' Width="170px"></asp:Label>
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
                                    <tr>
                                        <td height="7" colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox ID="tbxLogic" runat="server" Style="height: 116px; width: 590px" SkinID="TextBox"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:CustomValidator ID="cvLogic" runat="server" Display="Dynamic" OnServerValidate="cvLogic_ServerValidate"
                                                SkinID="Validator" ValidationGroup="Logic"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep ID="StepSortBy" runat="server" Title="Sort By">
                                <!-- Page element: 4 columns - sortby info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="2" style="width: 150px">
                                            <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                                        </td>
                                        <td colspan="1" style="width: 150px">
                                        </td>
                                        <td colspan="1" style="width: 150px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel id="upnlAddLateralsSearch" runat="server">
                                                <contenttemplate>
<asp:GridView id="grdSort" runat="server" SkinID="GridView" Width="440px" __designer:wfdid="w297" OnPageIndexChanging="grdSort_PageIndexChanging" DataKeyNames="FmType,COMPANY_ID,SortID" DataSourceID="odsSort" OnDataBound="grdSort_DataBound" AutoGenerateColumns="False" PageSize="6" AllowPaging="True">
                                                        <Columns>
                                                            <asp:BoundField ReadOnly="True" DataField="FmType" Visible="False" SortExpression="FmType" HeaderText="FmType"></asp:BoundField>
                                                            <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                                            <asp:BoundField ReadOnly="True" DataField="SortID" Visible="False" SortExpression="SortID" HeaderText="SortID"></asp:BoundField>
                                                            
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Column">
                                                                <HeaderStyle Width="250px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblColumn" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Order">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Width="80px" HorizontalAlign="Center" ></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlOrder" runat="server" EnableViewState="False"
                                                                        SkinID="DropDownList" Style="width: 70px" SelectedValue='<%# GetOrderSelected(Eval("Order_")) %>'>
                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView> 
</contenttemplate>
                                            </asp:UpdatePanel>
                                            <asp:CustomValidator ID="cvGrdSort" runat="server" Display="Dynamic" ErrorMessage="At least one option must be selected"
                                                OnServerValidate="cvGrdSort_ServerValidate" ValidationGroup="SortBy" SkinID="Validator"></asp:CustomValidator>
                                        </td>
                                        <td colspan="1">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsSort" runat="server" SelectMethod="GetSort" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_add">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep ID="StepSummary" runat="server" Title="Summary">
                                <!-- Page element: 1 column - summary info -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxSummary" runat="server" Style="height: 230px; width: 590px" ReadOnly="True"
                                                SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfStep" runat="server" />
                    <asp:HiddenField ID="hdfViewId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsConditionsNew" runat="server" SelectMethod="GetConditionsNew"
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_add" DeleteMethod="DummyConditionsNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyConditionsNew">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsConditionsToDisplay" runat="server" CacheDuration="120"
                        EnableCaching="True" SelectMethod="LoadAndAddItemInView" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewConditionList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="fmType" QueryStringField="fm_type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inView" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
