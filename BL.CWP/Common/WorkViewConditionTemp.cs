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

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewConditionTemp
    /// </summary>
    public class WorkViewConditionTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewConditionTemp()
            : base("WorkViewConditionTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewConditionTemp(DataSet data)
            : base(data, "WorkViewConditionTemp")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertTemp
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conditionId"></param>
        /// <param name="name"></param>
        /// <param name="refId"></param>
        /// <param name="operator_"></param>
        /// <param name="sign"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void Insert(int id, int conditionId, string name, int refId, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionTempRow row = ((WorkViewTDS.WorkViewConditionTempDataTable)Table).NewWorkViewConditionTempRow();

            row.ID = id;
            row.ConditionID = conditionId;
            row.Name = name;
            row.RefID = refId;
            row.Operator = operator_;
            row.Sign = sign;
            row.ConditionNumber = conditionNumber;
            row.Value_ = value_;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((WorkViewTDS.WorkViewConditionTempDataTable)Table).AddWorkViewConditionTempRow(row);
        }



        /// <summary>
        /// ProcessNew
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        public void ProcessNew(int viewId, int companyId, string workType)
        {
            DataRow[] toClear = Table.Select();

            foreach (DataRow rowTemp in toClear)
            {
                Table.Rows.Remove(rowTemp);
            }

            // Add new conditions
            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    int id = rowNew.ID;
                    int conditionId = rowNew.ConditionID;
                    string name = rowNew.Name;
                    int refId = rowNew.RefID;
                    string operator_ = rowNew.Operator;
                    string sign = rowNew.Sign;
                    int conditionNumber = rowNew.ConditionNumber;
                    string value = rowNew.Value_;
                    bool inDatabase = rowNew.InDatabase;
                    bool deleted = rowNew.Deleted;

                    Insert(id, conditionId, name, refId, operator_, sign, conditionNumber, value, false, false);
                }
            }
        }        



    }
}
