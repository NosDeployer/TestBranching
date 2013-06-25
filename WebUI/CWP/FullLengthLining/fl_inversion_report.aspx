<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="./../../mReport1.Master" CodeBehind="fl_inversion_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_inversion_report" %>

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
                    <asp:CheckBox ID="cbxSectionId" runat="server" SkinID="CheckBox" Enabled="false" Text="Section ID" />
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