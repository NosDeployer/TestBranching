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
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_add
    /// </summary>
    public partial class jliner_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SectionTDS sectionTDS;
        protected JlinerAddTDS jlinerAddTDS;
        protected JlinerAddTDS.MasterAreaDataTable masterArea;
        protected JlinerAddTDS.JunctionLiner2DataTable jliner2;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jliner_add.aspx");
                }

                // Tag page
                ViewState["client"] = Request.QueryString["client"];

                // Prepare initial data    
                jlinerAddTDS = new JlinerAddTDS();            
                Session.Remove("masterAreaDummy");
                Session.Remove("jliner2Dummy");

                // ... Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                
                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepSection1In();

                // Create and store datasets 
                sectionTDS = new SectionTDS();
                Session["sectionTDSForJlinerAdd"] = sectionTDS;
                
                Session["jlinerAddTDS"] = jlinerAddTDS;
                masterArea = jlinerAddTDS.MasterArea;
                Session["masterArea"] = masterArea;

                jliner2 = jlinerAddTDS.JunctionLiner2;
                Session["jliner2"] = jliner2;
            }
            else
            {
                // Restore datasets
                sectionTDS = (SectionTDS)Session["sectionTDSForJlinerAdd"];
                jlinerAddTDS = (JlinerAddTDS)Session["jlinerAddTDS"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wizard.ActiveStep.Name)
                {
                    case "Section1":
                        StepSection1In();
                        break;

                    case "Section2":
                        StepSection2In();
                        break;

                    case "Jliner":
                        StepJlinerIn();
                        break;
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizard.ActiveStep.Name)
            {
                case "Section1":
                    int stepSection1To = StepSection1Next();
                    if (stepSection1To == -1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        ViewState["StepFrom"] = "Section1";
                        wizard.ActiveStepIndex = stepSection1To;
                    }
                    break;

                case "Section2":
                    e.Cancel = !StepSection2Next();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Section2";
                    }
                    break;
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizard.ActiveStep.Name)
            {
                case "Section2":
                    e.Cancel = !StepSection2Previous();
                    break;

                case "Jliner":
                    e.Cancel = !StepJlinerPrevious();
                    break;
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wizard.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepJlinerFinish();

            if (!e.Cancel)
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - SECTION1

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - SECTION1
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - SECTION1 - METHODS
        //

        private void StepSection1In()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please search a section";

            cvSection1.IsValid = true;
        }



        private int StepSection1Next()
        {
            int step = -1;

            // Search Section
            int companyId = Int32.Parse(Session["companyID"].ToString());
            JlinerAddMasterAreaGateway jlinerAddMasterAreaGateway = new JlinerAddMasterAreaGateway(jlinerAddTDS);
            
            if ((tbxRecordIdForSearch.Text.Trim() == "") && (tbxStreetForSearch.Text.Trim() == ""))
            {
                jlinerAddMasterAreaGateway.LoadByCompaniesId(companyId, int.Parse((string)ViewState["client"]));
                if (jlinerAddMasterAreaGateway.Table.Rows.Count > 0)
                {
                    step = 1;
                }
            }
            else
            {
                if (tbxStreetForSearch.Text.Trim() == "")
                {
                    jlinerAddMasterAreaGateway.LoadByCompaniesIdRecordId(companyId, int.Parse((string)ViewState["client"]), tbxRecordIdForSearch.Text.Trim()); 
                    if (jlinerAddMasterAreaGateway.Table.Rows.Count == 1)
                    {
                        step = 2;
                        hdfRecordId.Value = tbxRecordIdForSearch.Text.Trim();
                        hdfSelectedId.Value = jlinerAddMasterAreaGateway.GetId(hdfRecordId.Value).ToString();
                        hdfStreet.Value = jlinerAddMasterAreaGateway.GetStreet(hdfRecordId.Value);
                        hdfUsmh.Value = jlinerAddMasterAreaGateway.GetUSMH(hdfRecordId.Value);
                        hdfDsmh.Value = jlinerAddMasterAreaGateway.GetDSMH(hdfRecordId.Value);
                        hdfActualLength.Value = jlinerAddMasterAreaGateway.GetActualLength(hdfRecordId.Value);
                    }
                    else
                    {
                        jlinerAddMasterAreaGateway.LoadByCompaniesIdRecordId(companyId, int.Parse((string)ViewState["client"]), "%" + tbxRecordIdForSearch.Text.Trim() + "%");
                        if (jlinerAddMasterAreaGateway.Table.Rows.Count > 0)
                        {
                            step = 1;
                        }

                    }
                }

                if (step == -1)
                {
                    jlinerAddMasterAreaGateway.LoadByCompaniesIdRecordIdStreet(companyId, int.Parse((string)ViewState["client"]), "%" + tbxRecordIdForSearch.Text.Trim() + "%", "%" + tbxStreetForSearch.Text.Trim() + "%"); 
                    if (jlinerAddMasterAreaGateway.Table.Rows.Count > 0)
                    {
                        step = 1;
                    }
                }
            }

            // Store datasets
            Session["jlinerAddTDS"] = jlinerAddTDS;
            masterArea = jlinerAddTDS.MasterArea;
            Session["masterArea"] = masterArea;            

            // Databind
            grdSection.DataBind();

            // Check next step
            if (step == -1)
            {
                cvSection1.IsValid = false;
            }
            return step;
        }

        #endregion






        #region STEP2 - SECTION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - SECTION2
        //

        /// ////////////////////////////////////////////////////////////////////////
        /// STEP2 - SECTION2 - AUXILIAR EVENTS
        ///

        protected void cvSelection_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;            
            if (GetRecordId())
            {
                args.IsValid = true;
            }
        }



        protected void grdSection_DataBound(object sender, EventArgs e)
        {
            AddSectionsNewEmptyFix(grdSection);
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// STEP2 - SECTION2 - METHODS
        ///

        public JlinerAddTDS.MasterAreaDataTable GetSectionsNew()
        {
            masterArea = (JlinerAddTDS.MasterAreaDataTable)Session["masterAreaDummy"];
            if (masterArea == null)
            {
                masterArea = (JlinerAddTDS.MasterAreaDataTable)Session["masterArea"];
            }

            return masterArea;
        }



        private void StepSection2In()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please select a section";

            grdJliner2.DataBind();
        }



        private bool StepSection2Next()
        {
            Page.Validate("sectionsGrid");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepSection2Previous()
        {
            return true;
        }



        protected void AddSectionsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                JlinerAddTDS.MasterAreaDataTable dt = new JlinerAddTDS.MasterAreaDataTable();
                dt.AddMasterAreaRow(Guid.NewGuid(), -1, "", "", -1, "", "", "", "", "", "", new DateTime(), "", -1, "", new DateTime(), new DateTime(), new DateTime(), new DateTime(), "", false, false, false, false, false, false, -1, -1, new DateTime(), new DateTime(), false, false, false, false, false, false, false, new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), false, false, -1, -1, new DateTime(), new DateTime(), "", "", "", "", "", "", -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, "", "", false, "", false, "", "", -1, false, false, "", "", "", "", false, false, "", "", "",  false, false, false, false, false, false, false, false, false, false, false, false, "", false, "", false, "", "", "", false, -1, "", -1, -1, false, "", "", "", -1, -1, false);
                Session["masterAreaDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                JlinerAddTDS.MasterAreaDataTable dt = (JlinerAddTDS.MasterAreaDataTable)Session["masterAreaDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }

        #endregion






        #region STEP3 - JLINER

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP3 - JLINER
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - JLINER - EVENTS
        //

        protected void grdJliner2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdJliner2 Gridview, if the gridview is edition mode
            if (grdJliner2.EditIndex >= 0)
            {
                grdJliner2.UpdateRow(grdJliner2.EditIndex, true);
            }

            // Delete jliner
            Guid id = new Guid(((Label)grdJliner2.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdJliner2.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
            int companyId = Int32.Parse(((Label)grdJliner2.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);
            
            JlinerAddJunctionLiner2 model = new JlinerAddJunctionLiner2(jlinerAddTDS);
            model.Delete(id, refId, companyId);

            // ... delete comments
            JlinerAddJunctionLiner2CommentGateway jlinerAddJunctionLiner2CommentGateway = new JlinerAddJunctionLiner2CommentGateway(jlinerAddTDS);
            jlinerAddJunctionLiner2CommentGateway.LoadAllByIdRefId(id, refId, companyId);
            JlinerAddJunctionLiner2Comment jlinerAddJunctionLiner2Comment = new JlinerAddJunctionLiner2Comment(jlinerAddJunctionLiner2CommentGateway.Data);
            jlinerAddJunctionLiner2Comment.DeleteAllCommentsForAJliner(id, refId, companyId);
            
            // Save dataset
            Session["jlinerAddTDS"] = jlinerAddTDS;
        }



        protected void grdJliner2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Jliner Gridview, if the gridview is edition mode
                    if (grdJliner2.EditIndex >= 0)
                    {
                        grdJliner2.UpdateRow(grdJliner2.EditIndex, true);
                    }

                    // Add New jliner
                    GrdJLinerAdd();
                    break;
            }
        }



        protected void grdJliner2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                Guid id = new Guid(((Label)grdJliner2.Rows[e.RowIndex].Cells[0].FindControl("lblIDEdit")).Text);
                int refId = Int32.Parse(((Label)grdJliner2.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text);
                int companyId = Int32.Parse(((Label)grdJliner2.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_IDEdit")).Text);                
                string detailId = ((TextBox)grdJliner2.Rows[e.RowIndex].Cells[4].FindControl("tbxDetailIdEdit")).Text.Trim();
                string address = ""; if (((TextBox)grdJliner2.Rows[e.RowIndex].Cells[5].FindControl("tbxAddressEdit")).Text.Trim() != "") address = ((TextBox)grdJliner2.Rows[e.RowIndex].Cells[5].FindControl("tbxAddressEdit")).Text.Trim();
                double? distanceFromUSMH = null; if (((TextBox)grdJliner2.Rows[e.RowIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)grdJliner2.Rows[e.RowIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim());                

                // Calculate fields
                double? distanceFromDSMH = null;
                if (distanceFromUSMH.HasValue)
                {
                    Distance length = new Distance(tbxActualLength.Text.Trim()) - new Distance(distanceFromUSMH.ToString());
                    distanceFromDSMH = length.ToDoubleInEng3();
                }

                JlinerAddJunctionLiner2 model = new JlinerAddJunctionLiner2(jlinerAddTDS);
                model.Update(id, refId, companyId, detailId, address, distanceFromUSMH, distanceFromDSMH );

                Session["jlinerAddTDS"] = jlinerAddTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - JLINER - AUXILIAR EVENTS
        //

        protected void grdJliner2_DataBound(object sender, EventArgs e)
        {
            AddJlinerNewEmptyFix(grdJliner2);
        }



        protected void grdJliner2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Initialize values
                if (((Label)e.Row.FindControl("lblHistory")).Text == "---Loaded---")
                {
                    e.Row.FindControl("ibtnEdit").Visible = false;
                    e.Row.FindControl("ibtnDelete").Visible = false;
                }
                else
                {
                    e.Row.FindControl("ibtnEdit").Visible = true;
                    e.Row.FindControl("ibtnDelete").Visible = true;
                }                
            }
        }



        protected void grdJliner2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdJliner2 Gridview, if the gridview is edition mode
            if (grdJliner2.EditIndex >= 0)
            {
                grdJliner2.UpdateRow(grdJliner2.EditIndex, true);
            }
        }




        protected void cvDistanceFromUsmhEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            double? distanceFromUsmhFooter = null;
            if (((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim() != "")
            {
                distanceFromUsmhFooter = double.Parse(((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim());
                if (distanceFromUsmhFooter < 0)
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvDistanceDsmhEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            double? distanceFromUsmhFooter = null;
            double? distanceFromDSMH = null;

            // Calculate distance from Dsmh
            if (((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim() != "")
            {
                distanceFromUsmhFooter = double.Parse(((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[6].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim());
                Distance length = new Distance(tbxActualLength.Text.Trim()) - new Distance(distanceFromUsmhFooter.ToString());
                distanceFromDSMH = length.ToDoubleInEng3();            

                if (distanceFromDSMH < 0)
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvDistanceFromUsmhFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            double? distanceFromUsmhFooter = null;
            if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim() != "")
            {
                distanceFromUsmhFooter = double.Parse(((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim());
                if (distanceFromUsmhFooter < 0)
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvDistanceDsmhFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            double? distanceFromUsmhFooter = null;
            double? distanceFromDSMH = null;
            
            // Calculate distance form dsmh
            if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim() != "")
            {
                distanceFromUsmhFooter = double.Parse(((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim());
                Distance length = new Distance(tbxActualLength.Text.Trim()) - new Distance(distanceFromUsmhFooter.ToString());
                distanceFromDSMH = length.ToDoubleInEng3();

                if (distanceFromDSMH < 0)
                {
                    args.IsValid = false;
                }
            }            
        }



        protected void cvDetailIdFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            args.IsValid = true;
            string detailIdFooter = args.Value.Trim();

            foreach (GridViewRow row in grdJliner2.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && (row.RowState == DataControlRowState.Normal))
                {
                    string detailId = ((Label)row.FindControl("lblLateralId")).Text.Trim();

                    if (detailId == detailIdFooter)
                    {
                        count = count + 1;
                    }
                }
            }

            if (count > 0)
            {
                args.IsValid = false;
            }
        }



        protected void cvProvideLateralIdFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            double? distanceFromUsmhFooter = null; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim()!="") distanceFromUsmhFooter = double.Parse(((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim());
            string addressFooter = ""; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim() != "") addressFooter = ((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim();

            if (((distanceFromUsmhFooter.HasValue) || (addressFooter != "")) && (args.Value == ""))
            {
                args.IsValid = false;
            }
        }



        protected void cvProvideLateralIdEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            double? distanceFromUsmhEdit = null; if (((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[4].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim() != "") distanceFromUsmhEdit = double.Parse(((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[4].FindControl("tbxDistanceFromUSMHEdit")).Text.Trim());
            string addressEdit = ""; if (((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[4].FindControl("tbxAddressEdit")).Text.Trim() != "") addressEdit = ((TextBox)grdJliner2.Rows[grdJliner2.EditIndex].Cells[4].FindControl("tbxAddressEdit")).Text.Trim();

            if (((distanceFromUsmhEdit.HasValue) || (addressEdit != "")) && (args.Value == ""))
            {
                args.IsValid = false;
            }

            if (((!distanceFromUsmhEdit.HasValue) || (addressEdit == "")) && (args.Value == ""))
            {
                args.IsValid = false;
            }
        }



        protected void cvDetailIdEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            args.IsValid = true;
            string detailIdNew = args.Value.Trim();
            string detailId = "";

            foreach (GridViewRow row in grdJliner2.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && (row.RowState == DataControlRowState.Normal))
                {
                    detailId = ((Label)row.FindControl("lblLateralId")).Text.Trim();
                }                               

                if (detailId == detailIdNew)
                {
                    count = count + 1;
                }
            }

            if (count > 0)
            {
                args.IsValid = false;
            }
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// STEP3 - JLINER - PUBLIC METHODS
        ///

        public JlinerAddTDS.JunctionLiner2DataTable GetJlinerNew()
        {
            jliner2 = (JlinerAddTDS.JunctionLiner2DataTable)Session["jliner2Dummy"];
            if (jliner2 == null)
            {
                jliner2 = (JlinerAddTDS.JunctionLiner2DataTable)Session["jliner2"];
            }

            return jliner2;
        }



        public void DummyJlinerNew(Guid ID, int RefID, int COMPANY_ID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - JLINER - PRIVATE METHODS
        //


        private void StepJlinerIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please add laterals";

            // Prepare initial data
            Session.Remove("jliner2Dummy");

            // ... for Section
            string recordId = hdfRecordId.Value;
            Guid id = new Guid(hdfSelectedId.Value);

            hdfID.Value = id.ToString();
            tbxRecordId.Text = recordId;
            tbxStreet.Text = hdfStreet.Value;
            tbxActualLength.Text = hdfActualLength.Value;
            tbxUSMH.Text = hdfUsmh.Value;
            tbxDSMH.Text = hdfDsmh.Value;

            // ... for Jliner
            int companyId = Int32.Parse(Session["companyID"].ToString());
            JlinerAddJunctionLiner2 jlinerAddJunctionLiner2 = new JlinerAddJunctionLiner2(jlinerAddTDS);
            jlinerAddJunctionLiner2.LoadForAdd(id, companyId);

            Session["jlinerAddTDS"] = jlinerAddTDS;
            jliner2 = jlinerAddTDS.JunctionLiner2;
            Session["jliner2"] = jliner2;
            grdJliner2.DataBind();
        }



        private bool StepJlinerPrevious()
        {
            // Cancel all jliners inserted
            sectionTDS.RejectChanges();
            sectionTDS.LFS_JUNCTION_LINER2.Clear();

            return true;
        }



        private bool StepJlinerFinish()
        {
            // Validate data
            bool validData = true;

            // Edit if there is data to save
            Page.Validate("dataEdit");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // Conditions Gridview, if the gridview is edition mode
                if (grdJliner2.EditIndex >= 0)
                {
                    grdJliner2.UpdateRow(grdJliner2.EditIndex, true);
                    grdJliner2.DataBind();
                }
            }

            Page.Validate("dataFooter");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // Add conditions if exists at footer
                GrdJLinerAdd();

                // Save Data
                PostPageChanges();
                UpdateDatabase();
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddJlinerNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                JlinerAddTDS.JunctionLiner2DataTable dt = new JlinerAddTDS.JunctionLiner2DataTable();
                dt.AddJunctionLiner2Row(Guid.NewGuid(), -1, -1, "", "", new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), new DateTime(), "", new DateTime(), new DateTime(), new DateTime(), -1, new DateTime(), new DateTime(), new DateTime(), -1, -1, "", "", -1, false, new DateTime(), false, false, "", false, "", "", new DateTime(), new DateTime(), "", "", false, "", new DateTime(), false);
                Session["jliner2Dummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                JlinerAddTDS.JunctionLiner2DataTable dt = (JlinerAddTDS.JunctionLiner2DataTable)Session["jliner2Dummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdJLinerAdd()
        {
            Page.Validate("dataFooter");
            if (Page.IsValid)
            {
                if (ValidateJlinerFooter())
                {
                    Guid id = new Guid(hdfSelectedId.Value);                    
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    string detailId = ""; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDetailIdFooter")).Text.Trim() != "") detailId = ((TextBox)grdJliner2.FooterRow.FindControl("tbxDetailIdFooter")).Text.Trim();
                    string address = ""; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim() != "") address = ((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim();
                    double? distanceFromUSMH = null; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim());
                    int buildRebuild = 0;
                    bool inDatabase = false;
                    string issue = "No";

                    // Calculate fields
                    double? distanceFromDSMH = null;
                    if (distanceFromUSMH.HasValue)
                    {
                        Distance length = new Distance(tbxActualLength.Text.Trim()) - new Distance(distanceFromUSMH.ToString());
                        distanceFromDSMH = length.ToDoubleInEng3();
                    }

                    JlinerAddJunctionLiner2 model = new JlinerAddJunctionLiner2(jlinerAddTDS);
                    model.Insert(id, companyId, detailId, address, null, null, null, null, null, null, null, null, null, "", null, null, null, buildRebuild, null, null, null, distanceFromUSMH, distanceFromDSMH, "", issue, null, false, null, false, false, "", false, "", "", null, null, "", "", false, "", null, inDatabase);

                    Session.Remove("jliner2Dummy");
                    Session["jlinerAddTDS"] = jlinerAddTDS;
                    jliner2 = jlinerAddTDS.JunctionLiner2;
                    masterArea = jlinerAddTDS.MasterArea;
                    Session["masterArea"] = masterArea;

                    grdJliner2.DataBind();
                    grdJliner2.PageIndex = grdJliner2.PageCount - 1;
                }
            }
        }



        private bool ValidateJlinerFooter()
        {
            string detailId = ""; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDetailIdFooter")).Text.Trim() != "") detailId = ((TextBox)grdJliner2.FooterRow.FindControl("tbxDetailIdFooter")).Text.Trim();
            string address = ""; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim() != "") address = ((TextBox)grdJliner2.FooterRow.FindControl("tbxAddressFooter")).Text.Trim();
            double? distanceFromUSMH = null; if (((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)grdJliner2.FooterRow.FindControl("tbxDistanceFromUSMHFooter")).Text.Trim());

            if ((detailId != "") || (distanceFromUSMH.HasValue) || (address != ""))
            {
                return true;
            }

            return false;
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title
            mWizard2 master = (mWizard2)this.Master;
            master.WizardTitle = "Add Laterals";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_add.js");
        }



        private void PostPageChanges()
        {
            // Get selected id
            string recordId = hdfRecordId.Value;
            Guid id = new Guid(hdfSelectedId.Value);
            int companyId = Int32.Parse(Session["companyID"].ToString());

            JlinerAddMasterArea jlinerAddMasterArea = new JlinerAddMasterArea(jlinerAddTDS);
            jlinerAddMasterArea.UpdateJliners(id, companyId);

            Session["jlinerAddTDS"] = jlinerAddTDS;            
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                Guid id = new Guid(hdfSelectedId.Value);
                int companyId = Int32.Parse(Session["companyID"].ToString());

                // Save jliner2
                JlinerAddJunctionLiner2 jlinerAddJunctionLiner2 = new JlinerAddJunctionLiner2(jlinerAddTDS);
                jlinerAddJunctionLiner2.Save(id, companyId);

                // Save section
                JlinerAddMasterArea jlinerAddMasterArea = new JlinerAddMasterArea(jlinerAddTDS);
                jlinerAddMasterArea.Save(id, companyId);

                // Save jliner2comments
                JlinerAddJunctionLiner2Comment jlinerAddJunctionLiner2Comment = new JlinerAddJunctionLiner2Comment(jlinerAddTDS);
                jlinerAddJunctionLiner2Comment.Save(id, companyId);

                DB.CommitTransaction();

                // Store datasets
                jlinerAddTDS.AcceptChanges();
                Session["jlinerAddTDS"] = jlinerAddTDS;                
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private bool GetRecordId()
        {
            bool idIsSelected = false;
            int companyId = Int32.Parse(Session["companyID"].ToString());
            JlinerAddMasterArea jlinerAddMasterArea = new JlinerAddMasterArea(jlinerAddTDS);

            // Update rows
            foreach (GridViewRow row in grdSection.Rows)
            {
                Guid id = new Guid(((Label)row.FindControl("lblID")).Text);
                string recordId = ((Label)row.FindControl("lblRecordId")).Text;
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                string street = ((Label)row.FindControl("lblStreetGrid")).Text;
                string actualLength = ((Label)row.FindControl("lblActualLengthGrid")).Text;
                string usmh = ((Label)row.FindControl("lblUsmh")).Text;
                string dsmh = ((Label)row.FindControl("lblDsmh")).Text;

                jlinerAddMasterArea.Update(id, companyId, selected);
                
                // ... Save selected project
                if (selected)
                {
                    hdfRecordId.Value = recordId;
                    hdfSelectedId.Value = id.ToString();
                    hdfStreet.Value = street;
                    hdfActualLength.Value = actualLength;
                    hdfUsmh.Value = usmh;
                    hdfDsmh.Value = dsmh;
                    idIsSelected = true;
                }
            }

            return idIsSelected;
        }          
                


    }
}