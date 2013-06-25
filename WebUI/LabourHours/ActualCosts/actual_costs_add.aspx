<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" 
    CodeBehind="actual_costs_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 740px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Wizard ID="wzActualCostsAdd" runat="server" Width="910px" Height="450px"
                                                ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard"
                                                OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick"
                                                OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                                                OnPreviousButtonClick="Wizard_PreviousButtonClick">
                                                <WizardSteps>                                                
                                                
                                                    <asp:WizardStep ID="StepBegin" runat="server" Title="Begin" StepType="Start">
                                                    
                                                        <!-- Page element: 2 column -->                                                                                                                                                           
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width:30px"></td>
                                                                <td></td>
                                                            </tr>                                                            
                                                            <tr>                                                                                                                            
                                                                <td colspan="2">                                                                
                                                                    <asp:Label ID="lblForSubcontractors" runat="server" EnableViewState="False" SkinID="Label" Text="For Subcontractors"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td style="height: 7px;"  colspan="2">                                                                                                                                
                                                                </td>    
                                                                <td></td>                                                                                                                    
                                                            </tr>                                                             
                                                            <tr>  
                                                                <td></td>                                                                                                                          
                                                                <td>
                                                                    <asp:CheckBox ID="cbxSubcontractorCosts" runat="server" Checked="false" Text="Add Subcontractor Costs"  SkinID="CheckBox"
                                                                        OnCheckedChanged="cbxSubcontractorCost_CheckedChanged" AutoPostBack="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                               
                                                                <td style="height: 7px;">
                                                                </td>                                                                                                                        
                                                                <td></td>
                                                            </tr>                                                              
                                                            <tr>                             
                                                                <td></td>                                                                                               
                                                                <td>
                                                                    <asp:UpdatePanel id="upnlSubcontractorCost" runat="server"> 
                                                                        <contenttemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width:30px"></td>
                                                                                    <td></td>
                                                                                </tr>   
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbtnSubcontractorCostsBySubcontractor" runat="server" 
                                                                                            Checked="True" GroupName="Begin" SkinID="RadioButton" 
                                                                                            Text="Add Costs by Subcontractor" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rbtnSubcontractorCostsByProjectAndClient" runat="server" 
                                                                                            GroupName="Begin" SkinID="RadioButton" Text="Add Costs by Client - Project" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </contenttemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                                   
                                                                <td style="height: 7px;">
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td colspan="2">                                                                
                                                                    <asp:Label ID="lblOtherCategories" runat="server" EnableViewState="False" SkinID="Label" Text="For Other Categories"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td style="height: 7px;"  colspan="2">                                                                                                                                
                                                                </td>    
                                                                <td></td> 
                                                            <tr>                                                                                                                                
                                                                <td></td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxHotelCosts" runat="server"  SkinID="CheckBox"
                                                                        Text="Add Hotel Costs by Client - Project" />
                                                                </td>
                                                            </tr>    
                                                            <tr>                                                                                                                                
                                                                <td style="height: 7px;">
                                                                </td>
                                                                <td></td>
                                                            </tr>    
                                                            <tr>                                                                                                                            
                                                                <td>
                                                                    </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxBondingCosts" runat="server"  SkinID="CheckBox"
                                                                        Text="Add Bonding Costs by Client - Project" />
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td style="height: 7px;">
                                                                </td>                                                        
                                                                <td></td>
                                                            </tr>
                                                            <tr>                                                                                                                                
                                                                <td>
                                                                    </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxInsuranceCosts" runat="server"  SkinID="CheckBox"
                                                                        Text="Add Insurance Costs by Client - Project" />
                                                                </td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td style="height: 7px;">
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>                                                                                                                            
                                                                <td></td>                                                                                                                         
                                                                <td>
                                                                    <asp:CheckBox ID="cbxOtherCosts" runat="server"  SkinID="CheckBox"
                                                                        Text="Add Other Costs by Client - Project" />
                                                                </td>
                                                            </tr>                                                            
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                
                                                    <asp:WizardStep ID="StepSubcontractorCostsBySubcontractor" runat="server" Title="SubcontractorCostsBySubcontractor" >
                                                        <!-- Page element: 2 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:Label ID="lblSubcontractor" runat="server" SkinID="Label" Text="Subcontractor"
                                                                        EnableViewState="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList Width="350px" ID="ddlSubcontractor" runat="server" SkinID="DropDownListLookup"
                                                                        DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                                                                        DataSourceID="odsSubcontractorsList">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                </td>                                                                
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlSubcontractor" ValidationGroup="generalData"
                                                                        Display="Dynamic" ErrorMessage="Please select a subcontractor." InitialValue="-1"
                                                                        SkinID="Validator"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 10px">
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                                                        </table>
        
                                                        <!-- Page element: 1 column title -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:Label ID="lblSubcontractorCostsBySubcontractor" runat="server" SkinID="Label" Text="Subcontractor Costs"
                                                                        EnableViewState="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                            
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 740px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlSubcontractorCostsBySubcontractor" runat="server" Height="330px" Width="740px">
                                                                        <asp:UpdatePanel ID="upnlSubcontractorCostsBySubcontractor" runat="server">
                                                                            <ContentTemplate>
                                                                                <!-- Page element: 1 column - Grid Project Time -->
                                                                                <asp:GridView ID="grdSubcontractorCostsBySubcontractor" runat="server" SkinID="GridView" Width="780px"
                                                                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="6" ShowFooter="True"
                                                                                    OnDataBound="grdSubcontractorCostsBySubcontractor_DataBound" OnRowCommand="grdSubcontractorCostsBySubcontractor_RowCommand"
                                                                                    OnRowUpdating="grdSubcontractorCostsBySubcontractor_RowUpdating" OnRowEditing="grdSubcontractorCostsBySubcontractor_RowEditing"
                                                                                    OnRowDeleting="grdSubcontractorCostsBySubcontractor_RowDeleting" OnRowDataBound="grdSubcontractorCostsBySubcontractor_RowDataBound"
                                                                                    DataKeyNames="ProjectID,RefID" DataSourceID="odsSubcontractorCostsBySubcontractor">
                                                                                    <Columns>
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblProjectIdEdit" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProjectId" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblProjectIdFooter" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIdEdit" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField SortExpression="SubcontractorID" Visible="False" HeaderText="SubcontractorID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorIdEdit" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorId" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>' TabIndex="1"
                                                                                                                Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" ControlToValidate="tkrdpDateEdit"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataEdit" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateFooter" runat="server" Width="100px" SkinID="RadDatePicker" TabIndex="1"
                                                                                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateFooter" runat="server" ControlToValidate="tkrdpDateFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: center">
                                                                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Client">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblClientEdit" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>                                                                                                   
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlClientFooter" runat="server" UpdateMode="Conditional">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlClientFooter" runat="server" SkinID="DropDownListLookup"
                                                                                                                        Width="100px" DataSourceID="odsClientFooter" AutoPostBack="True" TabIndex="2"
                                                                                                                        DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooter_SelectedIndexChanged">
                                                                                                                    </asp:DropDownList>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvClientFooter" runat="server" ControlToValidate="ddlClientFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblProjectEdit" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>                                                                                                    
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlProjectFooter" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                        <tbody>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:DropDownList ID="ddlProjectFooter" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                                                                        Width="140px" AutoPostBack="True">
                                                                                                                                    </asp:DropDownList>
                                                                                                                                </td>
                                                                                                                                <td style="vertical-align: middle">
                                                                                                                                    <asp:UpdateProgress ID="upProjectFooter" runat="server" AssociatedUpdatePanelID="upnlClientFooter">
                                                                                                                                        <ProgressTemplate>
                                                                                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                                                        </ProgressTemplate>
                                                                                                                                    </asp:UpdateProgress>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </tbody>
                                                                                                                    </table>
                                                                                                                </ContentTemplate>
                                                                                                                <Triggers>
                                                                                                                    <asp:AsyncPostBackTrigger ControlID="ddlClientFooter" EventName="SelectedIndexChanged">
                                                                                                                    </asp:AsyncPostBackTrigger>
                                                                                                                </Triggers>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvProjectFooter" runat="server" ControlToValidate="ddlProjectFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlQuantityEdit" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxQuantityEdit" runat="server" SkinID="TextBoxRight" Text='<%# Eval("Quantity") %>' TabIndex="4"
                                                                                                                        Width="60px" OnTextChanged="tbxQuantityEdit_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvQuantityEdit" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Double" ControlToValidate="tbxQuantityEdit" ValidationGroup="DataEdit"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlQuantityFooter" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxQuantityFooter" runat="server" SkinID="TextBoxRight" Text="0.0" TabIndex="4"
                                                                                                                        Width="60px" OnTextChanged="tbxQuantityFooter_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvQuantityFooter" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Double" ControlToValidate="tbxQuantityFooter" ValidationGroup="DataNew"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Rate">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateEdit" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateEdit" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>' TabIndex="5"
                                                                                                                        Width="60px" OnTextChanged="tbxRateEdit_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateEdit" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                                                                ControlToValidate="tbxRateEdit" ValidationGroup="DataEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateFooter" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateFooter" runat="server" SkinID="TextBoxRight" Text="0.00" TabIndex="5"
                                                                                                                        Width="60px" OnTextChanged="tbxRateFooter_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateFooter" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                                                                ControlToValidate="tbxRateFooter" ValidationGroup="DataNew" SkinID="Validator"
                                                                                                                Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblRate" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Total">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlTotalCalcEdit" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxTotalEdit" runat="server" SkinID="TextBoxRightReadOnly" Text='<%# String.Format("{0:N2}", Eval("Total")) %>' TabIndex="6"
                                                                                                                            AutoPostBack="True" Width="60px" ReadOnly="true"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlTotalCalcFooter" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxTotalFooter" runat="server" ReadOnly="true" SkinID="TextBoxRightReadOnly" TabIndex="6"
                                                                                                                        Text="0.00" AutoPostBack="True" Width="60px"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:N2}", Eval("Total")) %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="Comments">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxCommentFooter" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                Width="160px"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
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
                                                                                            <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                    OnClientClick='return confirm("Are you sure you want to delete this subcontractor costs?");'>
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 30px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: Data objects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60"
                                                                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    <asp:ObjectDataSource ID="odsSubcontractorCostsBySubcontractor" runat="server" SelectMethod="GetSubcontractorCostsBySubcontractorDetail"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                        DeleteMethod="DummySubcontractorCostsBySubcontractorDetail" FilterExpression="(Deleted = 0)" UpdateMethod="DummySubcontractorCostsBySubcontractorDetail"
                                                                        InsertMethod="DummySubcontractorCostsBySubcontractorDetail" OldValuesParameterFormatString="original_{0}">
                                                                        <DeleteParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </DeleteParameters>
                                                                        <UpdateParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </UpdateParameters>
                                                                        <InsertParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </InsertParameters>
                                                                    </asp:ObjectDataSource>
                                                                    <asp:ObjectDataSource ID="odsClientEdit" runat="server" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    <asp:ObjectDataSource ID="odsClientFooter" runat="server" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>                                                                                                                
                                                    </asp:WizardStep>
                                                
                                                
                                                
                                                    <asp:WizardStep ID="StepSubcontractorCostsByClientProject" runat="server" Title="SubcontractorCostsByClientProject">
                                                        <!-- Page element: 4 columns -->
                                                        <table border="0" cellpadding="0" cellspacing="0" width="790px%">
                                                            <tr>
                                                                <td style="width: 197px">
                                                                    <asp:Label ID="lblClientByClientProject" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                                                                </td>
                                                                <td style="width: 198px">
                                                                </td>
                                                                <td style="width: 197px">
                                                                    <asp:Label ID="lblProjectByClientProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                                                                </td>
                                                                <td style="width: 198px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel ID="upnlClientByClientProject" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlClientByClientProject" runat="server" SkinID="DropDownListLookup" Width="385px"
                                                                                DataMember="DefaultView" DataSourceID="odsClientByClientProject" AutoPostBack="True" DataValueField="Companies_ID"
                                                                                DataTextField="NAME" OnSelectedIndexChanged="ddlClientByClientProject_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td colspan="2">
                                                                    <!-- Page element: UpdatePanel -->
                                                                    <asp:UpdatePanel ID="upnlProjectByClientProject" runat="server">
                                                                        <ContentTemplate>
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlProjectByClientProject" runat="server" SkinID="DropDownListLookup" Width="385px"
                                                                                                DataMember="DefaultView">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="vertical-align: middle">
                                                                                            <asp:UpdateProgress ID="upAjax1" runat="server" AssociatedUpdatePanelID="upnlClientByClientProject">
                                                                                                <ProgressTemplate>
                                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                </ProgressTemplate>
                                                                                            </asp:UpdateProgress>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlClientByClientProject" EventName="SelectedIndexChanged">
                                                                            </asp:AsyncPostBackTrigger>
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvClientByClientProject" runat="server" ControlToValidate="ddlClientByClientProject" ValidationGroup="generalDataByClientProject"
                                                                        Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="rfvProjectByClientProject" runat="server" ControlToValidate="ddlProjectByClientProject" ValidationGroup="generalDataByClientProject"
                                                                        Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 10px">
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: 1 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:Label ID="lblSubcontractorCostByClientProject" runat="server" SkinID="Label" Text="Costs" EnableViewState="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px">
                                                                </td>                                                            
                                                            </tr>                                                          
                                                        </table>         
                                                        
                                                        <%--Grid--%>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlSubcontractorsCostsByClientProject" runat="server" Height="330px" Width="780px">
                                                                        <asp:UpdatePanel ID="upnlSubcontractorByClientProject" runat="server">
                                                                            <ContentTemplate>
                                                                                <!-- Page element: 1 column - Grid Project Time -->
                                                                                <asp:GridView ID="grdSubcontractorCostsByClientProject" runat="server" SkinID="GridView" Width="780px"
                                                                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                                                    OnDataBound="grdSubcontractorCostsByClientProject_DataBound" OnRowCommand="grdSubcontractorCostsByClientProject_RowCommand"
                                                                                    OnRowUpdating="grdSubcontractorCostsByClientProject_RowUpdating" OnRowEditing="grdSubcontractorCostsByClientProject_RowEditing"
                                                                                    OnRowDeleting="grdSubcontractorCostsByClientProject_RowDeleting" OnRowDataBound="grdSubcontractorCostsByClientProject_RowDataBound"
                                                                                    DataKeyNames="ProjectID,RefID" DataSourceID="odsSubcontractorsCostsByClientProject">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblProjectIdByClientProjectEdit" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProjectIdByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblProjectIdFooterByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIdEditByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefIdByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField SortExpression="SubcontractorID" Visible="False" HeaderText="SubcontractorID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorIdEditByClientProject" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorIdByClientProject" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateEditByClientProject" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>'
                                                                                                                Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateEditByClientProject" runat="server" ControlToValidate="tkrdpDateEditByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataEditByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateFooterByClientProject" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateFooterByClientProject" runat="server" ControlToValidate="tkrdpDateFooterByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataNewByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: center">
                                                                                                            <asp:Label ID="lblDateByClientProject" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Subcontractors">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="ddlSubcontractorEditByClientProject" runat="server" SkinID="DropDownListLookup" DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                                                                                                                DataSourceID="odsSubcontractorsListEditByClientProject"
                                                                                                                Width="220px">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvSubcontractorEditByClientProject" runat="server" ControlToValidate="ddlSubcontractorEditByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Subcontractor." InitialValue="-1"
                                                                                                                SkinID="Validator" ValidationGroup="DataEditByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Width="220px" ID="ddlSubcontractorFooterByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                                                                                                                DataSourceID="odsSubcontractorsListFooterByClientProject">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvSubcontractorFooterByClientProject" runat="server" ControlToValidate="ddlSubcontractorFooterByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Subcontractor." InitialValue="-1"
                                                                                                                SkinID="Validator" ValidationGroup="DataNewByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="220px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblSubcontractorByClientProject" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlQuantityEditByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxQuantityEditByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# Eval("Quantity") %>'
                                                                                                                        Width="60px" OnTextChanged="tbxQuantityEditByClientProject_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvQuantityEditByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Double" ControlToValidate="tbxQuantityEditByClientProject" ValidationGroup="DataEditByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlQuantityFooterByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxQuantityFooterByClientProject" runat="server" SkinID="TextBoxRight" Text="0.0"
                                                                                                                        Width="60px" OnTextChanged="tbxQuantityFooterByClientProject_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvQuantityFooterByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Double" ControlToValidate="tbxQuantityFooterByClientProject" ValidationGroup="DataNewByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblQuantityByClientProject" runat="server" Text='<%# Eval("Quantity") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Rate">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateEditByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateEditByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                        Width="60px" OnTextChanged="tbxRateEditByClientProject_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateEditByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Currency" ControlToValidate="tbxRateEditByClientProject" ValidationGroup="DataEditByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateFooterByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateFooterByClientProject" runat="server" SkinID="TextBoxRight" Text="0.00"
                                                                                                                        Width="60px" OnTextChanged="tbxRateFooterByClientProject_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateFooterByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Currency" ControlToValidate="tbxRateFooterByClientProject" ValidationGroup="DataNewByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblRateByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Total">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlTotalCalcEditByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxTotalEditByClientProject" runat="server" SkinID="TextBoxRightReadOnly" Text='<%# String.Format("{0:N2}", Eval("Total")) %>'
                                                                                                                            AutoPostBack="True" Width="60px" ReadOnly="true"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlTotalCalcFooterByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxTotalFooterByClientProject" runat="server" ReadOnly="true" SkinID="TextBoxRightReadOnly"
                                                                                                                        Text="0.00" AutoPostBack="True" Width="60px"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblTotalByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Total")) %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Comments">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentEditByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxCommentFooterByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                Width="160px"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblCommentByClientProject" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
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
                                                                                            <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                    OnClientClick='return confirm("Are you sure you want to delete this subcontractor costs?");'>
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 30px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: DataObjects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsSubcontractorsListEditByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsSubcontractorsListFooterByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsSubcontractorsCostsByClientProject" runat="server" SelectMethod="GetSubcontractorsDetailByClientProject"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                        DeleteMethod="DummySubcontractorsDetail" FilterExpression="(Deleted = 0)"
                                                                        UpdateMethod="DummySubcontractorsDetail" InsertMethod="DummySubcontractorsDetail"
                                                                        OldValuesParameterFormatString="original_{0}">
                                                                        <DeleteParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </DeleteParameters>
                                                                        <UpdateParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </UpdateParameters>
                                                                        <InsertParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </InsertParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsClientByClientProject" runat="server" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                                                                                                                            
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepHotelCostsByClientProject" runat="server" Title="HotelCostsByClientProject">
                                                        <div runat="server" id="dvHotelCostsByClientProject" style="overflow-x: auto; overflow-y: hidden; width: 930px">                                                            
                                                            <!-- Page element: 1 column -->
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblHotelCosts" runat="server" SkinID="Label" Text="Hotel Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>                                                                                                                           
                                                            </table>
                                                        </div>
                                                        
                                                        <%--Grid--%>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlHotelCostsByClientProject" runat="server" Height="330px" Width="780px">
                                                                        <asp:UpdatePanel ID="upnlHotelCostsByClientProject" runat="server">
                                                                            <ContentTemplate>
                                                                                <!-- Page element: 1 column - Grid Project Time -->
                                                                                <asp:GridView ID="grdHotelCostsByClientProject" runat="server" SkinID="GridView" Width="780px"
                                                                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                                                    OnDataBound="grdHotelCostsByClientProject_DataBound" OnRowCommand="grdHotelCostsByClientProject_RowCommand"
                                                                                    OnRowUpdating="grdHotelCostsByClientProject_RowUpdating" OnRowEditing="grdHotelCostsByClientProject_RowEditing"
                                                                                    OnRowDeleting="grdHotelCostsByClientProject_RowDeleting" OnRowDataBound="grdHotelCostsByClientProject_RowDataBound"
                                                                                    DataKeyNames="ProjectID,RefID" DataSourceID="odsHotelCostsHotelByClientProject">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblProjectIdEditHotelByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProjectIdHotelByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblProjectIdFooterHotelByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIdEditHotelByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefIdHotelByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField SortExpression="HotelID" Visible="False" HeaderText="HotelID">
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblHotelIdEditHotelByClientProject" runat="server" Text='<%# Eval("HotelID") %>'></asp:Label></EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblHotelIdHotelByClientProject" runat="server" Text='<%# Eval("HotelID") %>'></asp:Label></ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateEditHotelByClientProject" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>'
                                                                                                                Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateEditHotelByClientProject" runat="server" ControlToValidate="tkrdpDateEditHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataEditHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <telerik:RadDatePicker ID="tkrdpDateFooterHotelByClientProject" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                            </telerik:RadDatePicker>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvDateFooterHotelByClientProject" runat="server" ControlToValidate="tkrdpDateFooterHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                ValidationGroup="DataNewHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: center">
                                                                                                            <asp:Label ID="lblDateHotelByClientProject" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Client">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblClientEditHotelByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>                                                                                                   
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlClientFooterHotelByClientProject" runat="server" UpdateMode="Conditional">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlClientFooterHotelByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                        Width="100px" DataSourceID="odsClientFooterHotelByClientProject" AutoPostBack="True" TabIndex="2"
                                                                                                                        DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooterHotelByClientProject_SelectedIndexChanged">
                                                                                                                    </asp:DropDownList>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvClientFooterHotelByClientProject" runat="server" ControlToValidate="ddlClientFooterHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                                                                ValidationGroup="DataNewHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblClientHotelByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblProjectEditHotelByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>                                                                                                            
                                                                                                        </td>
                                                                                                    </tr>                                                                                                    
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlProjectFooterHotelByClientProject" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                        <tbody>
                                                                                                                            <tr>
                                                                                                                                <td>
                                                                                                                                    <asp:DropDownList ID="ddlProjectFooterHotelByClientProject" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                                                                        Width="140px" AutoPostBack="True">
                                                                                                                                    </asp:DropDownList>
                                                                                                                                </td>
                                                                                                                                <td style="vertical-align: middle">
                                                                                                                                    <asp:UpdateProgress ID="upProjectFooterHotelByClientProject" runat="server" AssociatedUpdatePanelID="upnlClientFooterHotelByClientProject">
                                                                                                                                        <ProgressTemplate>
                                                                                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                                                        </ProgressTemplate>
                                                                                                                                    </asp:UpdateProgress>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </tbody>
                                                                                                                    </table>
                                                                                                                </ContentTemplate>
                                                                                                                <Triggers>
                                                                                                                    <asp:AsyncPostBackTrigger ControlID="ddlClientFooterHotelByClientProject" EventName="SelectedIndexChanged">
                                                                                                                    </asp:AsyncPostBackTrigger>
                                                                                                                </Triggers>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvProjectFooterHotelByClientProject" runat="server" ControlToValidate="ddlProjectFooterHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                                                                ValidationGroup="DataNewHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblProjectHotelByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                                                                                                               
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Hotel">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="ddlHotelEditHotelByClientProject" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                                                                                            DataMember="DefaultView" DataValueField="COMPANIES_ID"
                                                                                                                DataSourceID="odsHotelListEditHotelByClientProject"
                                                                                                                Width="220px">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvHotelEditHotelByClientProject" runat="server" ControlToValidate="ddlHotelEditHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Hotel." InitialValue="-1"
                                                                                                                SkinID="Validator" ValidationGroup="DataEditHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="ddlHotelFooterHotelByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                Width="220px" DataSourceID="odsHotelListFooterHotelByClientProject"  TabIndex="2"
                                                                                                                DataValueField="COMPANIES_ID" DataTextField="Name">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvSubcontractorFooterHotelByClientProject" runat="server" ControlToValidate="ddlHotelFooterHotelByClientProject"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a Subcontractor." InitialValue="-1"
                                                                                                                SkinID="Validator" ValidationGroup="DataNewHotelByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="220px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblSubcontractorHotelByClientProject" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>                                                                                    
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Rate">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateEditHotelByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateEditHotelByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                        Width="60px"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateEditHotelByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Currency" ControlToValidate="tbxRateEditHotelByClientProject" ValidationGroup="DataEditHotelByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel ID="upnlRateFooterHotelByClientProject" runat="server" UpdateMode="Always">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:TextBox ID="tbxRateFooterHotelByClientProject" runat="server" SkinID="TextBoxRight" Text="0.00"
                                                                                                                        Width="60px"></asp:TextBox>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvRateFooterHotelByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                Type="Currency" ControlToValidate="tbxRateFooterHotelByClientProject" ValidationGroup="DataNewHotelByClientProject"
                                                                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                            </asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="text-align: right">
                                                                                                            <asp:Label ID="lblRateHotelByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                                                                                                               
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Comments">
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentEditHotelByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 12px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxCommentFooterHotelByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                Width="160px"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblCommentHotelByClientProject" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
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
                                                                                            <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                    OnClientClick='return confirm("Are you sure you want to delete this hotel costs?");'>
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 30px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                                                                                
                                                        <!-- Page element: DataObjects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsHotelListEditHotelByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Hotels.HotelsList">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="hotelId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a hotel)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsHotelListFooterHotelByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Hotels.HotelsList">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="hotelId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a hotel)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsHotelCostsHotelByClientProject" runat="server" SelectMethod="GetHotelDetailHotelByClientProject"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                        DeleteMethod="DummyHotelDetail" FilterExpression="(Deleted = 0)"
                                                                        UpdateMethod="DummyHotelDetail" InsertMethod="DummyHotelDetail"
                                                                        OldValuesParameterFormatString="original_{0}">
                                                                        <DeleteParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </DeleteParameters>
                                                                        <UpdateParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </UpdateParameters>
                                                                        <InsertParameters>
                                                                            <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                            <asp:Parameter Name="RefID" Type="Int32" />
                                                                        </InsertParameters>
                                                                    </asp:ObjectDataSource>
                                                                    
                                                                    <asp:ObjectDataSource ID="odsClientFooterHotelByClientProject" runat="server" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepBondingCompaniesCostsByClientProject" runat="server" Title="BondingCompaniesCostsByClientProject">
                                                        <div runat="server" id="dvBondingCompaniesCostsByClientProject" style="overflow-x: auto; overflow-y: hidden; width: 930px">                                                                                                                        
                                                            <!-- Page element: 1 column -->                                                            
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblBondingCompaniesCosts" runat="server" SkinID="Label" Text="Bonding Companies Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>                                                                                                                             
                                                            </table>
                                                            
                                                            <%--Grid--%>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="pnlBondingCompaniesCostsByClientProject" runat="server" Height="330px" Width="780px">
                                                                            <asp:UpdatePanel ID="upnlBondingCompaniesCostsByClientProject" runat="server">
                                                                                <ContentTemplate>
                                                                                    <!-- Page element: 1 column - Grid Project Time -->
                                                                                    <asp:GridView ID="grdBondingCompaniesCostsByClientProject" runat="server" SkinID="GridView" Width="780px"
                                                                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                                                        OnDataBound="grdBondingCompaniesCostsByClientProject_DataBound" OnRowCommand="grdBondingCompaniesCostsByClientProject_RowCommand"
                                                                                        OnRowUpdating="grdBondingCompaniesCostsByClientProject_RowUpdating" OnRowEditing="grdBondingCompaniesCostsByClientProject_RowEditing"
                                                                                        OnRowDeleting="grdBondingCompaniesCostsByClientProject_RowDeleting" OnRowDataBound="grdBondingCompaniesCostsByClientProject_RowDataBound"
                                                                                        DataKeyNames="ProjectID,RefID" DataSourceID="odsBondingCompaniesCostsBondingCompaniesByClientProject">
                                                                                        <Columns>
                                                                                        
                                                                                            <%--0--%>
                                                                                            <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdEditBondingCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdBondingCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblProjectIdFooterBondingCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--1--%>
                                                                                            <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdEditBondingCompaniesByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdBondingCompaniesByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--2--%>
                                                                                            <asp:TemplateField SortExpression="BondingCompanyID" Visible="False" HeaderText="BondingCompanyID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblBondingCompanyIdEditBondingCompaniesByClientProject" runat="server" Text='<%# Eval("BondingCompanyID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblBondingCompanyIdBondingCompaniesByClientProject" runat="server" Text='<%# Eval("BondingCompanyID") %>'></asp:Label></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--3--%>
                                                                                            <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateEditBondingCompaniesByClientProject" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>'
                                                                                                                    Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateEditBondingCompaniesByClientProject" runat="server" ControlToValidate="tkrdpDateEditBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataEditBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateFooterBondingCompaniesByClientProject" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateFooterBondingCompaniesByClientProject" runat="server" ControlToValidate="tkrdpDateFooterBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: center">
                                                                                                                <asp:Label ID="lblDateBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--4--%>
                                                                                            <asp:TemplateField HeaderText="Client">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientEditBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>                                                                                                   
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlClientFooterBondingCompaniesByClientProject" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:DropDownList ID="ddlClientFooterBondingCompaniesByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                            Width="100px" DataSourceID="odsClientFooterBondingCompaniesByClientProject" AutoPostBack="True" TabIndex="2"
                                                                                                                            DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooterBondingCompaniesByClientProject_SelectedIndexChanged">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvClientFooterBondingCompaniesByClientProject" runat="server" ControlToValidate="ddlClientFooterBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--5--%>
                                                                                            <asp:TemplateField HeaderText="Project">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectEditBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>                                                                                                            
                                                                                                            </td>
                                                                                                        </tr>                                                                                                    
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlProjectFooterBondingCompaniesByClientProject" runat="server">
                                                                                                                    <ContentTemplate>
                                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                            <tbody>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:DropDownList ID="ddlProjectFooterBondingCompaniesByClientProject" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                                                                            Width="140px" AutoPostBack="True">
                                                                                                                                        </asp:DropDownList>
                                                                                                                                    </td>
                                                                                                                                    <td style="vertical-align: middle">
                                                                                                                                        <asp:UpdateProgress ID="upProjectFooterBondingCompaniesByClientProject" runat="server" AssociatedUpdatePanelID="upnlClientFooterBondingCompaniesByClientProject">
                                                                                                                                            <ProgressTemplate>
                                                                                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                                                            </ProgressTemplate>
                                                                                                                                        </asp:UpdateProgress>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </tbody>
                                                                                                                        </table>
                                                                                                                    </ContentTemplate>
                                                                                                                    <Triggers>
                                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlClientFooterBondingCompaniesByClientProject" EventName="SelectedIndexChanged">
                                                                                                                        </asp:AsyncPostBackTrigger>
                                                                                                                    </Triggers>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvProjectFooterBondingCompaniesByClientProject" runat="server" ControlToValidate="ddlProjectFooterBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--6--%>
                                                                                            <asp:TemplateField HeaderText="Bonding Companies">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlBondingCompaniesEditBondingCompaniesByClientProject" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                                                                                                DataMember="DefaultView" DataValueField="COMPANIES_ID" DataSourceID="odsBondingCompaniesListEditBondingCompaniesByClientProject"
                                                                                                                    Width="220px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvBondingCompaniesEditBondingCompaniesByClientProject" runat="server" ControlToValidate="ddlBondingCompaniesEditBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a BondingCompanies." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataEditBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlBondingCompaniesFooterBondingCompaniesByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                    Width="220px" DataSourceID="odsBondingCompaniesListFooterBondingCompaniesByClientProject"  TabIndex="2"
                                                                                                                    DataValueField="COMPANIES_ID" DataTextField="Name">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvSubcontractorFooterBondingCompaniesByClientProject" runat="server" ControlToValidate="ddlBondingCompaniesFooterBondingCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Bonding Company." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataNewBondingCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="220px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblSubcontractorBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>                                                                                    
                                                                                            
                                                                                            <%--7--%>
                                                                                            <asp:TemplateField HeaderText="Rate">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateEditBondingCompaniesByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateEditBondingCompaniesByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateEditBondingCompaniesByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateEditBondingCompaniesByClientProject" ValidationGroup="DataEditBondingCompaniesByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateFooterBondingCompaniesByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateFooterBondingCompaniesByClientProject" runat="server" SkinID="TextBoxRight" Text="0.00"
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateFooterBondingCompaniesByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateFooterBondingCompaniesByClientProject" ValidationGroup="DataNewBondingCompaniesByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: right">
                                                                                                                <asp:Label ID="lblRateBondingCompaniesByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                    SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--8--%>
                                                                                            <asp:TemplateField HeaderText="Comments">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="tbxCommentEditBondingCompaniesByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                        Width="160px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentFooterBondingCompaniesByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblCommentBondingCompaniesByClientProject" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
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
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                        OnClientClick='return confirm("Are you sure you want to delete this BondingCompanies costs?");'>
                                                                                                                    </asp:ImageButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 30px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                                                                                    
                                                            <!-- Page element: DataObjects -->
                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ObjectDataSource ID="odsBondingCompaniesListEditBondingCompaniesByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesList">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="bondingCompanyId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a Bonding Company)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsBondingCompaniesListFooterBondingCompaniesByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesList">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="bondingCompanyId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a Bonding Company)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsBondingCompaniesCostsBondingCompaniesByClientProject" runat="server" SelectMethod="GetBondingCompaniesDetailBondingCompaniesByClientProject"
                                                                            TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                            DeleteMethod="DummyBondingCompaniesDetail" FilterExpression="(Deleted = 0)"
                                                                            UpdateMethod="DummyBondingCompaniesDetail" InsertMethod="DummyBondingCompaniesDetail"
                                                                            OldValuesParameterFormatString="original_{0}">
                                                                            <DeleteParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </DeleteParameters>
                                                                            <UpdateParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </UpdateParameters>
                                                                            <InsertParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </InsertParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsClientFooterBondingCompaniesByClientProject" runat="server" SelectMethod="LoadAndAddItem"
                                                                            TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepInsuranceCompaniesCostsByClientProject" runat="server" Title="InsuranceCompaniesCostsByClientProject">
                                                        <div runat="server" id="dvnsuranceCompaniesCostsByClientProject" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <!-- Page element: 1 column -->                                                            
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblInsuranceCompaniesCosts" runat="server" SkinID="Label" Text="Insurance Companies Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>                                                                                                                           
                                                            </table>
                                                            
                                                            <%--Grid--%>                                                             
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="pnlInsuranceCompaniesCostsByClientProject" runat="server" Height="330px" Width="780px">
                                                                            <asp:UpdatePanel ID="upnlInsuranceCompaniesCostsByClientProject" runat="server">
                                                                                <ContentTemplate>
                                                                                    <!-- Page element: 1 column - Grid Project Time -->
                                                                                    <asp:GridView ID="grdInsuranceCompaniesCostsByClientProject" runat="server" SkinID="GridView" Width="780px"
                                                                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                                                        OnDataBound="grdInsuranceCompaniesCostsByClientProject_DataBound" OnRowCommand="grdInsuranceCompaniesCostsByClientProject_RowCommand"
                                                                                        OnRowUpdating="grdInsuranceCompaniesCostsByClientProject_RowUpdating" OnRowEditing="grdInsuranceCompaniesCostsByClientProject_RowEditing"
                                                                                        OnRowDeleting="grdInsuranceCompaniesCostsByClientProject_RowDeleting" OnRowDataBound="grdInsuranceCompaniesCostsByClientProject_RowDataBound"
                                                                                        DataKeyNames="ProjectID,RefID" DataSourceID="odsInsuranceCompaniesCostsInsuranceCompaniesByClientProject">
                                                                                        <Columns>
                                                                                        
                                                                                            <%--0--%>
                                                                                            <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdEditInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblProjectIdFooterInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--1--%>
                                                                                            <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdEditInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--2--%>
                                                                                            <asp:TemplateField SortExpression="InsuranceCompanyID" Visible="False" HeaderText="InsuranceCompanyID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblInsuranceCompanyIdEditInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("InsuranceCompanyID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblInsuranceCompanyIdInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("InsuranceCompanyID") %>'></asp:Label></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--3--%>
                                                                                            <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateEditInsuranceCompaniesByClientProject" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>'
                                                                                                                    Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateEditInsuranceCompaniesByClientProject" runat="server" ControlToValidate="tkrdpDateEditInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataEditInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateFooterInsuranceCompaniesByClientProject" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateFooterInsuranceCompaniesByClientProject" runat="server" ControlToValidate="tkrdpDateFooterInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: center">
                                                                                                                <asp:Label ID="lblDateInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--4--%>
                                                                                            <asp:TemplateField HeaderText="Client">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientEditInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>                                                                                                   
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlClientFooterInsuranceCompaniesByClientProject" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:DropDownList ID="ddlClientFooterInsuranceCompaniesByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                            Width="100px" DataSourceID="odsClientFooterInsuranceCompaniesByClientProject" AutoPostBack="True" TabIndex="2"
                                                                                                                            DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooterInsuranceCompaniesByClientProject_SelectedIndexChanged">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvClientFooterInsuranceCompaniesByClientProject" runat="server" ControlToValidate="ddlClientFooterInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--5--%>
                                                                                            <asp:TemplateField HeaderText="Project">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectEditInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>                                                                                                            
                                                                                                            </td>
                                                                                                        </tr>                                                                                                    
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlProjectFooterInsuranceCompaniesByClientProject" runat="server">
                                                                                                                    <ContentTemplate>
                                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                            <tbody>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:DropDownList ID="ddlProjectFooterInsuranceCompaniesByClientProject" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                                                                            Width="140px" AutoPostBack="True">
                                                                                                                                        </asp:DropDownList>
                                                                                                                                    </td>
                                                                                                                                    <td style="vertical-align: middle">
                                                                                                                                        <asp:UpdateProgress ID="upProjectFooterInsuranceCompaniesByClientProject" runat="server" AssociatedUpdatePanelID="upnlClientFooterInsuranceCompaniesByClientProject">
                                                                                                                                            <ProgressTemplate>
                                                                                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                                                            </ProgressTemplate>
                                                                                                                                        </asp:UpdateProgress>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </tbody>
                                                                                                                        </table>
                                                                                                                    </ContentTemplate>
                                                                                                                    <Triggers>
                                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlClientFooterInsuranceCompaniesByClientProject" EventName="SelectedIndexChanged">
                                                                                                                        </asp:AsyncPostBackTrigger>
                                                                                                                    </Triggers>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvProjectFooterInsuranceCompaniesByClientProject" runat="server" ControlToValidate="ddlProjectFooterInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--6--%>
                                                                                            <asp:TemplateField HeaderText="InsuranceCompanies">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlInsuranceCompaniesEditInsuranceCompaniesByClientProject" runat="server" SkinID="DropDownListLookup" DataTextField="Name" 
                                                                                                                DataMember="DefaultView" DataValueField="COMPANIES_ID"
                                                                                                                    DataSourceID="odsInsuranceCompaniesListEditInsuranceCompaniesByClientProject"
                                                                                                                    Width="220px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvInsuranceCompaniesEditInsuranceCompaniesByClientProject" runat="server" ControlToValidate="ddlInsuranceCompaniesEditInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Insurance Company." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataEditInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlInsuranceCompaniesFooterInsuranceCompaniesByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                    Width="220px" DataSourceID="odsInsuranceCompaniesListFooterInsuranceCompaniesByClientProject"  TabIndex="2"
                                                                                                                    DataValueField="COMPANIES_ID" DataTextField="Name">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvInsuranceCompaniesFooterInsuranceCompaniesByClientProject" runat="server" ControlToValidate="ddlInsuranceCompaniesFooterInsuranceCompaniesByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Subcontractor." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataNewInsuranceCompaniesByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="220px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>                                                                                    
                                                                                            
                                                                                            <%--7--%>
                                                                                            <asp:TemplateField HeaderText="Rate">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateEditInsuranceCompaniesByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateEditInsuranceCompaniesByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateEditInsuranceCompaniesByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateEditInsuranceCompaniesByClientProject" ValidationGroup="DataEditInsuranceCompaniesByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateFooterInsuranceCompaniesByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateFooterInsuranceCompaniesByClientProject" runat="server" SkinID="TextBoxRight" Text="0.00"
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateFooterInsuranceCompaniesByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateFooterInsuranceCompaniesByClientProject" ValidationGroup="DataNewInsuranceCompaniesByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: right">
                                                                                                                <asp:Label ID="lblRateInsuranceCompaniesByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                    SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--8--%>
                                                                                            <asp:TemplateField HeaderText="Comments">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="tbxCommentEditInsuranceCompaniesByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                        Width="160px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentFooterInsuranceCompaniesByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblCommentInsuranceCompaniesByClientProject" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
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
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                        OnClientClick='return confirm("Are you sure you want to delete this InsuranceCompanies costs?");'>
                                                                                                                    </asp:ImageButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 30px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                                                                                    
                                                            <!-- Page element: DataObjects -->
                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ObjectDataSource ID="odsInsuranceCompaniesListEditInsuranceCompaniesByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesList">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="insuranceCompanyId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a Insurance Company)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsInsuranceCompaniesListFooterInsuranceCompaniesByClientProject" runat="server" CacheDuration="60" EnableCaching="True"
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesList">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="insuranceCompanyId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a Insurance Company)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsInsuranceCompaniesCostsInsuranceCompaniesByClientProject" runat="server" SelectMethod="GetInsuranceCompaniesDetailInsuranceCompaniesByClientProject"
                                                                            TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                            DeleteMethod="DummyInsuranceCompaniesDetail" FilterExpression="(Deleted = 0)"
                                                                            UpdateMethod="DummyInsuranceCompaniesDetail" InsertMethod="DummyInsuranceCompaniesDetail"
                                                                            OldValuesParameterFormatString="original_{0}">
                                                                            <DeleteParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </DeleteParameters>
                                                                            <UpdateParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </UpdateParameters>
                                                                            <InsertParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </InsertParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsClientFooterInsuranceCompaniesByClientProject" runat="server" SelectMethod="LoadAndAddItem"
                                                                            TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepOtherCostsByClientProject" runat="server" Title="OtherCostsByClientProject">
                                                        <div runat="server" id="dvOtherCostsByClientProject" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <!-- Page element: 1 column --> 
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOtherCosts" runat="server" SkinID="Label" Text="Other Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlSubcontractors" runat="server">
                                                                            <ContentTemplate>
                                                                               
                                                                                
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>                                                                
                                                            </table>
                                                            
                                                            
                                                             <%--Grid--%>                                                             
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Panel ID="pnlOtherCostsByClientProject" runat="server" Height="330px" Width="780px">
                                                                            <asp:UpdatePanel ID="upnlOtherCostsByClientProject" runat="server">
                                                                                <ContentTemplate>
                                                                                    <!-- Page element: 1 column - Grid Project Time -->
                                                                                    <asp:GridView ID="grdOtherCostsByClientProject" runat="server" SkinID="GridView" Width="780px"
                                                                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                                                        OnDataBound="grdOtherCostsByClientProject_DataBound" OnRowCommand="grdOtherCostsByClientProject_RowCommand"
                                                                                        OnRowUpdating="grdOtherCostsByClientProject_RowUpdating" OnRowEditing="grdOtherCostsByClientProject_RowEditing"
                                                                                        OnRowDeleting="grdOtherCostsByClientProject_RowDeleting" OnRowDataBound="grdOtherCostsByClientProject_RowDataBound"
                                                                                        DataKeyNames="ProjectID,RefID" DataSourceID="odsOtherCostsOtherByClientProject">
                                                                                        <Columns>
                                                                                        
                                                                                            <%--0--%>
                                                                                            <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdEditOtherByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblProjectIdOtherByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblProjectIdFooterOtherByClientProject" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--1--%>
                                                                                            <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdEditOtherByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRefIdOtherByClientProject" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                                                                            </asp:TemplateField>                                                                                                                                                                                        
                                                                                            
                                                                                            <%--3--%>
                                                                                            <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateEditOtherByClientProject" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>'
                                                                                                                    Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateEditOtherByClientProject" runat="server" ControlToValidate="tkrdpDateEditOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataEditOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpDateFooterOtherByClientProject" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDateFooterOtherByClientProject" runat="server" ControlToValidate="tkrdpDateFooterOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: center">
                                                                                                                <asp:Label ID="lblDateOtherByClientProject" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--4--%>
                                                                                            <asp:TemplateField HeaderText="Client">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientEditOtherByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>                                                                                                   
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlClientFooterOtherByClientProject" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:DropDownList ID="ddlClientFooterOtherByClientProject" runat="server" SkinID="DropDownListLookup"
                                                                                                                            Width="100px" DataSourceID="odsClientFooterOtherByClientProject" AutoPostBack="True" TabIndex="2"
                                                                                                                            DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooterOtherByClientProject_SelectedIndexChanged">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvClientFooterOtherByClientProject" runat="server" ControlToValidate="ddlClientFooterOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblClientOtherByClientProject" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            
                                                                                            <%--5--%>
                                                                                            <asp:TemplateField HeaderText="Project">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectEditOtherByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>                                                                                                            
                                                                                                            </td>
                                                                                                        </tr>                                                                                                    
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlProjectFooterOtherByClientProject" runat="server">
                                                                                                                    <ContentTemplate>
                                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                                            <tbody>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        <asp:DropDownList ID="ddlProjectFooterOtherByClientProject" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                                                                            Width="140px" AutoPostBack="True">
                                                                                                                                        </asp:DropDownList>
                                                                                                                                    </td>
                                                                                                                                    <td style="vertical-align: middle">
                                                                                                                                        <asp:UpdateProgress ID="upProjectFooterOtherByClientProject" runat="server" AssociatedUpdatePanelID="upnlClientFooterOtherByClientProject">
                                                                                                                                            <ProgressTemplate>
                                                                                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                                                                            </ProgressTemplate>
                                                                                                                                        </asp:UpdateProgress>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </tbody>
                                                                                                                        </table>
                                                                                                                    </ContentTemplate>
                                                                                                                    <Triggers>
                                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlClientFooterOtherByClientProject" EventName="SelectedIndexChanged">
                                                                                                                        </asp:AsyncPostBackTrigger>
                                                                                                                    </Triggers>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvProjectFooterOtherByClientProject" runat="server" ControlToValidate="ddlProjectFooterOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                                                                    ValidationGroup="DataNewOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProjectOtherByClientProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--6--%>
                                                                                            <asp:TemplateField HeaderText="Category">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>                                                                                                                                                                                                                                
                                                                                                                <asp:DropDownList ID="ddlCategoryEditOtherByClientProject" runat="server"
                                                                                                                    SkinID="DropDownList" Width="210px"   EnableViewState="true">
                                                                                                                    <asp:ListItem Value="-1" Text="(Select a category)"></asp:ListItem>                                                                                                                    
                                                                                                                    <asp:ListItem Value="Rentals" Text="Rentals"></asp:ListItem>                                                                                                                                                                                                                                        
                                                                                                                    <asp:ListItem Value="Fuel" Text="Fuel"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Traffic Control" Text="Traffic Control"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Permits" Text="Permits"></asp:ListItem>                                                                                                                    
                                                                                                                    <asp:ListItem Value="Meals" Text="Meals"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCategoryEditOtherByClientProject" runat="server" ControlToValidate="ddlCategoryEditOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Category." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataEditOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>                                                                                                                
                                                                                                                <asp:DropDownList ID="ddlCategoryFooterOtherByClientProject" runat="server"
                                                                                                                    SkinID="DropDownList" Width="210px"  EnableViewState="true">
                                                                                                                    <asp:ListItem Value="-1" Text="(Select a category)"></asp:ListItem>                                                                                                                    
                                                                                                                    <asp:ListItem Value="Rentals" Text="Rentals"></asp:ListItem>                                                                                                                                                                                                                                        
                                                                                                                    <asp:ListItem Value="Fuel" Text="Fuel"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Traffic Control" Text="Traffic Control"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Permits" Text="Permits"></asp:ListItem>                                                                                                                    
                                                                                                                    <asp:ListItem Value="Meals" Text="Meals"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCategoryFooterOtherByClientProject" runat="server" ControlToValidate="ddlCategoryFooterOtherByClientProject"
                                                                                                                    Display="Dynamic" ErrorMessage="Please select a Category." InitialValue="-1"
                                                                                                                    SkinID="Validator" ValidationGroup="DataNewOtherByClientProject" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="220px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblCategoryOtherByClientProject" runat="server" Text='<%# Eval("Name") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>                                                                                    
                                                                                            
                                                                                            <%--7--%>
                                                                                            <asp:TemplateField HeaderText="Rate">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateEditOtherByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateEditOtherByClientProject" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateEditOtherByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateEditOtherByClientProject" ValidationGroup="DataEditOtherByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:UpdatePanel ID="upnlRateFooterOtherByClientProject" runat="server" UpdateMode="Always">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:TextBox ID="tbxRateFooterOtherByClientProject" runat="server" SkinID="TextBoxRight" Text="0.00"
                                                                                                                            Width="60px"></asp:TextBox>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvRateFooterOtherByClientProject" runat="server" Operator="DataTypeCheck"
                                                                                                                    Type="Currency" ControlToValidate="tbxRateFooterOtherByClientProject" ValidationGroup="DataNewOtherByClientProject"
                                                                                                                    SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="text-align: right">
                                                                                                                <asp:Label ID="lblRateOtherByClientProject" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                                                                    SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                                                                                                   
                                                                                            <%--8--%>
                                                                                            <asp:TemplateField HeaderText="Comments">
                                                                                                <EditItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="tbxCommentEditOtherByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                        Width="160px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </EditItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentFooterOtherByClientProject" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                                                    Width="160px"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 10px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblCommentOtherByClientProject" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
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
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
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
                                                                                                                        OnClientClick='return confirm("Are you sure you want to delete this Other costs?");'>
                                                                                                                    </asp:ImageButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 30px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                                                                                    
                                                            <!-- Page element: DataObjects -->
                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
                                                                <tr>
                                                                    <td>                                                                                                                                                
                                                                        <asp:ObjectDataSource ID="odsOtherCostsOtherByClientProject" runat="server" SelectMethod="GetOtherDetailOtherByClientProject"
                                                                            TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.actual_costs_add"
                                                                            DeleteMethod="DummyOtherDetail" FilterExpression="(Deleted = 0)"
                                                                            UpdateMethod="DummyOtherDetail" InsertMethod="DummyOtherDetail"
                                                                            OldValuesParameterFormatString="original_{0}">
                                                                            <DeleteParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </DeleteParameters>
                                                                            <UpdateParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </UpdateParameters>
                                                                            <InsertParameters>
                                                                                <asp:Parameter Name="ProjectID" Type="Int32" />
                                                                                <asp:Parameter Name="RefID" Type="Int32" />
                                                                            </InsertParameters>
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsClientFooterOtherByClientProject" runat="server" SelectMethod="LoadAndAddItem"
                                                                            TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>                                                                                                                                                            
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                                        <!-- Page element: Summary -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="930px" ReadOnly="True"
                                                                        SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                                                                                                                                                                              
                                                </WizardSteps>
                                            </asp:Wizard>
                                        </td>
                                        <td style="vertical-align: bottom; width: 30px">
                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlProject">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />                                                       
                    <asp:HiddenField ID="hdfNextStep" runat="server" />                                   
                  </td>  
            </tr>
        </table>        
                   
        <!-- Page element: DataObjects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td>                   
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>