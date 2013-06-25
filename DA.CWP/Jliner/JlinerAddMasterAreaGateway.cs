using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerAddMasterAreaGateway
    /// </summary>
    public class JlinerAddMasterAreaGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerAddMasterAreaGateway()
            : base("MasterArea")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerAddMasterAreaGateway(DataSet data)
            : base(data, "MasterArea")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerAddTDS();
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
            tableMapping.DataSetTable = "LFS_MASTER_AREA";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("ScaledLength", "ScaledLength");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            tableMapping.ColumnMappings.Add("LiveLats", "LiveLats");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("FullLengthLining", "FullLengthLining");
            tableMapping.ColumnMappings.Add("SubcontractorLining", "SubcontractorLining");
            tableMapping.ColumnMappings.Add("OutOfScopeInArea", "OutOfScopeInArea");
            tableMapping.ColumnMappings.Add("IssueGivenToBayCity", "IssueGivenToBayCity");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("InstallRate", "InstallRate");
            tableMapping.ColumnMappings.Add("DeadlineDate", "DeadlineDate");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("SalesIssue", "SalesIssue");
            tableMapping.ColumnMappings.Add("LFSIssue", "LFSIssue");
            tableMapping.ColumnMappings.Add("ClientIssue", "ClientIssue");
            tableMapping.ColumnMappings.Add("InvestigationIssue", "InvestigationIssue");
            tableMapping.ColumnMappings.Add("PointLining", "PointLining");
            tableMapping.ColumnMappings.Add("Grouting", "Grouting");
            tableMapping.ColumnMappings.Add("LateralLining", "LateralLining");
            tableMapping.ColumnMappings.Add("VacExDate", "VacExDate");
            tableMapping.ColumnMappings.Add("PusherDate", "PusherDate");
            tableMapping.ColumnMappings.Add("LinerOrdered", "LinerOrdered");
            tableMapping.ColumnMappings.Add("Restoration", "Restoration");
            tableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            tableMapping.ColumnMappings.Add("JLiner", "JLiner");
            tableMapping.ColumnMappings.Add("RehabAssessment", "RehabAssessment");
            tableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            tableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("USMHMN", "USMHMN");
            tableMapping.ColumnMappings.Add("DSMHMN", "DSMHMN");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("MeasurementsTakenBy", "MeasurementsTakenBy");
            tableMapping.ColumnMappings.Add("SteelTapeThruPipe", "SteelTapeThruPipe");
            tableMapping.ColumnMappings.Add("USMHAtMouth1200", "USMHAtMouth1200");
            tableMapping.ColumnMappings.Add("USMHAtMouth100", "USMHAtMouth100");
            tableMapping.ColumnMappings.Add("USMHAtMouth200", "USMHAtMouth200");
            tableMapping.ColumnMappings.Add("USMHAtMouth300", "USMHAtMouth300");
            tableMapping.ColumnMappings.Add("USMHAtMouth400", "USMHAtMouth400");
            tableMapping.ColumnMappings.Add("USMHAtMouth500", "USMHAtMouth500");
            tableMapping.ColumnMappings.Add("DSMHAtMouth1200", "DSMHAtMouth1200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth100", "DSMHAtMouth100");
            tableMapping.ColumnMappings.Add("DSMHAtMouth200", "DSMHAtMouth200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth300", "DSMHAtMouth300");
            tableMapping.ColumnMappings.Add("DSMHAtMouth400", "DSMHAtMouth400");
            tableMapping.ColumnMappings.Add("DSMHAtMouth500", "DSMHAtMouth500");
            tableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            tableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            tableMapping.ColumnMappings.Add("RampsRequired", "RampsRequired");
            tableMapping.ColumnMappings.Add("DegreeOfTrafficControl", "DegreeOfTrafficControl");
            tableMapping.ColumnMappings.Add("StandarBypass", "StandarBypass");
            tableMapping.ColumnMappings.Add("HydroWireDetails", "HydroWireDetails");
            tableMapping.ColumnMappings.Add("PipeMaterialType", "PipeMaterialType");
            tableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            tableMapping.ColumnMappings.Add("RoboticPrepRequired", "RoboticPrepRequired");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("M1Comments", "M1Comments");
            tableMapping.ColumnMappings.Add("VideoDoneFrom", "VideoDoneFrom");
            tableMapping.ColumnMappings.Add("ToManhole", "ToManhole");
            tableMapping.ColumnMappings.Add("CutterDescriptionDuringMeasuring", "CutterDescriptionDuringMeasuring");
            tableMapping.ColumnMappings.Add("FullLengthPointLiner", "FullLengthPointLiner");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            tableMapping.ColumnMappings.Add("SchoolZone", "SchoolZone");
            tableMapping.ColumnMappings.Add("RestaurantArea", "RestaurantArea");
            tableMapping.ColumnMappings.Add("CarwashLaundromat", "CarwashLaundromat");
            tableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            tableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            tableMapping.ColumnMappings.Add("TwoInchPump", "TwoInchPump");
            tableMapping.ColumnMappings.Add("SixInchBypass", "SixInchBypass");
            tableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            tableMapping.ColumnMappings.Add("WinchExtension", "WinchExtension");
            tableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            tableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            tableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            tableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("MeasuredFromManhole", "MeasuredFromManhole");
            tableMapping.ColumnMappings.Add("MainLined", "MainLined");
            tableMapping.ColumnMappings.Add("BenchingIssue", "BenchingIssue");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
            tableMapping.ColumnMappings.Add("ScaledLength1", "ScaledLength1");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("City", "City");
            tableMapping.ColumnMappings.Add("ProvState", "ProvState");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            tableMapping.ColumnMappings.Add("Selected", "Selected"); 
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
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID - Client</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERADDMASTERAREAGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdRecordId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID - Client</param>
        /// <param name="recordId">RecordId - Id for users</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesIdRecordId(int companyId, int companiesId, string recordId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERADDMASTERAREAGATEWAY_LOADBYCOMPANIESIDRECORDID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@recordId", recordId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdRecordIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID - Client</param>
        /// <param name="recordId">RecordId - Id for users</param>
        /// <param name="street">Street</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesIdRecordIdStreet(int companyId, int companiesId, string recordId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERADDMASTERAREAGATEWAY_LOADBYCOMPANIESIDRECORDIDSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@recordId", recordId), new SqlParameter("@street", street));
            return Data;
        }



        /// <summary>
        ///  Get a single section. If not exists, raise an exception.
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(string recordId)
        {
            string filter = string.Format("RecordID = '{0}'", recordId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Jliner.JlinerAddMasterAreaGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(Guid id, int companyId)
        {
            string filter = string.Format("(ID = '{0}')  AND (COMPANY_ID = {1})", id, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.Jliner.JlinerAddMasterAreaGateway.GetRow");
            }
        }



        /// <summary>
        /// GetID
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>ID</returns>
        public Guid GetId(string recordId)
        {
            return (Guid)GetRow(recordId)["ID"];
        }



        /// <summary>
        /// GetStreet
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>Street or EMPTY</returns>
        public string GetStreet(string recordId)
        {
            if (GetRow(recordId).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(recordId)["Street"];
            }
        }




        /// <summary>
        /// GetUSMH
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>USMH or EMPTY</returns>
        public string GetUSMH(string recordId)
        {
            if (GetRow(recordId).IsNull("USMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(recordId)["USMH"];
            }
        }




        /// <summary>
        /// GetDSMH
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>DSMH or EMPTY</returns>
        public string GetDSMH(string recordId)
        {
            if (GetRow(recordId).IsNull("DSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(recordId)["DSMH"];
            }
        }



        /// <summary>
        /// GetActualLength
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>Actual Length or EMPTY</returns>
        public string GetActualLength(string recordId)
        {
            if (GetRow(recordId).IsNull("ActualLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(recordId)["ActualLength"];
            }
        }



        /// <summary>
        /// GetRecordID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RecordID o EMPTY</returns>
        public string GetRecordID(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("RecordID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["RecordID"];
            }
        }



        /// <summary>
        /// GetRecordID Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original RecordID or EMPTY</returns>
        public string GetRecordIDOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["RecordID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["RecordID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ClientID o EMPTY</returns>
        public string GetClientID(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ClientID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ClientID"];
            }
        }



        /// <summary>
        /// GetClientID Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ClientID or EMPTY</returns>
        public string GetClientIDOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ClientID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ClientID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSubArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SubArea o EMPTY</returns>
        public string GetSubArea(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("SubArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["SubArea"];
            }
        }



        /// <summary>
        /// GetSubArea Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SubArea or EMPTY</returns>
        public string GetSubAreaOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["SubArea"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["SubArea", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStreet. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Street o EMPTY</returns>
        public string GetStreet(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Street"];
            }
        }



        /// <summary>
        /// GetStreet Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Street or EMPTY</returns>
        public string GetStreetOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["Street"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Street", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMH o EMPTY</returns>
        public string GetUSMH(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMH"];
            }
        }



        /// <summary>
        /// GetUSMH Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMH or EMPTY</returns>
        public string GetUSMHOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMH o EMPTY</returns>
        public string GetDSMH(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMH"];
            }
        }



        /// <summary>
        /// GetDSMH Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMH or EMPTY</returns>
        public string GetDSMHOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize_. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Size_ o EMPTY</returns>
        public string GetSize_(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("Size_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Size_"];
            }
        }



        /// <summary>
        /// GetSize_ Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Size_ or EMPTY</returns>
        public string GetSize_Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["Size_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Size_", DataRowVersion.Original];
            }
        }

                

        /// <summary>
        /// GetScaledLength. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ScaledLength o EMPTY</returns>
        public string GetScaledLength(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ScaledLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ScaledLength"];
            }
        }



        /// <summary>
        /// GetScaledLength Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ScaledLength or EMPTY</returns>
        public string GetScaledLengthOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ScaledLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ScaledLength", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>P1Date o EMPTY</returns>
        public DateTime? GetP1Date(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("P1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["P1Date"];
            }
        }



        /// <summary>
        /// GetP1Date Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original P1Date or EMPTY</returns>
        public DateTime? GetP1DateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["P1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["P1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetActualLength. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ActualLength o EMPTY</returns>
        public string GetActualLength(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ActualLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ActualLength"];
            }
        }



        /// <summary>
        /// GetActualLength Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ActualLength or EMPTY</returns>
        public string GetActualLengthOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ActualLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ActualLength", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLiveLats. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>LiveLats o EMPTY</returns>
        public double? GetLiveLats(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("LiveLats"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["LiveLats"];
            }
        }



        /// <summary>
        /// GetLiveLats Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original LiveLats or EMPTY</returns>
        public double? GetLiveLatsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["LiveLats"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["LiveLats", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCXIsRemoved. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>CXIsRemoved o EMPTY</returns>
        public string GetCXIsRemoved(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("CXIsRemoved"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["CXIsRemoved"];
            }
        }



        /// <summary>
        /// GetCXIsRemoved Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original CXIsRemoved or EMPTY</returns>
        public string GetCXIsRemovedOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["CXIsRemoved"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["CXIsRemoved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetM1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>M1Date o EMPTY</returns>
        public DateTime? GetM1Date(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("M1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["M1Date"];
            }
        }



        /// <summary>
        /// GetM1Date Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original M1Date or EMPTY</returns>
        public DateTime? GetM1DateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["M1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["M1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetM2Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>M2Date o EMPTY</returns>
        public DateTime? GetM2Date(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("M2Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["M2Date"];
            }
        }



        /// <summary>
        /// GetM2Date Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original M2Date or EMPTY</returns>
        public DateTime? GetM2DateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["M2Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["M2Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>InstallDate o EMPTY</returns>
        public DateTime? GetInstallDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetInstallDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original InstallDate or EMPTY</returns>
        public DateTime? GetInstallDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["InstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["InstallDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideo. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>FinalVideo o EMPTY</returns>
        public DateTime? GetFinalVideo(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("FinalVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["FinalVideo"];
            }
        }



        /// <summary>
        /// GetFinalVideo Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original FinalVideo or EMPTY</returns>
        public DateTime? GetFinalVideoOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["FinalVideo"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["FinalVideo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Comments o EMPTY</returns>
        public string GetComments(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssueIdentified. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>IssueIdentified o EMPTY</returns>
        public bool GetIssueIdentified(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueIdentified"];
        }



        /// <summary>
        /// GetIssueIdentified Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original IssueIdentified or EMPTY</returns>
        public bool GetIssueIdentifiedOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueIdentified", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueResolved. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>       
        /// <param name="companyId">companyId</param>
        /// <returns>IssueResolved o EMPTY</returns>
        public bool GetIssueResolved(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueResolved"];
        }



        /// <summary>
        /// GetIssueResolved Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original IssueResolved or EMPTY</returns>
        public bool GetIssueResolvedOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueResolved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFullLengthLining. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>FullLengthLining o EMPTY</returns>
        public bool GetFullLengthLining(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FullLengthLining"];
        }



        /// <summary>
        /// GetFullLengthLining Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original FullLengthLining or EMPTY</returns>
        public bool GetFullLengthLiningOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FullLengthLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetSubcontractorLining. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SubcontractorLining o EMPTY</returns>
        public bool GetSubcontractorLining(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SubcontractorLining"];
        }



        /// <summary>
        /// GetSubcontractorLining Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SubcontractorLining or EMPTY</returns>
        public bool GetSubcontractorLiningOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SubcontractorLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetOutOfScopeInArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>OutOfScopeInArea o EMPTY</returns>
        public bool GetOutOfScopeInArea(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["OutOfScopeInArea"];
        }



        /// <summary>
        /// GetOutOfScopeInArea Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original OutOfScopeInArea or EMPTY</returns>
        public bool GetOutOfScopeInAreaOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["OutOfScopeInArea", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueGivenToBayCity. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>IssueGivenToBayCity o EMPTY</returns>
        public bool GetIssueGivenToBayCity(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueGivenToBayCity"];
        }



        /// <summary>
        /// GetIssueGivenToBayCity Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original IssueGivenToBayCity or EMPTY</returns>
        public bool GetIssueGivenToBayCityOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["IssueGivenToBayCity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetConfirmedSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ConfirmedSize o EMPTY</returns>
        public int? GetConfirmedSize(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ConfirmedSize"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["ConfirmedSize"];
            }
        }



        /// <summary>
        /// GetConfirmedSize Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ConfirmedSize or EMPTY</returns>
        public int? GetConfirmedSizeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ConfirmedSize"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["ConfirmedSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallRate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>InstallRate o EMPTY</returns>
        public decimal? GetInstallRate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("InstallRate"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, companyId)["InstallRate"];
            }
        }



        /// <summary>
        /// GetInstallRate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original InstallRate or EMPTY</returns>
        public decimal? GetInstallRateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["InstallRate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, companyId)["InstallRate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeadlineDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DeadlineDate o EMPTY</returns>
        public DateTime? GetDeadlineDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DeadlineDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["DeadlineDate"];
            }
        }



        /// <summary>
        /// GetDeadlineDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DeadlineDate or EMPTY</returns>
        public DateTime? GetDeadlineDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DeadlineDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["DeadlineDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProposedLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetProposedLiningDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ProposedLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["ProposedLiningDate"];
            }
        }



        /// <summary>
        /// GetProposedLiningDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ProposedLiningDate or EMPTY</returns>
        public DateTime? GetProposedLiningDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ProposedLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["ProposedLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSalesIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SalesIssue o EMPTY</returns>
        public bool GetSalesIssue(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SalesIssue"];
        }



        /// <summary>
        /// GetSalesIssue Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SalesIssue or EMPTY</returns>
        public bool GetSalesIssueOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SalesIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLFSIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>LFSIssue o EMPTY</returns>
        public bool GetLFSIssue(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["LFSIssue"];
        }



        /// <summary>
        /// GetLFSIssue Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original LFSIssue or EMPTY</returns>
        public bool GetLFSIssueOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["LFSIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetClientIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ClientIssue o EMPTY</returns>
        public bool GetClientIssue(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["ClientIssue"];
        }



        /// <summary>
        /// GetClientIssue Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ClientIssue or EMPTY</returns>
        public bool GetClientIssueOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["ClientIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInvestigationIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>InvestigationIssue o EMPTY</returns>
        public bool GetInvestigationIssue(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["InvestigationIssue"];
        }



        /// <summary>
        /// GetInvestigationIssue Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original InvestigationIssue or EMPTY</returns>
        public bool GetInvestigationIssueOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["InvestigationIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPointLining. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PointLining o EMPTY</returns>
        public bool GetPointLining(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["PointLining"];
        }



        /// <summary>
        /// GetPointLining Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PointLining or EMPTY</returns>
        public bool GetPointLiningOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["PointLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrouting. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Grouting o EMPTY</returns>
        public bool GetGrouting(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Grouting"];
        }



        /// <summary>
        /// GetGrouting Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Grouting or EMPTY</returns>
        public bool GetGroutingOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Grouting", DataRowVersion.Original];
        }        



        /// <summary>
        /// GetLateralLining. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>LateralLining o EMPTY</returns>
        public bool GetLateralLining(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["LateralLining"];
        }



        /// <summary>
        /// GetLateralLining Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original LateralLining or EMPTY</returns>
        public bool GetLateralLiningOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["LateralLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetVacExDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>VacExDate o EMPTY</returns>
        public DateTime? GetVacExDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("VacExDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["VacExDate"];
            }
        }



        /// <summary>
        /// GetVacExDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original VacExDate or EMPTY</returns>
        public DateTime? GetVacExDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["VacExDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["VacExDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPusherDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PusherDate o EMPTY</returns>
        public DateTime? GetPusherDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("PusherDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PusherDate"];
            }
        }



        /// <summary>
        /// GetPusherDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PusherDate or EMPTY</returns>
        public DateTime? GetPusherDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["PusherDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PusherDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerOrdered. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>LinerOrdered o EMPTY</returns>
        public DateTime? GetLinerOrdered(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("LinerOrdered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["LinerOrdered"];
            }
        }



        /// <summary>
        /// GetLinerOrdered Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerOrdered or EMPTY</returns>
        public DateTime? GetLinerOrderedOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["LinerOrdered"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["LinerOrdered", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRestoration. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Restoration o EMPTY</returns>
        public DateTime? GetRestoration(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("Restoration"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["Restoration"];
            }
        }



        /// <summary>
        /// GetRestoration Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Restoration or EMPTY</returns>
        public DateTime? GetRestorationOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["Restoration"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["Restoration", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGroutDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>GroutDate o EMPTY</returns>
        public DateTime? GetGroutDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("GroutDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["GroutDate"];
            }
        }



        /// <summary>
        /// GetGroutDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original GroutDate or EMPTY</returns>
        public DateTime? GetGroutDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["GroutDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["GroutDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetJLiner. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>JLiner o EMPTY</returns>
        public bool GetJLiner(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["JLiner"];
        }



        /// <summary>
        /// GetJLiner Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original JLiner or EMPTY</returns>
        public bool GetJLinerOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["JLiner", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRehabAssessment. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RehabAssessment o EMPTY</returns>
        public bool GetRehabAssessment(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RehabAssessment"];
        }



        /// <summary>
        /// GetRehabAssessment Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original RehabAssessment or EMPTY</returns>
        public bool GetRehabAssessmentOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RehabAssessment", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEstimatedJoints. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>EstimatedJoints o EMPTY</returns>
        public int? GetEstimatedJoints(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("EstimatedJoints"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["EstimatedJoints"];
            }
        }



        /// <summary>
        /// GetEstimatedJoints Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original EstimatedJoints or EMPTY</returns>
        public int? GetEstimatedJointsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["EstimatedJoints"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["EstimatedJoints", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetJointsTestSealed. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>JointsTestSealed o EMPTY</returns>
        public int? GetJointsTestSealed(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("JointsTestSealed"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["JointsTestSealed"];
            }
        }



        /// <summary>
        /// GetJointsTestSealed Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original JointsTestSealed or EMPTY</returns>
        public int? GetJointsTestSealedOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["JointsTestSealed"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["JointsTestSealed", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreFlushDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PreFlushDate o EMPTY</returns>
        public DateTime? GetPreFlushDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("PreFlushDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PreFlushDate"];
            }
        }



        /// <summary>
        /// GetPreFlushDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PreFlushDate or EMPTY</returns>
        public DateTime? GetPreFlushDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["PreFlushDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PreFlushDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreVideoDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PreVideoDate o EMPTY</returns>
        public DateTime? GetPreVideoDate(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("PreVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PreVideoDate"];
            }
        }



        /// <summary>
        /// GetPreVideoDate Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PreVideoDate or EMPTY</returns>
        public DateTime? GetPreVideoDateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["PreVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, companyId)["PreVideoDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHMN. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHMN o EMPTY</returns>
        public string GetUSMHMN(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHMN"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMHMN"];
            }
        }



        /// <summary>
        /// GetUSMHMN Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHMN or EMPTY</returns>
        public string GetUSMHMNOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHMN"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMHMN", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHMN. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHMN o EMPTY</returns>
        public string GetDSMHMN(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHMN"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMHMN"];
            }
        }



        /// <summary>
        /// GetDSMHMN Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHMN or EMPTY</returns>
        public string GetDSMHMNOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHMN"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMHMN", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHDepth o EMPTY</returns>
        public string GetUSMHDepth(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMHDepth"];
            }
        }



        /// <summary>
        /// GetUSMHDepth Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHDepth or EMPTY</returns>
        public string GetUSMHDepthOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["USMHDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHDepth o EMPTY</returns>
        public string GetDSMHDepth(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMHDepth"];
            }
        }



        /// <summary>
        /// GetDSMHDepth Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHDepth or EMPTY</returns>
        public string GetDSMHDepthOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DSMHDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementsTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>MeasurementsTakenBy o EMPTY</returns>
        public string GetMeasurementsTakenBy(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("MeasurementsTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasurementsTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementsTakenBy Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original MeasurementsTakenBy or EMPTY</returns>
        public string GetMeasurementsTakenByOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["MeasurementsTakenBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasurementsTakenBy", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSteelTapeThruPipe. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SteelTapeThruPipe o EMPTY</returns>
        public string GetSteelTapeThruPipe(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("SteelTapeThruPipe"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["SteelTapeThruPipe"];
            }
        }



        /// <summary>
        /// GetSteelTapeThruPipe Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SteelTapeThruPipe or EMPTY</returns>
        public string GetSteelTapeThruPipeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["SteelTapeThruPipe"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["SteelTapeThruPipe", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth1200. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth1200 o EMPTY</returns>
        public double? GetUSMHAtMouth1200(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth1200"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth1200"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth1200 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth1200 or EMPTY</returns>
        public double? GetUSMHAtMouth1200Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth1200"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth1200", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth100. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth100 o EMPTY</returns>
        public double? GetUSMHAtMouth100(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth100"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth100"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth100 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth100 or EMPTY</returns>
        public double? GetUSMHAtMouth100Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth100"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth100", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth200. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth200 o EMPTY</returns>
        public double? GetUSMHAtMouth200(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth200"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth200"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth200 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth200 or EMPTY</returns>
        public double? GetUSMHAtMouth200Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth200"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth200", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth300. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth300 o EMPTY</returns>
        public double? GetUSMHAtMouth300(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth300"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth300"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth300 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth300 or EMPTY</returns>
        public double? GetUSMHAtMouth300Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth300"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth300", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth400. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth400 o EMPTY</returns>
        public double? GetUSMHAtMouth400(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth400"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth400"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth400 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth400 or EMPTY</returns>
        public double? GetUSMHAtMouth400Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth400"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth400", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth500. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>USMHAtMouth500 o EMPTY</returns>
        public double? GetUSMHAtMouth500(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("USMHAtMouth500"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth500"];
            }
        }



        /// <summary>
        /// GetUSMHAtMouth500 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original USMHAtMouth500 or EMPTY</returns>
        public double? GetUSMHAtMouth500Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["USMHAtMouth500"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["USMHAtMouth500", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth1200. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth1200 o EMPTY</returns>
        public double? GetDSMHAtMouth1200(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth1200"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth1200"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth1200 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth1200 or EMPTY</returns>
        public double? GetDSMHAtMouth1200Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth1200"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth1200", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth100. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth100 o EMPTY</returns>
        public double? GetDSMHAtMouth100(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth100"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth100"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth100 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth100 or EMPTY</returns>
        public double? GetDSMHAtMouth100Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth100"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth100", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth200. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth200 o EMPTY</returns>
        public double? GetDSMHAtMouth200(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth200"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth200"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth200 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth200 or EMPTY</returns>
        public double? GetDSMHAtMouth200Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth200"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth200", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth300. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth300 o EMPTY</returns>
        public double? GetDSMHAtMouth300(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth300"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth300"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth300 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth300 or EMPTY</returns>
        public double? GetDSMHAtMouth300Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth300"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth300", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth400. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth400 o EMPTY</returns>
        public double? GetDSMHAtMouth400(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth400"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth400"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth400 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth400 or EMPTY</returns>
        public double? GetDSMHAtMouth400Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth400"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth400", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth500. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DSMHAtMouth500 o EMPTY</returns>
        public double? GetDSMHAtMouth500(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DSMHAtMouth500"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth500"];
            }
        }



        /// <summary>
        /// GetDSMHAtMouth500 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DSMHAtMouth500 or EMPTY</returns>
        public double? GetDSMHAtMouth500Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DSMHAtMouth500"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["DSMHAtMouth500", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHydrantAddress. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>HydrantAddress o EMPTY</returns>
        public string GetHydrantAddress(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("HydrantAddress"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["HydrantAddress"];
            }
        }



        /// <summary>
        /// GetHydrantAddress Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original HydrantAddress or EMPTY</returns>
        public string GetHydrantAddressOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["HydrantAddress"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["HydrantAddress", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceToInversionMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DistanceToInversionMH o EMPTY</returns>
        public string GetDistanceToInversionMH(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DistanceToInversionMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DistanceToInversionMH"];
            }
        }



        /// <summary>
        /// GetDistanceToInversionMH Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DistanceToInversionMH or EMPTY</returns>
        public string GetDistanceToInversionMHOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DistanceToInversionMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DistanceToInversionMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRampsRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RampsRequired o EMPTY</returns>
        public bool GetRampsRequired(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RampsRequired"];
        }



        /// <summary>
        /// GetRampsRequired Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original RampsRequired or EMPTY</returns>
        public bool GetRampsRequiredOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RampsRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDegreeOfTrafficControl. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DegreeOfTrafficControl o EMPTY</returns>
        public string GetDegreeOfTrafficControl(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DegreeOfTrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DegreeOfTrafficControl"];
            }
        }



        /// <summary>
        /// GetDegreeOfTrafficControl Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DegreeOfTrafficControl or EMPTY</returns>
        public string GetDegreeOfTrafficControlOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DegreeOfTrafficControl"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DegreeOfTrafficControl", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStandarBypass. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>StandarBypass o EMPTY</returns>
        public bool GetStandarBypass(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["StandarBypass"];
        }



        /// <summary>
        /// GetStandarBypass Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original StandarBypass or EMPTY</returns>
        public bool GetStandarBypassOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["StandarBypass", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHydroWireDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>HydroWireDetails o EMPTY</returns>
        public string GetHydroWireDetails(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("HydroWireDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["HydroWireDetails"];
            }
        }



        /// <summary>
        /// GetHydroWireDetails Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original HydroWireDetails or EMPTY</returns>
        public string GetHydroWireDetailsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["HydroWireDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["HydroWireDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeMaterialType. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PipeMaterialType o EMPTY</returns>
        public string GetPipeMaterialType(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("PipeMaterialType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["PipeMaterialType"];
            }
        }



        /// <summary>
        /// GetPipeMaterialType Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PipeMaterialType or EMPTY</returns>
        public string GetPipeMaterialTypeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["PipeMaterialType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["PipeMaterialType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCappedLaterals. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>CappedLaterals o EMPTY</returns>
        public int? GetCappedLaterals(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("CappedLaterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["CappedLaterals"];
            }
        }



        /// <summary>
        /// GetCappedLaterals Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original CappedLaterals or EMPTY</returns>
        public int? GetCappedLateralsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["CappedLaterals"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["CappedLaterals", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRoboticPrepRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RoboticPrepRequired o EMPTY</returns>
        public bool GetRoboticPrepRequired(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RoboticPrepRequired"];
        }



        /// <summary>
        /// GetRoboticPrepRequired Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original RoboticPrepRequired or EMPTY</returns>
        public bool GetRoboticPrepRequiredOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RoboticPrepRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPipeSizeChange. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>PipeSizeChange o EMPTY</returns>
        public bool GetPipeSizeChange(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["PipeSizeChange"];
        }



        /// <summary>
        /// GetPipeSizeChange Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original PipeSizeChange or EMPTY</returns>
        public bool GetPipeSizeChangeOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["PipeSizeChange", DataRowVersion.Original];
        }



        /// <summary>
        /// GetM1Comments. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>M1Comments o EMPTY</returns>
        public string GetM1Comments(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("M1Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["M1Comments"];
            }
        }



        /// <summary>
        /// GetM1Comments Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original M1Comments or EMPTY</returns>
        public string GetM1CommentsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["M1Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["M1Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDoneFrom. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>VideoDoneFrom o EMPTY</returns>
        public string GetVideoDoneFrom(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("VideoDoneFrom"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["VideoDoneFrom"];
            }
        }



        /// <summary>
        /// GetVideoDoneFrom Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original VideoDoneFrom or EMPTY</returns>
        public string GetVideoDoneFromOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["VideoDoneFrom"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["VideoDoneFrom", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetToManhole. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ToManhole o EMPTY</returns>
        public string GetToManhole(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ToManhole"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ToManhole"];
            }
        }



        /// <summary>
        /// GetToManhole Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ToManhole or EMPTY</returns>
        public string GetToManholeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ToManhole"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ToManhole", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCutterDescriptionDuringMeasuring. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>CutterDescriptionDuringMeasuring o EMPTY</returns>
        public string GetCutterDescriptionDuringMeasuring(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("CutterDescriptionDuringMeasuring"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["CutterDescriptionDuringMeasuring"];
            }
        }



        /// <summary>
        /// GetCutterDescriptionDuringMeasuring Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original CutterDescriptionDuringMeasuring or EMPTY</returns>
        public string GetCutterDescriptionDuringMeasuringOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["CutterDescriptionDuringMeasuring"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["CutterDescriptionDuringMeasuring", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFullLengthPointLiner. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>FullLengthPointLiner o EMPTY</returns>
        public bool GetFullLengthPointLiner(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FullLengthPointLiner"];
        }



        /// <summary>
        /// GetFullLengthPointLiner Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original FullLengthPointLiner or EMPTY</returns>
        public bool GetFullLengthPointLinerOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FullLengthPointLiner", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBypassRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>BypassRequired o EMPTY</returns>
        public bool GetBypassRequired(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["BypassRequired"];
        }



        /// <summary>
        /// GetBypassRequired Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original BypassRequired or EMPTY</returns>
        public bool GetBypassRequiredOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["BypassRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRoboticDistances. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RoboticDistances o EMPTY</returns>
        public string GetRoboticDistances(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("RoboticDistances"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["RoboticDistances"];
            }
        }



        /// <summary>
        /// GetRoboticDistances Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original RoboticDistances or EMPTY</returns>
        public string GetRoboticDistancesOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["RoboticDistances"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["RoboticDistances", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>TrafficControlDetails o EMPTY</returns>
        public string GetTrafficControlDetails(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("TrafficControlDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["TrafficControlDetails"];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original TrafficControlDetails or EMPTY</returns>
        public string GetTrafficControlDetailsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["TrafficControlDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["TrafficControlDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLineWithID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>LineWithID o EMPTY</returns>
        public string GetLineWithID(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("LineWithID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["LineWithID"];
            }
        }



        /// <summary>
        /// GetLineWithID Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original LineWithID or EMPTY</returns>
        public string GetLineWithIDOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["LineWithID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["LineWithID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSchoolZone. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SchoolZone o EMPTY</returns>
        public bool GetSchoolZone(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SchoolZone"];
        }



        /// <summary>
        /// GetSchoolZone Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SchoolZone or EMPTY</returns>
        public bool GetSchoolZoneOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SchoolZone", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRestaurantArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>RestaurantArea o EMPTY</returns>
        public bool GetRestaurantArea(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RestaurantArea"];
        }



        /// <summary>
        /// GetRestaurantArea Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original RestaurantArea or EMPTY</returns>
        public bool GetRestaurantAreaOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["RestaurantArea", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCarwashLaundromat. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>CarwashLaundromat o EMPTY</returns>
        public bool GetCarwashLaundromat(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["CarwashLaundromat"];
        }



        /// <summary>
        /// GetCarwashLaundromat Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original CarwashLaundromat or EMPTY</returns>
        public bool GetCarwashLaundromatOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["CarwashLaundromat", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHydroPulley. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>HydroPulley o EMPTY</returns>
        public bool GetHydroPulley(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["HydroPulley"];
        }



        /// <summary>
        /// GetHydroPulley Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original HydroPulley or EMPTY</returns>
        public bool GetHydroPulleyOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["HydroPulley", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFridgeCart. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>FridgeCart o EMPTY</returns>
        public bool GetFridgeCart(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FridgeCart"];
        }



        /// <summary>
        /// GetFridgeCart Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original FridgeCart or EMPTY</returns>
        public bool GetFridgeCartOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["FridgeCart", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTwoInchPump. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>TwoInchPump o EMPTY</returns>
        public bool GetTwoInchPump(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["TwoInchPump"];
        }



        /// <summary>
        /// GetTwoInchPump Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original TwoInchPump or EMPTY</returns>
        public bool GetTwoInchPumpOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["TwoInchPump", DataRowVersion.Original];
        }



        /// <summary>
        /// GetSixInchBypass. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>SixInchBypass o EMPTY</returns>
        public bool GetSixInchBypass(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SixInchBypass"];
        }



        /// <summary>
        /// GetSixInchBypass Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original SixInchBypass or EMPTY</returns>
        public bool GetSixInchBypassOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["SixInchBypass", DataRowVersion.Original];
        }



        /// <summary>
        /// GetScaffolding. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Scaffolding o EMPTY</returns>
        public bool GetScaffolding(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Scaffolding"];
        }



        /// <summary>
        /// GetScaffolding Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Scaffolding or EMPTY</returns>
        public bool GetScaffoldingOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Scaffolding", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWinchExtension. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>WinchExtension o EMPTY</returns>
        public bool GetWinchExtension(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["WinchExtension"];
        }



        /// <summary>
        /// GetWinchExtension Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original WinchExtension or EMPTY</returns>
        public bool GetWinchExtensionOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["WinchExtension", DataRowVersion.Original];
        }



        /// <summary>
        /// GetExtraGenerator. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ExtraGenerator o EMPTY</returns>
        public bool GetExtraGenerator(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["ExtraGenerator"];
        }



        /// <summary>
        /// GetExtraGenerator Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ExtraGenerator or EMPTY</returns>
        public bool GetExtraGeneratorOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["ExtraGenerator", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGreyCableExtension. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>GreyCableExtension o EMPTY</returns>
        public bool GetGreyCableExtension(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["GreyCableExtension"];
        }



        /// <summary>
        /// GetGreyCableExtension Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original GreyCableExtension or EMPTY</returns>
        public bool GetGreyCableExtensionOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["GreyCableExtension", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEasementMats. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>EasementMats o EMPTY</returns>
        public bool GetEasementMats(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["EasementMats"];
        }



        /// <summary>
        /// GetEasementMats Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original EasementMats or EMPTY</returns>
        public bool GetEasementMatsOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["EasementMats", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMeasurementType. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>MeasurementType o EMPTY</returns>
        public string GetMeasurementType(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("MeasurementType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasurementType"];
            }
        }



        /// <summary>
        /// GetMeasurementType Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original MeasurementType or EMPTY</returns>
        public string GetMeasurementTypeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["MeasurementType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasurementType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDropPipe. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DropPipe o EMPTY</returns>
        public bool GetDropPipe(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["DropPipe"];
        }



        /// <summary>
        /// GetDropPipe Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DropPipe or EMPTY</returns>
        public bool GetDropPipeOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["DropPipe", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDropPipeInvertDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>DropPipeInvertDepth o EMPTY</returns>
        public string GetDropPipeInvertDepth(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("DropPipeInvertDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DropPipeInvertDepth"];
            }
        }



        /// <summary>
        /// GetDropPipeInvertDepth Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original DropPipeInvertDepth or EMPTY</returns>
        public string GetDropPipeInvertDepthOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["DropPipeInvertDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["DropPipeInvertDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasuredFromManhole. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>MeasuredFromManhole o EMPTY</returns>
        public string GetMeasuredFromManhole(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("MeasuredFromManhole"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasuredFromManhole"];
            }
        }



        /// <summary>
        /// GetMeasuredFromManhole Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original MeasuredFromManhole or EMPTY</returns>
        public string GetMeasuredFromManholeOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["MeasuredFromManhole"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MeasuredFromManhole", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMainLined. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>MainLined o EMPTY</returns>
        public string GetMainLined(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("MainLined"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MainLined"];
            }
        }



        /// <summary>
        /// GetMainLined Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original MainLined or EMPTY</returns>
        public string GetMainLinedOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["MainLined"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["MainLined", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBenchingIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>BenchingIssue o EMPTY</returns>
        public string GetBenchingIssue(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("BenchingIssue"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["BenchingIssue"];
            }
        }



        /// <summary>
        /// GetBenchingIssue Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original BenchingIssue or EMPTY</returns>
        public string GetBenchingIssueOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["BenchingIssue"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["BenchingIssue", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetArchived. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Archived o EMPTY</returns>
        public bool GetArchived(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Archived"];
        }



        /// <summary>
        /// GetArchived Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original Archived or EMPTY</returns>
        public bool GetArchivedOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["Archived", DataRowVersion.Original];
        }



        /// <summary>
        /// GetScaledLength1. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ScaledLength1 o EMPTY</returns>
        public double? GetScaledLength1(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ScaledLength1"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["ScaledLength1"];
            }
        }



        /// <summary>
        /// GetScaledLength1 Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ScaledLength1 or EMPTY</returns>
        public double? GetScaledLength1Original(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ScaledLength1"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, companyId)["ScaledLength1", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHistory. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>History o EMPTY</returns>
        public string GetHistory(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("History"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["History"];
            }
        }



        /// <summary>
        /// GetHistory Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original History or EMPTY</returns>
        public string GetHistoryOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["History"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["History", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNumLats. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>NumLats o EMPTY</returns>
        public int? GetNumLats(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("NumLats"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NumLats"];
            }
        }



        /// <summary>
        /// GetNumLats Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original NumLats or EMPTY</returns>
        public int? GetNumLatsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["NumLats"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NumLats", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotLinedYet. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>NotLinedYet o EMPTY</returns>
        public int? GetNotLinedYet(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("NotLinedYet"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotLinedYet"];
            }
        }



        /// <summary>
        /// GetNotLinedYet Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original NotLinedYet or EMPTY</returns>
        public int? GetNotLinedYetOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["NotLinedYet"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotLinedYet", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAllMeasured. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>AllMeasured o EMPTY</returns>
        public bool GetAllMeasured(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["AllMeasured"];
        }



        /// <summary>
        /// GetAllMeasured Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original AllMeasured or EMPTY</returns>
        public bool GetAllMeasuredOriginal(Guid id, int companyId)
        {
            return (bool)GetRow(id, companyId)["AllMeasured", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCity. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>City o EMPTY</returns>
        public string GetCity(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("City"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["City"];
            }
        }



        /// <summary>
        /// GetCity Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original City or EMPTY</returns>
        public string GetCityOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["City"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["City", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProvState. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>ProvState o EMPTY</returns>
        public string GetProvState(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("ProvState"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ProvState"];
            }
        }



        /// <summary>
        /// GetProvState Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original ProvState or EMPTY</returns>
        public string GetProvStateOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["ProvState"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["ProvState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssueWithLaterals. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>IssueWithLaterals o EMPTY</returns>
        public string GetIssueWithLaterals(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("IssueWithLaterals"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["IssueWithLaterals"];
            }
        }



        /// <summary>
        /// GetIssueWithLaterals Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original IssueWithLaterals or EMPTY</returns>
        public string GetIssueWithLateralsOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["IssueWithLaterals"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, companyId)["IssueWithLaterals", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotMeasuredYet. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>NotMeasuredYet o EMPTY</returns>
        public int? GetNotMeasuredYet(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("NotMeasuredYet"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotMeasuredYet"];
            }
        }



        /// <summary>
        /// GetNotMeasuredYetOriginal
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original NotMeasuredYet or EMPTY</returns>
        public int? GetNotMeasuredYetOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["NotMeasuredYet"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotMeasuredYet", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotDeliveredYet. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>NotDeliveredYet o EMPTY</returns>
        public int? GetNotDeliveredYet(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("NotDeliveredYet"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotDeliveredYet"];
            }
        }



        /// <summary>
        /// GetNotDeliveredYetOriginal
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original NotDeliveredYet or EMPTY</returns>
        public int? GetNotDeliveredYetOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["NotDeliveredYet"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["NotDeliveredYet", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCOMPANIES_ID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>COMPANIES_ID o EMPTY</returns>
        public int? GetCOMPANIES_ID(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull("COMPANIES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["COMPANIES_ID"];
            }
        }



        /// <summary>
        /// GetCOMPANIES_ID Original
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Original COMPANIES_ID or EMPTY</returns>
        public int? GetCOMPANIES_IDOriginal(Guid id, int companyId)
        {
            if (GetRow(id, companyId).IsNull(Table.Columns["COMPANIES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, companyId)["COMPANIES_ID", DataRowVersion.Original];
            }
        }
    }
}
