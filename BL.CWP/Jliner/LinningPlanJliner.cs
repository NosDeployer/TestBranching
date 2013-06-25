using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// LinningPlanJliner
    /// </summary>
    public class LinningPlanJliner : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LinningPlanJliner() : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LinningPlanJliner(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LinningPlanTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateCommentsForReport
        /// </summary>
        public void UpdateCommentsForReport()
        {
            foreach (LinningPlanTDS.LFS_JUNCTION_LINER2Row row in (LinningPlanTDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }
   
    }
}
