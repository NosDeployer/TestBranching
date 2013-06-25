<%@ Page Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="company_levels_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.CompanyLevels.company_levels_edit" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzCompanyLevelsAdd" runat="server" Width="550px" Height="390px" 
                        ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" 
                        OnNextButtonClick="Wizard_NextButtonClick" 
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnCancelButtonClick="Wizard_CancelButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        
                        <WizardSteps>
                        
                            <asp:WizardStep ID="StepOperation" runat="server" Title="Operation">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnAddCompanyLevel" runat="server" Text="Add company level" Checked="True" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnEditCompanyLevel" runat="server" Text="Edit company level" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnDeleteCompanyLevel" runat="server" Text="Delete company level" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                                                   
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepCompanyLevels" runat="server" Title="Company Levels">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                    
                                    <tr>
                                        <td style="width:275px"></td>
                                        <td style="width:275px"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblCompanyLevel" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlCompanyLevel" Width="500px" Height="250px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CustomValidator ID="cvCompanyLevels" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can only choose one company level"
                                            OnServerValidate="cvCompanyLevels_ServerValidate" ValidationGroup="StepCompanyLevels" ></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px" class="Background_Separator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="lblName" SkinID="Label" Text="Name"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxName" Width="265px" runat="server" SkinID="TextBox"></asp:TextBox>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                                Display="Dynamic" ErrorMessage="Please provide a name" SkinID="Validator"
                                                ValidationGroup="StepCompanyLevelsName" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblUnitsUnitOfMeasurement" runat="server" SkinID="Label" 
                                                Text="Mileage Unit Of Measurement "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxUnitsUnitOfMeasurement" runat="server" SkinID="TextBox" 
                                                Width="265px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepCompanyLevelManagers" runat="server" Title="Company Level Managers">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">  
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlEmployees" runat="server" Height="250px" Width="245px"
                                            ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlGrdEmployees" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdEmployees" runat="server" SkinID="GridView" Width="230px" 
                                                            AutoGenerateColumns="False"  DataKeyNames="EmployeeID" DataSourceID="odsEmployees"
                                                            OnDataBound="grdEmployees_DataBound">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="EmployeeID" Visible="False" HeaderText="EmployeeID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                <asp:TemplateField ShowHeader="False" Visible="False">
                                                                    <EditItemTemplate>
                                                                          <asp:Label ID="lblInDatabaseEdit" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                          <asp:Label ID="lblInDatabase" runat="server" SkinID="Label" Text='<%# Bind("InDatabase") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                 <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="Center" />    
                                                                    <HeaderStyle Width="30px"></HeaderStyle>                        
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server"
                                                                            Checked='<%# Bind("Selected") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                                                                                  
                                                                                                    
                                                                <asp:TemplateField HeaderText="Team Member">
                                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFullName" runat="server" EnableViewState="False" SkinID="Label"
                                                                        Text='<%# Eval("FullName") %>'></asp:Label>
                                                                        
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>
                                                 
                                            </asp:Panel>
                                            <asp:CustomValidator ID="cvGrdEmployees" runat="server" Display="Dynamic" 
                                                ErrorMessage="At least one team member must be selected" OnServerValidate="cvGrdEmployees_ServerValidate" ValidationGroup="managers" SkinID="Validator">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>                                                
                                </table>
        

                                <!-- Page element: Data objects -->
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsEmployees" runat="server" FilterExpression="(Deleted = 0)"
                                                SelectMethod="GetManagers" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.CompanyLevels.company_levels_edit">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>

                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepCompanyLevels2" runat="server" Title="Company level to replace">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                    
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCompanyLevelToReplace" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCompanyLevels2" Width="500px" Height="250px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCompanyLevelsRoot2" runat="server" SkinID="SimpleTreeView">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvCompanyLevels2" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can only choose one company level"
                                            OnServerValidate="cvCompanyLevels2_ServerValidate" ValidationGroup="StepCompanyLevels2" ></asp:CustomValidator>
                                        </td>
                                    </tr>                                    
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">                            
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="100px" Width="500px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>                                                                 
                                </table>                                                          
                            </asp:WizardStep>
                            
                        </WizardSteps>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyLevelId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

