<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="supportTicket_categories.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket.supportTicket_categories" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzCategoriesAdd" runat="server" Width="550px" Height="390px" ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        
                        <WizardSteps>                      
                                                     
                            <asp:WizardStep ID="StepOperation" runat="server" Title="Operation">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnAddCategory" runat="server" Text="Add category" Checked="True" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnEditCategory" runat="server" Text="Edit category" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnDeleteCategory" runat="server" Text="Delete category" GroupName="Operation" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                                                   
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="StepCategories" runat="server" Title="Categories">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                    
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCategory" runat="server" Text="Categories" SkinID="Label"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCategories" Width="500px" Height="250px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can only choose one category"
                                            OnServerValidate="cvCategories_ServerValidate" ValidationGroup="StepCategories" ></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px" class="Background_Separator">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblName" SkinID="Label" Text="Name"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxName" Width="290px" runat="server" SkinID="TextBox"></asp:TextBox>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                                Display="Dynamic" ErrorMessage="Please provide a name" SkinID="Validator"
                                                ValidationGroup="StepCategoriesName" EnableViewState="False">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="StepWarning" runat="server" Title="Warning">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                    
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxWarning" runat="server" Height="315px" Width="500px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:Label ID="lblWarning" runat="server" SkinID="Label" Text="If you are not sure about deleting you can reassign this items to another category in the next step">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="StepCategories2" runat="server" Title="Category to replace">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                    
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCategoryToReplace" runat="server" Text="Category" SkinID="Label"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCategories2" Width="500px" Height="250px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCategoriesRoot2" runat="server" SkinID="SimpleTreeView">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvCategories2" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can only choose one category"
                                            OnServerValidate="cvCategories2_ServerValidate" ValidationGroup="StepCategories2" ></asp:CustomValidator>
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
