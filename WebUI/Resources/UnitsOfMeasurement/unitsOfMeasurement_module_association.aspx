<%@ Page Language="C#" AutoEventWireup="true" Title="LFS Live" MasterPageFile="../../mWizard2.Master" CodeBehind="unitsOfMeasurement_module_association.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement.unitsOfMeasurement_module_association" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzUnitsOfMeasurement" runat="server" Width="350px" Height="300px" 
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
                                                <asp:Label ID="lblModule" runat="server" SkinID="Label" Text="Module"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlModules" runat="server" SkinID="DropDownListLookup"
                                                    DataSourceID="odsModules" Width="230px" DataValueField="Module" DataTextField="Module"                                                    
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvModuleList" runat="server" 
                                                    ControlToValidate="ddlModules" Display="Dynamic" EnableViewState="False" 
                                                    ErrorMessage="Please select a module" InitialValue="(Select a module)" 
                                                    SkinID="Validator" ValidationGroup="beginData"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                            
                                                </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepAssociations" runat="server"  Title="Associations">
                                <!-- Page element: General Data -->
                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                    <tr>
                                        <td style="width: 175px; height:10px">                                                                                     
                                        </td>
                                        <td>                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlAssociations" runat="server" Height="185px" Width="290px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlAssociations" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdAssociations" runat="server" AutoGenerateColumns="False" 
                                                        SkinID="GridView" Width="273px" OnDataBound="grdAssociations_DataBound" 
                                                        DataSourceID="odsAssociations" DataKeyNames="AssociationsID">
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" Visible="False" DataField="AssociationsID" HeaderText="AssociationsID"></asp:BoundField>
                                                                                                                                
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit Of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" SkinID="Label" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="By Default">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxByDefault" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("ByDefault") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="InDataBase" Visible="false">                                                                    
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxInDataBase" runat="server" Checked='<%# Eval("InDataBase") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="UnitOfMeasurementID" Visible="false">                                                                    
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurementID" runat="server" SkinID="Label" Text='<%# Bind("UnitOfMeasurementID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Module" Visible="false">                                                                    
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblModule" runat="server" SkinID="Label" Text='<%# Bind("Module") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>                                            
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                                <asp:CustomValidator ID="cvGrdAssociations" runat="server" Display="Dynamic" 
                                                ErrorMessage="At least one unit of measurement must be selected" OnServerValidate="cvgrdAssociations_ServerValidate" 
                                                ValidationGroup="associations" SkinID="Validator">
                                                </asp:CustomValidator>   
                                                <asp:CustomValidator ID="cvGrdAssociationsByDefault" runat="server" Display="Dynamic" 
                                                ErrorMessage="At least one should be selected as Default" OnServerValidate="cvGrdAssociationsByDefault_ServerValidate" 
                                                ValidationGroup="associations" SkinID="Validator">
                                                </asp:CustomValidator>
                                                <asp:CustomValidator ID="cvGrdAssociationsByDefaultSelected" runat="server" Display="Dynamic" 
                                                ErrorMessage="If you want to use this unit of measurement as default please select it." OnServerValidate="cvGrdAssociationsByDefaultSelected_ServerValidate" 
                                                ValidationGroup="associations" SkinID="Validator">
                                                </asp:CustomValidator>
                                            </asp:Panel>                                         
                                        </td>
                                        <td colspan="1">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsAssociations" runat="server" SelectMethod="GetAssociations"
                                                            TypeName="LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement.unitsOfMeasurement_module_association"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                        <td colspan="1">
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
                    <asp:ObjectDataSource ID="odsModules" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementModulesToAssociateList"
                        OldValuesParameterFormatString="original_{0}" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a module)" Name="module" Type="String" />
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
                    <asp:HiddenField ID="hdfModule" runat="server" />  
                    <asp:HiddenField ID="hdfAssociationsList" runat="server" />  
                    <asp:HiddenField ID="hdfLoadDataFirstTime" runat="server" />  
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
