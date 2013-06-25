<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="vacations_setup.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="360px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">
                                <!-- Page element: Range title 1 columns -->
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSelectAPeriod" runat="server" SkinID="Label" Text="Select a period" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <!-- Page element: UpdatePanel -->
                                            <asp:UpdatePanel ID="upnlSelectAPeriod" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSelectAPeriod" runat="server" SkinID="DropDownList" Width="130px"
                                                        OnSelectedIndexChanged="ddlSelectAPeriod_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="2010">2010</asp:ListItem>
                                                        <asp:ListItem Value="2011">2011</asp:ListItem>
                                                        <asp:ListItem Value="2012">2012</asp:ListItem>
                                                        <asp:ListItem Value="2013">2013</asp:ListItem>
                                                        <asp:ListItem Value="2014">2014</asp:ListItem>
                                                        <asp:ListItem Value="2015">2015</asp:ListItem>
                                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                                        <asp:ListItem Value="2018">2018</asp:ListItem>
                                                        <asp:ListItem Value="2019">2019</asp:ListItem>
                                                        <asp:ListItem Value="2020">2020</asp:ListItem>
                                                        <asp:ListItem Value="2021">2021</asp:ListItem>
                                                        <asp:ListItem Value="2022">2022</asp:ListItem>
                                                        <asp:ListItem Value="2023">2023</asp:ListItem>
                                                        <asp:ListItem Value="2024">2024</asp:ListItem>
                                                        <asp:ListItem Value="2025">2025</asp:ListItem>
                                                        <asp:ListItem Value="2026">2026</asp:ListItem>
                                                        <asp:ListItem Value="2027">2027</asp:ListItem>
                                                        <asp:ListItem Value="2028">2028</asp:ListItem>
                                                        <asp:ListItem Value="2029">2029</asp:ListItem>
                                                        <asp:ListItem Value="2030">2030</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;&nbsp;
                                                    <asp:UpdateProgress ID="upPeriod" runat="server" AssociatedUpdatePanelID="upnlSelectAPeriod">
                                                        <ProgressTemplate>
                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                </table>
                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblVacationDaysTilte" runat="server" EnableViewState="False" SkinID="Label" Text="Please define the paid vacation days for your Team Members"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlVacationsSetup" runat="server" Height="260px" Width="400px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlVacationsSetup" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdVacationsSetup" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="383px" 
                                                            DataSourceID="odsVacationsSetup" DataKeyNames="Year,EmployeeID" >
                                                            <Columns>
                                                            
                                                                <asp:TemplateField HeaderText="Team Member">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmployeeName" runat="server" SkinID="Label" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Entitlement">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxVacationDays" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# Bind("VacationDays") %>' Width="73px" 
                                                                                        OnTextChanged="tbxTotalDays_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvVacationDays" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbxVacationDays" ValidationGroup="Begin" SkinID="Validator" Display="Dynamic"  ErrorMessage="Invalid data. (use #.## format)">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Carry Over">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCarryOverDays" runat="server" SkinID="TextBox" 
                                                                                        Text='<%# Bind("CarryOverDays") %>' Width="73px" 
                                                                                         OnTextChanged="tbxTotalDays_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                            </tr>  
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvCarryOverDays" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="tbxCarryOverDays" ValidationGroup="Begin" SkinID="Validator" Display="Dynamic"  ErrorMessage="Invalid data. (use #.## format)">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                          
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                 <asp:TemplateField HeaderText="Total">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:UpdatePanel id="upnlTotalCalc" runat="server" UpdateMode="Always">
                                                                                        <contenttemplate>
                                                                                            <asp:TextBox ID="tbxTotalDays" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                                            Text='<%# Bind("TotalVacationDays") %>' Width="73px" AutoPostBack="True"></asp:TextBox>
                                                                                        </contenttemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>                                                                            
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
                                                        <asp:ObjectDataSource ID="odsVacationsSetup" runat="server"
                                                            SelectMethod="GetVacationsSetupNew" 
                                                            TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_setup"
                                                            DeleteMethod="DummyVacationsSetupNew" InsertMethod="DummyVacationsSetupNew" UpdateMethod="DummyVacationsSetupNew" >
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="350px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="25"></asp:TextBox>
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
                                    <td style="width: 80px; text-align: right">
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
                    <asp:HiddenField ID="hdfIsVacationManager" runat="server" />
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>