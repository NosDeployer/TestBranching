using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using System.Collections;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsChecklistRulesTemp
    /// </summary>
    public class UnitsChecklistRulesTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsChecklistRulesTemp()
            : base("UnitsChecklistRulesTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsChecklistRulesTemp(DataSet data)
            : base(data, "UnitsChecklistRulesTemp")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void Load(ArrayList categoriesSelected, int companyLevelId, int companyId)
        {
            int count = 0;

            UnitsChecklistRulesTempGateway unitsChecklistRulesTempGateway = new UnitsChecklistRulesTempGateway(Data);
            unitsChecklistRulesTempGateway.ClearBeforeFill = false;

            foreach (int categoryId in categoriesSelected)
            {
                count = count + 1;
                unitsChecklistRulesTempGateway.LoadByCategoryIdCompanyLevelId(categoryId, companyLevelId, count, companyId);
            }

            //count = count + 1;
            //unitsChecklistRulesTempGateway.LoadByCompanyLevelId(companyLevelId, count, companyId);
            unitsChecklistRulesTempGateway.ClearBeforeFill = true;

            UpdateData();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="count">count</param>
        /// <param name="lastService">lastService</param>
        /// <param name="nextDue">nextDue</param>
        /// <param name="state">state</param>
        /// <param name="done">done</param>
        /// <param name="selected">selected</param>
        public void Update(int ruleId, int count, DateTime? lastService, DateTime? nextDue, string state, bool done, bool selected)
        {
            UnitsAddTDS.UnitsChecklistRulesTempRow row = GetRow(ruleId, count);

            if (lastService.HasValue) row.LastService = (DateTime)lastService;
            if (nextDue.HasValue) row.NextDue = (DateTime)nextDue;
            if (state != "") row.State = state;
            row.Done = done;
            row.Selected = selected;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int unitId, int companyId)
        {
            foreach (UnitsAddTDS.UnitsChecklistRulesTempRow row in (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Data.Tables["UnitsChecklistRulesTemp"])
            {
                string state = "Healthy";
                if (row.Selected)
                {
                    DateTime? lastService = null; if (!row.IsLastServiceNull()) lastService = row.LastService;
                    DateTime? nextDue = null; if (!row.IsNextDueNull()) nextDue = row.NextDue;

                    // Get state
                    state = GetChecklistState(row.RuleID, row.Frequency, lastService, nextDue, companyId);
                    
                    if (row.Frequency != "Only once")
                    {
                        if (lastService.HasValue)
                        {
                            // Get next due
                            DateTime timeToAdded = new DateTime(((DateTime)lastService).Year, ((DateTime)lastService).Month, ((DateTime)lastService).Day);

                            if (row.Frequency == "Monthly") nextDue = timeToAdded.AddMonths(1);
                            if (row.Frequency == "Every 2 months") nextDue = timeToAdded.AddMonths(2);
                            if (row.Frequency == "Every 3 months") nextDue = timeToAdded.AddMonths(3);
                            if (row.Frequency == "Every 4 months") nextDue = timeToAdded.AddMonths(4);
                            if (row.Frequency == "Every 6 months") nextDue = timeToAdded.AddMonths(6);
                            if (row.Frequency == "Yearly") nextDue = timeToAdded.AddYears(1);
                        }
                    }

                    Checklist checklist = new Checklist(null);
                    checklist.InsertDirect(unitId, row.RuleID, lastService, nextDue, row.Done, state, false, companyId);
                }
                else
                {
                    state = "Inactive";

                    DateTime? lastService = null; if (!row.IsLastServiceNull()) lastService = row.LastService;
                    DateTime? nextDue = null; if (!row.IsNextDueNull()) nextDue = row.NextDue;

                    Checklist checklist = new Checklist(null);
                    checklist.InsertDirect(unitId, row.RuleID, lastService, nextDue, row.Done, state, false, companyId);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="count">count</param>
        /// <returns>Row</returns>
        private UnitsAddTDS.UnitsChecklistRulesTempRow GetRow(int ruleId, int count)
        {
            UnitsAddTDS.UnitsChecklistRulesTempRow row = ((UnitsAddTDS.UnitsChecklistRulesTempDataTable)Table).FindByCountRuleID( count, ruleId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsChecklistRulesTemp.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            ArrayList rules = new ArrayList();

            //DataTable temp = new DataTable();
            //temp = Table.Copy();

            foreach (UnitsAddTDS.UnitsChecklistRulesTempRow row in (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Table)
            {
                if (!rules.Contains(row.RuleID))
                {
                    rules.Add(row.RuleID);
                }
                else
                {
                    //Table.Rows.Remove(Table.Rows[temp.Rows.IndexOf(row)]);                    
                    row.Delete();
                }               
            }
            
            Table.DefaultView.Sort = "Name ASC";
            Table.AcceptChanges();
        }

        

        /// <summary>
        /// GetChecklistState
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="frequency">frequency</param>
        /// <param name="lastService">lastService</param>
        /// <param name="nextDue">nextDue</param>
        /// <param name="companyId">companyId</param>
        /// <returns>State</returns>
        private string GetChecklistState(int ruleId, string frequency, DateTime? lastService, DateTime? nextDue, int companyId)
        {
            string state = "Healthy";

            if (nextDue.HasValue)
            {
                if ((DateTime)nextDue < DateTime.Now)
                {
                    state = "Expired";
                }
                else
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    ruleGateway.LoadAllByRuleId(ruleId, companyId);

                    int? alarmDays = ruleGateway.GetAlarmDays(ruleId);

                    if (alarmDays.HasValue)
                    {
                        TimeSpan diference;
                        int daysBeforeNextDue = 0;

                        diference = (DateTime)nextDue - DateTime.Now;
                        daysBeforeNextDue = diference.Days;

                        if (daysBeforeNextDue <= (int)alarmDays)
                        {
                            state = "Warning";
                        }
                    }
                }
            }

            return state;
        }



    }
}
