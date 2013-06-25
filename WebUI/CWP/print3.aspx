<%@ Page language="c#" Codebehind="print3.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.print3" %>
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
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitle"></asp:label>
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
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 256px">
										<INPUT id="hbtnCancel" style="Z-INDEX: 102; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 224px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="7" type="button" value="Close" class="tButtonOkCancel">
										<asp:TextBox id="tbxRecordID" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 32px"
											runat="server" Width="100px" tabIndex="2" CssClass="tTextField"></asp:TextBox>
										<asp:customvalidator id="cvRecordID" style="Z-INDEX: 103; LEFT: 128px; POSITION: absolute; TOP: 32px"
											runat="server" ErrorMessage="ID# not found, please type another." ControlToValidate="tbxRecordID"
											Font-Size="Smaller" Display="Dynamic"></asp:customvalidator>
										<asp:button id="btnPreview" style="Z-INDEX: 104; LEFT: 0px; POSITION: absolute; TOP: 224px"
											tabIndex="5" runat="server" CssClass="tButtonOkCancel" Height="22px" Text="Preview" Width="80px" onclick="btnPreview_Click"></asp:button>
										<asp:button id="btnExport" style="Z-INDEX: 105; LEFT: 88px; POSITION: absolute; TOP: 224px"
											tabIndex="6" runat="server" CssClass="tButtonOkCancel" Height="22px" Text="Export" Width="80px" onclick="btnExport_Click"></asp:button>
										<asp:RadioButton id="rbtnRecordID" style="Z-INDEX: 106; LEFT: 0px; POSITION: absolute; TOP: 8px"
											runat="server" CssClass="tLabel" Text="ID#" Height="16px" GroupName="print3" AutoPostBack="True"
											tabIndex="1" Checked="True"></asp:RadioButton>
										<asp:RadioButton id="rbtnClient" style="Z-INDEX: 107; LEFT: 0px; POSITION: absolute; TOP: 64px" runat="server"
											CssClass="tLabel" Text="Client" Height="16px" GroupName="print3" AutoPostBack="True" tabIndex="3"></asp:RadioButton>
										<asp:dropdownlist id="ddlSelectAClient" style="Z-INDEX: 108; LEFT: 20px; POSITION: absolute; TOP: 88px"
											tabIndex="4" runat="server" CssClass="tTextField" Width="250px"></asp:dropdownlist>
										<asp:Label id="lblRecordID" style="Z-INDEX: 109; LEFT: 128px; POSITION: absolute; TOP: 32px"
											runat="server" Font-Size="Smaller" ForeColor="Red">Type an ID#</asp:Label>
										<asp:RadioButton id="rbtnDate" style="Z-INDEX: 110; LEFT: 0px; POSITION: absolute; TOP: 120px" tabIndex="5"
											runat="server" CssClass="tLabel" Text="Date" Height="16px" AutoPostBack="True" GroupName="print3"></asp:RadioButton>
										<asp:textbox id="tbxDate" style="Z-INDEX: 111; LEFT: 20px; POSITION: absolute; TOP: 144px" tabIndex="6"
											runat="server" CssClass="tTextField" Width="100px"></asp:textbox>
										<asp:customvalidator id="cvDate" style="Z-INDEX: 113; LEFT: 128px; POSITION: absolute; TOP: 144px" runat="server"
											Display="Dynamic" Font-Size="Smaller" ControlToValidate="tbxDate" ErrorMessage="Invalid date" EnableViewState="False"></asp:customvalidator></DIV>
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
	</body>
</HTML>
