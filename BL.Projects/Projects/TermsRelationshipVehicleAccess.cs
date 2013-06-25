using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// TermsRelationshipVehicleAccess
    /// </summary>
    public class TermsRelationshipVehicleAccess : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TermsRelationshipVehicleAccess()
            : base("LFS_PROJECT_TERMS_RELATIONSHIP_VEHICLE_ACCESS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TermsRelationshipVehicleAccess(DataSet data)
            : base(data, "LFS_PROJECT_TERMS_RELATIONSHIP_VEHICLE_ACCESS")
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
        /// LoadAndAddItem
        /// </summary>
        /// <param name="vehicleAccess">vehicleAccess</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string vehicleAccess)
        {
            // Add item
            CreateTableStructure();
            Insert(vehicleAccess);

            // Load working details list
            TermsRelationshipVehicleAccessGateway termsRelationshipVehicleAccessGateway = new TermsRelationshipVehicleAccessGateway(Data);
            termsRelationshipVehicleAccessGateway.ClearBeforeFill = false;
            termsRelationshipVehicleAccessGateway.Load();
            termsRelationshipVehicleAccessGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="vehicleAccess">vehicleAccess</param>
        public void Insert(string vehicleAccess)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["RelationshipVehicleAccess"] = vehicleAccess;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            DataTable table = new DataTable("LFS_PROJECT_TERMS_RELATIONSHIP_VEHICLE_ACCESS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "RelationshipVehicleAccess";
            Table.Columns.Add(column);
        }



    }
}
