<%@ Page language="c#"  MasterPageFile="./../../mReport1.Master" Codebehind="jliner_tobuild_report.aspx.cs" 
AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_tobuild_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Select A Client" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlSelectAClient" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSelectAClient" SkinID="DropDownList" TabIndex="1" runat="server"
                                Width="160px" AutoPostBack="True" >
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
					<asp:CheckBox id="ckbxAutofillLinerInProcess" runat="server" CssClass="tLabel" Text="Autofill Liner In Process " EnableViewState="False" SkinID="CheckBox">
					</asp:CheckBox>
				</td>
			</tr>
            <tr>                
                <td>
                    <asp:Label ID="lblByOfficeOnly" runat="server" CssClass="tLabel" EnableViewState="False" SkinID="Label">(to be used by office only)
                    </asp:Label></td>
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
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


