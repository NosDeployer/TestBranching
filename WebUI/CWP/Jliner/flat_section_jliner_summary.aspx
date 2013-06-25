<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" Codebehind="flat_section_jliner_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.flat_section_jliner_summary" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Laterals Summary" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuCurrentClient" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Current Client" PostBack="false">
                                <Items>                                   
                                    <telerik:RadPanelItem runat="server" Value="mCurrentClient" Text="Current Client" PostBack="false">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxCurrentClient" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>     
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mChange" Text="Change" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuLaterals" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Laterals" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAdd" Text="Add"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <hr style="color: #2f82c7; height: 1px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLiningPlan" Text="Lining Plan" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mLateralsOverviewReport" Text="Laterals Overview Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLinersToBuildReport" Text="Liners To Build Report" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>       
    </div>         
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                     <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" >                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mBulkDateUpdate" Text="BULK DATE UPDATE" />
                                                          
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>        
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">        
        <!-- Page element: 1 column - Grid Jliner -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="grdvJliner" runat="server" AutoGenerateColumns="False" GridLines="None"
                        PageSize="1" Width="100%" DataKeyNames="ID_" DataSourceID="odsFlatSectionJliner"
                        ShowHeader="False" OnRowDataBound="grdvJliner_RowDataBound" EnableViewState="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Lateral">
                                <ItemTemplate>
                                    <!-- Table element : 3 columns - Jliner row -->
                                    <table style="width: 100%" class="Background_ViewGrid_Table" cellspacing="0" cellpadding="0"
                                        border="0">
                                        <tr>
                                            <td class="Background_ViewGrid_Header" align="center" colspan="5">
                                                    <asp:Label ID="lblTitleGrid" runat="server" SkinID="ViewGridHeader" Text="Lateral"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; " class="Background_ViewGrid_Td">
                                                <asp:CheckBox ID="cbxSelected" runat="server" SkinID="CheckBox" Checked='<%# Eval("Selected") %>'
                                                    EnableViewState="False" />
                                            </td>
                                            <td style="width: 25px" class="Background_ViewGrid_Td">
                                            </td>
                                            <td style="width: 700px" class="Background_ViewGrid_Td">
                                                <!-- Table element : 5 columns - Jliner fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%">
                                                        </td>
                                                        <td style="width: 20%">
                                                        </td>
                                                        <td style="width: 20%">
                                                        </td>
                                                        <td style="width: 20%">
                                                        </td>
                                                        <td style="width: 20%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblId_" runat="server" EnableViewState="False" SkinID="Label" Text="ID">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClientLateralId" runat="server" EnableViewState="False" SkinID="Label" Text="Client Lateral ID">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHamiltonInspectionNumber" runat="server" EnableViewState="False" SkinID="Label" Text="Hamilton Insp.#">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxId_" runat="server" SkinID="TextBoxReadOnly" Width="130px" ReadOnly="True" Text='<%# Eval("ID_") %>' EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                        <td>
                                                            <asp:TextBox ID="tbxClientLateralId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientLateralID") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxHamiltonInspectionNumber" runat="server" SkinID="TextBoxReadOnly" Width="130px" ReadOnly="True" Text='<%# Eval("HamiltonInspectionNumber") %>' EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxStreet" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Street") %>' Width="270px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAddress" runat="server" EnableViewState="False" SkinID="Label" Text="Address">
                                                            </asp:Label>
                                                        </td>                                                        
                                                        <td>
                                                            <asp:Label ID="lblIssue" runat="server" EnableViewState="False" SkinID="Label" Text="Issue">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUSMH" runat="server" EnableViewState="false" SkinID="Label" Text="USMH">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDSMH" runat="server" EnableViewState="false" SkinID="Label" Text="DSMH">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVideoInspection" runat="server" EnableViewState="False" SkinID="Label" Text="Video Inspection">
                                                            </asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxAddress" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Address") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxIssue" runat="server" SkinID="TextBoxSmallReadOnly" Text='<%# GetIssueSelected(Eval("Issue")) %>' Width="130px" ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxUSMH" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("USMH") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDSMH" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("DSMH") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxVideoInspection" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("VideoInspection", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblVideoLengthToPropertyLine" runat="server" EnableViewState="False" SkinID="Label" Text="Video Length To PL">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPipeLocated" runat="server" EnableViewState="False" SkinID="Label" Text="Pipe Located">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblServicesLocated" runat="server" EnableViewState="False" SkinID="Label" Text="Services Located">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:Label ID="lblCoReq" runat="server" EnableViewState="False" SkinID="Label" Text="C/O Req.">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:Label ID="lblPitReq" runat="server" EnableViewState="False" SkinID="Label" Text="Pit Req.">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoPitLocation" runat="server" EnableViewState="false" SkinID="Label" Text="CO/Pit Location">
                                                            </asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxVideoLengthToPropertyLine" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("VideoLengthToPropertyLine") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPipeLocated" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("PipeLocated", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxServicesLocated" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("ServicesLocated", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:CheckBox ID="cbxCoReq" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("CoRequired") %>' onclick="return cbxClick();" />
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:CheckBox ID="cbxPitReq" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("PitRequired") %>' onclick="return cbxClick();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoPitLocation" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("CoPitLocation") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCoInstalled" runat="server" EnableViewState="False" SkinID="Label" Text="C/O Installed">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBackfilledConcrete" runat="server" EnableViewState="False" SkinID="Label" Text="Backfilled Concrete">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBackfilledSoil" runat="server" EnableViewState="False" SkinID="Label" Text="Backfilled Soil">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblGrouted" runat="server" EnableViewState="False" SkinID="Label" Text="Grouted">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCored" runat="server" EnableViewState="False" SkinID="Label" Text="Cored">
                                                            </asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoInstalled" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("CoInstalled", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBackfilledConcrete" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("BackfilledConcrete", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBackfilledSoil" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("BackfilledSoil", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxGrouted" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("Grouted", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCored" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("Cored", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPrepped" runat="server" EnableViewState="False" SkinID="Label" Text="Prepped">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreVideo" runat="server" EnableViewState="False" SkinID="Label" Text="Pre-Video">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMeasured" runat="server" EnableViewState="False" SkinID="Label" Text="Measured">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLinerSize" runat="server" EnableViewState="False" SkinID="Label" Text="Liner Size">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLiningThruCo" runat="server" EnableViewState="False" SkinID="Label" Text="Lining Thru C/O">
                                                            </asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxPrepped" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("Prepped", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPreVideo" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("PreVideo", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxMeasured" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("Measured", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLinerSize" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("LinerSize") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxLiningThruCo" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("LiningThruCo") %>' onclick="return cbxClick();" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNoticeDelivered" runat="server" EnableViewState="False" SkinID="Label" Text="Notice Delivered">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInProcess" runat="server" EnableViewState="False" SkinID="Label" Text="Liner In Process">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInStock" runat="server" EnableViewState="False" SkinID="Label" Text="Liner In Stock">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDelivered" runat="server" EnableViewState="False" SkinID="Label" Text="Liner Delivered">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLinerInstalled" runat="server" EnableViewState="False" SkinID="Label" Text="Liner Installed">
                                                            </asp:Label>
                                                        </td>                                                                                                               
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxNoticeDelivered" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("NoticeDelivered", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInProcess" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("InProcess", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInStock" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("InStock", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDelivered" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Delivered", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLinerInstalled" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("LinerInstalled", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td>
                                                            <asp:Label ID="lblFinalVideo" runat="server" EnableViewState="False" SkinID="Label" Text="Final Video">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDistanceFromUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="Dist. From USMH">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDistanceFromDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="Dist. From DSMH">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPostContractDigRequired" runat="server" EnableViewState="false" SkinID="Label" Text="Post Contract Dig?">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoCutDown" runat="server" EnableViewState="False" SkinID="Label" Text="C/O Cut Down?">
                                                            </asp:Label>
                                                        </td>                                                                                                                
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxFinalVideo" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("FinalVideo", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDistanceFromUSMH" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("DistanceFromUSMH", "{0:n1}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDistanceFromDSMH" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("DistanceFromDSMH", "{0:n1}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxPostContractDigRequired" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("PostContractDigRequired") %>' onclick="return cbxClick();" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoCutDown" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("CoCutDown", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>                                                                                                                
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblFinalRestoration" runat="server" EnableViewState="false" SkinID="Label" Text="Final Restoration">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCost" runat="server" EnableViewState="False" SkinID="Label" Text="Cost" Visible='<%# Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]) %>'>
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBuildRebuild" runat="server" EnableViewState="False" SkinID="Label" Text="Build / Rebuild #">
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxFinalRestoration" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("FinalRestoration", "{0:d}") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCost" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Cost", "{0:f2}") %>' Width="130px" Visible='<%# Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]) %>' EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBuildRebuild" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("BuildRebuild") %>' ReadOnly="True" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                <!-- Table element : 2 columns - Jliner comments and history -->
                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 690px">
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <asp:Label ID="Label2" runat="server" EnableViewState="False" SkinID="Label" Text="Comments"></asp:Label></td>
                                                        <td align="right" style="width: 50%">
                                                            <asp:Button ID="btnComments" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                                                EnableViewState="False" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxComments" runat="server" Height="44px" SkinID="TextBoxReadOnly"
                                                                TextMode="MultiLine" Width="690px" Text='<%# Eval("Comments") %>' ReadOnly="True"
                                                                EnableViewState="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50%;">
                                                            <asp:Label ID="lblHistory" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="History"></asp:Label>
                                                        </td>
                                                        <td align="right" colspan="1" style="width: 50%">
                                                            <asp:Button ID="btnHistory" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                                                EnableViewState="False" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 46px">
                                                            <asp:TextBox ID="tbxHistory" runat="server" Height="44px" SkinID="TextBoxReadOnly"
                                                                TextMode="MultiLine" Width="690px" Text='<%# Eval("History") %>' ReadOnly="True"
                                                                EnableViewState="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:HiddenField ID="hdfID" runat="server" EnableViewState="false" Value='<%# Eval("ID") %>' />
                                                            <asp:HiddenField ID="hdfRefID" runat="server" EnableViewState="false" Value='<%# Eval("RefID") %>' />
                                                            <asp:HiddenField ID="hdfCompanyID" runat="server" EnableViewState="false" Value='<%# Eval("COMPANY_ID") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 25px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 25px" class="Background_ViewGrid_Td">
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element : Space inter rows -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                        <tr>
                                            <td style="height: 35px" class="Background_ViewGrid_Separator">
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        
        <!-- Table element : Toolbar -->
        <table id="tbFooterToolbar" runat="server" border="0" cellpadding="0" cellspacing="0"
            style="width: 100%" class="ASPxMenu_Background">
            <tr>
                <td style="width: 10px; height: 10px">
                </td>
                <td>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" >                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mBulkDateUpdate" Text="BULK DATE UPDATE" />
                                                          
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsFlatSectionJliner" runat="server" SelectMethod="GetDataSet"
                        TypeName="LiquiForce.LFSLive.DA.CWP.Jliner.FlatSectionJlinerGateway">
                        <SelectParameters>
                            <asp:SessionParameter Name="flatSectionJlinerTDS" SessionField="flatSectionJlinerTDS"
                                Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>