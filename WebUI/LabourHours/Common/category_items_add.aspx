<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="category_items_add.aspx.cs" 
Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Common.category_items_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Wizard ID="wzCategories" runat="server" Width="350px" Height="300px" 
                                                ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard"
                                                OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick"
                                                OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                                                OnPreviousButtonClick="Wizard_PreviousButtonClick">
                                                <WizardSteps>                                                
                                                
                                                    <asp:WizardStep ID="StepBegin" runat="server" Title="Begin" StepType="Start">
                                                    
                                                        <!-- Page element: 2 column -->                                                                                                                                                           
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                                                                                                                                                                                                                             
                                                            <tr>                                                                 
                                                                <td>
                                                                    <asp:CheckBox ID="cbxSubcontractor" runat="server" Checked="false" Text="Add Subcontractors"  SkinID="CheckBox"/>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                    
                                                                <td>
                                                                    <asp:CheckBox ID="cbxHotels" runat="server" Checked="false" Text="Add Hotels"  SkinID="CheckBox"/>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                    
                                                                <td>
                                                                    <asp:CheckBox ID="cbxBondingCompanies" runat="server" Checked="false" Text="Add Bonding Companies"  SkinID="CheckBox"/>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                    
                                                                <td>
                                                                    <asp:CheckBox ID="cbxInsuranceCompanies" runat="server" Checked="false" Text="Add Insurance Companies"  SkinID="CheckBox"/>
                                                                </td>
                                                            </tr>                                                                                                                     
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                
                                                    <asp:WizardStep ID="StepSubcontractors" runat="server" Title="Subcontractors" >
                                                        <!-- Page element: 1 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="upnlUserErrorMessage" runat="server">
                                                                        <ContentTemplate>
                                                                        <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                                                            <tr>                                                                                
                                                                                <td>
                                                                                    <asp:Label ID="lblSubcontractorLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                                        Text="Add Subcontractors"></asp:Label></td>                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">
                                                                                </td>
                                                                             </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCompanies" runat="server" SkinID="Label" Text="Companies in iamatrenchlessexpert.com"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCompanies" runat="server" SkinID="DropDownListLookup"
                                                                                        DataSourceID="odsCompaniesRAF" Width="230px" DataValueField="COMPANIES_ID" DataTextField="NAME"
                                                                                        OnSelectedIndexChanged="ddlCompanies_SelectedIndexChanged" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                            
                                                                                    <asp:Label ID="lblUserErrorMessage" runat="server" SkinID="LabelError" Text="The company is already registered in LFS Live."></asp:Label>                                                                                                
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>    
                                                                </td>
                                                            </tr>
                                                        </table>                                                                                                                           
                                                        
                                                        <!-- Page element: Data objects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
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
                                                                    <asp:HiddenField ID="hdfCompanyIdForSubcontractors" runat="server" />                                                      
                                                                    <asp:HiddenField ID="hdfNameForSubcontractors" runat="server" />       
                                                                    <asp:HiddenField ID="hdfUpdateForSubcontractors" runat="server" /> 
                                                                </td>
                                                            </tr>
                                                        </table>                                                                                                             
                                                    </asp:WizardStep>
                                                                                                                                               
                                                
                                                    
                                                    <asp:WizardStep ID="StepHotel" runat="server" Title="Hotels">
                                                        <!-- Page element: 1 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <div runat="server" id="dvHotels" style="overflow-x: auto; overflow-y: hidden; width: 350px">                                                            
                                                                        <!-- Page element: 1 column -->
                                                                        <table cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlHotels" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                                                                                <tr>                                                                                
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblAddHotelslabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                                                            Text="Add Hotels"></asp:Label></td>                                                                                
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 10px">
                                                                                                    </td>
                                                                                                 </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblCompaniesForHotels" runat="server" SkinID="Label" Text="Companies in iamatrenchlessexpert.com"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlCompaniesForHotels" runat="server" SkinID="DropDownListLookup"
                                                                                                            DataSourceID="odsCompaniesForHotelsRAF" Width="230px" DataValueField="COMPANIES_ID" DataTextField="NAME"
                                                                                                            OnSelectedIndexChanged="ddlCompaniesForHotels_SelectedIndexChanged" AutoPostBack="True">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>                                            
                                                                                                        <asp:Label ID="lblUserErrorMessageForHotels" runat="server" SkinID="LabelError" Text="The hotel is already registered in LFS Live."></asp:Label>                                                                                                
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>                                                                                                                                                                                         
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>         
                                                                                   
                                                        <!-- Page element: DataObjects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsCompaniesForHotelsRAF" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.RAF.CompaniesListGatewayRAF"
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
                                                                    <asp:HiddenField ID="hdfCompanyIdForHotels" runat="server" />                                                      
                                                                    <asp:HiddenField ID="hdfNameForHotels" runat="server" />       
                                                                    <asp:HiddenField ID="hdfUpdateForHotels" runat="server" /> 
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepBondingCompanies" runat="server" Title="BondingCompanies">
                                                        <!-- Page element: 1 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <div runat="server" id="dvBondingCompanies" style="overflow-x: auto; overflow-y: hidden; width: 350px">                                                            
                                                                        <!-- Page element: 1 column -->
                                                                        <table cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlBondingCompanies" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                                                                                <tr>                                                                                
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblAddBondingCompaniesLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                                                            Text="Add Bonding Companies"></asp:Label></td>                                                                                
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 10px">
                                                                                                    </td>
                                                                                                 </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblCompaniesForBondingCompanies" runat="server" SkinID="Label" Text="Companies in iamatrenchlessexpert.com"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlCompaniesForBondingCompanies" runat="server" SkinID="DropDownListLookup"
                                                                                                            DataSourceID="odsCompaniesForBondingCompaniesRAF" Width="230px" DataValueField="COMPANIES_ID" DataTextField="NAME"
                                                                                                            OnSelectedIndexChanged="ddlCompaniesForBondingCompanies_SelectedIndexChanged" AutoPostBack="True">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>                                            
                                                                                                        <asp:Label ID="lblUserErrorMessageForBondingCompanies" runat="server" SkinID="LabelError" Text="The hotel is already registered in LFS Live."></asp:Label>                                                                                                
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>                                                                                                                                                                                         
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>         
                                                                                   
                                                        <!-- Page element: DataObjects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsCompaniesForBondingCompaniesRAF" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.RAF.CompaniesListGatewayRAF"
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
                                                                    <asp:HiddenField ID="hdfCompanyIdForBondingCompanies" runat="server" />                                                      
                                                                    <asp:HiddenField ID="hdfNameForBondingCompanies" runat="server" />       
                                                                    <asp:HiddenField ID="hdfUpdateForBondingCompanies" runat="server" /> 
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepInsuranceCompanies" runat="server" Title="InsuranceCompanies">
                                                        <!-- Page element: 1 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <div runat="server" id="dvInsuranceCompanies" style="overflow-x: auto; overflow-y: hidden; width: 350px">                                                            
                                                                        <!-- Page element: 1 column -->
                                                                        <table cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlInsuranceCompanies" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                                                                                <tr>                                                                                
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblAddInsuranceCompaniesLabel" runat="server" EnableViewState="False" SkinID="LabelTitle1"
                                                                                                            Text="Add Insurance Companies"></asp:Label></td>                                                                                
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 10px">
                                                                                                    </td>
                                                                                                 </tr>
                                                                                                <tr>
                                                                                                    <td>    
                                                                                                        <asp:Label ID="lblCompaniesForInsuranceCompanies" runat="server" SkinID="Label" Text="Companies in iamatrenchlessexpert.com"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlCompaniesForInsuranceCompanies" runat="server" SkinID="DropDownListLookup"
                                                                                                            DataSourceID="odsCompaniesForInsuranceCompaniesRAF" Width="230px" DataValueField="COMPANIES_ID" DataTextField="NAME"
                                                                                                            OnSelectedIndexChanged="ddlCompaniesrForInsuranceCompanies_SelectedIndexChanged" AutoPostBack="True">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>                                            
                                                                                                        <asp:Label ID="lblUserErrorMessageForInsuranceCompanies" runat="server" SkinID="LabelError" Text="The hotel is already registered in LFS Live."></asp:Label>                                                                                                
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>                                                                                                                                                                                         
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>         
                                                                                   
                                                        <!-- Page element: DataObjects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsCompaniesForInsuranceCompaniesRAF" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.RAF.CompaniesListGatewayRAF"
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
                                                                    <asp:HiddenField ID="hdfCompanyIdForInsuranceCompanies" runat="server" />                                                      
                                                                    <asp:HiddenField ID="hdfNameForInsuranceCompanies" runat="server" />       
                                                                    <asp:HiddenField ID="hdfUpdateForInsuranceCompanies" runat="server" /> 
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                                                                                                                          
                                                    
                                                    <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                                        <!-- Page element: Summary -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="350px" ReadOnly="True"
                                                                        SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                                                                                                                                                                              
                                                </WizardSteps>
                                            </asp:Wizard>
                                        </td>
                                        <td style="vertical-align: bottom; width: 30px">
                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlProject">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
               
                   
        <!-- Page element: DataObjects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td>                   
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>