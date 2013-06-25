<%@ Page language="c#" Codebehind="print_for_lining_completed.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.print_for_lining_completed" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="./../common/images/lfcss.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0">
				<TR height="30" bgColor="#c8dbed">
					<TD width="40">&nbsp;</TD>
					<TD width="40">&nbsp;</TD>
					<TD width="430">&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<tr height="30">
					<td bgColor="#c8dbed"></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td bgColor="#c8dbed"></td>
					<td></td>
					<!-- PAGE -->
					<td valign="top">
						<!-- HEADER -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitle">Lining Completed</asp:label>
								</td>
							</tr>
							<tr>
								<td>
									<hr width="100%" size="2" color="#c8dbed">
								</td>
							</tr>
						</table>
						<!-- DATA -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table1">
							<tr>
								<td>
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 216px" >
										<asp:label id="lblSelectAClient" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px"
											runat="server" CssClass="tLabel"> Select Client</asp:label><asp:dropdownlist id="ddlSelectAClient" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 24px"
											tabIndex="1" runat="server" Width="250px" CssClass="tTextField"></asp:dropdownlist>
										<INPUT id="hbtnCancel" style="Z-INDEX: 100; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 184px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="6" type="button" value="Close" class="tButtonOkCancel">
										<asp:Label id="lblStartDate" style="Z-INDEX: 111; LEFT: 0px; POSITION: absolute; TOP: 56px"
											runat="server" CssClass="tLabel"> Start Date</asp:Label>
										<asp:TextBox id="tbxStartDate" style="Z-INDEX: 110; LEFT: 0px; POSITION: absolute; TOP: 72px"
											runat="server" Width="100px" tabIndex="2" CssClass="tTextField"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvStartDate" style="Z-INDEX: 107; LEFT: 112px; POSITION: absolute; TOP: 78px"
											runat="server" ErrorMessage="Type a date" ControlToValidate="tbxStartDate" Font-Size="Smaller" Display="Dynamic"
											EnableViewState="False"></asp:RequiredFieldValidator>
										<asp:customvalidator id="cvStartDate" style="Z-INDEX: 105; LEFT: 112px; POSITION: absolute; TOP: 78px"
											runat="server" ErrorMessage="Invalid date" ControlToValidate="tbxStartDate" Font-Size="Smaller" Display="Dynamic"
											EnableViewState="False"></asp:customvalidator>
										<asp:Label id="lblEndDate" style="Z-INDEX: 106; LEFT: 0px; POSITION: absolute; TOP: 104px"
											runat="server" CssClass="tLabel">End Date</asp:Label>
										<asp:TextBox id="tbxEndDate" style="Z-INDEX: 108; LEFT: 0px; POSITION: absolute; TOP: 120px"
											runat="server" Width="100px" tabIndex="3" CssClass="tTextField"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvEndDate" style="Z-INDEX: 109; LEFT: 112px; POSITION: absolute; TOP: 126px"
											runat="server" ErrorMessage="Type a date" ControlToValidate="tbxEndDate" Font-Size="Smaller" Display="Dynamic"
											EnableViewState="False"></asp:RequiredFieldValidator>
										<asp:customvalidator id="cvEndDate" style="Z-INDEX: 104; LEFT: 112px; POSITION: absolute; TOP: 126px"
											runat="server" ErrorMessage="Invalid date" ControlToValidate="tbxEndDate" Font-Size="Smaller" Display="Dynamic"
											EnableViewState="False"></asp:customvalidator>
										<asp:button id="btnPreview" style="Z-INDEX: 112; LEFT: 0px; POSITION: absolute; TOP: 184px"
											tabIndex="4" runat="server" CssClass="tButtonOkCancel" Width="80px" Height="22px" Text="Preview" onclick="btnPreview_Click"></asp:button>
										<asp:button id="btnExport" style="Z-INDEX: 113; LEFT: 88px; POSITION: absolute; TOP: 184px"
											tabIndex="5" runat="server" CssClass="tButtonOkCancel" Width="80px" Height="22px" Text="Export" onclick="btnExport_Click"></asp:button></DIV>
								</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</TABLE>
            <!-- Page element:  refresh iFrame-->
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td>
                        <iframe id="iframe1" frameborder="0" height="0" width="0" src="./../refresh_iframe.aspx">
                            Your web browser don't accept iFrame tag. Contact with your Administrator. </iframe>
                    </td>
                </tr>
            </table>
			
		</form>
		<!--- Inline scripts --->
		<script>window.document.all["ddlSelectAClient"].focus()</script>
	</body>
</HTML>
