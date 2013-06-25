using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// AddressGateway
    /// </summary>
    public class AddressGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AddressGateway()
            : base("Address")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AddressGateway(DataSet data)
            : base(data, "Address")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AddressTDS();
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
            tableMapping.DataSetTable = "Address";
            tableMapping.ColumnMappings.Add("ADDRESS_ID", "ADDRESS_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CONTACTS_ID", "CONTACTS_ID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("ADDRESS_1", "ADDRESS_1");
            tableMapping.ColumnMappings.Add("ADDRESS_2", "ADDRESS_2");
            tableMapping.ColumnMappings.Add("CITY", "CITY");
            tableMapping.ColumnMappings.Add("PROVINCES_ID", "PROVINCES_ID");
            tableMapping.ColumnMappings.Add("POSTAL_CODE", "POSTAL_CODE");
            tableMapping.ColumnMappings.Add("COUNTRY_ID", "COUNTRY_ID");
            tableMapping.ColumnMappings.Add("COUNTRY_NAME", "COUNTRY_NAME");
            tableMapping.ColumnMappings.Add("FULL_NAME", "FULL_NAME");
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
        /// <param name="companyId">compnyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByContactId(int contactId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_ADDRESSGATEWAY_LOADBYCONTACTID", new SqlParameter("@contactId", contactId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">compnyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_ADDRESSGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
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
        /// GetRowByCompaniesId
        /// </summary>
        /// <param name="contactId">companiesId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRowByCompaniesId(int companiesId)
        {
            string filter = string.Format("COMPANIES_ID = {0}", companiesId);

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



        /// <sumary>
        /// GetAddress
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>string</returns>
        public string GetAddress(int contactId)
        {
            string fullAddress = "";

            // Address1
            if (GetRow(contactId).IsNull("ADDRESS_1"))
            {
                fullAddress = fullAddress + "";
            }
            else
            {
                fullAddress = fullAddress + (string)GetRow(contactId)["ADDRESS_1"] + "\n";
            }

            // Address2
            if (GetRow(contactId).IsNull("ADDRESS_2"))
            {
                fullAddress = fullAddress + "";
            }
            else
            {
                fullAddress = fullAddress + (string)GetRow(contactId)["ADDRESS_2"] + "\n";
            }            

            return (fullAddress);
        }



        /// <sumary>
        /// GetAddressByCompaniesId
        /// </summary>
        /// <param name="contactId">companiesId</param>
        /// <returns>string</returns>
        public string GetAddressByCompaniesId(int companiesId)
        {
            string fullAddress = "";

            // Address1
            object address1 = GetRowByCompaniesId(companiesId)["ADDRESS_1"];
            if ((address1 == null) || (address1 == DBNull.Value))
            {
                fullAddress = fullAddress + "";
            }
            else
            {
                fullAddress = fullAddress + (string)address1 + "\n";
            }

            // Address2
            object address2 = GetRowByCompaniesId(companiesId)["ADDRESS_2"];
            if ((address2 == null) || (address2 == DBNull.Value))
            {
                fullAddress = fullAddress + "";
            }
            else
            {
                fullAddress = fullAddress + (string)address2 + "\n";
            }            

            return (fullAddress);
        }



        /// <summary>
        /// GetCity
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>CITY</returns>
        public string GetCity(int contactId)
        {
            if (GetRow(contactId).IsNull("CITY"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(contactId)["CITY"];
            }
        }



        /// <summary>
        /// GetProvinceFullName
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>FULL_NAME</returns>
        public string GetProvinceFullName(int contactId)
        {
            if (GetRow(contactId).IsNull("FULL_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(contactId)["FULL_NAME"];
            }
        }



        /// <summary>
        /// GetPostalCode
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>POSTAL_COD</returns>
        public string GetPostalCode(int contactId)
        {
            if (GetRow(contactId).IsNull("POSTAL_CODE"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(contactId)["POSTAL_CODE"];
            }
        }



        /// <summary>
        /// GetCountry
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>COUNTRY_NAME</returns>
        public string GetCountry(int contactId)
        {
            if (GetRow(contactId).IsNull("COUNTRY_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(contactId)["COUNTRY_NAME"];
            }
        }

    }
}
