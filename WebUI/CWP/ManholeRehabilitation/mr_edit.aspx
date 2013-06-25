<%@ Page Language="C#" MasterPageFile="../../mForm8.master" AutoEventWireup="true" CodeBehind="mr_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation.mr_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">   
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Manhole Rehabilitation Summary" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 70px">                    
                </td>
                <td style="width: 10px">
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
                <td>
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="True" OnClick="btnChange_Click" />
                </td>
                <td style="width: 10px">
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
                            <telerik:RadPanelItem Expanded="True" Text="Manhole Rehabilitation" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAddManhole" Text="Add Manhole"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mAddBatch" Text="Add Batch" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mSummaryReport" Text="Summary Report" ></telerik:RadPanelItem>
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
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                    <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;">  
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Table element: 1 columns - Manhole Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblManholeDetails" runat="server" SkinID="LabelTitle1" Text="Manhole Details" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Manhole Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblManholeNumber" runat="server" EnableViewState="True" SkinID="Label" Text="Manhole #"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxManholeNumber" runat="server" EnableViewState="True" SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 115px"></asp:TextBox>                      
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
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="True" SkinID="Label" Text="Street"></asp:Label>
                </td>                
                <td>
                    <asp:Label ID="lblLatitude" runat="server" EnableViewState="True" SkinID="Label" Text="Latitude"></asp:Label>                    
                </td>
                <td>
                    <asp:Label ID="lblLongitude" runat="server" EnableViewState="True" SkinID="Label" Text="Longitude"></asp:Label>                    
                </td>
                <td>
                    <asp:Label ID="lblShape" runat="server" EnableViewState="True" SkinID="Label" Text="Shape"></asp:Label>                    
                </td>
                <td>
                    <asp:Label ID="lblConditionRating" runat="server" EnableViewState="False" SkinID="Label" Text="Condition Rating"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>                
                <td>
                    <asp:TextBox ID="tbxLatitude" runat="server" SkinID="TextBox" Style="width: 115px"></asp:TextBox>                    
                </td>
                <td>
                    <asp:TextBox ID="tbxLongitude" runat="server" SkinID="TextBox" Style="width: 115px"></asp:TextBox>                    
                </td>
                <td>
                    <asp:UpdatePanel ID="uplShape" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlShape" runat="server" DataMember="DefaultView"
                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                SkinID="DropDownList" Style="width: 115px" AutoPostBack="true" OnSelectedIndexChanged="ddlShape_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                     <asp:DropDownList ID="ddlConditioningRating" runat="server" DataMember="DefaultView"
                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                        SkinID="DropDownList" Style="width: 115px" >
                    </asp:DropDownList>
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
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMaterial" runat="server" EnableViewState="False" SkinID="Label" Text="Material"></asp:Label></td>
                <td>
                    <asp:Label ID="lblLocation" runat="server" EnableViewState="False" SkinID="Label" Text="Location"></asp:Label></td>
                <td>
                </td>
                <td></td>                                               
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddlMaterial" runat="server" DataMember="DefaultView"
                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                        SkinID="DropDownList" Style="width: 240px" >
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLocation" runat="server" DataMember="DefaultView"
                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                        SkinID="DropDownList" Style="width: 115px" >
                    </asp:DropDownList>
                </td>
                <td>                   
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
                
        
        <!-- Table element: 6 columns - Rehabilitation Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblManholeRehabilitationDetails" runat="server" SkinID="LabelTitle1" Text="Rehabilitation Details" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Tab Control -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <!-- Page element : Tab control -->
                    <cc1:TabContainer ID="tcMrDetails" runat="server" Width="730px" ActiveTabIndex="0" CssClass="ajax_tabcontainer">
                        <cc1:TabPanel ID="tpRehabilitationData" runat="server" HeaderText="Rehabilitation Data" OnClientClick="tpMrRehabilitationDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 6 columns Setup information -->
                                    <asp:UpdatePanel ID="upnlWorkData" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnlWorkData" runat="server">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 118px; height: 10px;">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:Label ID="lblRehabilitationData" runat="server" SkinID="LabelTitle2" 
                                                                Text="Rehabilitation Data"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataPreppedDate" runat="server" SkinID="Label" 
                                                                Text="Prepped Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataSprayedDate" runat="server" SkinID="Label" 
                                                                Text="Sprayed Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBatchDate" runat="server" SkinID="Label" Text="Batch Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLastBatchDate" runat="server" SkinID="Label" 
                                                                Text="Last Batch Date"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadDatePicker ID="tkrdpRehabilitationPreppedDate" runat="server" 
                                                                Culture="English (United States)" SkinID="RadDatePicker" Width="108px">
                                                                <calendar daynameformat="Short" showrowheaders="False" 
                                                                usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                                viewselectortext="x"></calendar>

                                                                <dateinput dateformat="M/d/yyyy" displaydateformat="M/d/yyyy" width=""></dateinput>

                                                                <datepopupbutton cssclass="" hoverimageurl="" imageurl="" />
                                                                </telerik:RadDatePicker>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="uptkrdpRehabilitationSprayedDate" runat="server">
                                                                <ContentTemplate>
                                                                    <telerik:RadDatePicker ID="tkrdpRehabilitationSprayedDate" runat="server" 
                                                                        AutoPostBack="true" Culture="English (United States)" 
                                                                        onselecteddatechanged="tkrdpRehabilitationSprayedDate_SelectedDateChanged" 
                                                                        SkinID="RadDatePicker" Width="108px">
                                                                        <calendar daynameformat="Short" showrowheaders="False" 
                                                                        usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                                        viewselectortext="x"></calendar>

                                                                        <dateinput dateformat="M/d/yyyy" displaydateformat="M/d/yyyy" width=""></dateinput>

                                                                        <datepopupbutton cssclass="" hoverimageurl="" imageurl="" />
                                                                        </telerik:RadDatePicker>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="upRehabilitationBatchDate" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRehabilitationBatchDate" runat="server" DataMember="DefaultView" EnableViewState="true" 
                                                                        SkinID="DropDownList" Style="width: 226px" AutoPostBack="true" OnSelectedIndexChanged="ddlRehabilitationBatchDate_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>                                                        
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLastRehabilitationBatchDate" runat="server" ReadOnly="true" 
                                                                SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                            <asp:HiddenField ID="hdfBatchId" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="upNotLastBatch" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblNotLastBatch" runat="server" SkinID="LabelError" 
                                                                        Text="Are you sure you want to use a non current batch?"></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationBatchDate" runat="server" 
                        SkinID="Validator" ValidationGroup="rehabilitationData" ErrorMessage="Please select a batch date."
                        Display="Dynamic" ControlToValidate="ddlRehabilitationBatchDate" 
                        InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlBatchDateRequired" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblBatchDateRequired" runat="server" SkinID="LabelError" 
                                                                        Text="Please provide a date with the Add Batch tool."></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 7px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <!-- Page element : Horizontal Rule -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_Separator" style="height: 2px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element: 6 columns Manhole structucture -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblManholeStructure" runat="server" SkinID="LabelTitle2" 
                                                    Text="Manhole Structure"></asp:Label>
                                                <asp:Label ID="lblMessage" runat="server" SkinID="LabelError" 
                                                    Text="  (All measurements round up to nearest foot)"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:CheckBox ID="ckbxRehabilitationDataImperial" runat="server" 
                                                    SkinID="CheckBox" Text="Imperial" Checked="true" />
                                            </td>
                                            <td></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4"></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="upnlShapes" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnlInformationRoundMH" runat="server">
                                                <!-- Table element: 6 columns structure information -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataRoundStructureTitle" runat="server" 
                                                                SkinID="LabelTitle2" Text="Surface Area of Round MH"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" rowspan="17">
                                                            <asp:UpdatePanel ID="upnlShapeGraphic" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pnlRoundGraphic" runat="server" Height="200px" ScrollBars="None" 
                                                                        SkinID="MrRoundShapePanel" Width="180px">
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr style="height:10px">
                                                                                            <td style="width: 60px">
                                                                                            </td>
                                                                                            <td style="width: 70px">
                                                                                            </td>
                                                                                            <td style="width: 50px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudChimneyDiameterLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudChimneyCeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRoudChimneyDepthLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoundChimneySurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align:left; height:10px;">
                                                                                                <asp:Label ID="lblRoundTotalDepthLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoundBarrelCeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRoudBarrelDepthLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoundBarrelSurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudBarrelDiameterLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" style="height:10px; text-align:center">
                                                                                                <asp:Label ID="lblRoundTotalSurfaceArea" runat="server" SkinID="LabelSmall" 
                                                                                                    Text="Total Surface Area: "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyDiameter" runat="server" 
                                                                SkinID="Label" Text="Chimney Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyDepth" runat="server" SkinID="Label" 
                                                                Text="Chimney Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyFloor" runat="server" SkinID="Label" 
                                                                Text="Chimney Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyCeiling" runat="server" 
                                                                SkinID="Label" Text="Chimney Ceiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyDiameter" runat="server" 
                                                                SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyDepth" runat="server" 
                                                                SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataChimneyFloor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataChimneyFloor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataChimneyFloor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataChimneyCeiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataChimneyCeiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataChimneyCeiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataChimneyDiameter" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataChimneyDiameter" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the chimney diameter" SkinID="Validator" 
                                                                ValidationGroup="mrRoundShape">
                                                           </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataChimneyDiameter" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataChimneyDiameter" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataChimneyDiameter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRoundShape">
                                                           </asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataChimneyDepth" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataChimneyDepth" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the chimney depth" SkinID="Validator" 
                                                                ValidationGroup="mrRoundShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataChimneyDepth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataChimneyDepth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataChimneyDepth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRoundShape">
                                                           </asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyBenching" runat="server" SkinID="Label" Text="Chimney Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneySurfaceArea" runat="server" SkinID="LabelSmall" Text="Chimney Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyTotalSurfaceArea" runat="server" SkinID="LabelSmall" Text="Total Chimney Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataChimneyBenching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataChimneyBenching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataChimneyBenching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataChimneySurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataChimneySurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataChimneyTotalSurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataChimneyTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelDiameter" runat="server" 
                                                                SkinID="Label" Text="Barrel Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelDepth" runat="server" SkinID="Label" 
                                                                Text="Barrel Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelFloor" runat="server" SkinID="Label" 
                                                                Text="Barrel Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelCeiling" runat="server" 
                                                                SkinID="Label" Text="Barrel Ceiling "></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelDiameter" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelDiameter" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelDepth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelDepth" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlehabilitationDataBarrelFloor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataBarrelFloor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelFloor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelCeiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataBarrelCeiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelCeiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataBarrelDiameter" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataBarrelDiameter" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the barrel diameter" SkinID="Validator" 
                                                                ValidationGroup="mrRoundShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataBarrelDiameter" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataBarrelDiameter" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataBarrelDiameter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRoundShape">
                                                            </asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataBarrelDepth" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataBarrelDepth" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the barrel depth" SkinID="Validator" 
                                                                ValidationGroup="mrRoundShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataBarrelDepth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataBarrelDepth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataBarrelDepth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRoundShape"></asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelBenching" runat="server" 
                                                                SkinID="Label" Text="Barrel Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelSurfaceArea" runat="server" 
                                                                SkinID="Label" Text="Barrel Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelTotalSurfaceArea" runat="server" 
                                                                SkinID="Label" Text="Total Barrel Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelManholeRugs" runat="server" 
                                                                SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelBenching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataBarrelBenching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelBenching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelSurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBarrelTotalSurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataBarrelTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRehabilitationDataRoundManholeRugs" runat="server" 
                                                                DataMember="DefaultView" DataSourceID="odsRugs" DataTextField="ManholeRugs" 
                                                                DataValueField="ManholeRugsId" SkinID="DropDownListLookupBlueText" 
                                                                Style="width: 115px">
                                                            </asp:DropDownList>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundTotalDepth" runat="server" 
                                                                SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundTotalSurfaceArea" runat="server" 
                                                                SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationataRoundTotalDepth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundTotalDepth" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundTotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 592px">
                                                        </td>
                                                        <td align="right" style="width: 106px">
                                                            <asp:UpdateProgress ID="upRoundShape" runat="server" 
                                                                AssociatedUpdatePanelID="upnlBtnRoundShape">
                                                                <ProgressTemplate>
                                                                    <img height="16" src="../../common/images/ajax1.gif" width="16" />
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:UpdatePanel ID="upnlBtnRoundShape" runat="server">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnRoundShape" EventName="Click" />
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnRoundShape" runat="server" EnableViewState="True" 
                                                                        OnClick="btnRoundShapeOnClick" SkinID="Button" Text="Calculate" Width="80px" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInformationRectangularMH" runat="server">
                                                <!-- Table element: 6 columns structure information -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataRectangularStructureTitle" runat="server" 
                                                                SkinID="LabelTitle2" Text="Surface Area of Rectangular MH"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" rowspan="17">
                                                            <asp:UpdatePanel ID="upnlMrRectangularShape" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pnlMrRectangularGraphic" runat="server" Height="200px" 
                                                                        ScrollBars="None" SkinID="MrRectangularShapePanel" Width="180px">
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr style="height:3px">
                                                                                            <td style="width: 40px">
                                                                                            </td>
                                                                                            <td style="width: 110px">
                                                                                            </td>
                                                                                            <td style="width: 30px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1ShortSideLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1CeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1LongSideLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangle1SurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1DephtLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align:left; height:10px;">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular2CeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                                <asp:Label ID="lblRectangularTotalDepthLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRectangle2LongSideLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangle2SurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular2Depth" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular2ShortSideLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" style="height:10px; text-align:center">
                                                                                                <asp:Label ID="lblRectangularTotalSurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text="Total Surface Area: "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1LongSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle 1 Long Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1ShortSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle 1 Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Depth" runat="server" 
                                                                SkinID="Label" Text="Rectangle 1 Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Floor" runat="server" 
                                                                SkinID="Label" Text="Rectangle 1 Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlLRehabilitationDataRectangle1LongSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1LongSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1ShortSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1ShortSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1Depth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1Depth" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1Floor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Floor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1Floor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle1LongSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle1LongSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the long side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle1LongSide" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangle1LongSide" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle1LongSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle1ShortSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle1ShortSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the short side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle1ShortSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle1ShortSide" 
                                                                Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle1ShortSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle1Depth" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle1Depth" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the depth" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle1Depth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangle1Depth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle1Depth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Ceiling" runat="server" SkinID="Label" Text="Rectangle 1 Ceiling"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Benching" runat="server" SkinID="LabelSmall" Text="Rectangle 1 Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1SurfaceArea" runat="server" SkinID="LabelSmall" Text="Rectangle 1 Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1TotalSurfaceArea" runat="server" SkinID="LabelSmall" Text="Total Rectangle 1 Surface Area"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1Ceiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Ceiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1Ceiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1Benching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Benching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1Benching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1SurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1SurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle1TotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle1TotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2LongSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle 2 Long Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2ShortSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle 2 Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Depth" runat="server" 
                                                                SkinID="Label" Text="Rectangle 2 Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Floor" runat="server" 
                                                                SkinID="Label" Text="Rectangle 2 Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2LongSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2LongSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2ShortSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2ShortSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2Depth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2Depth" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2Floor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Floor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2Floor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle2LongSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle2LongSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the long side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle2LongSide" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangle2LongSide" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle2LongSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle2ShortSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle2ShortSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the short side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle2ShortSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle2ShortSide" 
                                                                Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle2ShortSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangle2Depth" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangle2Depth" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the depth" SkinID="Validator" 
                                                                ValidationGroup="mrRectangularShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangle2Depth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangle2Depth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangle2Depth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrRectangularShape"></asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Ceiling" runat="server" 
                                                                SkinID="Label" Text="Rectangle 2 Ceiling"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Benching" runat="server" 
                                                                SkinID="LabelSmall" Text="Rectangle 2 Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2SurfaceArea" runat="server" 
                                                                SkinID="LabelSmall" Text="Rectangle 2 Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2TotalSurfaceArea" runat="server" 
                                                                SkinID="LabelSmall" Text="Total Rectangle 2 Surface Area"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2Ceiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Ceiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2Ceiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2Benching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Benching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2Benching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2SurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2SurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangle2TotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangle2TotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularManholeRugs" runat="server" 
                                                                SkinID="LabelSmall" Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularTotalDepth" runat="server" 
                                                                SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularTotalSurfaceArea" runat="server" 
                                                                SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRehabilitationDataRectangularManholeRugs" 
                                                                runat="server" DataMember="DefaultView" DataSourceID="odsRugs" 
                                                                DataTextField="ManholeRugs" DataValueField="ManholeRugsId" 
                                                                SkinID="DropDownListLookupBlueText" Style="width: 115px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangularTotalDepth" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangularTotalDepth" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangularTotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangularTotalSurfaceArea" 
                                                                        runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 592px">
                                                        </td>
                                                        <td align="right" style="width: 106px">
                                                            <asp:UpdateProgress ID="upRectangularShape" runat="server" 
                                                                AssociatedUpdatePanelID="upnlBtnRectangularShape">
                                                                <ProgressTemplate>
                                                                    <img height="16" src="../../common/images/ajax1.gif" width="16" />
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:UpdatePanel ID="upnlBtnRectangularShape" runat="server">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnRectangularShape" EventName="Click" />
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnRectangularShape" runat="server" EnableViewState="True" 
                                                                        OnClick="btnRectangularShapeOnClick" SkinID="Button" Text="Calculate" 
                                                                        Width="80px" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInformationMixedMH" runat="server">
                                                <!-- Table element: 6 columns structure information -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataMixedStructureTitle" runat="server" 
                                                                SkinID="LabelTitle2" Text="Surface Area of Mixed MH"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" rowspan="17">
                                                            <asp:UpdatePanel ID="upnlMixedGraphic" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pnlMixedGraphic" runat="server" Height="200px" ScrollBars="None" 
                                                                        SkinID="MrMixedShapePanel" Width="180px">
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr style="height:10px">
                                                                                            <td style="width: 60px">
                                                                                            </td>
                                                                                            <td style="width: 70px">
                                                                                            </td>
                                                                                            <td style="width: 50px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleShortSideLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleCeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleLongSideLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleSurfaceAreaLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRectangleDephtLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="text-align:left; height:10px;">
                                                                                                <asp:Label ID="lblMixedTotalDepthLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblDataRoundCeilingLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblDataRoundDepthLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblDataRoundSurfaceAreaLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblDataRoundDiameterLabel" runat="server" SkinID="LabelSmall" 
                                                                                                    Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" style="height:10px; text-align:center">
                                                                                                <asp:Label ID="lblTotalMixedSurfaceAreaLabel" runat="server" 
                                                                                                    SkinID="LabelSmall" Text="Total Surface Area: "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundDiameter" runat="server" 
                                                                SkinID="Label" Text="Round Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundDepth" runat="server" SkinID="Label" 
                                                                Text="Round Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundFloor" runat="server" SkinID="Label" 
                                                                Text="Round Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundCeiling" runat="server" SkinID="Label" 
                                                                Text="Round Ceiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundDiameter" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundDiameter" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundDepth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundDepth" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundFloor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRoundFloor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundFloor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundCeiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRoundCeiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundCeiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRoundDiameter" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRoundDiameter" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the diameter" SkinID="Validator" 
                                                                ValidationGroup="mrMixedShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRoundDiameter" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRoundDiameter" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRoundDiameter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRoundDepth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRoundDepth" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please provide the depth" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRoundDepth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRoundDepth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRoundDepth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundBenching" runat="server" SkinID="Label" Text="Round Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundSurfaceArea" runat="server" SkinID="Label" Text="Round Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataMixedRoundTotalSurfaceArea" runat="server" SkinID="Label" Text="Total Round Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundBenching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRoundBenching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundBenching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRoundSurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRoundSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataMixedRoundTotalSurfaceArea" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataMixedRoundTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleLongSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle Long Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleShortSide" runat="server" 
                                                                SkinID="Label" Text="Rectangle Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleDepth" runat="server" 
                                                                SkinID="Label" Text="Rectangle Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleFloor" runat="server" 
                                                                SkinID="Label" Text="Rectangle Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangleLongSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleLongSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangleShortSide" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleShortSide" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangleDepth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleDepth" runat="server" 
                                                                        SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangleFloor" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangleFloor" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleFloor" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangleLongSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangleLongSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the long side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrMixedShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangleLongSide" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangleLongSide" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangleLongSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangleShortSide" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangleShortSide" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the short side measurement" SkinID="Validator" 
                                                                ValidationGroup="mrMixedShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangleShortSide" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangleShortSide" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangleShortSide_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataRectangleDepth" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataRectangleDepth" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the depth" SkinID="Validator" 
                                                                ValidationGroup="mrMixedShape"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataRectangleDepth" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataRectangleDepth" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataRectangleDepth_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrMixedShape"></asp:CustomValidator>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleCeiling" runat="server" 
                                                                SkinID="Label" Text="Rectangle Ceiling"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBenching" runat="server" SkinID="LabelSmall" 
                                                                Text="Rectangle Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularSufaceArea" runat="server" 
                                                                SkinID="LabelSmall" Text="Rectangle Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataMixedRectangleTotalSurfaceArea" runat="server" 
                                                                SkinID="LabelSmall" Text="Total Rectangle Surface Area"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangleCeiling" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangleCeiling" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleCeiling" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataBenching" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbxRehabilitationDataRectangleBenching" runat="server" 
                                                                        SkinID="CheckBox" />
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleBenching" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataRectangularSufaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataRectangleSufaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataMixedRectangleTotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataMixedRectangleTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataManholeRugs" runat="server" SkinID="Label" 
                                                                Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataMixedTotalDepth" runat="server" 
                                                                SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataMixedTotalSurfaceArea" runat="server" 
                                                                SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRehabilitationDataMixManholeRugs" runat="server" 
                                                                DataMember="DefaultView" DataSourceID="odsRugs" DataTextField="ManholeRugs" 
                                                                DataValueField="ManholeRugsId" SkinID="DropDownListLookupBlueText" 
                                                                Style="width: 115px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataMixedTotalDepth" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataMixedTotalDepth" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataMixedTotalSurfaceArea" 
                                                                runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataMixedTotalSurfaceArea" runat="server" 
                                                                        SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 592px">
                                                        </td>
                                                        <td align="right" style="width: 106px">
                                                            <asp:UpdateProgress ID="upMixedShape" runat="server" 
                                                                AssociatedUpdatePanelID="upnlBtnMixedShape">
                                                                <ProgressTemplate>
                                                                    <img height="16" src="../../common/images/ajax1.gif" width="16" />
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:UpdatePanel ID="upnlBtnMixedShape" runat="server">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnMixedShape" EventName="Click" />
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnMixedShape" runat="server" EnableViewState="True" 
                                                                        OnClick="btnMixedShapeOnClick" SkinID="Button" Text="Calculate" Width="80px" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInformationOtherMH" runat="server">
                                                <!-- Table element: 6 columns structure information -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataOtherStructureTitle" runat="server" 
                                                                SkinID="LabelTitle2" Text="Surface Area of MH"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" rowspan="15">
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataOtherStructure" runat="server" 
                                                                SkinID="Label" Text="Total Surface Area"></asp:Label>
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
                                                            <asp:UpdatePanel ID="upnlRehabilitationDataOtherStructure" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRehabilitationDataOtherStructure" runat="server" 
                                                                        AutoPostBack="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                            <asp:RequiredFieldValidator ID="rfvRehabilitationDataOtherStructure" 
                                                                runat="server" ControlToValidate="tbxRehabilitationDataOtherStructure" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide the total surface area" SkinID="Validator" 
                                                                ValidationGroup="mrOtherStructure"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cvRehabilitationDataOtherStructure" runat="server" 
                                                                ControlToValidate="tbxRehabilitationDataOtherStructure" Display="Dynamic" 
                                                                ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                OnServerValidate="cvRehabilitationDataOtherStructure_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="mrOtherStructure"></asp:CustomValidator>
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
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <!-- Page element : Horizontal Rule -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_Separator" style="height: 2px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element: 6 columns  -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 148px">
                                            </td>
                                            <td style="width: 90px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblcommentsTitle" runat="server" SkinID="LabelTitle2" 
                                                    Text="Comments"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCommentsDataComments" runat="server" SkinID="Label" 
                                                    Text="Comments Summary"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlComments" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnComments" runat="server" EnableViewState="True" 
                                                            OnClick="btnCommentsOnClick" SkinID="Button" Text="Update" Width="80px" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" ReadOnly="True" 
                                                    Rows="20" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
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
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                    
                    <asp:ObjectDataSource ID="odsShape" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHShapeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="shape" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>       
                                        
                    <asp:ObjectDataSource ID="odsLocation" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="location" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsRugs" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHRugsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="manholeRugsId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="manholeRugs" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsConditionRating" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerMHConditionRatingList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="conditionRatingId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="conditionRating" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHMaterialTypeList">
                        <SelectParameters>                            
                            <asp:Parameter DefaultValue="-1" Name="materialId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="materialType" Type="String" />
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
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfImperialType" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfManholeId" runat="server" />                                        
                    <asp:HiddenField ID="hdfInProject" runat="server" />
                    <asp:HiddenField ID="hdfErrorFieldList" runat="server" />
                    <asp:HiddenField ID="hdfSavedShape" runat="server" />                    

                    <asp:HiddenField ID="hdfExistBatchId" runat="server" />                    

                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Conten5" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">
                        <items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="FooterSpacePlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Page element : Footer separation -->
        <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
