<%@ Page Title="LFS Live" Language="C#"  MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="fl_catalyst_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_catalyst_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 330px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="360px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 330px">                                    
                                    <tr>
                                        <td >
                                            <asp:Label ID="lblCatalystsTitle" runat="server" EnableViewState="False" SkinID="Label" Text="Catalysts information"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCatalysts" runat="server" Height="330px" Width="330px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlCatalysts" runat="server">
                                                    <contenttemplate>
                                                        <!-- Page element: 1 column - Grid Catalyst -->
                                                        <asp:GridView ID="grdCatalysts" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                                            AllowPaging="True" PageSize="10" ShowFooter="True" OnDataBound="grdCatalysts_DataBound"
                                                            OnRowCommand="grdCatalysts_RowCommand" OnRowUpdating="grdCatalysts_RowUpdating" OnRowEditing="grdCatalysts_RowEditing"
                                                            OnRowDeleting="grdCatalysts_RowDeleting" DataKeyNames="CatalystID" DataSourceID="odsCatalysts">
                                                            <Columns>
                                                                                                                                
                                                                <asp:TemplateField Visible="True" HeaderText="No">
                                                                    <HeaderStyle Width="30px" ></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCatalystIdEdit" runat="server" SkinID="Label" Text='<%# Eval("CatalystID") %>' Width="30px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblCatalystIdFooter" runat="server" SkinID="Label" Text='<%# Eval("CatalystID") %>' Width="30px"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCatalystId" runat="server"  SkinID="Label" Text='<%# Eval("CatalystID") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Name">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Eval("Name") %>' Width="190px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    
                                                                    <EditItemTemplate>                                                                    
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxNameEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Name") %>' Width="190px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvNameEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide a name"
                                                                                        Display="Dynamic" ControlToValidate="tbxNameEdit"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxNameFooter" runat="server" SkinID="TextBox"  Width="190px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvNameFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide a name"
                                                                                        Display="Dynamic" ControlToValidate="tbxNameFooter"></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                                                                                               
                                                                    </FooterTemplate>
                                                                    
                                                                </asp:TemplateField>
                                                                                                                                                                                             
                                                                <asp:TemplateField  Visible="True" HeaderText="Default % by Weight ">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxDefaultPercentageByWeightEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("DefaultPercentageByWeight"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDefaultPercentageByWeightEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide the % by Weight"
                                                                                        Display="Dynamic" ControlToValidate="tbxDefaultPercentageByWeightEdit"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvDefaultPercentageByWeightEdit" runat="server" ControlToValidate="tbxDefaultPercentageByWeightEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDefaultPercentageByWeightFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDefaultPercentageByWeightFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide the % by Weight"
                                                                                        Display="Dynamic" ControlToValidate="tbxDefaultPercentageByWeightFooter"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvDefaultPercentageByWeightFooter" runat="server" ControlToValidate="tbxDefaultPercentageByWeightFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblDefaultPercentageByWeight" runat="server" SkinID="Label" Text='<%# GetRound(Eval("DefaultPercentageByWeight"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                                                                                                                                                                                                                                                                         
                                                                                                                              
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel">
                                                                                        </asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this catalyst?");'>
                                                                                        </asp:ImageButton>
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
                                            </asp:Panel>
                                        </td>                                        
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsCatalysts" runat="server" FilterExpression="(Deleted = 0)"
                                                            SelectMethod="GetCatalystsNew" 
                                                            TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_catalyst_add"
                                                            DeleteMethod="DummyCatalystsNew" InsertMethod="DummyCatalystsNew" UpdateMethod="DummyCatalystsNew" >
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 330px">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="310px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="25"></asp:TextBox>
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
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 230px">
                                <tr>                                    
                                    <td style="width: 60px; text-align: right">
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