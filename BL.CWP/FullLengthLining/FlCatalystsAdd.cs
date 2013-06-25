using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlCatalystsAdd
    /// </summary>
    public class FlCatalystsAdd: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlCatalystsAdd()
            : base("FlCatalystsAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlCatalystsAdd(DataSet data)
            : base(data, "FlCatalystsAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlCatalystsAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            FlCatalystsAddGateway flCatalystsAddGateway = new FlCatalystsAddGateway(Data);
            flCatalystsAddGateway.LoadAll(companyId);
        }



        /// <summary>
        /// LoadByCatalystId
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCatalystId(int catalystId,int companyId)
        {
            FlCatalystsAddGateway flCatalystsAddGateway = new FlCatalystsAddGateway(Data);
            flCatalystsAddGateway.LoadByCatalystId(catalystId, companyId);
        }



        /// <summary>
        /// Insert a new catalyst
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="defaultPercentageByWeight">defaultPercentageByWeight</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(string name, decimal defaultPercentageByWeight, bool deleted, int companyId, bool inDatabase)
        {
            FlCatalystsAddTDS.FlCatalystsAddRow row = ((FlCatalystsAddTDS.FlCatalystsAddDataTable)Table).NewFlCatalystsAddRow();

            row.CatalystID = GetNewId();
            row.Name = name;
            row.DefaultPercentageByWeight = defaultPercentageByWeight;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((FlCatalystsAddTDS.FlCatalystsAddDataTable)Table).AddFlCatalystsAddRow(row);
        }



        /// <summary>
        /// Update a catalyst
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="name">name</param>
        /// <param name="defaultPercentageByWeight">defaultPercentageByWeight</param>
        public void Update(int catalystId, string name, decimal defaultPercentageByWeight)
        {
            FlCatalystsAddTDS.FlCatalystsAddRow row = GetRow(catalystId);

            row.Name = name;
            row.DefaultPercentageByWeight = defaultPercentageByWeight;
        }



        /// <summary>
        /// Delete one catalyst
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="companyId">companyId</param>        
        public void Delete(int catalystId, int companyId)
        {
            FlCatalystsAddTDS.FlCatalystsAddRow row = GetRow(catalystId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all catalysts to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            FlCatalystsAddTDS flCatalystsAddChanges = (FlCatalystsAddTDS)Data.GetChanges();

            if (flCatalystsAddChanges.FlCatalystsAdd.Rows.Count > 0)
            {
                FlCatalystsAddGateway flCatalystsAddGateway = new FlCatalystsAddGateway(flCatalystsAddChanges);

                foreach (FlCatalystsAddTDS.FlCatalystsAddRow row in (FlCatalystsAddTDS.FlCatalystsAddDataTable)flCatalystsAddChanges.FlCatalystsAdd)
                {
                    // Insert new catalysts 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        WorkFullLengthLiningCatalysts workFullLengthLiningCatalysts = new WorkFullLengthLiningCatalysts(null);
                        workFullLengthLiningCatalysts.InsertDirect(row.CatalystID, row.Name, row.DefaultPercentageByWeight, row.Deleted, row.COMPANY_ID);
                    }

                     //Update catalysts
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int catalystId = row.CatalystID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalName = flCatalystsAddGateway.GetNameOriginal(catalystId);
                        decimal originalDefaultPercentageByWeight = flCatalystsAddGateway.GetDefaultPercentageByWeightOriginal(catalystId);

                        // new values
                        string newName = flCatalystsAddGateway.GetName(catalystId);
                        decimal newDefaultPercentageByWeight = flCatalystsAddGateway.GetDefaultPercentageByWeight(catalystId);

                        WorkFullLengthLiningCatalysts workFullLengthLiningCatalysts = new WorkFullLengthLiningCatalysts(null);
                        workFullLengthLiningCatalysts.UpdateDirect(catalystId, originalName, originalDefaultPercentageByWeight, originalDeleted, originalCompanyId, catalystId, newName, newDefaultPercentageByWeight, originalDeleted, originalCompanyId);                            
                    }

                    // Deleted catalysts 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        WorkFullLengthLiningCatalysts workFullLengthLiningCatalysts = new WorkFullLengthLiningCatalysts(null);
                        workFullLengthLiningCatalysts.DeleteDirect(row.CatalystID, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns>Summary</returns>
        public string GetSummary()
        {
            string summary = "";
            foreach (FlCatalystsAddTDS.FlCatalystsAddRow row in (FlCatalystsAddTDS.FlCatalystsAddDataTable)Table)
            {
                summary = summary + "Index: " + row.CatalystID;
                summary = summary + ", Name: " + row.Name;
                summary = summary + ", Defaul % by Weight: " + row.DefaultPercentageByWeight.ToString() + "\n\n";
            }

            return summary;
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (FlCatalystsAddTDS.FlCatalystsAddRow row in (FlCatalystsAddTDS.FlCatalystsAddDataTable)Table)
            {
                if (newId < row.CatalystID)
                {
                    newId = row.CatalystID;
                }
            }

            newId++;

            return newId;
        }       



        /// <summary>
        /// Get a single catalyst. If not exists, raise an exception
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>FlCatalystsAddTDS.FlCatalystsAddRow</returns>
        private FlCatalystsAddTDS.FlCatalystsAddRow GetRow(int catalystId)
        {
            FlCatalystsAddTDS.FlCatalystsAddRow row = ((FlCatalystsAddTDS.FlCatalystsAddDataTable)Table).FindByCatalystID(catalystId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlCatalystsAdd.GetRow");
            }

            return row;
        }


        

    }
}