<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="bulk_upload.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.bulk_upload" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzBulkUpload" runat="server" Width="550px" Height="360px" ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        
                        <WizardSteps>
                        
                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblFile" SkinID="label" Text="File"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <input id="htmlInputFile" style=" width: 300px; height: 23px; border:solid 1px #7f9db9; font-family: Verdana; color: #797b7d; font-size: 10px; " type="file" size="30" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblResults" Text="" runat="server" SkinID="LabelError"></asp:Label>
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
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfProjectLocation" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>