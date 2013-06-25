<%@ Page Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="employees_costing_setup.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_costing_setup" Title="LFS Live"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="360px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">                               
                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblEmployeeCostTilte" runat="server" EnableViewState="False" SkinID="Label" Text="Setup job costing factors"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlCostSetup" runat="server" Height="260px" Width="500px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlCostSetup" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdCostSetup" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="483px" 
                                                            DataSourceID="odsCostsSetup" DataKeyNames="EmployeeID" >
                                                            <Columns>
                                                            
                                                                <asp:TemplateField HeaderText="Team Member">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="250px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeName" runat="server" SkinID="Label" Text='<%# Bind("FullName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Burden Factor (%)">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBourdenFactor" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# GetRound(Eval("BourdenFactor"),1) %>' Width="73px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBourdenFactor" runat="server" Operator="DataTypeCheck" Type="Double" 
                                                                                    ControlToValidate="tbxBourdenFactor" ValidationGroup="Begin" SkinID="Validator" Display="Dynamic"  
                                                                                    ErrorMessage="Invalid data. (use #.# format)">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="US Health Benefit Factor (%)">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUSHealthBenefitFactor" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# GetRound(Eval("USHealthBenefitFactor"),1) %>' Width="73px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>  
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvUSHealthBenefitFactor" runat="server" Operator="DataTypeCheck" 
                                                                                    Type="Double" ControlToValidate="tbxUSHealthBenefitFactor" ValidationGroup="Begin" 
                                                                                    SkinID="Validator" Display="Dynamic"  ErrorMessage="Invalid data. (use #.# format)">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                          
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                 <asp:TemplateField HeaderText="Benefit Factor (Cad)">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBenefitFactorCad" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# GetRound(Eval("BenefitFactorCad"),2) %>' Width="73px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>  
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBenefitFactorCad" runat="server" Operator="DataTypeCheck" 
                                                                                    Type="Double" ControlToValidate="tbxBenefitFactorCad" ValidationGroup="Begin" 
                                                                                    SkinID="Validator" Display="Dynamic"  ErrorMessage="Invalid data. (use #.## format)">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                          
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Benefit Factor (Usd)">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBenefitFactorUsd" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# GetRound(Eval("BenefitFactorUsd"),2) %>' Width="73px" ></asp:TextBox>
                                                                                </td>
                                                                            </tr>  
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBenefitFactorUsd" runat="server" Operator="DataTypeCheck" 
                                                                                    Type="Double" ControlToValidate="tbxBenefitFactorUsd" ValidationGroup="Begin" 
                                                                                    SkinID="Validator" Display="Dynamic"  ErrorMessage="Invalid data. (use #.## format)">
                                                                                    </asp:CompareValidator>
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
                                            <asp:ObjectDataSource ID="odsCostsSetup" runat="server"
                                                SelectMethod="GetCostsSetupNew" 
                                                TypeName="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_costing_setup"
                                                DeleteMethod="DummyCostsSetupNew" InsertMethod="DummyCostsSetupNew" UpdateMethod="DummyCostsSetupNew" >
                                            </asp:ObjectDataSource>
                                        </td>                                                                               
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="450px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>                                    
                                </table>
                            </asp:WizardStep>
                                                        
                        </WizardSteps>
                        
                        
                       <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>                                    
                                    <td style="width: 180px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right;">
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="FinishButton" Style="width: 80px" runat="server" CommandName="MoveComplete"
                                            Text="Finish" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </FinishNavigationTemplate>
                      
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
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>