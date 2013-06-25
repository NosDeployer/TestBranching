using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddHotelsInformation
    /// </summary>
    public class ProjectCostingSheetAddHotelsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddHotelsInformation()
            : base("HotelsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddHotelsInformation(DataSet data)
            : base(data, "HotelsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void Load(int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            int refId = 0;

            ProjectCostingSheetAddHotelListGateway projectCostingSheetAddHotelListGateway = new ProjectCostingSheetAddHotelListGateway(Data);
            projectCostingSheetAddHotelListGateway.LoadByProjectIdStartDateEndDate(projectId, startDate, endDate, companyId);

            foreach (ProjectCostingSheetAddTDS.HotelListRow subcontractorListRow in (ProjectCostingSheetAddTDS.HotelListDataTable)projectCostingSheetAddHotelListGateway.Table)
            {
                DateTime newStartDate = new DateTime();
                newStartDate = startDate;
                DateTime newEndDate = new DateTime();
                newEndDate = endDate;

                ProjectCostingSheetAddOriginalHotelGateway projectCostingSheetAddOriginalHotelGateway = new ProjectCostingSheetAddOriginalHotelGateway(Data);
                projectCostingSheetAddOriginalHotelGateway.LoadByProjectIdStartDateEndDateHotelId(projectId, newStartDate, newEndDate, subcontractorListRow.HotelID);

                if (projectCostingSheetAddOriginalHotelGateway.Table.Rows.Count > 0)
                {
                    foreach (ProjectCostingSheetAddTDS.OriginalHotelRow originalHotelRow in (ProjectCostingSheetAddTDS.OriginalHotelDataTable)projectCostingSheetAddOriginalHotelGateway.Table)
                    {
                        ProjectCostingSheetAddTDS.HotelsInformationRow newRow = ((ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table).NewHotelsInformationRow();
                        newRow.CostingSheetID = 0;
                        newRow.HotelID = subcontractorListRow.HotelID;
                        newRow.RefID = refId++;
                        newRow.Rate = originalHotelRow.Rate;
                        newRow.Deleted = false;
                        newRow.InDatabase = false;
                        newRow.COMPANY_ID = companyId;
                        newRow.StartDate = originalHotelRow.Date_;
                        newRow.EndDate = newEndDate;
                        newRow.FromDatabase = true;
                        newRow.Hotel = originalHotelRow.Hotel;
                        newRow.Comment = ""; if (!originalHotelRow.IsCommentNull()) newRow.Comment = originalHotelRow.Comment;

                        ((ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table).AddHotelsInformationRow(newRow);
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int costingSheetId, int hotelId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate, string hotel)
        {
            ProjectCostingSheetAddTDS.HotelsInformationRow row = ((ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table).NewHotelsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.HotelID = hotelId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.Hotel = hotel;

            ((ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table).AddHotelsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int hotelId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.HotelsInformationRow row = GetRow(costingSheetId, hotelId, refId);

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
            ProjectCostingSheetAddTDS.HotelsInformationRow row = GetRow(costingSheetId, hotelId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Hotels Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS changes = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (changes.HotelsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.HotelsInformationRow row in (ProjectCostingSheetAddTDS.HotelsInformationDataTable)changes.HotelsInformation)
                {
                    // Insert new costing sheet Hotels 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetHotels projectCostingSheetHotels = new ProjectCostingSheetHotels(null);
                        projectCostingSheetHotels.InsertDirect(costingSheetId, row.HotelID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="hotelId">hotelId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.HotelsInformationRow GetRow(int costingSheetId, int hotelId, int refId)
        {
            ProjectCostingSheetAddTDS.HotelsInformationRow row = ((ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table).FindByCostingSheetIDHotelIDRefID(costingSheetId, hotelId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddHotelsInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.HotelsInformationRow row in (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Table)
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