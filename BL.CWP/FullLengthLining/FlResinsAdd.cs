using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlResinsAdd
    /// </summary>
    public class FlResinsAdd: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlResinsAdd()
            : base("FlResinsAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlResinsAdd(DataSet data)
            : base(data, "FlResinsAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlResinsAddTDS();
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
            FlResinsAddGateway flResinsAddGateway = new FlResinsAddGateway(Data);
            flResinsAddGateway.LoadAll(companyId);
        }



        /// <summary>
        /// LoadByResinId
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByResinId(int resinId,int companyId)
        {
            FlResinsAddGateway flResinsAddGateway = new FlResinsAddGateway(Data);
            flResinsAddGateway.LoadByResinId(resinId, companyId);
        }



        /// <summary>
        /// Insert a new resin
        /// </summary>
        /// <param name="resinMake">resinMake</param>
        /// <param name="resinType">resinType</param>
        /// <param name="resinNumber">resinNumber</param>
        /// <param name="lbUsg">lbUsg</param>
        /// <param name="lbDrums">lbDrums</param>
        /// <param name="activeResin">activeResin</param>
        /// <param name="applyCatalystTo">applyCatalystTo</param>
        /// <param name="filter">filter</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(string resinMake, string resinType, string resinNumber, decimal lbUsg, int lbDrums, decimal activeResin, string applyCatalystTo, decimal filter, bool deleted, int companyId, bool inDatabase)
        {
            FlResinsAddTDS.FlResinsAddRow row = ((FlResinsAddTDS.FlResinsAddDataTable)Table).NewFlResinsAddRow();

            row.ResinID = GetNewId();
            row.ResinMake = resinMake;
            row.ResinType = resinType;
            row.ResinNumber = resinNumber;
            row.LbUsg = lbUsg;
            row.LbDrums = lbDrums;
            row.ActiveResin = activeResin;
            row.ApplyCatalystTo = applyCatalystTo;
            row.Filter = filter;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((FlResinsAddTDS.FlResinsAddDataTable)Table).AddFlResinsAddRow(row);
        }



        /// <summary>
        /// Update a resin
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="resinMake">resinMake</param>
        /// <param name="resinType">resinType</param>
        /// <param name="resinNumber">resinNumber</param>
        /// <param name="lbUsg">lbUsg</param>
        /// <param name="lbDrums">lbDrums</param>
        /// <param name="activeResin">activeResin</param>
        /// <param name="applyCatalystTo">applyCatalystTo</param>
        /// <param name="filter">filter</param>
        public void Update(int resinId, string resinMake, string resinType, string resinNumber, decimal lbUsg, int lbDrums, decimal activeResin, string applyCatalystTo, decimal filter)
        {
            FlResinsAddTDS.FlResinsAddRow row = GetRow(resinId);

            row.ResinMake = resinMake;
            row.ResinType = resinType;
            row.ResinNumber = resinNumber;
            row.LbUsg = lbUsg;
            row.LbDrums = lbDrums;
            row.ActiveResin = activeResin;
            row.ApplyCatalystTo = applyCatalystTo;
            row.Filter = filter;
        }



        /// <summary>
        /// Delete one resin
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="companyId">companyId</param>        
        public void Delete(int resinId, int companyId)
        {
            FlResinsAddTDS.FlResinsAddRow row = GetRow(resinId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all resins to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            FlResinsAddTDS flResinsAddChanges = (FlResinsAddTDS)Data.GetChanges();

            if (flResinsAddChanges.FlResinsAdd.Rows.Count > 0)
            {
                FlResinsAddGateway flResinsAddGateway = new FlResinsAddGateway(flResinsAddChanges);

                foreach (FlResinsAddTDS.FlResinsAddRow row in (FlResinsAddTDS.FlResinsAddDataTable)flResinsAddChanges.FlResinsAdd)
                {
                    // Insert new resins 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        WorkFullLengthLiningResins workFullLengthLiningResins = new WorkFullLengthLiningResins(null);
                        workFullLengthLiningResins.InsertDirect(row.ResinID, row.ResinMake, row.ResinType, row.ResinNumber, row.LbUsg, row.LbDrums, row.ActiveResin, row.ApplyCatalystTo, row.Filter, row.Deleted, row.COMPANY_ID);
                    }

                     //Update resins
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int resinId = row.ResinID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalResinMake = flResinsAddGateway.GetResinMakeOriginal(resinId);
                        string originalResinType = flResinsAddGateway.GetResinTypeOriginal(resinId);
                        string originalResinNumber = flResinsAddGateway.GetResinNumberOriginal(resinId);
                        decimal originalLbUsg = flResinsAddGateway.GetLbUsgOriginal(resinId);
                        int originalLbDrum = flResinsAddGateway.GetLbDrumsOriginal(resinId);
                        decimal originalActiveResin = flResinsAddGateway.GetActiveResinOriginal(resinId);
                        string originalApplyCatalystToNumber = flResinsAddGateway.GetApplyCatalystToOriginal(resinId);
                        decimal originalFilter = flResinsAddGateway.GetFilterOriginal(resinId);

                        // new values
                        string newResinMake = flResinsAddGateway.GetResinMake(resinId);
                        string newResinType = flResinsAddGateway.GetResinType(resinId);
                        string newResinNumber = flResinsAddGateway.GetResinNumber(resinId);
                        decimal newLbUsg = flResinsAddGateway.GetLbUsg(resinId);
                        int newLbDrum = flResinsAddGateway.GetLbDrums(resinId);
                        decimal newActiveResin = flResinsAddGateway.GetActiveResin(resinId);
                        string newApplyCatalystToNumber = flResinsAddGateway.GetApplyCatalystTo(resinId);
                        decimal newFilter = flResinsAddGateway.GetFilter(resinId);

                        WorkFullLengthLiningResins workFullLengthLiningResins = new WorkFullLengthLiningResins(null);
                        workFullLengthLiningResins.UpdateDirect(resinId, originalResinMake, originalResinType, originalResinNumber, originalLbUsg, originalLbDrum, originalActiveResin, originalApplyCatalystToNumber, originalFilter, originalDeleted, originalCompanyId, resinId, newResinMake, newResinType, newResinNumber, newLbUsg, newLbDrum, newActiveResin, newApplyCatalystToNumber, newFilter, originalDeleted, originalCompanyId);                            
                    }

                    // Deleted resins 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        WorkFullLengthLiningResins workFullLengthLiningResins = new WorkFullLengthLiningResins(null);
                        workFullLengthLiningResins.DeleteDirect(row.ResinID, row.COMPANY_ID);
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
            foreach (FlResinsAddTDS.FlResinsAddRow row in (FlResinsAddTDS.FlResinsAddDataTable)Table)
            {
                summary = summary + "Index: " + row.ResinID;
                summary = summary + ", Make: " + row.ResinMake;
                summary = summary + ", Type: " + row.ResinType;
                summary = summary + ", Number : " + row.ResinNumber;
                summary = summary + ", Lb/Usg: " + row.LbUsg.ToString();
                summary = summary + ", lb/Drum: " + row.LbDrums.ToString();
                summary = summary + ", Active Resin (%): " + row.ActiveResin.ToString();
                summary = summary + ", Apply Catalyst To: " + row.ApplyCatalystTo;
                summary = summary + ", Filter (%): " + row.Filter.ToString() + "\n\n";
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

            foreach (FlResinsAddTDS.FlResinsAddRow row in (FlResinsAddTDS.FlResinsAddDataTable)Table)
            {
                if (newId < row.ResinID)
                {
                    newId = row.ResinID;
                }
            }

            newId++;

            return newId;
        }       



        /// <summary>
        /// Get a single resin. If not exists, raise an exception
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>FlResinsAddTDS.FlResinsAddRow</returns>
        private FlResinsAddTDS.FlResinsAddRow GetRow(int resinId)
        {
            FlResinsAddTDS.FlResinsAddRow row = ((FlResinsAddTDS.FlResinsAddDataTable)Table).FindByResinID(resinId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlResinsAdd.GetRow");
            }

            return row;
        }


        



    }
}


