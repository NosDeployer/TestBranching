<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="project_state.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_state" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">    
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProject" runat="server" Text="Project:" SkinID="LabelPageTitle2" EnableViewState="False"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <%-- Proposal--%>
                            <telerik:RadMenuItem Value="mProposalAward" Text="YES, AWARD" />
                            
                            <telerik:RadMenuItem Value="mProposalLostBid" Text="YES, LOST BID" />
                            
                            <telerik:RadMenuItem Value="mCancelProposal" Text="YES, CANCEL PROPOSAL" />
                            
                            <telerik:RadMenuItem Value="mProposalBidding" Text="YES, BIDDING" />
                            
                            <telerik:RadMenuItem Value="mProposalUnpromoteToBallpark" Text="YES, UNPROMOTE TO BALLPARK" />
                            
                            <telerik:RadMenuItem Value="mProposalPromoteToProject" Text="YES, PROMOTE" />
                            
                            
                            <%-- Project--%>
                            <telerik:RadMenuItem Value="mProjectSetWaiting" Text="YES, SET WAITING" />
                            
                            <telerik:RadMenuItem Value="mActivate" Text="YES, ACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mInactivate" Text="YES, INACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mComplete" Text="YES, COMPLETE" />
                            
                            <telerik:RadMenuItem Value="mCancelProject" Text="YES, CANCEL PROJECT" />
                            
                            <telerik:RadMenuItem Value="mUnpromoteToBallpark" Text="YES, UNPROMOTE TO BALLPARK" />
                            
                            <telerik:RadMenuItem Value="mUnpromoteToProposal" Text="YES, UNPROMOTE TO PROPOSAL" />
                            
                            <telerik:RadMenuItem Value="mTagAsInternal" Text="YES, TAG AS INTERNAL" />
                            
                            
                            <%-- Internal Project--%>
                            <telerik:RadMenuItem Value="mActivate" Text="YES, ACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mComplete" Text="YES, COMPLETE" />
                            
                            <telerik:RadMenuItem Value="mCancelProject" Text="YES, CANCEL INTERNAL PROJECT" />
                            
                            <telerik:RadMenuItem Value="mPromoteToProposal" Text="YES, PROMOTE TO PROPOSAL" />
                            
                            <telerik:RadMenuItem Value="mPromoteToProject" Text="YES, PROMOTE TO PROJECT" />
                            
                            
                            <%-- Ballpark--%>
                            <telerik:RadMenuItem Value="mBallparkProjectActivate" Text="YES, ACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mBallparkProjectCancelProject" Text="YES, CANCEL BALLPARK" />
                            
                            <telerik:RadMenuItem Value="mBallparkProjectPromoteToProposal" Text="YES, PROMOTE TO PROPOSAL" />
                            
                            <telerik:RadMenuItem Value="mBallparkProjectPromoteToProject" Text="YES, PROMOTE TO PROJECT" />
                            
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<script language="javascript" type="text/javascript">

    function cbxSelectedClick(evt) {
        var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        var parentTagName = "table"
        var parent = src.parentNode;

        while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
            parent = parent.parentNode;
        }

        var allSelect = true;

        var childChkBoxes = parent.getElementsByTagName("input");
        var childChkBoxCount = childChkBoxes.length;

        if (src.id != "ctl00_ContentPlaceHolder_cbxlEmployee_0") {

            for (i = 1; i < childChkBoxCount; i++) {
                if (childChkBoxes[i].type == "checkbox") {
                    if (childChkBoxes[i].checked != true)
                        allSelect = false;
                }
            }

            if (allSelect == true) {
                childChkBoxes[0].checked = true;
            }
            else {
                childChkBoxes[0].checked = false;
            }
        }
        else {
            if (childChkBoxes[0].checked == true) {
                for (i = 1; i < childChkBoxCount; i++) {
                    if (childChkBoxes[i].type == "checkbox") {

                        childChkBoxes[i].checked = true;
                    }
                }
            }
            else {
                for (i = 1; i < childChkBoxCount; i++) {
                    if (childChkBoxes[i].type == "checkbox") {

                        childChkBoxes[i].checked = false;
                    }
                }
            }
        }
    }
    </script>
    
    
    
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text="Are you sure you want to change the state of the project?" EnableViewState="False"></asp:Label>
                </td>                
           </tr>
           <tr>
                <td style="height: 7px">
                </td>
            </tr>
           <tr>
                <td>
                    <asp:UpdatePanel id="upPnlSendMail" runat="server">
                        <contenttemplate>
                               <table style="width: 100%" cellspacing="0" cellpadding="0" width="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSendMail" runat="server" SkinID="Label" Text="Please select the employees to be notified" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upnlEmployee" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">                                                        
                                                            <tr>
                                                                <td style="WIDTH: 260px">
                                                                    <asp:Panel ID="pnlEmployee" Width="156px" Height="188px" runat="server" SkinID="Panel">
                                                                        <asp:CheckBoxList ID="cbxlEmployee" runat="server" DataSourceID="odsEmployee" DataTextField="FullName" DataValueField="EmployeeID" 
                                                                            SkinID="CheckBoxListWithoutBorder" onclick="return cbxSelectedClick(event);">
                                                                        </asp:CheckBoxList>
                                                                    </asp:Panel>
                                                                </td>
                                                                <td style="VERTICAL-ALIGN: middle">
                                                                    <asp:UpdateProgress id="upEmployee" runat="server" AssociatedUpdatePanelID="upnlEmployee">
                                                                        <ProgressTemplate>
                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </td>
                                                            </tr>                                                       
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>            
                                        </td>
                                    </tr>
                              </table>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
           </tr>
        </table>                
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadCurrentEmployees"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>                            
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="fullName" Type="String" />                            
                        </SelectParameters>
                    </asp:ObjectDataSource>
                 </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                     <asp:HiddenField ID="hdfProjectId" runat="server" />
                     <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>
    </div>    
    
</asp:Content>