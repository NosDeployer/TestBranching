<%@ Page Title="" Language="C#" MasterPageFile="~/mReportForM12.Master" AutoEventWireup="true" CodeBehind="fl_m12_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_m12_report" %>

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
            
            if (src.id != "ctl00_ContentPlaceHolder1_cbxlSectionId_0") {
			
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
    
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblReport" runat="server" Text="Report" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxM1Report" runat="server" Text="M1 Report" SkinID="CheckBox" Checked="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxM2Report" runat="server" Text="M2 Report" SkinID="CheckBox" Checked="true" />
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" Text="Client" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:dropdownlist id="ddlClient" SkinID="DropDownList" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
				            </asp:dropdownlist>
				        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" Text="Project" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="ddlProject" SkinID="DropDownList" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imAjax" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
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
                    <asp:CheckBox ID="cbxSectionId" runat="server" SkinID="CheckBox" Text="Section ID" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlSectionId" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 156px">
                                            <asp:Panel ID="pnlSectionId" Width="156px" Height="88px" runat="server" SkinID="Panel">
                                                <asp:CheckBoxList ID="cbxlSectionId" runat="server" SkinID="CheckBoxListWithoutBorder" onclick="return cbxSelectedClick(event);">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress ID="upSectionId" runat="server" AssociatedUpdatePanelID="upnlProject">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imAjaxSectionId" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
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
                    <asp:CheckBox ID="cbxDate" runat="server" SkinID="CheckBox" Text="Date" />
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxStreet" runat="server" SkinID="CheckBox" Text="Street" /></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxStreet" runat="server" SkinID="TextBox" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxSubArea" runat="server" SkinID="CheckBox" Text="Sub Area" /></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxSubArea" runat="server" SkinID="TextBox" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUnitType" runat="server" Text="Print on" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:dropdownlist id="ddlUnitType" SkinID="DropDownList" runat="server" Width="160px">
				        <asp:ListItem Text="Imperial" Value="Imperial" Selected="True"></asp:ListItem>
				        <asp:ListItem Text="Metric" Value="Metric"></asp:ListItem>				        
				    </asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvCriteria" runat="server" Display="Dynamic"
                        EnableViewState="False" ErrorMessage="You can select only one option." 
                        OnServerValidate="cvCriteria_ServerValidate" SkinID="Validator" ValidateEmptyText="True" ></asp:CustomValidator>
                </td>
            </tr>            
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>