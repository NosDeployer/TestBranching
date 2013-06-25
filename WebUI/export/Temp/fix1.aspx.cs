using System;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class fix1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            // Set title
            mWizard master = (mWizard)this.Master;
            master.WizardTitle = "Fix1";
        }



        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Fix1SectionGateway fix1SectionGateway = new Fix1SectionGateway();
            
            //Initialize all values
            fix1SectionGateway.InitializeAllSections();
         
            // Load all sections that have jliners
            fix1SectionGateway.Load();

            // Fix data
            Fix1Section fix1section = new Fix1Section(fix1SectionGateway.Data);
            fix1section.SectionUpdate();

            fix1SectionGateway.Update();
        }



        protected void btnFixCommentsAndHistory_Click(object sender, EventArgs e)
        {
            Fix1JlinerGateway fix1JlinerGateway = new Fix1JlinerGateway();
            
            // Load all jliners
            fix1JlinerGateway.LoadAll();

            Fix1Jliner fix1Jliner = new Fix1Jliner(fix1JlinerGateway.Data);
            fix1Jliner.UpdateCommentsHistory();

            fix1JlinerGateway.Update();
        }



        protected void btnAvailableToLine_Click(object sender, EventArgs e)
        {
            Fix1WorkJuntionLiningSectionTDS fix1WorkJunctionLiningSectionTDS = new Fix1WorkJuntionLiningSectionTDS();
            
            // load section
            Fix1WorkJunctionLiningSectionGateway fix1WorkJunctionLiningSectionGateway = new Fix1WorkJunctionLiningSectionGateway(fix1WorkJunctionLiningSectionTDS);
            fix1WorkJunctionLiningSectionGateway.Load(3);

            Fix1WorkJunctionLiningSection fix1WorkJunctionLiningSection = new Fix1WorkJunctionLiningSection(fix1WorkJunctionLiningSectionGateway.Data);
            fix1WorkJunctionLiningSection.UpdateSection(3);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fix1.js");
        }



    }
}