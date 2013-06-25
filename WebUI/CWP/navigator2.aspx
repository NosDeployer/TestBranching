<%@ Page language="c#" Codebehind="navigator2.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.navigator2" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server"> <!-- onsubmit="__doPostBack('btnSubmit','');" -->
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<!-- PAGE -->
					<TD vAlign="top" width="900">
						<DIV><!-- Page element: Header -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header1.gif" height="50">&nbsp;</TD>
									<TD width="100" background="./../common/images/im_header2.gif" height="50"></TD>
									<TD width="100" background="./../common/images/im_header3.gif" height="50">
										<TABLE height="50" cellSpacing="0" cellPadding="0" width="100" border="0">
											<TR>
												<TD width="85" height="4"></TD>
												<TD width="15" rowSpan="3"></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CssClass="tMainLink" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><A class="tmainlinkorange" tabIndex="100" href="./../default.aspx">Menu</A>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: Header buttons -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header4.gif" height="28">&nbsp;</TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28"></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28"></TD>
								</TR>
							</TABLE>
							<BR> <!-- Page element: Title with horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:label id="lblTitle" runat="server" CssClass="tTitle" Font-Size="Large" EnableViewState="False"> Navigator</asp:label></TD>
								</TR>
								<TR>
									<TD>
										<TABLE height="5" cellSpacing="0" cellPadding="0" width="900" border="0">
											<TR>
												<TD><IMG height="5" src="./../common/images/im_backrowblue.gif" width="900"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<BR> <!-- Page element: Custom [search] -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV>
											<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD style="WIDTH: 86px; HEIGHT: 23px" vAlign="middle" width="86">
														<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" >Search 
															By</DIV>
													</TD>
													<TD style="WIDTH: 250px; HEIGHT: 23px" vAlign="middle" width="250"><asp:dropdownlist id="ddlSearch" tabIndex="1" runat="server" CssClass="tTextField" AutoPostBack="True"
															Width="240px" onselectedindexchanged="ddlSearch_SelectedIndexChanged">
															<asp:ListItem Value="ID#">ID#</asp:ListItem>
															<asp:ListItem Value="Client">Client</asp:ListItem>
															<asp:ListItem Value="USMH">USMH</asp:ListItem>
															<asp:ListItem Value="DSMH">DSMH</asp:ListItem>
															<asp:ListItem Value="P1 Date">P1 Date</asp:ListItem>
															<asp:ListItem Value="M1 Date">M1 Date</asp:ListItem>
															<asp:ListItem Value="M2 Date">M2 Date</asp:ListItem>
															<asp:ListItem Value="Install Date">Install Date</asp:ListItem>
															<asp:ListItem Value="Street">Street</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="HEIGHT: 23px" vAlign="middle" width="100"></TD>
													<TD style="HEIGHT: 23px"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:textbox id="tbxSearch" tabIndex="2" runat="server" CssClass="tTextField" Width="240px"></asp:textbox></TD>
													<TD vAlign="middle" width="100"><asp:button id="btnSubmit" tabIndex="3" runat="server" CssClass="tButtonOkCancel" Width="100px"
															Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:customvalidator id="cvSearch" runat="server" Font-Size="Smaller" EnableViewState="False" ControlToValidate="tbxSearch"
															Display="Dynamic" ValidationGroup="submitText"></asp:customvalidator>
													<TD width="100"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:label id="lblHint" runat="server" CssClass="tLabel">Type '%' to get all records</asp:label></TD>
													<TD width="100"></TD>
													<TD></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
							 
							
					        <!-- Page element : Horizontal Rule -->
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 2px" class="Background_Separator">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                            </table>
							
							<!-- Page element: Section title - Results-->
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                            </table>
                            
                            <!-- Page element: Results -->
                            <table border="0" cellpadding="0" cellspacing="0" style="width: =900px">
                                <tr>
                                    <td style="width: 775px">
                                        <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one or more sections"
                                            Display="Dynamic" SkinID="Validator" OnServerValidate="cvSelection_ServerValidate" ValidationGroup="resultsGrid"></asp:CustomValidator>
                                    </td>
                                    <td style="width: 125px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 625px">
                                    </td>
                                    <td style="width: 125px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label"
                                            Text="Total Rows"></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        <asp:Panel ID="pnlNavigator" runat="server" Width="775px" Height="600px" ScrollBars="Auto">
                                            <asp:GridView ID="grdCWPNavigator" runat="server" AutoGenerateColumns="False" 
                                             DataKeyNames="ID,COMPANY_ID" SkinID="GridView" DataSourceID="odsNavigator" OnDataBound="grdCWPNavigator_DataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                                Checked='<%# Bind("Selected") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="ID" Visible ="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Style="width: 100px" Text='<%# Bind("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="CompanyID" Visible ="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompanyId" runat="server" Style="width: 100px" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="CompaniesID" Visible ="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompaniesId" runat="server" Style="width: 100px" Text='<%# Bind("COMPANIES_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    
                                                    
                                                    <asp:TemplateField HeaderText="ID#">
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRecordId" runat="server" Style="width: 100px" Text='<%# Bind("RecordID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Client">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Style="width: 150px" Text='<%# Bind("NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Street">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStreet" runat="server" Style="width: 150px" Text='<%# Bind("Street") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                                                                      
                                                    
                                                    <asp:TemplateField HeaderText="USMH">
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUSMH" runat="server" Style="width: 100px" Text='<%# Bind("USMH") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="DSMH">
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDSMH" runat="server" Style="width: 100px" Text='<%# Bind("DSMH") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="P1 Date">
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblP1Date" runat="server" Style="width: 100px" Text='<%# Bind("P1Date", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="M1 Date">
                                                        <ItemStyle HorizontalAlign="Center" />                            
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblM1DateDate" runat="server" Style="width: 100px" Text='<%# Bind("M1Date", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="M2 Date">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblM2Date" runat="server" Style="width: 100px" Text='<%# Bind("M2Date", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Install Date">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInstallDate" runat="server" Style="width: 100px" Text='<%# Bind("InstallDate", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                        
                                                </Columns>
                                            </asp:GridView>                    
                                        </asp:Panel> 
                                    </td>
                                    <td style="vertical-align: top">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                                            <!-- Page element : Buttons -->
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnView" runat="server" EnableViewState="False" SkinID="Button" Text="View"
                                                    Style="width: 80px" OnClick="btnView_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                                        Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td style="height: 7px">
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!-- Page element : Footer separation -->
                            <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
                                <tr>
                                    <td style="height: 60px">
                                    </td>
                                </tr>
                            </table>

						</DIV>
					</TD> <!-- ENDPAGE -->
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			
			<!-- Page element: Tag Page -->
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>

                        <asp:HiddenField ID="hdfSelectedId" runat="server" />
                    </td>
                </tr>
            </table>
			
            <!-- Page element: Data objects -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
			            <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetNavigator"
                            TypeName="LiquiForce.LFSLive.WebUI.CWP.navigator2"
                            FilterExpression="(Deleted = 0)" OldValuesParameterFormatString="original_{0}">                            
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
