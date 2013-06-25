<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="project_duplicate.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_duplicate" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<!-- CONTENT -->
    <div style="width: 645px;">
        <!-- Page element: Wizard -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 645px">
            <tr>
                <td>
                    <asp:Wizard ID="wzProjectDuplicate" runat="server" Width="645px" Height="400px" ActiveStepIndex="0" DisplaySideBar="False" SkinID="Wizard" OnActiveStepChanged="wzProjectDuplicate_ActiveStepChanged" OnCancelButtonClick="wzProjectDuplicate_CancelButtonClick" OnFinishButtonClick="wzProjectDuplicate_FinishButtonClick" DisplayCancelButton="True">
                        <WizardSteps>                        
                        
                        
                            <asp:WizardStep ID="StepProposal" runat="server" Title="Proposals">
                            
                                <!-- Page element: grid view; 1 column  -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTotalRows" runat="server" EnableViewState="true" SkinID="Label"
                                                Text="Total Rows"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlGrdProposals" runat="server" Height="315px" Width="100%" ScrollBars="Vertical">                                     
                                        
                                                <asp:GridView id="grdProposals" runat="server" SkinID="GridView" Width="100%"  
                                                DataKeyNames="ProjectID" DataSourceID="odsProposals"  
                                                OnDataBound="grdProposals_DataBound" PageSize="12" AutoGenerateColumns="False">
                                                    <Columns>
                                                       
                                                       
                                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                  <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Bind("ProjectID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Width="30px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Project Number">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Width="125px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProjectNumber" runat="server" SkinID="Label" Text='<%# Bind("ProjectNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Name">
                                                            <HeaderStyle Width="230px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Client">
                                                            <HeaderStyle Width="179px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClientName" runat="server" SkinID="Label" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="State">
                                                            <HeaderStyle Width="86px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProjectState" runat="server" SkinID="Label" Text='<%# Bind("ProjectState") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                     </tr>   
                                     <tr>
                                        <td>
                                            <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError"
                                                Text="At least one proposal must be selected"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="1">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsProposals" runat="server" SelectMethod="GetProposals"
                                                            TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_duplicate"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                     </tr>
                                     
                                </table>    
                            
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepFinishOptions" runat="server" StepType="Complete" Title="Finish Options">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 645px;">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnOpenProject" runat="server" EnableViewState="False" SkinID="LinkButton">Open the proposal you just duplicated</asp:LinkButton>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditProject" runat="server" SkinID="LinkButton" >Edit the proposal you just duplicated</asp:LinkButton>                                            
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
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        
             
              
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
