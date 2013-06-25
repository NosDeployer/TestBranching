<%@ Page Language="C#" MasterPageFile="./../../mWizard2.master" AutoEventWireup="true" 
CodeBehind="timesheet_missing.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_missing" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 500px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzMissingProjectTime" runat="server" ActiveStepIndex="0" DisplaySideBar="False"
                        OnActiveStepChanged="wzMissingProjectTime_ActiveStepChanged" SkinID="Wizard"
                        Width="500px" Height="250px" OnFinishButtonClick="wzMissingProjectTime_FinishButtonClick" CancelButtonText="Close" DisplayCancelButton="True" OnCancelButtonClick="wzMissingProjectTime_CancelButtonClick">
                        <WizardSteps>
                        
                        
                            <asp:WizardStep ID="Start" runat="server" Title="Start">
                                <!-- Page element: 1 column -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStart" runat="server" SkinID="Label" Text="Click next to continue." EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        
                        
                            <asp:WizardStep ID="Criteria" runat="server" Title="Criteria">
                                <!-- Page element: Range title 4 columns -->
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblCountry" runat="server" SkinID="Label" Text="Select Country" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 125px">
                                        </td>
                                        <td style="width: 125px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCountry" runat="server" SkinID="DropDownList" Width="240px" DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblEmployee" runat="server" SkinID="Label" Text="Select Team Member" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>                          
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCriteriaEmployee" runat="server" SkinID="DropDownList"
                                                Width="240px" DataSourceID="odsEmployee" DataTextField="FullName" DataValueField="EmployeeID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblEmployeeType" runat="server" SkinID="Label" Text="Select Team Member Type" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlEmployeeType" runat="server" SkinID="DropDownList" Width="240px">
                                                <asp:ListItem Value="(All)" Enabled="true">(All)</asp:ListItem>                                                
                                                <asp:ListItem Value="LFSCA">LFS Canada</asp:ListItem>
                                                <asp:ListItem Value="LFSUS">LFS USA</asp:ListItem>
                                                <asp:ListItem Value="LFS">All LFS</asp:ListItem>
                                                <asp:ListItem Value="PAGCA">PAG Canada</asp:ListItem>
                                                <asp:ListItem Value="PAGUS">PAG USA</asp:ListItem>
                                                <asp:ListItem Value="PAG">All PAG</asp:ListItem>
                                                <asp:ListItem Value="CA">All Canada</asp:ListItem>
                                                <asp:ListItem Value="US">All USA</asp:ListItem>
                                                <asp:ListItem Value="SOTA">SOTA</asp:ListItem>
                                                <asp:ListItem Value="Subcontractor">Subcontractor</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblIncludeSalaried" runat="server" SkinID="Label" Text="Include Salaried"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="cbxIncludeSalaried" runat="server" SkinID="CheckBox" Checked="false" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblState" runat="server" Text="Select Team Member State" SkinID="Label"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlState" runat="server" SkinID="DropDownListLookup"
                                                DataSourceID="odsState" Width="240px" DataValueField="State" DataTextField="Description">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>                                
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="115px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="115px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        
                        
                            <asp:WizardStep ID="Format" runat="server" Title="Format">
                                <!-- Page element: 1 column -->
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnFormatPdf" runat="server" GroupName="Format"
                                                SkinID="RadioButton" Text="To PDF format" Checked="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnFormatExcel" runat="server" GroupName="Format" SkinID="RadioButton"
                                                Text="To Excel format" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data components -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadByRequestProjectTimeAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="requestProjectTime" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCountry" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsState" runat="server" SelectMethod="Load" 
                        TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeStateGateway" OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>