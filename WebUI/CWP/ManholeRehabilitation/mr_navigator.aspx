<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" 
Codebehind="mr_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation.mr_navigator" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Manhole Rehabilitation" SkinID="LabelPageTitle1"></asp:Label>
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
        
        <!-- Table element: 6 columns - Columns to display-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxIdManhole" onclick="return cbxClick();" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="ID (Manhole)" EnableViewState="False" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxStreet" runat="server" SkinID="CheckBoxSmall" Text="Street" Checked="True"  EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxLatitude" runat="server" SkinID="CheckBoxSmall" Text="Latitude" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxLongitude" runat="server" SkinID="CheckBoxSmall"  Text="Longitude" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxShape" runat="server" SkinID="CheckBoxSmall" Text="Shape"  EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxLocation" runat="server" SkinID="CheckBoxSmall" Text="Location" EnableViewState="False" />
                </td>                
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxConditionRaiting" runat="server" SkinID="CheckBoxSmall" Text="Condition Raiting" EnableViewState="False" />
                </td>
                <td> 
                    <asp:CheckBox ID="cbxPreppedDate" runat="server" SkinID="CheckBoxSmall" Text="Prepped Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxSprayedDate" runat="server" SkinID="CheckBoxSmall" Text="Sprayed Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxBatchDate" runat="server" SkinID="CheckBoxSmall" Text="Batch Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxComments" runat="server" SkinID="CheckBoxSmall" Text="Comments" EnableViewState="False" />                
                </td>                
                <td>                    
                </td>                
            </tr>
            <tr>
                <td colspan="6" height="7px">
                </td>
            </tr>
        </table>
        
        
        <!-- Page element: Search & Sort components , 6 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">   
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 155px">
                        <asp:Label ID="lblCondition1" runat="server" EnableViewState="False" SkinID="Label" Text="Condition 1"></asp:Label>
                    </td>
                    <td style="width: 180px">
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 115px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 145px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
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
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 405px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvInvalidOperator" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                        
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" 
                            OnServerValidate="cvForDateRange_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                        
                        <asp:CustomValidator ID="cvForNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
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
                    <td>
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
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition2" runat="server" SkinID="DropDownList" Style="width: 145px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList2" DataTextField="Name" DataValueField="ConditionID">
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
                        <asp:TextBox ID="tbxCondition2" runat="server" Style="width: 405px" SkinID="TextBox" EnableViewState="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvDeleteOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage="Please delete the operator."
                            OnServerValidate="cvDeleteOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvSelectOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage="Please select an operator." 
                            OnServerValidate="cvSelectOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                       
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvForDate2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" 
                            OnServerValidate="cvForDateRange2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>                        
                        <asp:CustomValidator ID="cvForNumberCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid data. (use an integer number, % or leave the field empty)" 
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
                    <td>
                    </td>
                </tr>
            </table> 
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">                
                <tr>
                    <td style="width: 155px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 180px">                        
                     </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 105px">
                    </td>
                    
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 145px" EnableViewState="False" DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>
                    <td>                        
                    </td>
                    <td colspan="3">
                    </td>                    
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px"> 
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
        
        
        <asp:Panel ID="pnlDefaultViewSearch" runat="server" Width="100%" DefaultButton="btnGo">  
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="lblViewTitle" runat="server" SkinID="LabelTitle1" Text="Views" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
            </table>  
            
            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px;">
                    </td>
                    <td colspan="3" style="width: 125px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
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
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td>
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
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
                            <asp:Parameter DefaultValue="Manhole Rehabilitation" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList2" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Manhole Rehabilitation" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                            <asp:Parameter Name="conditionId" Type="Int32" DefaultValue="-1" />
                            <asp:Parameter Name="name" Type="String" DefaultValue="" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                    
                    
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Manhole Rehabilitation" Name="workType" Type="String" />
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
                    <asp:HiddenField ID="hdfInProject" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>