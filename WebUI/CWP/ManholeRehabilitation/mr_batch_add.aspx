<%@ Page Title="LFS Live" Language="C#" AutoEventWireup="true" MasterPageFile="../../mWizard2.Master"
  CodeBehind="mr_batch_add.aspx.cs"
  Inherits="LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation.mr_batch_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px; height: 350px;">
        <!-- Page element: Wizard -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wizardBatch" runat="server" Width="440px" Height="340px" ActiveStepIndex="0"
                        DisplayCancelButton="True" DisplaySideBar="False" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick"
                        OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick"
                        SkinID="Wizard">
                        <WizardSteps>                       
                                                        
                            <asp:WizardStep ID="StepNewBatch" runat="server" Title="New Batch" StepType="Start">                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 330px">                                    
                                    <tr>
                                        <td >
                                            <asp:Label ID="lblNewBatchTitle" runat="server" EnableViewState="False" SkinID="Label" Text="Please provide information for new batch date"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlNewBatch" runat="server" Height="300px" Width="400px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlNewBatch" runat="server">
                                                    <contenttemplate>
                                                        <!-- Page element: 1 column - Grid Catalyst -->
                                                        <asp:GridView ID="grdNewBatch" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                                            AllowPaging="True" PageSize="8" ShowFooter="True" OnDataBound="grdNewBatch_DataBound" OnRowDataBound = "grdNewBatch_RowDataBound"
                                                            OnRowCommand="grdNewBatch_RowCommand" OnRowUpdating="grdNewBatch_RowUpdating" OnRowEditing="grdNewBatch_RowEditing"
                                                            OnRowDeleting="grdNewBatch_RowDeleting" DataKeyNames="BatchID" DataSourceID="odsNewBatch">
                                                            <Columns>
                                                                                                                                
                                                                <asp:TemplateField Visible="False" HeaderText="No">                                                                                                                                  
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblBatchIdEdit" runat="server" SkinID="Label" Text='<%# Eval("BatchId") %>' Width="30px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblBatchIdFooter" runat="server" SkinID="Label" Text='<%# Eval("BatchId") %>' Width="30px"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBatchId" runat="server"  SkinID="Label" Text='<%# Eval("BatchId") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                                                                               
                                                                                                                                                                                             
                                                                <asp:TemplateField  Visible="True" HeaderText="Batch Date">
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" SkinID="RadDatePicker" 
                                                                                        Width="140px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short" AutoPostBack="True" >
                                                                                        <dateinput autopostback="True"></dateinput>
                                                                                        <calendar daynameformat="Short" showrowheaders="False" 
                                                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                                                            viewselectortext="x">
                                                                                        </calendar>
                                                                                        <datepopupbutton hoverimageurl="" imageurl="" />
                                                                                    </telerik:RadDatePicker>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide a Date"
                                                                                        Display="Dynamic" ControlToValidate="tkrdpDateEdit"></asp:RequiredFieldValidator>                                                                                    
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadDatePicker ID="tkrdpDateFooter" runat="server" SkinID="RadDatePicker" 
                                                                                        Width="140px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short" AutoPostBack="True" >
                                                                                        <dateinput autopostback="True"></dateinput>
                                                                                        <calendar daynameformat="Short" showrowheaders="False" 
                                                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                                                            viewselectortext="x">
                                                                                        </calendar>
                                                                                        <datepopupbutton hoverimageurl="" imageurl="" />
                                                                                    </telerik:RadDatePicker>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide a date"
                                                                                        Display="Dynamic" ControlToValidate="tkrdpDateFooter"></asp:RequiredFieldValidator>                                                                                    
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Eval("Date") %>' Width="140px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                                                                                                                                                                                                                                                                         
                                                                             
                                                                             
                                                                             
                                                                 <asp:TemplateField  Visible="True" HeaderText="Batch Description">
                                                                    <HeaderStyle Width="230px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBatchDescription" runat="server" SkinID="Label" Text='<%# Eval("Description") %>' Width="220px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    
                                                                    <EditItemTemplate>                                                                    
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxBatchDescriptionEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Description") %>' Width="220px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvBatchDescriptionEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataEdit" ErrorMessage="Please provide a description"
                                                                                        Display="Dynamic" ControlToValidate="tbxBatchDescriptionEdit"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBatchDescriptionFooter" runat="server" SkinID="TextBox"  Width="220px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvBatchDescriptionFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="dataFooter" ErrorMessage="Please provide a description"
                                                                                        Display="Dynamic" ControlToValidate="tbxBatchDescriptionFooter"></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                                                                                               
                                                                    </FooterTemplate>
                                                                    
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
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this batch?");'>
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
                                                        <asp:ObjectDataSource ID="odsNewBatch" runat="server" FilterExpression="(Deleted = 0)"
                                                            SelectMethod="GetNewBatchNew" 
                                                            TypeName="LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation.mr_batch_verification"
                                                            DeleteMethod="DummyNewBatchNew" InsertMethod="DummyNewBatchNew" UpdateMethod="DummyNewBatchNew" >
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
                    <asp:HiddenField ID="hdfBatchDescription" runat="server" />
                    <asp:HiddenField ID="hdfBatchId" runat="server" />
                    <asp:HiddenField ID="hdfBatchDate" runat="server" />
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>