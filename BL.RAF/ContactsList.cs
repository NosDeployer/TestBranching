using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.RAF
{
    /// <summary>
    /// ContactsList
    /// </summary>
    public class ContactsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactsList() : base("CONTACTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ContactsList(DataSet data) : base(data, "CONTACTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllAndAddItem
        /// </summary>
        /// <param name="contactsId">contactsId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllAndAddItem(int? contactsId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(contactsId, name);

            // Load contacts list
            ContactsListGateway contactsListGateway = new ContactsListGateway(Data);
            contactsListGateway.ClearBeforeFill = false;
            contactsListGateway.LoadAll(companyId);
            contactsListGateway.ClearBeforeFill = true;

            return Data;
        }

        
        
        /// <summary>
        /// LoadAllAndAddItemByCompaniesId
        /// </summary>
        /// <param name="contactsId">contactsId</param>
        /// <param name="name">name</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllAndAddItemByCompaniesId(int? contactsId, string name, int companiesId, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(contactsId, name);

            // Load contacts list
            ContactsListGateway contactsListGateway = new ContactsListGateway(Data);
            contactsListGateway.ClearBeforeFill = false;
            contactsListGateway.LoadAllByCompaniesId(companiesId, companyId);
            contactsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="contactsId">contactsId</param>
        /// <param name="name">name</param>
        public void Insert(int? contactsId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            if (contactsId.HasValue)
            {
                newRow["CONTACTS_ID"] = (int)contactsId;
            }
            newRow["NAME"] = name;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("CONTACTS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CONTACTS_ID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NAME";
            Table.Columns.Add(column);
        }



    }
}
