<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" 
CodeBehind="jliner_bulk_date_update.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_bulk_date_update" 
Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="Wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" 
                    Height="160px" DisplaySideBar="False" DisplayCancelButton="True" 
                    OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" 
                    OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" 
                    OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">
                                <!-- Page element: Range title 1 columns -->
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFieldToUpdate" runat="server" SkinID="Label" Text="Please select the field to update" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlFieldToUpdate" runat="server" SkinID="DropDownList"
                                                Width="130px" >
                                                <asp:ListItem Value="(Select a field)">(Select a field)</asp:ListItem>
                                                <asp:ListItem Value="VideoInspection">Video Inspection</asp:ListItem>
                                                <asp:ListItem Value="PipeLocated">Pipe Located</asp:ListItem>
                                                <asp:ListItem Value="ServicesLocated">Services Located</asp:ListItem>
                                                <asp:ListItem Value="CoInstalled">C/O Installed</asp:ListItem>
                                                <asp:ListItem Value="BackfilledConcrete">Backfilled Concrete</asp:ListItem>
                                                <asp:ListItem Value="BackfilledSoil">Backfilled Soil</asp:ListItem>
                                                <asp:ListItem Value="Grouted">Grouted</asp:ListItem>
                                                <asp:ListItem Value="Cored">Cored</asp:ListItem>
                                                <asp:ListItem Value="Prepped">Prepped</asp:ListItem>
                                                <asp:ListItem Value="PreVideo">Pre-Video</asp:ListItem>
                                                <asp:ListItem Value="Measured">Measured</asp:ListItem>
                                                <asp:ListItem Value="NoticeDelivered">Notice Delivered</asp:ListItem>
                                                <asp:ListItem Value="InProcess">In Process</asp:ListItem>
                                                <asp:ListItem Value="InStock">In Stock</asp:ListItem>
                                                <asp:ListItem Value="Delivered">Delivered</asp:ListItem>
                                                <asp:ListItem Value="LinerInstalled">Liner Installed</asp:ListItem>
                                                <asp:ListItem Value="FinalVideo">Final Video</asp:ListItem>
                                                <asp:ListItem Value="CoCutDown">C/O Cut Down?</asp:ListItem>
                                                <asp:ListItem Value="FinalRestoration">Final Restoration</asp:ListItem>                                                
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvFieldToUpdate" runat="server" ControlToValidate="ddlFieldToUpdate"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a field to update"
                                                InitialValue="(Select a field)" SkinID="Validator" ValidationGroup="Begin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>                               
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Enter the date value" EnableViewState="False"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                         <td>
                                            <asp:TextBox ID="tbxDate" runat="server" SkinID="TextBox" Width="130px" EnableViewState="False"></asp:TextBox>
                                        </td>   
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="tbxDate"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date (use MM/DD/YYYY format)"
                                                Operator="DataTypeCheck" SkinID="Validator" Type="Date" ValidationGroup="Begin"></asp:CompareValidator>
                                        </td>                                                        
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Finish" runat="server" Title="Finish" StepType="Finish">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="350px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="6"></asp:TextBox>
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
                            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveComplete" Text="Finish"
                                SkinID="Button" Width="80px" Height="24px" />
                        </FinishNavigationTemplate>                        
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                    <asp:HiddenField ID="hdfStep" runat="server" />
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>