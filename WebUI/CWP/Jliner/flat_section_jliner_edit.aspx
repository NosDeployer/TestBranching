<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" Codebehind="flat_section_jliner_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.flat_section_jliner_edit" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Update Laterals" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
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
                        PageSize="1" Width="100%" DataKeyNames="ID_" ShowHeader="False" EnableViewState="False"
                        OnRowCommand="grdvJliner_RowCommand" OnRowCreated="grdvJliner_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="Lateral">                                
                                <ItemTemplate>
                                    <!-- Table element : 3 columns - Jliner row -->
                                    <table style="width: 100%" class="Background_ViewGrid_Table" cellspacing="0" cellpadding="0"
                                        border="0">
                                        <tbody>
                                            <tr>
                                                <td class="Background_ViewGrid_Header" align="center" colspan="5">
                                                    <asp:Label ID="lblTitleGrid" runat="server" SkinID="ViewGridHeader" Text="Lateral"></asp:Label>
                                                </td>
                                            </tr>                                    
                                            <tr>
                                                <td style="width: 25px" class="Background_ViewGrid_Td">
                                                    </td>
                                                <td style="width: 700px" class="Background_ViewGrid_Td">
                                                    <!-- Table element : 5 columns - Jliner fields -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 700px">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("ID") %>' />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:HiddenField ID="hdfCompanyId" runat="server" Value='<%# Eval("COMPANY_ID") %>' />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:HiddenField ID="hdfRefId" runat="server" Value='<%# Eval("RefID") %>' />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:HiddenField ID="hdfRecordId" runat="server" Value='<%# Eval("RecordID") %>' />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:HiddenField ID="hdfDetailId" runat="server" Value='<%# Eval("DetailID") %>' />
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
                                                                <asp:TextBox ID="tbxClientLateralId" runat="server" EnableViewState="False" SkinID="TextBox" Text='<%# Eval("ClientLateralID") %>' Width="130px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxHamiltonInspectionNumber" runat="server" EnableViewState="False" SkinID="TextBox" Text='<%# Eval("HamiltonInspectionNumber") %>' Width="130px">
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
                                                                <asp:TextBox ID="tbxAddress" runat="server" SkinID="TextBox" Text='<%# Eval("Address") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIssue" runat="server" SkinID="DropDownList" Width="130px"
                                                                    EnableViewState="False" SelectedValue='<%# Eval("Issue") %>'>
                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                    <asp:ListItem Value="Out Of Scope">Out Of Scope</asp:ListItem>
                                                                    <asp:ListItem Value="Dig Required Prior To Lining">Dig Req'd Prior To Lining</asp:ListItem>
                                                                    <asp:ListItem Value="Hold - Client Issue">Hold - Client Issue</asp:ListItem>
                                                                    <asp:ListItem Value="Hold - LFS Issue">Hold - LFS Issue</asp:ListItem>
                                                                    <asp:ListItem Value="Dig Required After Lining">Dig Req'd After Lining</asp:ListItem>
                                                                    <asp:ListItem Value="Robotic Prep Required">Robotic Prep Req'd</asp:ListItem>
                                                                </asp:DropDownList>
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
                                                                <asp:TextBox ID="tbxVideoInspection" runat="server" SkinID="TextBox" Text='<%# Eval("VideoInspection", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvVideoInspection" runat="server" ControlToValidate="tbxVideoInspection"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Date">
                                                                </asp:CompareValidator>
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
                                                                        <td style="width: 50%; height: 19px;">
                                                                            <asp:Label ID="lblCoReq" runat="server" EnableViewState="False" SkinID="Label" Text="C/O Req.">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td style="width: 50%; height: 19px;">
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
                                                                <asp:TextBox ID="tbxVideoLengthToPropertyLine" runat="server" EnableViewState="False" SkinID="TextBox" Text='<%# Eval("VideoLengthToPropertyLine") %>' Width="130px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxPipeLocated" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("PipeLocated", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxServicesLocated" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("ServicesLocated", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                    <tr>
                                                                        <td style="width: 50%">
                                                                            <asp:CheckBox ID="cbxCoReq" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("CoRequired") %>' />
                                                                        </td>
                                                                        <td style="width: 50%">
                                                                            <asp:CheckBox ID="cbxPitReq" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("PitRequired") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCoPitLocation" runat="server" SkinID="DropDownList" Width="130px"
                                                                    EnableViewState="False" DataValueField="Name" DataMember="DefaultView" DataTextField="Name"
                                                                    DataSourceID="odsCoPitLocation" SelectedValue='<%# GetCoPitLocationSelected(Eval("CoPitLocation")) %>'>
                                                                </asp:DropDownList>
                                                            </td>                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxVideoLengthToPropertyLine"
                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                    OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" Style="width: 80px">
                                                                </asp:CustomValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvPipeLocated" runat="server" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    ControlToValidate="tbxPipeLocated" Display="Dynamic" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvServicesLocated" runat="server" ControlToValidate="tbxServicesLocated"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                 </asp:CompareValidator>
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
                                                                <asp:TextBox ID="tbxCoInstalled" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("CoInstalled", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxBackfilledConcrete" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("BackfilledConcrete", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxBackfilledSoil" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("BackfilledSoil", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxGrouted" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("Grouted", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxCored" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("Cored", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCoInstalled" runat="server" ControlToValidate="tbxCoInstalled"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvBackfilledConcrete" runat="server" ControlToValidate="tbxBackfilledConcrete"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvBackfilledSoil" runat="server" ControlToValidate="tbxBackfilledSoil"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvGrouted" runat="server" ControlToValidate="tbxGrouted"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCored" runat="server" ControlToValidate="tbxCored" Display="Dynamic"
                                                                    ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
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
                                                                <asp:TextBox ID="tbxPrepped" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("Prepped", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxPreVideo" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("PreVideo", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxMeasured" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("Measured", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxLinerSize" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("LinerSize") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="cbxLiningThruCo" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("LiningThruCo") %>' />
                                                            </td>                                                       
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvPrepped" runat="server" ControlToValidate="tbxPrepped"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvPreVideo" runat="server" ControlToValidate="tbxPreVideo"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvMeasured" runat="server" ControlToValidate="tbxMeasured"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
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
                                                                <asp:TextBox ID="tbxNoticeDelivered" runat="server" SkinID="TextBox" Text='<%# Eval("NoticeDelivered", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxInProcess" runat="server" SkinID="TextBox" Text='<%# Eval("InProcess", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxInStock" runat="server" SkinID="TextBox" Text='<%# Eval("InStock", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxDelivered" runat="server" SkinID="TextBox" Text='<%# Eval("Delivered", "{0:d}") %>' Width="130px" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxLinerInstalled" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("LinerInstalled", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>                                                        
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvNoticeDelivered" runat="server" ControlToValidate="tbxNoticeDelivered"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Date">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvInProcess" runat="server" ControlToValidate="tbxInProcess"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Date">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvInStock" runat="server" ControlToValidate="tbxInStock"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Date">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvDelivered" runat="server" ControlToValidate="tbxDelivered"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use MM/DD/YYYY format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Date">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvLinerInstalled" runat="server" ControlToValidate="tbxLinerInstalled"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
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
                                                                <asp:Label ID="lblDistanceFromUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="Distance From USMH">
                                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDistanceFromDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="Distance From DSMH">
                                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPostContractDigRequired" runat="server" EnableViewState="false" SkinID="Label" Text="Post Contract Dig?">
                                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCoCutDown" runat="server" EnableViewState="false" SkinID="Label" Text="C/O Cut Down?">
                                                                </asp:Label>
                                                            </td>                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxFinalVideo" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("FinalVideo", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxDistanceFromUSMH" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("DistanceFromUSMH", "{0:n1}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxDistanceFromDSMH" runat="server" SkinID="TextBoxReadOnly" Width="130px" Text='<%# Eval("DistanceFromDSMH", "{0:n1}") %>' ReadOnly="True" EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="cbxPostContractDigRequired" runat="server" EnableViewState="False" SkinID="CheckBox" Checked='<%# Eval("PostContractDigRequired") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxCoCutDown" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("CoCutDown", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>                                                                                                                
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CompareValidator ID="cvFinalVideo" runat="server" ControlToValidate="tbxFinalVideo"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvDistanceFromUSMH1" runat="server" ControlToValidate="tbxDistanceFromUSMH"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use #.#  format)"
                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Double">
                                                                </asp:CompareValidator>
                                                                <asp:CompareValidator ID="cvDistanceFromUSMH2" runat="server" ControlToValidate="tbxDistanceFromUSMH"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (must be equal or greater than 0)"
                                                                    Operator="GreaterThanEqual" SkinID="Validator" Type="Double" ValueToCompare="0">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvDistanceFromDSMH" runat="server" ControlToValidate="tbxDistanceFromDSMH"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (the calculation must be equal or greater than 0)"
                                                                    Operator="GreaterThanEqual" SkinID="Validator" Type="Double" ValueToCompare="0">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCoCutDown" runat="server" ControlToValidate="tbxCoCutDown"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
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
                                                                <asp:TextBox ID="tbxFinalRestoration" runat="server" SkinID="TextBox" Width="130px" Text='<%# Eval("FinalRestoration", "{0:d}") %>' EnableViewState="False">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxCost" runat="server" SkinID="TextBox" Text='<%# Eval("Cost", "{0:f2}") %>' Width="130px" Visible='<%# Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]) %>' EnableViewState="False">
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
                                                            <td>
                                                                <asp:CompareValidator ID="cvFinalRestoration" runat="server" ControlToValidate="tbxFinalRestoration"
                                                                    Display="Dynamic" ErrorMessage="Invalid date. (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Date" EnableViewState="False">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCost" runat="server" ControlToValidate="tbxCost" Display="Dynamic"
                                                                    EnableViewState="False" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                                                                    SkinID="Validator" Type="Currency">
                                                                </asp:CompareValidator>
                                                            </td>
                                                            <td>
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
                                                    <!-- Table element : 1 column - Jliner comments and history -->
                                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 690px">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:Label ID="lblComments" runat="server" EnableViewState="False" SkinID="Label"
                                                                    Text="Comments"></asp:Label>
                                                                <td align="right" style="width: 50%">
                                                                    <asp:Button ID="btnComments" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                                                        CommandName="Comments" EnableViewState="False" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 46px">
                                                                <asp:TextBox ID="tbxComments" runat="server" Height="44px" SkinID="TextBoxReadOnly"
                                                                    TextMode="MultiLine" Width="100%" Text='<%# Eval("Comments") %>' ReadOnly="True"
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
                                                                    CommandName="History" EnableViewState="False" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 46px">
                                                                <asp:TextBox ID="tbxHistory" runat="server" Height="44px" SkinID="TextBoxReadOnly"
                                                                    TextMode="MultiLine" Width="690px" Text='<%# Eval("History") %>' ReadOnly="True"
                                                                    EnableViewState="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 25px" colspan="2">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 25px" class="Background_ViewGrid_Td">
                                                </td>
                                            </tr>
                                    </table>
                                    
                                    <!-- Table element : Space inter rows -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;" >
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
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <!-- Page element: Data objects -->
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCoPitLocation" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Jliner.JlinerCoPitLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue=" " Name="name" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="abbreviation" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
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
    
    <!-- Table element : Toolbar -->
    <div style="width: 750px">
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
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="3">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>