using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlAddLateralsTemp
    /// </summary>
    public class JlAddLateralsTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlAddLateralsTemp() : base("JlAddLateralsTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlAddLateralsTemp(DataSet data) : base(data, "JlAddLateralsTemp")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlAddLateralsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="address">address</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="state">state</param>
        /// <param name="inProject">inProject</param>
        /// <param name="inProjectDatabase">inProjectDatabase</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int assetId, int sectionWorkId, int sectionAssetId, string sectionId, string lateralId, string address, string distanceFromUSMH, string distanceFromDSMH, string state, bool inProject, bool inProjectDatabase, bool inDatabase, bool deleted)
        {
            JlAddLateralsTDS.JlAddLateralsTempRow row = ((JlAddLateralsTDS.JlAddLateralsTempDataTable)Table).NewJlAddLateralsTempRow();

            row.ID = GetNewId();
            row.AssetID = assetId;
            row.SectionWorkID = sectionWorkId;
            row.SectionAssetID = sectionAssetId;
            row.SectionID = sectionId;
            row.LateralID = lateralId;
            if (address.Trim() != "") row.Address = address; else row.SetAddressNull();
            if (distanceFromUSMH.Trim() != "") row.DistanceFromUSMH = distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.Trim() != "") row.DistanceFromDSMH = distanceFromDSMH; else row.SetDistanceFromDSMHNull();
            row.State = state;
            row.InProject = inProject;
            row.InProjectDatabase = inProjectDatabase;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((JlAddLateralsTDS.JlAddLateralsTempDataTable)Table).AddJlAddLateralsTempRow(row);
        }


        
        /// <summary>
        /// Process a new section's table 
        /// </summary>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="sectionId">sectionId</param>
        public void ProcessNew(int sectionWorkId, int sectionAssetId, string sectionId)
        {
            // clear previous laterals for section
            string filter = string.Format("(SectionAssetID = {0})", sectionAssetId.ToString());
            DataRow[] toClear = Table.Select(filter);

            foreach (DataRow rowTemp in toClear)
            {
                Table.Rows.Remove(rowTemp);
            }

            // Add new laterals
            foreach (JlAddLateralsTDS.JlAddLateralsNewRow rowNew in (JlAddLateralsTDS.JlAddLateralsNewDataTable)Data.Tables["JlAddLateralsNew"])
            {
                if (!rowNew.Deleted)
                {
                    int assetId = rowNew.AssetID;
                    string lateralId = rowNew.LateralID;
                    string address = ""; if (!rowNew.IsAddressNull()) address = rowNew.Address;
                    string distanceFromUsmh = ""; if (!rowNew.IsDistanceFromUSMHNull()) distanceFromUsmh = rowNew.DistanceFromUSMH;
                    string distanceFromDsmh = ""; if (!rowNew.IsDistanceFromDSMHNull()) distanceFromDsmh = rowNew.DistanceFromDSMH;
                    string state = rowNew.State;
                    bool inProject = rowNew.InProject;
                    bool inProjectDatabase = rowNew.InProjectDatabase;
                    bool inDatase = rowNew.InDatabase;

                    Insert(assetId, sectionWorkId, sectionAssetId, sectionId, lateralId, address, distanceFromUsmh, distanceFromDsmh, state, inProject, inProjectDatabase, inDatase, false);
                }
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int projectId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            foreach (JlAddLateralsTDS.JlAddLateralsTempRow row in (JlAddLateralsTDS.JlAddLateralsTempDataTable)Table)
            {
                if ((!row.Deleted) && (row.InProject) && (!row.InProjectDatabase))
                {
                    int lateral_assetId = SaveLateral(row, projectId, countryId, provinceId, countyId, cityId, companyId);
                    SaveJLLWork(projectId, lateral_assetId, row.SectionWorkID, companyId);
                }
            }
        }



        /// <summary>
        /// Return a text with all laterals for saved in a database
        /// </summary>
        /// <returns>LateralsSummary</returns>
        public string GetLateralsSummary()
        {
            string lateralsSummary = "";

            foreach (JlAddLateralsTDS.JlAddLateralsTempRow row in (JlAddLateralsTDS.JlAddLateralsTempDataTable)Table)
            {
                string sectionId = row.SectionID;
                string lateralID = row.LateralID;
                string address = "(empty)"; if (!row.IsAddressNull()) address = row.Address;
                string distanceFromUsmh = "(empty)"; if (!row.IsDistanceFromUSMHNull()) distanceFromUsmh = row.DistanceFromUSMH;

                if (!row.Deleted)
                {
                    if (!row.InDatabase)
                    {
                        lateralsSummary = lateralsSummary + "- " + sectionId + ", " + lateralID + ",  " + address + ",  " + distanceFromUsmh + "  (New)\n";
                    }
                    else
                    {
                        if (!row.InProjectDatabase && row.InProject)
                        {
                            lateralsSummary = lateralsSummary + "- " + sectionId + ", " + lateralID + ",  " + address + ",  " + distanceFromUsmh + "  (Added to project)\n";
                        }
                    }
                }
            }

            return lateralsSummary;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>AssetID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (JlAddLateralsTDS.JlAddLateralsTempRow row in (JlAddLateralsTDS.JlAddLateralsTempDataTable)Table)
            {
                if (newId < row.ID)
                {
                    newId = row.ID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// Save a lateral
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>lateral_assetId</returns>
        private int SaveLateral(JlAddLateralsTDS.JlAddLateralsTempRow row, int projectId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            int section_ = row.SectionAssetID;
            string lateralID = row.LateralID;
            string address = ""; if (!row.IsAddressNull()) address = row.Address;
            string distanceFromUSMH = ""; if (!row.IsDistanceFromUSMHNull()) distanceFromUSMH = row.DistanceFromUSMH;
            string distanceFromDSMH = ""; if (!row.IsDistanceFromDSMHNull()) distanceFromDSMH = row.DistanceFromDSMH;
           
            LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
            int lateral_assetId = lfsAssetSewerLateral.InsertDirect(countryId, provinceId, countyId, cityId, row.SectionAssetID, address, lateralID, "", "", "", "", "Live", "", distanceFromUSMH, distanceFromDSMH, "", false, companyId, "");

            return lateral_assetId;
        }



        /// <summary>
        /// Save a lateral work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="lateralAssetId">lateralAssetId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="companyId">companyId</param>
        private void SaveJLLWork(int projectId, int lateralAssetId, int sectionWorkId, int companyId)
        {
            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
            WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(workJunctionLiningLateralGateway.Data);
            workJunctionLiningLateral.InsertDirect(projectId, lateralAssetId, sectionWorkId, null, null, null, null, null, null, null, null, null, "", null, null, null, 0, null, null, null, 0, null, false, false, "", false, null, null, false, companyId, "", "", "", false, null, "", "", "", "", false, null, false, null, false, false, null, false, null, false, null, "", "", false, DateTime.Now, "");    
        }
                

                
    }
}