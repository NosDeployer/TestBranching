using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// SizeInformation
    /// </summary>
    public class SizeInformation : TableModule
    {
        // ///////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SizeInformation()
            : base("SizeInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SizeInformation(DataSet data)
            : base(data, "SizeInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SizeInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new size
        /// </summary>
        /// <param name="size_">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(string size_, int companyId, bool deleted, bool inDatabase)
        {
            SizeInformationTDS.SizeInformationRow row = ((SizeInformationTDS.SizeInformationDataTable)Table).NewSizeInformationRow();

            row.Size_ = size_;
            row.COMPANY_ID = companyId;
            row.Deleted = deleted;
            row.InDatabase = inDatabase;
            row.Selected = false;

            ((SizeInformationTDS.SizeInformationDataTable)Table).AddSizeInformationRow(row);
        }



        /// <summary>
        /// Update size
        /// </summary>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="companyId">companyId</param>
        public void Update(string originalSize_, string newSize_, int companyId)
        {
            SizeInformationTDS.SizeInformationRow row = GetRow(originalSize_, companyId);
            //row.NewSize_ = newSize_;
            row.Size_ = newSize_;
            row.NewSize_ = originalSize_;
        }



        /// <summary>
        /// Update Selected
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void UpdateSelected(string size_, int companyId, bool selected)
        {
            SizeInformationTDS.SizeInformationRow row = GetRow(size_, companyId);
            row.Selected = selected;
        }



        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        public void Delete(string size_, int companyId)
        {
            SizeInformationTDS.SizeInformationRow row = GetRow(size_, companyId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all size to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            SizeInformationTDS sizeInformationChanges = (SizeInformationTDS)Data.GetChanges();

            if (sizeInformationChanges != null)
            {
                if (sizeInformationChanges.SizeInformation.Rows.Count > 0)
                {
                    SizeInformationGateway sizeInformationGateway = new SizeInformationGateway(sizeInformationChanges);

                    foreach (SizeInformationTDS.SizeInformationRow row in (SizeInformationTDS.SizeInformationDataTable)sizeInformationChanges.SizeInformation)
                    {
                        // Insert new size 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway();
                            WorkPointRepairsRepairPointSize workPointRepairsRepairPointSize = new WorkPointRepairsRepairPointSize(null);

                            workPointRepairsRepairPointSizeGateway.LoadAllBySize_(row.Size_, row.COMPANY_ID);

                            if (workPointRepairsRepairPointSizeGateway.Table.Rows.Count == 0)
                            {
                                workPointRepairsRepairPointSize.InsertDirect(row.Size_, row.COMPANY_ID, row.Deleted);
                            }
                            else
                            {
                                workPointRepairsRepairPointSize.UnDeleteDirect(row.Size_, row.COMPANY_ID);
                            }
                        }

                        // Update size
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            string originalSize_ = row.NewSize_;
                            string newSize_ = row.Size_;
                            int originalCompanyId = companyId;

                            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway();
                            WorkPointRepairsRepairPointSize workPointRepairsRepairPointSize = new WorkPointRepairsRepairPointSize(null);

                            workPointRepairsRepairPointSizeGateway.LoadAllBySize_(newSize_, companyId);

                            if (workPointRepairsRepairPointSizeGateway.Table.Rows.Count == 0)
                            {
                                workPointRepairsRepairPointSize.InsertDirect(newSize_, originalCompanyId, false);
                            }
                            else
                            {
                                workPointRepairsRepairPointSize.UnDeleteDirect(newSize_, originalCompanyId);
                            }

                            if (workPointRepairsRepairPointSizeGateway.IsUsedInPointRepair(originalSize_, companyId))
                            {
                                WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway(null);
                                workPointRepairsRepairGateway.UpdateSize(originalSize_, companyId, newSize_, companyId);
                            }

                            workPointRepairsRepairPointSize.DeleteDirect(originalSize_, companyId);
                        }

                        // Delete size 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            WorkPointRepairsRepairPointSize workPointRepairsRepairPointSize = new WorkPointRepairsRepairPointSize(null);
                            workPointRepairsRepairPointSize.DeleteDirect(row.Size_, row.COMPANY_ID);
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row</returns>
        private SizeInformationTDS.SizeInformationRow GetRow(string size_, int companyId)
        {
            SizeInformationTDS.SizeInformationRow row = ((SizeInformationTDS.SizeInformationDataTable)Table).FindBySize_COMPANY_ID(size_, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.SizeInformation.GetRow");
            }

            return row;
        }



    }
}