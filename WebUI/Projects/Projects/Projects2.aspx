<%@ Page Language="C#" MasterPageFile="./../../mForm5.master" AutoEventWireup="true" Codebehind="Projects2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.Projects2" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Projects" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
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
    <div style="width: 750px;">
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
                        <asp:DropDownList ID="ddlProjectType" runat="server" Height="16px" SkinID="DropDownList" Width="100px">           
                            <asp:ListItem Value="Project" Text="Project"></asp:ListItem>                      
                        </asp:DropDownList> 
                        <asp:DropDownList ID="ddlProjectTypeAdmin" runat="server" Height="16px" SkinID="DropDownList" Width="100px">                         
                          <asp:ListItem Value="%" Text= "(All)"></asp:ListItem>        
                          <asp:ListItem Value="BallparkProposalProject" Text= "Ballpark & Proposal & Project"></asp:ListItem>
                          <asp:ListItem Value="Ballpark" Text= "Ballpark"></asp:ListItem>
                          <asp:ListItem Value="Proposal" Text= "Proposal"></asp:ListItem>
                          <asp:ListItem Value="Project" Text= "Project"></asp:ListItem>
                          <asp:ListItem Value="Internal" Text= "Internal Project"></asp:ListItem>
                        </asp:DropDownList>                                               
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProjectState" runat="server" Height="16px" SkinID="DropDownList" Width="100px">    
                            <asp:ListItem Value="Active" Text="Active"></asp:ListItem>                             
                        </asp:DropDownList> 
                        <asp:DropDownList ID="ddlProjectStateAdmin" runat="server" Height="16px" SkinID="DropDownList" Width="100px"> 
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
                    <td>
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
        
        <!-- Page element: Section title - Results -->
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
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td style="width: 650px">
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="true" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td style="width: 125px; vertical-align: top;">
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Panel ID="pnlProjectSectionsNavigator" runat="server" Height="330px" Width="615px" ScrollBars="Auto">                                     
                        <asp:Panel ID="pnlGrdNavigator" runat="server" Width="1000px" ScrollBars="Horizontal">                                     
                            <asp:UpdatePanel id="upnlNavigator" runat="server">
                                <contenttemplate>
                                    <asp:GridView ID="grdNavigator" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                        PageSize="12" OnDataBound="grdNavigator_DataBound" AllowSorting="True" OnRowCreated="grdNavigator_RowCreated"
                                        DataSourceID="odsNavigator" DataKeyNames="ProjectID" OnSorting="grdNavigator_Sorting">
                                        <Columns>
                                            <asp:TemplateField Visible="False" ShowHeader="False">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Bind("ProjectID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField Visible="False" ShowHeader="False">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientID" runat="server" SkinID="Label" Text='<%# Bind("ClientID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="ProjectNumber" HeaderText="Project Number">
                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                <HeaderStyle Width="120px" Wrap="False"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectNumberForGrid" runat="server" SkinID="Label" Text='<%# Bind("ProjectNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="Name" HeaderText="Name">                                                
                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            
                                            <asp:TemplateField SortExpression="ClientName" HeaderText="Client">
                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" runat="server" SkinID="Label" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="Description" HeaderText="Description">                                                
                                                <HeaderStyle Width="150px" Wrap="False"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" SkinID="Label" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="ProjectType" HeaderText="Type">
                                                <ItemStyle Wrap="False"></ItemStyle>
                                                <HeaderStyle Width="75px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectType" runat="server" SkinID="Label" Text='<%# Bind("ProjectType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="ProjectState" HeaderText="State">
                                                <ItemStyle Wrap="False"></ItemStyle>
                                                <HeaderStyle Width="75px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectState" runat="server" SkinID="Label" Text='<%# Bind("ProjectState") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField SortExpression="InvoicedToDate" HeaderText="Invoiced To Date">
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                                <HeaderStyle Width="150px" Wrap="False"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoicedToDate" runat="server" SkinID="Label" Text='<%# Bind("InvoicedToDate","{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            
                                        </Columns>
                                    </asp:GridView>
                                </contenttemplate>    
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </asp:Panel>
                </td>
                <td style="vertical-align: top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <tr>
                            <td>
                                <asp:Button ID="btnAddCombinedCostingSheet" runat="server" OnClick="btnAddCombinedCostingSheet_Click" SkinID="ButtonSmallText" Text="Add Comb. Costing Sheet"
                                    Width="80px" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" OnClick="btnOpen_Click" SkinID="Button" Text="Open"
                                    Width="80px" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                    OnClick="btnEdit_Click" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" SkinID="ButtonRedText" Text="Delete" Width="80px"
                                    OnClick="btnDelete_Click" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>                                                                                                                
                                <asp:DropDownList ID="ddlViewWorks" runat="server"  AutoPostBack="true" Height="16px" SkinID="DropDownList"
                                 EnableViewState="false" Width="80px" OnSelectedIndexChanged="ddlViewWorks_SelectedIndexChanged">
                                 <asp:ListItem Text="(Works)" Value="Works" Selected="True"></asp:ListItem>                                 
                                 <asp:ListItem Text="Rehab Assessment" Value="RehabAssessment"></asp:ListItem>
                                 <asp:ListItem Text="Full Length Lining" Value="FullLengthLining"></asp:ListItem>
                                 <asp:ListItem Text="Point Repairs" Value="PointRepairs"></asp:ListItem>
                                 <asp:ListItem Text="Junction Lining" Value="JunctionLining"></asp:ListItem>
                                </asp:DropDownList>                                              
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>                                                                                                                
                                <asp:DropDownList ID="ddlCostingSheets" runat="server"  AutoPostBack="true" Height="16px" SkinID="DropDownList" Visible="false"
                                 EnableViewState="false" Width="80px" OnSelectedIndexChanged="ddlCostingSheets_SelectedIndexChanged">
                                 <asp:ListItem Text="(Costing Sheets)" Value="CostingSheets" Selected="True"></asp:ListItem>                                 
                                 <asp:ListItem Text="Add Combined Costing Sheet" Value="AddCombinedCostingSheet"></asp:ListItem>
                                </asp:DropDownList>                                              
                            </td>
                        </tr>                       
                        
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError"
                        Text="At least one project must be selected"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                
                    <!-- Page element: Data objects -->
                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetProjects"
                                    TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.Projects2"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Tag Page -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                    
                    <asp:HiddenField ID="hdfSelectedProjectId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedClientId" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfPageIndex" runat="server" />
                </td>
            </tr>
        </table>
        
       
    </div>
</asp:Content>
