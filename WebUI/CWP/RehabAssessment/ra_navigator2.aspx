<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" Codebehind="ra_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_navigator2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Rehab Assessment" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click"/>
                </td>
                <td style="width:10px">
                </td>                
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Rehab Assessment" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mRehabAssessmentPlan" Text="Rehab Assessment Plan"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mBulkUpload" Text="Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWincapBulkUpload" Text="Wincan (Lateral) Bulk Upload" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOpenedAndBrushed" Text="Opened And Brushed Report" ></telerik:RadPanelItem>
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
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element: Search & Sort components , 8 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="width: 135px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 345px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>                
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlDefaultViewSearch" runat="server" Width="100%" DefaultButton="btnGo">  
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td>
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel id="upnlViews" runat="server">
                            <contenttemplate>
                                <asp:DropDownList style="WIDTH: 540px" id="ddlView" runat="server" SkinID="DropDownListLookup">
                                </asp:DropDownList> 
                            </contenttemplate>
                        </asp:UpdatePanel></td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button  ID="btnViewAdd" runat="server" style="width: 16px; height:16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height:16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height:16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                         <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px" EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" />
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
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one section."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
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
                    <asp:Panel ID="pnlGrid" runat="server" Width="625px" Height="200px" ScrollBars="Auto">
                        <asp:GridView ID="grdRANavigator" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="AssetID" SkinID="GridView" >
                            <Columns>
                            
                                <%--Column 0--%>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                            Checked='<%# Bind("Selected") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 1--%>
                                <asp:TemplateField HeaderText="AssetID" Visible ="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetID" runat="server" Style="width: 100px" Text='<%# Bind("AssetID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 2--%>
                                <asp:TemplateField HeaderText="ID (Section)">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlowOrderID" runat="server" Style="width: 100px" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 3--%>
                                <asp:TemplateField HeaderText="Old CWP ID">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblOldCWPID" runat="server" Style="width: 100px" Text='<%# Bind("OriginalSectionID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 4--%>
                                <asp:TemplateField HeaderText="Sub Area">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubArea" runat="server" Style="width: 150px" Text='<%# Bind("SubArea") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 5--%>
                                <asp:TemplateField HeaderText="Street">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStreet" runat="server" Style="width: 150px" Text='<%# Bind("Street") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 6--%>
                                <asp:TemplateField HeaderText="USMH">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMH" runat="server" Style="width: 100px" Text='<%# Bind("USMHDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 7--%>
                                <asp:TemplateField HeaderText="DSMH">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMH" runat="server" Style="width: 100px" Text='<%# Bind("DSMHDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 8--%>
                                <asp:TemplateField HeaderText="Pre-Flush Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreFlushDate" runat="server" Style="width: 100px" Text='<%# Bind("PreFlushDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 9--%>
                                <asp:TemplateField HeaderText="Pre-Video Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreVideoDate" runat="server" Style="width: 100px" Text='<%# Bind("PreVideoDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                                               
                                <%--Column 10--%>
                                <asp:TemplateField HeaderText="Map Size">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblMapSize" runat="server" Style="width: 100px" Text='<%# Bind("MapSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 11--%>
                                <asp:TemplateField HeaderText="Map Length">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblMapLength" runat="server" Style="width: 100px" Text='<%# Bind("MapLength") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 12--%>
                                <asp:TemplateField HeaderText="Thickness">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblThickness" runat="server" Style="width: 80px" Text='<%# Bind("Thickness") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 13--%>
                                <asp:TemplateField HeaderText="Confirmed Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize_" runat="server" Width="100px" Text='<%# Bind("Size_") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 14--%>
                                <asp:TemplateField HeaderText="Steel Tape Length">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLength" runat="server" Width="100px" Text='<%# Bind("Length") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 15--%>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Width="250px" Text='<%# Bind("Comments") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                             
                                                                
                                <%--Column 16--%>
                                <asp:TemplateField HeaderText="Video Length">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoLength" runat="server" Width="100px" Text='<%# Bind("VideoLength") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 17--%>
                                <asp:TemplateField HeaderText="Laterals">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLaterals" runat="server" Width="100px" Text='<%# Bind("Laterals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 18--%>
                                <asp:TemplateField HeaderText="Live Laterals">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLiveLaterals" runat="server" Width="100px" Text='<%# Bind("LiveLaterals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 19--%>
                                <asp:TemplateField HeaderText="Client ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientID" runat="server" Width="100px" Text='<%# Bind("ClientID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 20--%>
                                <asp:TemplateField HeaderText="P1 Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP1Date" runat="server" Width="100px" Text='<%# Bind("P1Date", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 21--%>
                                <asp:TemplateField HeaderText="CXI's Removed">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCXIsRemoved" runat="server" Width="100px" Text='<%# Bind("CXIsRemoved") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 22--%>
                                <asp:TemplateField HeaderText="M1 Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblM1Date" runat="server" Width="100px" Text='<%# Bind("M1Date", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 23--%>
                                <asp:TemplateField HeaderText="Measurements Taken By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeasurementTakenBy" runat="server" Width="100px" Text='<%# Bind("MeasurementTakenBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 24--%>
                                <asp:TemplateField HeaderText="Material">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialType" runat="server" Width="100px" Text='<%# Bind("MaterialType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 25--%>
                                <asp:TemplateField HeaderText="USMH Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHAddress" runat="server" Width="100px" Text='<%# Bind("USMHAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 26--%>
                                <asp:TemplateField HeaderText="USMH Depth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHDepth" runat="server" Width="100px" Text='<%# Bind("USMHDepth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 27--%>
                                <asp:TemplateField HeaderText="USMH Mouth 12:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth12" runat="server" Width="100px" Text='<%# Bind("USMHMouth12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 28--%>
                                <asp:TemplateField HeaderText="USMH Mouth 1:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth1" runat="server" Width="100px" Text='<%# Bind("USMHMouth1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 29--%>
                                <asp:TemplateField HeaderText="USMH Mouth 2:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth2" runat="server" Width="100px" Text='<%# Bind("USMHMouth2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 30--%>
                                <asp:TemplateField HeaderText="USMH Mouth 3:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth3" runat="server" Width="100px" Text='<%# Bind("USMHMouth3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 31--%>
                                <asp:TemplateField HeaderText="USMH Mouth 4:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth4" runat="server" Width="100px" Text='<%# Bind("USMHMouth4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 32--%>
                                <asp:TemplateField HeaderText="USMH Mouth 5:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth5" runat="server" Width="100px" Text='<%# Bind("USMHMouth5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 33--%>
                                <asp:TemplateField HeaderText="DSMH Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHAddress" runat="server" Width="100px" Text='<%# Bind("DSMHAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 34--%>
                                <asp:TemplateField HeaderText="DSMH Depth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHDepth" runat="server" Width="100px" Text='<%# Bind("DSMHDepth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 35--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 12:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth12" runat="server" Width="100px" Text='<%# Bind("DSMHMouth12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 36--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 1:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth1" runat="server" Width="100px" Text='<%# Bind("DSMHMouth1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 37--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 2:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth2" runat="server" Width="100px" Text='<%# Bind("DSMHMouth2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 38--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 3:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth3" runat="server" Width="100px" Text='<%# Bind("DSMHMouth3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 39--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 4:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth4" runat="server" Width="100px" Text='<%# Bind("DSMHMouth4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 40--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 5:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth5" runat="server" Width="100px" Text='<%# Bind("DSMHMouth5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 41--%>
                                <asp:TemplateField HeaderText="Traffic Control">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrafficControl" runat="server" Width="100px" Text='<%# Bind("TrafficControl") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 42--%>
                                <asp:TemplateField HeaderText="Site Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSiteDetails" runat="server" Width="100px" Text='<%# Bind("SiteDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 43--%>
                                <asp:TemplateField HeaderText="Pipe Size Change?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxPipeSizeChange" runat="server" Checked='<%# Bind("PipeSizeChange") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 44--%>
                                <asp:TemplateField HeaderText="Standard Bypass?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxStandardBypass" runat="server" Checked='<%# Bind("StandardBypass") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                
                                <%--Column 45--%>
                                <asp:TemplateField HeaderText="Standard Bypass Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStandardBypassComments" runat="server" Width="100px" Text='<%# Bind("StandardBypassComments") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 46--%>
                                <asp:TemplateField HeaderText="Traffic Control Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrafficControlDetails" runat="server" Width="100px" Text='<%# Bind("TrafficControlDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 47--%>
                                <asp:TemplateField HeaderText="Measurement Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeasurementType" runat="server" Width="100px" Text='<%# Bind("MeasurementType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 48--%>
                                <asp:TemplateField HeaderText="Measured From MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeasurementFromMH" runat="server" Width="100px" Text='<%# Bind("MeasurementFromMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 49--%>
                                <asp:TemplateField HeaderText="Video Done From MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoDoneFromMH" runat="server" Width="100px" Text='<%# Bind("VideoDoneFromMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 50--%>
                                <asp:TemplateField HeaderText="Video Done To MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoDoneToMH" runat="server" Width="100px" Text='<%# Bind("VideoDoneToMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 51--%>
                                <asp:TemplateField HeaderText="Section Robotic Prep">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxRoboticPrepCompleted" runat="server" Checked='<%# Bind("RoboticPrepCompleted") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 52--%>
                                <asp:TemplateField HeaderText="Robotic Prep Completed Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoboticPrepCompletedDate" runat="server" Width="100px" Text='<%# Bind("RoboticPrepCompletedDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Not visible columns--%>
                                <asp:TemplateField HeaderText="ID (Section)" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSectionID" runat="server" Style="width: 100px" Text='<%# Bind("SectionID") %>'></asp:Label>
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
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnExportList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPrintLateralLocationSheet" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Lat Loc Sheet" Style="width: 80px" OnClick="btnPrintLateralLocationSheet_Click" />
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
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
        </table>
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>

        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Rehab Assessment" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Rehab Assessment" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfSelectedViewId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>