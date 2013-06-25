<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="print_hours_for_payroll_period.aspx.cs" 
Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_hours_for_payroll_period" Title="LFS Live"  %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
 
        function cbxSelectedClick(evt){
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var parentTagName = "table"
            var parent = src.parentNode;
			
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            			
            var allSelect = true;
            
            var childChkBoxes = parent.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            
            if (src.id != "ctl00_ContentPlaceHolder1_cbxlEmployee_0") {
			
				for (i = 1; i < childChkBoxCount; i++) {
					if (childChkBoxes[i].type == "checkbox") {
						if (childChkBoxes[i].checked != true) 
							allSelect = false;
					}
				}
				
				if (allSelect == true) {
					childChkBoxes[0].checked = true;
				}
				else {
					childChkBoxes[0].checked = false;
				}
			}
			else	
			{
				if (childChkBoxes[0].checked == true) {
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = true;
						}
					}
				}
				else	
				{
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = false;
						}
					}
				}
			}
        }
    </script>
        
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
             <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" SkinID="Label" Text="Select Country" EnableViewState="False"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" SkinID="DropDownList" Width="160px" DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                        Display="Dynamic" ErrorMessage="Please select a country."
                        InitialValue="-1" SkinID="Validator">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectTimeState" runat="server" SkinID="Label" Text="Select Project Time State" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProjectTimeState" runat="server" SkinID="DropDownList" Width="160px" EnableViewState="False">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Unapproved">For Approval</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:Label ID="lblEmployee" runat="server" SkinID="Label" Text="Select Team Member" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlEmployee" runat="server">
                        <ContentTemplate>
                            <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
                                <TBODY>
                                    <TR>
                                        <TD style="WIDTH: 160px">
                                            <asp:Panel ID="pnlEmployee" Width="156px" Height="88px" runat="server" SkinID="Panel">
                                                <asp:CheckBoxList ID="cbxlEmployee" runat="server" DataSourceID="odsEmployee" DataTextField="FullName" DataValueField="EmployeeID" 
                                                    SkinID="CheckBoxListWithoutBorder" onclick="return cbxSelectedClick(event);">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </TD>
                                        <TD style="VERTICAL-ALIGN: middle">
                                            <asp:UpdateProgress id="upEmployee" runat="server" AssociatedUpdatePanelID="upnlEmployee">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </TD>
                                    </TR>
                                </TBODY>
                            </TABLE>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cbxEmployeeState" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>                                      
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeType" runat="server" SkinID="Label" Text="Select Team Member Type" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlEmployeeType" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlEmployeeType" runat="server" SkinID="DropDownList" Width="160px" EnableViewState="False"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeType_SelectedIndexChanged">
                                <asp:ListItem Value="(All)">(All)</asp:ListItem>
                                <asp:ListItem Value="LFSCA">LFS Canada</asp:ListItem>
                                <asp:ListItem Value="LFSUS">LFS USA</asp:ListItem>
                                <asp:ListItem Value="LFS">All LFS</asp:ListItem>
                                <asp:ListItem Value="PAGCA">PAG Canada</asp:ListItem>
                                <asp:ListItem Value="PAGUS">PAG USA</asp:ListItem>
                                <asp:ListItem Value="PAG">All PAG</asp:ListItem>
                                <asp:ListItem Value="SOTA">SOTA</asp:ListItem>
                                <asp:ListItem Value="Salaried">Salaried</asp:ListItem>
                                <asp:ListItem Value="Subcontractor">Subcontractor</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>                       
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
            
        <asp:UpdatePanel ID="upnlPersonnelAgency" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlPersonnelAgency" runat="server" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblPersonnelAgency" runat="server" EnableViewState="False" SkinID="Label"
                                    Text="Personnel Agency"></asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:UpdateProgress id="upPersonnelAgency" runat="server" AssociatedUpdatePanelID="upnlEmployeeType">
                                    <ProgressTemplate>
                                        <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlPersonalAgency" runat="server" DataSourceID="odsPersonalAgency" DataTextField="PersonalAgencyName"
                                    DataValueField="PersonalAgencyName" SkinID="DropDownListLookup" Width="160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlEmployeeType" EventName="SelectedIndexChanged">
                </asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeState" runat="server" SkinID="Label" Text="Show no longer employees?" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxEmployeeState" runat="server" SkinID="CheckBox" Checked="false" AutoPostBack="True" OnCheckedChanged="cbxEmployeeState_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Select Client" EnableViewState="False"></asp:Label>
                </td>
            </tr>       
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>                        
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" DataMember="DefaultView"
                                DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                SkinID="DropDownListLookup" Width="160px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Select Project" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 160px"><asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" DataValueField="ProjectID" DataTextField="NAME" DataSourceID="odsProject" Width="160px" DataMember="DefaultView" AutoPostBack="True">
                                            </asp:DropDownList> </TD><TD style="VERTICAL-ALIGN: middle"><asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress> </TD></TR></TBODY></TABLE>
</ContentTemplate>
                        <Triggers>
<asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                    </asp:UpdatePanel> 
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>            
        </table>
        
        
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadBySalariedStateAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="salaried" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="fullName" Type="String" />
                            <asp:Parameter DefaultValue="Active" Name="state" Type="String" />                            
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCountry" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a country)" Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsPersonalAgency" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.PersonalAgencyList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="personalAgencyName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>