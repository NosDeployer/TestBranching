<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="jl_bulk_date_update.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_bulk_date_update" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="Wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="180px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
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
                                            <!-- Page element: UpdatePanel -->
                                            <asp:UpdatePanel ID="upnlFieldToUpdate" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:DropDownList ID="ddlFieldToUpdate" runat="server" SkinID="DropDownList" Width="130px" OnSelectedIndexChanged="ddlFieldToUpdate_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="(Select a field)">(Select a field)</asp:ListItem>
                                                        <asp:ListItem Value="VideoInspection">Video Inspection</asp:ListItem>
                                                        <asp:ListItem Value="PipeLocated">Pipe Located</asp:ListItem>
                                                        <asp:ListItem Value="ServicesLocated">Services Located</asp:ListItem>
                                                        <asp:ListItem Value="PrepType">Prep Type</asp:ListItem>
                                                        <%--<asp:ListItem Value="CoRequired">C/O Req.</asp:ListItem>--%>
                                                        <asp:ListItem Value="CoPitLocation">CO/Pit Location</asp:ListItem>
                                                        <asp:ListItem Value="CoInstalled">C/O Installed</asp:ListItem>
                                                        <asp:ListItem Value="BackfilledConcrete">Backfilled Concrete</asp:ListItem>
                                                        <asp:ListItem Value="BackfilledSoil">Backfilled Soil</asp:ListItem>
                                                        <asp:ListItem Value="Grouted">Grouted</asp:ListItem>
                                                        <asp:ListItem Value="Cored">Cored</asp:ListItem>
                                                        <asp:ListItem Value="Prepped">Prepped</asp:ListItem>
                                                        <asp:ListItem Value="PreVideo">Pre-Video</asp:ListItem>
                                                        <asp:ListItem Value="Measured">Measured</asp:ListItem>
                                                        <asp:ListItem Value="LinerType">Liner Type</asp:ListItem>
                                                        <asp:ListItem Value="NoticeDelivered">Notice Delivered</asp:ListItem>
                                                        <asp:ListItem Value="InProcess">In Process</asp:ListItem>
                                                        <asp:ListItem Value="InStock">In Stock</asp:ListItem>
                                                        <asp:ListItem Value="Delivered">Delivered</asp:ListItem>
                                                        <asp:ListItem Value="LinerInstalled">Liner Installed</asp:ListItem>
                                                        <asp:ListItem Value="FinalVideo">Final Video</asp:ListItem>
                                                        <asp:ListItem Value="CoCutDown">C/O Cut Down?</asp:ListItem>
                                                        <asp:ListItem Value="FinalRestoration">Final Restoration</asp:ListItem>
                                                        <asp:ListItem Value="Comment">Comment</asp:ListItem>
                                                        <asp:ListItem Value="OutOfScope">Out Of Scope</asp:ListItem>
                                                        <asp:ListItem Value="DigRequiredPriorToLining">Dig Req'd Prior To Lining</asp:ListItem>
                                                        <asp:ListItem Value="DigRequiredPriorToLiningCompleted">Dig Req'd Prior To Lining Completed</asp:ListItem>
                                                        <asp:ListItem Value="DigRequiredAfterLining">Dig Req'd After Lining</asp:ListItem>
                                                        <asp:ListItem Value="DigRequiredAfterLiningCompleted">Dig Req'd After Lining Completed</asp:ListItem>
                                                        <asp:ListItem Value="HoldClientIssue">Hold - Client Issue</asp:ListItem>
                                                        <asp:ListItem Value="HoldClientIssueResolved">Hold - Client Issue Resolved</asp:ListItem>
                                                        <asp:ListItem Value="HoldLFSIssue">Hold - LFS Issue</asp:ListItem>
                                                        <asp:ListItem Value="HoldLFSIssueResolved">Hold - LFS Issue Resolved</asp:ListItem>
                                                        <asp:ListItem Value="LateralRequiresRoboticPrep">Lateral Requires Robotic Prep</asp:ListItem>
                                                        <asp:ListItem Value="LateralRequiresRoboticPrepCompleted">Lateral Requires Robotic Prep Completed</asp:ListItem>
                                                        <asp:ListItem Value="ContractYear">Contract Year</asp:ListItem>
                                                    </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvFieldToUpdate" runat="server" ControlToValidate="ddlFieldToUpdate"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a field to update."
                                                InitialValue="(Select a field)" SkinID="Validator" ValidationGroup="Begin">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>                               
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Enter the field value" EnableViewState="False"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                         <td>
                                            <asp:UpdatePanel ID="upnlValue" runat="server">
                                                <contenttemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpValue" runat="server" Width="130px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                    </telerik:RadDatePicker>
                                                                    <asp:CheckBox ID="cbxValue" runat="server" SkinID="CheckBox" Visible="false" />
                                                                    <asp:DropDownList ID="ddlCoPitLocationValue" runat="server" SkinID="DropDownList" Width="130px" Visible="false"
                                                                        DataSourceID="odsCoPitLocation" DataTextField="Name" DataMember="DefaultView" DataValueField="Name">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBox" Width="250px" TextMode="MultiLine" Rows="5" Visible="false">
                                                                    </asp:TextBox>
                                                                    <asp:TextBox ID="tbxValue" runat="server" SkinID="TextBox" Width="130px" Visible="false">
                                                                    </asp:TextBox>
                                                                    <asp:DropDownList ID="ddlPrepType" runat="server" SkinID="DropDownList" Width="130px" Visible="false">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="CO Req">CO Req</asp:ListItem>
                                                                        <asp:ListItem Value="PFM Req">PFM Req</asp:ListItem>
                                                                        <asp:ListItem Value="Pit Req">Pit Req</asp:ListItem>
                                                                        <asp:ListItem Value="Fact CO Req">Fact CO Req</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlLinerType" runat="server" SkinID="DropDownList" Width="130px" Visible="false">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="LFM Liner">LFM Liner</asp:ListItem>
                                                                        <asp:ListItem Value="J-Liner">J-Liner</asp:ListItem>
                                                                        <asp:ListItem Value="Lat Liner">Lat Liner</asp:ListItem>
                                                                        <asp:ListItem Value="Prado Liner">Prado Liner</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: middle">
                                                                    <asp:UpdateProgress id="upValue" runat="server" AssociatedUpdatePanelID="upnlFieldToUpdate">
                                                                        <ProgressTemplate>
                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress> 
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFieldToUpdate" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </triggers>
                                            </asp:UpdatePanel>
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
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: auto">
                                        &nbsp;
                                    </td>
                                    <td style="width: 160px; text-align: right">                                        
                                    </td>
                                    <td style="width: 90px; text-align: right">                                        
                                    </td>
                                    <td style="width: 90px; text-align: right">  
                                        <asp:Button ID="FinishButton" style="width:80px" runat="server" CommandName="MoveComplete" Text="Finish"
                                            SkinID="Button" EnableViewState="False" />                                      
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
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProject" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                    <asp:HiddenField ID="hdfStep" runat="server" />
                </td>
            </tr>
        </table>
        
         <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <!-- Page element: Data objects -->
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCoPitLocation" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkJunctionLiningCoPitLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue=" " Name="name" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="abbreviation" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>