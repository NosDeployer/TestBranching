<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="materials_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzMaterials" runat="server" Width="350px" Height="300px" 
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
                                                <asp:Label ID="lblProcess" runat="server" SkinID="Label" Text="Process"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlProcess" runat="server" 
                                                DataSourceID="odsProcess" DataTextField="Type" DataValueField="Type" 
                                                SkinID="DropDownListLookup" Width="165px">
                                            </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                            
                                                <asp:CustomValidator ID="cvProcess" runat="server" 
                                                    ControlToValidate="ddlProcess" Display="Dynamic" 
                                                    ErrorMessage="Please select a process" 
                                                    OnServerValidate="cvProcess_ServerValidate" SkinID="Validator" 
                                                    ValidationGroup="beginInformation"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepGeneralData" runat="server"  Title="General Data">
                                <!-- Page element: General Data -->
                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel id="pnlJunctionLiner" runat="server" Width="100%">
                                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                                    <tr>
                                                        <td style="width: 175px">
                                                            
                                                            <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Description"></asp:Label>
                                                            
                                                        </td>
                                                        <td style="width: 175px">                                                                                    
                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RadioButton ID="rbtnMiscSupplies" runat="server" 
                                                            GroupName="JunctionLiner" SkinID="RadioButton"  Text="Lateral / Misc Supplies" />
                                                        </td>                                                        
                                                    </tr>                                                    
                                                    <tr>
                                                        <td colspan="2" style="height: 7px">  </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RadioButton ID="rbtnCleanoutMaterial" runat="server" 
                                                            GroupName="JunctionLiner" SkinID="RadioButton"  Text="Lateral / Cleanout Material" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 7px">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RadioButton ID="rbtnBackfillCleanout" runat="server"  
                                                            GroupName="JunctionLiner" SkinID="RadioButton"  Text="Lateral / Backfill - Cleanout" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 7px">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 7px">
                                                            <asp:RadioButton ID="rbtnRestorationCrowleCap" runat="server" 
                                                            GroupName="JunctionLiner" SkinID="RadioButton"  
                                                                Text="Lateral / Restoration &amp; Crowle Cap" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 7px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RadioButton ID="rbtnOther" runat="server" Checked="True" 
                                                            GroupName="JunctionLiner" SkinID="RadioButton"  
                                                                Text="Auto Generate Description" />
                                                        </td>                                                        
                                                    </tr>      
                                                    <tr>
                                                        <td colspan="2" style="height: 7px">
                                                             </td>
                                                    </tr>
                                                    <tr>                                        
                                                        <td>
                                                            <asp:Label ID="lblJLSize" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Size"></asp:Label>
                                                        </td>
                                                        <td>
                                                            
                                                        </td>
                                                    </tr>                
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxJLSize" runat="server" SkinID="TextBox"
                                                            Style="width: 165px"></asp:TextBox>
                                                        </td>
                                                        <td>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvJLSize" runat="server" ControlToValidate="tbxJLSize" 
                                                                Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvJLSize_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="detailInformation"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvJLSizeEmpty" runat="server" 
                                                                ControlToValidate="tbxJLSize" Display="Dynamic" 
                                                                ErrorMessage="Please enter a size." 
                                                                OnServerValidate="cvJLSizeEmpty_ServerValidate" 
                                                                SkinID="Validator" ValidateEmptyText="True" 
                                                                ValidationGroup="detailInformation"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvJLSizeAutoGenerate" runat="server" 
                                                                ControlToValidate="tbxJLSize" Display="Dynamic" 
                                                                ErrorMessage="Please delete the size." 
                                                                OnServerValidate="cvJLSizeAutoGenerate_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="detailInformation"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>                              
                                                </table>
                                            </asp:Panel>
                                            
                                            <asp:Panel id="pnlPointRepairs" runat="server" Width="100%">
                                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                                    <tr>
                                                        <td style="width: 175px">                                                            
                                                            <asp:Label ID="lblPrSize" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Size"></asp:Label>
                                                            
                                                        </td>
                                                        <td style="width: 175px">                                                                                    
                                                            <asp:Label ID="lblPrLength" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Length"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPrSize" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsSizeList" DataTextField="Size_" DataValueField="Size_"
                                                                SkinID="DropDownList" Style="width: 165px">
                                                            </asp:DropDownList>                                                                                        
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPrLength" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsLengthList" DataTextField="Length" DataValueField="Length"
                                                                SkinID="DropDownList" Style="width: 165px">
                                                            </asp:DropDownList>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvPRSizeEmpty" runat="server" 
                                                                ControlToValidate="ddlPrSize" Display="Dynamic" 
                                                                ErrorMessage="Please select a size." 
                                                                OnServerValidate="cvSizeEmpty_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="detailInformation"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvPRLengthEmpty" runat="server" 
                                                                ControlToValidate="ddlPrLength" Display="Dynamic" 
                                                                ErrorMessage="Please select a length." 
                                                                OnServerValidate="cvJLSizeEmpty_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="detailInformation"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>                                                                                       
                                            
                                            <asp:Panel id="pnlFullLengthLining" runat="server" Width="100%">
                                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                                    <tr>                                        
                                                        <td>
                                                            <asp:Label ID="lblSize" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Size"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblThickness" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Thickness"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBox"
                                                            Style="width: 165px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlThickness" runat="server" DataSourceID="odsThicknessList" 
                                                                DataTextField="Thickness" DataValueField="Thickness" SkinID="DropDownListLookup" 
                                                                Width="165px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxSize" 
                                                                Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvSize_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="detailInformation"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvSizeEmpty" runat="server" 
                                                                ControlToValidate="tbxSize" Display="Dynamic" 
                                                                ErrorMessage="Please enter a size." 
                                                                OnServerValidate="cvSizeEmpty_ServerValidate" 
                                                                SkinID="Validator" ValidateEmptyText="True" 
                                                                ValidationGroup="detailInformation"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>   
                                        </td>
                                    </tr>
                                    
                                    
                                    <tr>
                                        <td style="height: 7px">
                                             </td>
                                        <td>
                                             </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                                                       
                        
                                                    
                           <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="250px" ReadOnly="True"
                                                SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepFinalStep" runat="server" Title="Final Step" StepType="Complete">
                                <!-- Page element: Final Steps -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnOpen" runat="server" SkinID="LinkButton" EnableViewState="False">Open the team member you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEdit" runat="server" SkinID="LinkButton">Edit the team member you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnClose" runat="server" SkinID="LinkButton">Close this window</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                        
                        
                        
                        <StepNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 80px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="btnPrevious" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MovePrevious" Text="Previous" SkinID="Button" EnableViewState="False" /></td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="NextButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MoveNext" Text="Next" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </StepNavigationTemplate>
                        <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>                                    
                                    <td style="width: 80px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right;">
                                        <asp:Button ID="btnPrevious" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MovePrevious" Text="Previous" SkinID="Button" EnableViewState="False" /></td>
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


        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                                        
                     <asp:ObjectDataSource ID="odsProcess" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Materials.MaterialsTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a process)" Name="type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                                           
                    
                    <asp:ObjectDataSource ID="odsThicknessList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerSectionThicknessList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="thickness" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                     
                    
                     <asp:ObjectDataSource ID="odsSizeList" runat="server" CacheDuration="120" 
                         EnableCaching="True" OldValuesParameterFormatString="original_{0}" 
                         SelectMethod="LoadAndAddItem" 
                         TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkPointRepairsRepairPointSizeList">
                         <SelectParameters>
                             <asp:Parameter DefaultValue="" Name="size_" Type="String" />
                             <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                         </SelectParameters>
                     </asp:ObjectDataSource>
                     
                     <asp:ObjectDataSource ID="odsLengthList" runat="server" CacheDuration="120" 
                         EnableCaching="True" OldValuesParameterFormatString="original_{0}" 
                         SelectMethod="LoadAndAddItem" 
                         TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkPointRepairsRepairPointLengthList">
                         <SelectParameters>
                             <asp:Parameter DefaultValue="" Name="length" Type="String" />
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
                    <asp:HiddenField ID="hdfType" runat="server" />                    
                    <asp:HiddenField ID="hdfState" runat="server" />                    
                    <asp:HiddenField ID="hdfDescription" runat="server" />                    
                    <asp:HiddenField ID="hdfSize" runat="server" />                    
                    <asp:HiddenField ID="hdfThickness" runat="server" />                                        
                    <asp:HiddenField ID="hdfLength" runat="server" />                                        
                    <asp:HiddenField ID="hdfMaterialId" runat="server" />     
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
