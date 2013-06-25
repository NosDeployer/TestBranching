using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// ContactsGateway
    /// </summary>
    public class ContactsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactsGateway()
            : base("CONTACTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ContactsGateway(DataSet data)
            : base(data, "CONTACTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByContactId
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <param name="companyId">compnyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByContactId(int contactId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_CONTACTSGATEWAY_LOADALLBYCONTACTID", new SqlParameter("@contactId", contactId), new SqlParameter("@companyId", companyId));  //Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int contactId)
        {
            string filter = string.Format("CONTACTS_ID = {0}", contactId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.ContactsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetCompleteName
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>Full name</returns>
        public string GetCompleteName(int contactId)
        {
            string fullName = "";

            // Last Name
            if (!GetRow(contactId).IsNull("LAST_NAME"))
            {
                fullName = fullName + (string)GetRow(contactId)["LAST_NAME"] + " ";
            }

            // First Name
            if (!GetRow(contactId).IsNull("FIRST_NAME"))
            {
                fullName = fullName + (string)GetRow(contactId)["FIRST_NAME"];
            }

            // Unavailable
            if (!GetActive(contactId))
            {
                fullName = fullName + " (Unavailable)";
            }

            return (fullName);
        }



        /// <summary>
        /// GetCompaniesPosition
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>Position</returns>
        public string GetCompaniesPosition(int contactId)
        {
            string contactPosition = "";
            object position = GetRow(contactId)["COMPANIES_POSITION"];
            if ((position != null) && (position != DBNull.Value))
            {
                contactPosition = contactPosition + (string)position + " ";
            }

            // Unavailable
            if (!GetActive(contactId))
            {
                contactPosition = contactPosition + " (Unavailable)";
            }

            return (contactPosition);
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>ACTIVE</returns>
        public bool GetActive(int contactId)
        {
            return (bool)GetRow(contactId)["ACTIVE"];
        }
    }
}
