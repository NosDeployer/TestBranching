using System;
using System.Data;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsPaymentTypeList
    /// </summary>
    public class VacationsPaymentTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsPaymentTypeList()
            : base("LFS_VACATION_PAYMENTTYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsPaymentTypeList(DataSet data)
            : base(data, "LFS_VACATION_PAYMENTTYPE")
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
        /// <returns>DataSet</returns>
        public DataSet Load(int companyId)
        {
            // Add item
            CreateTableStructure();

            // Load Payment Type list
            VacationsPaymentTypeListGateway vacationsPaymentTypeListGateway = new VacationsPaymentTypeListGateway(Data);
            vacationsPaymentTypeListGateway.ClearBeforeFill = false;
            vacationsPaymentTypeListGateway.Load(companyId);
            vacationsPaymentTypeListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("LFS_VACATION_PAYMENTTYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PaymentType";
            Table.Columns.Add(column);
        }



    }
}