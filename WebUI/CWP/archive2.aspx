<%@ Page language="c#" Codebehind="archive2.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.archive2" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>archive2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR bgColor="#c8dbed" height="30">
					<TD width="40">&nbsp;</TD>
					<TD width="40">&nbsp;</TD>
					<TD width="820">&nbsp;</TD>
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
					<td vAlign="top">
						<!-- Custom: Header -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:label id="lblDialogTitle" runat="server" CssClass="tDialogTitle" Font-Bold="True">Archive Tool</asp:label></td>
							</tr>
							<tr>
								<td>
									<hr width="100%" color="#c8dbed" SIZE="2">
								</td>
							</tr>
						</table>
						<br>
						<!-- Custom: Search -->
						<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 86px; HEIGHT: 13px" vAlign="middle" width="86">
									<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" >Search 
										By</DIV>
								</TD>
								<TD style="WIDTH: 250px; HEIGHT: 13px" vAlign="middle" width="250">
									<asp:dropdownlist id="ddlSearch" tabIndex="1" runat="server" CssClass="tTextField" AutoPostBack="True"
										Width="240px" onselectedindexchanged="ddlSearch_SelectedIndexChanged">
										<asp:ListItem Value="ID#">ID#</asp:ListItem>
										<asp:ListItem Value="Client">Client</asp:ListItem>
										<asp:ListItem Value="USMH">USMH</asp:ListItem>
										<asp:ListItem Value="DSMH">DSMH</asp:ListItem>
										<asp:ListItem Value="Street">Street</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 13px" vAlign="middle" width="100"></TD>
								<TD style="HEIGHT: 13px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
									<asp:textbox id="tbxSearch" tabIndex="2" runat="server" CssClass="tTextField" Width="240px"></asp:textbox></TD>
								<TD vAlign="middle" width="100">
									<asp:button id="btnSubmit" tabIndex="3" runat="server" CssClass="tButtonOkCancel" Width="100px"
										Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
								<TD width="100"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
									<asp:label id="lblHint" runat="server" CssClass="tLabel">Type '%' to get all records</asp:label></TD>
								<TD width="100"></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<br>
						<!-- Custom: Results -->
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE height="28" cellSpacing="0" cellPadding="0" width="100%" bgColor="#c8dbed" border="0">
										<TR>
											<TD width="700" height="28">
												<asp:Label id="Label1" runat="server" BackColor="#C8DBED" Font-Bold="True" ForeColor="#2F82C7">Search Results</asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<br>
						<!-- Custom: Results grid -->
						<TABLE cellspacing="0" cellpadding="0" width="100%" border="0">						    							
							<tr>
								<td>								
								    <asp:Panel ID="pnlArchive2" runat="server" Width="617px" Height="300px" ScrollBars="Auto">			        							                                        
                                        <asp:GridView ID="grdArchive2" runat="server" SkinID="GridView" Width="600px"
                                        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="odsArchive"
                                        OnDataBound="grdArchive2_DataBound"  >
                                            <Columns>                                                        
                                                <asp:TemplateField HeaderText="ID" Visible ="False">                                                                                                          
                                                    <ItemTemplate>                
                                                        <asp:Label ID="lblId" runat="server" SkinID="Label" Text='<%# Eval("ID") %>'></asp:Label>                                                                               
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                            
                                                
                                                <asp:TemplateField HeaderText="COMPANY_ID" Visible ="False">
                                                    <ItemTemplate>                                                                        
                                                        <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>                                                                                
                                                    </ItemTemplate>                                                                    
                                                </asp:TemplateField>                                   
                                                
                                                <asp:TemplateField HeaderText="COMPANIES_ID" Visible ="False">
                                                    <ItemTemplate>                                                                        
                                                        <asp:Label ID="lblCompaniesId" runat="server" SkinID="Label" Text='<%# Eval("COMPANIES_ID") %>'></asp:Label>                                                                                
                                                    </ItemTemplate>                                                                    
                                                </asp:TemplateField>
                                                    
                                                <asp:TemplateField>
                                                    <ItemStyle HorizontalAlign="Center" />                            
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                            Checked='<%# Bind("Selected") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                                                                                                                                
                                                <asp:TemplateField HeaderText="ID#">                                  
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblRecordID" runat="server" SkinID="Label" Text='<%# Eval("RecordID") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Client">                                               
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("NAME") %>' SkinID="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Street">                                               
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblStreet" runat="server" SkinID="Label" Text='<%# Eval("Street") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="USMH">                                               
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr  style="text-align: center;">
                                                                    <td>
                                                                        <asp:Label ID="lblUSMH" runat="server" SkinID="Label" Text='<%# Eval("USMH") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="DSMH">                                               
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr  style="text-align: center;">
                                                                    <td>
                                                                        <asp:Label ID="lblDSMH" runat="server" SkinID="Label" Text='<%# Eval("DSMH") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Archived">                                               
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr style="text-align: center;">
                                                                    <td>
                                                                        <asp:CheckBox ID="cbxArchived" runat="server"  Checked='<%# Bind("Archived") %>' />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                        </asp:GridView>
							        </asp:Panel>
								</TD>
								<TD vAlign="top">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="90" border="0">
										<TR>
											<TD align="center"><asp:button id="btnArchive" tabIndex="5" runat="server" CssClass="tButtonOkCancel" Width="80px"
													Text="Archive" onclick="btnArchive_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD style="heigth: 7px"></TD>
										</TR>
										<TR>
											<TD align="center"><asp:button id="btnUnarchive" tabIndex="5" runat="server" CssClass="tButtonOkCancel" Width="80px"
													Text="Unarchive" onclick="btnUnarchive_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD style="heigth: 7px"></TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<br/>
						<br/>
					</td>
					<td></td>
				</tr>
			</TABLE>
            
            
            <!-- Page element: Data objects -->
            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsArchive" runat="server" 
                         SelectMethod="GetArchiveNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.archive2" >                            
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>               
            
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
