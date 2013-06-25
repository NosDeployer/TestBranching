using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationHotelsInformation
    /// </summary>
    public class ProjectCostingSheetInformationHotelsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationHotelsInformation()
            : base("HotelsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationHotelsInformation(DataSet data)
            : base(data, "HotelsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="hotel">hotel</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, int hotelId, decimal rate, bool deleted, int companyId, string hotel, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.HotelsInformationRow row = ((ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Table).NewHotelsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.HotelID = hotelId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Hotel = hotel;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Table).AddHotelsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int hotelId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.HotelsInformationRow row = GetRow(costingSheetId, hotelId, refId);

            row.CostingSheetID = costingSheetId;
            row.HotelID = hotelId;
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int hotelId, int refId)
        {
            ProjectCostingSheetInformationTDS.HotelsInformationRow row = GetRow(costingSheetId, hotelId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Hotels Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS hotelsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (hotelsInformationChanges.HotelsInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationHotelsInformationGateway projectCostingSheetInformationHotelsInformationGateway = new ProjectCostingSheetInformationHotelsInformationGateway(hotelsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.HotelsInformationRow row in (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)hotelsInformationChanges.HotelsInformation)
                {
                    // Insert new costing sheet Hotels
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetHotels hotels = new ProjectCostingSheetHotels(null);
                        hotels.InsertDirect(costingSheetId, row.HotelID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }

                    // Update costing sheet Hotels
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int hotelId = row.HotelID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        decimal originalRate = projectCostingSheetInformationHotelsInformationGateway.GetRateOriginal(costingSheetId, hotelId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationHotelsInformationGateway.GetStartDateOriginal(costingSheetId, hotelId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationHotelsInformationGateway.GetEndDateOriginal(costingSheetId, hotelId, refId);

                        //original values
                        decimal newRate = projectCostingSheetInformationHotelsInformationGateway.GetRate(costingSheetId, hotelId, refId);
                        DateTime newStartDate = projectCostingSheetInformationHotelsInformationGateway.GetStartDate(costingSheetId, hotelId, refId);
                        DateTime newEndDate = projectCostingSheetInformationHotelsInformationGateway.GetEndDate(costingSheetId, hotelId, refId);

                        ProjectCostingSheetHotels hotels = new ProjectCostingSheetHotels(null);
                        //hotels.UpdateDirect(costingSheetId, hotelId, refId, originalRate, deleted, companyId, originalStartDate, originalEndDate, newRate, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Hotels 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        /*ProjectCostingSheetHotels hotels = new ProjectCostingSheetHotels(null);
                        hotels.DeleteDirect(row.CostingSheetID, row.HotelID, row.RefID, row.COMPANY_ID);*/
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.HotelsInformationRow GetRow(int costingSheetId, int hotelId, int refId)
        {
            ProjectCostingSheetInformationTDS.HotelsInformationRow row = ((ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Table).FindByRefIDHotelIDCostingSheetID(refId, hotelId, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationHotelsInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetInformationTDS.HotelsInformationRow row in (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}