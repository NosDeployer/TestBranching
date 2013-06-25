using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlM12Report
    /// </summary>
    public class FlM12Report : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM12Report()
            : base("M2_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM12Report(DataSet data)
            : base(data, "M2_SECTION")
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
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.Load(companyId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="date">date</param>
        /// <param name="unitType">unitType</param>
        public void LoadByDate(int companyId, string date, string unitType)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByDate(companyId, date);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="street">street</param>
        /// <param name="unitType">unitType</param>
        public void LoadByStreet(int companyId, string street, string unitType)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByStreet(companyId, street);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadBySubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="unitType">unitType</param>
        public void LoadBySubArea(int companyId, string subArea, string unitType)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadBySubArea(companyId, subArea);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionsId">sectionsId</param>
        /// <param name="unitType">unitType</param>
        public void LoadBySectionId(int companyId, ArrayList sectionsId, string unitType)
        {
            foreach (string sectionId in sectionsId)
            {
                FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
                flM12ReportGateway.ClearBeforeFill = false;
                flM12ReportGateway.LoadBySectionId(companyId, sectionId);
                flM12ReportGateway.ClearBeforeFill = true;

                UpdateForReport(unitType);
            }
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesId(int companyId, int companiesId, string unitType)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId, string unitType)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        /// <param name="sectionsId">sectionsId</param>
        public void LoadByCompaniesIdSectionId(int companyId, int companiesId, string unitType, ArrayList sectionsId)
        {
            foreach (string sectionId in sectionsId)
            {
                FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
                flM12ReportGateway.ClearBeforeFill = false;
                flM12ReportGateway.LoadByCompaniesIdSectionId(companyId, companiesId, sectionId);
                flM12ReportGateway.ClearBeforeFill = true;

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
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdDate(companyId, companiesId, date);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        /// <param name="street">street</param>
        public void LoadByCompaniesIdStreet(int companyId, int companiesId, string unitType, string street)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdStreet(companyId, companiesId, street);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        /// <param name="subArea">subArea</param>
        public void LoadByCompaniesIdSubArea(int companyId, int companiesId, string unitType, string subArea)
        {
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdSubArea(companyId, companiesId, subArea);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="sectionsId">sectionsId</param>
        public void LoadByCompaniesIdProjectIdSectionId(int companyId, int companiesId, int projectId, string unitType, ArrayList sectionsId)
        {
            foreach (string sectionId in sectionsId)
            {
                FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
                flM12ReportGateway.ClearBeforeFill = false;
                flM12ReportGateway.LoadByCompaniesIdProjectIdSectionId(companyId, companiesId, projectId, sectionId);
                flM12ReportGateway.ClearBeforeFill = true;

                UpdateForReport(unitType);
            }
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
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdProjectIdDate(companyId, companiesId, projectId, date);

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
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdProjectIdStreet(companyId, companiesId, projectId, street);

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
            FlM12ReportGateway flM12ReportGateway = new FlM12ReportGateway(Data);
            flM12ReportGateway.LoadByCompaniesIdProjectIdSubArea(companyId, companiesId, projectId, subArea);

            UpdateForReport(unitType);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="unitType">unitType</param>
        public void UpdateForReport(string unitType)
        {
            // Load comments
            foreach (FlM1ReportTDS.M2_SECTIONRow row in (FlM1ReportTDS.M2_SECTIONDataTable)Table)
            {
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(row.WorkID, row.COMPANY_ID);

                row.Comments = workGateway.GetComments(row.WorkID);

                Distance d;

                if (unitType == "Metric")
                {
                    if (!row.IsSize_Null())
                    {
                        d = new Distance(row.Size_);
                        row.Size_ = d.ToStringInMet2();
                    }

                    if (!row.IsVideoLengthNull())
                    {
                        d = new Distance(row.VideoLength);
                        row.VideoLength = d.ToStringInMet2();
                    }

                    if (!row.IsSurfaceGradeNull())
                    {
                        if (row.SurfaceGrade == "0-3 ft")
                        {
                            row.SurfaceGrade = "0-0.91 m";
                        }

                        if (row.SurfaceGrade == "3-6 ft")
                        {
                            row.SurfaceGrade = "0.91-1.83 m";
                        }

                        if (row.SurfaceGrade == "6 ft +")
                        {
                            row.SurfaceGrade = "1.83 m +";
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

                    if (!row.IsVideoLengthNull())
                    {
                        d = new Distance(row.VideoLength);
                        row.VideoLength = d.ToStringInEng1();
                    }
                }
            }

            // Update for unit type
            //foreach (FlM1ReportTDS.M2_SECTIONRow row in (FlM1ReportTDS.M2_SECTIONDataTable)Table)
            //{
                //Distance d;

                //if (unitType == "Metric")
                //{
                //    if (!row.IsSize_Null())
                //    {
                //        d = new Distance(row.Size_);
                //        row.Size_ = d.ToStringInMet2();
                //    }

                //    if (!row.IsVideoLengthNull())
                //    {
                //        d = new Distance(row.VideoLength);
                //        row.VideoLength = d.ToStringInMet2();
                //    }

                //    if (!row.IsSurfaceGradeNull())
                //    {
                //        if (row.SurfaceGrade == "0-3 ft")
                //        {
                //            row.SurfaceGrade = "0-0.91 m";
                //        }

                //        if (row.SurfaceGrade == "3-6 ft")
                //        {
                //            row.SurfaceGrade = "0.91-1.83 m";
                //        }

                //        if (row.SurfaceGrade == "6 ft +")
                //        {
                //            row.SurfaceGrade = "1.83 m +";
                //        }
                //    }
                //}

                //if (unitType == "Imperial")
                //{
                //    if (!row.IsSize_Null())
                //    {
                //        if (Distance.IsValidDistance(row.Size_))
                //        {
                //            Distance distance = new Distance(row.Size_);

                //            switch (distance.DistanceType)
                //            {
                //                case 2:
                //                    row.Size_ = distance.ToStringInEng1();
                //                    break;
                //                case 3:
                //                    if (Convert.ToDouble(row.Size_) > 99)
                //                    {
                //                        double newSize_ = 0;
                //                        newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                //                        row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                //                    }
                //                    else
                //                    {
                //                        row.Size_ = row.Size_ + "\"";
                //                    }
                //                    break;
                //                case 4:
                //                    row.Size_ = distance.ToStringInEng1();
                //                    break;
                //                case 5:
                //                    row.Size_ = distance.ToStringInEng1();
                //                    break;
                //            }
                //        }
                //    }

                //    if (!row.IsVideoLengthNull())
                //    {
                //        d = new Distance(row.VideoLength);
                //        row.VideoLength = d.ToStringInEng1();
                //    }
                //}
            //}
        }



    }
}