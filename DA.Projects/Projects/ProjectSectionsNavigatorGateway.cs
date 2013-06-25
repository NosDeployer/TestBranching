using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectSectionsNavigatorGateway
    /// </summary>
    public class ProjectSectionsNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSectionsNavigatorGateway()
            : base("LFS_PROJECT_SECTIONS_NAVIGATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSectionsNavigatorGateway(DataSet data)
            : base(data, "LFS_PROJECT_SECTIONS_NAVIGATOR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSectionsNavigatorTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_SECTIONS_NAVIGATOR";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Laterals", "Laterals");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("LateralsDescription", "LateralsDescription");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("RehabAssessment", "RehabAssessment");
            tableMapping.ColumnMappings.Add("FullLengthLining", "FullLengthLining");
            tableMapping.ColumnMappings.Add("JunctionLining", "JunctionLining");
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("WorksDescription", "WorksDescription");
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
        /// LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId
        /// </summary>
        /// <param name="sectionID">sectionID</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        public void LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId(string sectionID, string street, string usmh, string dsmh, int companyId, int projectId)
        {
            string where = "(AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AAS.AssetSewerType = 'Section') AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";

            if (sectionID == "%")
            {
                where = where + " AND ((AASS.SectionID LIKE '%')";
                where = where + " OR (AASS.SectionID IS NULL))";
            }
            else
            {
                if (sectionID != "") where = where + " AND (AASS.FlowOrderID LIKE '%" + sectionID.Trim() + "%')";
            }
            
            if (street != "") where = where + " AND (AASS.Street LIKE '%" + street.Trim() + "%')";
            
            string whereClauseUsmh = "";
            
            // For USMH           
            if (usmh != "")
            {
                whereClauseUsmh = whereClauseUsmh + " AND  (AASS.AssetID IN " +
                         " (SELECT DISTINCT AASS2.AssetID " +
                         "   FROM  AM_ASSET AA2 INNER JOIN " +
                         "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                         "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                         "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                         "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                         "         (SELECT AASS1.AssetID " +
                         "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                         "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                         "          WHERE AASM.MHID LIKE '%" + usmh.Trim() + "%'))))";
            }
            
            // For DSMH
            string whereClauseDsmh = "";

            if (dsmh != "")
            {
                whereClauseUsmh = whereClauseUsmh + " AND (AASS.AssetID IN " +
                        " (SELECT DISTINCT AASS2.AssetID " +
                        "   FROM  AM_ASSET AA2 INNER JOIN " +
                        "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                        "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                        "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                        "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0) AND (AASS2.AssetID IN " +
                        "         (SELECT AASS1.AssetID " +
                        "          FROM AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                        "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                        "          WHERE AASM.MHID LIKE '%" + dsmh.Trim() + "%'))))";
            }

            string whereClauseProject = "";

            whereClauseProject = "AND (AA.AssetID IN (SELECT DISTINCT LW.AssetID " +
                                 "  FROM   LFS_WORK LW " +
                                 "  WHERE  (LW.ProjectID = " + projectId + ") AND (LW.COMPANY_ID = " + companyId + ") AND (LW.Deleted = 0)))";
            
            string commandText = String.Format("SELECT DISTINCT AA.AssetID, AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, "+
                                                " AASS.Laterals, AASS.LiveLaterals, '' AS LateralsDescription, '' AS USMHDescription,  "+
                                                " '' AS DSMHDescription, 0 AS RehabAssessment, 0 AS FullLengthLining, 0 AS JunctionLining, 0 AS WorkID, "+
                                                " '' AS WorksDescription,  CAST (0  AS bit) AS Selected, AASS.FlowOrderID " +
                                                " FROM AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                                                "       AM_ASSET AA ON AA.AssetID = AASS.AssetID INNER JOIN " +
                                                "       AM_ASSET_SEWER AAS ON AASS.AssetID = AAS.AssetID " +
                                                " WHERE {0} {1} {2} {3} ORDER BY AASS.SectionID", where, whereClauseUsmh, whereClauseDsmh, whereClauseProject);
            FillData(commandText);

        }



    }
}