using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using LiquiForce.LFSLive.CWP.DatabaseGateway;
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class view_fulllength_m1 : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///

		//
		// Data components
		//
		protected TDSLFSRecord tdsLfsRecord;



		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		//
		// Page_Load
		//
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//--- Security check
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- Restore dataset lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];

				//--- Prepare initial data
                hdfId.Value = Request.QueryString["id"].ToString();

				//--- ... for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

				//--- ... for traffic control
				LFSTrafficControlGateway lfsTrafficControlGateway = new LFSTrafficControlGateway();
				DataSet dsLfsTrafficControl = lfsTrafficControlGateway.GetLFSTrafficControlForDropDownList("");

				ddlDegreeOfTrafficControl.DataSource = dsLfsTrafficControl;
				ddlDegreeOfTrafficControl.DataTextField = "TrafficControl";

				//--- Databind
				Page.DataBind();

				TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
				ddlDegreeOfTrafficControl.SelectedValue = (lfsMasterAreaRow.IsDegreeOfTrafficControlNull()) ? "" : lfsMasterAreaRow.DegreeOfTrafficControl;
			}
			else
			{
				//--- Restore dataset lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
			}
		}

		//
		// btnOK_Click
		//
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				this.PostPageChanges();

				//--- Update database
				this.UpdateDatabase();

				//--- Go to navigator2.aspx
				Response.Redirect("navigator2.aspx?record_modified=true");
			}
		}

		//
		// btnCancel_Click
		//
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//--- Go to navigator2.aspx
			Response.Redirect("navigator2.aspx?record_modified=false");
		}

		//
		// Page_PreRender
		//
		protected void Page_PreRender(object sender, EventArgs e)
		{
			//--- Security check

			//--- ... edit
			if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
			{
				//--- Master area
				tbxSubArea.ReadOnly = false;
				tbxStreet.ReadOnly = false;
				tbxUSMH.ReadOnly = false;
				tbxDSMH.ReadOnly = false;
				tbxM1Date.ReadOnly = false;
				tbxConfirmedSize.ReadOnly = false;
				tbxUSMHMN.ReadOnly = false;
				tbxDSMHMN.ReadOnly = false;
				tbxUSMHDepth.ReadOnly = false;
				tbxDSMHDepth.ReadOnly = false;
				tbxMeasurementsTakenBy.ReadOnly = false;
				tbxSteelTapeThruPipe.ReadOnly = false;
				tbxUSMHAtMouth1200.ReadOnly = false;
				tbxUSMHAtMouth100.ReadOnly = false;
				tbxUSMHAtMouth200.ReadOnly = false;
				tbxUSMHAtMouth300.ReadOnly = false;
				tbxUSMHAtMouth400.ReadOnly = false;
				tbxUSMHAtMouth500.ReadOnly = false;
				tbxDSMHAtMouth1200.ReadOnly = false;
				tbxDSMHAtMouth100.ReadOnly = false;
				tbxDSMHAtMouth200.ReadOnly = false;
				tbxDSMHAtMouth300.ReadOnly = false;
				tbxDSMHAtMouth400.ReadOnly = false;
				tbxDSMHAtMouth500.ReadOnly = false;
				tbxHydrantAddress.ReadOnly = false;
				tbxDistanceToInversionMH.ReadOnly = false;
				cbxRampsRequired.Enabled = true;
				ddlDegreeOfTrafficControl.Enabled = true;
				cbxStandarBypass.Enabled = true;
				tbxHydroWireDetails.ReadOnly = false;
				tbxPipeMaterialType.ReadOnly = false;
				cbxRoboticPrepRequired.Enabled = true;
				cbxPipeSizeChange.Enabled = true;
				tbxM1Comments.ReadOnly = false;
				tbxTrafficControlDetails.ReadOnly = false;
				tbxLineWithID.ReadOnly = false;
				cbxSchoolZone.Enabled = true;
				cbxRestaurantArea.Enabled = true;
				cbxCarwashLaundromat.Enabled = true;
				cbxHydroPulley.Enabled = true;
				cbxFridgeCart.Enabled = true;
				cbxTwoInchPump.Enabled = true;
				cbxSixInchBypass.Enabled = true;
				cbxScaffolding.Enabled = true;
				cbxWinchExtension.Enabled = true;
				cbxExtraGenerator.Enabled = true;
				cbxGreyCableExtension.Enabled = true;
				cbxEasementMats.Enabled = true;
				cbxDropPipe.Enabled = true;
				tbxDropPipeInvertDepth.ReadOnly = false;
				
				//--- Buttons
				btnOK.Enabled = true;
				btnOK1.Enabled = true;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}
			else
			{
				//--- Master area
				tbxSubArea.ReadOnly = true;
				tbxStreet.ReadOnly = true;
				tbxUSMH.ReadOnly = true;
				tbxDSMH.ReadOnly = true;
				tbxM1Date.ReadOnly = true;
				tbxConfirmedSize.ReadOnly = true;
				tbxUSMHMN.ReadOnly = true;
				tbxDSMHMN.ReadOnly = true;
				tbxUSMHDepth.ReadOnly = true;
				tbxDSMHDepth.ReadOnly = true;
				tbxMeasurementsTakenBy.ReadOnly = true;
				tbxSteelTapeThruPipe.ReadOnly = true;
				tbxUSMHAtMouth1200.ReadOnly = true;
				tbxUSMHAtMouth100.ReadOnly = true;
				tbxUSMHAtMouth200.ReadOnly = true;
				tbxUSMHAtMouth300.ReadOnly = true;
				tbxUSMHAtMouth400.ReadOnly = true;
				tbxUSMHAtMouth500.ReadOnly = true;
				tbxDSMHAtMouth1200.ReadOnly = true;
				tbxDSMHAtMouth100.ReadOnly = true;
				tbxDSMHAtMouth200.ReadOnly = true;
				tbxDSMHAtMouth300.ReadOnly = true;
				tbxDSMHAtMouth400.ReadOnly = true;
				tbxDSMHAtMouth500.ReadOnly = true;
				tbxHydrantAddress.ReadOnly = true;
				tbxDistanceToInversionMH.ReadOnly = true;
				cbxRampsRequired.Enabled = false;
				ddlDegreeOfTrafficControl.Enabled = false;
				cbxStandarBypass.Enabled = false;
				tbxHydroWireDetails.ReadOnly = true;
				tbxPipeMaterialType.ReadOnly = true;
				cbxRoboticPrepRequired.Enabled = false;
				cbxPipeSizeChange.Enabled = false;
				tbxM1Comments.ReadOnly = true;
				tbxTrafficControlDetails.ReadOnly = true;
				tbxLineWithID.ReadOnly = true;
				cbxSchoolZone.Enabled = false;
				cbxRestaurantArea.Enabled = false;
				cbxCarwashLaundromat.Enabled = false;
				cbxHydroPulley.Enabled = false;
				cbxFridgeCart.Enabled = false;
				cbxTwoInchPump.Enabled = false;
				cbxSixInchBypass.Enabled = false;
				cbxScaffolding.Enabled = false;
				cbxWinchExtension.Enabled = false;
				cbxExtraGenerator.Enabled = false;
				cbxGreyCableExtension.Enabled = false;
				cbxEasementMats.Enabled = false;
				cbxDropPipe.Enabled = false;
				tbxDropPipeInvertDepth.ReadOnly = true;

				//--- Buttons
				btnOK.Enabled = false;
				btnOK1.Enabled = false;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}
		}



		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		//
		// lkbtnSectionDetails_Click
		//
		protected void lkbtnSectionDetails_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				PostPageChanges();

				//--- Go to view_fulllength_m1.aspx
                Response.Redirect("view_fulllength.aspx?source_page=view_fulllength_m1.aspx&id=" + hdfId.Value);
			}	
		}

		//
		// lkbtnM2_Click
		//
		protected void lkbtnM2_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				PostPageChanges();

				//--- Go to view_fulllength_m2.aspx
                Response.Redirect("view_fulllength_m2.aspx?id=" + hdfId.Value);
			}
		}

		//
		// lkbtnSignOut_Click
		//
		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			//--- Sing out
			Response.Redirect((string)Session["loginPage"]);
		}

		//
		// lkbtnMenu_Click
		//
		protected void lkbtnMenu_Click(object sender, System.EventArgs e)
		{
			//--- Go to default.aspx
			Response.Redirect("./../default.aspx");
		}		
		
		//
		// Date_ServerValidate
		//
		private void Date_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Validator.IsValidDate(args.Value.Trim());
		}

		//
		// cvSteelTapeThruPipe_ServerValidate
		//
		private void cvSteelTapeThruPipe_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
            cvSteelTapeThruPipe.ErrorMessage = "";
            bool isValid = true;

            if (Distance.IsValidDistance(args.Value.Trim()) || tbxSteelTapeThruPipe.Text.Trim() == "")
            {
                foreach (TDSLFSRecord.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in tdsLfsRecord.LFS_JUNCTION_LINER2)
                {
                    if (!lfsJunctionLiner2Row.IsDistanceFromUSMHNull() && lfsJunctionLiner2Row.DistanceFromUSMH >= 0)
                    {
                        Distance length = new Distance(tbxSteelTapeThruPipe.Text.ToString()) - new Distance(lfsJunctionLiner2Row.DistanceFromUSMH.ToString());
                        if (length.ToDoubleInEng3() < 0)
                        {
                            isValid = false;
                            cvSteelTapeThruPipe.ErrorMessage = "Steel Tape Through Sewe must be greater than the Distance From USMH of its laterals";
                        }
                    }
                }
                args.IsValid = isValid;
            }
            else
            {
                cvSteelTapeThruPipe.ErrorMessage = "Invalid data";
                args.IsValid = false;
            }
		}



        /// ////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// PostPageChanges
		//
		private void PostPageChanges()
		{
			//--- Post lfs master area changes
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));

			if (tbxSubArea.Text.Trim() != "") lfsMasterAreaRow.SubArea = tbxSubArea.Text.Trim(); else lfsMasterAreaRow.SetSubAreaNull();
			if (tbxStreet.Text.Trim() != "") lfsMasterAreaRow.Street = tbxStreet.Text.Trim(); else lfsMasterAreaRow.SetStreetNull();
			if (tbxUSMH.Text.Trim() != "") lfsMasterAreaRow.USMH = tbxUSMH.Text.Trim(); else lfsMasterAreaRow.SetUSMHNull();
			if (tbxDSMH.Text.Trim() != "") lfsMasterAreaRow.DSMH = tbxDSMH.Text.Trim(); else lfsMasterAreaRow.SetDSMHNull();
			if (tbxM1Date.Text.Trim() != "") lfsMasterAreaRow.M1Date = DateTime.Parse(tbxM1Date.Text.Trim()); else lfsMasterAreaRow.SetM1DateNull();
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim()); else lfsMasterAreaRow.SetConfirmedSizeNull();

            //--- update DistanceFromDSMH
            foreach (TDSLFSRecord.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in tdsLfsRecord.LFS_JUNCTION_LINER2)
            {
                if (!lfsJunctionLiner2Row.IsDistanceFromUSMHNull() && lfsJunctionLiner2Row.DistanceFromUSMH >= 0)
                {
                    Distance length = new Distance(tbxSteelTapeThruPipe.Text.Trim()) - new Distance(lfsJunctionLiner2Row.DistanceFromUSMH.ToString());
                    lfsJunctionLiner2Row.DistanceFromDSMH = length.ToDoubleInEng3();
                }
            }
            
            if (tbxSteelTapeThruPipe.Text.Trim() != "") lfsMasterAreaRow.ActualLength = tbxSteelTapeThruPipe.Text.Trim(); else lfsMasterAreaRow.SetActualLengthNull(); // SYNCHRONIZED
			if (tbxUSMHMN.Text.Trim() != "") lfsMasterAreaRow.USMHMN = tbxUSMHMN.Text.Trim(); else lfsMasterAreaRow.SetUSMHMNNull();
			if (tbxDSMHMN.Text.Trim() != "") lfsMasterAreaRow.DSMHMN = tbxDSMHMN.Text.Trim(); else lfsMasterAreaRow.SetDSMHMNNull();
			if (tbxUSMHDepth.Text.Trim() != "") lfsMasterAreaRow.USMHDepth = tbxUSMHDepth.Text.Trim(); else lfsMasterAreaRow.SetUSMHDepthNull();
			if (tbxDSMHDepth.Text.Trim() != "") lfsMasterAreaRow.DSMHDepth = tbxDSMHDepth.Text.Trim(); else lfsMasterAreaRow.SetDSMHDepthNull();
			if (tbxMeasurementsTakenBy.Text.Trim() != "") lfsMasterAreaRow.MeasurementsTakenBy = tbxMeasurementsTakenBy.Text.Trim(); else lfsMasterAreaRow.SetMeasurementsTakenByNull();
			if (tbxSteelTapeThruPipe.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxSteelTapeThruPipe.Text.Trim(); else lfsMasterAreaRow.SetSteelTapeThruPipeNull();
			if (tbxUSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth1200 = Double.Parse(tbxUSMHAtMouth1200.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth1200Null();
			if (tbxUSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth100 = Double.Parse(tbxUSMHAtMouth100.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth100Null();
			if (tbxUSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth200 = Double.Parse(tbxUSMHAtMouth200.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth200Null();
			if (tbxUSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth300 = Double.Parse(tbxUSMHAtMouth300.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth300Null();
			if (tbxUSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth400 = Double.Parse(tbxUSMHAtMouth400.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth400Null();
			if (tbxUSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth500 = Double.Parse(tbxUSMHAtMouth500.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth500Null();
			if (tbxDSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth1200 = Double.Parse(tbxDSMHAtMouth1200.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth1200Null();
			if (tbxDSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth100 = Double.Parse(tbxDSMHAtMouth100.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth100Null();
			if (tbxDSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth200 = Double.Parse(tbxDSMHAtMouth200.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth200Null();
			if (tbxDSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth300 = Double.Parse(tbxDSMHAtMouth300.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth300Null();
			if (tbxDSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth400 = Double.Parse(tbxDSMHAtMouth400.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth400Null();
			if (tbxDSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth500 = Double.Parse(tbxDSMHAtMouth500.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth500Null();
			if (tbxHydrantAddress.Text.Trim() != "") lfsMasterAreaRow.HydrantAddress = tbxHydrantAddress.Text.Trim(); else lfsMasterAreaRow.SetHydrantAddressNull();
			if (tbxDistanceToInversionMH.Text.Trim() != "") lfsMasterAreaRow.DistanceToInversionMH = tbxDistanceToInversionMH.Text.Trim(); else lfsMasterAreaRow.SetDistanceToInversionMHNull();
			lfsMasterAreaRow.RampsRequired = cbxRampsRequired.Checked;
			if (ddlDegreeOfTrafficControl.SelectedValue != "") lfsMasterAreaRow.DegreeOfTrafficControl = ddlDegreeOfTrafficControl.SelectedValue; else lfsMasterAreaRow.SetDegreeOfTrafficControlNull();
			lfsMasterAreaRow.StandarBypass = cbxStandarBypass.Checked;
			if (tbxHydroWireDetails.Text.Trim() != "") lfsMasterAreaRow.HydroWireDetails = tbxHydroWireDetails.Text.Trim(); else lfsMasterAreaRow.SetHydroWireDetailsNull();
			if (tbxPipeMaterialType.Text.Trim() != "") lfsMasterAreaRow.PipeMaterialType = tbxPipeMaterialType.Text.Trim(); else lfsMasterAreaRow.SetPipeMaterialTypeNull();
			lfsMasterAreaRow.RoboticPrepRequired = cbxRoboticPrepRequired.Checked;
			lfsMasterAreaRow.PipeSizeChange = cbxPipeSizeChange.Checked;
			if (tbxM1Comments.Text.Trim() != "") lfsMasterAreaRow.M1Comments = tbxM1Comments.Text.Trim(); else lfsMasterAreaRow.SetM1CommentsNull();
			if (tbxTrafficControlDetails.Text.Trim() != "") lfsMasterAreaRow.TrafficControlDetails = tbxTrafficControlDetails.Text.Trim(); else lfsMasterAreaRow.SetTrafficControlDetailsNull();
			if (tbxLineWithID.Text.Trim() != "") lfsMasterAreaRow.LineWithID = tbxLineWithID.Text.Trim(); else lfsMasterAreaRow.SetLineWithIDNull();
			lfsMasterAreaRow.SchoolZone = cbxSchoolZone.Checked;
			lfsMasterAreaRow.RestaurantArea = cbxRestaurantArea.Checked;
			lfsMasterAreaRow.CarwashLaundromat = cbxCarwashLaundromat.Checked;
			lfsMasterAreaRow.HydroPulley = cbxHydroPulley.Checked;
			lfsMasterAreaRow.FridgeCart = cbxFridgeCart.Checked;
			lfsMasterAreaRow.TwoInchPump = cbxTwoInchPump.Checked;
			lfsMasterAreaRow.SixInchBypass = cbxSixInchBypass.Checked;
			lfsMasterAreaRow.Scaffolding = cbxScaffolding.Checked;
			lfsMasterAreaRow.WinchExtension = cbxWinchExtension.Checked;
			lfsMasterAreaRow.ExtraGenerator = cbxExtraGenerator.Checked;
			lfsMasterAreaRow.GreyCableExtension = cbxGreyCableExtension.Checked;
			lfsMasterAreaRow.EasementMats = cbxEasementMats.Checked;
			lfsMasterAreaRow.DropPipe = cbxDropPipe.Checked;
			if (tbxDropPipeInvertDepth.Text.Trim() != "") lfsMasterAreaRow.DropPipeInvertDepth = tbxDropPipeInvertDepth.Text.Trim(); else lfsMasterAreaRow.SetDropPipeInvertDepthNull();

			//--- Update m2 tables' reverse setup
			foreach (TDSLFSRecord.LFS_M2_TABLESRow lfsM2TablesRow in tdsLfsRecord.LFS_M2_TABLES)
			{
				if (!lfsM2TablesRow.IsDistanceToCentreOfLateralNull()) 
				{
					lfsM2TablesRow.ReverseSetup = Distance.Subtract(lfsMasterAreaRow.IsActualLengthNull() ? "" : lfsMasterAreaRow.ActualLength, lfsM2TablesRow.DistanceToCentreOfLateral);
				}
			}

			//--- Store dataset lfs record
			Session["tdsLfsRecord"] = tdsLfsRecord;
		}

		//
		// UpdateDatabase
		//
		private void UpdateDatabase()
		{
			//--- Update database
			try
			{
				LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
				lfsRecordGateway.UpdateRecord(tdsLfsRecord);
			}
			catch(Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}

			//--- Store datasets
			Session["tdsLfsRecord"] = tdsLfsRecord;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			//--- Wire events
			this.PreRender += new EventHandler(Page_PreRender);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.tdsLfsRecord = new TDSLFSRecord();
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).BeginInit();
			this.cvM1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvSteelTapeThruPipe.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvSteelTapeThruPipe_ServerValidate);
			// 
			// tdsLfsRecord
			// 
			this.tdsLfsRecord.DataSetName = "TDSLFSRecord";
			this.tdsLfsRecord.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).EndInit();

		}
		#endregion


		
	}
}
