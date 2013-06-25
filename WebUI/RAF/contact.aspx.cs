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
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.RAF
{
    /// <summary>
    /// Shows Contacts dialog
    /// </summary>
    public partial class contact : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PhoneTDS phoneTDS;
        protected PhoneTDS.PhoneDataTable phone;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfContactId.Value = Request.QueryString["contact_id"].ToString();

                // Initialize viewstate variables
                Session.Remove("phonesDummy");
                phoneTDS = new PhoneTDS();

                // Load data 
                LoadFullName();
                LoadAddress();
                LoadPhones();

                // Store dataset
                Session["phoneTDS"] = phoneTDS;
                Session["phone"] = phoneTDS.Phone;
            }
            else
            {
                // Restore dataset 
                phoneTDS = (PhoneTDS)Session["phoneTDS"];
                phone = phoneTDS.Phone;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Contact Info";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdTelephones_DataBound(object sender, EventArgs e)
        {
            AddPhonesNewEmptyFix(grdTelephones);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public PhoneTDS.PhoneDataTable GetPhonesNew()
        {
            phone = (PhoneTDS.PhoneDataTable)Session["phonesDummy"];
            if (phone == null)
            {
                phone = ((PhoneTDS.PhoneDataTable)Session["phone"]);
            }

            return phone;
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./contact.js");
        }



        private void LoadFullName()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int contactId = Int32.Parse(hdfContactId.Value);

            ContactsGateway contactsGateway = new ContactsGateway();
            contactsGateway.LoadAllByContactId(contactId, companyId);

            if (contactsGateway.Table.Rows.Count > 0)
            {
                tbxName.Text = contactsGateway.GetCompleteName(contactId);
            }
            else
            {
                tbxName.Text = "";
            }
        }



        private void LoadAddress()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int contactId = Int32.Parse(hdfContactId.Value);

            AddressGateway addressGateway = new AddressGateway();
            addressGateway.LoadByContactId(contactId, companyId);

            if (addressGateway.Table.Rows.Count > 0)
            {
                tbxAddress.Text = addressGateway.GetAddress(contactId);
                tbxCity.Text = addressGateway.GetCity(contactId);
                tbxProvState.Text = addressGateway.GetProvinceFullName(contactId);
                tbxPostalCode.Text = addressGateway.GetPostalCode(contactId);
                tbxCountry.Text = addressGateway.GetCountry(contactId);

            }
            else
            {
                tbxAddress.Text = "";
                tbxCity.Text = "";
                tbxProvState.Text = "";
                tbxPostalCode.Text = "";
                tbxCountry.Text = "";
            }
        }



        private void LoadPhones()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int contactId = Int32.Parse(hdfContactId.Value);

            PhoneGateway phoneGateway = new PhoneGateway(phoneTDS);
            phoneGateway.LoadByContactId(contactId, companyId);
        }



        protected void AddPhonesNewEmptyFix(GridView grdTelephones)
        {
            if (grdTelephones.Rows.Count == 0)
            {
                PhoneTDS.PhoneDataTable dt = new PhoneTDS.PhoneDataTable();
                dt.AddPhoneRow(-1, -1, -1, "", "", "", false, false);
                Session["phonesDummy"] = dt;

                grdTelephones.DataBind();
            }

            // Normally executes at all postbacks
            if (grdTelephones.Rows.Count == 1)
            {
                PhoneTDS.PhoneDataTable dt = (PhoneTDS.PhoneDataTable)Session["phonesDummy"];
                if (dt != null)
                {
                    grdTelephones.Rows[0].Visible = false;
                    grdTelephones.Rows[0].Controls.Clear();
                }
            }
        }


    }
}
