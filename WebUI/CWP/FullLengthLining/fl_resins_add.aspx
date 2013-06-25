<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="fl_resins_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_resins_add" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 730px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="360px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 730px">                                    
                                    <tr>
                                        <td >
                                            <asp:Label ID="lblResinsTitle" runat="server" EnableViewState="False" SkinID="Label" Text="Please provide resins information. Resin numbers 1 - 3 are pre-set."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlResins" runat="server" Height="330px" Width="730px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlResins" runat="server">
                                                    <contenttemplate>
                                                        <!-- Page element: 1 column - Grid Resins -->
                                                        <asp:GridView ID="grdResins" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                                            AllowPaging="True" PageSize="10" ShowFooter="True" OnDataBound="grdResins_DataBound"
                                                            OnRowCommand="grdResins_RowCommand" OnRowUpdating="grdResins_RowUpdating" OnRowEditing="grdResins_RowEditing"
                                                            OnRowDeleting="grdResins_RowDeleting" OnRowDataBound="grdResins_RowDataBound"
                                                            DataKeyNames="ResinID" DataSourceID="odsResins">
                                                            <Columns>
                                                                                                                                
                                                                <asp:TemplateField Visible="True" HeaderText="No">
                                                                    <HeaderStyle Width="30px" ></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblResinIdEdit" runat="server" SkinID="Label" Text='<%# Eval("ResinID") %>' Width="30px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblResinIdFooter" runat="server" SkinID="Label" Text='<%# Eval("ResinID") %>' Width="30px"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblResinId" runat="server"  SkinID="Label" Text='<%# Eval("ResinID") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Resin Make">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblResinMake" runat="server" SkinID="Label" Text='<%# Eval("ResinMake") %>' Width="90px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    
                                                                    <EditItemTemplate>                                                                    
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxResinMakeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ResinMake") %>' Width="90px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinMakeEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide the resin make"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinMakeEdit"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxResinMakeFooter" runat="server" SkinID="TextBox"  Width="90px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinMakeFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide the resin make"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinMakeFooter"></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                                                                                               
                                                                    </FooterTemplate>
                                                                    
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Resin Type">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxResinTypeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ResinType") %>' Width="90px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinTypeEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide the resin make"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinTypeEdit"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxResinTypeFooter" runat="server" SkinID="TextBox"  Width="90px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinTypeFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide the resin type"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinTypeFooter"></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblResinType" runat="server" SkinID="Label" Text='<%# Eval("ResinType") %>' Width="90px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                                                                                
                                                                 <asp:TemplateField  Visible="True" HeaderText="Resin Number">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxResinNumberEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ResinNumber") %>' Width="110px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinNumberEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide the resin number"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinNumberEdit"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxResinNumberFooter" runat="server" SkinID="TextBox"  Width="110px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvResinNumberFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide the resin number"
                                                                                        Display="Dynamic" ControlToValidate="tbxResinNumberFooter"></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblResinNumber" runat="server" SkinID="Label" Text='<%# Eval("ResinNumber") %>' Width="110px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Lb / Usg">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxLbUsgEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("LbUsg"),3) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvLbUsgEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide lb/usg"
                                                                                        Display="Dynamic" ControlToValidate="tbxLbUsgEdit"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbUsgEdit" runat="server" ControlToValidate="tbxLbUsgEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XXX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLbUsgFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvLbUsgFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide lb/usg"
                                                                                        Display="Dynamic" ControlToValidate="tbxLbUsgFooter"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbUsgFooter" runat="server" ControlToValidate="tbxLbUsgFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XXX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblLbUsg" runat="server" SkinID="Label" Text='<%# GetRound(Eval("LbUsg"),3) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Lb / Drums">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxLbDrumsEdit" runat="server" SkinID="TextBox" Text='<%# Eval("LbDrums") %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvLbDrumsEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide lb/drums"
                                                                                        Display="Dynamic" ControlToValidate="tbxLbDrumsEdit"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbDrumsEdit" runat="server" ControlToValidate="tbxLbDrumsEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLbDrumsFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvLbDrumsFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide lb/drums"
                                                                                        Display="Dynamic" ControlToValidate="tbxLbDrumsFooter"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbDrumsFooter" runat="server" ControlToValidate="tbxLbDrumsFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblLbDrums" runat="server" SkinID="Label" Text='<%# Eval("LbDrums") %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>               
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Active Resin (%)">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxActiveResinEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("ActiveResin"),1) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvActiveResinEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide active resin %"
                                                                                        Display="Dynamic" ControlToValidate="tbxActiveResinEdit"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvActiveResinEdit" runat="server" ControlToValidate="tbxActiveResinEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.X)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxActiveResinFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvActiveResinFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide active resin %"
                                                                                        Display="Dynamic" ControlToValidate="tbxActiveResinFooter"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbActiveResinFooter" runat="server" ControlToValidate="tbxActiveResinFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.X)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblActiveResin" runat="server" SkinID="Label" Text='<%# GetRound(Eval("ActiveResin"),1) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                              
                                                                                                                                                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Apply Catalyst To">
                                                                    <HeaderStyle Width="130px" HorizontalAlign="Center"></HeaderStyle>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:DropDownList ID="ddlApplyCatalystToEdit" runat="server" EnableViewState="true" SkinID="DropDownList" 
                                                                                        Style="width: 120px">
                                                                                            <asp:ListItem Value="(Select)" Selected="True">(Select)</asp:ListItem>
                                                                                            <asp:ListItem Value="Active Resin">Active Resin</asp:ListItem>
                                                                                            <asp:ListItem Value="Active Resin & Filter">Active Resin & Filter</asp:ListItem>                                                                                
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvApplyCatalystToEdit" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataEdit" ErrorMessage="Please select an item."
                                                                                            Display="Dynamic" ControlToValidate="ddlApplyCatalystToEdit"  InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                         <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlApplyCatalystToFooter" runat="server" EnableViewState="true"  SkinID="DropDownList" 
                                                                                        Style="width: 120px" >
                                                                                            <asp:ListItem Value="(Select)" Selected="True">(Select)</asp:ListItem>
                                                                                            <asp:ListItem Value="Active Resin">Active Resin</asp:ListItem>
                                                                                            <asp:ListItem Value="Active Resin & Filter">Active Resin & Filter</asp:ListItem>                                                                                
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvApplyCatalystToFooter" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataFooter" ErrorMessage="Please select an item."
                                                                                            Display="Dynamic" ControlToValidate="ddlApplyCatalystToFooter"  InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                     
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblApplyCatalystTo" runat="server" SkinID="Label" Text='<%# Eval("ApplyCatalystTo") %>' Width="120px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Filter (%)">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxFilterEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("Filter"),1) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvFilterEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide filter %"
                                                                                        Display="Dynamic" ControlToValidate="tbxFilterEdit"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvAFilterEdit" runat="server" ControlToValidate="tbxFilterEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.X)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                            
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxFilterFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvFilterFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide a filter %"
                                                                                        Display="Dynamic" ControlToValidate="tbxFilterFooter"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvLbFilterFooter" runat="server" ControlToValidate="tbxFilterFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.X)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblFilter" runat="server" SkinID="Label" Text='<%# GetRound(Eval("Filter"),1) %>' Width="40px"></asp:Label>
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
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this resin?");'>
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
                                                        <asp:ObjectDataSource ID="odsResins" runat="server" FilterExpression="(Deleted = 0)"
                                                            SelectMethod="GetResinsNew" 
                                                            TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_resins_add"
                                                            DeleteMethod="DummyResinsNew" InsertMethod="DummyResinsNew" UpdateMethod="DummyResinsNew" >
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 730px">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="710px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="25"></asp:TextBox>
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
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 730px">
                                <tr>                                    
                                    <td style="width: 460px; text-align: right">
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