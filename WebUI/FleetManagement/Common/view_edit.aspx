<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true"
    Codebehind="view_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_edit" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 600px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 600px">
                    <asp:Wizard ID="wzViews" Width="600px" Height="280px" runat="server" SkinID="Wizard"
                        ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" OnActiveStepChanged="Wizard_ActiveStepChanged"
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
                                                <ContentTemplate>
                                                    <asp:DropDownList Style="width: 140px" ID="ddlType" runat="server" SkinID="DropDownListLookup">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
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
                                            <asp:Panel ID="pnlColumnsToDisplay" runat="server" Height="185px" Width="290px" 
                                            ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlColumnsToDisplay" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdColumnsToDisplay" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="273px" OnDataBound="grdColumnsToDisplay_DataBound" DataSourceID="odsColumnsToDisplay" DataKeyNames="FmType,COMPANY_ID,DisplayID" OnPageIndexChanging="grdColumnsToDisplay_PageIndexChanging" >
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
                                                ErrorMessage="At least one option must be selected." OnServerValidate="cvgrdColumnsToDisplay_ServerValidate" ValidationGroup="ColumsToDisplay" SkinID="Validator">
                                                </asp:CustomValidator>   
                                            </asp:Panel>                                         
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsColumnsToDisplay" runat="server" SelectMethod="GetColumnsToDisplay"
                                                            TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_edit"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
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
                                            <asp:GridView ID="grdConditions" runat="server" SkinID="GridView" Width="590px"
                                                AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="odsConditionsNew"
                                                ShowFooter="True" PageSize="8" OnDataBound="grdConditions_DataBound" OnRowCommand="grdConditions_RowCommand" 
                                                OnRowDataBound="grdConditions_RowDataBound" OnRowDeleting="grdConditions_RowDeleting" OnRowEditing="grdConditions_RowEditing" 
                                                OnRowUpdating="grdConditions_RowUpdating">
                                                <Columns>
                                                
                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="False">
                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                        <EditItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                       </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>                                                                    
                                                                </tbody>
                                                            </table>       
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                    
                                                    <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                        <EditItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>                                                                    
                                                                </tbody>
                                                            </table>      
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="No">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                        <EditItemTemplate>
                                                           <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlConditionNumber" runat="server" EnableViewState="False"
                                                                                SkinID="DropDownList" Style="width: 40px" SelectedValue='<%# GetConditionNumberSelected(Eval("ConditionNumber")) %>'>
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
                                                        <FooterTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="height: 12px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlConditionNumber" runat="server" EnableViewState="False"
                                                                            SkinID="DropDownList" Style="width: 40px" SelectedValue='<%# GetConditionNumberSelected(Eval("ConditionNumber")) %>'>
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
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Condition">
                                                        <HeaderStyle Width="170px"></HeaderStyle>
                                                        <EditItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlName" runat="server" SkinID="DropDownListLookup" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" DataSourceID="odsConditionsToDisplay" DataTextField="Name" DataValueField="ConditionID" Width="160px"></asp:DropDownList>
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
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="height: 12px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlName" runat="server" SkinID="DropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlNameNew_SelectedIndexChanged" DataSourceID="odsConditionsToDisplay" DataTextField="Name" DataValueField="ConditionID" Width="160px"></asp:DropDownList>
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
                                                                    <td>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Operator">
                                                        <HeaderStyle Width="170px"></HeaderStyle>
                                                        <EditItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td>
                                                                           <asp:DropDownList ID="ddlOperator" runat="server" EnableViewState="true" SkinID="DropDownList" Width="160px"></asp:DropDownList>
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
                                                                            <asp:DropDownList ID="ddlOperator" runat="server" EnableViewState="true" SkinID="DropDownList" Width="160px"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>                                                                    
                                                                </tbody>
                                                            </table>
                                                        </FooterTemplate>
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
                                                        <EditItemTemplate>
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>                                                                    
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxValue" runat="server" SkinID="TextBox" Text='<%# Eval("Value_") %>' Width="170px"></asp:TextBox>
                                                                            <asp:DropDownList ID="ddlValue" runat="server" SkinID="DropDownList" Width="170px" Visible="false"></asp:DropDownList>
                                                                            <asp:RadioButton ID="rbtnYes" SkinID="RadioButton" GroupName="rbtnValue" Text="Yes" runat="server" Visible="false" />
                                                                            <asp:RadioButton ID="rbtnNo" SkinID="RadioButton" GroupName="rbtnValue" Text="No" runat="server" Visible="false" />                                                                            
                                                                            <asp:Label ID="lblValidateValue" runat="server" Visible="false" Text="No Sub Areas available, cannot use this field as a condition" SkinID="LabelError"></asp:Label>                                                                            
                                                                        </td>
                                                                    </tr> 
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvValueData" runat="server" ControlToValidate="tbxValue" Display="Dynamic" ErrorMessage="htr" OnServerValidate="cvValueData_ServerValidate" SkinID="Validator" ValidateEmptyText="True" ValidationGroup="ConditionsUpdate"></asp:CustomValidator>
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
                                                                            <asp:TextBox ID="tbxValue" runat="server" SkinID="TextBox" Text='<%# Eval("Value_") %>' Width="170px"></asp:TextBox>
                                                                            <asp:DropDownList ID="ddlValue" runat="server" SkinID="DropDownList" Width="170px" Visible="false"></asp:DropDownList>
                                                                            <asp:RadioButton ID="rbtnYes" SkinID="RadioButton" GroupName="rbtnValue" Text="Yes" Checked="True" runat="server" Visible="false" />
                                                                            <asp:RadioButton ID="rbtnNo" SkinID="RadioButton" GroupName="rbtnValue" Text="No" Checked="false" runat="server" Visible="false" />
                                                                            <asp:Label ID="lblValidateValue" runat="server" Visible="false" Text="No Sub Areas available, cannot use this field as a condition" SkinID="LabelError"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvValueData" runat="server" ControlToValidate="tbxValue" Display="Dynamic" EnableViewState="False" ErrorMessage="" OnServerValidate="cvValueData_ServerValidate" SkinID="Validator" ValidateEmptyText="True" ValidationGroup="Conditions"></asp:CustomValidator>
                                                                        </td>
                                                                    </tr>                                                                    
                                                                </tbody>
                                                            </table>
                                                        </FooterTemplate>
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
                                                    
                                                    <asp:TemplateField>
                                                        <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                            OnClientClick='return confirm("Are you sure you want to delete this condition?");' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </contenttemplate>
                                            </asp:UpdatePanel>
                                            <asp:CustomValidator ID="cvGrdConditions" runat="server" Display="Dynamic" 
                                                ErrorMessage="Duplicated condition number. (you already have this condition number here)" OnServerValidate="cvGrdConditions_ServerValidate" ValidationGroup="ConditionsNext" SkinID="Validator">
                                            </asp:CustomValidator>                                               
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
                                                    <asp:GridView ID="grdLogic" runat="server" SkinID="GridView" Width="590px"
                                                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="odsConditionsNew"
                                                        ShowFooter="True" PageSize="4">
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
                                            <asp:TextBox ID="tbxLogic" runat="server" style =" Height:116px; width:590px" SkinID="TextBox"
                                    TextMode="MultiLine"></asp:TextBox>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:CustomValidator ID="cvLogic" runat="server" Display="Dynamic" OnServerValidate="cvLogic_ServerValidate" SkinID="Validator" ValidationGroup="Logic"></asp:CustomValidator>
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
                                            <asp:GridView ID="grdSort" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="6" SkinID="GridView" Width="440px" OnDataBound="grdSort_DataBound" DataSourceID="odsSort" DataKeyNames="FmType,COMPANY_ID,SortID" OnPageIndexChanging="grdSort_PageIndexChanging" >
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
                                                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
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
                                            <asp:CustomValidator ID="cvGrdSort" runat="server" Display="Dynamic" 
                                            ErrorMessage="At least one option must be selected" OnServerValidate="cvGrdSort_ServerValidate" ValidationGroup="SortBy" SkinID="Validator">
                                            </asp:CustomValidator>
                                        </td>
                                        <td colspan="1">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsSort" runat="server" SelectMethod="GetSort"
                                                            TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_edit"></asp:ObjectDataSource>
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
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" style =" Height:230px; width:590px" ReadOnly="True" SkinID="TextBoxReadOnly"
                                    TextMode="MultiLine"></asp:TextBox>
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
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsConditionsNew" runat="server" SelectMethod="GetConditionsNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Common.view_edit" DeleteMethod="DummyConditionsNew" FilterExpression="(Deleted = 0)" UpdateMethod="DummyConditionsNew">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                     <asp:ObjectDataSource ID="odsConditionsToDisplay" runat="server" CacheDuration="120"
                        EnableCaching="True" SelectMethod="LoadAndAddItemInView" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewConditionList" OldValuesParameterFormatString="original_{0}">
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
