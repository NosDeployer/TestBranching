<%@ Page language="c#" Codebehind="id_lookup.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.id_lookup" %>
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
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitle">ID Lookup</asp:label>
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
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 168px" >
										<asp:Label id="lblLastID" style="Z-INDEX: 108; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
											CssClass="tLabel"> Last ID Lookup For</asp:Label>
										<asp:DropDownList id="ddlLastID" style="Z-INDEX: 108; LEFT: 0px; POSITION: absolute; TOP: 24px" runat="server"
											Width="222px" tabIndex="1" AutoPostBack="True" CssClass="tTextField" onselectedindexchanged="ddlLastID_SelectedIndexChanged">
											<asp:ListItem></asp:ListItem>
                                            <asp:ListItem>2007</asp:ListItem>
										</asp:DropDownList>
										<asp:TextBox id="tbxRecordID" style="Z-INDEX: 107; LEFT: 0px; POSITION: absolute; TOP: 64px"
											runat="server" Width="161px" tabIndex="2" CssClass="tTextField"></asp:TextBox>
										<INPUT id="hbtnOK" style="Z-INDEX: 106; LEFT: 0px; WIDTH: 80px; POSITION: absolute; TOP: 128px; HEIGHT: 22px"
											type="button" value="OK" onclick="window.close();" tabIndex="3" class="tButtonOkCancel"></DIV>
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
		<script>window.document.all["ddlLastID"].focus()</script>
	</body>
</HTML>
