using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlAddLateralsNew
    /// </summary>
    public class JlAddLateralsNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlAddLateralsNew() : base("JlAddLateralsNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlAddLateralsNew(DataSet data) : base(data, "JlAddLateralsNew")
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
        /// LoadBySection_ProjectId
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadBySection_ProjectId(int section_, int projectId, int companyId)
        {
            // process temp table
            string filter = string.Format("(SectionAssetID = {0})", section_.ToString());
            DataRow[] toCopy = Data.Tables["JlAddLateralsTemp"].Select(filter);

            foreach (DataRow rowTemp in toCopy)
            {
                string lateralId = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).LateralID;
                string address = ""; if (!((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).IsAddressNull()) address = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).Address;
                string distanceFromUsmh = ""; if (!((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).IsDistanceFromUSMHNull()) distanceFromUsmh = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).DistanceFromUSMH;
                string distanceFromDsmh = ""; if (!((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).IsDistanceFromDSMHNull()) distanceFromDsmh = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).DistanceFromDSMH;
                string state = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).State;
                bool inProject = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).InProject;
                bool inProjectDatabase = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).InProjectDatabase;
                bool inDatabase = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).InDatabase;
                bool deleted = ((JlAddLateralsTDS.JlAddLateralsTempRow)rowTemp).Deleted;

                Insert(lateralId, address, distanceFromUsmh, distanceFromDsmh, state, inProject, inProjectDatabase, inDatabase, deleted);
            }

            // load from database
            if (Table.Rows.Count == 0)
            {
                JlAddLateralsNewGateway jlAddLateralsNewGateway = new JlAddLateralsNewGateway(Data);
                jlAddLateralsNewGateway.LoadBySection_ProjectID(section_, projectId, companyId);
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="lateralId">lateralId</param>
        /// <param name="address">address</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="state">state</param>
        /// <param name="inProject">inProject</param>
        /// <param name="inProjectDatabase">inProjectDatabase</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(string lateralId, string address, string distanceFromUSMH, string distanceFromDSMH, string state, bool inProject, bool inProjectDatabase, bool inDatabase, bool deleted)
        {
            JlAddLateralsTDS.JlAddLateralsNewRow row = ((JlAddLateralsTDS.JlAddLateralsNewDataTable)Table).NewJlAddLateralsNewRow();

            row.AssetID = GetNewAssetId();
            row.LateralID = lateralId;
            if (address.Trim() != "") row.Address = address; else row.SetAddressNull();
            if (distanceFromUSMH.Trim() != "") row.DistanceFromUSMH = distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.Trim() != "") row.DistanceFromDSMH = distanceFromDSMH; else row.SetDistanceFromDSMHNull();
            row.State = state;
            row.InProject = inProject;
            row.InProjectDatabase = inProjectDatabase;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
            
            ((JlAddLateralsTDS.JlAddLateralsNewDataTable)Table).AddJlAddLateralsNewRow(row);
        }
        


        /// <summary>
        /// Update a lateral for insertion
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="address">address</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="inProject">inProject</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Update(int assetId, string lateralId, string address, string distanceFromUSMH, string distanceFromDSMH, bool inProject)
        {
            JlAddLateralsTDS.JlAddLateralsNewRow row = GetRow(assetId);

            row.LateralID = lateralId;
            if (address.Trim() != "") row.Address = address; else row.SetAddressNull();
            if (distanceFromUSMH.Trim() != "") row.DistanceFromUSMH = distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.Trim() != "") row.DistanceFromDSMH = distanceFromDSMH; else row.SetDistanceFromDSMHNull();
            row.InProject = inProject;
        }



        /// <summary>
        /// Delete a section for inserting
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            JlAddLateralsTDS.JlAddLateralsNewRow row = GetRow(id);

            row.Deleted = true;
        }



        /// <summary>
        /// Verify if a lateral exists for inserting
        /// </summary>
        /// <param name="slateralId">lateralId</param>
        /// <returns>True if the lateral exists, otherwise false</returns>
        public bool ExistsByLateralId(string lateralId)
        {
            string filter = string.Format("(LateralID = '{0}') AND (Deleted = 0)", lateralId);

            if (Table.Select(filter).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single lateral. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Row</returns>
        private JlAddLateralsTDS.JlAddLateralsNewRow GetRow(int assetId)
        {
            JlAddLateralsTDS.JlAddLateralsNewRow row = ((JlAddLateralsTDS.JlAddLateralsNewDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.JLAddLateralsNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewAssetId
        /// </summary>
        /// <returns>AssetID</returns>
        private int GetNewAssetId()
        {
            int newAssetId = 0;

            foreach (JlAddLateralsTDS.JlAddLateralsNewRow row in (JlAddLateralsTDS.JlAddLateralsNewDataTable)Table)
            {
                if (newAssetId < row.AssetID)
                {
                    newAssetId = row.AssetID;
                }
            }

            newAssetId++;

            return newAssetId;
        }


               
    }
}

