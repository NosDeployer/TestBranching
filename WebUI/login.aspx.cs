using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace LiquiForce.LFSLive.WebUI
{
	public partial class login : System.Web.UI.Page
	{
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS 
        //

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
		}



		protected void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (FormsAuthentication.Authenticate(tbxUserName.Text, tbxPassword.Text))
			{
                Session["userName"] = "danzovino";
                
				Session["companyID"] = 3;
                Session["loginID"] = 115;
                Session["justeMail"] = "danzovino@liquiforce.com";

                //if (cbxKirchoff.Checked)
                //{
                //    Session["loginID"] = 129;
                //    Session["justeMail"] = "Sean Bergman";
                //}

				Session["sgLFS_APP_VIEW"] = this.cbxView.Checked;
				Session["sgLFS_APP_ADD"] = this.cbsAdd.Checked;
				Session["sgLFS_APP_EDIT"] = this.cbxEdit.Checked;
				Session["sgLFS_APP_DELETE"] = this.cbxDelete.Checked;
				Session["sgLFS_APP_ADMIN"] = this.cbxAdmin.Checked;

                Session["sgLFS_PROJECTS_VIEW"] = this.cbxProjectView.Checked;
                Session["sgLFS_PROJECTS_ADD"] = this.cbxProjectAdd.Checked;
                Session["sgLFS_PROJECTS_EDIT"] = this.cbxProjectEdit.Checked;
                Session["sgLFS_PROJECTS_DELETE"] = this.cbxProjectDelete.Checked;
                Session["sgLFS_PROJECTS_ADMIN"] = this.cbxProjectAdmin.Checked;
                Session["sgLFS_PROJECTS_PROMOTEPROPOSALTOPROJECT"] = this.cbxProjectPromoteProposalToProject.Checked;

                Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"] = this.cbxCostingSheetAdmin.Checked;
                Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"] = this.cbxCostingSheetView.Checked;
                Session["sgLFS_PROJECTS_COSTINGSHEETS_ADD"] = this.cbxCostingSheetAdd.Checked;
                Session["sgLFS_PROJECTS_COSTINGSHEETS_EDIT"] = this.cbxCostingSheetEdit.Checked;
                Session["sgLFS_PROJECTS_COSTINGSHEETS_DELETE"] = this.cbxCostingSheetDelete.Checked;

                Session["sgLFS_PROJECTS_REVENUE_ADMIN"] = this.cbxProjectRevenueAdmin.Checked;
                Session["sgLFS_PROJECTS_REVENUE_VIEW"] = this.cbxProjectRevenueView.Checked;
                Session["sgLFS_PROJECTS_REVENUE_ADD"] = this.cbxProjectRevenueAdd.Checked;
                Session["sgLFS_PROJECTS_REVENUE_EDIT"] = this.cbxProjectRevenueEdit.Checked;
                Session["sgLFS_PROJECTS_REVENUE_DELETE"] = this.cbxProjectRevenueDelete.Checked;
                
                Session["sgLFS_LABOUR_HOURS_FULL_EDITING"] = this.cbxLHFullEditing.Checked;
                Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"] = this.cbxVacationHolidayFullEditing.Checked;

                Session["sgLFS_LABOUR_HOURS_REPORTS"] = this.cbxLHReports.Checked;
                Session["sgLFS_LABOUR_HOURS_AUTOREPORT"] = this.cbxLHAutoReport.Checked;

                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"] = this.cbxLHMTV.Checked;
                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_ADD"] = this.cbxLHMTA.Checked;
                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_EDIT"] = this.cbxLHMTE.Checked;
                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_DELETE"] = this.cbxLHMTD.Checked;
                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"] = this.cbxLHMTM.Checked;
                Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"] = this.cbxLHMTWM.Checked;

                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"] = this.cbxLHOTV.Checked;
                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_ADD"] = this.cbxLHOTA.Checked;
                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_EDIT"] = this.cbxLHOTE.Checked;
                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_DELETE"] = this.cbxLHOTD.Checked;
                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"] = this.cbxLHOTM.Checked;
                Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"] = this.cbxLHOTWM.Checked;

                Session["sgLFS_LABOUR_HOURS_VACATIONS_VIEW"] = this.cbxLHVacationsView.Checked;
                //Session["sgLFS_LABOUR_HOURS_VACATIONS_ADD"] = this.cbxVacationsAdd.Checked;
                //Session["sgLFS_LABOUR_HOURS_VACATIONS_EDIT"] = this.cbxLHVacationsEdit.Checked;
                //Session["sgLFS_LABOUR_HOURS_VACATIONS_DELETE"] = this.cbxLHVacationsDelete.Checked;
                //Session["sgLFS_LABOUR_HOURS_VACATIONS_ADMIN"] = this.cbxLHVacationsAdmin.Checked;
                Session["sgLFS_LABOUR_HOURS_VACATIONS_FULL_EDITING"] = this.cbxLHVacationsFullEditing.Checked;
                Session["sgLFS_LABOUR_HOURS_VACATIONS_REPORTS"] = this.cbxLGVacationsReports.Checked;

                Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"] = this.cbxActualCostsView.Checked;
                Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADD"] = this.cbxActualCostsAdd.Checked;
                Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_EDIT"] = this.cbxActualCostsEdit.Checked;
                Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_DELETE"] = this.cbxActualCostsDelete.Checked;
                Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"] = this.cbxActualCostsAdmin.Checked;

                Session["sgLFS_CWP_GERENCIAL_PRODUCTION_REPORTS"] = this.cbxGerencialProductionReport.Checked;

                Session["sgLFS_CWP_REHABASSESSMENT_VIEW"] = this.cbxRAView.Checked;
                Session["sgLFS_CWP_REHABASSESSMENT_ADD"] = this.cbxRAAdd.Checked;
                Session["sgLFS_CWP_REHABASSESSMENT_EDIT"] = this.cbxRAEdit.Checked;
                Session["sgLFS_CWP_REHABASSESSMENT_DELETE"] = this.cbxRADelete.Checked;
                Session["sgLFS_CWP_REHABASSESSMENT_ADMIN"] = this.cbxRAAdmin.Checked;

                Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"] = this.cbxFLView.Checked;
                Session["sgLFS_CWP_FULLLENGTHLINING_ADD"] = this.cbxFLAdd.Checked;
                Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"] = this.cbxFLEdit.Checked;
                Session["sgLFS_CWP_FULLLENGTHLINING_DELETE"] = this.cbxFLDelete.Checked;
                Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"] = this.cbxFLAdmin.Checked;

                Session["sgLFS_CWP_POINTREPAIRS_VIEW"] = this.cbxPointRepairsView.Checked;
                Session["sgLFS_CWP_POINTREPAIRS_ADD"] = this.cbxPointRepairsAdd.Checked;
                Session["sgLFS_CWP_POINTREPAIRS_EDIT"] = this.cbxPointRepairsEdit.Checked;
                Session["sgLFS_CWP_POINTREPAIRS_DELETE"] = this.cbxPointRepairsDelete.Checked;
                Session["sgLFS_CWP_POINTREPAIRS_ADMIN"] = this.cbxPointRepairsAdmin.Checked;

                Session["sgLFS_CWP_JUNCTIONLINING_VIEW"] = this.cbxJLView.Checked;
                Session["sgLFS_CWP_JUNCTIONLINING_ADD"] = this.cbxJLAdd.Checked;
                Session["sgLFS_CWP_JUNCTIONLINING_EDIT"] = this.cbxJLEdit.Checked;
                Session["sgLFS_CWP_JUNCTIONLINING_DELETE"] = this.cbxJLDelete.Checked;
                Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"] = this.cbxJLAdmin.Checked;

                Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"] = this.cbxMRView.Checked;
                Session["sgLFS_CWP_MANHOLEREHABILITATION_ADD"] = this.cbxMRAdd.Checked;
                Session["sgLFS_CWP_MANHOLEREHABILITATION_EDIT"] = this.cbxMREdit.Checked;
                Session["sgLFS_CWP_MANHOLEREHABILITATION_DELETE"] = this.cbxMRDelete.Checked;
                Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"] = this.cbxMRAdmin.Checked;

                Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"] = this.cbxServicesView.Checked;
                Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADD"] = this.cbxServicesAdd.Checked;
                Session["sgLFS_FLEETMANAGEMENT_SERVICES_EDIT"] = this.cbxServicesEdit.Checked;
                Session["sgLFS_FLEETMANAGEMENT_SERVICES_DELETE"] = this.cbxServicesDelete.Checked;
                Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"] = this.cbxServicesAdmin.Checked;

                Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_VIEW"] = this.cbxChecklistRulesView.Checked;
                Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_ADD"] = this.cbxChecklistRulesAdd.Checked;
                Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_EDIT"] = this.cbxChecklistRulesEdit.Checked;
                Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_DELETE"] = this.cbxChecklistRulesDelete.Checked;
                Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_ADMIN"] = this.cbxChecklistRulesAdmin.Checked;

                Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"] = this.cbxUnitsView.Checked;
                Session["sgLFS_FLEETMANAGEMENT_UNITS_ADD"] = this.cbxUnitsAdd.Checked;
                Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"] = this.cbxUnitsEdit.Checked;
                Session["sgLFS_FLEETMANAGEMENT_UNITS_DELETE"] = this.cbxUnitsDelete.Checked;
                Session["sgLFS_FLEETMANAGEMENT_UNITS_ADMIN"] = this.cbxUnitsAdmin.Checked;
                Session["sgLFS_FLEETMANAGEMENT_UNITS_COMMENTS"] = this.cbxUnitsComments.Checked;

                Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"] = this.cbxToDoListView.Checked;
                Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADD"] = this.cbxToDoListAdd.Checked;
                Session["sgLFS_FLEETMANAGEMENT_TODOLIST_EDIT"] = this.cbxToDoListEdit.Checked;
                Session["sgLFS_FLEETMANAGEMENT_TODOLIST_DELETE"] = this.cbxToDoListDelete.Checked;
                Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADMIN"] = this.cbxToDoListAdmin.Checked;

                Session["sgLFS_GLOBALVIEWS_VIEW"] = this.cbxGlobalViewsView.Checked;
                Session["sgLFS_GLOBALVIEWS_ADD"] = this.cbxGlobalViewsAdd.Checked;
                Session["sgLFS_GLOBALVIEWS_EDIT"] = this.cbxGlobalViewsEdit.Checked;
                Session["sgLFS_GLOBALVIEWS_DELETE"] = this.cbxGlobalViewsDelete.Checked;
                Session["sgLFS_VIEWS_ADD"] = this.cbxViewsAdd.Checked;
                Session["sgLFS_VIEWS_EDIT"] = this.cbxViewsEdit.Checked;
                Session["sgLFS_VIEWS_DELETE"] = this.cbxViewsDelete.Checked;

                Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"] = this.cbxEmployeeView.Checked;
                Session["sgLFS_RESOURCES_EMPLOYEES_ADD"] = this.cbxEmployeeAdd.Checked;
                Session["sgLFS_RESOURCES_EMPLOYEES_EDIT"] = this.cbxEmployeeEdit.Checked;
                Session["sgLFS_RESOURCES_EMPLOYEES_DELETE"] = this.cbxEmployeeDelete.Checked;
                Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"] = this.cbxEmployeeAdmin.Checked;

                Session["sgLFS_RESOURCES_MATERIALS_VIEW"] = this.cbxMaterialsView.Checked;
                Session["sgLFS_RESOURCES_MATERIALS_ADD"] = this.cbxMaterialsAdd.Checked;
                Session["sgLFS_RESOURCES_MATERIALS_EDIT"] = this.cbxMaterialsEdit.Checked;
                Session["sgLFS_RESOURCES_MATERIALS_DELETE"] = this.cbxMaterialsDelete.Checked;
                Session["sgLFS_RESOURCES_MATERIALS_ADMIN"] = this.cbxMaterialsAdmin.Checked;

                Session["sgLFS_RESOURCES_SUBCONTRACTORS_VIEW"] = this.cbxSubcontractorsView.Checked;
                Session["sgLFS_RESOURCES_SUBCONTRACTORS_ADD"] = this.cbxSubcontractorsAdd.Checked;
                Session["sgLFS_RESOURCES_SUBCONTRACTORS_EDIT"] = this.cbxSubcontractorsEdit.Checked;
                Session["sgLFS_RESOURCES_SUBCONTRACTORS_DELETE"] = this.cbxSubcontractorsDelete.Checked;

                Session["sgLFS_RESOURCES_HOTELS_VIEW"] = this.cbxHotelsView.Checked;
                Session["sgLFS_RESOURCES_HOTELS_ADD"] = this.cbxHotelsAdd.Checked;
                Session["sgLFS_RESOURCES_HOTELS_EDIT"] = this.cbxHotelsEdit.Checked;
                Session["sgLFS_RESOURCES_HOTELS_DELETE"] = this.cbxHotelsDelete.Checked;

                Session["sgLFS_RESOURCES_INSURANCECOMPANIES_VIEW"] = this.cbxHotelsView.Checked;
                Session["sgLFS_RESOURCES_INSURANCECOMPANIES_ADD"] = this.cbxHotelsAdd.Checked;
                Session["sgLFS_RESOURCES_INSURANCECOMPANIES_EDIT"] = this.cbxHotelsEdit.Checked;
                Session["sgLFS_RESOURCES_INSURANCECOMPANIES_DELETE"] = this.cbxHotelsDelete.Checked;

                Session["sgLFS_RESOURCES_BONDINGCOMPANIES_VIEW"] = this.cbxHotelsView.Checked;
                Session["sgLFS_RESOURCES_BONDINGCOMPANIES_ADD"] = this.cbxHotelsAdd.Checked;
                Session["sgLFS_RESOURCES_BONDINGCOMPANIES_EDIT"] = this.cbxHotelsEdit.Checked;
                Session["sgLFS_RESOURCES_BONDINGCOMPANIES_DELETE"] = this.cbxHotelsDelete.Checked;

                Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_VIEW"] = this.cbxUnitsOfMeasurementView.Checked;
                Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_ADD"] = this.cbxUnitsOfMeasurementAdd.Checked;
                Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_EDIT"] = this.cbxUnitsOfMeasurementEdit.Checked;
                Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_DELETE"] = this.cbxUnitsOfMeasurementDelete.Checked;
                Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_ADMIN"] = this.cbxUnitsOfMeasurementAdmin.Checked;

                Session["sgLFS_ITTST_SUPPORTTICKET_VIEW"] = this.cbxSupportTicketView.Checked;
                Session["sgLFS_ITTST_SUPPORTTICKET_ADD"] = this.cbxSupportTicketAdd.Checked;
                Session["sgLFS_ITTST_SUPPORTTICKET_EDIT"] = this.cbxSupportTicketEdit.Checked;
                Session["sgLFS_ITTST_SUPPORTTICKET_DELETE"] = this.cbxSupportTicketDelete.Checked;
                Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"] = this.cbxSupportTicketAdmin.Checked;


				FormsAuthentication.RedirectFromLoginPage(tbxUserName.Text, false);
			}
			else
			{
				tbxPassword.Text = "";
				lblLoginResult.Text = "Invalid user name or password";
			}
		}



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

      


       

		

	}
}

