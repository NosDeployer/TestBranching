<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_manhours_per_phase.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_manhours_per_phase" Title="LFS Live"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblProjectTimeState" runat="server" SkinID="Label" Text="Select Project Time State" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProjectTimeState" runat="server" SkinID="DropDownList" Width="160px">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Unapproved">For Approval</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" SkinID="Label" Text="Select Country" EnableViewState="False"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" SkinID="DropDownList" Width="160px" DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Select Client" EnableViewState="False"></asp:Label>
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" DataMember="DefaultView"
                                DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                SkinID="DropDownListLookup" Width="160px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Select Project" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width:160px">
                                            <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="160px" DataValueField="ProjectID" DataTextField="NAME" DataSourceID="odsProject" DataMember="DefaultView" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress> 
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel> 
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPhase" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Phase"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlPhase" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPhase" runat="server" SkinID="DropDownList" Width="160px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlPhase_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="(All)" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Junction Lining . Install" Value="Install"></asp:ListItem>
                                <asp:ListItem Text="Junction Lining . Prep from Main" Value="Prep from Main"></asp:ListItem>
                                <asp:ListItem Text="Junction Lining . PreVideo & Locate (V1)" Value="Scoping"></asp:ListItem>
                                <asp:ListItem Text="Rehab Assessment . Flush Video and Reaming" Value="Flush Video and Reaming"></asp:ListItem>
                                <%--<asp:ListItem Text="Rehab Assessment . Pre-Video" Value="Pre-Video"></asp:ListItem>--%>
                                <asp:ListItem Text="Full Length . Install" Value="FInstall"></asp:ListItem>
                                <asp:ListItem Text="Full Length . Prep & Measure" Value="Prep & Measure"></asp:ListItem>
                                <asp:ListItem Text="Full Length . Reinstate & Post Video" Value="Reinstate & Post Video"></asp:ListItem>
                                <asp:ListItem Text="MH Rehab . Prep" Value="Prep"></asp:ListItem>
                                <asp:ListItem Text="MH Rehab . Spray" Value="Spray"></asp:ListItem>
                                <asp:ListItem Text="Point Lining . Install" Value="PLInstall"></asp:ListItem>
                                <asp:ListItem Text="Point Lining . Prep" Value="PLPrep"></asp:ListItem>
                                <asp:ListItem Text="Point Lining . Reinstate" Value="Reinstate"></asp:ListItem>                                
                            </asp:DropDownList>
                        </ContentTemplate>                       
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:RequiredFieldValidator ID="rfvPhase" runat="server" ControlToValidate="ddlPhase"
                        EnableViewState="False" ErrorMessage="Please select a phase" InitialValue="-1"
                        SkinID="Validator">
                    </asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
        </table>
        
        <asp:UpdatePanel ID="upnlMHCriterias" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlMHCriterias" runat="server" Visible="true">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblMHShape" runat="server" EnableViewState="False" SkinID="Label"
                                    Text="MH Shape"></asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:UpdateProgress id="upMHCriterias" runat="server" AssociatedUpdatePanelID="upnlPhase">
                                    <ProgressTemplate>
                                        <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlShape" runat="server" DataMember="DefaultView" DataSourceID="odsShape"
                                    DataTextField="ManholeShape" DataValueField="ManholeShape" SkinID="DropDownList"
                                    Style="width: 160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblConditionRating" runat="server" EnableViewState="False" SkinID="Label"
                                    Text="Condition Rating"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlConditioningRating" runat="server" DataMember="DefaultView"
                                    DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                    SkinID="DropDownList" Style="width: 160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLocation" runat="server" EnableViewState="False" SkinID="Label"
                                    Text="Location"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLocation" runat="server" DataMember="DefaultView" DataSourceID="odsLocation"
                                    DataTextField="Location" DataValueField="Location" SkinID="DropDownList" Style="width: 160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMaterial" runat="server" EnableViewState="False" SkinID="Label"
                                    Text="Material"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlMaterial" runat="server" DataMember="DefaultView" DataSourceID="odsMaterialType"
                                    DataTextField="Description" DataValueField="MaterialID" SkinID="DropDownList"
                                    Style="width: 160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCrew" runat="server" EnableViewState="False" SkinID="Label" Text="Crew"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCrew" runat="server" DataSourceID="odsCrew" DataTextField="Crew"
                                    DataValueField="Crew" SkinID="DropDownListLookup" Width="160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPhase" EventName="SelectedIndexChanged">
                </asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        
        <asp:UpdatePanel ID="upnlFLLCriterias" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlFLLCriterias" runat="server" Visible="true">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblConfirmedSize" runat="server" EnableViewState="False" SkinID="Label" Text="Confirmed Size"></asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:UpdateProgress id="upFLLCriterias" runat="server" AssociatedUpdatePanelID="upnlPhase">
                                    <ProgressTemplate>
                                        <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlConfirmedSize" runat="server" SkinID="DropDownList" Width="160px">
                                    <asp:ListItem Selected="True" Text="(All)" Value="(All)"></asp:ListItem>
                                    <asp:ListItem Text='8" / 200mm' Value='8'></asp:ListItem>
                                    <asp:ListItem Text='10" / 250mm' Value='10'></asp:ListItem>
                                    <asp:ListItem Text='12" / 300mm' Value='12'></asp:ListItem>
                                    <asp:ListItem Text='15" / 375mm' Value='15'></asp:ListItem>
                                    <asp:ListItem Text='18" / 450mm' Value='18'></asp:ListItem>
                                    <asp:ListItem Text='21" / 525mm' Value='21'></asp:ListItem>
                                    <asp:ListItem Text='24" / 600mm' Value='24'></asp:ListItem>
                                    <asp:ListItem Text='27" / 675mm' Value='27'></asp:ListItem>
                                    <asp:ListItem Text='30" / 750mm' Value='30'></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAccessType" runat="server" EnableViewState="False" SkinID="Label" Text="Access Type"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlAccessType" runat="server" SkinID="DropDownListLookup" Style="width: 160px">
                                    <asp:ListItem Text="(All)" Value="(All)"></asp:ListItem>
                                    <asp:ListItem Text="Type 1 - Road" Value="Type 1 - Road"></asp:ListItem>
                                    <asp:ListItem Text="Type 2 - Easement" Value="Type 2 - Easement"></asp:ListItem>
                                    <asp:ListItem Text="Type 3 - Sp Easement" Value="Type 3 - Sp Easement"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPhase" EventName="SelectedIndexChanged">
                </asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
        
        
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                                                                                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
               </td>
            </tr>
        </table>
        
        
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 50%;">
                    <asp:ObjectDataSource ID="odsCountry" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsShape" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHShapeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="shape" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>   
                    
                    <asp:ObjectDataSource ID="odsConditionRating" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerMHConditionRatingList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="conditionRatingId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="conditionRating" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>               
                                        
                    <asp:ObjectDataSource ID="odsLocation" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="location" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByType" TypeName="LiquiForce.LFSLive.BL.Resources.Materials.MaterialsList">
                        <SelectParameters>                            
                            <asp:Parameter DefaultValue="(All)" Name="description" Type="String" />
                            <asp:SessionParameter DefaultValue="-1" Name="materialId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:SessionParameter DefaultValue="Manhole Rehabilitation" Name="type" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCrew" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.CrewList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="crew" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table> 
    </div>
</asp:Content>