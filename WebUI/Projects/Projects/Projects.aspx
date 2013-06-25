<%@ Page Language="C#" MasterPageFile="../../mForm5.master" AutoEventWireup="true" Codebehind="Projects.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.Projects" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Projects" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Projects" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddProject" Text="Add Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mDuplicateProposal" Text="Duplicate Proposal Tool" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
             </tr>
             <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mBallparkSummaryReport" Text="Ballpark Summary"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mTotalValueOfProposalsReport" Text="Total Value Of Proposals" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCurrentActiveWorkOnHandReport" Text="Current Active Work On Hand" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectsSummaryReport" Text="Projects Summary" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar2_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProductionReport" Text="Production Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVideoCompleteReport" Text="Video Complete Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mDetailedCostingSheetReport" Text="Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCombinedDetailedCostingSheetReport" Text="Combined Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mConsolidatedCostingSheetReport" Text="Consolidated Costing Sheet"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
             </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px; height: 430px;">
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnbSearch">
            <!-- Table element: 7 columns - Search -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 110px">
                        <asp:Label ID="lblProjectNumber" runat="server" EnableViewState="False" SkinID="Label" Text="Project Number"></asp:Label>
                    </td>
                    <td style="width: 110px">
                        <asp:Label ID="lblProjectName" runat="server" EnableViewState="False" SkinID="Label" Text="Project Name"></asp:Label>
                    </td>
                    <td style="width: 110px">
                        <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                    </td>
                    <td style="width: 110px">
                        <asp:Label ID="lblCountry" runat="server" EnableViewState="False" SkinID="Label" Text="Country"></asp:Label>
                    </td>
                    <td style="width: 110px">
                        <asp:Label ID="lblType" runat="server" EnableViewState="False" SkinID="Label" Text="Type"></asp:Label>
                    </td>
                    <td style="width: 110px">
                        <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                    </td>
                    <td style="width: 90px">
                    </td>    
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbxProjectNumber" runat="server" EnableViewState="False" SkinID="TextBox" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxName" runat="server" EnableViewState="False" SkinID="TextBox" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxClient" runat="server" EnableViewState="False" SkinID="TextBox" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" Height="16px" SkinID="DropDownList" Width="100px">                         
                          <asp:ListItem Value="%" Text= "(All)"></asp:ListItem> 
                          <asp:ListItem Value="1" Text= "Canada"></asp:ListItem>       
                          <asp:ListItem Value="2" Text= "USA"></asp:ListItem>                          
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProjectType" runat="server" Height="16px" SkinID="DropDownList"
                          Width="100px">           
                          <asp:ListItem Value="Project" Text="Project"></asp:ListItem>                      
                        </asp:DropDownList> 
                        <asp:DropDownList ID="ddlProjectTypeAdmin" runat="server" Height="16px" SkinID="DropDownList"
                          Width="100px">                         
                          <asp:ListItem Value="%" Text= "(All)"></asp:ListItem>        
                          <asp:ListItem Value="BallparkProposalProject" Text= "Ballpark & Proposal & Project"></asp:ListItem>
                          <asp:ListItem Value="Ballpark" Text= "Ballpark"></asp:ListItem>
                          <asp:ListItem Value="Proposal" Text= "Proposal"></asp:ListItem>
                          <asp:ListItem Value="Project" Text= "Project"></asp:ListItem>
                          <asp:ListItem Value="Internal" Text= "Internal Project"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProjectState" runat="server" Height="16px" SkinID="DropDownList"
                          Width="100px">    
                          <asp:ListItem Value="Active" Text="Active"></asp:ListItem>                             
                        </asp:DropDownList> 
                        <asp:DropDownList ID="ddlProjectStateAdmin" runat="server" Height="16px" SkinID="DropDownList"
                          Width="100px"> 
                          <asp:ListItem Value="%" Text= "(All)"></asp:ListItem>        
                          <asp:ListItem Value="Bidding" Text= "Bidding"></asp:ListItem>
                          <asp:ListItem Value="Awarded" Text= "Awarded"></asp:ListItem>                                
                          <asp:ListItem Value="Lost Bid" Text= "Lost Bid"></asp:ListItem>                                
                          <asp:ListItem Value="Canceled" Text= "Canceled"></asp:ListItem>                                
                          <asp:ListItem Value="Waiting" Text= "Waiting"></asp:ListItem>                                
                          <asp:ListItem Value="Active" Text= "Active"></asp:ListItem>                                
                          <asp:ListItem Value="Complete" Text= "Complete"></asp:ListItem>                                
                        </asp:DropDownList> 
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnbSearch" runat="server" EnableViewState="False" SkinID="Button" Text="Search" Width="80px" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
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
        
        <!-- Page element : No Results -->
        <table id="tNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td id="tdNoResults" runat="server">
                    <asp:Label ID="pNoResults" runat="server" Text="No results for your query"></asp:Label>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Section title - LastOpenedProjects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="LastOpenedProjects" runat="server" SkinID="LabelTitle1" Text="Last Opened Projects" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        		
        		
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                                       
                    <asp:GridView id="grdProjects" runat="server" SkinID="GridView" Width="660px" 
                        DataKeyNames="ProjectID, UserID, LastLoggedInDate, COMPANY_ID" 
                        DataSourceID="odsProjects" OnDataBound="grdProjects_DataBound"
                        AutoGenerateColumns="False">
                            <Columns>                                    
                                <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectId" runat="server" Style="width: 100px" Text='<%# Bind("ProjectID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="UserID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserId" runat="server" Style="width: 100px" Text='<%# Bind("UserID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="LastLoggedInDate" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastLoggedInDate" runat="server" Style="width: 100px" Text='<%# Bind("LastLoggedInDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                    
                                <asp:TemplateField HeaderText="COMPANY_ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyId" runat="server" Style="width: 100px" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Client">                                    
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" Style="width: 230px" Text='<%# Bind("ClientName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px"></HeaderStyle>
                                    </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Project">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectName" runat="server" Style="width: 230px" Text='<%# Bind("ProjectName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="210px"></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Style="width: 230px" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <ItemTemplate>                                            
                                        <asp:HyperLink ID="hlkGo" runat="server" SkinID="HyperLink" Text="Go"
                                         NavigateUrl='<%# GetUrl( Eval("ProjectID")) %>' Target="_parent" >
                                        </asp:HyperLink>                                                                               
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                                                             
                                                                             
                                                                                                                                                    
                            </Columns>
                        </asp:GridView>
                
                </td>
            </tr>
            <tr>
                <td >
                </td>                    
            </tr>
            <tr>
                <td style="height: 60px">
                </td>                    
            </tr>
        </table>
            
            <!-- Page element: Data objects -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsProjects" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProjects" 
                            TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.Projects">
                        </asp:ObjectDataSource>

                    </td>
                </tr>
            </table>	
            
            <!-- Page element : Tag page -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdfCompanyId" runat="server" />
                        <asp:HiddenField ID="hdfLoginId" runat="server" />                                                
                        <asp:HiddenField ID="hdfProjectId" runat="server" /> 
                    </td>
                </tr>
            </table>	
	</div>
</asp:Content>
