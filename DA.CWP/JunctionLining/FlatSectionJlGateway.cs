using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJlGateway
    /// </summary>
    public class FlatSectionJlGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlGateway()
            : base("FlatSectionJl")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlGateway(DataSet data)
            : base(data, "FlatSectionJl")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlTDS();
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
            tableMapping.DataSetTable = "FlatSectionJl";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Section_", "Section_");
            tableMapping.ColumnMappings.Add("LateralDescription", "LateralDescription");
            tableMapping.ColumnMappings.Add("LateralWorkID", "LateralWorkID");
            tableMapping.ColumnMappings.Add("SectionWorkID", "SectionWorkID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
            tableMapping.ColumnMappings.Add("HamiltonInspectionNumber", "HamiltonInspectionNumber");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
            tableMapping.ColumnMappings.Add("Gasket", "Gasket");
            tableMapping.ColumnMappings.Add("MainSize", "MainSize");
            tableMapping.ColumnMappings.Add("ConnectionType", "ConnectionType");
            tableMapping.ColumnMappings.Add("DepthOfLocated", "DepthOfLocated");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLining", "DigRequiredPriorToLining");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLiningCompleted", "DigRequiredPriorToLiningCompleted");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLining", "DigRequiredAfterLining");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLiningCompleted", "DigRequiredAfterLiningCompleted");
            tableMapping.ColumnMappings.Add("OutOfScope", "OutOfScope");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldClientIssueResolved", "HoldClientIssueResolved");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssueResolved", "HoldLFSIssueResolved");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrep", "LateralRequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrepCompleted", "LateralRequiresRoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("LinerType", "LinerType");
            tableMapping.ColumnMappings.Add("PrepType", "PrepType");
            tableMapping.ColumnMappings.Add("DyeTestReq", "DyeTestReq");
            tableMapping.ColumnMappings.Add("DyeTestComplete", "DyeTestComplete");
            tableMapping.ColumnMappings.Add("ContractYear", "ContractYear");
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

        ///<summary>
        ///LoadByAssetIdArrayList
        ///</summary>
        ///<param name="projectId">projectId</param>
        ///<param name="assetId">assetID</param>    
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="companyId">companyId</param>
        ///<param name="selected">1 = Selected by default, 0 = Not selected by default</param>
        ///<returns>Data</returns>
        public DataSet LoadByAssetIdArrayList(int projectId, int assetId, int sectionWorkId, int companyId, int selected)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLGATEWAY_LOADBYASSETIDARRAYLIST", new SqlParameter("@projectId", projectId), new SqlParameter("@assetId", assetId), new SqlParameter("@sectionWorkId", sectionWorkId), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected));
            return Data;
        }



        ///<summary>
        ///LoadAllByWorkId
        ///</summary>
        ///<param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        ///<returns>Data</returns>
        public DataSet LoadAllByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLGATEWAY_LOADALLBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get one row, if not exists throw an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>row</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.JunctionLining.FlatSectionJlGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLateralId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralId</returns>
        public string GetLateralId(int workId)
        {
            return (string)GetRow(workId)["LateralID"];
        }



        /// <summary>
        /// GetSectionID
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SectionID</returns>
        public string GetSectionId(int workId)
        {
            return (string)GetRow(workId)["SectionID"];
        }



        /// <summary>
        /// GetSection_
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Section_</returns>
        public int GetSection_(int workId)
        {
            return (int)GetRow(workId)["Section_"];
        }



        /// <summary>
        /// GetLateralDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralDescription</returns>
        public string GetLateralDescription(int workId)
        {
            if (GetRow(workId).IsNull("LateralDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LateralDescription"];
            }
        }



        /// <summary>
        /// GetLateralWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralWorkID</returns>
        public int GetLateralWorkId(int workId)
        {
            return (int)GetRow(workId)["LateralWorkID"];
        }


        
        /// <summary>
        /// GetSectionWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SectionWorkId</returns>
        public string GetSectionWorkId(int workId)
        {
            return (string)GetRow(workId)["SectionWorkID"];
        }



        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>COMPANY_ID</returns>
        public int GetCompanyId(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetStreet
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Street</returns>
        public string GetStreet(int workId)
        {
            if (GetRow(workId).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Street"];
            }
        }



        /// <summary>
        /// GetAddress
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Address</returns>
        public string GetAddress(int workId)
        {
            if (GetRow(workId).IsNull("Address"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Address"];
            }
        }



        /// <summary>
        /// GetAddressOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Address</returns>
        public string GetAddressOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Address"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Address", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeLocated
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeLocated</returns>
        public DateTime? GetPipeLocated(int workId)
        {
            if (GetRow(workId).IsNull("PipeLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PipeLocated"];
            }
        }



        /// <summary>
        /// GetPipeLocatedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeLocated</returns>
        public DateTime? GetPipeLocatedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PipeLocated"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PipeLocated", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetServicesLocated
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ServicesLocated</returns>
        public DateTime? GetServicesLocated(int workId)
        {
            if (GetRow(workId).IsNull("ServicesLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ServicesLocated"];
            }
        }



        /// <summary>
        /// GetServicesLocatedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ServicesLocated Original</returns>
        public DateTime? GetServicesLocatedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ServicesLocated"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ServicesLocated", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCoRequired
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoRequired</returns>
        public bool GetCoRequired(int workId)
        {
            return (bool)GetRow(workId)["CoRequired"];
        }



        /// <summary>
        /// GetCoRequiredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoRequired original</returns>
        public bool GetCoRequiredOriginal(int workId)
        {
            return (bool)GetRow(workId)["CoRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPitRequired
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeRequired</returns>
        public bool GetPitRequired(int workId)
        {
            return (bool)GetRow(workId)["PitRequired"];
        }



        /// <summary>
        /// GetPitRequiredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PitRequired original</returns>
        public bool GetPitRequiredOriginal(int workId)
        {
            return (bool)GetRow(workId)["PitRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoPïtLocation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoPitLocation</returns>
        public string GetCoPitLocation(int workId)
        {
            if (GetRow(workId).IsNull("CoPitLocation"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CoPitLocation"];
            }
        }



        /// <summary>
        /// GetCoPitLocationOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoPitLocation original</returns>
        public string GetCoPitLocationOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CoPitLocation"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (string)GetRow(workId)["CoPitLocation", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCoInstalled
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>coInstalled</returns>
        public DateTime? GetCoInstalled(int workId)
        {
            if (GetRow(workId).IsNull("CoInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoInstalled"];
            }
        }



        /// <summary>
        /// GetCoInstalledOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoInstalled original</returns>
        public DateTime? GetCoInstalledOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CoInstalled"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoInstalled", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBackfilledConcrete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BackfilledConcrete</returns>
        public DateTime? GetBackfilledConcrete(int workId)
        {
            if (GetRow(workId).IsNull("BackfilledConcrete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledConcrete"];
            }
        }



        /// <summary>
        /// GetBackfilledConcreteOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BackfilledContrete original</returns>
        public DateTime? GetBackfilledConcreteOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["BackfilledConcrete"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledConcrete", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBackfilledSoil
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BackfilledSoil</returns>
        public DateTime? GetBackfilledSoil(int workId)
        {
            if (GetRow(workId).IsNull("BackfilledSoil"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledSoil"];
            }
        }



        /// <summary>
        /// GetBackfilledSoilOriginal
        /// </summary>
        /// <param name="workId">workid</param>
        /// <returns>BackfilledSoil original</returns>
        public DateTime? GetBackfilledSoilOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["BackfilledSoil"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledSoil", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGrouted
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Grouted</returns>
        public DateTime? GetGrouted(int workId)
        {
            if (GetRow(workId).IsNull("Grouted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Grouted"];
            }
        }



        /// <summary>
        /// GetGroutedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Grouted original</returns>
        public DateTime? GetGroutedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Grouted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Grouted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCored
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Cored</returns>
        public DateTime? GetCored(int workId)
        {
            if (GetRow(workId).IsNull("Cored"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Cored"];
            }
        }



        /// <summary>
        /// GetCoredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>cored original</returns>
        public DateTime? GetCoredOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Cored"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Cored", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPrepped
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Prepped</returns>
        public DateTime? GetPrepped(int workId)
        {
            if (GetRow(workId).IsNull("Prepped"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Prepped"];
            }
        }



        /// <summary>
        /// GetPreppedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Prepped original</returns>
        public DateTime? GetPreppedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Prepped"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Prepped", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasured
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Measured</returns>
        public DateTime? GetMeasured(int workId)
        {
            if (GetRow(workId).IsNull("Measured"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Measured"];
            }
        }



        /// <summary>
        /// GetMeasuredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Measured original</returns>
        public DateTime? GetMeasuredOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Measured"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Measured", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerSize
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerSize</returns>
        public string GetLinerSize(int workId)
        {
            if (GetRow(workId).IsNull("LinerSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerSize"];
            }
        }



        /// <summary>
        /// GetLinerSizeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerSize original</returns>
        public string GetLinerSizeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LinerSize"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (string)GetRow(workId)["LinerSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInProcess
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InProcess</returns>
        public DateTime? GetInProcess(int workId)
        {
            if (GetRow(workId).IsNull("InProcess"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InProcess"];
            }
        }



        /// <summary>
        /// GetInProcessOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InProcess original</returns>
        public DateTime? GetInProcessOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InProcess"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InProcess", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInStock
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InStock</returns>
        public DateTime? GetInStock(int workId)
        {
            if (GetRow(workId).IsNull("InStock"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InStock"];
            }
        }



        /// <summary>
        /// GetInStockOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InStock original</returns>
        public DateTime? GetInStockOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InStock"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InStock", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDelivered
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Delivered</returns>
        public DateTime? GetDelivered(int workId)
        {
            if (GetRow(workId).IsNull("Delivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Delivered"];
            }
        }



        /// <summary>
        /// GetDeliveredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Delivered original</returns>
        public DateTime? GetDeliveredOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Delivered"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Delivered", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerInstalled
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerInstalled</returns>
        public DateTime? GetLinerInstalled(int workId)
        {
            if (GetRow(workId).IsNull("LinerInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LinerInstalled"];
            }
        }



        /// <summary>
        /// GetLinerInstalledOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Liner Installed original</returns>
        public DateTime? GetLinerInstalledOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LinerInstalled"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LinerInstalled", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideo
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>finalVideo</returns>
        public DateTime? GetFinalVideo(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideo"];
            }
        }



        /// <summary>
        /// GetFinalVideoOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>final video original</returns>
        public DateTime? GetFinalVideoOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["FinalVideo"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DistanceFromUSMH</returns>
        public string GetDistanceFromUSMH(int workId)
        {
            if (GetRow(workId).IsNull("DistanceFromUSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DistanceFromUSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMHOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DistanceFromUsmh original</returns>
        public string GetDistanceFromUSMHOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DistanceFromUSMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (string)GetRow(workId)["DistanceFromUSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DistanceFromDsmh</returns>
        public string GetDistanceFromDSMH(int workId)
        {
            if (GetRow(workId).IsNull("DistanceFromDSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DistanceFromDSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMHOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DistanceFromDSMH orignal</returns>
        public string GetDistanceFromDSMHOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DistanceFromDSMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (string)GetRow(workId)["DistanceFromDSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCost
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Cost</returns>
        public decimal? GetCost(int workId)
        {
            if (GetRow(workId).IsNull("Cost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId)["Cost"];
            }
        }



        /// <summary>
        /// GetCostOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Cost original</returns>
        public decimal? GetCostOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Cost"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId)["Cost", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoInspection
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoInspection</returns>
        public DateTime? GetVideoInspection(int workId)
        {
            if (GetRow(workId).IsNull("VideoInspection"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["VideoInspection"];
            }
        }



        /// <summary>
        /// GetVideoInspectionOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoInspection original</returns>
        public DateTime? GetVideoInspectionOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoInspection"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["VideoInspection", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmh
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Usmh</returns>
        public int? GetUsmh(int workId)
        {
            if (GetRow(workId).IsNull("USMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["USMH"];
            }
        }



        /// <summary>
        /// GetDsmh
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Dsmh</returns>
        public int? GetDsmh(int workId)
        {
            if (GetRow(workId).IsNull("DSMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["DSMH"];
            }
        }



        /// <summary>
        /// GetHistory
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>History</returns>
        public string GetHistory(int workId)
        {
            if (GetRow(workId).IsNull("History"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["History"];
            }
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>comments</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetPostContractDigRequired
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PostContractDigRequired</returns>
        public bool GetPostContractDigRequired(int workId)
        {
            return (bool)GetRow(workId)["PostContractDigRequired"];
        }



        /// <summary>
        /// GetPostContractDigRequiredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PostContractDigRequired original</returns>
        public bool GetPostContractDigRequiredOriginal(int workId)
        {
            return (bool)GetRow(workId)["PostContractDigRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoCutDown
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoCutDown</returns>
        public DateTime? GetCoCutDown(int workId)
        {
            if (GetRow(workId).IsNull("CoCutDown"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoCutDown"];
            }
        }



        /// <summary>
        /// GetCoCutDownOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoCutDown original</returns>
        public DateTime? GetCoCutDownOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CoCutDown"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoCutDown", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalRestoration
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalRestoration</returns>
        public DateTime? GetFinalRestoration(int workId)
        {
            if (GetRow(workId).IsNull("FinalRestoration"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalRestoration"];
            }
        }



        /// <summary>
        /// GetFinalRestorationOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalRestoration original</returns>
        public DateTime? GetFinalRestorationOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["FinalRestoration"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalRestoration", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSMHDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>UsmhDescription</returns>
        public string GetUSMHDescription(int workId)
        {
            if (GetRow(workId).IsNull("USMHDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHDescription"];
            }
        }



        /// <summary>
        /// GetDSMHDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Dsmh Decription</returns>
        public string GetDSMHDescription(int workId)
        {
            if (GetRow(workId).IsNull("DSMHDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHDescription"];
            }
        }



        /// <summary>
        /// GetFlowOrderId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FlowOrderID or EMPTY</returns>
        public string GetFlowOrderId(int workId)
        {
            if (GetRow(workId).IsNull("FlowOrderID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["FlowOrderID"];
            }
        }



        /// <summary>
        /// GetClientLateralId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientLateralId</returns>
        public string GetClientLateralId(int workId)
        {
            if (GetRow(workId).IsNull("ClientLateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientLateralID"];
            }
        }



        /// <summary>
        /// GetClientLateralIdOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientLateralId original</returns>
        public string GetClientLateralIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ClientLateralID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientLateralID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoLengthToPropertyLine
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoLengthToPropertyLine</returns>
        public string GetVideoLengthToPropertyLine(int workId)
        {
            if (GetRow(workId).IsNull("VideoLengthToPropertyLine"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLengthToPropertyLine"];
            }
        }



        /// <summary>
        /// GetVideoLengthToPropertyLineOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoLengthToPropertyLine original</returns>
        public string GetVideoLengthToPropertyLineOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoLengthToPropertyLine"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLengthToPropertyLine", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLiningThruCo
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LiningThruCo</returns>
        public bool GetLiningThruCo(int workId)
        {
            return (bool)GetRow(workId)["LiningThruCo"];
        }



        /// <summary>
        /// GetLiningThruCoOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LiningThruCo original</returns>
        public bool GetLiningThruCoOriginal(int workId)
        {
            return (bool)GetRow(workId)["LiningThruCo", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNoticeDelivered
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NoticeDelivered</returns>
        public DateTime? GetNoticeDelivered(int workId)
        {
            if (GetRow(workId).IsNull("NoticeDelivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["NoticeDelivered"];
            }
        }



        /// <summary>
        /// GetNoticeDeliveredOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NoticeDelivered original</returns>
        public DateTime? GetNoticeDeliveredOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["NoticeDelivered"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["NoticeDelivered", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHamiltonInspectionNumber
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HamiltonInspectionNumber</returns>
        public string GetHamiltonInspectionNumber(int workId)
        {
            if (GetRow(workId).IsNull("HamiltonInspectionNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HamiltonInspectionNumber"];
            }
        }



        /// <summary>
        /// GetHamiltonInspectionNumberOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HamiltonInspectionNumber original</returns>
        public string GetHamiltonInspectionNumberOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HamiltonInspectionNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HamiltonInspectionNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFlange
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Flange</returns>
        public string GetFlange(int workId)
        {
            if (GetRow(workId).IsNull("Flange"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Flange"];
            }
        }



        /// <summary>
        /// GetFlangeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Flange original</returns>
        public string GetFlangeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Flange"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Flange", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGasket
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Gasket</returns>
        public string GetGasket(int workId)
        {
            if (GetRow(workId).IsNull("Gasket"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Gasket"];
            }
        }



        /// <summary>
        /// GetGasketOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Gasket original</returns>
        public string GetGasketOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Gasket"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Gasket", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetConnectionType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ConnectionType</returns>
        public string GetConnectionType(int workId)
        {
            if (GetRow(workId).IsNull("ConnectionType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ConnectionType"];
            }
        }



        /// <summary>
        /// GetConnectionTypeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ConnectionType original</returns>
        public string GetConnectionTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ConnectionType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ConnectionType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDigRequiredPriorToLining
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredPriorToLining</returns>
        public bool GetDigRequiredPriorToLining(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredPriorToLining"];
        }



        /// <summary>
        /// GetDigRequiredPriorToLiningOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredPriorToLining original</returns>
        public bool GetDigRequiredPriorToLiningOriginal(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredPriorToLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDigRequiredAfterLining
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredAfterLining</returns>
        public bool GetDigRequiredAfterLining(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredAfterLining"];
        }



        /// <summary>
        /// GetDigRequiredAfterLiningOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredAfterLining original</returns>
        public bool GetDigRequiredAfterLiningOriginal(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredAfterLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetOutOfScope
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>OutOfScope</returns>
        public bool GetOutOfScope(int workId)
        {
            return (bool)GetRow(workId)["OutOfScope"];
        }



        /// <summary>
        /// GetOutOfScopeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>OutOfScope original</returns>
        public bool GetOutOfScopeOriginal(int workId)
        {
            return (bool)GetRow(workId)["OutOfScope", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHoldClientIssue
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldClientIssue</returns>
        public bool GetHoldClientIssue(int workId)
        {
            return (bool)GetRow(workId)["HoldClientIssue"];
        }



        /// <summary>
        /// GetHoldClientIssueOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldClientIssue original</returns>
        public bool GetHoldClientIssueOriginal(int workId)
        {
            return (bool)GetRow(workId)["HoldClientIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHoldLFSIssue
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldLFSIssue</returns>
        public bool GetHoldLFSIssue(int workId)
        {
            return (bool)GetRow(workId)["HoldLFSIssue"];
        }



        /// <summary>
        /// GetHoldLFSIssueOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldLFSIssue original</returns>
        public bool GetHoldLFSIssueOriginal(int workId)
        {
            return (bool)GetRow(workId)["HoldLFSIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrep
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralRequiresRoboticPrep</returns>
        public bool GetLateralRequiresRoboticPrep(int workId)
        {
            return (bool)GetRow(workId)["LateralRequiresRoboticPrep"];
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrepOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralRequiresRoboticPrep original</returns>
        public bool GetLateralRequiresRoboticPrepOriginal(int workId)
        {
            return (bool)GetRow(workId)["LateralRequiresRoboticPrep", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDigRequiredPriorToLiningCompleted
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredPriorToLiningCompleted</returns>
        public DateTime? GetDigRequiredPriorToLiningCompleted(int workId)
        {
            if (GetRow(workId).IsNull("DigRequiredPriorToLiningCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredPriorToLiningCompleted"];
            }
        }



        /// <summary>
        /// GetDigRequiredPriorToLiningCompletedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredPriorToLiningCompleted original</returns>
        public DateTime? GetDigRequiredPriorToLiningCompletedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DigRequiredPriorToLiningCompleted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredPriorToLiningCompleted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDigRequiredAfterLiningCompleted
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredAfterLiningCompleted</returns>
        public DateTime? GetDigRequiredAfterLiningCompleted(int workId)
        {
            if (GetRow(workId).IsNull("DigRequiredAfterLiningCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredAfterLiningCompleted"];
            }
        }



        /// <summary>
        /// GetDigRequiredAfterLiningCompletedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredAfterLiningCompleted original</returns>
        public DateTime? GetDigRequiredAfterLiningCompletedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DigRequiredAfterLiningCompleted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredAfterLiningCompleted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHoldClientIssueResolved
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldClientIssueResolved</returns>
        public DateTime? GetHoldClientIssueResolved(int workId)
        {
            if (GetRow(workId).IsNull("HoldClientIssueResolved"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldClientIssueResolved"];
            }
        }



        /// <summary>
        /// GetHoldClientIssueResolvedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldClientIssueResolved original</returns>
        public DateTime? GetHoldClientIssueResolvedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HoldClientIssueResolved"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldClientIssueResolved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHoldLFSIssueResolved
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldLFSIssueResolved</returns>
        public DateTime? GetHoldLFSIssueResolved(int workId)
        {
            if (GetRow(workId).IsNull("HoldLFSIssueResolved"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldLFSIssueResolved"];
            }
        }



        /// <summary>
        /// GetHoldLFSIssueResolvedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldLFSIssueResolved original</returns>
        public DateTime? GetHoldLFSIssueResolvedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HoldLFSIssueResolved"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldLFSIssueResolved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrepCompleted
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralRequiresRoboticPrepCompleted</returns>
        public DateTime? GetLateralRequiresRoboticPrepCompleted(int workId)
        {
            if (GetRow(workId).IsNull("LateralRequiresRoboticPrepCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LateralRequiresRoboticPrepCompleted"];
            }
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrepCompletedOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralRequiresRoboticPrepCompleted original</returns>
        public DateTime? GetLateralRequiresRoboticPrepCompletedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LateralRequiresRoboticPrepCompleted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LateralRequiresRoboticPrepCompleted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerType</returns>
        public string GetLinerType(int workId)
        {
            if (GetRow(workId).IsNull("LinerType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerType"];
            }
        }



        /// <summary>
        /// GetLinerTypeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerType</returns>
        public string GetLinerTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LinerType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPrepType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PrepType</returns>
        public string GetPrepType(int workId)
        {
            if (GetRow(workId).IsNull("PrepType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PrepType"];
            }
        }



        /// <summary>
        /// GetPrepTypeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PrepType</returns>
        public string GetPrepTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PrepType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PrepType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// Get DataSet for ODS
        /// </summary>
        /// <param name="flatSectionRaTDS">DataSet to return</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(DataSet flatSectionJlTDS)
        {
            return flatSectionJlTDS;
        }



        /// <summary>
        /// GetDyeTestReq
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DyeTestReq</returns>
        public bool GetDyeTestReq(int workId)
        {
            return (bool)GetRow(workId)["DyeTestReq"];
        }



        /// <summary>
        /// GetDyeTestReqOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DyeTestReq original</returns>
        public bool GetDyeTestReqOriginal(int workId)
        {
            return (bool)GetRow(workId)["DyeTestReq", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDyeTestComplete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DyeTestComplete</returns>
        public DateTime? GetDyeTestComplete(int workId)
        {
            if (GetRow(workId).IsNull("DyeTestComplete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DyeTestComplete"];
            }
        }



        /// <summary>
        /// GetDyeTestCompleteOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DyeTestComplete original</returns>
        public DateTime? GetDyeTestCompleteOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DyeTestComplete"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DyeTestComplete", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralDescription</returns>
        public string GetContractYear(int workId)
        {
            if (GetRow(workId).IsNull("ContractYear"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ContractYear"];
            }
        }



        /// <summary>
        /// GetContractYearOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PrepType</returns>
        public string GetContractYearOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ContractYear"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ContractYear", DataRowVersion.Original];
            }
        }



    }
}