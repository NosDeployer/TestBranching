<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="data_migration.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.data_migration" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzDataMigration" runat="server" Width="550px" Height="360px" ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick" OnInit="wzDataMigration_Init" OnUnload="wzDataMigration_Unload">
                        
                        <WizardSteps>
                        
                            <asp:WizardStep ID="Projects" runat="server" Title="Projects">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblFileProjects" SkinID="Label" Text="File"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <input id="htmlInputFileProjects" style=" width: 300px; height: 23px; border:solid 1px #7f9db9; font-family: Verdana; color: #797b7d; font-size: 10px; " type="file" size="30" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblResultsProjects" Text="" runat="server" SkinID="LabelError"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="Sections" runat="server" Title="Sections">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblSections" SkinID="Label" Text="File"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <input id="htmlInputFileSections" style=" width: 300px; height: 23px; border:solid 1px #7f9db9; font-family: Verdana; color: #797b7d; font-size: 10px; " type="file" size="30" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblResultsSections" Text="" runat="server" SkinID="LabelError"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">                            
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="300px" Width="100%" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
