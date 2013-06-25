<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mWizard2.Master"
    AutoEventWireup="true" Codebehind="project_add_sections.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.project_add_sections" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 770px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzSections" runat="server" Width="770px" Height="525px" ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>



                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnBeginNewSection" runat="server" Checked="True" GroupName="Begin"
                                                SkinID="RadioButton" Text="Create new sections and add them to project" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnBeginNewIntermediateSection" runat="server" GroupName="Begin"
                                                SkinID="RadioButton" Text="Create intermediate sections and add them to project" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:RadioButton ID="rbtnBeginSelectSection" runat="server" GroupName="Begin" SkinID="RadioButton"
                                                Text="Add existing sections to project" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepNewSections" runat="server" Title="New Sections">
                                <asp:UpdatePanel ID="upStepNewSections" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdProjectAddSectionsNew" runat="server" SkinID="GridView" Width="770px"
                                                            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="odsProjectAddSectionNew"
                                                            OnDataBound="grdProjectAddSectionsNew_DataBound" OnRowCreated="grdProjectAddSectionsNew_RowCreated"
                                                            OnRowUpdating="grdProjectAddSectionsNew_RowUpdating" OnRowEditing="grdProjectAddSectionsNew_RowEditing"
                                                            OnRowCommand="grdProjectAddSectionsNew_RowCommand" PageSize="2" ShowFooter="True"
                                                            OnRowDeleting="grdProjectAddSectionsNew_RowDeleting" OnRowDataBound="grdProjectAddSectionsNew_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" Visible="False"></asp:BoundField>
                                                                    
                                                                <asp:TemplateField SortExpression="ID" Visible="False" HeaderText="ID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Section and Manhole Information" SortExpression="SectionID"> 
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px" >
                                                                                </td>
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>    
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSectionIdEditTitle" runat="server" SkinID="Label" Text="ID (Section)"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreetEdit" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:Label ID="lblMapSizeEdit" runat="server" SkinID="Label" Text="Map Size"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMapLengthEdit" runat="server" SkinID="Label" Text="Map Length"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblAssetMaterialTypeEdit" runat="server" SkinID="Label" Text="Section Material"></asp:Label>                                                                                
                                                                                </td>                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSectionIdEdit" runat="server" SkinID="Label" Text='<%# Eval("SectionID") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreetEdit" runat="server" Text='<%# Eval("Street") %>' Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapSizeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("MapSize") %>'
                                                                                        Width="90px"  Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapLengthEdit" runat="server" SkinID="TextBox" Text='<%# Eval("MapLength") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:DropDownList ID="ddlSectionMaterialEdit" runat="server" 
                                                                                        DataSourceID="odsAssetMaterialType" DataTextField="MaterialType" 
                                                                                        DataValueField="MaterialType" SkinID="DropDownList" style="width: 190px">
                                                                                    </asp:DropDownList>
                                                                                </td>                                                                                
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                                                                                                               
                                                                                <td>
                                                                                    <asp:CustomValidator  ID="cvMapSizeEdit" runat="server" SkinID="Validator"
                                                                                         Display="Dynamic" ValidationGroup="SectionsUpdate"
                                                                                        ControlToValidate="tbxMapSizeEdit" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                        OnServerValidate="cvDistance_ServerValidate"></asp:CustomValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CustomValidator  ID="cvMapLengthEdit" runat="server" SkinID="Validator"
                                                                                        Display="Dynamic" ValidationGroup="SectionsUpdate"
                                                                                        ControlToValidate="tbxMapLengthEdit" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                        OnServerValidate="cvDistance_ServerValidate"></asp:CustomValidator>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>                                                                             
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>
                                                                                <td>
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblClientIdEdit" runat="server" SkinID="Label" Text="Client ID"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblWorkDataEdit" runat="server" SkinID="Label" Text="Work Data"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUSMMHRehabEdit" runat="server" SkinID="Label" Text="MH Rehab"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDSMHRehabEdit" runat="server" SkinID="Label" Text="MH Rehab"></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxClientIdEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClientID") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>              
                                                                                </td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxRehabAssessmentWorkEdit" runat="server" 
                                                                                                    Checked='<%# Eval("RehabAssessmentWork") %>' SkinID="CheckBox" Text="RA" 
                                                                                                    ToolTip="Rehab Assessment" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxFullLengthLiningWorkEdit" runat="server" 
                                                                                                    Checked='<%# Eval("FullLengthLiningWork") %>' SkinID="CheckBox" Text="FLL" 
                                                                                                    ToolTip="Full Length Lining" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxPointRepairsWorkEdit" runat="server" 
                                                                                                    Checked='<%# Eval("PointRepairsWork") %>' SkinID="CheckBox" Text="PR" 
                                                                                                    ToolTip="Point Repairs" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxJunctionLiningWorkEdit" runat="server" 
                                                                                                    Checked='<%# Eval("JunctionLiningWork") %>' SkinID="CheckBox" Text="JL" 
                                                                                                    ToolTip="Junction Lining" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="4">
                                                                                                <asp:CustomValidator ID="cvWorksEdit" runat="server" Display="Dynamic" 
                                                                                                    ErrorMessage="Please check at least one work." 
                                                                                                    OnServerValidate="cvWorksEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddSectionsUpdate">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>                                                                                
                                                                                <td colspan="2">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxMHRehabUsmhEdit" runat="server" 
                                                                                                    Checked='<%# Eval("MHRehabUsmh") %>' SkinID="CheckBox" Text="USMH" 
                                                                                                    ToolTip="USMH" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxMHRehabDsmhEdit" runat="server" 
                                                                                                    Checked='<%# Eval("MHRehabDsmh") %>' SkinID="CheckBox" Text="DSMH" 
                                                                                                    ToolTip="DSMH" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2">
                                                                                                <asp:CustomValidator ID="cvMHRehabEdit" runat="server" Display="Dynamic" 
                                                                                                    ErrorMessage="" 
                                                                                                    OnServerValidate="cvMHRehabEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddSectionsUpdate">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>    
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
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
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhEditTitle" runat="server" SkinID="Label" Text="USMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhStreetEdit" runat="server" SkinID="Label" Text="USMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLatitudeEdit" runat="server" SkinID="Label" Text="USMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLongitudeEdit" runat="server" SkinID="Label" Text="USMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhShapeEdit" runat="server" SkinID="Label" Text="USMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLocationEdit" runat="server" SkinID="Label" Text="USMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhEdit" runat="server" Text='<%# Eval("USMH") %>' Width="90px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>                                                                                   
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhStreetEdit" runat="server" Text='<%# Eval("UsmhStreet") %>' Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxUsmhLatitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("UsmhLatitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhLongitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("UsmhLongitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="uplUsmhShapeEdit" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlUsmhShapeEdit" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnSelectedIndexChanged="ddlUsmhShapeEdit_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhLocationEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <cc1:AutoCompleteExtender ID="aceUsmhEdit" runat="server" SkinID="AutoCompleteExtender"
                                                                                        TargetControlID="tbxUsmhEdit" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                        ServiceMethod="GetMHList" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                    </cc1:AutoCompleteExtender>
                                                                                    
                                                                                    <asp:CustomValidator ID="cvUsmhDsmhDBEdit" runat="server" ControlToValidate="tbxUsmhEdit"
                                                                                        Display="Dynamic" ErrorMessage="The manholes are exactly the same in other section, USMH & DSMH numbers have to be unique."
                                                                                        OnServerValidate="cvUsmhDsmhDBEdit_ServerValidate" SkinID="Validator" ValidationGroup="AddSectionsUpdate">
                                                                                    </asp:CustomValidator>
                                                                                </td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>      
                                                                                <td></td>                                                                          
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhConditionRatingEdit" runat="server" SkinID="Label" Text="USMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhMaterialEdit" runat="server" SkinID="Label" Text="USMH Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhConditionRatingEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhMaterialEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                     
                                                                                </td>                                                                                                                                                             
                                                                            </tr>    
                                                                            <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                             <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhEdit" runat="server" SkinID="Label" Text="DSMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhStreetEdit" runat="server" SkinID="Label" Text="DSMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLatitudeEdit" runat="server" SkinID="Label" Text="DSMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLongitudeEdit" runat="server" SkinID="Label" Text="DSMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhShapeEdit" runat="server" SkinID="Label" Text="DSMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLocationEdit" runat="server" SkinID="Label" Text="DSMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhEdit" runat="server" Text='<%# Eval("DSMH") %>' Width="90px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>                                                                                    
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhStreetEdit" runat="server" Text='<%# Eval("DsmhStreet") %>' Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxDsmhLatitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("DsmhLatitude") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhLongitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("DsmhLongitude") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlDsmhShapeEdit" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlDsmhShapeEdit" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnSelectedIndexChanged="ddlDsmhShapeEdit_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhLocationEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <cc1:AutoCompleteExtender ID="aceDsmhEdit" runat="server" SkinID="AutoCompleteExtender"
                                                                                        TargetControlID="tbxDsmhEdit" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                        ServiceMethod="GetMHList" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                    </cc1:AutoCompleteExtender>
                                                                                </td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhConditionRatingEdit" runat="server" SkinID="Label" Text="DSMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhMaterialEdit" runat="server" SkinID="Label" Text="DSMH Material"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>                                                                                   
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhConditionRatingEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhMaterialEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                     
                                                                                </td>                                                                                                                                                             
                                                                            </tr>                                                                                
                                                                            <tr>
                                                                                <td></td>
                                                                                <td style="height: 10px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                    
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px" >
                                                                                </td>
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSectionIdTitleAdd" runat="server" SkinID="Label" Text="ID (Section)"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreetAdd" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:Label ID="lblMapSizeAdd" runat="server" SkinID="Label" Text="Map Size"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMapLengthAdd" runat="server" SkinID="Label" Text="Map Length"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblAssetMaterialTypeAdd" runat="server" SkinID="Label" Text="Section Material"></asp:Label>
                                                                                </td>                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSectionIdAdd" runat="server" SkinID="Label" Text='<%# Eval("SectionID") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreetAdd" runat="server" Text='<%# Eval("Street") %>' Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapSizeAdd" runat="server" SkinID="TextBox" Text='<%# Eval("MapSize") %>'
                                                                                        Width="90px"  Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapLengthAdd" runat="server" SkinID="TextBox" Text='<%# Eval("MapLength") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:DropDownList ID="ddlSectionMaterialAdd" runat="server" 
                                                                                        DataSourceID="odsAssetMaterialType" DataTextField="MaterialType" 
                                                                                        DataValueField="MaterialType" SkinID="DropDownList" style="width: 190px">
                                                                                    </asp:DropDownList>
                                                                                </td>                                                                                
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                                                                                                               
                                                                                <td>
                                                                                    <asp:CustomValidator  ID="cvMapSizeAdd" runat="server" SkinID="Validator"
                                                                                        Display="Dynamic" ValidationGroup="AddSectionsAdd"
                                                                                        ControlToValidate="tbxMapSizeAdd" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                        OnServerValidate="cvDistance_ServerValidate">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CustomValidator  ID="cvMapLengthAdd" runat="server" SkinID="Validator"
                                                                                        Display="Dynamic" ValidationGroup="AddSectionsAdd"
                                                                                        ControlToValidate="tbxMapLengthAdd" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                        OnServerValidate="cvDistance_ServerValidate">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblClientIdAdd" runat="server" SkinID="Label" Text="Client ID"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblWorkDataAdd" runat="server" SkinID="Label" Text="Work Data"></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxClientIdAdd" runat="server" Autocomplete="Off" 
                                                                                        SkinID="TextBox" Text='<%# Eval("ClientID") %>' Width="90px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxRehabAssessmentWorkAdd" runat="server" SkinID="CheckBox" Text="RA" ToolTip="Rehab Assessment" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxFullLengthLiningWorkAdd" runat="server" SkinID="CheckBox" Text="FLL" ToolTip="Full Length Lining" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxPointRepairsWorkAdd" runat="server" SkinID="CheckBox" Text="PR" ToolTip="Point Repairs" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxJunctionLiningWorkAdd" runat="server" SkinID="CheckBox" Text="JL" ToolTip="Junction Lining" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="4" style="height: 10px">
                                                                                                <asp:CustomValidator ID="cvWorksAdd" runat="server" Display="Dynamic" 
                                                                                                    ErrorMessage="Please check at least one work." 
                                                                                                    OnServerValidate="cvWorksAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddSectionsAdd">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 90px">
                                                                                        <tr>
                                                                                            <td style="text-align: right">
                                                                                                <asp:Label ID="lblDSMHRehabAdd" Width="90px" runat="server" SkinID="Label" Text="MH Rehab"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 10px">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: left">
                                                                                                <asp:CheckBox ID="cbxMHRehabUsmhAdd" runat="server" SkinID="CheckBoxSmall" Text="USMH" ToolTip="USMH" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 10px">
                                                                                                <asp:CustomValidator ID="cvMHRehabAdd" runat="server" Display="Dynamic" 
                                                                                                    ErrorMessage="" 
                                                                                                    OnServerValidate="cvMHRehabAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddSectionsAdd">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>																				
																				<td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: left">
                                                                                                <asp:CheckBox ID="cbxMHRehabDsmhAdd" runat="server" SkinID="CheckBoxSmall" Text="DSMH" ToolTip="DSMH" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 10px">                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 7px">
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhTitleAdd" runat="server" SkinID="Label" Text="USMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhStreetAdd" runat="server" SkinID="Label" Text="USMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLatitudeAdd" runat="server" SkinID="Label" Text="USMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLongitudeAdd" runat="server" SkinID="Label" Text="USMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhShapeAdd" runat="server" SkinID="Label" Text="USMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLocationAdd" runat="server" SkinID="Label" Text="USMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>                                                                                    
                                                                                    <asp:TextBox ID="tbxUsmhAdd" runat="server" SkinID="TextBox" Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhStreetAdd" runat="server"  Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxUsmhLatitudeAdd" runat="server" SkinID="TextBox"
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhLongitudeAdd" runat="server" SkinID="TextBox" 
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="uplUsmhShapeAdd" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlUsmhShapeAdd" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnSelectedIndexChanged="ddlUsmhShapeAdd_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhLocationAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <cc1:AutoCompleteExtender ID="aceUsmhAdd" runat="server" SkinID="AutoCompleteExtender"
                                                                                        TargetControlID="tbxUsmhAdd" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                        ServiceMethod="GetMHListAdd" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                    </cc1:AutoCompleteExtender>
                                                                                    
                                                                                    <asp:CompareValidator ID="cvUsmhDsmhAdd" runat="server" SkinID="Validator" 
                                                                                        ControlToCompare="tbxDsmhAdd" Operator="NotEqual" Display="Dynamic" ValidationGroup="AddSectionsAdd"
                                                                                        ControlToValidate="tbxUsmhAdd" ErrorMessage="USMH and DSMH must be different.">
                                                                                    </asp:CompareValidator>
                                                                                    
                                                                                    <asp:CustomValidator ID="cvUsmhDsmhDBAdd" runat="server" ControlToValidate="tbxUsmhAdd"
                                                                                        Display="Dynamic" ErrorMessage="The manholes are exactly the same in other section, USMH & DSMH numbers have to be unique."
                                                                                        OnServerValidate="cvUsmhDsmhDBAdd_ServerValidate" SkinID="Validator" ValidationGroup="AddSectionsAdd">
                                                                                    </asp:CustomValidator>
                                                                                </td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>    
                                                                                <td></td>                                                                            
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhConditionRatingAdd" runat="server" SkinID="Label" Text="USMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhMaterialAdd" runat="server" SkinID="Label" Text="USMH Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhConditionRatingAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUsmhMaterialAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                           
                                                                                </td>                                                                                                                                                             
                                                                            </tr>    
                                                                            <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhAdd" runat="server" SkinID="Label" Text="DSMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhStreetAdd" runat="server" SkinID="Label" Text="DSMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLatitudeAdd" runat="server" SkinID="Label" Text="DSMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLongitudeAdd" runat="server" SkinID="Label" Text="DSMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhShapeAdd" runat="server" SkinID="Label" Text="DSMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLocationAdd" runat="server" SkinID="Label" Text="DSMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhAdd" runat="server" SkinID="TextBox" Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                                                                                                    
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhStreetAdd" runat="server"  Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxDsmhLatitudeAdd" runat="server" SkinID="TextBox" 
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhLongitudeAdd" runat="server" SkinID="TextBox" 
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlDsmhShapeAdd" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlDsmhShapeAdd" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnSelectedIndexChanged="ddlDsmhShapeAdd_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhLocationAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <cc1:AutoCompleteExtender ID="aceDsmhAdd" runat="server" SkinID="AutoCompleteExtender"
                                                                                        TargetControlID="tbxDsmhAdd" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                        ServiceMethod="GetMHListAdd" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                    </cc1:AutoCompleteExtender>
                                                                                </td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhConditionRatingAdd" runat="server" SkinID="Label" Text="DSMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhMaterialAdd" runat="server" SkinID="Label" Text="DSMH Material"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhConditionRatingAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDsmhMaterialAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                     
                                                                                </td>                                                                                                                                                             
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 10px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>  
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    
                                                                    
                                                                    <ItemTemplate>
                                                                       <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px" >
                                                                                </td>
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSectionIdTitle" runat="server" SkinID="Label" Text="ID (Section)"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreet" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:Label ID="lblMapSize" runat="server" SkinID="Label" Text="Map Size"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMapLength" runat="server" SkinID="Label" Text="Map Length"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblAssetMaterialType" runat="server" SkinID="Label" Text="Section Material"></asp:Label>
                                                                                </td>                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxSectionId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("SectionID") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox> 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreet" runat="server" Text='<%# Eval("Street") %>' Width="180px"
                                                                                    SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>
                                                                                </td>                                                                                
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapSize" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("MapSize") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMapLength" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("MapLength") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxAssetMaterial" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("SectionMaterial") %>'
                                                                                        Width="190px" Autocomplete="Off"></asp:TextBox> 
                                                                                </td>                                                                                
                                                                             </tr>                                                                                
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>
                                                                                <td>
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblClientId" runat="server" SkinID="Label" Text="Client ID"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblWorkData" runat="server" SkinID="Label" Text="Work Data"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxClientID" runat="server" Autocomplete="Off" ReadOnly="true" 
                                                                                        SkinID="TextBoxReadOnly" Text='<%# Eval("ClientID") %>' Width="90px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxRehabAssessmentWork" runat="server" 
                                                                                                    Checked='<%# Eval("RehabAssessmentWork") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBox" Text="RA" ToolTip="Rehab Assessment" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxFullLengthLiningWork" runat="server" 
                                                                                                    Checked='<%# Eval("FullLengthLiningWork") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBox" Text="FLL" ToolTip="Full Length Lining" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxPointRepairsWork" runat="server" 
                                                                                                    Checked='<%# Eval("PointRepairsWork") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBox" Text="PR" ToolTip="Point Repairs" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                <asp:CheckBox ID="cbxJunctionLiningWork" runat="server" 
                                                                                                    Checked='<%# Eval("JunctionLiningWork") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBox" Text="JL" ToolTip="Junction Lining" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: right">
                                                                                                <asp:Label ID="lblMHRehab" runat="server" SkinID="Label" Text="MH Rehab"></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align: center">                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: left">
                                                                                                <asp:CheckBox ID="cbxMHRehabUsmh" runat="server" 
                                                                                                    Checked='<%# Eval("MHRehabUsmh") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBoxSmall" Text="USMH" ToolTip="USMH" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="text-align: left">
                                                                                                <asp:CheckBox ID="cbxMHRehabDsmh" runat="server" 
                                                                                                    Checked='<%# Eval("MHRehabDsmh") %>' onclick="return cbxClick();" 
                                                                                                    SkinID="CheckBoxSmall" Text="USMH" ToolTip="USMH" />
                                                                                            </td>
                                                                                            <td style="text-align: center">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
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
                                                                                <td>
                                                                                    </td>
                                                                                <td>
                                                                                    </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhTitle" runat="server" SkinID="Label" Text="USMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhStreet" runat="server" SkinID="Label" Text="USMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLatitude" runat="server" SkinID="Label" Text="USMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLongitude" runat="server" SkinID="Label" Text="USMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhShape" runat="server" SkinID="Label" Text="USMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhLocation" runat="server" SkinID="Label" Text="USMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>                                                                                    
                                                                                    <asp:TextBox ID="tbxUsmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("USMH") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox> 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhStreet" runat="server" Text='<%# Eval("UsmhStreet") %>' Width="180px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxUsmhLatitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhLatitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhLongitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhLongitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhShape" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhShape") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                                                                                                               
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhLocation" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhLocation") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>
                                                                                </td>                                                                               
                                                                            </tr>                                                                                  
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>        
                                                                                <td></td>                                                                        
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhConditionRating" runat="server" SkinID="Label" Text="USMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUsmhMaterial" runat="server" SkinID="Label" Text="USMH Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhConditionRating" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhConditionRating") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxUsmhMaterial" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("UsmhMaterialType") %>'
                                                                                        Width="180px" Autocomplete="Off"></asp:TextBox>                                                                                     
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                     
                                                                                </td>                                                                                                                                                             
                                                                            </tr>    
                                                                            <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmh" runat="server" SkinID="Label" Text="DSMH"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhStreet" runat="server" SkinID="Label" Text="DSMH Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLatitude" runat="server" SkinID="Label" Text="DSMH Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLongitude" runat="server" SkinID="Label" Text="DSMH Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhShape" runat="server" SkinID="Label" Text="DSMH Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhLocation" runat="server" SkinID="Label" Text="DSMH Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>                                                                                    
                                                                                    <asp:TextBox ID="tbxDsmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DSMH") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox> 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhStreet" runat="server" Text='<%# Eval("DsmhStreet") %>' Width="180px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxDsmhLatitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhLatitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhLongitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhLongitude") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhShape" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhShape") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox> 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhLocation" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhLocation") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                     
                                                                                </td>                                                                               
                                                                            </tr>                                                                                
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                             
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhConditionRating" runat="server" SkinID="Label" Text="DSMH Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDsmhMaterial" runat="server" SkinID="Label" Text="DSMH Material"></asp:Label>
                                                                                </td>                                                                                
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDsmhConditionRating" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhConditionRating") %>'
                                                                                        Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                     
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxDsmhMaterial" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("DsmhMaterialType") %>'
                                                                                        Width="180px" Autocomplete="Off"></asp:TextBox>                                                                                     
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                           
                                                                                </td>                                                                                                                                                             
                                                                             </tr>
                                                                            <tr>
                                                                                <td style="height: 10px" colspan="7"></td>
                                                                            </tr>                                                               
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="700px"></HeaderStyle>                                                                    
                                                                </asp:TemplateField> 
                                                                
                                                                
                                                                
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" 
                                                                                            CommandName="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" 
                                                                                            CommandName="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" 
                                                                                       CommandName="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                    </asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" 
                                                                                            CommandName="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" 
                                                                                            CommandName="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this section?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsProjectAddSectionNew" runat="server" SelectMethod="GetProjectAddSectionsNew" 
                                                TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.project_add_sections" DeleteMethod="DummyProjectAddSectionsNew" 
                                                FilterExpression="(Deleted = 0)" UpdateMethod="DummyProjectAddSectionsNew">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </UpdateParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSearchIntermediateSections" runat="server" Title="Search Intermediate Sections">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 760px">
                                    <tr>
                                        <td style="width: 110px;">
                                            <asp:Label ID="lblForIntermediateSearchSectionId" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="ID (Section)"></asp:Label>
                                        </td>
                                        <td style="width: 210px">
                                            <asp:Label ID="lblForIntermediateSearchStreet" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Street"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblForIntermediateSearchUsmh" runat="server" SkinID="Label" Text="USMH" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblForIntermediateSearchDsmh" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="DSMH"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblForIntermediateSearchMapSize" runat="server" EnableViewState="False" SkinID="Label" Text="Map Size"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblForIntermediateSearchMapLength" runat="server" EnableViewState="False" SkinID="Label" Text="Map Length"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchSectionId" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchStreet" runat="server" Width="200px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchUsmh" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchDsmh" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchMapSize" runat="server" SkinID="TextBox" Width="100px">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxForIntermediateSearchMapLength" runat="server" SkinID="TextBox" Width="100px">%</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSelectForIntermediateSections" runat="server" Title="Select For Intermediate Section">
                                <asp:UpdatePanel ID="upStepSelectForIntermediateSections" runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdSelectForIntermediateSectionsSearch" runat="server" SkinID="GridView"
                                                                OnPageIndexChanging="grdSelectForIntermediateSectionsSearch_PageIndexChanging"
                                                                OnDataBound="grdSelectForIntermediateSectionsSearch_DataBound" DataSourceID="odsSelectForSectionsSearch"
                                                                DataKeyNames="AssetID" AutoGenerateColumns="False" AllowPaging="True" >
                                                                <Columns>
                                                                    <asp:BoundField DataField="AssetID" HeaderText="AssetID" ReadOnly="True" SortExpression="AssetID"
                                                                        Visible="False"></asp:BoundField>
                                                                    <asp:TemplateField HeaderText="SectionID" SortExpression="SectionID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSectionID_" runat="server" Text='<%# Bind("SectionID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbxSelected_" onclick="return cbxSelectedClick(this);" runat="server"
                                                                                 Checked='<%# Eval("Selected") %>'></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="30px"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SectionID" SortExpression="FlowOrderID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFlowOrderId" runat="server" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Street" HeaderText="Street" SortExpression="Street">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="USMH" HeaderText="USMH" SortExpression="USMH">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DSMH" HeaderText="DSMH" SortExpression="DSMH">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MapSize" HeaderText="Map Size" SortExpression="MapSize">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MapLength" HeaderText="Map Length" SortExpression="MapLength">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:CustomValidator ID="cvGrdSelectForIntermediateSections" runat="server" SkinID="Validator"
                                                                OnServerValidate="cvGrdSelectForIntermediateSections_ServerValidate"
                                                                ErrorMessage="At least one section must be selected." ValidationGroup="selectForIntermediateSection"
                                                                Display="Dynamic"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsSelectForSectionsSearch" runat="server" SelectMethod="GetProjectAddSectionsSearch"
                                                TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.project_add_sections" OldValuesParameterFormatString="original_{0}">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepNewIntermediateSections" runat="server" Title="New Intermediate Sections">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 760px">
                                    <tr>
                                        <td style="width: 110px;">
                                            <asp:Label ID="lblNewIntermediateSectionId" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="ID (Section)"></asp:Label>
                                        </td>
                                        <td style="width: 210px">
                                            <asp:Label ID="lblNewIntermediateStreet" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Street"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblNewIntermediateUsmh" runat="server" SkinID="Label" Text="USMH" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblNewIntermediateDsmh" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="DSMH"></asp:Label>
                                        </td>                                        
                                        <td style="width: 110px">
                                            <asp:Label ID="lblNewIntermediateMapSize" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Map Size"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblNewIntermediateMapLength" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Map Length"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlNewIntermediateSectionId" runat="server"  SkinID="DropDownList" Width="100px">
                                            </asp:DropDownList>                                           
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxNewIntermediateStreet" runat="server" Width="200px" SkinID="TextBox"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxNewIntermediateUsmh" runat="server" Width="100px" SkinID="TextBox"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="aceIntermediateUsmh" runat="server" CompletionSetCount="12"
                                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="2" ServiceMethod="GetMHList"
                                                ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx" SkinID="AutoCompleteExtender"
                                                TargetControlID="tbxNewIntermediateUsmh" UseContextKey="True">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxNewIntermediateDsmh" runat="server" Width="100px" SkinID="TextBox"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="aceIntermediateDsmh" runat="server" CompletionSetCount="12"
                                                DelimiterCharacters="" Enabled="True" MinimumPrefixLength="2" ServiceMethod="GetMHList"
                                                ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx" SkinID="AutoCompleteExtender"
                                                TargetControlID="tbxNewIntermediateDsmh" UseContextKey="True">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxNewIntermediateMapSize" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxNewIntermediateMapLength" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvSectionId" runat="server" ControlToValidate="ddlNewIntermediateSectionId"
                                                Display="Dynamic" ErrorMessage="cvSectionID" OnServerValidate="cvSectionId_ServerValidate"
                                                SkinID="Validator" ValidationGroup="intermediateData"></asp:CustomValidator>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdfPrimarySectionId" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cvIntermediateUsmhDsmh" runat="server" ControlToCompare="tbxNewIntermediateDsmh"
                                                ControlToValidate="tbxNewIntermediateUsmh" Display="Dynamic" ErrorMessage="CompareValidator"
                                                Operator="NotEqual" SkinID="Validator" ValidationGroup="intermediateData">USMH and DSMH must be different.</asp:CompareValidator>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cvIntermediateDsmhUsmh" runat="server" ControlToCompare="tbxNewIntermediateUsmh"
                                                ControlToValidate="tbxNewIntermediateDsmh" Display="Dynamic" ErrorMessage="CompareValidator"
                                                Operator="NotEqual" SkinID="Validator" ValidationGroup="intermediateData">DSMH and USMH must be different.</asp:CompareValidator>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvMapSize" runat="server" ControlToValidate="tbxNewIntermediateMapSize"
                                                Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" Style="width: 80px"
                                                ValidationGroup="intermediateData"></asp:CustomValidator>
                                        </td>
                                        <td>
                                            <asp:CustomValidator ID="cvMapLength" runat="server" ControlToValidate="tbxNewIntermediateMapLength"
                                                Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" Style="width: 80px"
                                                ValidationGroup="intermediateData"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>                            
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSearchSections" runat="server" Title="Search Sections">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 760px">
                                    <tr>
                                        <td style="width: 110px;">
                                            <asp:Label ID="lblSearchSectionID" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="ID (Section)"></asp:Label>
                                        </td>
                                        <td style="width: 210px">
                                            <asp:Label ID="lblSearchStreet" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Street"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblSearchUSMH" runat="server" SkinID="Label" Text="USMH" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblSearchDSMH" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="DSMH"></asp:Label>
                                        </td>                                        
                                        <td style="width: 110px">
                                            <asp:Label ID="lblSearchMapSize" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Map Size"></asp:Label>
                                        </td>                                        
                                        <td style="width: 110px">
                                            <asp:Label ID="lblSearchMapLength" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Map Length"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxSearchSectionID" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxSearchStreet" runat="server" Width="200px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxSearchUSMH" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxSearchDSMH" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxSearchMapSize" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxSearchMapLength" runat="server" Width="100px" SkinID="TextBox">%</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSelectSections" runat="server" Title="Select Sections">
                                <asp:UpdatePanel ID="upStepSelectSections" runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdProjectAddSectionsSearch" runat="server" SkinID="GridView" 
                                                                OnPageIndexChanging="grdProjectAddSectionsSearch_PageIndexChanging" OnDataBound="grdProjectAddSectionsSearch_DataBound"
                                                                DataSourceID="odsProjectAddSectionsSearch" DataKeyNames="AssetID" AutoGenerateColumns="False"
                                                                AllowPaging="True" OnRowDataBound="grdProjectAddSectionsSearch_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SectionID" SortExpression="SectionID" Visible="False">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSectionId" runat="server" Text='<%# Bind("SectionID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="AssetID" HeaderText="AssetID" ReadOnly="True" SortExpression="AssetID"
                                                                        Visible="False"></asp:BoundField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <HeaderStyle Width="30px"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbxSelected" runat="server"  Checked='<%# Eval("Selected") %>'>
                                                                            </asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="FlowOrderID" SortExpression="FlowOrderID">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFlowOrderId" runat="server" Text='<%# Bind("FlowOrderID") %>' ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Street" HeaderText="Street" SortExpression="Street">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="USMH" HeaderText="USMH" SortExpression="USMH">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DSMH" HeaderText="DSMH" SortExpression="DSMH">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MapSize" HeaderText="Map Size" SortExpression="MapSize">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MapLength" HeaderText="Map Length" SortExpression="MapLength">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Previous Project/Work Data" ShowHeader="False">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="text-align: center">
                                                                                            <asp:CheckBox ID="cbxRehabAssessmentPrevWork" runat="server" SkinID="CheckBox" Text="RA"
                                                                                                 Checked='<%# Eval("RehabAssessmentPrevWork") %>' ToolTip="Rehab Assessment">
                                                                                            </asp:CheckBox>
                                                                                            <asp:CheckBox ID="cbxRehabAssessmentPrevWorkReadOnly" runat="server" SkinID="CheckBox"
                                                                                                Text="RA"  Checked='<%# Eval("RehabAssessmentPrevWork") %>'
                                                                                                ToolTip="Rehab Assessment" onclick="return cbxClick();"></asp:CheckBox>
                                                                                        </td>
                                                                                        <td style="text-align: center">
                                                                                            <asp:CheckBox ID="cbxFullLengthLiningPrevWork" runat="server" SkinID="CheckBox" Text="FLL"
                                                                                                Checked='<%# Eval("FullLengthLiningPrevWork") %>' ToolTip="Full Length Lining">
                                                                                            </asp:CheckBox>
                                                                                            <asp:CheckBox ID="cbxFullLengthLiningPrevWorkReadOnly" runat="server" SkinID="CheckBox"
                                                                                                Text="FLL" Checked='<%# Eval("FullLengthLiningPrevWork") %>'
                                                                                                ToolTip="Full Length Lining" onclick="return cbxClick();"></asp:CheckBox>
                                                                                        </td>
                                                                                        <td style="text-align: center">
                                                                                            <asp:CheckBox ID="cbxPointRepairsPrevWork" runat="server" SkinID="CheckBox" Text="PR"
                                                                                                Checked='<%# Eval("PointRepairsPrevWork") %>' ToolTip="Point Repairs"></asp:CheckBox>
                                                                                            <asp:CheckBox ID="cbxPointRepairsPrevWorkReadOnly" runat="server" SkinID="CheckBox"
                                                                                                Text="PR" Checked='<%# Eval("PointRepairsPrevWork") %>' ToolTip="Point Repairs"
                                                                                                onclick="return cbxClick();"></asp:CheckBox>
                                                                                        </td>
                                                                                        <td style="text-align: center">
                                                                                            <asp:CheckBox ID="cbxJunctionLiningPrevWork" runat="server" SkinID="CheckBox" Text="JL"
                                                                                                 Checked='<%# Eval("JunctionLiningPrevWork") %>' ToolTip="Junction Lining">
                                                                                            </asp:CheckBox>
                                                                                            <asp:CheckBox ID="cbxJunctionLiningPrevWorkReadOnly" runat="server" SkinID="CheckBox"
                                                                                                Text="JL" Checked='<%# Eval("JunctionLiningPrevWork") %>'
                                                                                                ToolTip="Junction Lining" onclick="return cbxClick();"></asp:CheckBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>                                    
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                                                
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsProjectAddSectionsSearch" runat="server" SelectMethod="GetProjectAddSectionsSearch" TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.project_add_sections"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>                                
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepRemoveSections" runat="server" Title="Remove Sections">
                                <asp:UpdatePanel ID="upRemoveSections" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdRemove" runat="server" SkinID="GridView" OnRowDeleting="grdRemove_RowDeleting"
                                                            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID"
                                                            DataSourceID="odsRemove" OnDataBound="grdRemove_DataBound">
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" DataField="ID" Visible="False" SortExpression="ID"
                                                                    HeaderText="ID"></asp:BoundField>
                                                                <asp:BoundField ReadOnly="True" DataField="SectionID" Visible="False" SortExpression="SectionID"
                                                                    HeaderText="SectionID">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FlowOrderID" SortExpression="FlowOrderID" HeaderText="SectionID">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Street" SortExpression="Street" HeaderText="Street">
                                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="USMH" SortExpression="USMH" HeaderText="USMH">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DSMH" SortExpression="DSMH" HeaderText="DSMH">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MapSize" SortExpression="MapSize" HeaderText="Map Size">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MapLength" SortExpression="MapLength" HeaderText="Map Length">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 30px">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                                                        OnClientClick='return confirm("Are you sure you want to delete this section?");' />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsRemove" runat="server" DeleteMethod="DummyRemove" SelectMethod="GetRemove"
                                                TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.project_add_sections" FilterExpression="(Deleted = 0)">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </DeleteParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        
                        
                            
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">                            
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="240px" Width="100%" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                        </WizardSteps>
                        
                        
                        
                        <StepNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: auto">
                                        
                                    </td>
                                    <td style="width: 240px; text-align: right">
                                        <asp:DropDownList ID="ddlGoToStep" runat="server" Width="230px" SkinID="DropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlGoToStep_SelectedIndexChanged">
                                            <asp:ListItem>(Go to...)</asp:ListItem>
                                            <asp:ListItem>Create New Sections</asp:ListItem>
                                            <asp:ListItem>Create New Intermediate Sections</asp:ListItem>
                                            <asp:ListItem>Add Existing Sections</asp:ListItem>
                                            <asp:ListItem>Remove Sections</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="NextButton" style="width:80px" runat="server" CausesValidation="False" CommandName="MoveNext"
                                            Text="Next" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" style="width:80px" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </StepNavigationTemplate>



                        <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: auto">
                                        
                                    </td>
                                    <td style="width: 240px; text-align: right">
                                        <asp:DropDownList ID="ddlGoToFinish" runat="server" Width="230px" SkinID="DropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlGoToFinish_SelectedIndexChanged">
                                            <asp:ListItem>(Go to...)</asp:ListItem>
                                            <asp:ListItem>Create New Sections</asp:ListItem>
                                            <asp:ListItem>Create New Intermediate Sections</asp:ListItem>
                                            <asp:ListItem>Add Existing Sections</asp:ListItem>
                                            <asp:ListItem>Remove Sections</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="FinishButton" style="width:80px" runat="server" CommandName="MoveComplete" Text="Finish"
                                            SkinID="Button" EnableViewState="False" />

                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" style="width:80px" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </FinishNavigationTemplate>
                    </asp:Wizard>                    
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
                    
                    <asp:ObjectDataSource ID="odsAssetMaterialType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.MaterialTypeList">
                        <SelectParameters>
                            <asp:Parameter Name="materialType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                                        
                </td>
            </tr>
        </table>

        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfSearchTitle" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>