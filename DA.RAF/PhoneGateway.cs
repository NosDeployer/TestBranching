using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.RAF;


namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// PhoneGateway
    /// </summary>
    public class PhoneGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PhoneGateway()
            : base("Phone")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PhoneGateway(DataSet data)
            : base(data, "Phone")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PhoneTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "Phone";
            tableMapping.ColumnMappings.Add("PHONE_ID", "PHONE_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CONTACTS_ID", "CONTACTS_ID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("TELEPHONE", "TELEPHONE");
            tableMapping.ColumnMappings.Add("TELEPHONE_EXT", "TELEPHONE_EXT");
            tableMapping.ColumnMappings.Add("TELEPHONE_TYPE", "TELEPHONE_TYPE");
            tableMapping.ColumnMappings.Add("ACTIVE", "ACTIVE");
            tableMapping.ColumnMappings.Add("PRIMARY_PHONE", "PRIMARY_PHONE");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByContactId
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByContactId(int contactId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_PHONEGATEWAY_LOADBYCONTACTID", new SqlParameter("@contactId", contactId), new SqlParameter("@companyId", companyId));  
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.AddressGateway.GetRow");
            }
        }



        /// <summary>
        /// GePhones
        /// </summary>
        /// <param name="contactId">contactId</param>
        public string GetPhones(int contactId)
        {
            string phones = "";
            string verifiedPhones = "";

            foreach (DataRow row in this.Table.Rows)
            {
                object selectedPhone = row["TELEPHONE"];
                object selectedPhoneExt = row["TELEPHONE_EXT"];
                object selectedPhoneType = row["TELEPHONE_TYPE"];

                // Unavailable
                if (!GetActive(contactId))
                {
                    verifiedPhones = "Type: " + (string)selectedPhoneType + " Num: " + (string)selectedPhone;
                    if ((string)selectedPhoneExt != "")
                    {
                        verifiedPhones = verifiedPhones + " - " + (string)selectedPhoneExt;
                    }
                    verifiedPhones = verifiedPhones + " (Unavailable)";

                }
                else
                {
                    verifiedPhones = "Type: " + (string)selectedPhoneType + " Num: " + (string)selectedPhone;
                    if ((string)selectedPhoneExt != "")
                    {
                        verifiedPhones = verifiedPhones + " - " + (string)selectedPhoneExt;
                    }
                }

                if ((selectedPhone != null) || (selectedPhone != DBNull.Value))
                {
                    phones = phones + verifiedPhones + "\n";
                }

            }
            return (phones);
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>ACTIVE</returns>
        public bool GetActive(int contactId)
        {
            return (bool)GetRow(contactId)["ACTIVE"];
        }
    }
}
