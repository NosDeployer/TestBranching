using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// LateralLocationSheetReport
    /// </summary>
    public class LateralLocationSheetReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LateralLocationSheetReport()
            : base("LateralLocationSheet")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LateralLocationSheetReport(DataSet data)
            : base(data, "LateralLocationSheet")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LateralLocationSheetReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByAssetIdWorkIdProjectIdMeasuredFrom
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workId">workId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="measuredFrom">measuredFrom</param>
        /// /// <param name="companyId">companyId</param>
        public int LoadByAssetIdWorkIdProjectIdMeasuredFrom(int assetId, int workId, int projectId, string measuredFrom, int companyId)
        {
            LateralLocationSheetReportGateway lateralLocationSheetReportGateway = new LateralLocationSheetReportGateway(Data);
            lateralLocationSheetReportGateway.LoadByAssetId(assetId, companyId);

            return UpdateForReport(assetId, workId, projectId, measuredFrom, companyId);
        }



        /// <summary>
        /// LoadByProjectIdJlNavigatorTDS
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jlNavigatorTDS">jlNavigatorTDS</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProjectIdJlNavigatorTDS(int projectId, JlNavigatorTDS jlNavigatorTDS, int companyId)
        {
            ArrayList sections = new ArrayList();
            LateralLocationSheetReportGateway lateralLocationSheetReportGateway = new LateralLocationSheetReportGateway(Data);

            lateralLocationSheetReportGateway.ClearBeforeFill = false;

            foreach (JlNavigatorTDS.JlNavigatorRow jlNavigatorRow in jlNavigatorTDS.JlNavigator)
            {
                if (jlNavigatorRow.Selected)
                {
                    if (!sections.Contains(jlNavigatorRow.AssetID))
                    {
                        sections.Add(jlNavigatorRow.AssetID);
                        int assetId = jlNavigatorRow.AssetID;

                        int workIdFll = GetWorkId(projectId, assetId, "Full Length Lining", companyId);
                        string measuredFrom = "USMH";
                        if (workIdFll > 0)
                        {
                            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, assetId, companyId);
                            measuredFrom = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll);
                        }                        
                                                
                        // Get Data            
                        lateralLocationSheetReportGateway.LoadByAssetId(assetId, companyId);
                        UpdateForReportForJunctionLining(assetId, workIdFll, projectId, measuredFrom, companyId);
                    }
                }
            }
            
            lateralLocationSheetReportGateway.ClearBeforeFill = true;             
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workId">workId</param>
        /// <param name="workIdJl">workIdJl</param>
        /// <param name="projectId">projectId</param>
        /// <param name="measuredFrom">measuredFrom</param>
        /// <param name="companyId">companyId</param>        
        private int UpdateForReport(int assetId, int workId, int projectId, string measuredFrom, int companyId)
        {
            int lateralsTot = 0;

            foreach (LateralLocationSheetReportTDS.LateralLocationSheetRow row in (LateralLocationSheetReportTDS.LateralLocationSheetDataTable)Table)
            {
                int lateralNumber = 0;
   
                LateralLocationSheetLateralDetailsReport lateralLocationSheetLateralDetailsReportSorted;

                LateralLocationSheetLateralDetailsReport lateralLocationSheetLateralDetailsReport = new LateralLocationSheetLateralDetailsReport();
                lateralLocationSheetLateralDetailsReport.LoadBySectionIdWorkIdProjectId(assetId, workId, projectId, companyId);
                lateralsTot = lateralLocationSheetLateralDetailsReport.Table.Rows.Count;

                if (lateralsTot > 0)
                {
                    int totalLaterals = 0;
                    totalLaterals = lateralLocationSheetLateralDetailsReport.Table.Rows.Count;
                    decimal div;
                    decimal interval;

                    if (totalLaterals > 26)
                    {
                        interval = 1;
                    }
                    else
                    {
                        div = 26 / totalLaterals;
                        interval = Math.Truncate(div);
                    }

                    lateralLocationSheetLateralDetailsReportSorted = Sort(lateralLocationSheetLateralDetailsReport, measuredFrom);

                    foreach (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsRow lateralRow in (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsDataTable)lateralLocationSheetLateralDetailsReportSorted.Table)
                    {                        
                        lateralNumber = lateralNumber + (int)interval;

                        if (totalLaterals == 1)
                        {
                            lateralNumber = 13;
                        }

                        // Determine position
                        string clock = ""; if (!lateralRow.IsClockPositionNull()) clock = lateralRow.ClockPosition;
                        string clockPosition = "N";
                        Distance d;
                        string distance = "";

                        if (measuredFrom == "DSMH")
                        {
                            clockPosition = "S";

                            if (clock != "")
                            {
                                if (clock == "1" || clock == "1:00" || clock == "01:00" || clock == "2" || clock == "2:00" || clock == "02:00" || clock == "3" || clock == "3:00" || clock == "03:00" || clock == "4" || clock == "4:00" || clock == "04:00" || clock == "5" || clock == "5:00" || clock == "05:00" || clock == "6" && clock != "6:00" && clock != "06:00")
                                {
                                    clockPosition = "N";
                                }
                            }

                            if (!lateralRow.IsReverseSetupNull()) d = new Distance(lateralRow.ReverseSetup); else d = new Distance();
                            distance = (!lateralRow.IsReverseSetupNull()) ? d.ToStringInMet3() + "/" + ((decimal)Math.Round(d.ToDoubleInEng3(), 1)).ToString() + "ft  " : "Distance not defined.  ";
                        }
                        else
                        {
                            clockPosition = "N";

                            if (clock != "")
                            {
                                if (clock == "1" || clock == "1:00" || clock == "01:00" || clock == "2" || clock == "2:00" || clock == "02:00" || clock == "3" || clock == "3:00" || clock == "03:00" || clock == "4" || clock == "4:00" || clock == "04:00" || clock == "5" || clock == "5:00" || clock == "05:00" || clock == "6" && clock != "6:00" && clock != "06:00")
                                {
                                    clockPosition = "S";
                                }
                            }

                            if (!lateralRow.IsVideoDistanceNull()) d = new Distance(lateralRow.VideoDistance); else d = new Distance();
                            distance = (!lateralRow.IsVideoDistanceNull()) ? d.ToStringInMet3() + "/" + ((decimal)Math.Round(d.ToDoubleInEng3(), 1)).ToString() + "ft  " : "Distance not defined.  ";
                        }

                        // Determine address
                        string address = ""; if (!lateralRow.IsAddressNull()) address = lateralRow.Address;
                        string connection = "";
                        string connectionType = ""; if (!lateralRow.IsConnectionTypeNull()) connectionType = lateralRow.ConnectionType;
                        if (connectionType != "")
                        {
                            connection += " (" + connectionType + ")    ";
                        }
                        else
                        {
                            connection += "    ";
                        }

                        // Determine state
                        string state = ""; if (!lateralRow.IsStateNull())
                        {
                            if (lateralRow.State == "Visibly Plugged")
                            {
                                state = "- VP ";
                            }
                            else
                            {
                                state = "- " + lateralRow.State + "  ";
                            }
                        }                                               
                                                
                        // Determine color, flange and out of scope
                        DateTime? linerInstalled = null;
                        string flange = "";
                        bool outOfScope = false;

                        int workIdJl = GetWorkId(projectId, lateralRow.AssetID, "Junction Lining Lateral", companyId);
                        if (workIdJl > 0)
                        {
                            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                            workJunctionLiningLateralGateway.LoadByWorkId(workIdJl, companyId);
                            linerInstalled = workJunctionLiningLateralGateway.GetLinerInstalled(workIdJl);
                            flange = workJunctionLiningLateralGateway.GetFlange(workIdJl);
                            outOfScope = workJunctionLiningLateralGateway.GetOutOfScope(workIdJl);
                        }

                        string color = "";
                        
                        if (linerInstalled.HasValue)
                        {
                            color = "blue";
                        }
                        else
                        {
                            if (outOfScope)
                            {
                                color = "red";
                            }
                            else
                            {
                                if (lateralRow.LineLateral)
                                {
                                    color = "green";
                                }
                                else
                                {
                                    if ((!lateralRow.IsStateNull()) && (lateralRow.State == "Visibly Plugged") || (!lateralRow.LineLateral))
                                    {
                                        color = "red";
                                    }
                                }
                            }
                        }

                        // Set distance
                        if ((distance == "0.00m/0ft") && (flange == "MH Shot"))
                        {
                            distance = " " + connection + distance + "MH Shot  "  + state + "  ";
                        }
                        else
                        {
                            distance = " " + connection + distance + state + "  ";
                        }

                        // Set values                        
                        switch (lateralNumber)
                        {
                            case 1:
                                row.ID1 = lateralRow.LateralID;
                                row.A1 = address;
                                row.D1 = distance;
                                row.CP1 = clockPosition;
                                row.C1 = color;
                                break;

                            case 2:
                                row.ID2 = lateralRow.LateralID;
                                row.A2 = address;
                                row.D2 = distance;
                                row.CP2 = clockPosition;
                                row.C2 = color;
                                break;

                            case 3:
                                row.ID3 = lateralRow.LateralID;
                                row.A3 = address;
                                row.D3 = distance;
                                row.CP3 = clockPosition;
                                row.C3 = color;
                                break;

                            case 4:
                                row.ID4 = lateralRow.LateralID;
                                row.A4 = address;
                                row.D4 = distance;
                                row.CP4 = clockPosition;
                                row.C4 = color;
                                break;

                            case 5:
                                row.ID5 = lateralRow.LateralID;
                                row.A5 = address;
                                row.D5 = distance;
                                row.CP5 = clockPosition;
                                row.C5 = color;
                                break;

                            case 6:
                                row.ID6 = lateralRow.LateralID;
                                row.A6 = address;
                                row.D6 = distance;
                                row.CP6 = clockPosition;
                                row.C6 = color;
                                break;

                            case 7:
                                row.ID7 = lateralRow.LateralID;
                                row.A7 = address;
                                row.D7 = distance;
                                row.CP7 = clockPosition;
                                row.C7 = color;
                                break;

                            case 8:
                                row.ID8 = lateralRow.LateralID;
                                row.A8 = address;
                                row.D8 = distance;
                                row.CP8 = clockPosition;
                                row.C8 = color;
                                break;

                            case 9:
                                row.ID9 = lateralRow.LateralID;
                                row.A9 = address;
                                row.D9 = distance;
                                row.CP9 = clockPosition;
                                row.C9 = color;
                                break;

                            case 10:
                                row.ID10 = lateralRow.LateralID;
                                row.A10 = address;
                                row.D10 = distance;
                                row.CP10 = clockPosition;
                                row.C10 = color;
                                break;

                            case 11:
                                row.ID11 = lateralRow.LateralID;
                                row.A11 = address;
                                row.D11 = distance;
                                row.CP11 = clockPosition;
                                row.C11 = color;
                                break;

                            case 12:
                                row.ID12 = lateralRow.LateralID;
                                row.A12 = address;
                                row.D12 = distance;
                                row.CP12 = clockPosition;
                                row.C12 = color;
                                break;

                            case 13:
                                row.ID13 = lateralRow.LateralID;
                                row.A13 = address;
                                row.D13 = distance;
                                row.CP13 = clockPosition;
                                row.C13 = color;
                                break;

                            case 14:
                                row.ID14 = lateralRow.LateralID;
                                row.A14 = address;
                                row.D14 = distance;
                                row.CP14 = clockPosition;
                                row.C14 = color;
                                break;

                            case 15:
                                row.ID15 = lateralRow.LateralID;
                                row.A15 = address;
                                row.D15 = distance;
                                row.CP15 = clockPosition;
                                row.C15 = color;
                                break;

                            case 16:
                                row.ID16 = lateralRow.LateralID;
                                row.A16 = address;
                                row.D16 = distance;
                                row.CP16 = clockPosition;
                                row.C16 = color;
                                break;

                            case 17:
                                row.ID17 = lateralRow.LateralID;
                                row.A17 = address;
                                row.D17 = distance;
                                row.CP17 = clockPosition;
                                row.C17 = color;
                                break;

                            case 18:
                                row.ID18 = lateralRow.LateralID;
                                row.A18 = address;
                                row.D18 = distance;
                                row.CP18 = clockPosition;
                                row.C18 = color;
                                break;

                            case 19:
                                row.ID19 = lateralRow.LateralID;
                                row.A19 = address;
                                row.D19 = distance;
                                row.CP19 = clockPosition;
                                row.C19 = color;
                                break;

                            case 20:
                                row.ID20 = lateralRow.LateralID;
                                row.A20 = address;
                                row.D20 = distance;
                                row.CP20 = clockPosition;
                                row.C20 = color;
                                break;

                            case 21:
                                row.ID21 = lateralRow.LateralID;
                                row.A21 = address;
                                row.D21 = distance;
                                row.CP21 = clockPosition;
                                row.C21 = color;
                                break;

                            case 22:
                                row.ID22 = lateralRow.LateralID;
                                row.A22 = address;
                                row.D22 = distance;
                                row.CP22 = clockPosition;
                                row.C22 = color;
                                break;

                            case 23:
                                row.ID23 = lateralRow.LateralID;
                                row.A23 = address;
                                row.D23 = distance;
                                row.CP23 = clockPosition;
                                row.C23 = color;
                                break;

                            case 24:
                                row.ID24 = lateralRow.LateralID;
                                row.A24 = address;
                                row.D24 = distance;
                                row.CP24 = clockPosition;
                                row.C24 = color;
                                break;

                            case 25:
                                row.ID25 = lateralRow.LateralID;
                                row.A25 = address;
                                row.D25 = distance;
                                row.CP25 = clockPosition;
                                row.C25 = color;
                                break;

                            case 26:
                                row.ID26 = lateralRow.LateralID;
                                row.A26 = address;
                                row.D26 = distance;
                                row.CP26 = clockPosition;
                                row.C26 = color;
                                break;

                            case 27:
                                row.ID27 = lateralRow.LateralID;
                                row.A27 = address;
                                row.D27 = distance;
                                row.CP27 = clockPosition;
                                row.C27 = color;
                                break;

                            case 28:
                                row.ID28 = lateralRow.LateralID;
                                row.A28 = address;
                                row.D28 = distance;
                                row.CP28 = clockPosition;
                                row.C28 = color;
                                break;

                            case 29:
                                row.ID29 = lateralRow.LateralID;
                                row.A29 = address;
                                row.D29 = distance;
                                row.CP29 = clockPosition;
                                row.C29 = color;
                                break;

                            case 30:
                                row.ID30 = lateralRow.LateralID;
                                row.A30 = address;
                                row.D30 = distance;
                                row.CP30 = clockPosition;
                                row.C30 = color;
                                break;

                            case 31:
                                row.ID31 = lateralRow.LateralID;
                                row.A31 = address;
                                row.D31 = distance;
                                row.CP31 = clockPosition;
                                row.C31 = color;
                                break;

                            case 32:
                                row.ID32 = lateralRow.LateralID;
                                row.A32 = address;
                                row.D32 = distance;
                                row.CP32 = clockPosition;
                                row.C32 = color;
                                break;

                            case 33:
                                row.ID33 = lateralRow.LateralID;
                                row.A33 = address;
                                row.D33 = distance;
                                row.CP33 = clockPosition;
                                row.C33 = color;
                                break;

                            case 34:
                                row.ID34 = lateralRow.LateralID;
                                row.A34 = address;
                                row.D34 = distance;
                                row.CP34 = clockPosition;
                                row.C34 = color;
                                break;

                            case 35:
                                row.ID35 = lateralRow.LateralID;
                                row.A35 = address;
                                row.D35 = distance;
                                row.CP35 = clockPosition;
                                row.C35 = color;
                                break;

                            case 36:
                                row.ID36 = lateralRow.LateralID;
                                row.A36 = address;
                                row.D36 = distance;
                                row.CP36 = clockPosition;
                                row.C36 = color;
                                break;

                            case 37:
                                row.ID37 = lateralRow.LateralID;
                                row.A37 = address;
                                row.D37 = distance;
                                row.CP37 = clockPosition;
                                row.C37 = color;
                                break;

                            case 38:
                                row.ID38 = lateralRow.LateralID;
                                row.A38 = address;
                                row.D38 = distance;
                                row.CP38 = clockPosition;
                                row.C38 = color;
                                break;

                            case 39:
                                row.ID39 = lateralRow.LateralID;
                                row.A39 = address;
                                row.D39 = distance;
                                row.CP39 = clockPosition;
                                row.C39 = color;
                                break;

                            case 40:
                                row.ID40 = lateralRow.LateralID;
                                row.A40 = address;
                                row.D40 = distance;
                                row.CP40 = clockPosition;
                                row.C40 = color;
                                break;

                            case 41:
                                row.ID41 = lateralRow.LateralID;
                                row.A41 = address;
                                row.D41 = distance;
                                row.CP41 = clockPosition;
                                row.C41 = color;
                                break;

                            case 42:
                                row.ID42 = lateralRow.LateralID;
                                row.A42 = address;
                                row.D42 = distance;
                                row.CP42 = clockPosition;
                                row.C42 = color;
                                break;

                            case 43:
                                row.ID43 = lateralRow.LateralID;
                                row.A43 = address;
                                row.D43 = distance;
                                row.CP43 = clockPosition;
                                row.C43 = color;
                                break;

                            case 44:
                                row.ID44 = lateralRow.LateralID;
                                row.A44 = address;
                                row.D44 = distance;
                                row.CP44 = clockPosition;
                                row.C44 = color;
                                break;

                            case 45:
                                row.ID45 = lateralRow.LateralID;
                                row.A45 = address;
                                row.D45 = distance;
                                row.CP45 = clockPosition;
                                row.C45 = color;
                                break;

                            case 46:
                                row.ID46 = lateralRow.LateralID;
                                row.A46 = address;
                                row.D46 = distance;
                                row.CP46 = clockPosition;
                                row.C46 = color;
                                break;

                            case 47:
                                row.ID47 = lateralRow.LateralID;
                                row.A47 = address;
                                row.D47 = distance;
                                row.CP47 = clockPosition;
                                row.C47 = color;
                                break;

                            case 48:
                                row.ID48 = lateralRow.LateralID;
                                row.A48 = address;
                                row.D48 = distance;
                                row.CP48 = clockPosition;
                                row.C48 = color;
                                break;

                            case 49:
                                row.ID49 = lateralRow.LateralID;
                                row.A49 = address;
                                row.D49 = distance;
                                row.CP49 = clockPosition;
                                row.C49 = color;
                                break;

                            case 50:
                                row.ID50 = lateralRow.LateralID;
                                row.A50 = address;
                                row.D50 = distance;
                                row.CP50 = clockPosition;
                                row.C50 = color;
                                break;

                            case 51:
                                row.ID51 = lateralRow.LateralID;
                                row.A51 = address;
                                row.D51 = distance;
                                row.CP51 = clockPosition;
                                row.C51 = color;
                                break;

                            case 52:
                                row.ID52 = lateralRow.LateralID;
                                row.A52 = address;
                                row.D52 = distance;
                                row.CP52 = clockPosition;
                                row.C52 = color;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            return lateralsTot;
        }



        /// <summary>
        /// UpdateForReportForJunctionLining
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workId">workId</param>
        /// <param name="projectId">projectId</param>        
        /// <param name="measuredFrom">measuredFrom</param>
        /// /// <param name="companyId">companyId</param>
        private int UpdateForReportForJunctionLining(int assetId, int workId, int projectId, string measuredFrom, int companyId)
        {
            int lateralsTot = 0;

            foreach (LateralLocationSheetReportTDS.LateralLocationSheetRow row in (LateralLocationSheetReportTDS.LateralLocationSheetDataTable)Table)
            {
                if (row.AssetID == assetId)
                {                   
                    int lateralNumber = 0;

                    LateralLocationSheetLateralDetailsReport lateralLocationSheetLateralDetailsReportSorted;

                    LateralLocationSheetLateralDetailsReport lateralLocationSheetLateralDetailsReport = new LateralLocationSheetLateralDetailsReport();
                    lateralLocationSheetLateralDetailsReport.LoadBySectionIdWorkIdProjectId(assetId, workId, projectId, companyId);
                    lateralsTot = lateralLocationSheetLateralDetailsReport.Table.Rows.Count;

                    if (lateralLocationSheetLateralDetailsReport.Table.Rows.Count > 0)
                    {
                        int totalLaterals = 0;
                        totalLaterals = lateralLocationSheetLateralDetailsReport.Table.Rows.Count;
                        decimal div;
                        decimal interval;

                        if (totalLaterals > 26)
                        {
                            interval = 1;
                        }
                        else
                        {
                            div = 26 / totalLaterals;
                            interval = Math.Truncate(div);
                        }

                        lateralLocationSheetLateralDetailsReportSorted = Sort(lateralLocationSheetLateralDetailsReport, measuredFrom);

                        foreach (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsRow lateralRow in (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsDataTable)lateralLocationSheetLateralDetailsReportSorted.Table)
                        {
                            lateralNumber = lateralNumber + (int)interval;

                            if (totalLaterals == 1)
                            {
                                lateralNumber = 13;
                            }

                            // Determine position
                            string clock = ""; if (!lateralRow.IsClockPositionNull()) clock = lateralRow.ClockPosition;
                            string clockPosition = "N";
                            Distance d;
                            string distance = "";

                            if (measuredFrom == "DSMH")
                            {
                                clockPosition = "S";

                                if (clock != "")
                                {
                                    if (clock == "1" || clock == "1:00" || clock == "01:00" || clock == "2" || clock == "2:00" || clock == "02:00" || clock == "3" || clock == "3:00" || clock == "03:00" || clock == "4" || clock == "4:00" || clock == "04:00" || clock == "5" || clock == "5:00" || clock == "05:00" || clock == "6" && clock != "6:00" && clock != "06:00")
                                    {
                                        clockPosition = "N";
                                    }
                                }

                                if (!lateralRow.IsReverseSetupNull()) d = new Distance(lateralRow.ReverseSetup); else d = new Distance();
                                distance = (!lateralRow.IsReverseSetupNull()) ? d.ToStringInMet3() + "/" + ((decimal)Math.Round(d.ToDoubleInEng3(), 1)).ToString() + "ft  " : "Distance not defined.  ";
                            }
                            else
                            {
                                clockPosition = "N";

                                if (clock != "")
                                {
                                    if (clock == "1" || clock == "1:00" || clock == "01:00" || clock == "2" || clock == "2:00" || clock == "02:00" || clock == "3" || clock == "3:00" || clock == "03:00" || clock == "4" || clock == "4:00" || clock == "04:00" || clock == "5" || clock == "5:00" || clock == "05:00" || clock == "6" && clock != "6:00" && clock != "06:00")
                                    {
                                        clockPosition = "S";
                                    }
                                }

                                if (!lateralRow.IsVideoDistanceNull()) d = new Distance(lateralRow.VideoDistance); else d = new Distance();
                                distance = (!lateralRow.IsVideoDistanceNull()) ? d.ToStringInMet3() + "/" + ((decimal)Math.Round(d.ToDoubleInEng3(), 1)).ToString() + "ft  " : "Distance not defined.  ";
                            }

                            // Determine address
                            string address = ""; if (!lateralRow.IsAddressNull()) address = lateralRow.Address;
                            string connection = "";
                            string connectionType = ""; if (!lateralRow.IsConnectionTypeNull()) connectionType = lateralRow.ConnectionType;
                            if (connectionType != "")
                            {
                                connection += " (" + connectionType + ")    ";
                            }
                            else
                            {
                                connection += "    ";
                            }

                            // Determine state
                            string state = ""; if (!lateralRow.IsStateNull())
                            {
                                if (lateralRow.State == "Visibly Plugged")
                                {
                                    state = "- VP ";
                                }
                                else
                                {
                                    state = "- " + lateralRow.State + "  ";
                                }
                            }
                           
                            // Determine color, flange and out of scope
                            DateTime? linerInstalled = null;
                            string flange = "";
                            bool outOfScope = false;

                            int workIdJl = GetWorkId(projectId, lateralRow.AssetID, "Junction Lining Lateral", companyId);
                            if (workIdJl > 0)
                            {
                                WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                                workJunctionLiningLateralGateway.LoadByWorkId(workIdJl, companyId);
                                linerInstalled = workJunctionLiningLateralGateway.GetLinerInstalled(workIdJl);
                                flange = workJunctionLiningLateralGateway.GetFlange(workIdJl);
                                outOfScope = workJunctionLiningLateralGateway.GetOutOfScope(workIdJl);
                            }

                            string color = "";                                                      

                            if (linerInstalled.HasValue)
                            {
                                color = "blue";
                            }
                            else
                            {
                                if (outOfScope)
                                {
                                    color = "red";
                                }
                                else
                                {
                                    if (lateralRow.LineLateral)
                                    {
                                        color = "green";
                                    }
                                    else
                                    {
                                        if ((!lateralRow.IsStateNull()) && (lateralRow.State == "Visibly Plugged") || (!lateralRow.LineLateral))
                                        {
                                            color = "red";
                                        }
                                    }
                                }
                            }

                            // Set distance
                            if ((distance == "0.00m/0ft") && (flange == "MH Shot"))
                            {
                                distance = " " + connection + distance + "MH Shot  " + state + "  ";
                            }
                            else
                            {
                                distance = " " + connection + distance + state + "  ";
                            }
                                                
                            // Set values
                            switch (lateralNumber)
                            {
                                case 1:
                                    row.ID1 = lateralRow.LateralID;
                                    row.A1 = address;
                                    row.D1 = distance;
                                    row.CP1 = clockPosition;
                                    row.C1 = color;
                                    break;

                                case 2:
                                    row.ID2 = lateralRow.LateralID;
                                    row.A2 = address;
                                    row.D2 = distance;
                                    row.CP2 = clockPosition;
                                    row.C2 = color;
                                    break;

                                case 3:
                                    row.ID3 = lateralRow.LateralID;
                                    row.A3 = address;
                                    row.D3 = distance;
                                    row.CP3 = clockPosition;
                                    row.C3 = color;
                                    break;

                                case 4:
                                    row.ID4 = lateralRow.LateralID;
                                    row.A4 = address;
                                    row.D4 = distance;
                                    row.CP4 = clockPosition;
                                    row.C4 = color;
                                    break;

                                case 5:
                                    row.ID5 = lateralRow.LateralID;
                                    row.A5 = address;
                                    row.D5 = distance;
                                    row.CP5 = clockPosition;
                                    row.C5 = color;
                                    break;

                                case 6:
                                    row.ID6 = lateralRow.LateralID;
                                    row.A6 = address;
                                    row.D6 = distance;
                                    row.CP6 = clockPosition;
                                    row.C6 = color;
                                    break;

                                case 7:
                                    row.ID7 = lateralRow.LateralID;
                                    row.A7 = address;
                                    row.D7 = distance;
                                    row.CP7 = clockPosition;
                                    row.C7 = color;
                                    break;

                                case 8:
                                    row.ID8 = lateralRow.LateralID;
                                    row.A8 = address;
                                    row.D8 = distance;
                                    row.CP8 = clockPosition;
                                    row.C8 = color;
                                    break;

                                case 9:
                                    row.ID9 = lateralRow.LateralID;
                                    row.A9 = address;
                                    row.D9 = distance;
                                    row.CP9 = clockPosition;
                                    row.C9 = color;
                                    break;

                                case 10:
                                    row.ID10 = lateralRow.LateralID;
                                    row.A10 = address;
                                    row.D10 = distance;
                                    row.CP10 = clockPosition;
                                    row.C10 = color;
                                    break;

                                case 11:
                                    row.ID11 = lateralRow.LateralID;
                                    row.A11 = address;
                                    row.D11 = distance;
                                    row.CP11 = clockPosition;
                                    row.C11 = color;
                                    break;

                                case 12:
                                    row.ID12 = lateralRow.LateralID;
                                    row.A12 = address;
                                    row.D12 = distance;
                                    row.CP12 = clockPosition;
                                    row.C12 = color;
                                    break;

                                case 13:
                                    row.ID13 = lateralRow.LateralID;
                                    row.A13 = address;
                                    row.D13 = distance;
                                    row.CP13 = clockPosition;
                                    row.C13 = color;
                                    break;

                                case 14:
                                    row.ID14 = lateralRow.LateralID;
                                    row.A14 = address;
                                    row.D14 = distance;
                                    row.CP14 = clockPosition;
                                    row.C14 = color;
                                    break;

                                case 15:
                                    row.ID15 = lateralRow.LateralID;
                                    row.A15 = address;
                                    row.D15 = distance;
                                    row.CP15 = clockPosition;
                                    row.C15 = color;
                                    break;

                                case 16:
                                    row.ID16 = lateralRow.LateralID;
                                    row.A16 = address;
                                    row.D16 = distance;
                                    row.CP16 = clockPosition;
                                    row.C16 = color;
                                    break;

                                case 17:
                                    row.ID17 = lateralRow.LateralID;
                                    row.A17 = address;
                                    row.D17 = distance;
                                    row.CP17 = clockPosition;
                                    row.C17 = color;
                                    break;

                                case 18:
                                    row.ID18 = lateralRow.LateralID;
                                    row.A18 = address;
                                    row.D18 = distance;
                                    row.CP18 = clockPosition;
                                    row.C18 = color;
                                    break;

                                case 19:
                                    row.ID19 = lateralRow.LateralID;
                                    row.A19 = address;
                                    row.D19 = distance;
                                    row.CP19 = clockPosition;
                                    row.C19 = color;
                                    break;

                                case 20:
                                    row.ID20 = lateralRow.LateralID;
                                    row.A20 = address;
                                    row.D20 = distance;
                                    row.CP20 = clockPosition;
                                    row.C20 = color;
                                    break;

                                case 21:
                                    row.ID21 = lateralRow.LateralID;
                                    row.A21 = address;
                                    row.D21 = distance;
                                    row.CP21 = clockPosition;
                                    row.C21 = color;
                                    break;

                                case 22:
                                    row.ID22 = lateralRow.LateralID;
                                    row.A22 = address;
                                    row.D22 = distance;
                                    row.CP22 = clockPosition;
                                    row.C22 = color;
                                    break;

                                case 23:
                                    row.ID23 = lateralRow.LateralID;
                                    row.A23 = address;
                                    row.D23 = distance;
                                    row.CP23 = clockPosition;
                                    row.C23 = color;
                                    break;

                                case 24:
                                    row.ID24 = lateralRow.LateralID;
                                    row.A24 = address;
                                    row.D24 = distance;
                                    row.CP24 = clockPosition;
                                    row.C24 = color;
                                    break;

                                case 25:
                                    row.ID25 = lateralRow.LateralID;
                                    row.A25 = address;
                                    row.D25 = distance;
                                    row.CP25 = clockPosition;
                                    row.C25 = color;
                                    break;

                                case 26:
                                    row.ID26 = lateralRow.LateralID;
                                    row.A26 = address;
                                    row.D26 = distance;
                                    row.CP26 = clockPosition;
                                    row.C26 = color;
                                    break;

                                case 27:
                                    row.ID27 = lateralRow.LateralID;
                                    row.A27 = address;
                                    row.D27 = distance;
                                    row.CP27 = clockPosition;
                                    row.C27 = color;
                                    break;

                                case 28:
                                    row.ID28 = lateralRow.LateralID;
                                    row.A28 = address;
                                    row.D28 = distance;
                                    row.CP28 = clockPosition;
                                    row.C28 = color;
                                    break;

                                case 29:
                                    row.ID29 = lateralRow.LateralID;
                                    row.A29 = address;
                                    row.D29 = distance;
                                    row.CP29 = clockPosition;
                                    row.C29 = color;
                                    break;

                                case 30:
                                    row.ID30 = lateralRow.LateralID;
                                    row.A30 = address;
                                    row.D30 = distance;
                                    row.CP30 = clockPosition;
                                    row.C30 = color;
                                    break;

                                case 31:
                                    row.ID31 = lateralRow.LateralID;
                                    row.A31 = address;
                                    row.D31 = distance;
                                    row.CP31 = clockPosition;
                                    row.C31 = color;
                                    break;

                                case 32:
                                    row.ID32 = lateralRow.LateralID;
                                    row.A32 = address;
                                    row.D32 = distance;
                                    row.CP32 = clockPosition;
                                    row.C32 = color;
                                    break;

                                case 33:
                                    row.ID33 = lateralRow.LateralID;
                                    row.A33 = address;
                                    row.D33 = distance;
                                    row.CP33 = clockPosition;
                                    row.C33 = color;
                                    break;

                                case 34:
                                    row.ID34 = lateralRow.LateralID;
                                    row.A34 = address;
                                    row.D34 = distance;
                                    row.CP34 = clockPosition;
                                    row.C34 = color;
                                    break;

                                case 35:
                                    row.ID35 = lateralRow.LateralID;
                                    row.A35 = address;
                                    row.D35 = distance;
                                    row.CP35 = clockPosition;
                                    row.C35 = color;
                                    break;

                                case 36:
                                    row.ID36 = lateralRow.LateralID;
                                    row.A36 = address;
                                    row.D36 = distance;
                                    row.CP36 = clockPosition;
                                    row.C36 = color;
                                    break;

                                case 37:
                                    row.ID37 = lateralRow.LateralID;
                                    row.A37 = address;
                                    row.D37 = distance;
                                    row.CP37 = clockPosition;
                                    row.C37 = color;
                                    break;

                                case 38:
                                    row.ID38 = lateralRow.LateralID;
                                    row.A38 = address;
                                    row.D38 = distance;
                                    row.CP38 = clockPosition;
                                    row.C38 = color;
                                    break;

                                case 39:
                                    row.ID39 = lateralRow.LateralID;
                                    row.A39 = address;
                                    row.D39 = distance;
                                    row.CP39 = clockPosition;
                                    row.C39 = color;
                                    break;

                                case 40:
                                    row.ID40 = lateralRow.LateralID;
                                    row.A40 = address;
                                    row.D40 = distance;
                                    row.CP40 = clockPosition;
                                    row.C40 = color;
                                    break;

                                case 41:
                                    row.ID41 = lateralRow.LateralID;
                                    row.A41 = address;
                                    row.D41 = distance;
                                    row.CP41 = clockPosition;
                                    row.C41 = color;
                                    break;

                                case 42:
                                    row.ID42 = lateralRow.LateralID;
                                    row.A42 = address;
                                    row.D42 = distance;
                                    row.CP42 = clockPosition;
                                    row.C42 = color;
                                    break;

                                case 43:
                                    row.ID43 = lateralRow.LateralID;
                                    row.A43 = address;
                                    row.D43 = distance;
                                    row.CP43 = clockPosition;
                                    row.C43 = color;
                                    break;

                                case 44:
                                    row.ID44 = lateralRow.LateralID;
                                    row.A44 = address;
                                    row.D44 = distance;
                                    row.CP44 = clockPosition;
                                    row.C44 = color;
                                    break;

                                case 45:
                                    row.ID45 = lateralRow.LateralID;
                                    row.A45 = address;
                                    row.D45 = distance;
                                    row.CP45 = clockPosition;
                                    row.C45 = color;
                                    break;

                                case 46:
                                    row.ID46 = lateralRow.LateralID;
                                    row.A46 = address;
                                    row.D46 = distance;
                                    row.CP46 = clockPosition;
                                    row.C46 = color;
                                    break;

                                case 47:
                                    row.ID47 = lateralRow.LateralID;
                                    row.A47 = address;
                                    row.D47 = distance;
                                    row.CP47 = clockPosition;
                                    row.C47 = color;
                                    break;

                                case 48:
                                    row.ID48 = lateralRow.LateralID;
                                    row.A48 = address;
                                    row.D48 = distance;
                                    row.CP48 = clockPosition;
                                    row.C48 = color;
                                    break;

                                case 49:
                                    row.ID49 = lateralRow.LateralID;
                                    row.A49 = address;
                                    row.D49 = distance;
                                    row.CP49 = clockPosition;
                                    row.C49 = color;
                                    break;

                                case 50:
                                    row.ID50 = lateralRow.LateralID;
                                    row.A50 = address;
                                    row.D50 = distance;
                                    row.CP50 = clockPosition;
                                    row.C50 = color;
                                    break;

                                case 51:
                                    row.ID51 = lateralRow.LateralID;
                                    row.A51 = address;
                                    row.D51 = distance;
                                    row.CP51 = clockPosition;
                                    row.C51 = color;
                                    break;

                                case 52:
                                    row.ID52 = lateralRow.LateralID;
                                    row.A52 = address;
                                    row.D52 = distance;
                                    row.CP52 = clockPosition;
                                    row.C52 = color;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return lateralsTot;
        }



        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="laterals">laterals</param>
        /// <param name="measuredFrom">measuredFrom</param>
        /// <returns>laterals sorted</returns>
        private LateralLocationSheetLateralDetailsReport Sort(LateralLocationSheetLateralDetailsReport laterals, string measuredFrom)
        {
            if (measuredFrom == "DSMH")
            {
                for (int i = 0; i < laterals.Table.Rows.Count; i++)
                {
                    for (int j = 0; j < laterals.Table.Rows.Count - 1; j++)
                    {
                        double numI = Convert.ToDouble(laterals.Table.Rows[j].ItemArray[8]);
                        double numD = Convert.ToDouble(laterals.Table.Rows[j + 1].ItemArray[8]);
                        if (numI > numD)
                        {
                            object[] aux = laterals.Table.Rows[j].ItemArray;
                            laterals.Table.Rows[j].ItemArray = laterals.Table.Rows[j + 1].ItemArray;
                            laterals.Table.Rows[j + 1].ItemArray = aux;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < laterals.Table.Rows.Count; i++)
                {
                    for (int j = 0; j < laterals.Table.Rows.Count - 1; j++)
                    {
                        double numI = Convert.ToDouble(laterals.Table.Rows[j].ItemArray[5]);
                        double numD = Convert.ToDouble(laterals.Table.Rows[j + 1].ItemArray[5]);
                        if (numI > numD)
                        {
                            object[] aux = laterals.Table.Rows[j].ItemArray;
                            laterals.Table.Rows[j].ItemArray = laterals.Table.Rows[j + 1].ItemArray;
                            laterals.Table.Rows[j + 1].ItemArray = aux;
                        }
                    }
                }
            }
        
            return laterals;
        }



        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>workId</returns>
        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



    }
}