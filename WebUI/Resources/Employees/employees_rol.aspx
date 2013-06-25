<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" 
Codebehind="employees_rol.aspx.cs"
    Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_rol" Title="LFS Live"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 500px">
    
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 500px">
    
                    <asp:Wizard ID="wzRole" runat="server" ActiveStepIndex="0" DisplayCancelButton="True"
                        DisplaySideBar="False" Height="200px" OnActiveStepChanged="wzRole_ActiveStepChanged"
                        OnCancelButtonClick="wzRole_CancelButtonClick" OnFinishButtonClick="wzRole_FinishButtonClick"
                        OnNextButtonClick="wzRole_NextButtonClick" SkinID="Wizard" Width="100%">
                        <WizardSteps>
                        
                        
                        
                            <asp:WizardStep ID="StepBegin" runat="server" StepType="Start" Title="Begin">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnAdd" runat="server" Checked="True" GroupName="Operation"
                                                Text="Add" SkinID="RadioButton" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnRemove" runat="server" GroupName="Operation" Text="Remove"
                                                SkinID="RadioButton" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepRemove" runat="server" StepType="Finish" Title="Remove">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:CheckBox ID="ckbxSalesmanRemove" runat="server" SkinID="CheckBox" Text="Salesman" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:CustomValidator ID="cvSalesmanRemove" runat="server" Display="Dynamic" ErrorMessage="The team member is associated with a project as a salesman, you cannot remove this role" SkinID="Validator" ValidationGroup="Remove"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            
                            <asp:WizardStep ID="StepAdd" runat="server" StepType="Step" Title="Add">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:CheckBox ID="ckbxSalesmanAdd" runat="server" SkinID="CheckBox" Text="Salesman" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:CustomValidator ID="cvSalesmanAdd" runat="server" Display="Dynamic" ErrorMessage="The team member is associated with a project as a salesman, you cannot change the ID" SkinID="Validator" ValidationGroup="Add"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep runat="server" StepType="Finish" Title="Finish" ID="StepFinish">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSalesmanIdForProjects" runat="server" SkinID="Label" Text="ID For Projects Creation"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxSalesmanIdForProjects" runat="server" SkinID="TextBox" Text='<%# DataBinder.Eval(employeeTDS, "Tables[LFS_SALESMAN].DefaultView.[0].IdForProjects") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvSalesmanIdForProjectsAlreadyInUse" runat="server" ControlToValidate="tbxSalesmanIdForProjects"
                                                ErrorMessage="ID already in use" SkinID="Validator" Display="Dynamic" OnServerValidate="cvSalesmanIdForProjects_ServerValidate" ValidationGroup="AddSalesman"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvSalesmanIdForPrrojectsFormat" runat="server" ControlToValidate="tbxSalesmanIdForProjects"
                                                Display="Dynamic" ErrorMessage="Invalid ID (use ## format)" OnServerValidate="cvSalesmanIdForPrrojectsFormat_ServerValidate"
                                                SkinID="Validator" ValidationGroup="AddSalesman"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvSalesmanIdForProjects" runat="server" ControlToValidate="tbxSalesmanIdForProjects"
                                                ErrorMessage="Please provide an ID for the salesman" SkinID="Validator" ValidationGroup="AddSalesman"></asp:RequiredFieldValidator>
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
                    <asp:HiddenField ID="hdfEmployeeId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />                    
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>
