<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="hotels_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Hotels.hotels_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script language="javascript" type="text/javascript">
        function OnUnload() {
            window.opener.location.href = window.opener.location;
        }
    </script>
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzTeamMember" runat="server" Width="350px" Height="300px" 
                        ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" 
                        OnNextButtonClick="Wizard_NextButtonClick" 
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnCancelButtonClick="Wizard_CancelButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>



                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <asp:UpdatePanel ID="upnlUserErrorMessage" runat="server">
                                    <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCompanies" runat="server" SkinID="Label" Text="Companies in iamatrenchlessexpert.com"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlCompanies" runat="server" SkinID="DropDownListLookup"
                                                    DataSourceID="odsCompaniesRAF" Width="230px" DataValueField="COMPANIES_ID" DataTextField="NAME"
                                                    OnSelectedIndexChanged="ddlCompaniesFooter_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                            
                                                <asp:Label ID="lblUserErrorMessage" runat="server" SkinID="LabelError" Text="The hotel is already registered in LFS Live."></asp:Label>                                                                                                
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:WizardStep>
                            
                                                                                 
                                                                            
                           <asp:WizardStep ID="StepSummary" runat="server" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="300px" ReadOnly="True"
                                                SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                            <asp:HiddenField ID="hdfStep" runat="server" />
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
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCompaniesRAF" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.RAF.CompaniesListGatewayRAF"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>                            
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />                            
                        </SelectParameters>                        
                    </asp:ObjectDataSource>                 
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                                                      
                    <asp:HiddenField ID="hdfName" runat="server" />       
                    <asp:HiddenField ID="hdfUpdate" runat="server" /> 
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
