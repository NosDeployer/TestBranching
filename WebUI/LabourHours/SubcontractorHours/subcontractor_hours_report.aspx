<%@ Page Language="C#"  MasterPageFile="../../mReport1.Master" AutoEventWireup="true" 
CodeBehind="subcontractor_hours_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractorHours_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnSearchBySubcontractor" runat="server" Checked="True" GroupName="Search"
                        SkinID="RadioButton" Text="Search by Subcontractor" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSubcontractor" runat="server" Text="Subcontractor" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList Width="160px" ID="ddlSubcontractor" runat="server" SkinID="DropDownList"
                            DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                            DataSourceID="odsSubcontractorsList">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnSearchByClientProject" runat="server" Checked="False" GroupName="Search"
                        SkinID="RadioButton" Text="Search by Client-Project" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" Text="Client" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:dropdownlist id="ddlClient" SkinID="DropDownList" tabIndex="1" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">   
				            </asp:dropdownlist>
				        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height:7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" Text="Project" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlProject" runat="server">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="WIDTH: 160px">
                                        <asp:DropDownList ID="ddlProject" SkinID="DropDownList" TabIndex="2" runat="server" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="VERTICAL-ALIGN: middle">
                                        <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                            <ProgressTemplate>
                                                <asp:Image id="imAjax" runat="server" skinId="Ajax_Grey"></asp:Image> 
                                            </ProgressTemplate>
                                        </asp:UpdateProgress> 
                                    </td>
                                </tr>
                            </table>
                        </contenttemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height:7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckbxDates" runat="server"  SkinID="CheckBox" Text="Between the following dates" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" 
                                SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                Calendar-DayNameFormat="Short">                                
                                <calendar daynameformat="Short" showrowheaders="False" 
                                    usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                    viewselectortext="x">
                                </calendar>
                                <datepopupbutton hoverimageurl="" imageurl="" />
                            </telerik:RadDatePicker>
                        </ContentTemplate> 
                    </asp:UpdatePanel> 
                </td>
            </tr> 
            <tr>
                <td style="height:7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlEndDate" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" 
                                SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                Calendar-DayNameFormat="Short">                                
                                <calendar daynameformat="Short" showrowheaders="False" 
                                    usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                    viewselectortext="x">
                                </calendar>
                                <datepopupbutton hoverimageurl="" imageurl="" />
                            </telerik:RadDatePicker>
                        </ContentTemplate> 
                    </asp:UpdatePanel>   
                </td>
            </tr>
        </table>           
       
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentRefId" runat="server" />
                </td>
            </tr>
        </table>
        
         <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
