using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlM1Report
    /// </summary>
    public class FlM1Report : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM1Report()
            : base("M1ReportByClient")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM1Report(DataSet data)
            : base(data, "M1ReportByClient")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM1ReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void Load(int companyId, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.Load(companyId);

            UpdateForReport(unitType);
        }


        
        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="date">date</param>
        /// /// <param name="unitType">unitType</param>
        public void LoadByDate(int companyId, string date, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByDate(companyId, date);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="street">street</param>
        /// /// <param name="unitType">unitType</param>
        public void LoadByStreet(int companyId, string street, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByStreet(companyId, street);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadBySubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// /// <param name="unitType">unitType</param>
        public void LoadBySubArea(int companyId, string subArea, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadBySubArea(companyId, subArea);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="unitType">unitType</param>
        public void LoadBySectionId(int companyId, ArrayList sectionsId, string unitType)
        {
            foreach (string sectionId in sectionsId)
            {
                FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
                flM1ReportGateway.ClearBeforeFill = false;
                flM1ReportGateway.LoadBySectionId(companyId, sectionId);
                flM1ReportGateway.ClearBeforeFill = true;
            }

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesId(int companyId, int companiesId, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesIdSectionId(int companyId, int companiesId, string unitType, ArrayList sectionsId)
        {
            foreach (string sectionId in sectionsId)
            {
                FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
                flM1ReportGateway.ClearBeforeFill = false;
                flM1ReportGateway.LoadByCompaniesIdSectionId(companyId, companiesId, sectionId);
                flM1ReportGateway.ClearBeforeFill = true;

                UpdateForReport(unitType);
            }
        }



        /// <summary>
        /// LoadByCompaniesIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        /// <param name="date">date</param>
        public void LoadByCompaniesIdDate(int companyId, int companiesId, string unitType, string date)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdDate(companyId, companiesId, date);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="street">street</param>
        public void LoadByCompaniesIdStreet(int companyId, int companiesId, string unitType, string street)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdStreet(companyId, companiesId, street);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="subArea">subArea</param>
        public void LoadByCompaniesIdSubArea(int companyId, int companiesId, string unitType, string subArea)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdSubArea(companyId, companiesId, subArea);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId, string unitType)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="sectionId">sectionId</param>
        public void LoadByCompaniesIdProjectIdSectionId(int companyId, int companiesId, int projectId, string unitType, ArrayList sectionsId)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.ClearBeforeFill = false;
            foreach (string sectionId in sectionsId)
            {
                flM1ReportGateway.LoadByCompaniesIdProjectIdSectionId(companyId, companiesId, projectId, sectionId);
            }
            flM1ReportGateway.ClearBeforeFill = true;

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="date">date</param>
        public void LoadByCompaniesIdProjectIdDate(int companyId, int companiesId, int projectId, string unitType, string date)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdProjectIdDate(companyId, companiesId, projectId, date);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="street">street</param>
        public void LoadByCompaniesIdProjectIdStreet(int companyId, int companiesId, int projectId, string unitType, string street)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdProjectIdStreet(companyId, companiesId, projectId, street);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="subArea">subArea</param>
        public void LoadByCompaniesIdProjectIdSubArea(int companyId, int companiesId, int projectId, string unitType, string subArea)
        {
            FlM1ReportGateway flM1ReportGateway = new FlM1ReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdProjectIdSubArea(companyId, companiesId, projectId, subArea);

            UpdateForReport(unitType);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="unitType">unitType</param>
        private void UpdateForReport(string unitType)
        {
            // Load comments
            foreach (FlM1ReportTDS.M1ReportByClientRow row in (FlM1ReportTDS.M1ReportByClientDataTable)Table)
            {
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(row.WorkID, row.COMPANY_ID);
                row.M1Comments = workGateway.GetComments(row.WorkID);
            }

            // Update for unit type
            FlM1LateralReportGateway flM1LateralReportGateway = new FlM1LateralReportGateway(Data);
            flM1LateralReportGateway.ClearBeforeFill = false;
            FlM1LateralReport flM1LateralReport = new FlM1LateralReport(Data);

            foreach (FlM1ReportTDS.M1ReportByClientRow row in (FlM1ReportTDS.M1ReportByClientDataTable)Table)
            {                
                if (!row.IsM1CommentsNull())
                {
                    row.M1Comments = row.M1Comments.Replace("<br>", "\n");                    
                }

                Distance d;

                if (unitType == "Metric")
                {
                    if (!row.IsSize_Null())
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
                            d = new Distance(row.Size_);
                            row.Size_ = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsLengthNull())
                    {
                        if (Distance.IsValidDistance(row.Length))
                        {
                            d = new Distance(row.Length);
                            row.Length = d.ToStringInMet2();
                        }
                    }

                    if (!row.IsUSMHDepthNull())
                    {
                        if (Distance.IsValidDistance(row.USMHDepth))
                        {
                            d = new Distance(row.USMHDepth);
                            row.USMHDepth = d.ToStringInMet2();
                        }
                    }

                    if (!row.IsDSMHDepthNull())
                    {
                        if (Distance.IsValidDistance(row.DSMHDepth))
                        {
                            d = new Distance(row.DSMHDepth);
                            row.DSMHDepth = d.ToStringInMet2();
                        }
                    }

                    if (!row.IsUSMHMouth12Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth12))
                        {
                            d = new Distance(row.USMHMouth12);
                            row.USMHMouth12 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsUSMHMouth1Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth1))
                        {
                            d = new Distance(row.USMHMouth1);
                            row.USMHMouth1 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsUSMHMouth2Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth2))
                        {
                            d = new Distance(row.USMHMouth2);
                            row.USMHMouth2 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsUSMHMouth3Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth3))
                        {
                            d = new Distance(row.USMHMouth3);
                            row.USMHMouth3 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsUSMHMouth4Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth4))
                        {
                            d = new Distance(row.USMHMouth4);
                            row.USMHMouth4 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsUSMHMouth5Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth5))
                        {
                            d = new Distance(row.USMHMouth5);
                            row.USMHMouth5 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth12Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth12))
                        {
                            d = new Distance(row.DSMHMouth12);
                            row.DSMHMouth12 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth1Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth1))
                        {
                            d = new Distance(row.DSMHMouth1);
                            row.DSMHMouth1 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth2Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth2))
                        {
                            d = new Distance(row.DSMHMouth2);
                            row.DSMHMouth2 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth3Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth3))
                        {
                            d = new Distance(row.DSMHMouth3);
                            row.DSMHMouth3 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth4Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth4))
                        {
                            d = new Distance(row.DSMHMouth4);
                            row.DSMHMouth4 = d.ToStringInMil2();
                        }
                    }

                    if (!row.IsDSMHMouth5Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth5))
                        {
                            d = new Distance(row.DSMHMouth5);
                            row.DSMHMouth5 = d.ToStringInMil2();
                        }
                    }
                }

                if (unitType == "Imperial")
                {
                    if (!row.IsSize_Null())
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {                            
                            Distance distance = new Distance(row.Size_);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.Size_) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                            row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.Size_ = row.Size_ + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsLengthNull())
                    {
                        d = new Distance(row.Length);
                        row.Length = d.ToStringInEng1();
                    }
                                        
                    if (!row.IsUSMHDepthNull())
                    {
                        if (Distance.IsValidDistance(row.USMHDepth))
                        {
                            Distance distance = new Distance(row.USMHDepth);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHDepth = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.Size_) > 99)
                                        {
                                            double newUSMHDepth = 0;
                                            newUSMHDepth = Convert.ToDouble(row.Size_) * 0.03937;
                                            row.USMHDepth = Convert.ToString(Math.Ceiling(newUSMHDepth)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHDepth = row.USMHDepth + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHDepth = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHDepth = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHDepthNull())
                    {
                        if (Distance.IsValidDistance(row.DSMHDepth))
                        {
                            Distance distance = new Distance(row.DSMHDepth);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHDepth = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.Size_) > 99)
                                        {
                                            double newDSMHDepth = 0;
                                            newDSMHDepth = Convert.ToDouble(row.Size_) * 0.03937;
                                            row.DSMHDepth = Convert.ToString(Math.Ceiling(newDSMHDepth)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHDepth = row.USMHDepth + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHDepth = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHDepth = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                    
                    if (!row.IsUSMHMouth12Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth12))
                        {
                            Distance distance = new Distance(row.USMHMouth12);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth12 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth12) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth12) * 0.03937;
                                            row.USMHMouth12 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth12 = row.USMHMouth12 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth12 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth12 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsUSMHMouth1Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth1))
                        {
                            Distance distance = new Distance(row.USMHMouth1);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth1 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth1) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth1) * 0.03937;
                                            row.USMHMouth1 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth1 = row.USMHMouth1 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth1 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth1 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsUSMHMouth2Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth2))
                        {
                            Distance distance = new Distance(row.USMHMouth2);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth2 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth2) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth2) * 0.03937;
                                            row.USMHMouth2 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth2 = row.USMHMouth2 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth2 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth2 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsUSMHMouth3Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth3))
                        {
                            Distance distance = new Distance(row.USMHMouth3);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth3 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth3) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth3) * 0.03937;
                                            row.USMHMouth3 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth3 = row.USMHMouth3 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth3 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth3 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsUSMHMouth4Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth4))
                        {
                            Distance distance = new Distance(row.USMHMouth4);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth4 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth4) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth4) * 0.03937;
                                            row.USMHMouth4 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth4 = row.USMHMouth4 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth4 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth4 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsUSMHMouth5Null())
                    {
                        if (Distance.IsValidDistance(row.USMHMouth5))
                        {
                            Distance distance = new Distance(row.USMHMouth5);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.USMHMouth5 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.USMHMouth5) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.USMHMouth5) * 0.03937;
                                            row.USMHMouth5 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.USMHMouth5 = row.USMHMouth5 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.USMHMouth5 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.USMHMouth5 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth12Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth12))
                        {
                            Distance distance = new Distance(row.DSMHMouth12);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth12 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth12) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth12) * 0.03937;
                                            row.DSMHMouth12 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth12 = row.DSMHMouth12 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth12 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth12 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth1Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth1))
                        {
                            Distance distance = new Distance(row.DSMHMouth1);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth1 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth1) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth1) * 0.03937;
                                            row.DSMHMouth1 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth1 = row.DSMHMouth1 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth1 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth1 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth2Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth2))
                        {
                            Distance distance = new Distance(row.DSMHMouth2);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth2 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth2) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth2) * 0.03937;
                                            row.DSMHMouth2 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth2 = row.DSMHMouth2 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth2 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth2 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth3Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth3))
                        {
                            Distance distance = new Distance(row.DSMHMouth3);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth3 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth3) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth3) * 0.03937;
                                            row.DSMHMouth3 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth3 = row.DSMHMouth3 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth3 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth3 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth4Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth4))
                        {
                            Distance distance = new Distance(row.DSMHMouth4);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth4 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth4) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth4) * 0.03937;
                                            row.DSMHMouth4 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth4 = row.DSMHMouth4 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth4 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth4 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }

                    if (!row.IsDSMHMouth5Null())
                    {
                        if (Distance.IsValidDistance(row.DSMHMouth5))
                        {
                            Distance distance = new Distance(row.DSMHMouth5);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.DSMHMouth5 = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    try
                                    {
                                        if (Convert.ToDouble(row.DSMHMouth5) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.DSMHMouth5) * 0.03937;
                                            row.DSMHMouth5 = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.DSMHMouth5 = row.DSMHMouth5 + "\"";
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case 4:
                                    row.DSMHMouth5 = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.DSMHMouth5 = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                }

                flM1LateralReportGateway.LoadByAssetId(row.AssetID, row.COMPANY_ID);
                flM1LateralReport.UpdateForReport(row.FlowOrderID, unitType);                           
            }
        }



    }
}