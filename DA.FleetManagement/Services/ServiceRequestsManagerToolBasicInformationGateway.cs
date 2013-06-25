using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServiceRequestsManagerToolBasicInformationGateway
    /// </summary>
    public class ServiceRequestsManagerToolBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceRequestsManagerToolTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ServiceNumber", "ServiceNumber");
            tableMapping.ColumnMappings.Add("ServiceState", "ServiceState");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("AssignmentDateTime", "AssignmentDateTime");
            tableMapping.ColumnMappings.Add("AssignedDeadlineDate", "AssignedDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignTeamMember", "AssignTeamMember");
            tableMapping.ColumnMappings.Add("AssignTeamMemberID", "AssignTeamMemberID");
            tableMapping.ColumnMappings.Add("AssignThirdPartyVendor", "AssignThirdPartyVendor");
            tableMapping.ColumnMappings.Add("AcceptDateTime", "AcceptDateTime");
            tableMapping.ColumnMappings.Add("RejectDateTime", "RejectDateTime");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");
            tableMapping.ColumnMappings.Add("StartWorkDateTime", "StartWorkDateTime");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceDate", "UnitOutOfServiceDate");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceTime", "UnitOutOfServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
            tableMapping.ColumnMappings.Add("UnitBackInServiceDate", "UnitBackInServiceDate");
            tableMapping.ColumnMappings.Add("UnitBackInServiceTime", "UnitBackInServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMCost", "CompleteWorkDetailTMCost");
            tableMapping.ColumnMappings.Add("CompleteWorkInvoiceNumber", "CompleteWorkInvoiceNumber");
            tableMapping.ColumnMappings.Add("CompleteWorkInvoiceAmount", "CompleteWorkInvoiceAmount");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            tableMapping.ColumnMappings.Add("UnitCompanyLevelID", "UnitCompanyLevelID");
            tableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
            tableMapping.ColumnMappings.Add("Mileage", "Mileage");
            tableMapping.ColumnMappings.Add("StartWorkMileage", "StartWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkMileage", "CompleteWorkMileage");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("AssociatedChecklistRule", "AssociatedChecklistRule");
            tableMapping.ColumnMappings.Add("AssociatedChecklistRuleState", "AssociatedChecklistRuleState");
            tableMapping.ColumnMappings.Add("AssociatedChecklistLastService", "AssociatedChecklistLastService");
            tableMapping.ColumnMappings.Add("AssociatedChecklistNextDue", "AssociatedChecklistNextDue");
            tableMapping.ColumnMappings.Add("AssociatedChecklistDone", "AssociatedChecklistDone");
            tableMapping.ColumnMappings.Add("AssociatedChecklistDeleted", "AssociatedChecklistDeleted");
            tableMapping.ColumnMappings.Add("AssociatedChecklistCompanyId", "AssociatedChecklistCompanyId");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
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
        /// LoadByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEREQUESTSMANAGERTOOLBASICINFORMATIONGATEWAY_LOADBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId)
        {
            string filter = string.Format("ServiceID = {0}", serviceId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServiceRequestsManagerToolBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetServiceNumber Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ServiceNumber</returns>
        public string GetServiceNumberOriginal(int serviceId)
        {
            return (string)GetRow(serviceId)["ServiceNumber", DataRowVersion.Original];
        }
        


        /// <summary>
        /// GetServiceDescription Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ServiceDescription</returns>
        public string GetServiceDescriptionOriginal(int serviceId)
        {
            return (string)GetRow(serviceId)["ServiceDescription", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNotes Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original Notes or EMPTY</returns>
        public string GetNotesOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["Notes"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["Notes", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetServiceState
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ServiceState</returns>
        public string GetServiceState(int serviceId)
        {            
            return (string)GetRow(serviceId)["ServiceState"];
        }



        /// <summary>
        /// GetServiceState Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ServiceState</returns>
        public string GetServiceStateOriginal(int serviceId)
        {
            return (string)GetRow(serviceId)["ServiceState", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original DateTime_</returns>
        public DateTime GetDateTime_Original(int serviceId)
        {
            return (DateTime)GetRow(serviceId)["DateTime_", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetMto Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original MtoDot</returns>
        public bool GetMtoOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["MTO", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetUnitId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitID or null</returns>
        public int? GetUnitId(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["UnitID"];
            }
        }



        /// <summary>
        /// GetUnitID Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitID or null</returns>
        public int? GetUnitIdOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["UnitID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRuleID Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original RuleID or null</returns>
        public int? GetRuleIdOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["RuleID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["RuleID", DataRowVersion.Original];
            }
        }
        


        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original Type</returns>
        public string GetTypeOriginal(int serviceId)
        {
            return (string)GetRow(serviceId)["Type", DataRowVersion.Original];
        }



        /// <summary>
        /// GetOwnerId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original OwnerID</returns>
        public int GetOwnerIdOriginal(int serviceId)
        {
            return (int)GetRow(serviceId)["OwnerID", DataRowVersion.Original];
        }
              

                
        /// <summary>
        /// GetAssignmentDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssignmentDateTime or null</returns>
        public DateTime? GetAssignmentDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssignmentDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssignmentDateTime"];
            }
        }



        /// <summary>
        /// GetAssignmentDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignmentDateTime or null</returns>
        public DateTime? GetAssignmentDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssignmentDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssignmentDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssignedDeadlineDate
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssignedDeadlineDate or null</returns>
        public DateTime? GetAssignedDeadlineDate(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssignedDeadlineDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssignedDeadlineDate"];
            }
        }



        /// <summary>
        /// GetAssignedDeadlineDate Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignedDeadlineDate or null</returns>
        public DateTime? GetAssignedDeadlineDateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssignedDeadlineDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssignedDeadlineDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssignTeamMember 
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssignTeamMember</returns>
        public bool GetAssignTeamMember(int serviceId)
        {
            return (bool)GetRow(serviceId)["AssignTeamMember"];
        }



        /// <summary>
        /// GetAssignTeamMember Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignTeamMember</returns>
        public bool GetAssignTeamMemberOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["AssignTeamMember", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAssignTeamMemberId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssignTeamMemberID or null</returns>
        public int? GetAssignTeamMemberId(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssignTeamMemberID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["AssignTeamMemberID"];
            }
        }



        /// <summary>
        /// GetAssignTeamMemberID Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignTeamMemberID or null</returns>
        public int? GetAssignTeamMemberIdOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssignTeamMemberID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["AssignTeamMemberID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssignedThirdPartyVendor
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssignedThirdPartyVendor or EMPTY</returns>
        public string GetAssignedThirdPartyVendor(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssignThirdPartyVendor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssignThirdPartyVendor"];
            }
        }



        /// <summary>
        /// GetAssignedThirdPartyVendor Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignedThirdPartyVendor or EMPTY</returns>
        public string GetAssignedThirdPartyVendorOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssignThirdPartyVendor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssignThirdPartyVendor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAcceptedDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AcceptedDateTime or null</returns>
        public DateTime? GetAcceptedDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AcceptDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AcceptDateTime"];
            }
        }



        /// <summary>
        /// GetAcceptedDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AcceptedDateTime or null</returns>
        public DateTime? GetAcceptedDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AcceptDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AcceptDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRejectDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>RejectDateTime or null</returns>
        public DateTime? GetRejectDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("RejectDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["RejectDateTime"];
            }
        }



        /// <summary>
        /// GetRejectDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original RejectDateTime or null</returns>
        public DateTime? GetRejectDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["RejectDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["RejectDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRejectReason
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>RejectReason or EMPTY</returns>
        public string GetRejectReason(int serviceId)
        {
            if (GetRow(serviceId).IsNull("RejectReason"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["RejectReason"];
            }
        }



        /// <summary>
        /// GetRejectReason Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original RejectReason or EMPTY</returns>
        public string GetRejectReasonOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["RejectReason"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["RejectReason", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStartWorkDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>StartWorkDateTime or null</returns>
        public DateTime? GetStartWorkDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("StartWorkDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["StartWorkDateTime"];
            }
        }



        /// <summary>
        /// GetStartWorkDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original StartWorkDateTime or null</returns>
        public DateTime? GetStartWorkDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["StartWorkDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["StartWorkDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitOutOfServiceDate
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitOutOfServiceDate or null</returns>
        public DateTime? GetUnitOutOfServiceDate(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitOutOfServiceDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["UnitOutOfServiceDate"];
            }
        }



        /// <summary>
        /// GetUnitOutOfServiceDate Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitOutOfServiceDate or null</returns>
        public DateTime? GetUnitOutOfServiceDateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitOutOfServiceDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["UnitOutOfServiceDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitOutOfServiceTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitOutOfServiceTime or EMPTY</returns>
        public string GetUnitOutOfServiceTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitOutOfServiceTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitOutOfServiceTime"];
            }
        }



        /// <summary>
        /// GetUnitOutOfServiceTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitOutOfServiceTime or EMPTY</returns>
        public string GetUnitOutOfServiceTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitOutOfServiceTime"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitOutOfServiceTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDateTime or null</returns>
        public DateTime? GetCompleteWorkDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["CompleteWorkDateTime"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDateTime or null</returns>
        public DateTime? GetCompleteWorkDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["CompleteWorkDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitBackInServiceDate
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitBackInServiceDate or null</returns>
        public DateTime? GetUnitBackInServiceDate(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitBackInServiceDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["UnitBackInServiceDate"];
            }
        }



        /// <summary>
        /// GetUnitBackInServiceDate Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitBackInServiceDate or null</returns>
        public DateTime? GetUnitBackInServiceDateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitBackInServiceDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["UnitBackInServiceDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitBackInServiceTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitBackInServiceTime or EMPTY</returns>
        public string GetUnitBackInServiceTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitBackInServiceTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitBackInServiceTime"];
            }
        }



        /// <summary>
        /// GetUnitBackInServiceTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitBackInServiceTime or EMPTY</returns>
        public string GetUnitBackInServiceTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitBackInServiceTime"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitBackInServiceTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailDescription
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailDescription or EMPTY</returns>
        public string GetCompleteWorkDetailDescription(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkDetailDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkDetailDescription"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailDescription Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailDescription or EMPTY</returns>
        public string GetCompleteWorkDetailDescriptionOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDetailDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkDetailDescription", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailPreventable 
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailPreventable</returns>
        public bool GetCompleteWorkDetailPreventable(int serviceId)
        {
            return (bool)GetRow(serviceId)["CompleteWorkDetailPreventable"];
        }



        /// <summary>
        /// GetCompleteWorkDetailPreventable Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailPreventable</returns>
        public bool GetCompleteWorkDetailPreventableOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["CompleteWorkDetailPreventable", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCompleteWorkDetailTMLabourHours
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailTMLabourHours or null</returns>
        public decimal? GetCompleteWorkDetailTMLabourHours(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkDetailTMLabourHours"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTMLabourHours"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTMLabourHours Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTMLabourHours or null</returns>
        public decimal? GetCompleteWorkDetailTMLabourHoursOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDetailTMLabourHours"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTMLabourHours", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTMCost
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailTMCost or null</returns>
        public decimal? GetCompleteWorkDetailTMCost(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkDetailTMCost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTMCost"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTMCost Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTMCost or null</returns>
        public decimal? GetCompleteWorkDetailTMCostOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDetailTMCost"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTMCost", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceNumber
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailTPVInvoiceNumber or EMPTY</returns>
        public string GetCompleteWorkDetailTPVInvoiceNumber(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkInvoiceNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkInvoiceNumber"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceNumber Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTPVInvoiceNumber or EMPTY</returns>
        public string GetCompleteWorkDetailTPVInvoiceNumberOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkInvoiceNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkInvoiceNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceAmout
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailTPVInvoiceAmout or null</returns>
        public decimal? GetCompleteWorkDetailTPVInvoiceAmout(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkInvoiceAmount"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkInvoiceAmount"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceAmout Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTPVInvoiceAmout or null</returns>
        public decimal? GetCompleteWorkDetailTPVInvoiceAmoutOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkInvoiceAmount"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkInvoiceAmount", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMileage
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Mileage or EMPTY</returns>
        public string GetMileage(int serviceId)
        {
            if (GetRow(serviceId).IsNull("Mileage"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["Mileage"];
            }
        }



        /// <summary>
        /// GetMileage Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original Mileage or EMPTY</returns>
        public string GetMileageOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["Mileage"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["Mileage", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStartWorkMileage
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>StartWorkMileage or EMPTY</returns>
        public string GetStartWorkMileage(int serviceId)
        {
            if (GetRow(serviceId).IsNull("StartWorkMileage"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["StartWorkMileage"];
            }
        }



        /// <summary>
        /// GetStartWorkMileage Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original StartWorkMileage or EMPTY</returns>
        public string GetStartWorkMileageOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["StartWorkMileage"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["StartWorkMileage", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkMileage
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>StartCompleteWorkMileage or EMPTY</returns>
        public string GetCompleteWorkMileage(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkMileage"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkMileage"];
            }
        }



        /// <summary>
        /// GetCompleteWorkMileage Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkMileage or EMPTY</returns>
        public string GetCompleteWorkMileageOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkMileage"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkMileage", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistRule
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistRule or EMPTY</returns>
        public string GetAssociatedChecklistRule(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssociatedChecklistRule"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssociatedChecklistRule"];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistRule Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistRule or EMPTY</returns>
        public string GetAssociatedChecklistRuleOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssociatedChecklistRule"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssociatedChecklistRule", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistRuleState
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistRuleState or EMPTY</returns>
        public string GetAssociatedChecklistRuleState(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssociatedChecklistRuleState"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssociatedChecklistRuleState"];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistRuleState Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistRuleState or EMPTY</returns>
        public string GetAssociatedChecklistRuleStateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssociatedChecklistRuleState"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssociatedChecklistRuleState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistLastService
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistLastService or null</returns>
        public DateTime? GetAssociatedChecklistLastService(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssociatedChecklistLastService"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssociatedChecklistLastService"];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistLastService Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistLastService or null</returns>
        public DateTime? GetAssociatedChecklistLastServiceOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssociatedChecklistLastService"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssociatedChecklistLastService", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistNextDue
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistNextDue or null</returns>
        public DateTime? GetAssociatedChecklistNextDue(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AssociatedChecklistNextDue"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssociatedChecklistNextDue"];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistNextDue Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistNextDue or null</returns>
        public DateTime? GetAssociatedChecklistNextDueOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssociatedChecklistNextDue"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AssociatedChecklistNextDue", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAssociatedChecklistDone
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistDone</returns>
        public Boolean GetAssociatedChecklistDone(int serviceId)
        {
            return (bool)GetRow(serviceId)["AssociatedChecklistDone"];
        }



        /// <summary>
        /// GetAssociatedChecklistDone Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistDone</returns>
        public Boolean GetAssociatedChecklistDoneOriginal(int serviceId)
        {
            return (Boolean)GetRow(serviceId)["AssociatedChecklistDone", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAssociatedChecklistDeleted
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistDeleted</returns>
        public Boolean GetAssociatedChecklistDeleted(int serviceId)
        {
            return (bool)GetRow(serviceId)["AssociatedChecklistDeleted"];
        }



        /// <summary>
        /// GetAssociatedChecklistDeleted Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistDeleted</returns>
        public Boolean GetAssociatedChecklistDeletedOriginal(int serviceId)
        {
            return (Boolean)GetRow(serviceId)["AssociatedChecklistDeleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAssociatedChecklistCompanyId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AssociatedChecklistCompanyId</returns>
        public int GetAssociatedChecklistCompanyId(int serviceId)
        {
            return (int)GetRow(serviceId)["AssociatedChecklistCompanyId"];
        }



        /// <summary>
        /// GetAssociatedChecklistCompanyId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssociatedChecklistCompanyId</returns>
        public int GetAssociatedChecklistCompanyIdOriginal(int serviceId)
        {
            return (int)GetRow(serviceId)["AssociatedChecklistCompanyId", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLibraryCategoriesId. If service not exists, raise an exception
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Library Categories Id or null</returns>
        public int? GetLibraryCategoriesId(int serviceId)
        {
            if (GetRow(serviceId).IsNull("LIBRARY_CATEGORIES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["LIBRARY_CATEGORIES_ID"];
            }
        }



        // <summary>
        /// GetLibraryCategoriesId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original LIBRARY_CATEGORIES_ID or null</returns>
        public int? GetLibraryCategoriesIdOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["LIBRARY_CATEGORIES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["LIBRARY_CATEGORIES_ID", DataRowVersion.Original];
            }
        }

                     

    }
}