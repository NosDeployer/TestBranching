using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesBasicInformationGateway
    /// </summary>
    public class ServiceInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceInformationTDS();
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
            tableMapping.ColumnMappings.Add("MtoDto", "MtoDto");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("AssignmentDateTime", "AssignmentDateTime");
            tableMapping.ColumnMappings.Add("AssignedDeadlineDate", "AssignedDeadlineDate");
            tableMapping.ColumnMappings.Add("ToTeamMember", "ToTeamMember");
            tableMapping.ColumnMappings.Add("AssignTeamMemberID", "AssignTeamMemberID");
            tableMapping.ColumnMappings.Add("AssignedThirdPartyVendor", "AssignedThirdPartyVendor");
            tableMapping.ColumnMappings.Add("AcceptedDateTime", "AcceptedDateTime");
            tableMapping.ColumnMappings.Add("RejectedDateTime", "RejectedDateTime");
            tableMapping.ColumnMappings.Add("RejectedReason", "RejectedReason");
            tableMapping.ColumnMappings.Add("StartWorkDateTime", "StartWorkDateTime");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceDate", "UnitOutOfServiceDate");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceTime", "UnitOutOfServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
            tableMapping.ColumnMappings.Add("UnitBackInServiceTime", "UnitBackInServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMCost", "CompleteWorkDetailTMCost");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceNumber", "CompleteWorkDetailTPVInvoiceNumber");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceAmout", "CompleteWorkDetailTPVInvoiceAmout");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            tableMapping.ColumnMappings.Add("VinSn", "VinSn");
            tableMapping.ColumnMappings.Add("UnitState", "UnitState");
            tableMapping.ColumnMappings.Add("AssociatedChecklistRule", "AssociatedChecklistRule");
            tableMapping.ColumnMappings.Add("AssociatedChecklistRuleState", "AssociatedChecklistRuleState");
            tableMapping.ColumnMappings.Add("AssociatedChecklistLastService", "AssociatedChecklistLastService");
            tableMapping.ColumnMappings.Add("AssociatedChecklistNextDue", "AssociatedChecklistNextDue");
            tableMapping.ColumnMappings.Add("AssociatedChecklistDone", "AssociatedChecklistDone");
            tableMapping.ColumnMappings.Add("AssociatedChecklistDeleted", "AssociatedChecklistDeleted");
            tableMapping.ColumnMappings.Add("AssociatedChecklistCompanyId", "AssociatedChecklistCompanyId");
            tableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
            tableMapping.ColumnMappings.Add("Mileage", "Mileage");
            tableMapping.ColumnMappings.Add("StartWorkMileage", "StartWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkMileage", "CompleteWorkMileage");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("MileageUnitOfMeasurement", "MileageUnitOfMeasurement");
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
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// LoadInProgressByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInProgressByRuleId(int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADINPROGRESSBYRULEID", new SqlParameter("ruleId", ruleId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadInProgressByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInProgressByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADINPROGRESSBYUNITID", new SqlParameter("unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadInProgressByUnitIdRuleId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInProgressByUnitIdRuleId(int unitId, int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADINPROGRESSBYUNITIDRULEID", new SqlParameter("@unitId", unitId), new SqlParameter("ruleId", ruleId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInProgressByServiceIdUnitIdRuleId(int serviceId, int unitId, int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESGATEWAY_LOADINPROGRESSBYSERVICEIDUNITIDRULEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@unitId", unitId), new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServiceInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetServiceNumber
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ServiceNumber or EMPTY</returns>
        public string GetServiceNumber(int serviceId)
        {
            if (GetRow(serviceId).IsNull("ServiceNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["ServiceNumber"];
            }
        }



        /// <summary>
        /// GetServiceState
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ServiceState or EMPTY</returns>
        public string GetServiceState(int serviceId)
        {
            if (GetRow(serviceId).IsNull("ServiceState"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["ServiceState"];
            }
        }



        /// <summary>
        /// GetServiceState Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ServiceState or EMPTY</returns>
        public string GetServiceStateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["ServiceState"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["ServiceState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDateTime_ If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DateTime_</returns>
        public DateTime GetDateTime_(int serviceId)
        {
            return (DateTime)GetRow(serviceId)["DateTime_"];
        }


        
        /// <summary>
        /// GetMtoDto
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>MtoDto</returns>
        public bool GetMtoDto(int serviceId)
        {
            return (bool)GetRow(serviceId)["MtoDto"];
        }



        /// <summary>
        /// GetMtoDto Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original MtoDto</returns>
        public bool GetMtoDtoOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["MtoDto", DataRowVersion.Original];
        }



        /// <summary>
        /// GetServiceDescription
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ServiceDescription or EMPTY</returns>
        public string GetServiceDescription(int serviceId)
        {
            if (GetRow(serviceId).IsNull("ServiceDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["ServiceDescription"];
            }
        }



        /// <summary>
        /// GetServiceDescription Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ServiceDescription or EMPTY</returns>
        public string GetServiceDescriptionOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["ServiceDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["ServiceDescription", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int serviceId)
        {
            if (GetRow(serviceId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["Type"];
            }
        }



        /// <summary>
        /// GetOwnerID. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>OwnerID</returns>
        public int GetOwnerID(int serviceId)
        {
            return (int)GetRow(serviceId)["OwnerID"];
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
        /// GetToTeamMember 
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ToTeamMember</returns>
        public bool GetToTeamMember(int serviceId)
        {
            return (bool)GetRow(serviceId)["ToTeamMember"];
        }



        /// <summary>
        /// GetToTeamMember Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original ToTeamMember</returns>
        public bool GetToTeamMemberOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["ToTeamMember", DataRowVersion.Original];
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
            if (GetRow(serviceId).IsNull("AssignedThirdPartyVendor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssignedThirdPartyVendor"];
            }
        }



        /// <summary>
        /// GetAssignedThirdPartyVendor Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AssignedThirdPartyVendor or EMPTY</returns>
        public string GetAssignedThirdPartyVendorOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AssignedThirdPartyVendor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["AssignedThirdPartyVendor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAcceptedDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>AcceptedDateTime or null</returns>
        public DateTime? GetAcceptedDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("AcceptedDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AcceptedDateTime"];
            }
        }



        /// <summary>
        /// GetAcceptedDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original AcceptedDateTime or null</returns>
        public DateTime? GetAcceptedDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["AcceptedDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["AcceptedDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRejectedDateTime
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>RejectedDateTime or null</returns>
        public DateTime? GetRejectedDateTime(int serviceId)
        {
            if (GetRow(serviceId).IsNull("RejectedDateTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["RejectedDateTime"];
            }
        }



        /// <summary>
        /// GetRejectedDateTime Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original RejectedDateTime or null</returns>
        public DateTime? GetRejectedDateTimeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["RejectedDateTime"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(serviceId)["RejectedDateTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRejectedReason
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>RejectedReason or EMPTY</returns>
        public string GetRejectedReason(int serviceId)
        {
            if (GetRow(serviceId).IsNull("RejectedReason"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["RejectedReason"];
            }
        }



        /// <summary>
        /// GetRejectedReason Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original RejectedReason or EMPTY</returns>
        public string GetRejectedReasonOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["RejectedReason"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["RejectedReason", DataRowVersion.Original];
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
            if (GetRow(serviceId).IsNull("CompleteWorkDetailTPVInvoiceNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkDetailTPVInvoiceNumber"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceNumber Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTPVInvoiceNumber or EMPTY</returns>
        public string GetCompleteWorkDetailTPVInvoiceNumberOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDetailTPVInvoiceNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CompleteWorkDetailTPVInvoiceNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceAmout
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CompleteWorkDetailTPVInvoiceAmout or null</returns>
        public decimal? GetCompleteWorkDetailTPVInvoiceAmout(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CompleteWorkDetailTPVInvoiceAmout"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTPVInvoiceAmout"];
            }
        }



        /// <summary>
        /// GetCompleteWorkDetailTPVInvoiceAmout Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CompleteWorkDetailTPVInvoiceAmout or null</returns>
        public decimal? GetCompleteWorkDetailTPVInvoiceAmoutOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CompleteWorkDetailTPVInvoiceAmout"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(serviceId)["CompleteWorkDetailTPVInvoiceAmout", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotes
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Notes or EMPTY</returns>
        public string GetNotes(int serviceId)
        {
            if (GetRow(serviceId).IsNull("Notes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["Notes"];
            }
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
        /// GetRuleId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>RuleID or null</returns>
        public int? GetRuleId(int serviceId)
        {
            if (GetRow(serviceId).IsNull("RuleID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId)["RuleID"];
            }
        }



        /// <summary>
        /// GetRuleId Original
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
        /// GetUnitID. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitID or null</returns>
        public int? GetUnitID(int serviceId)
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
        public int? GetUnitIDOriginal(int serviceId)
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
        /// GetUnitCode. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitCode or EMPTY</returns>
        public string GetUnitCode(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitCode"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitCode"];
            }
        }



        /// <summary>
        /// GetUnitCode Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitCode or EMPTY</returns>
        public string GetUnitCodeOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitCode"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitCode", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUnitDescription
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitDescription or EMPTY</returns>
        public string GetUnitDescription(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitDescription"];
            }
        }



        /// <summary>
        /// GetUnitDescription Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitDescription or EMPTY</returns>
        public string GetUnitDescriptionOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitDescription", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVinSn
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>VIN/SN or EMPTY</returns>
        public string GetVinSn(int serviceId)
        {
            if (GetRow(serviceId).IsNull("VinSn"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["VinSn"];
            }
        }



        /// <summary>
        /// GetVinSn Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original VinSn or EMPTY</returns>
        public string GetVinSnOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["VinSn"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["VinSn", DataRowVersion.Original];
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
        /// GetUnitState
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnitState or EMPTY</returns>
        public string GetUnitState(int serviceId)
        {
            if (GetRow(serviceId).IsNull("UnitState"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitState"];
            }
        }



        /// <summary>
        /// GetUnitState Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original UnitState or EMPTY</returns>
        public string GetUnitStateOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["UnitState"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["UnitState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCreatedBy
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>CreatedBy or EMPTY</returns>
        public string GetCreatedBy(int serviceId)
        {
            if (GetRow(serviceId).IsNull("CreatedBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CreatedBy"];
            }
        }



        /// <summary>
        /// GetCreatedBy Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original CreatedBy or EMPTY</returns>
        public string GetCreatedByOriginal(int serviceId)
        {
            if (GetRow(serviceId).IsNull(Table.Columns["CreatedBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["CreatedBy", DataRowVersion.Original];
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
        /// <returns>CompleteWorkMileage or EMPTY</returns>
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
        /// GetDeleted
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>GetDeleted</returns>
        public bool GetDeleted(int serviceId)
        {
            return (bool)GetRow(serviceId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Original Deleted or EMPTY</returns>
        public bool GetDeletedOriginal(int serviceId)
        {
            return (bool)GetRow(serviceId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMileageUnitOfMeasurement
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>MileageUnitOfMeasurement or EMPTY</returns>
        public string GetMileageUnitOfMeasurement(int serviceId)
        {
            if (GetRow(serviceId).IsNull("MileageUnitOfMeasurement"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId)["MileageUnitOfMeasurement"];
            }
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