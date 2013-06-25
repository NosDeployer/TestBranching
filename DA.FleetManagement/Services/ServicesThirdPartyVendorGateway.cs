using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesThirdPartyVendorGateway
    /// </summary>
    public class ServicesThirdPartyVendorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesThirdPartyVendorGateway()
            : base("LFS_FM_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesThirdPartyVendorGateway(DataSet data)
            : base(data, "LFS_FM_SERVICE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesTDS();
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
            tableMapping.DataSetTable = "LFS_FM_SERVICE";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Number", "Number");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AssignDeadlineDate", "AssignDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignTeamMember", "AssignTeamMember");
            tableMapping.ColumnMappings.Add("AssignTeamMemberID", "AssignTeamMemberID");
            tableMapping.ColumnMappings.Add("AssignThirdPartyVendor", "AssignThirdPartyVendor");
            tableMapping.ColumnMappings.Add("AcceptDateTime", "AcceptDateTime");
            tableMapping.ColumnMappings.Add("RejectDateTime", "RejectDateTime");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");
            tableMapping.ColumnMappings.Add("StartWorkDateTime", "StartWorkDateTime");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceDate", "StartWorkOutOfServiceDate");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceTime", "StartWorkOutOfServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceDate", "CompleteWorkBackToServiceDate");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceTime", "CompleteWorkBackToServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMCost", "CompleteWorkDetailTMCost");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceNumber", "CompleteWorkDetailTPVInvoiceNumber");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceAmout", "CompleteWorkDetailTPVInvoiceAmout");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");

            this._adapter.TableMappings.Add(tableMapping);

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //
             

        /// <summary>
        /// LoadSimilarTop12ThirdPartyVendorByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="thirdPartyVendorId">thirdPartyVendorId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadSimilarTop12ThirdPartyVendorByServiceId(Int32 serviceId, string thirdPartyVendorId, int companyId)
        {
            string serviceIdParameter = "ServiceID = " + serviceId.ToString();
            string thirdPartyVendorIdIdParameter = "AssignThirdPartyVendor LIKE '" + thirdPartyVendorId + "%'";
            string companyIdParameter = "COMPANY_ID = " + companyId.ToString();

            string commandText = String.Format("SELECT     TOP 12 ServiceID, Number, DateTime_, MTO, Description, UnitID, Type, State, OwnerID, AssignDateTime, AssignDeadlineDate, AssignTeamMember, "+
                "      AssignTeamMemberID, AssignThirdPartyVendor, AcceptDateTime, RejectDateTime, RejectReason, StartWorkDateTime, StartWorkOutOfServiceDate, "+
                "      StartWorkOutOfServiceTime, CompleteWorkDateTime, CompleteWorkBackToServiceDate, CompleteWorkBackToServiceTime, "+
                "      CompleteWorkDetailDescription, CompleteWorkDetailPreventable, CompleteWorkDetailTMLabourHours, CompleteWorkDetailTMCost, "+
                "      CompleteWorkDetailTPVInvoiceNumber, CompleteWorkDetailTPVInvoiceAmout, Deleted, COMPANY_ID, Notes, RuleID "+
                " FROM         LFS_FM_SERVICE "+
                " WHERE (Deleted = 0) AND {0} AND {1} AND {2} "+
                " ORDER BY MTO DESC, ServiceID", thirdPartyVendorIdIdParameter, serviceIdParameter, companyIdParameter);
            FillData(commandText);

            return Data;
        }

              
    }
}
