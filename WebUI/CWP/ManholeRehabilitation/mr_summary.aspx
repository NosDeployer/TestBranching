<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="mr_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation.mr_summary" Title="LFS Live" %>

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
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click" />
                </td>
                <td>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" >                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />                            
                           
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;" >                       
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" /> 
                                                       
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style="width:10px">
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
                    <asp:Label ID="lblManholeDetails" runat="server" SkinID="LabelTitle1" Text="Manhole Details" EnableViewState="False"></asp:Label>
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
                    <asp:Label ID="lblManholeNumber" runat="server" EnableViewState="False" SkinID="Label" Text="Manhole #"></asp:Label>
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
                    <asp:TextBox ID="tbxManholeNumber" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                </td>                
                <td>
                    <asp:Label ID="lblLatitude" runat="server" EnableViewState="False" SkinID="Label" Text="Latitude"></asp:Label> </td>
                <td>
                    <asp:Label ID="lblLongitude" runat="server" EnableViewState="False" SkinID="Label" Text="Longitude"></asp:Label></td>                
                <td>
                    <asp:Label ID="lblShape" runat="server" EnableViewState="False" SkinID="Label" Text="Shape"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblConditioningRating" runat="server" EnableViewState="False" SkinID="Label" Text="Condition Rating"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>                
                <td>
                    <asp:TextBox ID="tbxLatitude" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLongitude" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxShape" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxConditioningRating" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                <td></td>                    
                <td></td>                
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxMaterial" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLocation" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                
        
        <!-- Table element: 6 columns - Manhole Rehabilitation Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblManholeRehabilitationDetails" runat="server" SkinID="LabelTitle1" Text="Rehabilitation Details"
                        EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Tab Control -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>                                   
                    <!-- Page element : Tab control -->
                    <cc1:TabContainer ID="tcMrDetails" Width="730px" runat="server" ActiveTabIndex="0" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpRehabilitationData" runat="server" HeaderText="Rehabilitation Data"  OnClientClick="tpMrRehabilitationDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 6 columns Setup information -->
                                    <asp:UpdatePanel ID="upnlWorkData" runat="server">   
                                        <ContentTemplate> 
                                            <asp:Panel ID="pnlWorkData" runat="server"> 
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                            <asp:Label ID="lblRehabilitationData" runat="server" SkinID="LabelTitle2" Text="Rehabilitation Data"></asp:Label>
                                                        </td>                                            
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataPreppedDate" runat="server" SkinID="Label" Text="Prepped Date"></asp:Label>
                                                        </td>  
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataSprayedDate" runat="server" SkinID="Label" Text="Sprayed Date"></asp:Label>
                                                        </td> 
                                                        <td>
                                                            <asp:Label ID="lblBatchDate" runat="server" SkinID="Label" Text="Batch Date"></asp:Label>
                                                        </td> 
                                                        <td></td>                                                  
                                                        <td></td>                                                  
                                                        <td></td>                                                  
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationPreppedDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>  
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationSprayedDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td> 
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationBatchDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>  
                                                        <td></td>                                                  
                                                        <td></td>                                                  
                                                        <td></td>                                                   
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
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
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                <asp:Label ID="lblManholeStructure" runat="server" SkinID="LabelTitle2" Text="Manhole Structure"></asp:Label>
                                                <asp:Label ID="lblMessage" runat="server" SkinID="LabelError" Text="  (All measurements round up to nearest foot)"></asp:Label>
                                            </td>                                            
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <asp:UpdatePanel ID="upnlShapes" runat="server">   
                                        <ContentTemplate> 
                                            <asp:Panel ID="pnlInformationRoundMH" runat="server">    
                                                <!-- Table element: 6 columns structure information -->                                                                                                                                                          
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataRoundStructureTitle" runat="server" SkinID="LabelTitle2" Text="Surface Area of Round MH"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>                                                
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" rowspan="14" align="center">
                                                            <asp:UpdatePanel ID="upnlShapeGraphic" runat="server">
                                                                <ContentTemplate>                                           
                                                                    <asp:Panel ID="pnlRoundGraphic" runat="server"  SkinID="MrRoundShapePanel" ScrollBars="None" Width="180px" Height="200px" >
                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                        <tr style="height:10px">
                                                                                            <td style="width: 60px"></td>                                                            
                                                                                            <td style="width: 70px"></td>
                                                                                            <td style="width: 50px"></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudChimneyDiameterLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudChimneyCeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                                                
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                         
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRoudChimneyDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoundChimneySurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td  style="text-align:left; height:10px;">
                                                                                                <asp:Label ID="lblRoundTotalDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                                <asp:Label ID="lblRoundBarrelCeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRoudBarrelDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoundBarrelSurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>  
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRoudBarrelDiameterLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px; text-align:center" colspan="3">                                                                                                                                                       
                                                                                              <asp:Label ID="lblRoundTotalSurfaceArea" runat="server" SkinID="LabelSmall" Text="Total Surface Area: "></asp:Label>
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
                                                            <asp:Label ID="lblRehabilitationDataChimneyDiameter" runat="server" SkinID="Label" Text="Chimney Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyDepth" runat="server" SkinID="Label" Text="Chimney Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyFloor" runat="server" SkinID="Label" Text="Chimney Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataChimneyCeiling" runat="server" SkinID="Label" Text="Chimney Ceiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyDiameter" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>                                                    
                                                            <asp:CheckBox ID="ckbxRehabilitationDataChimneyFloor" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                    
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyFloor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataChimneyCeiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyCeiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
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
                                                            <asp:CheckBox ID="ckbxRehabilitationDataChimneyBenching" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyBenching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataChimneySurfaceArea" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneySurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataChimneyTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>                                    
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelDiameter" runat="server" SkinID="Label" Text="Barrel Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelDepth" runat="server" SkinID="Label" Text="Barrel Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelFloor" runat="server" SkinID="Label" Text="Barrel Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelCeiling" runat="server" SkinID="Label" Text="Barrel Ceiling "></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelDiameter" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>                                                    
                                                            <asp:CheckBox ID="ckbxRehabilitationDataBarrelFloor" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                    
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelFloor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataBarrelCeiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelCeiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelBenching" runat="server" SkinID="Label" Text="Barrel Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelSurfaceArea" runat="server" SkinID="Label" Text="Barrel Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelTotalSurfaceArea" runat="server" SkinID="Label" Text="Total Barrel Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBarrelManholeRugs" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataBarrelBenching" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelBenching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataBarrelManholeRugs" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundTotalDepth" runat="server" SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundTotalSurfaceArea" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>                                                    
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundTotalDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td style="height: 10px">
                                                           </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>                                                                           
                                                 
                                            </asp:Panel>
                                            
                                            <asp:Panel ID="pnlInformationRectangularMH" runat="server">                                                                               
                                                <!-- Table element: 6 columns structure information -->                                                                               
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataRectangularStructureTitle" runat="server" SkinID="LabelTitle2" Text="Surface Area of Rectangular MH"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>                                                
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" rowspan="14" align="center">
                                                            <asp:UpdatePanel ID="upnlMrRectangularShape" runat="server">
                                                                <ContentTemplate>                                                                                                   
                                                                    <asp:Panel ID="pnlMrRectangularGraphic" runat="server"  SkinID="MrRectangularShapePanel" ScrollBars="None" Width="180px" Height="200px" >
                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                        <tr style="height:3px">
                                                                                            <td style="width: 40px"></td>                                                            
                                                                                            <td style="width: 110px"></td>
                                                                                            <td style="width: 30px"></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1ShortSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1CeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                                                
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                         
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              <asp:Label ID="lblRectangular1LongSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label> 
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">                                                                                                
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">                                                                                                
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangle1SurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular1DephtLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:right">                                                                                              
                                                                                            </td>
                                                                                            <td>                                                                                                      
                                                                                            </td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td  style="text-align:left; height:10px;">                                                                                                      
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                                <asp:Label ID="lblRectangular2CeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                                
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                                <asp:Label ID="lblRectangularTotalDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRectangle2LongSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>  
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangle2SurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                                               
                                                                                            </td>
                                                                                            <td style="text-align:center">                                                                                            
                                                                                                <asp:Label ID="lblRectangular2Depth" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                        </tr>     
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                     
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangular2ShortSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                          
                                                                                        <tr>
                                                                                            <td style="height:10px; text-align:center" colspan="3">                                                                                                                                                       
                                                                                              <asp:Label ID="lblRectangularTotalSurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text="Total Surface Area: "></asp:Label>
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
                                                            <asp:Label ID="lblRehabilitationDataRectangle1LongSide" runat="server" SkinID="Label" Text="Rectangle 1 Long Sider"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1ShortSide" runat="server" SkinID="Label" Text="Rectangle 1 Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Depth" runat="server" SkinID="Label" Text="Rectangle 1 Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle1Floor" runat="server" SkinID="Label" Text="Rectangle 1 Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1LongSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1ShortSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1Depth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Floor" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1Floor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
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
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Ceiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1Ceiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle1Benching" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1Benching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1SurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle1TotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                    </tr>        
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>                                    
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2LongSide" runat="server" SkinID="Label" Text="Rectangle 2 Long Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2ShortSide" runat="server" SkinID="Label" Text="Rectangle 2 Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Depth" runat="server" SkinID="Label" Text="Rectangle 2 Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Floor" runat="server" SkinID="Label" Text="Rectangle 2 Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2LongSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2ShortSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2Depth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Floor" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2Floor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Ceiling" runat="server" SkinID="Label" Text="Rectangle 2 Ceiling"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2Benching" runat="server" SkinID="LabelSmall" Text="Rectangle 2 Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2SurfaceArea" runat="server" SkinID="LabelSmall" Text="Rectangle 2 Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangle2TotalSurfaceArea" runat="server" SkinID="LabelSmall" Text="Total Rectangle 2 Surface Area"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Ceiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2Ceiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangle2Benching" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2Benching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2SurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangle2TotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularManholeRugs" runat="server" SkinID="LabelSmall" Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularTotalDepth" runat="server" SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularTotalSurfaceArea" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangularManholeRugs" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangularTotalDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangularTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>                                                                           
                                                 
                                            </asp:Panel>
                                            
                                            <asp:Panel ID="pnlInformationMixedMH" runat="server">
                                                <!-- Table element: 6 columns structure information -->                                                                               
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataMixedStructureTitle" runat="server" SkinID="LabelTitle2" Text="Surface Area of Mixed MH"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>                                                
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" rowspan="14" align="center">
                                                            <asp:UpdatePanel ID="upnlMixedGraphic" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pnlMixedGraphic" runat="server"  SkinID="MrMixedShapePanel" ScrollBars="None" Width="180px" Height="200px" >
                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                        <tr style="height:10px">
                                                                                            <td style="width: 60px"></td>                                                            
                                                                                            <td style="width: 70px"></td>
                                                                                            <td style="width: 50px"></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleShortSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleCeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                                                
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                         
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblRectangleLongSideLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              <asp:Label ID="lblRectangleSurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td style="text-align:right">
                                                                                                <asp:Label ID="lblRectangleDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td  style="text-align:left; height:10px;">
                                                                                                <asp:Label ID="lblMixedTotalDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>          
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                                <asp:Label ID="lblDataRoundCeilingLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>      
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height:10px">
                                                                                                
                                                                                            </td>                                                            
                                                                                            <td style="text-align:center">                                                                                              
                                                                                            </td>
                                                                                            <td></td>
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
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:right">                                                                                                
                                                                                            </td>
                                                                                            <td style="text-align:right">                                                                                            
                                                                                                <asp:Label ID="lblDataRoundDepthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblDataRoundSurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                                               
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>     
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                     
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                              
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr> 
                                                                                        <tr>
                                                                                            <td style="height:10px"></td>                                                            
                                                                                            <td style="text-align:center">
                                                                                                <asp:Label ID="lblDataRoundDiameterLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                          
                                                                                        <tr>
                                                                                            <td style="height:10px; text-align:center" colspan="3">                                                                                                                                                       
                                                                                              <asp:Label ID="lblTotalMixedSurfaceAreaLabel" runat="server" SkinID="LabelSmall" Text="Total Surface Area: "></asp:Label>
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
                                                            <asp:Label ID="lblRehabilitationDataRoundDiameter" runat="server" SkinID="Label" Text="Round Diameter"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundDepth" runat="server" SkinID="Label" Text="Round Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundFloor" runat="server" SkinID="Label" Text="Round Floor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRoundCeiling" runat="server" SkinID="Label" Text="Round Ceiling"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundDiameter" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>                                                    
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRoundFloor" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                    
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundFloor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRoundCeiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundCeiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
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
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRoundBenching" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundBenching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRoundSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataMixedRoundTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>        
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>                                    
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleLongSide" runat="server" SkinID="Label" Text="Rectangle Long Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleShortSide" runat="server" SkinID="Label" Text="Rectangle Short Side"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleDepth" runat="server" SkinID="Label" Text="Rectangle Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleFloor" runat="server" SkinID="Label" Text="Rectangle Floor"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangleLongSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangleShortSide" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangleDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                                
                                                        </td>
                                                        <td>                                              
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangleFloor" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangleFloor" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangleCeiling" runat="server" SkinID="Label" Text="Rectangle Ceiling"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataBenching" runat="server" SkinID="LabelSmall" Text="Rectangle Benching"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataRectangularSufaceArea" runat="server" SkinID="LabelSmall" Text="Rectangle Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataMixedRectangleTotalSufaceArea" runat="server" SkinID="LabelSmall" Text="Total Rectangle Surface Area"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataRectangleCeiling" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangleCeiling" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxRehabilitationDataBenching" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />                                                      
                                                            <asp:TextBox ID="tbxRehabilitationDataBenching" runat="server" SkinID="TextBoxReadOnly" Style="width: 85px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataRectangularSufaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataMixedRectangleTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataManholeRugs" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataTotalDepth" runat="server" SkinID="Label" Text="Total Depth"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataTotalSurfaceArea" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataManholeRugs" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataTotalDepth" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRehabilitationDataTotalSurfaceArea" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td style="height: 10px">
                                                           </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>                                                                           
                                                 
                                            </asp:Panel>
                                            
                                            <asp:Panel ID="pnlInformationOtherMH" runat="server">   
                                                <!-- Table element: 6 columns structure information -->                                                                               
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
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
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblRehabilitationDataOtherStructureTitle" runat="server" SkinID="LabelTitle2" Text="Surface Area of MH"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>                                                
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" rowspan="14" align="center">
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRehabilitationDataOtherStructure" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
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
                                                            <asp:TextBox ID="tbxRehabilitationDataOtherStructure" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>                                          
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td style="height: 10px">
                                                            </td>
                                                        <td></td>
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
                                                <asp:Label ID="lblcommentsTitle" runat="server" SkinID="LabelTitle2" Text="Comments"></asp:Label>
                                            </td>                                            
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCommentsDataComments" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Comments Summary"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlComments" runat="server">
                                                    <contenttemplate>
                                                        <asp:Button id="btnComments" onclick="btnCommentsOnClick" runat="server" SkinID="Button" Text="Update" Visible="false" EnableViewState="False" Width="80px" ></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" EnableViewState="False"
                                                    ReadOnly="True" Rows="20" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 30px" colspan="6">
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
                
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
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
                    <asp:HiddenField ID="hdfBatchId" runat="server" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
