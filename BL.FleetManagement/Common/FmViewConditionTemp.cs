using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewConditionTemp
    /// </summary>
    public class FmViewConditionTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewConditionTemp()
            : base("FmViewConditionTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewConditionTemp(DataSet data)
            : base(data, "FmViewConditionTemp")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FmViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        /// <param name="refId">refId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="sign">sign</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int id, int conditionId, string name, int refId, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionTempRow row = ((FmViewTDS.FmViewConditionTempDataTable)Table).NewFmViewConditionTempRow();

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

            ((FmViewTDS.FmViewConditionTempDataTable)Table).AddFmViewConditionTempRow(row);
        }



        /// <summary>
        /// ProcessNew
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void ProcessNew(int viewId, int companyId, string fmType)
        {
            DataRow[] toClear = Table.Select();

            foreach (DataRow rowTemp in toClear)
            {
                Table.Rows.Remove(rowTemp);
            }

            // Add new conditions
            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
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