<%@ Page Title="" Language="C#" MasterPageFile="~/mReport1.Master" AutoEventWireup="true" CodeBehind="print_summary_costingsheet_by_month.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_summary_costingsheet_by_month" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
 
        function cbxSelectedClick(evt){
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var parentTagName = "table"
            var parent = src.parentNode;
			
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            			
            var allSelect = true;
            
            var childChkBoxes = parent.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            
            if (src.id != "ctl00_ContentPlaceHolder1_cbxlMonth_0") {
			
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
			else	
			{
				if (childChkBoxes[0].checked == true) {
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = true;
						}
					}
				}
				else	
				{
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = false;
						}
					}
				}
			}
        }
    </script>
    
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
             <tr>
                <td>
                    <asp:Label ID="lblYear" runat="server" SkinID="Label" Text="Year" EnableViewState="False"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" SkinID="DropDownList" Width="160px">
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2013" Selected="True">2013</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:Label ID="lblMonth" runat="server" SkinID="Label" Text="Month" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlMonth" Width="156px" Height="88px" runat="server" SkinID="Panel">
                        <asp:CheckBoxList ID="cbxlMonth" runat="server" SkinID="CheckBoxListWithoutBorder" onclick="return cbxSelectedClick(event);">
                            <asp:ListItem Text="(All)" Value="(All)"></asp:ListItem>
                            <asp:ListItem Text="January" Value="1"></asp:ListItem>
                            <asp:ListItem Text="February" Value="2"></asp:ListItem>
                            <asp:ListItem Text="March" Value="3"></asp:ListItem>
                            <asp:ListItem Text="April" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="July" Value="7"></asp:ListItem>
                            <asp:ListItem Text="August" Value="8"></asp:ListItem>
                            <asp:ListItem Text="September" Value="9"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>                    
            </tr>
        </table>
    
</asp:Content>
