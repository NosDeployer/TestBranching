<%@ Page Language="C#" MasterPageFile="./../../mForm7.master" AutoEventWireup="true" Codebehind="jliner_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_navigator" Title="LFS Live" %>
    
<asp:Content ID="Content3" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Claude's Lateral Database" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>
  
    
<asp:Content ID="Content4" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
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
                                                    <td style="width:10px"></td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCurrentClient" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Width="160px"></asp:TextBox>
                                                    </td>
                                                    <td style="width:10px"></td>
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
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false"></telerik:RadPanelItem>
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
    
   

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Section title - Columns to display-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblColumnsToDisplay" runat="server" SkinID="LabelTitle1" Text="Columns To Display" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Columns to display-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxId" onclick="return cbxClick();" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="ID"
                        EnableViewState="False" /></td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxClientLateralId" runat="server" SkinID="CheckBoxSmall" Text="Client Lateral ID"
                        EnableViewState="false" /></td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxHamiltonInspectionNumber" runat="server" SkinID="CheckBoxSmall" Text="Hamilton Insp.#"
                        EnableViewState="false" /></td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxStreet" runat="server" SkinID="CheckBoxSmall" Text="Street"
                        EnableViewState="False" /></td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxAddress" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="Address" 
                        EnableViewState="False" /></td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxCity" runat="server" SkinID="CheckBoxSmall" Text="City" 
                        EnableViewState="False" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxUSMH" runat="server" SkinID="CheckBoxSmall" Text="USMH" 
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxDSMH" runat="server" SkinID="CheckBoxSmall" Text="DSMH" 
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxVideoInspection" runat="server" SkinID="CheckBoxSmall" Text="Video Inspection"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxVideoLengthToPropertyLine" runat="server" SkinID="CheckBoxSmall" Text="Video Length To PL"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxPipeLocated" runat="server" SkinID="CheckBoxSmall" Text="Pipe Located"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxServicesLocated" runat="server" SkinID="CheckBoxSmall" Text="Services Located"
                        EnableViewState="False" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxCoRequired" runat="server" SkinID="CheckBoxSmall" Text="C/O Req."
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxPitRequired" runat="server" SkinID="CheckBoxSmall" Text="Pit Req."
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxCoPitLocation" runat="server" SkinID="CheckBoxSmall" Text="CO/Pit Location"
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxCoInstalled" runat="server" SkinID="CheckBoxSmall" Text="C/O Installed"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxBackfilledConcrete" runat="server" SkinID="CheckBoxSmall" Text="Backfilled Con."
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxBackfilledSoil" runat="server" SkinID="CheckBoxSmall" Text="Backfilled Soil"
                        EnableViewState="False" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxGrouted" runat="server" SkinID="CheckBoxSmall" Text="Grouted"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxCored" runat="server" SkinID="CheckBoxSmall" Text="Cored" 
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxPrepped" runat="server" SkinID="CheckBoxSmall" Text="Prepped"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxPreVideo" runat="server" SkinID="CheckBoxSmall" Text="Pre-Video"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxMeasured" runat="server" SkinID="CheckBoxSmall" Text="Measured"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxLinerSize" runat="server" SkinID="CheckBoxSmall" Text="Liner Size"
                        EnableViewState="false" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxLiningThruCo" runat="server" SkinID="CheckBoxSmall" Text="Lining Thru C/O"
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxNoticeDelivered" runat="server" SkinID="CheckBoxSmall" Text="Notice Delivered"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxInProcess" runat="server" SkinID="CheckBoxSmall" Text="In Process"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxInStock" runat="server" SkinID="CheckBoxSmall" Text="In Stock"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxDelivered" runat="server" SkinID="CheckBoxSmall" Text="Delivered"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxLinerInstalled" runat="server" SkinID="CheckBoxSmall" Text="Liner Installed"
                        EnableViewState="False" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxFinalVideo" runat="server" SkinID="CheckBoxSmall" Text="Final Video"
                        EnableViewState="False" /></td>
                <td>
                    <asp:CheckBox ID="cbxDistanceFromUSMH" runat="server" SkinID="CheckBoxSmall" Text="Dist. From USMH"
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxDistanceFromDSMH" runat="server" SkinID="CheckBoxSmall" Text="Dist. From DSMH"
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxPostContractDigRequired" runat="server" SkinID="CheckBoxSmall" Text="Post Contract Dig?" 
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxCoCutDown" runat="server" SkinID="CheckBoxSmall" Text="C/O Cut Down?"
                        EnableViewState="false" /></td>
                <td>
                    <asp:CheckBox ID="cbxFinalRestoration" runat="server" SkinID="CheckBoxSmall" Text="Final Restoration"
                        EnableViewState="false" /></td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxCost" runat="server" SkinID="CheckBoxSmall" Text="Cost" 
                        EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxBuidRebuid" runat="server" SkinID="CheckBoxSmall" Text="Build / Rebuild #" 
                        EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxComments" runat="server" SkinID="CheckBoxSmall" Text="Comments"
                        EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHistory" runat="server" SkinID="CheckBoxSmall" Text="History"
                        EnableViewState="False" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="color: #2f82c7; height: 1px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        
        <!-- Page element: Section title - Search & Sort by-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSearchSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Search & Sort -->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnbSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="lblCondition1" runat="server" EnableViewState="False" SkinID="Label" Text="Condition 1"></asp:Label>
                    </td>
                    <td style="width: 180px">
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 128px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" EnableViewState="False" SkinID="DropDownList" Width="115px">
                            <asp:ListItem Value="MA.RecordID + '-' + JL.DetailID">ID</asp:ListItem>
                            <asp:ListItem Value="JL.ClientLateralID">Client Lateral ID</asp:ListItem>
                            <asp:ListItem Value="JL.HamiltonInspectionNumber">Hamilton Insp.#</asp:ListItem>
                            <asp:ListItem Value="MA.Street">Street</asp:ListItem>
                            <asp:ListItem Value="JL.Address">Address</asp:ListItem>
                            <asp:ListItem Value="MA.USMH">USMH</asp:ListItem>
                            <asp:ListItem Value="MA.DSMH">DSMH</asp:ListItem>
                            <asp:ListItem Value="JL.VideoInspection">Video Inspection</asp:ListItem>
                            <asp:ListItem Value="JL.VideoLengthToPropertyLine">Video Length To Property Line</asp:ListItem>
                            <asp:ListItem Value="JL.PipeLocated">Pipe Located</asp:ListItem>
                            <asp:ListItem Value="JL.ServicesLocated">Services Located</asp:ListItem>
                            <asp:ListItem Value="JL.CoRequired">C/O Req.</asp:ListItem>
                            <asp:ListItem Value="JL.PitRequired">Pit Req.</asp:ListItem>
                            <asp:ListItem Value="JL.CoPitLocation">CO/Pit Location</asp:ListItem>
                            <asp:ListItem Value="JL.CoInstalled">C/O Installed</asp:ListItem>
                            <asp:ListItem Value="JL.BackfilledConcrete">Backfilled Con.</asp:ListItem>
                            <asp:ListItem Value="JL.BackfilledSoil">Backfilled Soil</asp:ListItem>
                            <asp:ListItem Value="JL.Grouted">Grouted</asp:ListItem>
                            <asp:ListItem Value="JL.Cored">Cored</asp:ListItem>
                            <asp:ListItem Value="JL.Prepped">Prepped</asp:ListItem>
                            <asp:ListItem Value="JL.PreVideo">Pre-Video</asp:ListItem>
                            <asp:ListItem Value="JL.Measured">Measured</asp:ListItem>
                            <asp:ListItem Value="JL.LiningThruCo">Lining Thru C/O</asp:ListItem>
                            <asp:ListItem Value="JL.NoticeDelivered">Notice Delivered</asp:ListItem>
                            <asp:ListItem Value="JL.InProcess">In Process</asp:ListItem>
                            <asp:ListItem Value="JL.InStock">In Stock</asp:ListItem>
                            <asp:ListItem Value="JL.Delivered">Delivered</asp:ListItem>
                            <asp:ListItem Value="JL.LinerInstalled">Liner Installed</asp:ListItem>
                            <asp:ListItem Value="JL.FinalVideo">Final Video</asp:ListItem>
                            <asp:ListItem Value="JL.PostContractDigRequired">Post Contract Dig?</asp:ListItem>
                            <asp:ListItem Value="JL.CoCutDown">C/O Cut Down?</asp:ListItem>
                            <asp:ListItem Value="JL.FinalRestoration">Final Restoration</asp:ListItem>
                            <asp:ListItem Value="JL.BuildRebuild">Build / Rebuild #</asp:ListItem>
                            <asp:ListItem Value="JL.Comments">Comments</asp:ListItem>
                            <asp:ListItem Value="JL.History">History</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator1" runat="server" EnableViewState="False" SkinID="DropDownList" Width="170px">
                            <asp:ListItem Value="=" Text="equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;&gt;" Text="not"></asp:ListItem>
                            <asp:ListItem Value="&gt;" Text="greater than"></asp:ListItem>
                            <asp:ListItem Value="'&gt;='" Text="greater than &amp; equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;" Text="less than"></asp:ListItem>
                            <asp:ListItem Value="'&lt;='" Text="less than &amp; equals to"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="tbxCondition1" runat="server" SkinID="TextBox" Width="435px" EnableViewState="False">%</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvInvalidOperator1" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator1_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperatorForBoolean1" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator (use "equals to")'
                            OnServerValidate="cvInvalidOperatorForBoolean1_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date (use a date over 1900)" 
                            OnServerValidate="cvForDateRange_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                    
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid data (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid data (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 4px">
                    </td>
                    <td style="height: 4px">
                    </td>
                    <td style="height: 4px">
                    </td>
                    <td style="height: 4px">
                    </td>
                    <td style="height: 4px">
                    </td>
                    <td style="height: 4px; width: 128px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCondition2" runat="server" EnableViewState="False" SkinID="Label" Text="And Condition 2"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition2" runat="server" EnableViewState="False" SkinID="DropDownList" Width="115px">
                            <asp:ListItem Value=""> </asp:ListItem>
                            <asp:ListItem Value="MA.RecordID + '-' + JL.DetailID">ID</asp:ListItem>
                            <asp:ListItem Value="JL.ClientLateralID">Client Lateral ID</asp:ListItem>
                            <asp:ListItem Value="JL.HamiltonInspectionNumber">Hamilton Insp.#</asp:ListItem>
                            <asp:ListItem Value="MA.Street">Street</asp:ListItem>
                            <asp:ListItem Value="JL.Address">Address</asp:ListItem>
                            <asp:ListItem Value="MA.USMH">USMH</asp:ListItem>
                            <asp:ListItem Value="MA.DSMH">DSMH</asp:ListItem>
                            <asp:ListItem Value="JL.VideoInspection">Video Inspection</asp:ListItem>
                            <asp:ListItem Value="JL.VideoLengthToPropertyLine">Video Length To Property Line</asp:ListItem>
                            <asp:ListItem Value="JL.PipeLocated">Pipe Located</asp:ListItem>
                            <asp:ListItem Value="JL.ServicesLocated">Services Located</asp:ListItem>
                            <asp:ListItem Value="JL.CoRequired">C/O Req.</asp:ListItem>
                            <asp:ListItem Value="JL.PitRequired">Pit Req.</asp:ListItem>
                            <asp:ListItem Value="JL.CoPitLocation">CO/Pit Location</asp:ListItem>
                            <asp:ListItem Value="JL.CoInstalled">C/O Installed</asp:ListItem>
                            <asp:ListItem Value="JL.BackfilledConcrete">Backfilled Con.</asp:ListItem>
                            <asp:ListItem Value="JL.BackfilledSoil">Backfilled Soil</asp:ListItem>
                            <asp:ListItem Value="JL.Grouted">Grouted</asp:ListItem>
                            <asp:ListItem Value="JL.Cored">Cored</asp:ListItem>
                            <asp:ListItem Value="JL.Prepped">Prepped</asp:ListItem>
                            <asp:ListItem Value="JL.PreVideo">Pre-Video</asp:ListItem>
                            <asp:ListItem Value="JL.Measured">Measured</asp:ListItem>
                            <asp:ListItem Value="JL.LiningThruCo">Lining Thru C/O</asp:ListItem>
                            <asp:ListItem Value="JL.NoticeDelivered">Notice Delivered</asp:ListItem>
                            <asp:ListItem Value="JL.InProcess">In Process</asp:ListItem>
                            <asp:ListItem Value="JL.InStock">In Stock</asp:ListItem>
                            <asp:ListItem Value="JL.Delivered">Delivered</asp:ListItem>
                            <asp:ListItem Value="JL.LinerInstalled">Liner Installed</asp:ListItem>
                            <asp:ListItem Value="JL.FinalVideo">Final Video</asp:ListItem>
                            <asp:ListItem Value="JL.PostContractDigRequired">Post Contract Dig?</asp:ListItem>
                            <asp:ListItem Value="JL.CoCutDown">C/O Cut Down?</asp:ListItem>
                            <asp:ListItem Value="JL.FinalRestoration">Final Restoration</asp:ListItem>
                            <asp:ListItem Value="JL.BuildRebuild">Build / Rebuild #</asp:ListItem>
                            <asp:ListItem Value="JL.Comments">Comments</asp:ListItem>
                            <asp:ListItem Value="JL.History">History</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator2" runat="server" EnableViewState="False" SkinID="DropDownList" Width="170px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="=" Text="equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;&gt;" Text="not"></asp:ListItem>
                            <asp:ListItem Value="&gt;" Text="greater than"></asp:ListItem>
                            <asp:ListItem Value="'&gt;='" Text="greater than &amp; equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;" Text="less than"></asp:ListItem>
                            <asp:ListItem Value="'&lt;='" Text="less than &amp; equals to"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="tbxCondition2" runat="server" EnableViewState="False" SkinID="TextBox" Width="435px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvDeleteOperator2" runat="server" ControlToValidate="tbxCondition2"
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please delete the operator"
                            OnServerValidate="cvDeleteOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage='Invalid operator (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvSelectOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Please select an operator" OnServerValidate="cvSelectOperator2_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperatorForBoolean2" runat="server" ControlToValidate="tbxCondition1"
                            Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator (use "equals to")'
                            OnServerValidate="cvInvalidOperatorForBoolean2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvDeleteCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Please delete text" 
                            OnServerValidate="cvDeleteCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDateCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRangeCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date (use a date over 1900)"
                            OnServerValidate="cvForDateRangeCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBooleanCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data (use Y, YES, N, NO, % or leave the field empty)" 
                            OnServerValidate="cvForBooleanCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForNumberCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid data (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
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
                    <td style="width: 128px">
                    </td>
                </tr>
            </table>
            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="lblIssues" runat="server" EnableViewState="False" Text="Issues" SkinID="Label"></asp:Label>
                    </td>
                    <td style="width: 180px">
                        <asp:Label ID="lblSubArea" runat="server" EnableViewState="false" SkinID="Label" Text="Sub Area"></asp:Label>
                    </td>
                    <td style="width: 125px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 97.5px">
                    </td>
                    <td style="width: 97.5px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIssues" runat="server" EnableViewState="False" SkinID="DropDownList" Width="115px">
                            <asp:ListItem Value="(All)">(All)</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                            <asp:ListItem Value="Out Of Scope">Out Of Scope</asp:ListItem>
                            <asp:ListItem Value="Dig Required Prior To Lining">Dig Req'd Prior To Lining</asp:ListItem>
                            <asp:ListItem Value="Hold - Client Issue">Hold - Client Issue</asp:ListItem>
                            <asp:ListItem Value="Hold - LFS Issue">Hold - LFS Issue</asp:ListItem>
                            <asp:ListItem Value="Dig Required After Lining">Dig Req'd After Lining</asp:ListItem>
                            <asp:ListItem Value="Robotic Prep Required">Robotic Prep Req’d</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubArea" runat="server" SkinID="DropDownList" Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" EnableViewState="False" SkinID="DropDownList"
                            Width="115px">
                            <asp:ListItem Value="MA.RecordID, JL.DetailID">ID</asp:ListItem>
                            <asp:ListItem Value="JL.Address">Address</asp:ListItem>
                            <asp:ListItem Value="MA.Street, JL.Address">Street</asp:ListItem>
                            <asp:ListItem Value="MA.SubArea">Sub Area</asp:ListItem>
                            <asp:ListItem>Date</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnbSearch" runat="server" EnableViewState="False" SkinID="Button" Text="Search" Width="80px" OnClick="btnbSearch_Click" />
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
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <!-- Page element: Horizontal Rule -->
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="color: #2f82c7; height: 1px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        
        <!-- Page element : Toolbar -->
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mAddJunctionLiners" Text="ADD LATERALS" />
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

        <!-- Page element : No results bar -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <div>
                        <asp:Panel ID="pNoResults" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 750px; height: 28px">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #C8DBED; vertical-align: middle">
                                        <asp:Label ID="lblNoResults" runat="server" SkinID="LabelError" Text="No results for your query"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="height: 43px">
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>