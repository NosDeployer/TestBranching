<%@ Page language="c#" Codebehind="script_runner.aspx.cs" AutoEventWireup="True" Inherits="LFS.Tools.script_runner" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>script_runner</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 32px; POSITION: absolute; TOP: 32px" runat="server"
				Font-Size="Large" Font-Bold="True">Script runner</asp:Label>
			<asp:Button id="btnExecuteDll" style="Z-INDEX: 109; LEFT: 576px; POSITION: absolute; TOP: 320px"
				runat="server" Text="DDL" Width="161px" onclick="btnExecuteDll_Click"></asp:Button>
			<asp:Button id="btnExecuteReader" style="Z-INDEX: 108; LEFT: 120px; POSITION: absolute; TOP: 320px"
				runat="server" Width="161px" Text="Select" onclick="btnExecuteReader_Click"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 106; LEFT: 56px; POSITION: absolute; TOP: 368px" runat="server"
				Font-Bold="True">Results :</asp:Label>
			<asp:TextBox id="script" style="Z-INDEX: 101; LEFT: 120px; POSITION: absolute; TOP: 80px" runat="server"
				TextMode="MultiLine" Width="904px" Height="232px"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 56px; POSITION: absolute; TOP: 80px" runat="server"
				Font-Bold="True">Script :</asp:Label>
			<asp:Button id="btnExecuteNonQuery" style="Z-INDEX: 103; LEFT: 320px; POSITION: absolute; TOP: 320px"
				runat="server" Width="216px" Text="Insert / Update / Delete" onclick="btnExecuteNonQuery_Click"></asp:Button>
			<asp:TextBox id="results" style="Z-INDEX: 105; LEFT: 120px; POSITION: absolute; TOP: 368px" runat="server"
				TextMode="MultiLine" Width="904px" Height="264px"></asp:TextBox>
			<asp:Button id="btnClear" style="Z-INDEX: 107; LEFT: 968px; POSITION: absolute; TOP: 320px"
				runat="server" Width="56px" Text="Clear" onclick="btnClear_Click"></asp:Button>
		</form>
	</body>
</HTML>
